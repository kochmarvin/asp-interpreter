//-----------------------------------------------------------------------
// <copyright file="ParseIsLiteralVisitor.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;

/// <summary>
/// Visitor class to parse and return an IsLiteral.
/// </summary>
public class ParseIsLiteralVisitor : LiteralVisitor<IsLiteral>
{
  /// <summary>
  /// Visits a LiteralBody and returns its contained IsLiteral.
  /// </summary>
  /// <param name="literalBody">The LiteralBody that is visited.</param>
  /// <returns>The parsed IsLiteral.</returns>
  /// <exception cref="InvalidOperationException">Thrown if the contained literal is not the right instance.</exception>
  public override IsLiteral Visit(LiteralBody literalBody)
  {
    return literalBody.Literal.Accept(this) ?? throw new InvalidOperationException("Trying to parse literal which is not the right instance");
  }

  /// <summary>
  /// Visits a IsLiteral and returns its contained IsLiteral.
  /// </summary>
  /// <param name="isLiteral">The IsLiteral that is visited.</param>
  /// <returns>The parsed IsLiteral.</returns>
  public override IsLiteral Visit(IsLiteral isLiteral)
  {
    ArgumentNullException.ThrowIfNull(isLiteral, "Is not supposed to be null");

    return isLiteral;
  }
}