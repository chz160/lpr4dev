// <copyright file="AuthenticationResult.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace LprServer;

/// <summary>
///     Defines the AuthenticationResult.
/// </summary>
public enum AuthenticationResult
{
    /// <summary>
    ///     Defines the Success
    /// </summary>
    Success,

    /// <summary>
    ///     Defines the Failure
    /// </summary>
    Failure,

    /// <summary>
    ///     Defines the TemporaryFailure
    /// </summary>
    TemporaryFailure
}
