// <copyright file="CurrentDateTimeProvider.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System;

namespace LprServer;

/// <summary>
///     Implements <see cref="ICurrentDateTimeProvider" /> using the real local date time.
/// </summary>
/// <seealso cref="LprServer.ICurrentDateTimeProvider" />
internal class CurrentDateTimeProvider : ICurrentDateTimeProvider
{
    /// <inheritdoc />
    public DateTime GetCurrentDateTime() => DateTime.Now;
}
