using Interpreter.Lib.Graph;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Vistors;


namespace Tests.Tree;

[TestFixture]
public class TreeTest
{
  [Test]
  public void BasicDependecy()
  {
    DependencyGraph tree = new MyDependencyGraph([
      new ProgramRule(new AtomHead(new Atom("b", [])), [new LiteralBody(new AtomLiteral(true, new Atom("a", [])))]),
      new ProgramRule(new AtomHead(new Atom("a", [])), []),
    ], new MyOrderVisitor(),
      new MyAddToGraphVisitor());

    var graphs = tree.CreateGraph(true);
    graphs.Reverse();


    Assert.That(graphs[0][0].ToString(), Is.EqualTo("a."));
    Assert.That(graphs[1][0].ToString(), Is.EqualTo("b :- a."));
  }

  [Test]
  public void NumberApplier()
  {
    DependencyGraph tree = new MyDependencyGraph([
      new ProgramRule(new AtomHead(new Atom("b", [])), [new LiteralBody(new AtomLiteral(false, new Atom("a", [])))]),
      new ProgramRule(new AtomHead(new Atom("a", [])), [new LiteralBody(new AtomLiteral(false, new Atom("b", [])))]),
    ], new MyOrderVisitor(),
      new MyAddToGraphVisitor());

    var graphs = tree.CreateGraph(true);
    graphs.Reverse();


    Assert.That(graphs[0][0].ToString(), Is.EqualTo("b :- not a."));
    Assert.That(graphs[1][0].ToString(), Is.EqualTo("a :- not b."));
  }
}