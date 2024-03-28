using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Interpreter.Lib.Results;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Listeners;
using Interpreter.Lib.Visitors;
using Interpreter.Lib.Graph;
using Interpreter.Lib.Grounder;

namespace Interpreter.CLI
{
  public class CommandManager
  {
    public string FilePath { get; set; }

    public void LoadFile(string filePath)
    {
      Console.WriteLine($"Loading/Reloading file {filePath}");
      try
      {
        var inputStream = new AntlrInputStream(File.ReadAllText(filePath));
        var lexer = new LparseLexer(inputStream);
        var tokens = new CommonTokenStream(lexer);

        var parser = new LparseParser(tokens);
        parser.RemoveErrorListeners();
        parser.AddErrorListener(new SyntaxErrorListener());


        var tree = parser.program();

        var programVisitor = new ProgramVisitor();
        List<ProgramRule> rules = programVisitor.Visit(tree);

        DependencyGraph graph = new DependencyGraph(rules);
        Grounder grounder = new Grounder(graph);
        grounder.Test();

        foreach (var r in rules)
        {
          Console.WriteLine(r);
        }
      }
      catch (Exception e)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(e.StackTrace);
        Console.ResetColor();
      }
    }
  }
}
