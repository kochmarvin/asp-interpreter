namespace Interpreter.Tests.Parser;

using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Objects.Terms;
using NUnit.Framework;

[TestFixture]
public class FunctionTermTests
{
  [Test]
  public void TestFunctionTerm()
  {
    List<ProgramRule> program = Utils.ParseProgram("function.lp");

    for (int i = 0; i < program.Count; i++)
    {
      Assert.IsInstanceOf<AtomHead>(program[i].Head, "Rule head has to be a AtomHead");

      var head = program[i].Head.Accept(new ObjectParser().ParseAtomHeadVisitor);
      Assert.That(head?.Atom.Name, Is.EqualTo("das"));
      Assert.IsInstanceOf<FunctionTerm>(head.Atom.Args[0]);

      var functionTerm = head.Atom.Args[0].Accept(new ObjectParser().ParseFunctionalVisitor);
      Assert.That(functionTerm?.Name, Is.EqualTo("ein"));

      Assert.IsInstanceOf<Variable>(functionTerm.Arguments[0]);

      var variable = functionTerm.Arguments[0].Accept(new ObjectParser().ParseVariableVisitor);
      Assert.That(variable?.Name, Is.EqualTo("test"));
    }

    Assert.That(program, Has.Count.EqualTo(1));
  }

  [Test]
  public void TestMultipleFunctionTerm()
  {
    List<ProgramRule> program = Utils.ParseProgram("function_multiple.lp");

    for (int i = 0; i < program.Count; i++)
    {
      Assert.IsInstanceOf<AtomHead>(program[i].Head, "Rule head has to be a AtomHead");
      var head = program[i].Head.Accept(new ObjectParser().ParseAtomHeadVisitor);

      foreach (Term term in head?.Atom.Args ?? [])
      {
        Assert.IsInstanceOf<FunctionTerm>(term);

        var functionTerm = term.Accept(new ObjectParser().ParseFunctionalVisitor);

        Assert.IsInstanceOf<Variable>(functionTerm?.Arguments[0]);
      }
    }

    Assert.That(program, Has.Count.EqualTo(1));
  }
}