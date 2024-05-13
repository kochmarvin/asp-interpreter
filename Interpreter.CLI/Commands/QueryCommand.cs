using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpreter.Lib.Logger;

namespace Interpreter.CLI.Commands;

/// <summary>
/// Basic Command that get the query and executes it.
/// </summary>
public class QueryCommand : ICommand
{
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