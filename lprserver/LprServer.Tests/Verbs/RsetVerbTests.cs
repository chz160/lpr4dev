﻿// <copyright file="RsetVerbTests.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System.Threading.Tasks;
using LprServer.Verbs;
using Xunit;

namespace LprServer.Tests.Verbs;

/// <summary>
///     Defines the <see cref="RsetVerbTests" />
/// </summary>
public class RsetVerbTests
{
    /// <summary>
    /// </summary>
    /// <returns>A <see cref="Task{T}" /> representing the async operation</returns>
    [Fact]
    public async Task ProcessAsync()
    {
        TestMocks mocks = new TestMocks();

        mocks.Connection.Setup(c => c.AbortMessage()).Returns(Task.CompletedTask).Verifiable();

        RsetVerb verb = new RsetVerb();
        await verb.Process(mocks.Connection.Object, new SmtpCommand("RSET"));


        mocks.VerifyWriteResponse(StandardSmtpResponseCode.OK);
        mocks.Connection.Verify();
    }
}
