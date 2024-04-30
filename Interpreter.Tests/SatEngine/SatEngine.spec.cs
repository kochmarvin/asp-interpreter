using Interpreter.Lib.Graph;
using Interpreter.Lib.Grounder;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Objects.Terms;
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
      "range_positive.lp",
      [
        [new Atom("a", [new Number(3)]), new Atom("a", [new Number(2)]), new Atom("a", [new Number(1)])]
      ]
    );

    yield return new SatEngineResult(
      "range_negative.lp",
      [
        [new Atom("mensch", [new Number(2)]),
        new Atom("mensch", [new Number(1)]),
        new Atom("mensch", [new Number(0)]),
        new Atom("mensch", [new Number(-2)]),
        new Atom("mensch", [new Number(-1)])]
      ]
    );

    yield return new SatEngineResult(
     "birds.lp",
     [
       [new Atom("penguin", [new Variable("tux")]),
        new Atom("fly", [new Variable("eddy")]),
        new Atom("eagle", [new Variable("eddy")]),
        new Atom("bird", [new Variable("tux")]),
        new Atom("bird", [new Variable("eddy")]),
        new Atom("-fly", [new Variable("tux")])]
     ]
   );

    /*
    reihenfolge fickt hier
    yield return new SatEngineResult(
      "choice_head.lp",
      [
        [],
        [new Atom("x", []), new Atom("a", [])],
        [new Atom("x", []), new Atom("c", []), new Atom("a", [])],
        [new Atom("a", [])],
        [new Atom("b", []), new Atom("a", [])],
        [new Atom("x", []), new Atom("b", []), new Atom("a", [])],
        [new Atom("c", []), new Atom("b", []), new Atom("a", [])],
        [new Atom("c", []), new Atom("a", [])],
        [new Atom("x", []), new Atom("c", []), new Atom("b", []), new Atom("a", [])],
        [new Atom("c", []), new Atom("b", [])],
      ]
    );
    */

    // hier kann reihenfolge auch ficken 
    yield return new SatEngineResult(
      "circular.lp",
      [
        [new Atom("single", [new Variable("marvin")]), new Atom("mensch", [new Variable("marvin")])],
        [new Atom("mensch", [new Variable("marvin")]), new Atom("married", [new Variable("marvin")])]
      ]
    );

    yield return new SatEngineResult(
      "comparisson.lp",
     [
       [new Atom("node", [new Number(6)]),
       new Atom("node", [new Number(5)]),
       new Atom("node", [new Number(4)]),
       new Atom("node", [new Number(3)]),
       new Atom("node", [new Number(2)]),
       new Atom("node", [new Number(1)]),
       new Atom("knoten", [new Number(6)]),
       new Atom("knoten", [new Number(5)]),
       new Atom("knoten", [new Number(4)]),
       new Atom("knoten", [new Number(3)]),
       new Atom("knoten", [new Number(2)]),
       new Atom("knoten", [new Number(1)])]
     ]
    );

    yield return new SatEngineResult(
      "faster.lp",
      [
        [new Atom("isFaster", [new Variable("werner"), new Variable("niko")]),
        new Atom("isFaster", [new Variable("werner"), new Variable("michi")]),
        new Atom("isFaster", [new Variable("niko"), new Variable("michi")]),
        new Atom("isFaster", [new Variable("marvin"), new Variable("werner")]),
        new Atom("isFaster", [new Variable("marvin"), new Variable("niko")]),
        new Atom("isFaster", [new Variable("marvin"), new Variable("michi")]),
        new Atom("faster", [new Variable("werner"), new Variable("niko")]),
        new Atom("faster", [new Variable("niko"), new Variable("michi")]),
        new Atom("faster", [new Variable("marvin"), new Variable("werner")])
        ]
      ]
    );

    // clingo wirft hier error wegen Y --> _
    yield return new SatEngineResult(
      "fastest.lp",
      [
        [new Atom("vehicle", [new Variable("skateboard")]),
        new Atom("vehicle", [new Variable("bike")]),
        new Atom("is_faster", [new Variable("bike"), new Variable("skateboard")]),
        new Atom("fastest", [new Variable("bike")]),
        new Atom("faster", [new Variable("bike"), new Variable("skateboard")])
        ]
      ]
    );

    yield return new SatEngineResult(
      "no_vars.lp",
      [
        [new Atom("b", [])],
        [new Atom("x", []), new Atom("a", [])],
      ]
    );

    yield return new SatEngineResult(
     "unsat_1.lp",
     []
   );

  }
}