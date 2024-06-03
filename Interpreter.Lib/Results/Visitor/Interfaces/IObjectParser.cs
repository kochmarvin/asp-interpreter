//-----------------------------------------------------------------------
// <copyright file="IObjectParser.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

/// <summary>
/// An interface defining properties for various visitor instances used to parse different types of literals.
/// </summary>
public interface IObjectParser
{
  /// <summary>
  /// Gets the visitor instance to parse headless objects.
  /// </summary>
  public ParseHeadlessVisitor ParseHeadlessVisitor { get; }

  /// <summary>
  /// Gets the visitor instance to parse choice head objects.
  /// </summary>
  public ParseChoiceHeadVisitor ParseChoiceHeadVisitor { get; }

  /// <summary>
  /// Gets the visitor instance to parse atom head objects.
  /// </summary>
  public ParseAtomHeadVisitor ParseAtomHeadVisitor { get; }

  /// <summary>
  /// Gets the visitor instance to parse atom literal objects.
  /// </summary>
  public ParseAtomLiteralVisitor ParseAtomLiteralVisitor { get; }

  /// <summary>
  /// Gets the visitor instance to parse comment literal objects.
  /// </summary>
  public ParseCommentLiteralVisitor ParseCommentLiteralVisitor { get; }

  /// <summary>
  /// Gets the visitor instance to parse comparison literal objects.
  /// </summary>
  public ParseComparisonLiteralVisitor ParseComparisonLiteralVisitor { get; }

  /// <summary>
  /// Gets the visitor instance to parse is literal objects.
  /// </summary>
  public ParseIsLiteralVisitor ParseIsLiteralVisitor { get; }

  /// <summary>
  /// Gets the visitor instance to parse number objects.
  /// </summary>
  public ParseNumberVisitor ParseNumberVisitor { get; }

  /// <summary>
  /// Gets the visitor instance to parse functional objects.
  /// </summary>
  public ParseFunctionalVisitor ParseFunctionalVisitor { get; }

  /// <summary>
  /// Gets the visitor instance to parse variable objects.
  /// </summary>
  public ParseVariableVisitor ParseVariableVisitor { get; }
}