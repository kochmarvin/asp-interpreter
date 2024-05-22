//-----------------------------------------------------------------------
// <copyright file="ParseAtomLiteralVisitor.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;

/// <summary>
/// Visitor class to parse and return an AtomLiteral.
/// </summary>
public class ParseAtomLiteralVisitor : LiteralVisitor<AtomLiteral>
{
  /// <summary>
  /// Visits a LiteralBody and returns its contained AtomLiteral.
  /// </summary>
  /// <param name="literalBody">The literalbody that is visited.</param>
  /// <returns>The contained atom literal.</returns>
  /// <exception cref="InvalidOperationException">Thrown if the contained literal is not the right instance.</exception>
  public override AtomLiteral Visit(LiteralBody literalBody)
  {
    return literalBody.Literal.Accept(this) ?? throw new InvalidOperationException("Trying to parse literal which is not the right instance");
  }

  /// <summary>
  /// Visits an AtomLiteral and returns it.
  /// </summary>
  /// <param name="atomLiteral">The AtomLiteral to visit.</param>
  /// <returns>The visited AtomLiteral.</returns>
  public override AtomLiteral Visit(AtomLiteral atomLiteral)
  {
    ArgumentNullException.ThrowIfNull(atomLiteral, "Is not supposed to be null");

    return atomLiteral;
  }
}