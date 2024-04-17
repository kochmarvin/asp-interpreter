using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

namespace Tests.Grounder;

[TestFixture]
public class MatcherTests
{
  [Test]
  public void NumberMatcherTrue()
  {
    var substitutions = new Dictionary<string, Term>
    {
      { "X", new Number(3) }
    };
    Number number = new(3);
    bool match = number.Match(new Number(3), substitutions);

    Assert.That(match, Is.EqualTo(true));
  }

  [Test]
  public void NumberMatcherFalse()
  {
    var substitutions = new Dictionary<string, Term>
    {
      { "X", new Number(3) }
    };
    Number number = new(1);
    bool match = number.Match(new Number(3), substitutions);

    Assert.That(match, Is.EqualTo(false));
  }

  [Test]
  public void VariableMatchSubstitution()
  {
    var substitutions = new Dictionary<string, Term>
    {
      { "X", new Variable("marvin") }
    };
    Variable vars = new("X");
    bool match = vars.Match(new Variable("marvin"), substitutions);

    Assert.That(match, Is.EqualTo(true));
  }

  [Test]
  public void VariableMatchSubstitutionFalse()
  {
    var substitutions = new Dictionary<string, Term>
    {
      { "X", new Variable("marvin") }
    };
    Variable vars = new("X");
    bool match = vars.Match(new Variable("X"), substitutions);

    Assert.That(match, Is.EqualTo(false));
  }

  [Test]
  public void VariableMatch()
  {
    var substitutions = new Dictionary<string, Term>
    {
      { "X", new Variable("marvin") }
    };
    Variable vars = new("Y");
    bool match = vars.Match(new Variable("marvin"), substitutions);

    Assert.NotNull(substitutions["Y"]);
    Assert.That(match, Is.EqualTo(true));
  }

  [Test]
  public void FunctionMatcherFailName()
  {
    FunctionTerm vars = new("marvin", []);
    bool match = vars.Match(new FunctionTerm("julia", []), []);

    Assert.That(match, Is.EqualTo(false));
  }

  [Test]
  public void FunctionMatcherFailArgsCount()
  {
    FunctionTerm vars = new("marvin", [new Variable("X")]);
    bool match = vars.Match(new FunctionTerm("marvin", []), []);

    Assert.That(match, Is.EqualTo(false));
  }

  [Test]
  public void AtomMatcherFailName()
  {
    Atom vars = new("marvin", []);
    bool match = vars.Match(new Atom("julia", []), []);

    Assert.That(match, Is.EqualTo(false));
  }

  [Test]
  public void AtomMatcherFailArgsCount()
  {
    Atom vars = new("marvin", [new Variable("X")]);
    bool match = vars.Match(new Atom("marvin", []), []);

    Assert.That(match, Is.EqualTo(false));
  }

}