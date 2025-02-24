﻿// Ix.Connector
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

using System;
using Ix.Connector.ValueTypes.Online;
using Ix.Connector.ValueTypes.Shadows;
using Ix.Connector.ValueValidation;

namespace Ix.Connector.ValueTypes;

/// <summary>
///     Class providing access to the LTIME type online variable.
/// </summary>
public class OnlinerLTime : OnlinerBase<TimeSpan>, IOnlineLTime, IShadowLTime
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="OnlinerTime" /> class.
    /// </summary>
    public OnlinerLTime()
    {
        validator = new LTimeValueValidationRule(this);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="OnlinerLTime" /> class.
    /// </summary>
    /// <param name="parent">Parent object of this instance.</param>
    /// <param name="readableTail">Human readable tail of this instance.</param>
    /// <param name="symbolTail">Symbol tail of this instance.</param>
    public OnlinerLTime(ITwinObject parent, string readableTail, string symbolTail)
        : base(parent, readableTail, symbolTail)
    {
        validator = new LTimeValueValidationRule(this);
    }

    /// <summary>
    ///     Gets the max value of <see cref="OnlinerLTime" />.
    /// </summary>
    public static TimeSpan MaxValue { get; } = TimeSpan.FromTicks(9223372036854775807 / 100);

    /// <summary>
    ///     Gets the min value of <see cref="OnlinerLTime" />.
    /// </summary>
    public static TimeSpan MinValue { get; } = TimeSpan.FromTicks(-9223372036854775808 / 100);

    /// <summary>
    ///     Gets the max value for this instance.
    /// </summary>
    public override TimeSpan InstanceMaxValue => AttributeMaxSet ? AttributeMaximum : MaxValue;

    /// <summary>
    ///     Gets the min value for this instance.
    /// </summary>
    public override TimeSpan InstanceMinValue => AttributeMinSet ? AttributeMinimum : MinValue;
}