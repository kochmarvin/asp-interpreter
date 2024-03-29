namespace Interpreter.Tests.Parser;

using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Objects.Terms;
using NUnit.Framework;

[TestFixture]
public class VariableTermTests
{
  [Test]
  public void TestVariableTerm()
  {
    List<ProgramRule> program = Utils.ParseProgram("variables.lp");

    for (int i = 0; i < program.Count; i++)
    {
      Assert.IsInstanceOf<AtomHead>(program[i].Head, "Rule head has to be a AtomHead");

      var head = (AtomHead)program[i].Head;

      Assert.That(head.Atom.Name, Is.EqualTo("mensch"));
      Assert.That(head.Atom.Args, Has.Count.EqualTo(1));
      Assert.IsInstanceOf<Variable>(head.Atom.Args[0]);
    }

    Assert.That(program, Has.Count.EqualTo(3));
  }

  [Test]
  public void TestMultipleVariableTerm()
  {
    List<ProgramRule> program = Utils.ParseProgram("variables_multiple.lp");

    for (int i = 0; i < program.Count; i++)
    {
      Assert.IsInstanceOf<AtomHead>(program[i].Head, "Rule head has to be a AtomHead");
      var head = (AtomHead)program[i].Head;
      foreach (Term term in head.Atom.Args)
      {
        Assert.IsInstanceOf<Variable>(term);
      }
    }

    Assert.That(program, Has.Count.EqualTo(4));
  }
}