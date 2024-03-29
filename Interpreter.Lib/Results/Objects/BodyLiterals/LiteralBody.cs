using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.BodyLiterals;

public class LiteralBody(Literal literal) : BodyLiteral
{
  public Literal Literal { get; } = literal;

  public override BodyLiteral Apply(Dictionary<string, Term> substitutions)
  {
    Literal appliedLiteral = Literal.Apply(substitutions);
    return new LiteralBody(appliedLiteral);
  }

  public override string ToString()
  {
    return Literal.ToString();
  }
}