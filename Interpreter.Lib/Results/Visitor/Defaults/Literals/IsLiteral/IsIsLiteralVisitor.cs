using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Terms;

public class IsIsLiteralVisitor : LiteralVisitor<bool>
{
  public override bool Visit(LiteralBody literalBody)
  {
    return literalBody.Literal.Accept(this);
  }
  public override bool Visit(IsLiteral isLiteral)
  {
    ArgumentNullException.ThrowIfNull(isLiteral, "Is not supposed to be null");

    return true;
  }
}