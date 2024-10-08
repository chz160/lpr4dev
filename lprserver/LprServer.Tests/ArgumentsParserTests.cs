﻿// <copyright file="ArgumentsParserTests.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System.Linq;
using Xunit;

namespace LprServer.Tests;

/// <summary>
///     Defines the <see cref="ArgumentsParserTests" />
/// </summary>
public class ArgumentsParserTests
{
    /// <summary>
    ///     The Parsing_FirstArgumentAferVerbWithColon_Split
    /// </summary>
    [Fact]
    public void Parsing_FirstArgumentAferVerbWithColon_Split()
    {
        ArgumentsParser args = new ArgumentsParser("ARG1=VALUE:BLAH");
        Assert.Single(args.Arguments);
        Assert.Equal("ARG1=VALUE:BLAH", args.Arguments.First());
    }

    /// <summary>
    ///     The Parsing_MailFrom_EmailOnly
    /// </summary>
    [Fact]
    public void Parsing_MailFrom_EmailOnly()
    {
        ArgumentsParser args = new ArgumentsParser("<chz160@yahoo.com> ARG1 ARG2");
        Assert.Equal("<chz160@yahoo.com>", args.Arguments.First());
        Assert.Equal("ARG1", args.Arguments.ElementAt(1));
        Assert.Equal("ARG2", args.Arguments.ElementAt(2));
    }

    /// <summary>
    ///     The Parsing_MailFrom_WithDisplayName
    /// </summary>
    [Fact]
    public void Parsing_MailFrom_WithDisplayName()
    {
        ArgumentsParser args = new ArgumentsParser("<Noah Porch<chz160@yahoo.com>> ARG1 ARG2");
        Assert.Equal("<Noah Porch<chz160@yahoo.com>>", args.Arguments.First());
        Assert.Equal("ARG1", args.Arguments.ElementAt(1));
        Assert.Equal("ARG2", args.Arguments.ElementAt(2));
    }
}
