﻿// <copyright file="LoginAuthenticationCredentials.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace LprServer.Extensions.Auth;

/// <summary>
///     Defines the <see cref="LoginAuthenticationCredentials" />.
/// </summary>
public class LoginAuthenticationCredentials : UsernameAndPasswordAuthenticationCredentials
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="LoginAuthenticationCredentials" /> class.
    /// </summary>
    /// <param name="username">The username<see cref="string" />.</param>
    /// <param name="password">The password<see cref="string" />.</param>
    public LoginAuthenticationCredentials(string username, string password)
        : base(username, password)
    {
    }
}
