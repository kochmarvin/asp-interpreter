using Interpreter.Lib.Graph;
using Interpreter.Lib.Grounder;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Solver.defaults;
using Interpreter.Tests;
using Interpreter.Tests.Parser;

namespace Tests.Tree;

[TestFixture]
public class SatEngineTests
{
  [TestCaseSource(nameof(GetTestCases))]
  public void SatEngine(SatEngineResult obj)
  {

    List<ProgramRule> program = Utils.ParseProgram(obj.File);
    var graph = new DependencyGraph(program);
    var grounder = new Grounding(graph);
    var satEngine = new SatEngine(grounder.Ground());

    List<List<Atom>> results = satEngine.Execute();

    List<List<Atom>> excpeted = [[], [new Atom("marvin", [])]];

    Assert.IsTrue(AreEquivalent(results, obj.Expected), "Results and expected lists are not equivalent.");
  }

  private bool AreEquivalent(List<List<Atom>> results, List<List<Atom>> expected)
  {
    var orderedResults = results.OrderBy(x => x.Count).ThenBy(x => string.Join(",", x.Select(a => a.Name)));
    var orderedExpected = expected.OrderBy(x => x.Count).ThenBy(x => string.Join(",", x.Select(a => a.Name)));

    return orderedResults.SequenceEqual(orderedExpected, new ListAtomComparer());
  }

  private class ListAtomComparer : IEqualityComparer<List<Atom>>
  {
    public bool Equals(List<Atom> x, List<Atom> y)
    {
      return x.OrderBy(a => a.Name).SequenceEqual(y.OrderBy(a => a.Name));
    }

    public int GetHashCode(List<Atom> obj)
    {
      return obj.Aggregate(0, (acc, atom) => acc ^ atom.GetHashCode());
    }
  }

  public static IEnumerable<SatEngineResult> GetTestCases()
  {
    yield return new SatEngineResult(
      "schraub.lp",
      [
        [new Atom("d", [])],
        [new Atom("a", []), new Atom("b", [])]
      ]
    );

    yield return new SatEngineResult(
     "unsat_1.lp",
     []
   );
  }
}