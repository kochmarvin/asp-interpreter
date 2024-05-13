using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.CLI.Commands;

/// <summary>
/// Basic exit command that closes the CLI
/// </summary>
public class ExitCLICommand : ICommand
{
  public void Execute(string[] args, CommandManager manager)
  {
    Environment.Exit(0);
  }
}

