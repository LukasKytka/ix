﻿// Ix.Compiler.Cs
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

namespace Ix.Compiler.Cs.Exceptions;

#pragma warning disable CS1591
[Serializable]
public class FailedGettingPackageReferenceException : Exception
{
    public FailedGettingPackageReferenceException(string s, Exception exception)
        : base(s, exception)
    {
    }
#pragma warning restore CS1591
}