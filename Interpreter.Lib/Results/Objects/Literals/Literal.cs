using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.Literals;

public abstract class Literal : IApplier<Literal>
{
  public object Atom { get; internal set; }

  public abstract Literal Apply(Dictionary<string, Term> substitutions);

  public override string ToString()
  {
    return base.ToString();
  }
}