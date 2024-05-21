using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;

namespace Interpreter.Lib.Results.Vistors;

public class MyOrderVisitor : OrderVisitor
{
  public override int Order(AtomLiteral atomLiteral)
  {
    if (atomLiteral.Positive)
    {
      return 0;
    }

    return 1;
  }

  public override int Order(LiteralBody literalBody)
  {
    return literalBody.Literal.Order(this);
  }

  public override int Order(IsLiteral atomLiteral)
  {
    return 1;
  }

  public override int Order(CommentLiteral atomLiteral)
  {
    return 1;
  }

  public override int Order(ComparisonLiteral atomLiteral)
  {
    return 2;
  }
}