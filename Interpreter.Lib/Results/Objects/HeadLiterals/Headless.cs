using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.HeadLiterals;

public class Headless : Head
{
  public override Head Apply(Dictionary<string, Term> substitutions)
  {
    return this;
  }

  public override string ToString()
  {
    return "";
  }
}