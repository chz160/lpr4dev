// <copyright file="QuitVerb.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System.Threading.Tasks;
using LprServer.Verbs;

namespace LprServer;

/// <summary>
///     Defines the <see cref="QuitVerb" />.
/// </summary>
public class QuitVerb : IVerb
{
    /// <inheritdoc />
    public async Task Process(IConnection connection, SmtpCommand command)
    {
        await connection.WriteResponse(new SmtpResponse(
            StandardSmtpResponseCode.ClosingTransmissionChannel,
            "Goodbye")).ConfigureAwait(false);
        await connection.CloseConnection().ConfigureAwait(false);
        connection.Session.CompletedNormally = true;
    }
}
