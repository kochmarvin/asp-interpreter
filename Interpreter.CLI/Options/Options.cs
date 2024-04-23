using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter.CLI.Options
{
  public class Options
  {
    [Option('f', "file", Required = false, HelpText = "Load a specific file with extension .lp")]
    public string? FilePath { get; set; }

    [Option('q', "query", Required = false, HelpText = "Execute a query on the loaded file")]
    public string? Query { get; set; }
    [Option("verbose", Required = false, HelpText = "Enable debug output to be shown")]
    public bool Verbose { get; set; }
  }
}
