﻿// <copyright file="VerbWithSubCommands.cs" company="LprServer project contributors">
// Copyright (c) LprServer project contributors. All rights reserved.
// Licensed under the BSD license. See LICENSE.md file in the project root for full license information.
// </copyright>

using System.Threading.Tasks;

namespace LprServer.Verbs;

/// <summary>
///     Defines the <see cref="VerbWithSubCommands" />.
/// </summary>
public abstract class VerbWithSubCommands : IVerb
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="VerbWithSubCommands" /> class.
    /// </summary>
    protected VerbWithSubCommands()
        : this(new VerbMap())
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="VerbWithSubCommands" /> class.
    /// </summary>
    /// <param name="subVerbMap">The subVerbMap<see cref="IVerbMap" />.</param>
    protected VerbWithSubCommands(IVerbMap subVerbMap) => SubVerbMap = subVerbMap;

    /// <summary>
    ///     Gets the SubVerbMap.
    /// </summary>
    public IVerbMap SubVerbMap { get; }

    /// <summary>
    ///     Dispatches a command to the registered sub command matching the next verb in the command
    ///     or writes an error to the client is no match was found.
    /// </summary>
    /// <param name="connection">The connection<see cref="LprServer.IConnection" />.</param>
    /// <param name="command">The command<see cref="LprServer.SmtpCommand" />.</param>
    /// <returns>
    ///     A <see cref="System.Threading.Tasks.Task" /> representing the async operation.
    /// </returns>
    public virtual async Task Process(IConnection connection, SmtpCommand command)
    {
        SmtpCommand subrequest = new SmtpCommand(command.ArgumentsText);
        IVerb verbProcessor = SubVerbMap.GetVerbProcessor(subrequest.Verb);

        if (verbProcessor != null)
        {
            await verbProcessor.Process(connection, subrequest).ConfigureAwait(false);
        }
        else
        {
            await connection.WriteResponse(
                new SmtpResponse(
                    StandardSmtpResponseCode.CommandParameterNotImplemented,
                    "Subcommand {0} not implemented",
                    subrequest.Verb)).ConfigureAwait(false);
        }
    }
}
