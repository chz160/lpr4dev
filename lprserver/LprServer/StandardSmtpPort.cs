﻿// <copyright file="StandardSmtpPort.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace LprServer;

/// <summary>
///     Enumeration of the different standard TCP ports that the server can listen on.
/// </summary>
public enum StandardSmtpPort
{
    /// <summary>
    ///     Select a free port number automatically
    /// </summary>
    AssignAutomatically = 0,

    /// <summary>
    ///     Use the standard IANA SMTP port - 25
    /// </summary>
    SMTP = 25,

    /// <summary>
    ///     Use the standard IANA SMTP-over-SSL port - 465
    /// </summary>
    SMTPOverSSL = 465
}
