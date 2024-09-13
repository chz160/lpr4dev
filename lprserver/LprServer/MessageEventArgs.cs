// <copyright file="MessageEventArgs.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System;

namespace LprServer;

/// <summary>
///     Defines the <see cref="MessageEventArgs" />.
/// </summary>
public class MessageEventArgs : EventArgs
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MessageEventArgs" /> class.
    /// </summary>
    /// <param name="message">The message<see cref="IMessage" />.</param>
    public MessageEventArgs(IMessage message) => Message = message;

    /// <summary>
    ///     Gets the Message.
    /// </summary>
    public IMessage Message { get; private set; }
}
