using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Interpreter.Lib.Results;

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
      Programm p = programVisitor.Visit(tree);
      Console.WriteLine(p.ToString());
    }
  }
}
