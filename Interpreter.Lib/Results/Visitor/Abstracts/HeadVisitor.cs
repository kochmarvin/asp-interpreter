//-----------------------------------------------------------------------
// <copyright file="HeadVisitor.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.HeadLiterals;

/// <summary>
/// Abstract class for visiting different types of heads in a rule.
/// </summary>
/// <typeparam name="T">The type of the result produced by the visitor.</typeparam>
public abstract class HeadVisitor<T>
{
  /// <summary>
  /// Visits a headless rule head.
  /// </summary>
  /// <param name="headless">The headless rule head that is visited.</param>
  /// <returns>The result produced by visiting the headless rule head.</returns>
  public virtual T? Visit(Headless headless) => default;

  /// <summary>
  /// Visits the choice rule head.
  /// </summary>
  /// <param name="choiceHead">The choice rule head that is visited.</param>
  /// <returns>The result produced by visiting the choice rule head.</returns>
  public virtual T? Visit(ChoiceHead choiceHead) => default;

  /// <summary>
  /// Visits the atom rule head.
  /// </summary>
  /// <param name="atomHead">The atom rule head that is visited.</param>
  /// <returns>The result produced by visiting the atom rule head.</returns>
  public virtual T? Visit(AtomHead atomHead) => default;
}