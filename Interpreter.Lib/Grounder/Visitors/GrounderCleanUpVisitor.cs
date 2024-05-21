using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;

public class GrounderCleanUpVisitor : LiteralVisitor<bool>
{
  public override bool Visit(LiteralBody literalBody)
  {
    ArgumentNullException.ThrowIfNull(literalBody, "Is not supposed to be null");

    return literalBody.Literal.Accept(this);
  }

  public override bool Visit(AtomLiteral atomLiteral)
  {
    ArgumentNullException.ThrowIfNull(atomLiteral, "Is not supposed to be null");

    return  atomLiteral.Positive;
  }
}