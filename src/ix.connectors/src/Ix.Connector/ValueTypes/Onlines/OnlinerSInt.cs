﻿// Ix.Connector
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

using Ix.Connector.ValueTypes.Online;
using Ix.Connector.ValueTypes.Shadows;
using Ix.Connector.ValueValidation;

namespace Ix.Connector.ValueTypes;

/// <summary>
///     Class providing access to the SINT type online variable.
/// </summary>
public class OnlinerSInt : OnlinerBase<sbyte>, IOnlineSInt, IShadowSInt
{
    /// <summary>
    ///     Gets the min value of <see cref="OnlinerSInt" />.
    /// </summary>
    public static readonly sbyte MinValue = sbyte.MinValue;

    /// <summary>
    ///     Gets the max value of <see cref="OnlinerSInt" />.
    /// </summary>
    public static readonly sbyte MaxValue = sbyte.MaxValue;

    /// <summary>
    ///     Initializes a new instance of the <see cref="OnlinerSInt" /> class.
    /// </summary>
    public OnlinerSInt()
    {
        validator = new SIntValueValidationRule(this);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="OnlinerSInt" /> class.
    /// </summary>
    /// <param name="parent">Parent object of this instance.</param>
    /// <param name="readableTail">Human readable tail of this instance.</param>
    /// <param name="symbolTail">Symbol tail of this instance.</param>
    public OnlinerSInt(ITwinObject parent, string readableTail, string symbolTail)
        : base(parent, readableTail, symbolTail)
    {
        validator = new SIntValueValidationRule(this);
    }

    /// <summary>
    ///     Gets the max value for this instance.
    /// </summary>
    public override sbyte InstanceMaxValue => AttributeMaxSet ? AttributeMaximum : MaxValue;

    /// <summary>
    ///     Gets the min value for this instance.
    /// </summary>
    public override sbyte InstanceMinValue => AttributeMinSet ? AttributeMinimum : MinValue;
}