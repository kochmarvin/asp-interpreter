//-----------------------------------------------------------------------
// <copyright file="IsIsLiteralVisitor.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;

/// <summary>
/// Visitor class to determine if a literal is an IsLiteral.
/// </summary>
public class IsIsLiteralVisitor : LiteralVisitor<bool>
{
  /// <summary>
  /// Visits a LiteralBody and returns whether its contained literal is a IsLiteral.
  /// </summary>
  /// <param name="literalBody">The LiteralBody to be visited.</param>
  /// <returns>Whether the visited literal is an IsLiteral.</returns>
  public override bool Visit(LiteralBody literalBody)
  {
    return literalBody.Literal.Accept(this);
  }

  /// <summary>
  /// Visits a IsLiteral and returns whether its contained literal is a IsLiteral.
  /// </summary>
  /// <param name="isLiteral">The IsLiteral to be visited.</param>
  /// <returns>Whether the visited literal is an IsLiteral.</returns>
  public override bool Visit(IsLiteral isLiteral)
  {
    ArgumentNullException.ThrowIfNull(isLiteral, "Is not supposed to be null");

    return true;
  }
}