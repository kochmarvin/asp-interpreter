using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.CLI.Commands
{
	public class ReloadFileCommand : ICommand
	{
		public void Execute(string[] args, CommandManager manager)
		{
			if (string.IsNullOrEmpty(manager.FilePath))
			{
				Console.WriteLine("Error: No file has been loaded. Please load a file before reloading.");
				return;
			}

			manager.LoadFile(manager.FilePath);
		}
	}
}
