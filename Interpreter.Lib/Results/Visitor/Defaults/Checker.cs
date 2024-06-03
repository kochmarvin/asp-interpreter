//-----------------------------------------------------------------------
// <copyright file="Checker.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

/// <summary>
/// A checker containing various visitor instances for checking different aspects of literals in the code.
/// </summary>
public class Checker : IChecker
{
  /// <summary>
  /// Gets the visitor instance to check if a head is an atom head.
  /// </summary>
  public IsAtomHeadVisitor IsAtomHeadVisitor { get; } = new();

  /// <summary>
  /// Gets the visitor instance to check if a head is headless.
  /// </summary>
  public IsHeadlessVisitor IsHeadlessVisitor { get; } = new();

  /// <summary>
  /// Gets the visitor instance to check if a head is a choice head.
  /// </summary>
  public IsChoiceHeadVisitor IsChoiceHeadVisitor { get; } = new();

  /// <summary>
  /// Gets the visitor instance to check if a literal is an atom literal.
  /// </summary>
  public IsAtomLiteralVisitor IsAtomLiteralVisitor { get; } = new();

  /// <summary>
  /// Gets the visitor instance to check if a literal is an is literal.
  /// </summary>
  public IsIsLiteralVisitor IsIsLiteralVisitor { get; } = new();

  /// <summary>
  /// Gets the visitor instance to check if a literal is a comparison literal.
  /// </summary>
  public IsComparisonLiteralVisitor IsComparisonLiteralVisitor { get; } = new();

  /// <summary>
  /// Gets the visitor instance to check if a literal is a comment literal.
  /// </summary>
  public IsCommentLiteralVisitor IsCommentLiteralVisitor { get; } = new();

  /// <summary>
  /// Gets the visitor instance to check if a term is functional.
  /// </summary>
  public IsFunctionalVisitor IsFunctionalVisitor { get; } = new();

  /// <summary>
  /// Gets the visitor instance to check if a term is a variable.
  /// </summary>
  public IsVariableVisitor IsVariableVisitor { get; } = new();

  /// <summary>
  /// Gets the visitor instance to check if a term is a number.
  /// </summary>
  public IsNumberVisitor IsNumberVisitor { get; } = new();
}