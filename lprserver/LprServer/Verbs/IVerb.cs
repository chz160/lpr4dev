// <copyright file="IVerb.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System.Threading.Tasks;

namespace LprServer.Verbs;

/// <summary>
///     Defines the <see cref="IVerb" />.
/// </summary>
public interface IVerb
{
    /// <summary>
    ///     Processes a command which math.
    /// </summary>
    /// <param name="connection">The connection<see cref="LprServer.IConnection" />.</param>
    /// <param name="command">The command<see cref="LprServer.SmtpCommand" />.</param>
    /// <returns>A <see cref="Task{T}" /> representing the async operation.</returns>
    Task Process(IConnection connection, SmtpCommand command);
}
