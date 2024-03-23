using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.CLI.Commands
{
	public class InfoCommand : ICommand
	{
		public void Execute(string[] args, CommandManager manager)
		{
			if (string.IsNullOrEmpty(manager.FilePath))
			{
                Console.WriteLine("Error: No file has been loaded. Please load a file before executing the info command.");
				return;
            }

            Console.WriteLine($"Loaded file: {manager.FilePath}");
            Console.WriteLine($"Content of file: \n {File.ReadAllText(manager.FilePath)}");
        }
	}
}
