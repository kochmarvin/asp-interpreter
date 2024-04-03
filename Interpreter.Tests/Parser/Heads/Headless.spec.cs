namespace Interpreter.Tests.Parser;

using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Objects.Terms;
using NUnit.Framework;

[TestFixture]
public class HeadlessTests
{
  [Test]
  public void TestHeadless()
  {
    List<ProgramRule> program = Utils.ParseProgram("headless.lp");

    for (int i = 0; i < program.Count; i++)
    {
      Assert.IsInstanceOf<Headless>(program[i].Head, "Rule head has to be Headless");
    }
  }

  [Test]
  public void TestHeadlessSingle()
  {
    List<ProgramRule> program = Utils.ParseProgram("headless.lp");

    Assert.IsInstanceOf<Headless>(program[0].Head, "Rule head has to be Headless");

    foreach (var bodyLiterl in program[0].Body)
    {
      var literal = ((LiteralBody)bodyLiterl).Literal;
      var atom = ((AtomLiteral)literal).Atom;

      Assert.IsInstanceOf<string>(atom.Name, "Atom has to be a variable");
      Assert.That(atom.Args.Count, Is.EqualTo(0));
    }
  }

  [Test]
  public void TestHeadlessNot()
  {
    List<ProgramRule> program = Utils.ParseProgram("headless.lp");

    Assert.IsInstanceOf<Headless>(program[1].Head, "Rule head has to be Headless");

    foreach (var bodyLiterl in program[1].Body)
    {
      var literal = ((LiteralBody)bodyLiterl).Literal;
      var atomLiteral = ((AtomLiteral)literal);
      var atom = atomLiteral.Atom;

      Assert.That(atomLiteral.Positive, Is.EqualTo(false));
      Assert.IsInstanceOf<string>(atom.Name, "Atom has to be a variable");
      Assert.That(atom.Args.Count, Is.EqualTo(1));
    }
  }
}