using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Interpreter.Lib.Results;
using Interpreter.Lib.Results.Objects.Rule;

namespace Interpreter.CLI
{
  public class CommandManager
  {
    public string FilePath { get; set; }

    public void LoadFile(string filePath)
    {
      Console.WriteLine($"Loading/Reloading file {filePath}");
      var inputStream = new AntlrInputStream(File.ReadAllText(filePath));
      var lexer = new LparseLexer(inputStream);
      var tokens = new CommonTokenStream(lexer);

      var parser = new LparseParser(tokens);
      var tree = parser.program();

      var programVisitor = new ProgramVisitor();
      List<ProgramRule> rules = programVisitor.Visit(tree);

      foreach (var r in rules)
      {
        Console.WriteLine(r);
      }
    }
  }
}
