// See https://aka.ms/new-console-template for more information

using CommandLine;
using Interpreter.CLI;
using Interpreter.CLI.Commands;
using Interpreter.CLI.Options;
using Interpreter.Lib.Logger;

Parser.Default.ParseArguments<Options>(args)
      .WithParsed(opts =>
      {
        var manager = new CommandManager();
        var cli = new CommandLineInterpreter(manager);
        Logger.InitLogger(opts.Verbose);
        Logger.Debug("Starting Answer Set Programming Interpreter"); 

        if (!string.IsNullOrEmpty(opts.FilePath))
        {
          if (!opts.FilePath.EndsWith(".lp"))
          {
            Logger.Error("Only files with extension .lp are supported.");
            return;
          }
          new LoadFileCommand().Execute(args, manager);
        }

        if (!string.IsNullOrEmpty(opts.Explain))
        {
          if (!opts.FilePath.EndsWith(".lp"))
          {
            Logger.Error("Only files with extension .lp are supported.");
            return;
          }
          
          new ExplainCommand().Execute(args, manager);
          return;
        }

        if (!string.IsNullOrEmpty(opts.Query))
        {
          new QueryCommand().Execute(args, manager);
          return;
        }

        cli.Run();
      });