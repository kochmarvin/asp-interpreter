//-----------------------------------------------------------------------
// <copyright file="Variable.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// Variable Term, variable is everything so not just X it is also a, b.
/// </summary>
public class Variable : Term
{
  private string name;

  /// <summary>
  /// Initializes a new instance of the <see cref="Variable"/> class.
  /// </summary>
  /// <param name="name">The name of the variable.</param>
  public Variable(string name)
  {
    this.Name = name;
  }

  /// <summary>
  /// Gets the name of the variable.
  /// </summary>
  public string Name
  {
    get
    {
      return this.name;
    }

    private set
    {
      this.name = value ?? throw new ArgumentNullException(nameof(this.Name), "Is not supposed to be null");
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
  /// Applies the substiution to the object.
  /// </summary>
  /// <param name="substitutions">The found subsitituions.</param>
  /// <returns>A new object instance.</returns>
  public override Term Apply(Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    if (substitutions.TryGetValue(this.Name, out Term? term))
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
    if (this.HasVariables())
    {
      return [this.Name];
    }

    return [];
  }

  /// <summary>
  /// Checks if the name starts with uppercase or underscore which is a variable.
  /// </summary>
  /// <returns>Either if there are variables or not.</returns>
  public override bool HasVariables()
  {
    if (string.IsNullOrEmpty(this.Name))
    {
      return false;
    }

    return char.IsUpper(this.Name[0]) || this.Name.StartsWith("_");
  }

  /// <summary>
  /// Checks if the name is a specific variable.
  /// </summary>
  /// <param name="variable">The variable to be checked.</param>
  /// <returns>Either if it includes the variable or not.</returns>
  public override bool HasVariables(string variable)
  {
    if (string.IsNullOrEmpty(this.Name))
    {
      return false;
    }

    return variable.Equals(this.Name);
  }

  /// <summary>
  /// Checks if there are any matches for another object and the substititions.
  /// </summary>
  /// <param name="other">The other object to match it.</param>
  /// <param name="substitutions">The found subsitituions.</param>
  /// <returns>Either if it was a match or not.</returns>
  public override bool Match(Term other, Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(other, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    if (substitutions.TryGetValue(this.Name, out Term? found))
    {
      var parsedFound = found.Accept(new ParseVariableVisitor()) ?? throw new InvalidOperationException("Trying to match a variable with somehting else");
      var parsedOther = other.Accept(new ParseVariableVisitor()) ?? throw new InvalidOperationException("Trying to match a variable with somehting else");

      return parsedFound.Name == parsedOther.Name;
    }

    if (this.HasVariables())
    {
      substitutions.Add(this.Name, other);
    }

    return true;
  }

  /// <summary>
  /// Basic to string method.
  /// </summary>
  /// <returns>The string equivalent.</returns>
  public override string ToString()
  {
    return this.Name;
  }
}