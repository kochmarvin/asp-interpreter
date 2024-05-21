using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.HeadLiterals;

public class Headless : Head
{
  public override Head Apply(Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    return this;
  }

  public override List<Atom> GetHeadAtoms()
  {
    return [];
  }

  public override List<string> GetVariables()
  {
    return [];
  }

  public override bool HasVariables()
  {
    return false;
  }

  public override bool HasVariables(string variable)
  {
    return false;
  }

  public override string ToString()
  {
    return "";
  }
}