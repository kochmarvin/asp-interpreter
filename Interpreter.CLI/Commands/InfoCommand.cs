//-----------------------------------------------------------------------
// <copyright file="InfoCommand.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.CLI.Commands;

using Interpreter.Lib.Logger;

/// <summary>
/// Basic information command that prints out all informations about the file (just the content).
/// </summary>
public class InfoCommand : ICommand
{
    /// <summary>
    /// This method executes the info command of the custom CLI.
    /// </summary>
    /// <param name="args">The given command line arguments.</param>
    /// <param name="manager">The manager class of the commands.</param>
    public void Execute(string[] args, CommandManager manager)
    {
        if (string.IsNullOrEmpty(manager.FilePath))
        {
            Logger.Error("No file has been loaded. Please load a file before executing the info command.");
            return;
        }

        Logger.Information($"Loaded file: {manager.FilePath}");
        Logger.Information($"Content of file: \n {File.ReadAllText(manager.FilePath)}");
    }
}