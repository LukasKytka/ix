﻿// Ix.Abstractions
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

using System;

public class RenderAuthorizedAttribute : Attribute
{
    public readonly string Permissions;

    public RenderAuthorizedAttribute(string permissions)
    {
        Permissions = permissions;
    }
}