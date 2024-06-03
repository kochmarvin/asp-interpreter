//-----------------------------------------------------------------------
// <copyright file="HelpCommand.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.CLI.Commands;

using Interpreter.Lib.Logger;

/// <summary>
/// Basic Help command that prints out the help that prints out all the available commands.
/// </summary>
public class HelpCommand : ICommand
{
    /// <summary>
    /// This method executes the help command of the custom CLI.
    /// </summary>
    /// <param name="args">The given command line arguments.</param>
    /// <param name="manager">The manager class of the commands.</param>
    public void Execute(string[] args, CommandManager manager)
    {
        string help = "\nAvailable commands: \n\n"
        + ":l <filePath> | :load <filePath> - Load a specific file with extension .lp \n"
        + ":ex <filePath> | :explain <filePath> - Explain a specific file with extension .lp \n"
        + ":r | :reload	- Reload the loaded file \n"
        + ":e | :exit - Close the CLI \n"
        + ":i | :info - Show information about the loaded file \n"
        + ":q <query> | :query <query> - Execute a query on the loaded file \n";

        Logger.Information(help);
    }
}
