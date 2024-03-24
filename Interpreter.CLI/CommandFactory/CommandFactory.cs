using Interpreter.CLI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.CLI
{
	public class CommandFactory
	{
		public ICommand CreateCommand(string cmd)
		{
			switch (cmd)
			{
				case ":l":
				case ":load":
					return new LoadFileCommand();
				case ":r":
				case ":reload":
					return new ReloadFileCommand();
				case ":e":
				case ":exit":
					return new ExitCLICommand();
				case ":i":
				case ":info":
					return new InfoCommand();
				case ":q":
				case ":query":
					return new QueryCommand();
				case ":h":
				case ":help":
					return new HelpCommand();
				default:
					return null;
			}
		}
	}
}
