using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.CLI.Commands
{
	public class HelpCommand : ICommand
	{
		public void Execute(string[] args, CommandManager manager)
		{
			Console.WriteLine("Available commands:");
			Console.WriteLine(":l <filePath> | :load <filePath> - Load a specific file with extension .lp");
			Console.WriteLine(":r | :reload	- Reload the loaded file");
			Console.WriteLine(":e | :exit - Close the CLI");
			Console.WriteLine(":i | :info - Show information about the loaded file");
			Console.WriteLine(":q <query> | :query <query> - Execute a query on the loaded file");
		}
	}
}
