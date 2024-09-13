// <copyright file="RandomIntegerGeneratorTests.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

using Xunit;

namespace LprServer.Tests;

/// <summary>
///     Defines the <see cref="RandomIntegerGeneratorTests" />
/// </summary>
public class RandomIntegerGeneratorTests
{
    /// <summary>
    /// </summary>
    [Fact]
    public void GenerateRandomInteger()
    {
        RandomIntegerGenerator randomNumberGenerator = new RandomIntegerGenerator();
        int randomNumber = randomNumberGenerator.GenerateRandomInteger(-100, 100);
        Assert.True(randomNumber >= -100);
        Assert.True(randomNumber <= 100);
    }
}
