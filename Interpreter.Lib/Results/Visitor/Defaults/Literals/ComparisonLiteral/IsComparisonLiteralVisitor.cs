//-----------------------------------------------------------------------
// <copyright file="IsComparisonLiteralVisitor.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;

/// <summary>
/// Visitor class to determine if a literal is an ComparisonLiteral.
/// </summary>
public class IsComparisonLiteralVisitor : LiteralVisitor<bool>
{
  /// <summary>
  /// Visits a LiteralBody and returns whether its contained literal is a ComparisonLiteral.
  /// </summary>
  /// <param name="literalBody">The visited literal body.</param>
  /// <returns>Wether the visited LiteralBody is a ComparisonLiteral.</returns>
  public override bool Visit(LiteralBody literalBody)
  {
    return literalBody.Literal.Accept(this);
  }

  /// <summary>
  /// Visits an ComparisonLiteral and returns true, indicating the literal is an ComparisonLiteral.
  /// </summary>
  /// <param name="comparisonLiteral">The visited ComparisonLiteral.</param>
  /// <returns>Whether the visited Literal is a ComparisonLiteral.</returns>
  public override bool Visit(ComparisonLiteral comparisonLiteral)
  {
    ArgumentNullException.ThrowIfNull(comparisonLiteral, "Is not supposed to be null");

    return true;
  }
}