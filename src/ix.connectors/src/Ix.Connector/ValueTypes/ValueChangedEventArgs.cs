﻿// Ix.Connector
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

using System;

namespace Ix.Connector.ValueTypes;

/// <summary>
///     Provides class for encapsulation of arguments for <see cref="ValueChangedEventHandlerDelegate" />.
/// </summary>
public class ValueChangedEventArgs : EventArgs
{
    /// <summary>Initializes a new instance of the <see cref="ValueChangedEventArgs" /> class.</summary>
    public ValueChangedEventArgs(object newValue)
    {
        NewValue = newValue;
    }

    /// <summary>
    ///     Get new | change value.
    /// </summary>
    public object NewValue { get; internal set; }
}