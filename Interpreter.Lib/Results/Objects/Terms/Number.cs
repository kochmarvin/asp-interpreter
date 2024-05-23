//-----------------------------------------------------------------------
// <copyright file="Number.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// The term of a number e.g. 1.
/// </summary>
public class Number : Term
{
  /// <summary>
  /// Initializes a new instance of the <see cref="Number"/> class.
  /// </summary>
  /// <param name="value">The value of the number.</param>
  public Number(int value)
  {
    this.Value = value;
  }

  /// <summary>
  /// Gets the value of the number.
  /// </summary>
  public int Value
  {
    get;
    private set;
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
  /// <returns>Returns empyt list because number has no vars.</returns>
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
  /// Checks if there are any matches for another object and the substititions.
  /// </summary>
  /// <param name="other">The other object to match it.</param>
  /// <param name="substitutions">The found subsitituions.</param>
  /// <returns>Either if it was a match or not.</returns>
  public override bool Match(Term other, Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(other, "Is not supposed to be null");

    try
    {
      Number parsed = other.Accept(new ParseNumberVisitor()) ?? throw new InvalidOperationException("Trying to compare something else with a number");
      return this.Value == parsed.Value;
    }
    catch (InvalidOperationException)
    {
      return false;
    }
  }

  /// <summary>
  /// Accepts an instance of term visitor and executes it, returning a type of T.
  /// </summary>
  /// <typeparam name="T">The type of the object that is excepted.</typeparam>
  /// <param name="visitor">The visitor that is executed.</param>
  /// <returns>The excepted object of type T.</returns>
  public override T? Accept<T>(TermVisitor<T> visitor)
    where T : default
  {
    return visitor.Visit(this);
  }

  /// <summary>
  /// Basic to string method.
  /// </summary>
  /// <returns>The string equivalent.</returns>
  public override string ToString()
  {
    return this.Value.ToString();
  }
}