//-----------------------------------------------------------------------
// <copyright file="LiteralVisitor.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;

/// <summary>
/// Abstract class for visiting different types of literals in a rule.
/// </summary>
/// <typeparam name="T">The type of the result produced by the visitor.</typeparam>
public abstract class LiteralVisitor<T>
{
  /// <summary>
  /// Visits the literal body in a rule.
  /// </summary>
  /// <param name="literalBody">The literal body that is visited.</param>
  /// <returns>The result produced by visiting the literal body.</returns>
  public virtual T? Visit(LiteralBody literalBody) => default;

  /// <summary>
  /// Visits the atom literal in a rule.
  /// </summary>
  /// <param name="atomLiteral">The atom literal that is visited.</param>
  /// <returns>The result produced by visiting the atom literal.</returns>
  public virtual T? Visit(AtomLiteral atomLiteral) => default;

  /// <summary>
  /// Visits the comparison literal in a rule.
  /// </summary>
  /// <param name="comparisonLiteral">The comparison literal that is visited.</param>
  /// <returns>The result produced by visiting the comparison literal.</returns>
  public virtual T? Visit(ComparisonLiteral comparisonLiteral) => default;

  /// <summary>
  /// Visits the is literal in a rule.
  /// </summary>
  /// <param name="isLiteral">The is literal that is visited.</param>
  /// <returns>The result produced by visiting the is literal.</returns>
  public virtual T? Visit(IsLiteral isLiteral) => default;

  /// <summary>
  /// Visits the comment literal in a rule.
  /// </summary>
  /// <param name="commentLiteral">The comment literal that is visited.</param>
  /// <returns>The result produced by visiting the comment literal.</returns>
  public virtual T? Visit(CommentLiteral commentLiteral) => default;
}