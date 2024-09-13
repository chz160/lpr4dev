// <copyright file="MemorySessionTests.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System;
using System.Net;

namespace LprServer.Tests;

/// <summary>
///     Defines the <see cref="MemorySessionTests" />
/// </summary>
public class MemorySessionTests : AbstractSessionTests
{
    /// <summary>
    /// </summary>
    /// <returns>The <see cref="IEditableSession" /></returns>
    protected override IEditableSession GetSession() => new MemorySession(IPAddress.Loopback, DateTime.Now);
}
