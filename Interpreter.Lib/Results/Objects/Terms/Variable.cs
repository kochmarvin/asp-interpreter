
namespace Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// Variable Term, variable is everything so not just X it is also a, b.
/// </summary>
public class Variable : Term
{
  private string name;

  public string Name
  {
    get
    {
      return name;
    }
    private set
    {
      name = value ?? throw new ArgumentNullException(nameof(Name), "Is not supposed to be null");
    }
  }

  public Variable(string name)
  {
    Name = name;
  }

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
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    if (substitutions.TryGetValue(Name, out Term? term))
    {
      return term;
    }

    return this;
  }

  /// <summary>
  /// Checks if the object has a specific variable.
  /// </summary>
  /// <param name="variable">The variable to be checked.</param>
  /// <returns>Either if it includes the variable or not.</returns>
  public override List<string> GetVariables()
  {
    if (HasVariables())
    {
      return [Name];
    }

    return [];
  }

  /// <summary>
  /// Checks if the name starts with uppercase or underscore which is a variable.
  /// </summary>
  /// <returns>Either if there are variables or not.</returns>
  public override bool HasVariables()
  {
    if (string.IsNullOrEmpty(Name))
    {
      return false;
    }

    return char.IsUpper(Name[0]) || Name.StartsWith("_");
  }

  /// <summary>
  /// Checks if the name is a specific variable
  /// </summary>
  /// <param name="variable">The variable to be checked.</param>
  /// <returns>Either if it includes the variable or not.</returns>
  public override bool HasVariables(string variable)
  {
    if (string.IsNullOrEmpty(Name))
    {
      return false;
    }

    return variable.Equals(Name);
  }

  /// <summary>
  /// Checks if there are any matches for another object and the substititions
  /// </summary>
  /// <param name="other">The other object to match it.</param>
  /// <param name="substiutionen">The found subsitituions</param>
  /// <returns>Either if it was a match or not.</returns>
  public override bool Match(Term other, Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(other, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    if (substitutions.TryGetValue(Name, out Term? found))
    {
      var parsedFound = found.Accept(new ParseVariableVisitor()) ?? throw new InvalidOperationException("Trying to match a variable with somehting else");
      var parsedOther = other.Accept(new ParseVariableVisitor()) ?? throw new InvalidOperationException("Trying to match a variable with somehting else");

      return parsedFound.Name == parsedOther.Name;
    }

    if (HasVariables())
    {
      substitutions.Add(Name, other);
    }

    return true;
  }

  /// <summary>
  /// Basic to string method.
  /// </summary>
  /// <returns>The string equivalent.</returns>
  public override string ToString()
  {
    return Name;
  }
}