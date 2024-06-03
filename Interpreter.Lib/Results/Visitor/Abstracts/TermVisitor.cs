//-----------------------------------------------------------------------
// <copyright file="TermVisitor.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// Abstract class for visiting different types of terms in a rule.
/// </summary>
/// <typeparam name="T">The type of the result produced by the visitor.</typeparam>
public abstract class TermVisitor<T>
{
  /// <summary>
  /// Visits the number in a rule.
  /// </summary>
  /// <param name="number">The number that is visited.</param>
  /// <returns>The result produced by visiting the number.</returns>
  public virtual T? Visit(Number number) => default;

  /// <summary>
  /// Visits the variable in a rule.
  /// </summary>
  /// <param name="variable">The variable that is visited.</param>
  /// <returns>The result produced by visiting the variable.</returns>
  public virtual T? Visit(Variable variable) => default;

  /// <summary>
  /// Visits the funtion term in a rule.
  /// </summary>
  /// <param name="functionTerm">The funtion term that is visited.</param>
  /// <returns>The result produced by visiting the function term.</returns>
  public virtual T? Visit(FunctionTerm functionTerm) => default;
}