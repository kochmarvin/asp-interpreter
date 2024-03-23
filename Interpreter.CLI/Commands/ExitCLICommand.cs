using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.CLI.Commands
{
	public class ExitCLICommand : ICommand
	{
		public void Execute(string[] args, CommandManager manager)
		{
			Environment.Exit(0);
		}
	}
}
