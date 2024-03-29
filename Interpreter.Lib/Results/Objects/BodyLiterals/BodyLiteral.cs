using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.BodyLiterals;

public abstract class BodyLiteral : IApplier<BodyLiteral>
{
  public abstract BodyLiteral Apply(Dictionary<string, Term> substitutions);

  public override string ToString()
  {
    return base.ToString();
  }
}