using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.Literals;

public abstract class Literal : IApplier<Literal>, IHasVariables, IGetVariables
{
  public abstract Literal Apply(Dictionary<string, Term> substitutions);

  public abstract List<string> GetVariables();

  public abstract bool HasVariables();

  public override string? ToString()
  {
    return base.ToString();
  }
}