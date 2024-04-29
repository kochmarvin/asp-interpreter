using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.BodyLiterals;

public abstract class Body : IApplier<Body>, IHasVariables, IGetVariables
{
  public abstract Body Apply(Dictionary<string, Term> substitutions);

  public abstract List<string> GetVariables();

  public abstract bool HasVariables();

  public abstract bool HasVariables(string variable);

  public override string? ToString()
  {
    return base.ToString();
  }
}