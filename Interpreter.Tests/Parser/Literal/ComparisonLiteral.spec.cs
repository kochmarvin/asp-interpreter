namespace Interpreter.Tests.Parser;

using Interpreter.Lib.Results.Enums;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Objects.Terms;
using NUnit.Framework;

[TestFixture]
public class ComparisonBodyTests
{
  private List<ProgramRule> _program;

  [SetUp]
  public void Init()
  {
    _program = Utils.ParseProgram("comparison.lp");
  }

  [Test]
  public void TestEqual()
  {
    var body = _program[0].Body[0];

    var comparisonLiteral = body.Accept(new ObjectParser().ParseComparisonLiteralVisitor);
    Assert.IsInstanceOf<ComparisonLiteral>(comparisonLiteral, "Body has to be a comparison Literal");
    Assert.IsInstanceOf<Variable>(comparisonLiteral?.Left);
    Assert.IsInstanceOf<Variable>(comparisonLiteral?.Right);
    Assert.That(comparisonLiteral?.TermRelation, Is.EqualTo(Relation.Equal));
  }

  [Test]
  public void TestGreater()
  {
    var body = _program[1].Body[0];

    var comparisonLiteral = body.Accept(new ObjectParser().ParseComparisonLiteralVisitor);
    Assert.IsInstanceOf<ComparisonLiteral>(comparisonLiteral, "Body has to be a comparison Literal");
    Assert.IsInstanceOf<FunctionTerm>(comparisonLiteral?.Left);
    Assert.IsInstanceOf<FunctionTerm>(comparisonLiteral?.Right);
    Assert.That(comparisonLiteral?.TermRelation, Is.EqualTo(Relation.GreaterThan));
  }

  [Test]
  public void TestLess()
  {
    var body = _program[2].Body[0];

    var comparisonLiteral = body.Accept(new ObjectParser().ParseComparisonLiteralVisitor);
    Assert.IsInstanceOf<ComparisonLiteral>(comparisonLiteral, "Body has to be a comparison Literal");
    Assert.IsInstanceOf<Number>(comparisonLiteral?.Left);
    Assert.IsInstanceOf<Number>(comparisonLiteral?.Right);
    Assert.That(comparisonLiteral?.TermRelation, Is.EqualTo(Relation.LessThan));
  }

  [Test]
  public void TestGreaterEqual()
  {
    var body = _program[3].Body[0];

    var comparisonLiteral = body.Accept(new ObjectParser().ParseComparisonLiteralVisitor);
    Assert.IsInstanceOf<ComparisonLiteral>(comparisonLiteral, "Body has to be a comparison Literal");
    Assert.IsInstanceOf<Variable>(comparisonLiteral?.Left);
    Assert.IsInstanceOf<Variable>(comparisonLiteral?.Right);
    Assert.That(comparisonLiteral?.TermRelation, Is.EqualTo(Relation.GreaterEqual));
  }
  [Test]
  public void TestLessEqual()
  {
    var body = _program[4].Body[0];

    var comparisonLiteral = body.Accept(new ObjectParser().ParseComparisonLiteralVisitor);
    Assert.IsInstanceOf<ComparisonLiteral>(comparisonLiteral, "Body has to be a comparison Literal");
    Assert.IsInstanceOf<Variable>(comparisonLiteral?.Left);
    Assert.IsInstanceOf<Variable>(comparisonLiteral?.Right);
    Assert.That(comparisonLiteral?.TermRelation, Is.EqualTo(Relation.LessEqual));
  }

  [Test]
  public void TestInEqual()
  {
    var body = _program[5].Body[0];

    var comparisonLiteral = body.Accept(new ObjectParser().ParseComparisonLiteralVisitor);
    Assert.IsInstanceOf<ComparisonLiteral>(comparisonLiteral, "Body has to be a comparison Literal");
    Assert.IsInstanceOf<Variable>(comparisonLiteral?.Left);
    Assert.IsInstanceOf<Variable>(comparisonLiteral?.Right);
    Assert.That(comparisonLiteral?.TermRelation, Is.EqualTo(Relation.Inequal));
  }

  [Test]
  public void TestInEqual_v2()
  {
    var body = _program[6].Body[0];

    var comparisonLiteral = body.Accept(new ObjectParser().ParseComparisonLiteralVisitor);
    Assert.IsInstanceOf<ComparisonLiteral>(comparisonLiteral, "Body has to be a comparison Literal");
    Assert.IsInstanceOf<Variable>(comparisonLiteral?.Left);
    Assert.IsInstanceOf<Variable>(comparisonLiteral?.Right);
    Assert.That(comparisonLiteral?.TermRelation, Is.EqualTo(Relation.Inequal));
  }
}