using Interpreter.CLI.Options;
using Interpreter.Lib.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.CLI.Commands
{
  public class LoadFileCommand : ICommand
  {
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
}