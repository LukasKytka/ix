﻿// Ix.Connector
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

namespace Ix.Connector.ValueTypes.Online;

/// <summary>
///     Defines contract to access online value of <see cref="string" />; STRING type of the PLC.
/// </summary>
public interface IOnlineString : IOnline<string>
{
}