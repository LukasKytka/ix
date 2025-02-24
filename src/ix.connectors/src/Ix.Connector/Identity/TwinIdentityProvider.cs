﻿// Ix.Connector
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

using System;
using System.Collections.Generic;
using System.Linq;
using Ix.Connector.ValueTypes;

namespace Ix.Connector.Identity;

/// <summary>
///     Provides access to the objects by their identities.
/// </summary>
public class TwinIdentityProvider
{
    private static readonly NullTwinIdentity _nullTwin = new();

    private readonly Connector _connector;
    private readonly Dictionary<OnlinerULInt, ITwinIdentity> _identities = new();

    private readonly List<OnlinerULInt> _identitiesTags = new();

    private readonly SortedDictionary<ulong, ITwinIdentity> _sortedIdentities = new();

    /// <summary>
    ///     Creates new instance of <see cref="TwinIdentityProvider" />.
    /// </summary>
    [Obsolete("Use `TwinIdentityProvider(Connector connector)` instead.")]
    public TwinIdentityProvider()
    {
    }

    /// <summary>
    ///     Creates an instance of <seealso cref="TwinIdentityProvider" />
    /// </summary>
    public TwinIdentityProvider(Connector connector)
    {
        ArgumentNullException.ThrowIfNull(connector);
        _connector = connector;
    }

    /// <summary>
    ///     Get dictionary of identities.
    /// </summary>
    public SortedDictionary<ulong, ITwinIdentity> Identities
    {
        get
        {
            if (_sortedIdentities.Count == 0) SortIdentities();

            return _sortedIdentities;
        }
    }

    /// <summary>
    ///     Get count of identities.
    /// </summary>
    public long IdentitiesCount
    {
        get
        {
            if (_identities != null) return _identities.Count();
            if (_sortedIdentities != null) return _sortedIdentities.Count();

            return 0;
        }
    }

    private ITwinIdentity GetReferencedTwinByIdentity(ITwinIdentity obj)
    {
        try
        {
            if (obj.Identity.GetLastAvailableValue() != 0)
            {
                var vrt = _sortedIdentities.FirstOrDefault(p => p.Key == obj.Identity.GetLastAvailableValue()).Value;
                if (vrt != null)
                {
                    return vrt;
                }

                ((ITwinObject)obj).GetParent().GetConnector().Logger.Debug(
                    $"Identity:'{obj.Identity.GetLastAvailableValue()}' for symbol: '{obj.Symbol}' could was not found.");
                return obj;
            }

            return obj;
        }
        catch (Exception)
        {
            return obj;
        }
    }

    private bool HasMemberByIdentityAttribute(ITwinIdentity obj)
    {
        if (obj is ITwinObject)
        {
            var d = obj as ITwinObject;
            if (d.GetParent() != null && d.GetSymbolTail() != null)
            {
                var property = d.GetParent().GetType().GetProperty(d.GetSymbolTail());
                if (property != null)
                {
                    var a = property.GetCustomAttributes(true)
                        .FirstOrDefault(p => p.GetType() == typeof(MemberByIdentityAttribute));
                    return a != null;
                }
            }
        }

        return false;
    }

    /// <summary>
    ///     Adds twin object to the list of identities.
    /// </summary>
    /// <param name="twinObject">twin object</param>
    public void AddIdentity(ITwinIdentity twinObject)
    {
        ArgumentNullException.ThrowIfNull(twinObject);

        _identitiesTags.Add(twinObject.Identity);

        if (!HasMemberByIdentityAttribute(twinObject)
            && !_identities.ContainsKey(twinObject.Identity))
            _identities.Add(twinObject.Identity, twinObject);
        else
            _connector?.Logger.Debug($"Identity {twinObject.Symbol} : {twinObject.Identity} ignored.");
    }

    /// <summary>
    ///     Gets twin object by identity, if the object implements <see cref="ITwinIdentity" />.
    ///     If object does not implements <see cref="ITwinIdentity" /> the same object is returned.
    /// </summary>
    /// <param name="obj">Object with identity</param>
    /// <returns>twin object with given identity.</returns>
    public dynamic GetTwinByIdentity(object obj)
    {
        ArgumentNullException.ThrowIfNull(obj);
        if (obj is ITwinIdentity identity) return GetTwinByIdentity(identity);

        return obj;
    }

    /// <summary>
    ///     Gets twin object by identity.
    /// </summary>
    /// <param name="obj">Twin object.</param>
    /// <returns>Twin object with given identity.</returns>
    public dynamic GetTwinByIdentity(ITwinIdentity obj)
    {
        ArgumentNullException.ThrowIfNull(obj);
        return GetReferencedTwinByIdentity(obj);
    }

    /// <summary>
    ///     Gets twin object by identity.
    /// </summary>
    /// <param name="identity">Twin identity address.</param>
    /// <returns>Twin object with given identity.</returns>
    public ITwinIdentity GetTwinByIdentity(ulong identity)
    {
        try
        {
            if (identity != 0)
            {
                var vrt = Identities.FirstOrDefault(p => p.Key == identity).Value;
                if (vrt != null)
                    return vrt;
                return _nullTwin;
            }

            return _nullTwin;
        }
        catch (Exception)
        {
            return _nullTwin;
        }
    }

    /// <summary>
    ///     Reads twin objects identities.
    /// </summary>
    /// <returns>Identity onliners.</returns>
    public IEnumerable<OnlinerULInt> ReadIdentities()
    {
        if (_connector != null)
        {
            _connector.Logger.Information("Reading identities...");
            _connector.ReadBatchAsync(_identitiesTags).Wait();
            _connector.Logger.Information("Reading identities done.");
            _connector.Logger.Information(
                $"Number of identities: {_identitiesTags.Count} | Unique :{_identities.Count}");
        }

        return _identitiesTags;
    }

    /// <summary>
    ///     Refreshes and sorts identities.
    /// </summary>
    public void RefreshIdentities()
    {
        ReadIdentities();
        SortIdentities();
    }

    /// <summary>
    ///     Sorts identities.
    /// </summary>
    public void SortIdentities()
    {
        _connector?.Logger.Information("Sorting identities...");
        _sortedIdentities.Clear();
        foreach (var identity in _identities)
        {
            var key = identity.Key.LastValue == 0 ? identity.Key.GetAsync().Result : identity.Key.LastValue;
            if (!_sortedIdentities.ContainsKey(key))
                _sortedIdentities.Add(key, identity.Value);
        }

        _connector?.Logger.Information("Sorting identities done.");
    }
}