// <copyright file="AnonymousAuthenticationCredentials.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace LprServer.Extensions.Auth;

/// <summary>
///     Defines the <see cref="AnonymousAuthenticationCredentials" />.
/// </summary>
public class AnonymousAuthenticationCredentials : IAuthenticationCredentials
{
    /// <inheritdoc />
    public string Type
    {
        get => "NONE";
    }
}
