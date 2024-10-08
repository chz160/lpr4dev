﻿// <copyright file="MailFromVerbTests.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System.Threading.Tasks;
using Moq;
using Xunit;

namespace LprServer.Tests.Verbs;

/// <summary>
///     Defines the <see cref="MailFromVerbTests" />
/// </summary>
public class MailFromVerbTests
{
    /// <summary>
    ///     The Process_Address_Bracketed
    /// </summary>
    /// <returns>A <see cref="Task{T}" /> representing the async operation</returns>
    [Fact]
    public async Task Process_Address_Bracketed() =>
        await Process_AddressAsync("<chz160@yahoo.com>", "chz160@yahoo.com", StandardSmtpResponseCode.OK)
            ;

    /// <summary>
    ///     The Process_Address_BracketedWithName
    /// </summary>
    /// <returns>A <see cref="Task{T}" /> representing the async operation</returns>
    [Fact]
    public async Task Process_Address_BracketedWithName() =>
        await Process_AddressAsync("<Noah Porch <chz160@yahoo.com>>", "Noah Porch <chz160@yahoo.com>",
            StandardSmtpResponseCode.OK);

    /// <summary>
    ///     The Process_Address_NonAsciiChars_Rejected
    /// </summary>
    /// <returns>A <see cref="Task{T}" /> representing the async operation</returns>
    [Fact]
    public async Task Process_NonAsciiChars_SmtpUtf8_Accepted() =>
        await Process_AddressAsync("<ظػؿقط <chz160@yahoo.com>>", "ظػؿقط <chz160@yahoo.com>",
            StandardSmtpResponseCode.OK, eightBitMessage: true);

    /// <summary>
    ///     The Process_Address_Plain
    /// </summary>
    /// <returns>A <see cref="Task{T}" /> representing the async operation</returns>
    [Fact]
    public async Task Process_Address_Plain() =>
        await Process_AddressAsync("chz160@yahoo.com", "chz160@yahoo.com", StandardSmtpResponseCode.OK)
            ;

    /// <summary>
    ///     The Process_AlreadyGivenFrom_ErrorResponse
    /// </summary>
    /// <returns>A <see cref="Task{T}" /> representing the async operation</returns>
    [Fact]
    public async Task Process_AlreadyGivenFrom_ErrorResponse()
    {
        TestMocks mocks = new TestMocks();
        mocks.Connection.SetupGet(c => c.CurrentMessage).Returns(new Mock<IMessageBuilder>().Object);

        MailFromVerb mailFromVerb = new MailFromVerb();
        await mailFromVerb.Process(mocks.Connection.Object, new SmtpCommand("FROM <foo@bar.com>"))
            ;

        mocks.VerifyWriteResponse(StandardSmtpResponseCode.BadSequenceOfCommands);
    }

    /// <summary>
    ///     The Process_MissingAddress_ErrorResponse
    /// </summary>
    /// <returns>A <see cref="Task{T}" /> representing the async operation</returns>
    [Fact]
    public async Task Process_MissingAddress_ErrorResponse()
    {
        TestMocks mocks = new TestMocks();

        MailFromVerb mailFromVerb = new MailFromVerb();
        await mailFromVerb.Process(mocks.Connection.Object, new SmtpCommand("FROM"));

        mocks.VerifyWriteResponse(StandardSmtpResponseCode.SyntaxErrorInCommandArguments);
    }

    /// <summary>
    ///     The Process_AddressAsync
    /// </summary>
    /// <param name="address">The address<see cref="string" /></param>
    /// <param name="expectedParsedAddress">The expectedParsedAddress<see cref="string" /></param>
    /// <param name="expectedResponse">The expectedResponse<see cref="StandardSmtpResponseCode" /></param>
    /// <returns>A <see cref="Task{T}" /> representing the async operation</returns>
    private async Task Process_AddressAsync(string address, string expectedParsedAddress,
        StandardSmtpResponseCode expectedResponse, bool asException = false, bool eightBitMessage = false)
    {
        TestMocks mocks = new TestMocks();
        Mock<IMessageBuilder> message = new Mock<IMessageBuilder>();
        message.SetupGet(m => m.EightBitTransport).Returns(eightBitMessage);
        IMessageBuilder currentMessage = null;
        mocks.Connection.Setup(c => c.NewMessage()).ReturnsAsync(() =>
        {
            currentMessage = message.Object;
            return currentMessage;
        });
        mocks.Connection.SetupGet(c => c.CurrentMessage).Returns(() => currentMessage);

        MailFromVerb mailFromVerb = new MailFromVerb();

        if (!asException)
        {
            await mailFromVerb.Process(mocks.Connection.Object, new SmtpCommand("FROM " + address))
                ;
            mocks.VerifyWriteResponse(expectedResponse);
        }
        else
        {
            SmtpServerException e = await Assert.ThrowsAsync<SmtpServerException>(() =>
                mailFromVerb.Process(mocks.Connection.Object, new SmtpCommand("FROM " + address)));
            Assert.Equal((int)expectedResponse, e.SmtpResponse.Code);
        }

        if (expectedParsedAddress != null)
        {
            message.VerifySet(m => m.From = expectedParsedAddress);
        }
    }
}
