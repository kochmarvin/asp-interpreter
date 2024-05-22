//-----------------------------------------------------------------------
// <copyright file="GrounderCleanUpVisitor.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;

/// <summary>
/// A visitor class for cleaning up literals after the grounding process.
/// </summary>
public class GrounderCleanUpVisitor : LiteralVisitor<bool>
{
  /// <summary>
  /// Visits a literal body object and determines if it should be kept.
  /// </summary>
  /// <param name="literalBody">Tha literal body that is to be visited.</param>
  /// <returns>True if the literal body should be kept.</returns>
  public override bool Visit(LiteralBody literalBody)
  {
    ArgumentNullException.ThrowIfNull(literalBody, "Is not supposed to be null");

    return literalBody.Literal.Accept(this);
  }

  /// <summary>
  /// Visits a atom literal object and determines if it should be kept.
  /// </summary>
  /// <param name="atomLiteral">The atom literal that is to be visited.</param>
  /// <returns>True if the atom literal should be kept.</returns>
  public override bool Visit(AtomLiteral atomLiteral)
  {
    ArgumentNullException.ThrowIfNull(atomLiteral, "Is not supposed to be null");

    return atomLiteral.Positive;
  }
}