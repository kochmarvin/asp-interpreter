using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.Rule;

/// <summary>
/// The full programm rule whith its head and body
/// </summary>
/// <param name="head">The head of the rule.</param>
/// <param name="body">The bodeis of the rule</param>
public class ProgramRule : IApplier<ProgramRule>, IHasVariables
{
  private Head head;
  private List<Body> body;

  public Head Head
  {
    get
    {
      return head;
    }
    private set
    {
      head = value ?? throw new ArgumentNullException(nameof(Head), "Is not supposed to be null");
    }
  }


  public List<Body> Body
  {
    get
    {
      return body;
    }

    set
    {
      body = value ?? throw new ArgumentNullException(nameof(Body), "Is not supposed to be null");
    }
  }

  public ProgramRule(Head head, List<Body> body)
  {
    Head = head;
    Body = body;
  }

  /// <summary>
  /// Applies the substitution to every body of the rule.
  /// </summary>
  /// <param name="substitutions">The found substitutions.</param>
  /// <returns>A new rule instance.</returns>
  public ProgramRule Apply(Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    Head appliedHead = Head.Apply(substitutions);
    var appliedBody = new List<Body>();
    foreach (var bodyLiteral in Body)
    {
      appliedBody.Add(bodyLiteral.Apply(substitutions));
    }
    return new ProgramRule(appliedHead, appliedBody);
  }

  /// <summary>
  /// Checks if either the head or the body has variables
  /// </summary>
  /// <returns>If Either Head or body has variables</returns>
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

  /// <summary>
  /// Checks if either head or body have a spcefic variable.
  /// </summary>
  /// <param name="variable">The specific variable you want to check</param>
  /// <returns>If the varable is either inside the head or body.</returns>
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

  public override bool Equals(object obj)
  {
    if (obj == null || GetType() != obj.GetType())
    {
      return false;
    }

    ProgramRule p = (ProgramRule)obj;
    return ToString() == p.ToString();
  }

  public override int GetHashCode()
  {
    return ToString().GetHashCode();
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