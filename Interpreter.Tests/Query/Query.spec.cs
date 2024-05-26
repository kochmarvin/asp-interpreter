using Antlr4.Runtime;
using Interpreter.Lib.Graph;
using Interpreter.Lib.Grounder;
using Interpreter.Lib.Results.Objects;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Objects.Terms;
using Interpreter.Lib.Solver;
using Interpreter.Lib.Solver.Defaults;
using Interpreter.Lib.Visitors;
using Interpreter.Tests;
using Interpreter.Tests.Parser;

namespace Tests.Sat;

[TestFixture]
public class QueryTests
{
  [TestCaseSource(nameof(GetTestCases))]
  public void QueryEngine(QueryResult obj)
  {
    List<ProgramRule> program = Utils.ParseProgram(obj.File);
    var graph = new MyDependencyGraph(program, new OrderVisitor(), new MyAddToGraphVisitor());
    var grounder = new Grounding(graph);
    var satEngine = new SatEngine(grounder.Ground());
    List<List<Atom>> results = satEngine.Execute();

    var inputStream = new AntlrInputStream(obj.Query + "?");
    var lexer = new LparseLexer(inputStream);
    var tokens = new CommonTokenStream(lexer);

    var parser = new LparseParser(tokens);

    var tree = parser.program();
    var programVisitor = new QueryVisitor();
    List<Query> parsedQuery = programVisitor.VisitQuery(tree);


    for (int i = 0; i < results.Count; i++)
    {
      var querySolver = new QuerySolver(parsedQuery[0], results[i], new Preparer(new Checker(), new ObjectParser()));
      var answers = querySolver.Answers(true);

      if (answers.Count == 0)
      {
        Assert.That(obj.Expected[i], Is.EqualTo(false));
      }

      foreach (var answer in answers)
      {
        Assert.That(obj.Expected[i], Is.EqualTo(answer.Head.GetHeadAtoms()[0].Args.Count == 0));
      }
    }
  }

  public static IEnumerable<QueryResult> GetTestCases()
  {
    yield return new QueryResult(
      "schraub.lp",
      "a",
      [
        true,
        false,
      ]
    );

    yield return new QueryResult(
      "unsat_1.lp",
      "p",
      [
        false,
      ]
    );

    yield return new QueryResult(
      "unsat_1.lp",
      "-p",
      [
        false,
      ]
    );

    yield return new QueryResult(
     "unsat_2.lp",
     "a",
     [
       false,
     ]
   );

    yield return new QueryResult(
      "unsat_2.lp",
      "b",
      [
        false,
      ]
    );

    yield return new QueryResult(
      "birds.lp",
      "fly(tux), bird(tux)",
      [
        false,
      ]
    );

    yield return new QueryResult(
      "birds.lp",
      "-fly(tux), bird(tux)",
      [
        true,
      ]
    );

    yield return new QueryResult(
      "birds.lp",
      "penguin(tux)",
      [
        true,
      ]
    );

    yield return new QueryResult(
     "birds.lp",
     "penguin(tux), eagle(tux)",
     [
       false,
     ]
   );

    yield return new QueryResult(
      "birds.lp",
      "hello == hello",
      [
        true,
      ]
    );

    yield return new QueryResult(
      "nested.lp",
      "marvin(findet(julia(cool)))",
      [
       true,
      ]
    );

    yield return new QueryResult(
      "faster.lp",
      "isFaster(marvin, michi)",
      [
       true,
      ]
    );

    yield return new QueryResult(
     "faster.lp",
     "isfaster(marvin, michi)",
     [
      false,
     ]
   );

    yield return new QueryResult(
      "fastest.lp",
      "fastest(bike)",
      [
       true,
      ]
    );

    yield return new QueryResult(
      "fastest.lp",
      "fastest(skateboard)",
      [
       false,
      ]
    );

    yield return new QueryResult(
      "fastest.lp",
      "fastest(enterprise)",
      [
       false,
      ]
    );

    yield return new QueryResult(
      "happy.lp",
      "sad(alice), unhappy(bob)",
      [
       true,
      ]
    );

    yield return new QueryResult(
      "range_positive.lp",
      "a(1), a(2), a(3)",
      [
       true,
      ]
    );

    yield return new QueryResult(
     "range_positive.lp",
     "3 < 2",
     [
      false,
     ]
   );

    yield return new QueryResult(
      "range_positive.lp",
      "3 <= 3",
      [
       true,
      ]
    );

    yield return new QueryResult(
      "range_positive.lp",
      "3 > 2",
      [
       true,
      ]
    );

    yield return new QueryResult(
      "range_positive.lp",
      "3 >= 2",
      [
       true,
      ]
    );

    yield return new QueryResult(
      "range_positive.lp",
      "18 != 2",
      [
       true,
      ]
    );

    yield return new QueryResult(
      "range_positive.lp",
      "18 <> 18",
      [
       false,
      ]
    );

    yield return new QueryResult(
     "circular.lp",
     "single(marvin)",
     [
      true,
       false,
     ]
   );

    yield return new QueryResult(
     "circular.lp",
     "married(marvin)",
     [
      false,
       true,
     ]
   );

    yield return new QueryResult(
     "books.lp",
     "assign(bookOne, shelfTwo)",
     [
       true,
     ]
   );
  }
}