using Interpreter.Lib.Graph;
using Interpreter.Lib.Grounder;
using Interpreter.Lib.Results.Objects.Rule;

using Interpreter.Lib.Solver;
using Interpreter.Lib.Solver.Defaults;
using Interpreter.Tests;
using Interpreter.Tests.Parser;

namespace Tests.Solver;

[TestFixture]
public class SolverTests
{
  [TestCaseSource(nameof(GetTestCases))]
  public void DPLLSolver(DPLLTestResults obj)
  {
    List<ProgramRule> program = Utils.ParseProgram(obj.File);
    var graph = new MyDependencyGraph(program, new OrderVisitor(), new MyAddToGraphVisitor());
    var grounder = new Grounding(graph);
    var groundedProgram = grounder.Ground();
    var preperation = new Preparer(new Checker(), new ObjectParser()).Prepare(groundedProgram);

    List<List<int>> transformed = new SatTransformer(new Checker(), new ObjectParser()).TransformToFormular(preperation);
    var results = new DPLLSolver().FindAllSolutions(transformed);

    CollectionAssert.AreEquivalent(obj.Expected, results, "The lists of SatResults do not contain the same elements.");
  }

  public static IEnumerable<DPLLTestResults> GetTestCases()
  {
    yield return new DPLLTestResults(
        "birds.lp",
        [
            new SatResult(true, [2, -3, -1])
        ]
    );

    yield return new DPLLTestResults(
        "blocks.lp",
        [
            new SatResult(true, [-1])
        ]
    );

    yield return new DPLLTestResults(
        "books.lp",
        [
            new SatResult(true, [2, 3, 4, 5, 6, 7, -1]),
        ]
    );

    yield return new DPLLTestResults(
        "circular.lp",
        [
            new SatResult(true, [-1, -3, 2]),
            new SatResult(true, [-1, 2, -3]),
            new SatResult(true, [-1, -2, 3])
        ]
    );

    yield return new DPLLTestResults(
       "edge.lp",
       [
           new SatResult(true, [-1])
       ]
   );

    yield return new DPLLTestResults(
       "family_relations.lp",
       [
           new SatResult(true, [-1])
       ]
   );

    yield return new DPLLTestResults(
       "faster.lp",
       [
           new SatResult(true, [-1])
       ]
   );

    yield return new DPLLTestResults(
        "fastest.lp",
        [
            new SatResult(true, [-1])
        ]
    );

    yield return new DPLLTestResults(
       "happy.lp",
       [
           new SatResult(true, [-1])
       ]
   );

    yield return new DPLLTestResults(
       "nested.lp",
       [
           new SatResult(true, [-1])
       ]
   );

    yield return new DPLLTestResults(
        "unsat_1.lp",
        []
    );

    yield return new DPLLTestResults(
       "unsat_2.lp",
       []
   );

    yield return new DPLLTestResults(
        "arithop_div.lp",
        [new SatResult(true, [-1])]
    );

    yield return new DPLLTestResults(
        "schraub.lp",
        [
          new SatResult(true, [-1, -7, 2, -3, 4, -5, 6]),
          new SatResult(true, [-1, 4, 2, -3, -5, 6, -7]),
          new SatResult(true, [-1, -3, 2, 4, -5, 6, -7]),
          new SatResult(true, [-1, 2, -3, 4, -5, 6, -7]),
          new SatResult(true, [-1, -2, 3, -4, -5, 6, 7]),
        ]
    );

    yield return new DPLLTestResults(
        "teaches.lp",
        [
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, 10, -11, 15, -12, 13, 9, -8, -6, 5, 19 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, 10, -11, 15, -12, 13, -8, 9, -6, 5, 19 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, -12, 13, -11, 10, 15, 9, -8, -6, 5, 19 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, -12, 13, -11, 10, 15, -8, 9, -6, 5, 19 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, 13, -12, -11, 10, 15, -5, 6, 8, -9, 19 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, -12, 13, -11, 10, 15, -6, 5, -8, 9, 19 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, -12, 13, -11, 10, 15, 5, -6, -8, 9, 19 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, -12, 13, -11, 10, 15, -5, 6, 8, -9, 19 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, 13, -12, -11, 10, 15, 9, -8, -6, 5, 19 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, 13, -12, -11, 10, 15, -8, 9, -6, 5, 19 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, 10, -11, 15, -12, 13, -6, 5, -8, 9, 19 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, 10, -11, 15, -12, 13, 5, -6, -8, 9, 19 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, 10, -11, 15, -12, 13, -5, 6, 8, -9, 19 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, 13, -12, -11, 10, 15, -6, 5, -8, 9, 19 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, 13, -12, -11, 10, 15, 5, -6, -8, 9, 19 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, -11, 10, 15, -12, 13, -6, 5, -8, 9, 19 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, -11, 10, 15, -12, 13, 5, -6, -8, 9, 19 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, -11, 10, 15, -12, 13, -5, 6, 8, -9, 19 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, 5, -6, -8, 9, 19, 10, -11, 15, -12, 13 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, 9, -8, -6, 5, 19, 10, -11, 15, -12, 13 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, -11, 10, 15, -12, 13, 9, -8, -6, 5, 19 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, -11, 10, 15, -12, 13, -8, 9, -6, 5, 19 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, -6, 5, -8, 9, 19, 10, -11, 15, -12, 13 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, -8, 9, -6, 5, 19, 10, -11, 15, -12, 13 ]),
          new SatResult(true, [2, 3, 4, 7, 14, 16, 17, 18, 20, 21, 23, 22, -1, -5, 6, 8, -9, 19, -10, 11, 12, -13, 15 ]),
        ]
    );

    yield return new DPLLTestResults(
      "negations.lp",
      [
        new SatResult(true, [-1, 2, -3]),
            new SatResult(true, [-1, -3, 2]),
            new SatResult(true, [-1, -2, 3]),
      ]
    );
  }
}