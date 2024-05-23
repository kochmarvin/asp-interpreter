using Interpreter.Lib.Graph;
using Interpreter.Lib.Grounder;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Objects.Terms;

using Interpreter.Lib.Solver.Defaults;
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
    var graph = new MyDependencyGraph(program, new OrderVisitor(), new MyAddToGraphVisitor());
    var grounder = new Grounding(graph);
    var satEngine = new SatEngine(grounder.Ground());

    List<List<Atom>> results = satEngine.Execute();

    Assert.IsTrue(AreEqual(obj.Expected, results));
  }

  public bool AreEqual(List<List<Atom>> x, List<List<Atom>> y)
  {
    if (x == null || y == null)
      return x == y;

    if (x.Count != y.Count)
      return false;

    var sortedX = x.Select(l => l.OrderBy(a => a.ToString()).ToList()).ToList();
    var sortedY = y.Select(l => l.OrderBy(a => a.ToString()).ToList()).ToList();

    sortedX.Sort((a, b) => string.Compare(a.FirstOrDefault()?.ToString(), b.FirstOrDefault()?.ToString()));
    sortedY.Sort((a, b) => string.Compare(a.FirstOrDefault()?.ToString(), b.FirstOrDefault()?.ToString()));

    for (int i = 0; i < sortedX.Count; i++)
    {
      var listX = sortedX[i];
      var listY = sortedY[i];

      if (listX.Count != listY.Count)
        return false;

      for (int j = 0; j < listX.Count; j++)
      {
        if (!listX[j].ToString().Equals(listY[j].ToString()))
          return false;
      }
    }

    return true;
  }

  private bool AreEquivalent(List<List<Atom>> results, List<List<Atom>> expected)
  {
    var orderedResults = results.OrderBy(x => x.Count).ThenBy(x => string.Join(",", x.Select(a => a.Name)));
    var orderedExpected = expected.OrderBy(x => x.Count).ThenBy(x => string.Join(",", x.Select(a => a.Name)));

    return orderedResults.SequenceEqual(orderedExpected, new ListAtomComparer());
  }

  private class ListAtomComparer : IEqualityComparer<List<Atom>>
  {
    public bool Equals(List<Atom>? x, List<Atom>? y)
    {
      if (x == null || y == null)
      {
        return false;
      }

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

    // yield return new SatEngineResult(
    //   "choice_head.lp",
    //   [
    //     [],
    //     [new Atom("b", [])],
    //     [new Atom("c", [])],
    //     [new Atom("b", []), new Atom("c", [])],
    //     [new Atom("a", [])],
    //     [new Atom("a", []), new Atom("c", [])],
    //     [new Atom("a", []), new Atom("b", [])],
    //     [new Atom("a", []), new Atom("b", []), new Atom("c", [])],
    //     [new Atom("a", []), new Atom("x", [])],
    //     [new Atom("a", []), new Atom("b", []), new Atom("x", [])],
    //     [new Atom("a", []), new Atom("b", []), new Atom("c", []), new Atom("x", [])],
    //   ]
    // );

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
      "blocks.lp",
      [
        [new Atom("stacked", [new Variable("b")]),
        new Atom("stacked", [new Variable("a")]),
        new Atom("puton", [new Variable("d"), new Variable("d")]),
        new Atom("puton", [new Variable("d"), new Variable("a")]),
        new Atom("puton", [new Variable("a"), new Variable("d")]),
        new Atom("puton", [new Variable("a"), new Variable("a")]),
        new Atom("on", [new Variable("b"), new Variable("c")]),
        new Atom("on", [new Variable("a"), new Variable("b")]),
        new Atom("handempty", []),
        new Atom("clear", [new Variable("d")]),
        new Atom("clear", [new Variable("a")])]
      ]
    );

    // yield return new SatEngineResult(
    //   "multichoice_body.lp",
    //   [
    //     [new Atom("mensch", [new Variable("marvin")]), new Atom("mensch", [new Variable("julia")])],
    //     [new Atom("mensch", [new Variable("marvin")]), new Atom("mensch", [new Variable("julia")]), new Atom("student", [new Variable("marvin")])],
    //     [new Atom("mensch", [new Variable("marvin")]), new Atom("mensch", [new Variable("julia")]), new Atom("informatiker", [new Variable("julia")])],
    //     [new Atom("mensch", [new Variable("marvin")]), new Atom("mensch", [new Variable("julia")]), new Atom("student", [new Variable("marvin")]), new Atom("informatiker", [new Variable("julia")])],
    //     [new Atom("mensch", [new Variable("marvin")]), new Atom("mensch", [new Variable("julia")]), new Atom("student", [new Variable("julia")])],
    //     [new Atom("mensch", [new Variable("marvin")]), new Atom("mensch", [new Variable("julia")]), new Atom("informatiker", [new Variable("julia")]), new Atom("student", [new Variable("julia")])],
    //     [new Atom("mensch", [new Variable("marvin")]), new Atom("mensch", [new Variable("julia")]), new Atom("student", [new Variable("marvin")]), new Atom("student", [new Variable("julia")])],
    //     [new Atom("mensch", [new Variable("marvin")]), new Atom("mensch", [new Variable("julia")]), new Atom("student", [new Variable("marvin")]), new Atom("informatiker", [new Variable("julia")]), new Atom("student", [new Variable("julia")])],
    //     [new Atom("mensch", [new Variable("marvin")]), new Atom("mensch", [new Variable("julia")]), new Atom("informatiker", [new Variable("marvin")])],
    //     [new Atom("mensch", [new Variable("marvin")]), new Atom("mensch", [new Variable("julia")]), new Atom("informatiker", [new Variable("marvin")]), new Atom("student", [new Variable("marvin")])],
    //     [new Atom("mensch", [new Variable("marvin")]), new Atom("mensch", [new Variable("julia")]), new Atom("informatiker", [new Variable("marvin")]), new Atom("student", [new Variable("julia")])],
    //     [new Atom("mensch", [new Variable("marvin")]), new Atom("mensch", [new Variable("julia")]), new Atom("informatiker", [new Variable("marvin")]), new Atom("student", [new Variable("marvin")]), new Atom("student", [new Variable("julia")])],
    //     [new Atom("mensch", [new Variable("marvin")]), new Atom("mensch", [new Variable("julia")]), new Atom("informatiker", [new Variable("marvin")]), new Atom("informatiker", [new Variable("julia")])],
    //     [new Atom("mensch", [new Variable("marvin")]), new Atom("mensch", [new Variable("julia")]), new Atom("informatiker", [new Variable("marvin")]), new Atom("informatiker", [new Variable("julia")]), new Atom("student", [new Variable("julia")])],
    //     [new Atom("mensch", [new Variable("marvin")]), new Atom("mensch", [new Variable("julia")]), new Atom("informatiker", [new Variable("marvin")]), new Atom("student", [new Variable("marvin")]), new Atom("informatiker", [new Variable("julia")])],
    //     [new Atom("mensch", [new Variable("marvin")]), new Atom("mensch", [new Variable("julia")]), new Atom("informatiker", [new Variable("marvin")]), new Atom("student", [new Variable("marvin")]), new Atom("informatiker", [new Variable("julia")]), new Atom("student", [new Variable("julia")])]
    //   ]
    // );

    // da fickt die reihenfolge der AS wieder, ab und zu kommts durch 
    /*
    yield return new SatEngineResult(
      "teaches.lp",
      [
        [
        new Atom("teaches", [new Variable("tom"), new Variable("logic")]),
        new Atom("teaches", [new Variable("sam"), new Variable("java")]),
        new Atom("teaches", [new Variable("sam"), new Variable("c")]),
        new Atom("teaches", [new Variable("bob"), new Variable("ai")]),
        new Atom("some_course", [new Variable("tom")]),
        new Atom("some_course", [new Variable("sam")]),
        new Atom("some_course", [new Variable("bob")]),
        new Atom("member", [new Variable("tom"), new Variable("cs")]),
        new Atom("member", [new Variable("sam"), new Variable("cs")]),
        new Atom("member", [new Variable("bob"), new Variable("cs")]),
        new Atom("likes", [new Variable("tom"), new Variable("logic")]),
        new Atom("likes", [new Variable("tom"), new Variable("ai")]),
        new Atom("likes", [new Variable("sam"), new Variable("java")]), 
        new Atom("likes", [new Variable("sam"), new Variable("c")]), 
        new Atom("likes", [new Variable("bob"), new Variable("java")]),
        new Atom("likes", [new Variable("bob"), new Variable("ai")]),
        new Atom("course", [new Variable("logic"), new Variable("cs")]),
        new Atom("course", [new Variable("java"), new Variable("cs")]),
        new Atom("course", [new Variable("c"), new Variable("cs")]),
        new Atom("course", [new Variable("ai"), new Variable("cs")]),
        new Atom("-teaches", [new Variable("tom"), new Variable("java")]),
        new Atom("-teaches", [new Variable("tom"), new Variable("c")]),
        new Atom("-teaches", [new Variable("tom"), new Variable("ai")]),
        new Atom("-teaches", [new Variable("sam"), new Variable("logic")]),
        new Atom("-teaches", [new Variable("sam"), new Variable("ai")]),
        new Atom("-teaches", [new Variable("bob"), new Variable("logic")]),
        new Atom("-teaches", [new Variable("bob"), new Variable("java")]),
        new Atom("-teaches", [new Variable("bob"), new Variable("c")]),
        ],
        [
        new Atom("teaches", [new Variable("tom"), new Variable("logic")]),
        new Atom("teaches", [new Variable("tom"), new Variable("ai")]),
        new Atom("teaches", [new Variable("sam"), new Variable("c")]),
        new Atom("teaches", [new Variable("bob"), new Variable("java")]),
        new Atom("some_course", [new Variable("tom")]),
        new Atom("some_course", [new Variable("sam")]),
        new Atom("some_course", [new Variable("bob")]),
        new Atom("member", [new Variable("tom"), new Variable("cs")]),
        new Atom("member", [new Variable("sam"), new Variable("cs")]),
        new Atom("member", [new Variable("bob"), new Variable("cs")]),
        new Atom("likes", [new Variable("tom"), new Variable("logic")]),
        new Atom("likes", [new Variable("tom"), new Variable("ai")]),
        new Atom("likes", [new Variable("sam"), new Variable("java")]), 
        new Atom("likes", [new Variable("sam"), new Variable("c")]), 
        new Atom("likes", [new Variable("bob"), new Variable("java")]),
        new Atom("likes", [new Variable("bob"), new Variable("ai")]),
        new Atom("course", [new Variable("logic"), new Variable("cs")]),
        new Atom("course", [new Variable("java"), new Variable("cs")]),
        new Atom("course", [new Variable("c"), new Variable("cs")]),
        new Atom("course", [new Variable("ai"), new Variable("cs")]),
        new Atom("-teaches", [new Variable("tom"), new Variable("java")]),
        new Atom("-teaches", [new Variable("tom"), new Variable("c")]),
        new Atom("-teaches", [new Variable("sam"), new Variable("logic")]),
        new Atom("-teaches", [new Variable("sam"), new Variable("java")]),
        new Atom("-teaches", [new Variable("sam"), new Variable("ai")]),
        new Atom("-teaches", [new Variable("bob"), new Variable("logic")]),
        new Atom("-teaches", [new Variable("bob"), new Variable("c")]),
        new Atom("-teaches", [new Variable("bob"), new Variable("ai")]),
        ],
        [
        new Atom("teaches", [new Variable("tom"), new Variable("logic")]),
        new Atom("teaches", [new Variable("sam"), new Variable("c")]),
        new Atom("teaches", [new Variable("bob"), new Variable("java")]),
        new Atom("teaches", [new Variable("bob"), new Variable("ai")]),
        new Atom("some_course", [new Variable("tom")]),
        new Atom("some_course", [new Variable("sam")]),
        new Atom("some_course", [new Variable("bob")]),
        new Atom("member", [new Variable("tom"), new Variable("cs")]),
        new Atom("member", [new Variable("sam"), new Variable("cs")]),
        new Atom("member", [new Variable("bob"), new Variable("cs")]),
        new Atom("likes", [new Variable("tom"), new Variable("logic")]),
        new Atom("likes", [new Variable("tom"), new Variable("ai")]),
        new Atom("likes", [new Variable("sam"), new Variable("java")]), 
        new Atom("likes", [new Variable("sam"), new Variable("c")]), 
        new Atom("likes", [new Variable("bob"), new Variable("java")]),
        new Atom("likes", [new Variable("bob"), new Variable("ai")]),
        new Atom("course", [new Variable("logic"), new Variable("cs")]),
        new Atom("course", [new Variable("java"), new Variable("cs")]),
        new Atom("course", [new Variable("c"), new Variable("cs")]),
        new Atom("course", [new Variable("ai"), new Variable("cs")]),
        new Atom("-teaches", [new Variable("tom"), new Variable("java")]),
        new Atom("-teaches", [new Variable("tom"), new Variable("c")]),
        new Atom("-teaches", [new Variable("tom"), new Variable("ai")]),
        new Atom("-teaches", [new Variable("sam"), new Variable("logic")]),
        new Atom("-teaches", [new Variable("sam"), new Variable("java")]),
        new Atom("-teaches", [new Variable("sam"), new Variable("ai")]),
        new Atom("-teaches", [new Variable("bob"), new Variable("logic")]),
        new Atom("-teaches", [new Variable("bob"), new Variable("c")]),
        ]
      ]
    );
    */

    yield return new SatEngineResult(
      "edge.lp",
      [
        [
          new Atom("edge", [new Variable("c"), new Variable("d")]),
          new Atom("edge", [new Variable("b"), new Variable("d")]),
          new Atom("edge", [new Variable("b"), new Variable("c")]),
          new Atom("edge", [new Variable("a"), new Variable("c")]),
          new Atom("edge", [new Variable("a"), new Variable("b")]),
          new Atom("color", [new Variable("red")]),
          new Atom("color", [new Variable("green")]),
          new Atom("color", [new Variable("blue")]),
        ]
      ]
    );

    yield return new SatEngineResult(
      "family_relations.lp",
      [
        [
          new Atom("parent", [new Variable("charlie"), new Variable("emma")]),
          new Atom("parent", [new Variable("bob"), new Variable("charlie")]),
          new Atom("parent", [new Variable("bob"), new Variable("alice")]),
          new Atom("parent", [new Variable("alice"), new Variable("david")]),
          new Atom("ancestor", [new Variable("charlie"), new Variable("emma")]),
          new Atom("ancestor", [new Variable("bob"), new Variable("emma")]),
          new Atom("ancestor", [new Variable("bob"), new Variable("david")]),
          new Atom("ancestor", [new Variable("bob"), new Variable("charlie")]),
          new Atom("ancestor", [new Variable("bob"), new Variable("alice")]),
          new Atom("ancestor", [new Variable("alice"), new Variable("david")]),
        ]
      ]
    );

    yield return new SatEngineResult(
      "negations.lp",
      [
        [new Atom("p", [])],
        [new Atom("q", [])]
      ]
    );

    yield return new SatEngineResult(
      "assign.lp",
      [
        [new Atom("sum", [new Number(1), new Number(2), new Number(3)])]
      ]
    );

    yield return new SatEngineResult(
      "happy.lp",
      [
        [
          new Atom("unhappy", [new Variable("bob")]),
          new Atom("sad", [new Variable("alice")]),
          new Atom("reasontobeunhappy", [new Variable("bob")]),
          new Atom("reasontobehappy", [new Variable("alice")]),
          new Atom("happy", [new Variable("alice")])
        ]
      ]
    );

    yield return new SatEngineResult(
      "arithop_times.lp",
      [
        [new Atom("sum", [new Number(5)]), new Atom("result", [new Number(100)]), new Atom("product", [new Number(20)])]
      ]
    );

    yield return new SatEngineResult(
      "arithop_div.lp",
      [
        [new Atom("two", [new Number(4)]), new Atom("result", [new Number(5)]), new Atom("one", [new Number(20)])]
      ]
    );

    yield return new SatEngineResult(
      "arithop_minus.lp",
      [
        [new Atom("result", [new Number(16)]), new Atom("number_two", [new Number(4)]), new Atom("number_one", [new Number(20)])]
      ]
    );

    yield return new SatEngineResult(
      "arithop_plus.lp",
      [
        [new Atom("result", [new Number(24)]), new Atom("num_two", [new Number(4)]), new Atom("num_one", [new Number(20)])]
      ]
    );

    yield return new SatEngineResult(
     "unsat_1.lp",
     []
   );

  }
}