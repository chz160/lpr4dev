﻿// <copyright file="RcptToVerbTests.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LprServer.Tests.Verbs;

/// <summary>
///     Defines the <see cref="RcptToVerbTests" />
/// </summary>
public class RcptToVerbTests
{
    /// <summary>
    /// </summary>
    /// <returns>A <see cref="Task{T}" /> representing the async operation</returns>
    [Fact]
    public async Task EmailAddressOnly() =>
        await TestGoodAddressAsync("<chz160@yahoo.com>", "chz160@yahoo.com");

    /// <summary>
    /// </summary>
    /// <returns>A <see cref="Task{T}" /> representing the async operation</returns>
    [Fact]
    public async Task EmailAddressWithDisplayName() =>
        //Should this format be accepted????
        await TestGoodAddressAsync("<Noah Porch<chz160@yahoo.com>>", "Noah Porch<chz160@yahoo.com>")
            ;

    /// <summary>
    ///     The EmptyAddress_ReturnsError
    /// </summary>
    /// <returns>A <see cref="Task{T}" /> representing the async operation</returns>
    [Fact]
    public async Task EmptyAddress_ReturnsError() => await TestBadAddressAsync("<>");

    /// <summary>
    ///     The MismatchedBraket_ReturnsError
    /// </summary>
    /// <returns>A <see cref="Task{T}" /> representing the async operation</returns>
    [Fact]
    public async Task MismatchedBraket_ReturnsError()
    {
        await TestBadAddressAsync("<chz160@yahoo.com");
        await TestBadAddressAsync("<Noah Porch<chz160@yahoo.com>");
    }

    /// <summary>
    ///     The UnbraketedAddress_ReturnsError
    /// </summary>
    /// <returns>A <see cref="Task{T}" /> representing the async operation</returns>
    [Fact]
    public async Task UnbraketedAddress_ReturnsError() =>
        await TestBadAddressAsync("chz160@yahoo.com");


    [Fact]
    public async Task NonAsciiAddress_SmtpUtf8_Accepted() =>
        await TestGoodAddressAsync("<ظػؿقط <chz160@yahoo.com>>", "ظػؿقط <chz160@yahoo.com>", true)
            ;


    /// <summary>
    /// </summary>
    /// <param name="address">The address<see cref="string" /></param>
    /// <returns>A <see cref="Task{T}" /> representing the async operation</returns>
    private async Task TestBadAddressAsync(string address, bool asException = false)
    {
        TestMocks mocks = new TestMocks();
        MemoryMessageBuilder messageBuilder = new MemoryMessageBuilder();
        mocks.Connection.SetupGet(c => c.CurrentMessage).Returns(messageBuilder);

        RcptToVerb verb = new RcptToVerb();

        if (!asException)
        {
            await verb.Process(mocks.Connection.Object, new SmtpCommand("TO " + address));
            mocks.VerifyWriteResponse(StandardSmtpResponseCode.SyntaxErrorInCommandArguments);
        }
        else
        {
            SmtpServerException e = await Assert
                .ThrowsAsync<SmtpServerException>(() =>
                    verb.Process(mocks.Connection.Object, new SmtpCommand("TO " + address)));
            Assert.Equal((int)StandardSmtpResponseCode.SyntaxErrorInCommandArguments, e.SmtpResponse.Code);
        }

        Assert.Empty(messageBuilder.Recipients);
    }

    /// <summary>
    /// </summary>
    /// <param name="address">The address<see cref="string" /></param>
    /// <param name="expectedAddress">The expectedAddress<see cref="string" /></param>
    /// <returns>A <see cref="Task{T}" /> representing the async operation</returns>
    private async Task TestGoodAddressAsync(string address, string expectedAddress, bool eightBit = false)
    {
        TestMocks mocks = new TestMocks();
        MemoryMessageBuilder messageBuilder = new MemoryMessageBuilder();
        messageBuilder.EightBitTransport = eightBit;
        mocks.Connection.SetupGet(c => c.CurrentMessage).Returns(messageBuilder);

        RcptToVerb verb = new RcptToVerb();
        await verb.Process(mocks.Connection.Object, new SmtpCommand("TO " + address));

        mocks.VerifyWriteResponse(StandardSmtpResponseCode.OK);
        Assert.Equal(expectedAddress, messageBuilder.Recipients.First());
    }
}
