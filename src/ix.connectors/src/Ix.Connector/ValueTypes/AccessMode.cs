﻿// Ix.Connector
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

namespace Ix.Connector.ValueTypes;

/// <summary>
///     Enumerates permitted access to a tag member.
/// </summary>
public enum ReadWriteAccess
{
    /// <summary>
    ///     Read only.
    /// </summary>
    Read,

    /// <summary>
    ///     Read Write.
    /// </summary>
    ReadWrite
}