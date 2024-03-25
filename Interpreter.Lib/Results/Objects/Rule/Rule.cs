using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Atoms;

namespace Interpreter.Lib.Results.Objects.Rule;

public class Rule(Atom head, List<BodyLiteral> body)
{
  public Atom Head { get; } = head;
  public List<BodyLiteral> Body { get; } = body;
  public override string ToString()
  {
    var headString = Head.ToString();
    if (Body.Count > 0)
    {
      var bodyStrings = Body.Select(bl => bl.ToString());
      return $"{headString} :- {string.Join(", ", bodyStrings)}.";
    }
    return $"{headString}.";
  }
}