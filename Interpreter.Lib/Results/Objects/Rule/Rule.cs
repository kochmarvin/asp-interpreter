using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.Rule;

public class ProgramRule(Head head, List<Body> body) : IApplier<ProgramRule>, IHasVariables
{
  public Head Head { get; } = head;
  public List<Body> Body { get; set; } = body;

  public ProgramRule Apply(Dictionary<string, Term> substitutions)
  {
    Head appliedHead = Head.Apply(substitutions);
    var appliedBody = new List<Body>();
    foreach (var bodyLiteral in Body)
    {
      appliedBody.Add(bodyLiteral.Apply(substitutions));
    }
    return new ProgramRule(appliedHead, appliedBody);
  }

  public bool HasVariables()
  {
    if (Head.HasVariables())
    {
      return true;
    }

    foreach (var bodyLiteral in Body)
    {
      if (bodyLiteral.HasVariables())
      {
        return true;
      }
    }

    return false;
  }

  public bool HasVariables(string variable)
  {
    if (Head.HasVariables(variable))
    {
      return true;
    }

    foreach (var bodyLiteral in Body)
    {
      if (bodyLiteral.HasVariables(variable))
      {
        return true;
      }
    }

    return false;
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