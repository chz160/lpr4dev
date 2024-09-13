// <copyright file="CommandEventArgs.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System;

namespace LprServer;

/// <summary>
///     Defines the <see cref="CommandEventArgs" />.
/// </summary>
public class CommandEventArgs : EventArgs
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="CommandEventArgs" /> class.
    /// </summary>
    /// <param name="command">The command<see cref="SmtpCommand" />.</param>
    public CommandEventArgs(SmtpCommand command) => Command = command;

    /// <summary>
    ///     Gets the Command.
    /// </summary>
    public SmtpCommand Command { get; private set; }
}
