﻿// <copyright file="LoginMechanism.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace LprServer.Extensions.Auth;

/// <summary>
///     Defines the <see cref="LoginMechanism" /> implementing the plain text LOGIN auth mechanism.
/// </summary>
public class LoginMechanism : IAuthMechanism
{
    /// <inheritdoc />
    public string Identifier => "LOGIN";

    /// <inheritdoc />
    public bool IsPlainText => true;

    /// <inheritdoc />
    public IAuthMechanismProcessor CreateAuthMechanismProcessor(IConnection connection) =>
        new LoginMechanismProcessor(connection);

    /// <inheritdoc />
    public override bool Equals(object obj) =>
        obj is LoginMechanism mechanism &&
        Identifier == mechanism.Identifier;

    /// <inheritdoc />
    public override int GetHashCode() => Identifier.GetHashCode();
}
