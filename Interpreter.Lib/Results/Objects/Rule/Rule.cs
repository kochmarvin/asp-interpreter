using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.HeadLiterals;

namespace Interpreter.Lib.Results.Objects.Rule;

public class ProgramRule(HeadLiteral head, List<BodyLiteral> body)
{
  public HeadLiteral Head { get; } = head;
  public List<BodyLiteral> Body { get; } = body;
  public override string ToString()
  {
    var headString = Head.ToString();
    if (Body.Count > 0)
    {
      var bodyStrings = Body.Select(bl => bl.ToString());
      return $"{headString}:- {string.Join(", ", bodyStrings)}.";
    }
    return $"{headString}.".Replace(" ", "");
  }
}