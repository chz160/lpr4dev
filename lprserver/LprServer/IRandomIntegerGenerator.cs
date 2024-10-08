﻿// <copyright file="IRandomIntegerGenerator.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace LprServer;

/// <summary>
///     Defines the <see cref="IRandomIntegerGenerator" />.
/// </summary>
public interface IRandomIntegerGenerator
{
    /// <summary>
    ///     Generates a random integer in a specfied range.
    /// </summary>
    /// <param name="minValue">The minValue<see cref="int" />.</param>
    /// <param name="maxValue">The maxValue<see cref="int" />.</param>
    /// <returns>
    ///     The <see cref="int" />.
    /// </returns>
    int GenerateRandomInteger(int minValue, int maxValue);
}
