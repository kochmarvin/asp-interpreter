namespace Interpreter.Tests.Parser;

using Interpreter.Lib.Results.Enums;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Objects.Terms;
using NUnit.Framework;

[TestFixture]
public class AtomLiteralTests
{
  private List<ProgramRule> _program;

  [SetUp]
  public void Init()
  {
    _program = Utils.ParseProgram("literal.lp");
  }

  [Test]
  public void TestNegative()
  {
    var body = (LiteralBody)_program[0].Body[0];

    Assert.IsInstanceOf<AtomLiteral>(body.Literal, "Body has to be a atom Literal");
    var atomLiteral = body.Accept(new ObjectParser().ParseAtomLiteralVisitor);
    Assert.That(atomLiteral?.Positive, Is.EqualTo(false));
  }

  [Test]
  public void TestPositive()
  {
    var body = (LiteralBody)_program[1].Body[0];

    Assert.IsInstanceOf<AtomLiteral>(body.Literal, "Body has to be a atom Literal");
    var atomLiteral = body.Accept(new ObjectParser().ParseAtomLiteralVisitor);
    Assert.That(atomLiteral?.Positive, Is.EqualTo(true));
  }
}