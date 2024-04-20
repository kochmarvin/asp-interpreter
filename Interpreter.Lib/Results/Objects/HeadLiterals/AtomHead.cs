
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.HeadLiterals;

public class AtomHead(Atom atom) : Head
{
  public Atom Atom { get; } = atom;

  public override Head Apply(Dictionary<string, Term> substitutions)
  {
    return new AtomHead(Atom.Apply(substitutions));
  }

  public override bool HasVariables()
  {
    return Atom.HasVariables();
  }

  public override string ToString()
  {
    return Atom.ToString() + " ";
  }
}