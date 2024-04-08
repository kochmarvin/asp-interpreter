using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.BodyLiterals;

public abstract class Body : IApplier<Body>
{
  public abstract Body Apply(Dictionary<string, Term> substitutions);

  public override string ToString()
  {
    return base.ToString();
  }
}