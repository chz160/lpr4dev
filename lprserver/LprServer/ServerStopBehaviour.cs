// <copyright file="ServerStopOptions.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace LprServer;

/// <summary>
///     Defines the ServerStopOptions.
/// </summary>
public enum ServerStopOptions
{
    /// <summary>
    ///     Defines the WaitForExistingConnections
    /// </summary>
    WaitForExistingConnections,

    /// <summary>
    ///     Defines the KillExistingConnections
    /// </summary>
    KillExistingConnections
}
