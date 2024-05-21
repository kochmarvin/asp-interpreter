using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;

public class TransformToAtomLiteralVisitor : LiteralVisitor<AtomLiteral>
{
  public override AtomLiteral Visit(LiteralBody literalBody)
  {
    ArgumentNullException.ThrowIfNull(literalBody, "Is not supposed to be null");

    return literalBody.Literal.Accept(this) ?? throw new InvalidOperationException("You are trying to transform a Atom Literal which is none");
  }

  public override AtomLiteral Visit(AtomLiteral atomLiteral)
  {
    ArgumentNullException.ThrowIfNull(atomLiteral, "Is not supposed to be null");

    return atomLiteral;
  }
}