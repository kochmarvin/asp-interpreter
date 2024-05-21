using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.HeadLiterals;

public class ChoiceHead : Head
{
  private List<Atom> atoms;
  public List<Atom> Atoms
  {
    get
    {
      return atoms;
    }
    private set
    {
      atoms = value ?? throw new ArgumentNullException(nameof(Atoms), "Is not supposed to be null");
    }
  }

  public ChoiceHead(List<Atom> atoms)
  {
    Atoms = atoms;
  }

  public override Head Apply(Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    var appliedChoices = Atoms.Select(atom => atom.Apply(substitutions)).ToList();
    return new ChoiceHead(appliedChoices);
  }

  public override List<Atom> GetHeadAtoms()
  {
    return Atoms;
  }

  public override List<string> GetVariables()
  {
    List<string> vars = [];

    foreach (var atom in Atoms)
    {
      vars.AddRange(atom.GetVariables());
    }

    return vars;
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