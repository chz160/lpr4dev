﻿// <copyright file="SmtpStringBuilder.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System.Text;

namespace LprServer;

/// <summary>Builds a multi line string where each line has the CRLF terminator required for LPR.</summary>
public class SmtpStringBuilder
{
    private readonly StringBuilder innerStringBuilder = new();

    /// <summary>Appends a line to the string and terminates it with the correct CRLF required for LPR.</summary>
    /// <param name="text">The text.</param>
    public void AppendLine(string text)
    {
        innerStringBuilder.Append(text);
        innerStringBuilder.Append("\r\n");
    }

    /// <summary>  Returns the complete string including all lines which have been appended separated with the correct CRLF.</summary>
    /// <returns>A <see cref="string" /> that represents this instance.</returns>
    public override string ToString() => innerStringBuilder.ToString();
}
