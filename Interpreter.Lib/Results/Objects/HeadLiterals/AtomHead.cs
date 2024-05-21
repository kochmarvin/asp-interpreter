
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.HeadLiterals;

public class AtomHead : Head
{
  private Atom atom;
  public Atom Atom
  {
    get
    {
      return atom;
    }
    private set
    {
      atom = value ?? throw new ArgumentNullException(nameof(Atom), "Is not supposed to be null");
    }
  }

  public AtomHead(Atom atom)
  {
    Atom = atom;
  }

  public override Head Apply(Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");
    
    return new AtomHead(Atom.Apply(substitutions));
  }

  public override List<Atom> GetHeadAtoms()
  {
    return [Atom];
  }

  public override List<string> GetVariables()
  {
    return Atom.GetVariables();
  }

  public override bool HasVariables()
  {
    return Atom.HasVariables();
  }

  public override bool HasVariables(string variable)
  {
    return Atom.HasVariables(variable);
  }

  public override string ToString()
  {
    return Atom.ToString() + " ";
  }
}