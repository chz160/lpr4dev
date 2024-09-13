// <copyright file="AuthExtension.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace LprServer.Extensions.Auth;

/// <summary>
///     Defines the <see cref="AuthExtension" />.
/// </summary>
public class AuthExtension : IExtension
{
    /// <inheritdoc />
    public IExtensionProcessor CreateExtensionProcessor(IConnection connection) =>
        new AuthExtensionProcessor(connection);
}
