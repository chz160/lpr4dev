// <copyright file="SessionEventArgsTests.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

using Xunit;

namespace LprServer.Tests;

/// <summary>
///     Defines the <see cref="SessionEventArgsTests" />
/// </summary>
public class SessionEventArgsTests
{
    /// <summary>
    /// </summary>
    [Fact]
    public void Session()
    {
        TestMocks mocks = new TestMocks();

        SessionEventArgs s = new SessionEventArgs(mocks.Session.Object);

        Assert.Equal(s.Session, mocks.Session.Object);
    }
}
