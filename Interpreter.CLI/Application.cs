//-----------------------------------------------------------------------
// <copyright file="Application.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.CLI;

using CommandLine;
using Interpreter.CLI.Commands;
using Interpreter.CLI.Options;
using Interpreter.Lib.Logger;

/// <summary>
/// The application class and entry point of the custum CLI.
/// </summary>
public class Application
{
    /// <summary>
    /// This is the starting point of the custom CLI.
    /// </summary>
    /// <param name="args">The useres command line arguments.</param>
    public void Run(string[] args)
    {
        Parser.Default.ParseArguments<CommandLineOptions>(args)
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

          if (!string.IsNullOrEmpty(opts.FilePath) && opts.Explain)
          {
              if (!opts.FilePath.EndsWith(".lp"))
              {
                  Logger.Error("Only files with extension .lp are supported.");
                  return;
              }

              new ExplainCommand().Execute(["explain", opts.FilePath], manager);
              return;
          }

          if (!string.IsNullOrEmpty(opts.Query))
          {
              new QueryCommand().Execute(["query", opts.Query], manager);
              return;
          }

          cli.Run();
      });
    }
}
