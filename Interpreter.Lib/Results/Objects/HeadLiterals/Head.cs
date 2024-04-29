using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.HeadLiterals;

public abstract class Head : IApplier<Head>, IHasVariables
{
  public abstract Head Apply(Dictionary<string, Term> substitutions);

  public abstract bool HasVariables();

  public abstract bool HasVariables(string variable);

  public override string? ToString()
  {
    return base.ToString();
  }
}