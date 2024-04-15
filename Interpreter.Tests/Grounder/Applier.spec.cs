using Interpreter.Lib.Results.Enums;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Terms;
using NUnit.Framework.Constraints;

namespace Tests.Grounder;

[TestFixture]
public class ApplierTests
{
  [Test]
  public void NumberApplier()
  {
    var substitutions = new Dictionary<string, Term>
    {
      { "X", new Number(3) }
    };
    Number number = new(3);
    Number newTerm = (Number)number.Apply(substitutions);

    Assert.That(newTerm.Value, Is.EqualTo(3));
  }

  [Test]
  public void VariableApplierFind()
  {
    var substitutions = new Dictionary<string, Term>
    {
      { "X", new Number(3) }
    };
    Variable number = new("X");
    Number newTerm = (Number)number.Apply(substitutions);

    Assert.That(newTerm.Value, Is.EqualTo(3));
  }

  [Test]
  public void VariableApplierNoFind()
  {
    var substitutions = new Dictionary<string, Term>
    {
      { "X", new Number(3) }
    };
    Variable vars = new("Y");
    Variable newTerm = (Variable)vars.Apply(substitutions);

    Assert.That(newTerm.Name, Is.EqualTo("Y"));
  }

  [Test]
  public void FunctionApplier()
  {
    var substitutions = new Dictionary<string, Term>
    {
      { "X", new Number(3) }
    };
    FunctionTerm vars = new FunctionTerm("marvin", [new Variable("X")]);
    FunctionTerm newTerm = (FunctionTerm)vars.Apply(substitutions);

    Assert.That(newTerm.ToString(), Is.EqualTo("marvin(3)"));
  }

  [Test]
  public void AtomApplier()
  {
    var substitutions = new Dictionary<string, Term>
    {
      { "X", new Number(3) },
      { "Y", new Number(10) }
    };
    Atom atom = new Atom("julia", [new Variable("X"), new Variable("Y")]);
    Atom newTerm = (Atom)atom.Apply(substitutions);

    Assert.That(newTerm.ToString(), Is.EqualTo("julia(3, 10)"));
  }

  [Test]
  public void ComparisonLiteralApplier()
  {
    var substitutions = new Dictionary<string, Term>
    {
      { "X", new Number(3) },
      { "Y", new Number(10) }
    };
    ComparisonLiteral lit = new ComparisonLiteral(new Variable("X"), Relation.Equal, new Variable("Y"));
    ComparisonLiteral newTerm = (ComparisonLiteral)lit.Apply(substitutions);

    Assert.That(newTerm.ToString(), Is.EqualTo("3==10"));
  }

  [Test]
  public void AtomLiteralApplier()
  {
    var substitutions = new Dictionary<string, Term>
    {
      { "X", new Number(3) },
      { "Y", new Number(10) }
    };
    AtomLiteral lit = new AtomLiteral(false, new Atom("julia", [new Variable("X")]));
    AtomLiteral newTerm = (AtomLiteral)lit.Apply(substitutions);

    Assert.That(newTerm.ToString(), Is.EqualTo("not julia(3)"));
  }

  [Test]
  public void BodyComparisonLiteralApplier()
  {
    var substitutions = new Dictionary<string, Term>
    {
      { "X", new Number(3) },
      { "Y", new Number(10) }
    };
    ComparisonLiteral lit = new ComparisonLiteral(new Variable("X"), Relation.Equal, new Variable("Y"));
    LiteralBody literalBody = new LiteralBody(lit);
    LiteralBody newTerm = (LiteralBody)literalBody.Apply(substitutions);

    Assert.That(newTerm.ToString(), Is.EqualTo("3==10"));
  }

  [Test]
  public void BodyAtomLiteralApplier()
  {
    var substitutions = new Dictionary<string, Term>
    {
      { "X", new Number(3) },
      { "Y", new Number(10) }
    };
    AtomLiteral lit = new AtomLiteral(false, new Atom("julia", [new Variable("X")]));
    LiteralBody literalBody = new LiteralBody(lit);
    LiteralBody newTerm = (LiteralBody)literalBody.Apply(substitutions);

    Assert.That(newTerm.ToString(), Is.EqualTo("not julia(3)"));
  }

  [Test]
  public void HeadlessApplier()
  {
    var substitutions = new Dictionary<string, Term>
    {
      { "X", new Number(3) },
      { "Y", new Number(10) }
    };
    Headless headless = new Headless();
    Headless newTerm = (Headless)headless.Apply(substitutions);

    Assert.That(headless, Is.EqualTo(newTerm));
  }

  [Test]
  public void AtomHeadApplier()
  {
    var substitutions = new Dictionary<string, Term>
    {
      { "X", new Number(3) },
      { "Y", new Number(10) }
    };
    AtomHead atomHead = new AtomHead(new Atom("hanoi", [new Variable("X")]));
    AtomHead newTerm = (AtomHead)atomHead.Apply(substitutions);

    Assert.That(newTerm.ToString(), Is.EqualTo("hanoi(3) "));
  }

  [Test]
  public void ChoiceHeadApplier()
  {
    var substitutions = new Dictionary<string, Term>
    {
      { "X", new Number(3) },
      { "Y", new Number(10) }
    };
    ChoiceHead atomHead = new ChoiceHead([new Atom("hanoi", [new Variable("X")])]);
    ChoiceHead newTerm = (ChoiceHead)atomHead.Apply(substitutions);

    Assert.That(newTerm.ToString(), Is.EqualTo("{hanoi(3)} "));
  }
}