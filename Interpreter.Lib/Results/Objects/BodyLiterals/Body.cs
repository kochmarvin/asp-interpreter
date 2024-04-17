using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.BodyLiterals;

public abstract class Body : IApplier<Body>, IHasVariables
{
  public abstract Body Apply(Dictionary<string, Term> substitutions);

  public abstract bool HasVariables();

  public override string? ToString()
  {
    return base.ToString();
  }
}