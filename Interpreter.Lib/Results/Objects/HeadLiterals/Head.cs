using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.HeadLiterals;

public abstract class Head : IApplier<Head>
{
  public abstract Head Apply(Dictionary<string, Term> substitutions);

  public override string? ToString()
  {
    return base.ToString();
  }
}