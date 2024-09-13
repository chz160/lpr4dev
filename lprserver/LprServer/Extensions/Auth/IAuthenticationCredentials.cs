// <copyright file="IAuthenticationCredentials.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace LprServer.Extensions.Auth;
/// <summary>
///     Represents credentials supplied by the client.
/// </summary>
public interface IAuthenticationCredentials
{
    /// <summary>
    /// Gets a string representing the type of this credential.
    /// </summary>
    string Type { get;  }

}
