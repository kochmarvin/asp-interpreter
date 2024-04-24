namespace Interpreter.Lib.Results.Objects.Literals;

using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

public class AtomLiteral(bool positive, Atom atom) : Literal
{
  public bool Positive { get; } = positive;
  public Atom Atom { get; } = atom;

  public override Literal Apply(Dictionary<string, Term> substitutions)
  {
    Atom appliedAtom = Atom.Apply(substitutions);
    return new AtomLiteral(Positive, appliedAtom);
  }

  public override List<string> GetVariables()
  {
    return Atom.GetVariables();
  }

  public override bool HasVariables()
  {
    return Atom.HasVariables();
  }

  public override string ToString()
  {
    return $"{(Positive ? "" : "not ")}{Atom}";
  }
}