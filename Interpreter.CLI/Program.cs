// See https://aka.ms/new-console-template for more information

using CommandLine;
using Interpreter.CLI;
using Interpreter.CLI.Commands;
using Interpreter.CLI.Options;

Parser.Default.ParseArguments<Options>(args)
			.WithParsed(opts =>
			{
				var manager = new CommandManager();
				var cli = new CommandLineInterpreter(manager);

				if (!string.IsNullOrEmpty(opts.FilePath))
				{
					if (opts.FilePath.EndsWith(".lp"))
					{
						new LoadFileCommand().Execute(args, manager);
					}
					else
					{
						Console.WriteLine("Only files with extension .lp are supported.");
						return;
					}
				}

				if (!string.IsNullOrEmpty(opts.Query))
				{
					new QueryCommand().Execute(args, manager);
					return;
				}

				cli.Run();
			});
