//-----------------------------------------------------------------------
// <copyright file="ParseComparisonLiteralVisitor.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;

/// <summary>
/// Visitor class to parse and return an ComparisonLiteral.
/// </summary>
public class ParseComparisonLiteralVisitor : LiteralVisitor<ComparisonLiteral>
{
  /// <summary>
  /// Visits a LiteralBody and returns its contained ComparisonLiteral.
  /// </summary>
  /// <param name="literalBody">The LiteralBody that is visited.</param>
  /// <returns>The parsed ComparisonLiteral.</returns>
  /// <exception cref="InvalidOperationException">Thrown if the contained literal is not the right instance.</exception>
  public override ComparisonLiteral Visit(LiteralBody literalBody)
  {
    return literalBody.Literal.Accept(this) ?? throw new InvalidOperationException("Trying to parse literal which is not the right instance");
  }

  /// <summary>
  /// Visits a ComparisonLiteral and returns its contained ComparisonLiteral.
  /// </summary>
  /// <param name="comparisonLiteral">The ComparisonLiteral that is visited.</param>
  /// <returns>The parsed ComparisonLiteral.</returns>
  public override ComparisonLiteral Visit(ComparisonLiteral comparisonLiteral)
  {
    ArgumentNullException.ThrowIfNull(comparisonLiteral, "Is not supposed to be null");

    return comparisonLiteral;
  }
}