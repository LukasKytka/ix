﻿// Ix.Connector
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

using System;
using System.Globalization;
using Ix.Connector.ValueTypes;

namespace Ix.Connector.ValueValidation;

/// <summary>
///     Provides validation rule for <see cref="OnlinerDateTime" /> type.
/// </summary>
public class DateTimeValueValidationRule : OnlinerValidationRule<DateTime>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="DateTimeValueValidationRule" /> class.
    /// </summary>
    /// <param name="onliner">
    ///     Onliner type.
    /// </param>
    public DateTimeValueValidationRule(OnlinerDateTime onliner) : base(onliner)
    {
    }


    /// <summary>
    ///     Validates value of <see cref="OnlinerDateTime" />
    /// </summary>
    /// <param name="value">Value to validate.</param>
    /// <param name="culture">Culture.</param>
    /// <returns>Validation result.</returns>
    public override ValidationResult Validate(DateTime value, CultureInfo culture)
    {
        if (value < Min || value > Max)
        {
            ValidationErrorTip = string.Format("Allowed range is: {0} - {1}.", Min, Max);
            return new ValidationResult(false, ValidationErrorTip);
        }

        return new ValidationResult(true, null);
    }
}