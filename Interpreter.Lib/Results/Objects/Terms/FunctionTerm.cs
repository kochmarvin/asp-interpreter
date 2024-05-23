//-----------------------------------------------------------------------
// <copyright file="FunctionTerm.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// Function term so a(a(a(a(n)))) a term that looks like this.
/// </summary>
public class FunctionTerm : Term
{
  private string name;
  private List<Term> arguments;

  /// <summary>
  /// Initializes a new instance of the <see cref="FunctionTerm"/> class.
  /// </summary>
  /// <param name="name">The name of the function term.</param>
  /// <param name="arguments">All of the terms of this function term.</param>
  public FunctionTerm(string name, List<Term> arguments)
  {
    this.Name = name;
    this.Arguments = arguments;
  }

  /// <summary>
  /// Gets the name of the function term.
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
  /// Gets the list of arguments of the funtion term.
  /// </summary>
  public List<Term> Arguments
  {
    get
    {
      return this.arguments;
    }

    private set
    {
      this.arguments = value ?? throw new ArgumentNullException(nameof(this.Arguments), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Accepts an instance of teerm visitor and executes it, returning a type of T.
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

    var appliedArgs = this.Arguments.Select(arg => arg.Apply(substitutions)).ToList();
    return new FunctionTerm(this.Name, appliedArgs);
  }

  /// <summary>
  /// Returns all the variables of the object as a list.
  /// </summary>
  /// <returns>The available variables as a list.</returns>
  public override List<string> GetVariables()
  {
    return this.Arguments.SelectMany(term => term.GetVariables()).ToList();
  }

  /// <summary>
  /// Checks if the object has any varibles.
  /// </summary>
  /// <returns>Either if there are variables or not.</returns>
  public override bool HasVariables()
  {
    foreach (var term in this.Arguments)
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
    foreach (var term in this.Arguments)
    {
      if (term.HasVariables(variable))
      {
        return true;
      }
    }

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
    ArgumentNullException.ThrowIfNull(other, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    try
    {
      FunctionTerm converted = other.Accept(new ParseFunctionalVisitor()) ?? throw new InvalidOperationException("Trying to compare a functional term with something else");
      if (this.Name != converted.Name || this.Arguments.Count != converted.Arguments.Count)
      {
        return false;
      }

      for (int i = 0; i < this.Arguments.Count; i++)
      {
        if (!this.Arguments[i].Match(converted.Arguments[i], substitutions))
        {
          return false;
        }
      }

      return true;
    }
    catch (InvalidOperationException)
    {
      return false;
    }
  }

  /// <summary>
  /// Basic to string method.
  /// </summary>
  /// <returns>The string equivalent.</returns>
  public override string ToString()
  {
    if (this.Arguments.Count == 0)
    {
      return this.Name;
    }

    return $"{this.Name}({string.Join(", ", this.Arguments)})";
  }
}