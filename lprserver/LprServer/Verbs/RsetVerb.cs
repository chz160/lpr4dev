// <copyright file="RsetVerb.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System.Threading.Tasks;

namespace LprServer.Verbs;

/// <summary>
///     Defines the <see cref="RsetVerb" />.
/// </summary>
public class RsetVerb : IVerb
{
    /// <inheritdoc />
    public async Task Process(IConnection connection, SmtpCommand command)
    {
        await connection.AbortMessage().ConfigureAwait(false);
        await connection.WriteResponse(new SmtpResponse(StandardSmtpResponseCode.OK, "Rset completed"))
            .ConfigureAwait(false);
    }
}
