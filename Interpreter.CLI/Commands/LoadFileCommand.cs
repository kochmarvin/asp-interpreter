﻿//-----------------------------------------------------------------------
// <copyright file="LoadFileCommand.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.CLI.Commands;

using Interpreter.Lib.Logger;

/// <summary>
/// Parses the CLI arguments in a way that you can enter a path and executed the file.
/// </summary>
public class LoadFileCommand : ICommand
{
    /// <summary>
    /// Executes the load file command of the custom CLI.
    /// </summary>
    /// <param name="args">The given command line arguments.</param>
    /// <param name="manager">The manager class of the commands.</param>
    public void Execute(string[] args, CommandManager manager)
    {
        if (args.Length < 2)
        {
            Logger.Error("No file path provided.");
            return;
        }

        string filePath;
        if (args[1].Contains('"'))
        {
            string command = string.Join(" ", args[1..]);

            int firstQuoteIndex = command.IndexOf('"');
            int secondQuoteIndex = command.IndexOf('"', firstQuoteIndex + 1);

            if (firstQuoteIndex == -1 || secondQuoteIndex == -1)
            {
                Logger.Error("Invalid file path format. Use double quotes to encapsulate the file path.");
                return;
            }

            filePath = command.Substring(firstQuoteIndex + 1, secondQuoteIndex - firstQuoteIndex - 1);
        }
        else
        {
            filePath = args[1];
        }

        if (!filePath.EndsWith(".lp"))
        {
            Logger.Error("Invalid file format. Only files with .lp extension are supported.");
            return;
        }

        manager.FilePath = filePath;
        manager.LoadFile(filePath);
    }
}