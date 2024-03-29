using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.Rule;

public class ProgramRule(HeadLiteral head, List<BodyLiteral> body) : IApplier<ProgramRule>
{
  public HeadLiteral Head { get; } = head;
  public List<BodyLiteral> Body { get; set; } = body;

  public ProgramRule Apply(Dictionary<string, Term> substitutions)
  {
    HeadLiteral appliedHead = Head.Apply(substitutions);
    var appliedBody = Body.Select(bl => bl.Apply(substitutions)).ToList();
    return new ProgramRule(appliedHead, appliedBody);
  }

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