//-----------------------------------------------------------------------
// <copyright file="CommandFactory.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Interpreter.CLI;

using Interpreter.CLI.Commands;

/// <summary>
/// The command factory class for the custom CLI.
/// </summary>
public class CommandFactory
{
    /// <summary>
    /// Creates a <see cref="ICommand"/> interface out of a given command string.
    /// </summary>
    /// <param name="cmd">The given command as a string.</param>
    /// <returns>A new command interface.</returns>
    public ICommand CreateCommand(string cmd)
    {
        switch (cmd)
        {
            case ":l":
            case ":load":
                return new LoadFileCommand();
            case ":r":
            case ":reload":
                return new ReloadFileCommand();
            case ":e":
            case ":exit":
                return new ExitCLICommand();
            case ":i":
            case ":info":
                return new InfoCommand();
            case ":q":
            case ":query":
                return new QueryCommand();
            case ":h":
            case ":help":
                return new HelpCommand();
            case ":ex":
            case ":explain":
                return new ExplainCommand();
            default:
                return null;
        }
    }
}
