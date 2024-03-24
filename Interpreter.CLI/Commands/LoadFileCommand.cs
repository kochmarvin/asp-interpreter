using Interpreter.CLI.Options;
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
				Console.WriteLine("Error: No file path provided.");
				return; 
			}

			string filePath = args[1];
      Console.WriteLine(filePath);

			if (!filePath.EndsWith(".lp"))
			{
				Console.WriteLine("Error: Invalid file format. Only files with .lp extension are supported.");
				return; 
			}

			manager.FilePath = filePath;
			manager.LoadFile(filePath);
		}
	}
}
