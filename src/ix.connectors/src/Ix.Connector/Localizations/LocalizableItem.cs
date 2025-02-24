﻿// Ix.Connector
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

namespace Ix.Localizations;

/// <summary>
///     Provides data object for localizable items.
/// </summary>
public class LocalizableItem
{
    /// <summary>
    ///     Gets or sets the location of the localizable item.
    /// </summary>
    public string Location { get; set; }

    /// <summary>
    ///     Gets or sets the key of the localizable item.
    /// </summary>
    public string Key { get; set; }
}