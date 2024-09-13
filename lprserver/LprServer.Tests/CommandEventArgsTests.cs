// <copyright file="CommandEventArgsTests.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

using Xunit;

namespace LprServer.Tests;

/// <summary>
///     Defines the <see cref="CommandEventArgsTests" />
/// </summary>
public class CommandEventArgsTests
{
    /// <summary>
    /// </summary>
    [Fact]
    public void Command()
    {
        SmtpCommand command = new SmtpCommand("BLAH");
        CommandEventArgs args = new CommandEventArgs(command);

        Assert.Same(command, args.Command);
    }
}
