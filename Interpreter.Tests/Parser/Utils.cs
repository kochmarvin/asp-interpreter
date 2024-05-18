using Antlr4.Runtime;
using Interpreter.Lib.Listeners;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Solver;
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

  public static bool AreEqual(List<List<int>> x, List<List<int>> y)
    {
        if (x == null || y == null)
        {
            return x == null && y == null;
        }

        if (x.Count != y.Count)
        {
            return false;
        }

        // Sort each inner list before comparing
        for (int i = 0; i < x.Count; i++)
        {
            x[i].Sort();
            y[i].Sort();
        }

        // Sort outer list before comparing
        x.Sort(CompareLists);
        y.Sort(CompareLists);

        return Enumerable.SequenceEqual(x, y, new ListComparer<int>());
    }

    private static int CompareLists(List<int> list1, List<int> list2)
    {
        if (list1 == null || list2 == null)
        {
            return list1 == null ? (list2 == null ? 0 : -1) : 1;
        }

        for (int i = 0; i < Math.Min(list1.Count, list2.Count); i++)
        {
            int comparison = list1[i].CompareTo(list2[i]);
            if (comparison != 0)
            {
                return comparison;
            }
        }

        return list1.Count.CompareTo(list2.Count);
    }
}