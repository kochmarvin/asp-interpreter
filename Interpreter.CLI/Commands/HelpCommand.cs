using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interpreter.Lib.Logger;

namespace Interpreter.CLI.Commands
{
  public class HelpCommand : ICommand
  {
    public void Execute(string[] args, CommandManager manager)
    {
      string help = "\nAvailable commands: \n\n"
      + ":l <filePath> | :load <filePath> - Load a specific file with extension .lp \n"
      + ":r | :reload	- Reload the loaded file \n"
      + ":e | :exit - Close the CLI \n"
      + ":i | :info - Show information about the loaded file \n"
      + ":q <query> | :query <query> - Execute a query on the loaded file \n";

      Logger.Information(help);
    }
  }
}
