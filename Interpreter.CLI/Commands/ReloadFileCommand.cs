//-----------------------------------------------------------------------
// <copyright file="ReloadFileCommand.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.CLI.Commands;

using Interpreter.Lib.Logger;

/// <summary>
/// Basic reload command to reload the file.
/// </summary>
public class ReloadFileCommand : ICommand
{
    /// <summary>
    /// This method executes a reload on an already loaded file.
    /// </summary>
    /// <param name="args">The given command line arguments.</param>
    /// <param name="manager">The manager class of the commands.</param>
    public void Execute(string[] args, CommandManager manager)
    {
        if (string.IsNullOrEmpty(manager.FilePath))
        {
            Logger.Error("No file has been loaded. Please load a file before reloading.");
            return;
        }

        manager.LoadFile(manager.FilePath);
    }
}
