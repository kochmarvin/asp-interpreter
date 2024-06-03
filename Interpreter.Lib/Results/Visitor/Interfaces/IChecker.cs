//-----------------------------------------------------------------------
// <copyright file="IChecker.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

/// <summary>
/// An interface defining properties for various visitor instances used to check different types of literals.
/// </summary>
public interface IChecker
{
  /// <summary>
  /// Gets the visitor instance to check atom head objects.
  /// </summary>
  public IsAtomHeadVisitor IsAtomHeadVisitor { get; }

  /// <summary>
  /// Gets the visitor instance to check headless objects.
  /// </summary>
  public IsHeadlessVisitor IsHeadlessVisitor { get; }

  /// <summary>
  /// Gets the visitor instance to check choice head objects.
  /// </summary>
  public IsChoiceHeadVisitor IsChoiceHeadVisitor { get; }

  /// <summary>
  /// Gets the visitor instance to check atom literal objects.
  /// </summary>
  public IsAtomLiteralVisitor IsAtomLiteralVisitor { get; }

  /// <summary>
  /// Gets the visitor instance to check is literal objects.
  /// </summary>
  public IsIsLiteralVisitor IsIsLiteralVisitor { get; }

  /// <summary>
  /// Gets the visitor instance to check comparison literal objects.
  /// </summary>
  public IsComparisonLiteralVisitor IsComparisonLiteralVisitor { get; }

  /// <summary>
  /// Gets the visitor instance to check comment literal objects.
  /// </summary>
  public IsCommentLiteralVisitor IsCommentLiteralVisitor { get; }

  /// <summary>
  /// Gets the visitor instance to check functional objects.
  /// </summary>
  public IsFunctionalVisitor IsFunctionalVisitor { get; }

  /// <summary>
  /// Gets the visitor instance to check variable objects.
  /// </summary>
  public IsVariableVisitor IsVariableVisitor { get; }

  /// <summary>
  /// Gets the visitor instance to check number objects.
  /// </summary>
  public IsNumberVisitor IsNumberVisitor { get; }
}