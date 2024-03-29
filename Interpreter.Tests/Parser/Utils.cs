using Antlr4.Runtime;
using Interpreter.Lib.Listeners;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Visitors;

namespace Interpreter.Tests.Parser;

public static class Utils
{
  public static string BASE_URL = "../../../Files/";
  public static List<ProgramRule> ParseProgram(string filename)
  {
    var inputStream = new AntlrInputStream(File.ReadAllText(BASE_URL + filename));
    var lexer = new LparseLexer(inputStream);
    var tokens = new CommonTokenStream(lexer);

    var parser = new LparseParser(tokens);
    parser.RemoveErrorListeners();
    parser.AddErrorListener(new SyntaxErrorListener());


    var tree = parser.program();

    var programVisitor = new ProgramVisitor();
    return programVisitor.Visit(tree);
  }
}