﻿// Ix.Compiler
// Copyright (c) 2023 Peter Kurhajec (PTKu), MTS,  and Contributors. All Rights Reserved.
// Contributors: https://github.com/ix-ax/ix/graphs/contributors
// See the LICENSE file in the repository root for more information.
// https://github.com/ix-ax/ix/blob/master/LICENSE
// Third party licenses: https://github.com/ix-ax/ix/blob/master/notices.md

using Serilog;
using Serilog.Core;

namespace Ix.Compiler;

/// <summary>
///     Provides logger for the compiler.
/// </summary>
public static class Log
{
    static Log()
    {
        Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
    }

    /// <summary>
    ///     Gets the logger.
    /// </summary>
    public static Logger Logger { get; }
}