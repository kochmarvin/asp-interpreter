using Interpreter.Lib.Results.Objects.Literals;

namespace Interpreter.Lib.Results.Objects.BodyLiterals;

public class LiteralBody(Literal literal) : BodyLiteral
{
  public Literal Literal { get; } = literal;

  public override string ToString()
  {
    return Literal.ToString();
  }
}