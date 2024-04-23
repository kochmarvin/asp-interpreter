using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpreter.Lib.Logger;

namespace Interpreter.CLI.Commands
{
  public class InfoCommand : ICommand
  {
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
}
