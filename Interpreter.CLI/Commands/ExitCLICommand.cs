//-----------------------------------------------------------------------
// <copyright file="ExitCLICommand.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Interpreter.CLI.Commands;

using System;

/// <summary>
/// Basic exit command that closes the CLI.
/// </summary>
public class ExitCLICommand : ICommand
{
    /// <summary>
    /// Executes the exit command of the CLI.
    /// </summary>
    /// <param name="args">The given command line arguments.</param>
    /// <param name="manager">The manager class of the commands.</param>
    public void Execute(string[] args, CommandManager manager)
    {
        Environment.Exit(0);
    }
}