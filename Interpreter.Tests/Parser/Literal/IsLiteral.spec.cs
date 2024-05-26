namespace Interpreter.Tests.Parser;

using Interpreter.Lib.Results.Enums;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Objects.Terms;
using NUnit.Framework;

[TestFixture]
public class IsBodyTest
{
  private List<ProgramRule> _program;

  [SetUp]
  public void Init()
  {
    _program = Utils.ParseProgram("isLiteral.lp");
  }

  [Test]
  public void TestNumberIs()
  {
    var body = _program[1].Body[0];

    var isLiteral = body.Accept(new ObjectParser().ParseIsLiteralVisitor);
    Assert.IsInstanceOf<IsLiteral>(isLiteral, "Body has to be a is Literal");
    Assert.IsInstanceOf<Number>(isLiteral?.Left);
    Assert.IsInstanceOf<Number>(isLiteral?.Right);
  }

  [Test]
  public void TestOneVariable()
  {
    var body = _program[2].Body[1];

    var isLiteral = body.Accept(new ObjectParser().ParseIsLiteralVisitor);
    Assert.IsInstanceOf<IsLiteral>(isLiteral, "Body has to be a is Literal");
    Assert.IsInstanceOf<Number>(isLiteral?.Left);
    Assert.IsInstanceOf<Variable>(isLiteral?.Right);
  }

  [Test]
  public void TestOneVariableSwitch()
  {
    var body = _program[3].Body[1];

    var isLiteral = body.Accept(new ObjectParser().ParseIsLiteralVisitor);
    Assert.IsInstanceOf<IsLiteral>(isLiteral, "Body has to be a is Literal");
    Assert.IsInstanceOf<Variable>(isLiteral?.Left);
    Assert.IsInstanceOf<Number>(isLiteral?.Right);
  }

  [Test]
  public void TestBothVariables()
  {
    var body = _program[4].Body[2];

    var isLiteral = body.Accept(new ObjectParser().ParseIsLiteralVisitor);
    Assert.IsInstanceOf<IsLiteral>(isLiteral, "Body has to be a is Literal");
    Assert.IsInstanceOf<Variable>(isLiteral?.Left);
    Assert.IsInstanceOf<Variable>(isLiteral?.Right);
  }
}