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
///     Class providing access to the DWORD type online variable.
/// </summary>
public class OnlinerDWord : OnlinerBase<uint>, IOnlineDWord, IShadowDWord
{
    /// <summary>
    ///     Gets the min value of <see cref="OnlinerDWord" />.
    /// </summary>
    public static readonly uint MinValue = uint.MinValue;

    /// <summary>
    ///     Gets the max value of <see cref="OnlinerDWord" />.
    /// </summary>
    public static readonly uint MaxValue = uint.MaxValue;

    /// <summary>
    ///     Initializes a new instance of the <see cref="OnlinerDWord" /> class.
    /// </summary>
    public OnlinerDWord()
    {
        validator = new DWordValueValidationRule(this);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="OnlinerDWord" /> class.
    /// </summary>
    /// <param name="parent">Parent object of this instance.</param>
    /// <param name="readableTail">Human readable tail of this instance.</param>
    /// <param name="symbolTail">Symbol tail of this instance.</param>
    public OnlinerDWord(ITwinObject parent, string readableTail, string symbolTail)
        : base(parent, readableTail, symbolTail)
    {
        validator = new DWordValueValidationRule(this);
    }

    /// <summary>
    ///     Gets the max value for this instance.
    /// </summary>
    public override uint InstanceMaxValue => AttributeMaxSet ? AttributeMaximum : MaxValue;

    /// <summary>
    ///     Gets the min value for this instance.
    /// </summary>
    public override uint InstanceMinValue => AttributeMinSet ? AttributeMinimum : MinValue;
}