

using Interpreter.Lib.Results.Objects.Atoms;

namespace Interpreter.Lib.Results.Objects.HeadLiterals;

public class AtomHead(Atom atom) : HeadLiteral
{
  public Atom Atom { get; } = atom;

  public override string ToString()
  {
    return Atom.ToString() + " ";
  }
}