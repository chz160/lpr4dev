// <copyright file="Logging.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

using Microsoft.Extensions.Logging;

namespace LprServer;

/// <summary>
///     Helper class implementing logging.
/// </summary>
internal static class Logging
{
    /// <summary>
    ///     Gets the logging factory.
    /// </summary>
    /// <value>
    ///     The factory.
    /// </value>
    public static ILoggerFactory Factory { get; } = new LoggerFactory();
}
