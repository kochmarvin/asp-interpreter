namespace Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Atoms;
public class AtomLiteral(bool positive, Atom atom) : Literal
{
  public bool Positive { get; } = positive;
  public Atom Atom { get; } = atom;

  public override string ToString()
  {
    return $"{(Positive ? "" : "not ")}{Atom}";
  }
}