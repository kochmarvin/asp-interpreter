using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;

public class OrderVisitor : LiteralVisitor<int>
{
  public override int Visit(LiteralBody literalBody)
  {
    ArgumentNullException.ThrowIfNull(literalBody, "Is not supposed to be null");
    return literalBody.Literal.Accept(this);
  }

  public override int Visit(CommentLiteral commentLiteral)
  {
    ArgumentNullException.ThrowIfNull(commentLiteral, "Is not supposed to be null");

    return 2;
  }

  public override int Visit(AtomLiteral atomLiteral)
  {
    ArgumentNullException.ThrowIfNull(atomLiteral, "Is not supposed to be null");

    if (atomLiteral.Positive)
    {
      return 0;
    }

    return 1;
  }

  public override int Visit(ComparisonLiteral comparisonLiteral)
  {
    ArgumentNullException.ThrowIfNull(comparisonLiteral, "Is not supposed to be null");

    return 2;
  }

  public override int Visit(IsLiteral isLiteral)
  {
    ArgumentNullException.ThrowIfNull(isLiteral, "Is not supposed to be null");

    return 2;
  }
}