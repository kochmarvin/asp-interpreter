namespace Interpreter.Tests.Parser;

using System.Data;
using Antlr4.Runtime;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Objects.Terms;
using NUnit.Framework;

[TestFixture]
public class NumberTermTests
{
  [Test]
  public void TestNumberTerm()
  {
    List<ProgramRule> program = Utils.ParseProgram("numbers.lp");

    for (int i = 0; i < program.Count; i++)
    {
      Assert.IsInstanceOf<AtomHead>(program[i].Head, "Rule head has to be a AtomHead");

      var head = program[i].Head.Accept(new ObjectParser().ParseAtomHeadVisitor);

      Assert.That(head?.Atom.Name, Is.EqualTo("node"));
      Assert.That(head?.Atom.Args, Has.Count.EqualTo(1));
      Assert.IsInstanceOf<Number>(head.Atom.Args[0]);

      var term = head.Atom.Args[0].Accept(new ObjectParser().ParseNumberVisitor);

      Assert.That(i + 1, Is.EqualTo(term?.Value));
    }

    Assert.That(program, Has.Count.EqualTo(7));
  }

  [Test]
  public void TestNegativeNumberTerm()
  {
    List<ProgramRule> program = Utils.ParseProgram("numbers_negative.lp");

    for (int i = 0; i < program.Count; i++)
    {
      Assert.IsInstanceOf<AtomHead>(program[i].Head, "Rule head has to be a AtomHead");

      var head = program[i].Head.Accept(new ObjectParser().ParseAtomHeadVisitor);

      Assert.That(head?.Atom.Name, Is.EqualTo("node"));
      Assert.That(head?.Atom.Args, Has.Count.EqualTo(1));
      Assert.IsInstanceOf<Number>(head.Atom.Args[0]);

      var term = head.Atom.Args[0].Accept(new ObjectParser().ParseNumberVisitor);

      Assert.That((i + 1) * -1, Is.EqualTo(term?.Value));
    }

    Assert.That(program, Has.Count.EqualTo(7));
  }

  [Test]
  public void TestMultipleNumberTerms()
  {
    List<ProgramRule> program = Utils.ParseProgram("numbers_multiple.lp");

    for (int i = 0; i < program.Count; i++)
    {
      Assert.IsInstanceOf<AtomHead>(program[i].Head, "Rule head has to be a AtomHead");

      var head = program[i].Head.Accept(new ObjectParser().ParseAtomHeadVisitor);

      Assert.That(head?.Atom.Name, Is.EqualTo("node"));

      foreach (Term term in head.Atom.Args)
      {
        Assert.IsInstanceOf<Number>(term);
      }
    }

    Assert.That(program, Has.Count.EqualTo(7));
  }
}