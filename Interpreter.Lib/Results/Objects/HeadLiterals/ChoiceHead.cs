

using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.HeadLiterals;

public class ChoiceHead(List<Atom> atoms) : Head
{
  public List<Atom> Atoms { get; } = atoms;

  public override Head Apply(Dictionary<string, Term> substitutions)
  {
    var appliedChoices = Atoms.Select(a => a.Apply(substitutions)).ToList();
    return new ChoiceHead(appliedChoices);
  }

  public override bool HasVariables()
  {
    foreach (var atom in Atoms)
    {
      if (atom.HasVariables())
      {
        return true;
      }
    }

    return false;
  }

  public override bool HasVariables(string variable)
  {
    foreach (var atom in Atoms)
    {
      if (atom.HasVariables(variable))
      {
        return true;
      }
    }

    return false;
  }

  public override string ToString()
  {
    var headString = Atoms.Select(bl => bl.ToString());
    return "{" + $"{string.Join("; ", headString)}" + "} ";
  }
}