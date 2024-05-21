using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Terms;

public class IsAtomLiteralVisitor : LiteralVisitor<bool>
{
  public override bool Visit(LiteralBody literalBody)
  {
    return literalBody.Literal.Accept(this);
  }
  public override bool Visit(AtomLiteral atomLiteral)
  {
    ArgumentNullException.ThrowIfNull(atomLiteral, "Is not supposed to be null");

    return true;
  }
}