// <copyright file="SmtpStreamWriter.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System.IO;
using System.Text;

namespace LprServer;

/// <summary>A stream writer which uses the correct \r\n line ending required for LPR protocol.</summary>
public class SmtpStreamWriter : StreamWriter
{
    /// <summary>Initializes a new instance of the <see cref="SmtpStreamWriter" /> class.</summary>
    /// <param name="stream">The stream to write to.</param>
    /// <param name="leaveOpen">True if stream should be closed when the writer is disposed.</param>
    public SmtpStreamWriter(Stream stream, bool leaveOpen)
        : base(stream, new UTF8Encoding(false, true), 1024 * 24, leaveOpen) =>
        NewLine = "\r\n";
}
