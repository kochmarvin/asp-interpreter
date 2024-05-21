namespace Interpreter.Lib.Results.Objects.Terms;


/// <summary>
/// Function term so a(a(a(a(n)))) a term that looks like this
/// </summary>
/// <param name="name">The name of the term which</param>
/// <param name="arguments">The arguments of the term</param>
public class FunctionTerm(string name, List<Term> arguments) : Term
{
  public string Name { get; } = name;
  public List<Term> Arguments { get; } = arguments;
  public override T? Accept<T>(TermVisitor<T> visitor) where T : default
  {
    return visitor.Visit(this);
  }

  /// <summary>
  /// Applies the substiution to the object.
  /// </summary>
  /// <param name="substitutions">The found subsitituions.</param>
  /// <returns>A new object instance.</returns>
  public override Term Apply(Dictionary<string, Term> substitutions)
  {
    var appliedArgs = Arguments.Select(arg => arg.Apply(substitutions)).ToList();
    return new FunctionTerm(Name, appliedArgs);

  }

  /// <summary>
  /// Returns all the variables of the object as a list.
  /// </summary>
  /// <returns>The available variables as a list.</returns>
  public override List<string> GetVariables()
  {
    return Arguments.SelectMany(term => term.GetVariables()).ToList();
  }

  /// <summary>
  /// Checks if the object has any varibles.
  /// </summary>
  /// <returns>Either if there are variables or not.</returns>
  public override bool HasVariables()
  {
    foreach (var term in Arguments)
    {
      if (term.HasVariables())
      {
        return true;
      }
    }

    return false;
  }

  /// <summary>
  /// Checks if the object has a specific variable.
  /// </summary>
  /// <param name="variable">The variable to be checked.</param>
  /// <returns>Either if it includes the variable or not.</returns>
  public override bool HasVariables(string variable)
  {
    foreach (var term in Arguments)
    {
      if (term.HasVariables(variable))
      {
        return true;
      }
    }

    return false;
  }

  /// <summary>
  /// Checks if there are any matches for another object and the substititions
  /// </summary>
  /// <param name="other">The other object to match it.</param>
  /// <param name="substiutionen">The found subsitituions</param>
  /// <returns>Either if it was a match or not.</returns>
  public override bool Match(Term other, Dictionary<string, Term> substiutionen)
  {
    FunctionTerm converted = (FunctionTerm)other;
    if (Name != converted.Name || Arguments.Count != converted.Arguments.Count)
    {
      return false;
    }

    for (int i = 0; i < Arguments.Count; i++)
    {
      if (!Arguments[i].Match(converted.Arguments[i], substiutionen))
      {
        return false;
      }
    }

    return true;
  }

  /// <summary>
  /// Basic to string method.
  /// </summary>
  /// <returns>The string equivalent.</returns>
  public override string ToString()
  {
    if (Arguments.Count == 0)
    {
      return Name;
    }

    return $"{Name}({string.Join(", ", Arguments)})";
  }
}