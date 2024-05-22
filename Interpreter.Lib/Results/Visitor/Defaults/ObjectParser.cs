//-----------------------------------------------------------------------
// <copyright file="ObjectParser.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

/// <summary>
/// A class providing various visitor instances for parsing different aspects of heads and literals.
/// </summary>
public class ObjectParser : IObjectParser
{
  /// <summary>
  /// Gets the visitor instance to parse headless objects.
  /// </summary>
  public ParseHeadlessVisitor ParseHeadlessVisitor { get; } = new();

  /// <summary>
  /// Gets the visitor instance to parse choice head objects.
  /// </summary>
  public ParseChoiceHeadVisitor ParseChoiceHeadVisitor { get; } = new();

  /// <summary>
  /// Gets the visitor instance to parse atom head objects.
  /// </summary>
  public ParseAtomHeadVisitor ParseAtomHeadVisitor { get; } = new();

  /// <summary>
  /// Gets the visitor instance to parse atom literal objects.
  /// </summary>
  public ParseAtomLiteralVisitor ParseAtomLiteralVisitor { get; } = new();

  /// <summary>
  /// Gets the visitor instance to parse comment literal objects.
  /// </summary>
  public ParseCommentLiteralVisitor ParseCommentLiteralVisitor { get; } = new();

  /// <summary>
  /// Gets the visitor instance to parse comparison literal objects.
  /// </summary>
  public ParseComparisonLiteralVisitor ParseComparisonLiteralVisitor { get; } = new();

  /// <summary>
  /// Gets the visitor instance to parse is literal objects.
  /// </summary>
  public ParseIsLiteralVisitor ParseIsLiteralVisitor { get; } = new();

  /// <summary>
  /// Gets the visitor instance to parse number objects.
  /// </summary>
  public ParseNumberVisitor ParseNumberVisitor { get; } = new();

  /// <summary>
  /// Gets the visitor instance to parse functional objects.
  /// </summary>
  public ParseFunctionalVisitor ParseFunctionalVisitor { get; } = new();

  /// <summary>
  /// Gets the visitor instance to parse variable objects.
  /// </summary>
  public ParseVariableVisitor ParseVariableVisitor { get; } = new();
}