using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.CLI
{
	public class CommandLineInterpreter
	{
		private readonly CommandFactory _commandFactory;
		private CommandManager _commandManager;

        public CommandLineInterpreter(CommandManager manager)
        {
            _commandFactory = new CommandFactory();
			_commandManager = manager;
        }

        public void Run()
        {
			while (true)
			{
				Console.Write(">");
				var input = Console.ReadLine()?.Trim();
				if (string.IsNullOrEmpty(input))
					continue;

				if (input.StartsWith(":"))
				{
					ExecuteCommand(input);
				}
				else
				{
					Console.WriteLine("Invalid command. Use ':help' to see available commands.");
				}
			}
		}

		private void ExecuteCommand(string command)
		{
			var parts = command.Split(' ');
			var cmd = parts[0].ToLower();

			ICommand cmdObject = _commandFactory.CreateCommand(cmd);

			if (cmdObject != null)
			{
				cmdObject.Execute(parts, _commandManager);
			}
			else
			{
				Console.WriteLine($"Unknown command: {cmd}. Use ':help' to see available commands.");
			}
		}
	}
}
