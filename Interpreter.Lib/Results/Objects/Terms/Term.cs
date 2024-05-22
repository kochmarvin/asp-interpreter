//-----------------------------------------------------------------------
// <copyright file="Term.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Objects.Terms;

using Interpreter.Lib.Results.Interfaces;

/// <summary>
/// Abstract class of the smallest Unit a rule can have.
/// </summary>
public abstract class Term : IMatch<Term>, IApplier<Term>, IHasVariables, IGetVariables, ITermAccept
{
  /// <summary>
  /// Applies the substiution to the object.
  /// </summary>
  /// <param name="substitutions">The found subsitituions.</param>
  /// <returns>A new object instance.</returns>
  public abstract Term Apply(Dictionary<string, Term> substitutions);

  /// <summary>
  /// Checks if there are any matches for another object and the substititions.
  /// </summary>
  /// <param name="other">The other object to match it.</param>
  /// <param name="substiutionen">The found subsitituions.</param>
  /// <returns>Either if it was a match or not.</returns>
  public abstract bool Match(Term other, Dictionary<string, Term> substiutionen);

  /// <summary>
  /// Basic to string method.
  /// </summary>
  /// <returns>The string equivalent.</returns>
  public override string? ToString()
  {
    return base.ToString();
  }

  /// <summary>
  /// Checks if the object has any varibles.
  /// </summary>
  /// <returns>Either if there are variables or not.</returns>
  public abstract bool HasVariables();

  /// <summary>
  /// Checks if the object has a specific variable.
  /// </summary>
  /// <param name="variable">The variable to be checked.</param>
  /// <returns>Either if it includes the variable or not.</returns>
  public abstract bool HasVariables(string variable);

  /// <summary>
  /// Returns all the variables of the object as a list.
  /// </summary>
  /// <returns>The available variables.</returns>
  public abstract List<string> GetVariables();

  /// <summary>
  /// Accepts an instance of term visitor and executes it, returning a type of T.
  /// </summary>
  /// <typeparam name="T">The type of the object that is excepted.</typeparam>
  /// <param name="visitor">The visitor that is executed.</param>
  /// <returns>The excepted object of type T.</returns>
  public abstract T? Accept<T>(TermVisitor<T> visitor);
}