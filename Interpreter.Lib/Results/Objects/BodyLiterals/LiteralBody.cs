using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.BodyLiterals;

public class LiteralBody(Literal literal) : Body
{
  public Literal Literal { get; } = literal;

  public override Body Apply(Dictionary<string, Term> substitutions)
  {
    Literal appliedLiteral = Literal.Apply(substitutions);
    return new LiteralBody(appliedLiteral);
  }

  public override List<string> GetVariables()
  {
    return Literal.GetVariables();
  }

  public override bool HasVariables()
  {
    return Literal.HasVariables();
  }

  public override bool HasVariables(string variable)
  {
    return Literal.HasVariables(variable);
  }

  public override string? ToString()
  {
    return Literal.ToString();
  }
}