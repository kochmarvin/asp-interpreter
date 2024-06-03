//-----------------------------------------------------------------------
// <copyright file="QueryCommand.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.CLI.Commands;

using Interpreter.Lib.Logger;

/// <summary>
/// Basic Command that get the query and executes it.
/// </summary>
public class QueryCommand : ICommand
{
    /// <summary>
    /// This method gets the query string from the user and executes it on the loaded file.
    /// </summary>
    /// <param name="args">The given command line arguments.</param>
    /// <param name="manager">The manager class of the commands.</param>
  public void Execute(string[] args, CommandManager manager)
  {
    if (args.Length < 2)
    {
      Logger.Error("No query provided.");
      return;
    }

    string query = string.Join(" ", args, 1, args.Length - 1);

    if (manager.FilePath == null)
    {
      Logger.Error("No file has been loaded. Please load a file before executing a query.");
      return;
    }

    Logger.Information($"Executing query: {query}");
    manager.ExecuteQuery(query);
  }
}