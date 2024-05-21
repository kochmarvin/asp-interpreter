
namespace Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// The term of a number e.g. 1
/// </summary>
public class Number : Term
{
  public int Value
  {
    get;
    private set;
  }

  public Number(int value)
  {
    Value = value;
  }

  /// <summary>
  /// Applies the substiution to the object.
  /// </summary>
  /// <param name="substitutions">The found subsitituions.</param>
  /// <returns>The instance of the object..</returns>
  public override Term Apply(Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    return this;
  }

  /// <summary>
  /// Returns all the variables of the object as a list.
  /// </summary>
  /// <returns>Returns empyt list because number has no vars</returns>
  public override List<string> GetVariables()
  {
    return [];
  }

  /// <summary>
  /// Checks if the object has any varibles.
  /// </summary>
  /// <returns>Always false because number has no variables.</returns>
  public override bool HasVariables()
  {
    return false;
  }

  /// <summary>
  /// Checks if the object has a specific variable.
  /// </summary>
  /// <param name="variable">The variable to be checked.</param>
  /// <returns>Returns always false because number has no variables.</returns>
  public override bool HasVariables(string variable)
  {
    return false;
  }

  /// <summary>
  /// Checks if there are any matches for another object and the substititions
  /// </summary>
  /// <param name="other">The other object to match it.</param>
  /// <param name="substiutionen">The found subsitituions</param>
  /// <returns>Either if it was a match or not.</returns>
  public override bool Match(Term other, Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(other, "Is not supposed to be null");
    
    return Value == ((Number)other).Value;
  }
  public override T? Accept<T>(TermVisitor<T> visitor) where T : default
  {
    return visitor.Visit(this);
  }


  /// <summary>
  /// Basic to string method.
  /// </summary>
  /// <returns>The string equivalent.</returns>

  public override string ToString()
  {
    return Value.ToString();
  }
}