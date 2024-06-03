//-----------------------------------------------------------------------
// <copyright file="ICommand.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.CLI;

/// <summary>
/// The public interface of the command of the custom CLI.
/// </summary>
public interface ICommand
{
    /// <summary>
    /// The method that executes the command.
    /// </summary>
    /// <param name="args">The given command line arguments.</param>
    /// <param name="manager">The manager for the commands.</param>
    void Execute(string[] args, CommandManager manager);
}