namespace Interpreter.Tests.Parser;

using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Objects.Terms;
using NUnit.Framework;

[TestFixture]
public class ChoiceHeadTests
{
  [Test]
  public void TestChoiceHead()
  {
    List<ProgramRule> program = Utils.ParseProgram("choice_head.lp");

    for (int i = 0; i < program.Count; i++)
    {
      Assert.IsInstanceOf<ChoiceHead>(program[i].Head, "Rule head has to be a Choicehead");
    }
  }

  [Test]
  public void TestChoiceHeadAtoms()
  {
    List<ProgramRule> program = Utils.ParseProgram("choice_head.lp");

    Assert.IsInstanceOf<ChoiceHead>(program[0].Head, "Rule head has to be a Choicehead");

    foreach (var atom in program[0].Head.GetHeadAtoms())
    {
      Assert.IsInstanceOf<string>(atom.Name, "Atom has to be a variable");
      Assert.That(atom.Args.Count, Is.EqualTo(0));
    }
  }
}