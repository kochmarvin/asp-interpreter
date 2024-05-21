using Interpreter.Lib.Graph;
using Interpreter.Lib.Grounder;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Objects.Terms;

using Interpreter.Lib.Solver;
using Interpreter.Lib.Solver.defaults;
using Interpreter.Tests;
using Interpreter.Tests.Parser;

namespace Tests.Solver;

[TestFixture]
public class PreparerTests
{
  [TestCaseSource(nameof(GetTestCases))]
  public void Prepare(PrepareResults obj)
  {
    List<ProgramRule> program = Utils.ParseProgram(obj.File);
    var graph = new MyDependencyGraph(program, new OrderVisitor(), new MyAddToGraphVisitor());
    var grounder = new Grounding(graph);
    var groundedProgram = grounder.Ground();
    var results = new Preparer(new Checker(), new ObjectParser()).Prepare(groundedProgram);

    Assert.IsTrue(AreEqual(obj.Expected, results));
  }

  public bool AreEqual(Preperation x, Preperation y)
  {
    if (x == null || y == null)
      return x == y;

    bool factuallyTrueEqual = x.FactuallyTrue.Count == y.FactuallyTrue.Count && !x.FactuallyTrue.Except(y.FactuallyTrue).Any();
    bool remainderEqual = x.Remainder.Count == y.Remainder.Count && !x.Remainder.Except(y.Remainder).Any();
    return factuallyTrueEqual && remainderEqual;
  }

  public static IEnumerable<PrepareResults> GetTestCases()
  {
    yield return new PrepareResults(
        "birds.lp",
        new Preperation(
            [
                new ProgramRule(new AtomHead(new Atom("eagle", [new Variable("eddy")])), []),
                    new ProgramRule(new AtomHead(new Atom("penguin", [new Variable("tux")])), []),
                    new ProgramRule(new AtomHead(new Atom("bird", [new Variable("tux")])), []),
                    new ProgramRule(new AtomHead(new Atom("bird", [new Variable("eddy")])), []),
                    new ProgramRule(new AtomHead(new Atom("fly", [new Variable("eddy")])), [])
            ],
            [
                new ProgramRule(new AtomHead(new Atom("-fly", [new Variable("tux")])), []),
                    new ProgramRule(new AtomHead(new Atom("fly", [new Variable("tux")])),
                    [
                        new LiteralBody(new AtomLiteral(false, new Atom("-fly", [new Variable("tux")])))
                    ]),
                    new ProgramRule(new Headless(),
                    [
                        new LiteralBody(new AtomLiteral(true, new Atom("-fly", [new Variable("tux")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("fly", [new Variable("tux")])))
                    ]),
            ],
            []
        )
    );

    yield return new PrepareResults(
        "blocks.lp",
        new Preperation(
            [
                new ProgramRule(new AtomHead(new Atom("on", [new Variable("a"), new Variable("b")])), []),
                    new ProgramRule(new AtomHead(new Atom("on", [new Variable("b"), new Variable("c")])), []),
                    new ProgramRule(new AtomHead(new Atom("clear", [new Variable("a")])), []),
                    new ProgramRule(new AtomHead(new Atom("clear", [new Variable("d")])), []),
                    new ProgramRule(new AtomHead(new Atom("handempty", [])), []),
                    new ProgramRule(new AtomHead(new Atom("puton", [new Variable("a"), new Variable("a")])), []),
                    new ProgramRule(new AtomHead(new Atom("puton", [new Variable("a"), new Variable("d")])), []),
                    new ProgramRule(new AtomHead(new Atom("puton", [new Variable("d"), new Variable("a")])), []),
                    new ProgramRule(new AtomHead(new Atom("puton", [new Variable("d"), new Variable("d")])), []),
                    new ProgramRule(new AtomHead(new Atom("stacked", [new Variable("a")])), []),
                    new ProgramRule(new AtomHead(new Atom("stacked", [new Variable("b")])), [])
            ],
            [],
            []
        )
    );

    yield return new PrepareResults(
        "circular.lp",
        new Preperation(
            [
                new ProgramRule(new AtomHead(new Atom("mensch", [new Variable("marvin")])), [])
            ],
            [
                new ProgramRule(new AtomHead(new Atom("single", [new Variable("marvin")])),
                    [
                        new LiteralBody(new AtomLiteral(false, new Atom("married", [new Variable("marvin")])))
                    ]),
                    new ProgramRule(new AtomHead(new Atom("married", [new Variable("marvin")])),
                    [
                        new LiteralBody(new AtomLiteral(false, new Atom("single", [new Variable("marvin")])))
                    ]),
            ],
            []
        )
    );

    yield return new PrepareResults(
       "comparison.lp",
       new Preperation(
           [
                new ProgramRule(new AtomHead(new Atom("test", [new Variable("X"), new Variable("Y")])), []),
                    new ProgramRule(new AtomHead(new Atom("test", [new Variable("X"), new Variable("Y")])), []),
                    new ProgramRule(new AtomHead(new Atom("test", [new Variable("X"), new Variable("Y")])), []),
                    new ProgramRule(new AtomHead(new Atom("test", [new Variable("X"), new Variable("Y")])), [])
           ],
           [],
           []
       )
   );

    yield return new PrepareResults(
        "comparisson.lp",
        new Preperation(
            [
               new ProgramRule(new AtomHead(new Atom("node", [new Number(1)])), []),
                  new ProgramRule(new AtomHead(new Atom("node", [new Number(2)])), []),
                  new ProgramRule(new AtomHead(new Atom("node", [new Number(3)])), []),
                  new ProgramRule(new AtomHead(new Atom("node", [new Number(4)])), []),
                  new ProgramRule(new AtomHead(new Atom("node", [new Number(5)])), []),
                  new ProgramRule(new AtomHead(new Atom("node", [new Number(6)])), []),
                  new ProgramRule(new AtomHead(new Atom("knoten", [new Number(4)])), []),
                  new ProgramRule(new AtomHead(new Atom("knoten", [new Number(5)])), []),
                  new ProgramRule(new AtomHead(new Atom("knoten", [new Number(6)])), []),
                  new ProgramRule(new AtomHead(new Atom("knoten", [new Number(3)])), []),
                  new ProgramRule(new AtomHead(new Atom("knoten", [new Number(4)])), []),
                  new ProgramRule(new AtomHead(new Atom("knoten", [new Number(5)])), []),
                  new ProgramRule(new AtomHead(new Atom("knoten", [new Number(6)])), []),
                  new ProgramRule(new AtomHead(new Atom("knoten", [new Number(1)])), []),
                  new ProgramRule(new AtomHead(new Atom("knoten", [new Number(2)])), []),
                  new ProgramRule(new AtomHead(new Atom("knoten", [new Number(3)])), []),
                  new ProgramRule(new AtomHead(new Atom("knoten", [new Number(1)])), []),
                  new ProgramRule(new AtomHead(new Atom("knoten", [new Number(2)])), []),
                  new ProgramRule(new AtomHead(new Atom("knoten", [new Number(3)])), []),
                  new ProgramRule(new AtomHead(new Atom("knoten", [new Number(1)])), []),
                  new ProgramRule(new AtomHead(new Atom("knoten", [new Number(2)])), []),
                  new ProgramRule(new AtomHead(new Atom("knoten", [new Number(4)])), []),
                  new ProgramRule(new AtomHead(new Atom("knoten", [new Number(5)])), []),
                  new ProgramRule(new AtomHead(new Atom("knoten", [new Number(6)])), []),
            ],
            [],
            []
        )
    );

    yield return new PrepareResults(
         "edge_2.lp",
         new Preperation(
             [
                 new ProgramRule(new AtomHead(new Atom("node", [new Variable("a")])), []),
                    new ProgramRule(new AtomHead(new Atom("node", [new Variable("b")])), [])
             ],
             [
                 new ProgramRule(new AtomHead(new Atom("edge", [new Variable("a"), new Variable("b")])), []),
                    new ProgramRule(new AtomHead(new Atom("color", [new Variable("red")])), []),
                    new ProgramRule(new AtomHead(new Atom("color", [new Variable("blue")])), []),
                    new ProgramRule(new Headless(),
                    [
                        new LiteralBody(new AtomLiteral(true, new Atom("edge", [new Variable("a"), new Variable("b")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("color", [new Variable("red")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("color", [new Variable("red")]))),
                        new LiteralBody(new AtomLiteral(false, new Atom("colored", [new Variable("a"), new Variable("red")]))),
                        new LiteralBody(new AtomLiteral(false, new Atom("colored", [new Variable("b"), new Variable("red")])))
                    ]),
                    new ProgramRule(new Headless(),
                    [
                        new LiteralBody(new AtomLiteral(true, new Atom("edge", [new Variable("a"), new Variable("b")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("color", [new Variable("blue")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("color", [new Variable("blue")]))),
                        new LiteralBody(new AtomLiteral(false, new Atom("colored", [new Variable("a"), new Variable("blue")]))),
                        new LiteralBody(new AtomLiteral(false, new Atom("colored", [new Variable("b"), new Variable("blue")])))
                    ]),
             ],
             []
         )
     );

    yield return new PrepareResults(
        "edge.lp",
        new Preperation(
            [
                new ProgramRule(new AtomHead(new Atom("edge", [new Variable("a"), new Variable("b")])), []),
                    new ProgramRule(new AtomHead(new Atom("edge", [new Variable("a"), new Variable("c")])), []),
                    new ProgramRule(new AtomHead(new Atom("edge", [new Variable("b"), new Variable("c")])), []),
                    new ProgramRule(new AtomHead(new Atom("edge", [new Variable("b"), new Variable("d")])), []),
                    new ProgramRule(new AtomHead(new Atom("edge", [new Variable("c"), new Variable("d")])), []),
                    new ProgramRule(new AtomHead(new Atom("color", [new Variable("red")])), []),
                    new ProgramRule(new AtomHead(new Atom("color", [new Variable("blue")])), []),
                    new ProgramRule(new AtomHead(new Atom("color", [new Variable("green")])), []),
            ],
            [],
            []
        )
    );

    yield return new PrepareResults(
        "family_relations.lp",
        new Preperation(
            [
                new ProgramRule(new AtomHead(new Atom("parent", [new Variable("bob"), new Variable("alice")])), []),
                    new ProgramRule(new AtomHead(new Atom("parent", [new Variable("bob"), new Variable("charlie")])), []),
                    new ProgramRule(new AtomHead(new Atom("parent", [new Variable("alice"), new Variable("david")])), []),
                    new ProgramRule(new AtomHead(new Atom("parent", [new Variable("charlie"), new Variable("emma")])), []),
                    new ProgramRule(new AtomHead(new Atom("ancestor", [new Variable("bob"), new Variable("alice")])), []),
                    new ProgramRule(new AtomHead(new Atom("ancestor", [new Variable("bob"), new Variable("charlie")])), []),
                    new ProgramRule(new AtomHead(new Atom("ancestor", [new Variable("alice"), new Variable("david")])), []),
                    new ProgramRule(new AtomHead(new Atom("ancestor", [new Variable("charlie"), new Variable("emma")])), []),
                    new ProgramRule(new AtomHead(new Atom("ancestor", [new Variable("bob"), new Variable("david")])), []),
                    new ProgramRule(new AtomHead(new Atom("ancestor", [new Variable("bob"), new Variable("emma")])), [])
            ],
            [],
            []
        )
    );

    yield return new PrepareResults(
        "faster.lp",
        new Preperation(
            [
                new ProgramRule(new AtomHead(new Atom("faster", [new Variable("marvin"), new Variable("werner")])), []),
                    new ProgramRule(new AtomHead(new Atom("faster", [new Variable("werner"), new Variable("niko")])), []),
                    new ProgramRule(new AtomHead(new Atom("faster", [new Variable("niko"), new Variable("michi")])), []),
                    new ProgramRule(new AtomHead(new Atom("isFaster", [new Variable("marvin"), new Variable("werner")])), []),
                    new ProgramRule(new AtomHead(new Atom("isFaster", [new Variable("werner"), new Variable("niko")])), []),
                    new ProgramRule(new AtomHead(new Atom("isFaster", [new Variable("niko"), new Variable("michi")])), []),
                    new ProgramRule(new AtomHead(new Atom("isFaster", [new Variable("marvin"), new Variable("niko")])), []),
                    new ProgramRule(new AtomHead(new Atom("isFaster", [new Variable("werner"), new Variable("michi")])), []),
                    new ProgramRule(new AtomHead(new Atom("isFaster", [new Variable("marvin"), new Variable("michi")])), []),
            ],
            [],
            []
        )
    );

    yield return new PrepareResults(
        "fastest.lp",
        new Preperation(
            [
                new ProgramRule(new AtomHead(new Atom("vehicle", [new Variable("bike")])), []),
                    new ProgramRule(new AtomHead(new Atom("vehicle", [new Variable("skateboard")])), []),
                    new ProgramRule(new AtomHead(new Atom("faster", [new Variable("bike"), new Variable("skateboard")])), []),
                    new ProgramRule(new AtomHead(new Atom("is_faster", [new Variable("bike"), new Variable("skateboard")])), []),
                    new ProgramRule(new AtomHead(new Atom("fastest", [new Variable("bike")])), [])
            ],
            [],
            []
        )
    );

    yield return new PrepareResults(
        "happy.lp",
        new Preperation(
            [
                new ProgramRule(new AtomHead(new Atom("reasontobehappy", [new Variable("alice")])), []),
                    new ProgramRule(new AtomHead(new Atom("reasontobeunhappy", [new Variable("bob")])), []),
                    new ProgramRule(new AtomHead(new Atom("happy", [new Variable("alice")])), []),
                    new ProgramRule(new AtomHead(new Atom("unhappy", [new Variable("bob")])), []),
                    new ProgramRule(new AtomHead(new Atom("sad", [new Variable("alice")])), []),
            ],
            [],
            []
        )
    );

    yield return new PrepareResults(
       "negations.lp",
       new Preperation(
           [],
           [
                new ProgramRule(new AtomHead(new Atom("p", [])), [new LiteralBody(new AtomLiteral(false, new Atom("q", [])))]),
                    new ProgramRule(new AtomHead(new Atom("q", [])), [new LiteralBody(new AtomLiteral(false, new Atom("p", [])))]),
           ],
           []
       )
   );

    yield return new PrepareResults(
       "schraub.lp",
       new Preperation(
           [],
           [
                new ProgramRule(new ChoiceHead([new Atom("a", [])]), []),
                    new ProgramRule(new AtomHead(new Atom("b", [])), [new LiteralBody(new AtomLiteral(true, new Atom("a", [])))]),
                    new ProgramRule(new ChoiceHead([new Atom("c", [])]), [new LiteralBody(new AtomLiteral(false, new Atom("a", [])))]),
                    new ProgramRule(new AtomHead(new Atom("d", [])), [new LiteralBody(new AtomLiteral(false, new Atom("b", []))), new LiteralBody(new AtomLiteral(false, new Atom("c", [])))]),
                    new ProgramRule(new Headless(), [new LiteralBody(new AtomLiteral(true, new Atom("c", []))), new LiteralBody(new AtomLiteral(false, new Atom("a", [])))])
           ],
           []
       )
   );

    yield return new PrepareResults(
       "teaches.lp",
       new Preperation(
           [
                new ProgramRule(new AtomHead(new Atom("course", [new Variable("java"), new Variable("cs")])), []),
                    new ProgramRule(new AtomHead(new Atom("course", [new Variable("ai"), new Variable("cs")])), []),
                    new ProgramRule(new AtomHead(new Atom("course", [new Variable("c"), new Variable("cs")])), []),
                    new ProgramRule(new AtomHead(new Atom("course", [new Variable("logic"), new Variable("cs")])), []),
                    new ProgramRule(new AtomHead(new Atom("likes", [new Variable("sam"), new Variable("java")])), []),
                    new ProgramRule(new AtomHead(new Atom("likes", [new Variable("sam"), new Variable("c")])), []),
                    new ProgramRule(new AtomHead(new Atom("likes", [new Variable("bob"), new Variable("java")])), []),
                    new ProgramRule(new AtomHead(new Atom("likes", [new Variable("bob"), new Variable("ai")])), []),
                    new ProgramRule(new AtomHead(new Atom("likes", [new Variable("tom"), new Variable("ai")])), []),
                    new ProgramRule(new AtomHead(new Atom("likes", [new Variable("tom"), new Variable("logic")])), []),
           ],
           [
                new ProgramRule(new AtomHead(new Atom("member", [new Variable("sam"), new Variable("cs")])), []),
                    new ProgramRule(new AtomHead(new Atom("member", [new Variable("bob"), new Variable("cs")])), []),
                    new ProgramRule(new AtomHead(new Atom("member", [new Variable("tom"), new Variable("cs")])), []),
                    new ProgramRule(new AtomHead(new Atom("teaches", [new Variable("sam"), new Variable("java")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("sam"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(false, new Atom("-teaches", [new Variable("sam"), new Variable("java")])))
                    ]),
                    new ProgramRule(new AtomHead(new Atom("teaches", [new Variable("sam"), new Variable("c")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("sam"), new Variable("cs")]))),
                    ]),
                    new ProgramRule(new AtomHead(new Atom("teaches", [new Variable("bob"), new Variable("java")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("bob"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(false, new Atom("-teaches", [new Variable("bob"), new Variable("java")])))
                    ]),
                     new ProgramRule(new AtomHead(new Atom("teaches", [new Variable("bob"), new Variable("ai")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("bob"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(false, new Atom("-teaches", [new Variable("bob"), new Variable("ai")])))
                    ]),
                     new ProgramRule(new AtomHead(new Atom("teaches", [new Variable("tom"), new Variable("ai")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("tom"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(false, new Atom("-teaches", [new Variable("tom"), new Variable("ai")])))
                    ]),
                     new ProgramRule(new AtomHead(new Atom("teaches", [new Variable("tom"), new Variable("logic")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("tom"), new Variable("cs")])))
                    ]),
                    new ProgramRule(new AtomHead(new Atom("-teaches", [new Variable("sam"), new Variable("java")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("sam"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("bob"), new Variable("java")])))
                    ]),
                    new ProgramRule(new AtomHead(new Atom("-teaches", [new Variable("sam"), new Variable("ai")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("sam"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("bob"), new Variable("ai")])))
                    ]),
                    new ProgramRule(new AtomHead(new Atom("-teaches", [new Variable("sam"), new Variable("ai")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("sam"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("tom"), new Variable("ai")])))
                    ]),
                    new ProgramRule(new AtomHead(new Atom("-teaches", [new Variable("sam"), new Variable("logic")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("sam"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("tom"), new Variable("logic")])))
                    ]),
                    new ProgramRule(new AtomHead(new Atom("-teaches", [new Variable("bob"), new Variable("java")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("bob"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("sam"), new Variable("java")])))
                    ]),
                    new ProgramRule(new AtomHead(new Atom("-teaches", [new Variable("bob"), new Variable("ai")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("bob"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("tom"), new Variable("ai")])))
                    ]),
                    new ProgramRule(new AtomHead(new Atom("-teaches", [new Variable("bob"), new Variable("c")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("bob"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("sam"), new Variable("c")])))
                    ]),
                    new ProgramRule(new AtomHead(new Atom("-teaches", [new Variable("bob"), new Variable("logic")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("bob"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("tom"), new Variable("logic")])))
                    ]),
                    new ProgramRule(new AtomHead(new Atom("-teaches", [new Variable("tom"), new Variable("java")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("tom"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("sam"), new Variable("java")])))
                    ]),
                    new ProgramRule(new AtomHead(new Atom("-teaches", [new Variable("tom"), new Variable("java")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("tom"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("bob"), new Variable("java")])))
                    ]),
                    new ProgramRule(new AtomHead(new Atom("-teaches", [new Variable("tom"), new Variable("ai")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("tom"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("bob"), new Variable("ai")])))
                    ]),
                    new ProgramRule(new AtomHead(new Atom("-teaches", [new Variable("tom"), new Variable("c")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("tom"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("sam"), new Variable("c")])))
                    ]),
                    new ProgramRule(new AtomHead(new Atom("some_course", [new Variable("sam")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("sam"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("sam"), new Variable("java")])))
                    ]),
                    new ProgramRule(new AtomHead(new Atom("some_course", [new Variable("sam")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("sam"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("sam"), new Variable("c")])))
                    ]),
                    new ProgramRule(new AtomHead(new Atom("some_course", [new Variable("bob")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("bob"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("bob"), new Variable("java")])))
                    ]),
                    new ProgramRule(new AtomHead(new Atom("some_course", [new Variable("bob")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("bob"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("bob"), new Variable("ai")])))
                    ]),
                    new ProgramRule(new AtomHead(new Atom("some_course", [new Variable("tom")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("tom"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("tom"), new Variable("ai")])))
                    ]),
                    new ProgramRule(new AtomHead(new Atom("some_course", [new Variable("tom")])), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("tom"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("tom"), new Variable("logic")])))
                    ]),
                    new ProgramRule(new Headless(), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("sam"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(false, new Atom("some_course", [new Variable("sam")])))
                    ]),
                    new ProgramRule(new Headless(), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("bob"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(false, new Atom("some_course", [new Variable("bob")])))
                    ]),
                    new ProgramRule(new Headless(), [
                        new LiteralBody(new AtomLiteral(true, new Atom("member", [new Variable("tom"), new Variable("cs")]))),
                        new LiteralBody(new AtomLiteral(false, new Atom("some_course", [new Variable("tom")])))
                    ]),
                    new ProgramRule(new Headless(), [
                        new LiteralBody(new AtomLiteral(true, new Atom("-teaches", [new Variable("sam"), new Variable("java")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("sam"), new Variable("java")])))
                    ]),
                    new ProgramRule(new Headless(), [
                        new LiteralBody(new AtomLiteral(true, new Atom("-teaches", [new Variable("bob"), new Variable("java")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("bob"), new Variable("java")])))
                    ]),
                    new ProgramRule(new Headless(), [
                        new LiteralBody(new AtomLiteral(true, new Atom("-teaches", [new Variable("bob"), new Variable("ai")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("bob"), new Variable("ai")])))
                    ]),
                    new ProgramRule(new Headless(), [
                        new LiteralBody(new AtomLiteral(true, new Atom("-teaches", [new Variable("tom"), new Variable("ai")]))),
                        new LiteralBody(new AtomLiteral(true, new Atom("teaches", [new Variable("tom"), new Variable("ai")])))
                    ])
           ],
           []
       )
   );

    yield return new PrepareResults(
       "unsat_1.lp",
       new Preperation(
           [],
           [
                new ProgramRule(new AtomHead(new Atom("-p", [])), []),
                    new ProgramRule(new AtomHead(new Atom("p", [])), [new LiteralBody(new AtomLiteral(true, new Atom("-p", [])))]),
                    new ProgramRule(new Headless(), [new LiteralBody(new AtomLiteral(true, new Atom("-p", []))), new LiteralBody(new AtomLiteral(true, new Atom("p", [])))])
           ],
           []
       )
   );

    yield return new PrepareResults(
        "unsat_2.lp",
        new Preperation(
            [],
            [
                 new ProgramRule(new AtomHead(new Atom("a", [])), []),
                    new ProgramRule(new AtomHead(new Atom("b", [])), []),
                    new ProgramRule(new Headless(), [new LiteralBody(new AtomLiteral(true, new Atom("a", []))), new LiteralBody(new AtomLiteral(true, new Atom("b", [])))])
            ],
            []
        )
    );
  }
}