using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Terms;

public class ParseAtomLiteralVisitor : LiteralVisitor<AtomLiteral>
{
  public override AtomLiteral Visit(LiteralBody literalBody)
  {
    return literalBody.Literal.Accept(this) ?? throw new InvalidOperationException("Trying to parse literal which is not the right instance");
  }
  public override AtomLiteral Visit(AtomLiteral atomLiteral)
  {
    ArgumentNullException.ThrowIfNull(atomLiteral, "Is not supposed to be null");

    return atomLiteral;
  }
}