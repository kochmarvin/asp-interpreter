//-----------------------------------------------------------------------
// <copyright file="CommandLineInterpreter.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Interpreter.CLI;

using System;
using Interpreter.Lib.Logger;

/// <summary>
/// Command line interpreter for the custome CLI.
/// </summary>
public class CommandLineInterpreter
{
    private readonly CommandFactory commandFactory;
    private CommandManager commandManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="CommandLineInterpreter"/> class.
    /// </summary>
    /// <param name="manager">The command manager used in the interpreter.</param>
    public CommandLineInterpreter(CommandManager manager)
    {
        this.commandFactory = new CommandFactory();
        this.commandManager = manager;
    }

    /// <summary>
    /// This method starts the CLI.
    /// </summary>
    public void Run()
    {
        // Runs endless until you enter the exit command
        while (true)
        {
            Console.Write(">");
            var input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input))
            {
                continue;
            }

            if (input.StartsWith(":"))
            {
                this.ExecuteCommand(input);
                continue;
            }

            Logger.Error("Invalid command. Use ':help' to see available commands.");
        }
    }

    /// <summary>
    /// Executes the given command and runs it.
    /// </summary>
    /// <param name="command">The command to run on the CLI.</param>
    private void ExecuteCommand(string command)
    {
        var parts = command.Split(' ');
        var cmd = parts[0].ToLower();

        ICommand cmdObject = this.commandFactory.CreateCommand(cmd);

        if (cmdObject != null)
        {
            cmdObject.Execute(parts, this.commandManager);
            return;
        }

        Logger.Error($"Unknown command: {cmd}. Use ':help' to see available commands.");
    }
}