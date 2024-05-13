using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpreter.Lib.Logger;

namespace Interpreter.CLI;

/// <summary>
/// Command line interpreter for the custome CLI
/// </summary>
public class CommandLineInterpreter
{
  private readonly CommandFactory _commandFactory;
  private CommandManager _commandManager;

  public CommandLineInterpreter(CommandManager manager)
  {
    _commandFactory = new CommandFactory();
    _commandManager = manager;
  }

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
        ExecuteCommand(input);
        continue;
      }

      Logger.Error("Invalid command. Use ':help' to see available commands.");
    }
  }

  // Executes the given command and runs it.
  private void ExecuteCommand(string command)
  {
    var parts = command.Split(' ');
    var cmd = parts[0].ToLower();

    ICommand cmdObject = _commandFactory.CreateCommand(cmd);

    if (cmdObject != null)
    {
      cmdObject.Execute(parts, _commandManager);
      return;
    }

    Logger.Error($"Unknown command: {cmd}. Use ':help' to see available commands.");
  }
}