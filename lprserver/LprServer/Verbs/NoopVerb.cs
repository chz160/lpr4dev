// <copyright file="NoopVerb.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System.Threading.Tasks;

namespace LprServer.Verbs;

/// <summary>
///     Defines the <see cref="NoopVerb" />.
/// </summary>
public class NoopVerb : IVerb
{
    /// <inheritdoc />
    public async Task Process(IConnection connection, SmtpCommand command) =>
        await connection.WriteResponse(new SmtpResponse(StandardSmtpResponseCode.OK, "Successfully did nothing"))
            .ConfigureAwait(false);
}
