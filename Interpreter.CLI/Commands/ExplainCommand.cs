//-----------------------------------------------------------------------
// <copyright file="ExplainCommand.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.CLI.Commands;

using Interpreter.Lib.Logger;

/// <summary>
/// The command that explains the file of the CLI.
/// </summary>
public class ExplainCommand : ICommand
{
  /// <summary>
  /// This method explains the provided file by parsing the explain comments from its content.
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
    manager.ExplainFile(filePath);
  }
}
