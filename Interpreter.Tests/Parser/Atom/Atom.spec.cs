namespace Interpreter.Tests.Parser;

using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Objects.Terms;
using NUnit.Framework;

[TestFixture]
public class AtomTests
{
  [Test]
  public void TestAtomSigniture()
  {
    List<ProgramRule> program = Utils.ParseProgram("atom.lp");

    for (int i = 0; i < program.Count; i++)
    {
      Assert.IsInstanceOf<AtomHead>(program[i].Head, "Rule head has to be a AtomHead");

      var head = program[i].Head;
      Assert.That(head.GetHeadAtoms()[0].Signature, Is.EqualTo("informatiker/1"));


      var body = program[i].Body[0].Accept(new ObjectParser().ParseAtomLiteralVisitor);
      Assert.That(body?.Atom.Signature, Is.EqualTo("mensch/1"));
    }
  }
}