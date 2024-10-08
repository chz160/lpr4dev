﻿// <copyright file="AuthMechanismProcessorStatus.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace LprServer.Extensions.Auth;

/// <summary>
///     Defines the AuthMechanismProcessorStatus.
/// </summary>
#pragma warning disable CA1717 // Only FlagsAttribute enums should have plural names
public enum AuthMechanismProcessorStatus
{
    /// <summary>
    ///     Defines the Continue
    /// </summary>
    Continue,

    /// <summary>
    ///     Defines the Failed
    /// </summary>
    Failed,

    /// <summary>
    ///     Defines the Success
    /// </summary>
    Success
}
#pragma warning restore CA1717 // Only FlagsAttribute enums should have plural names
