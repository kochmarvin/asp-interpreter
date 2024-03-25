

using Interpreter.Lib.Results.Objects.Atoms;

namespace Interpreter.Lib.Results.Objects.HeadLiterals;

public class ChoiceHead(List<Atom> atoms) : HeadLiteral
{
  public List<Atom> Atoms { get; } = atoms;

  public override string ToString()
  {
    var headString = Atoms.Select(bl => bl.ToString());
    return "{" + $"{string.Join("; ", headString)}" + "} ";
  }
}