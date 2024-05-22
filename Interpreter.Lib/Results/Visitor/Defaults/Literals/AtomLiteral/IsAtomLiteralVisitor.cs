//-----------------------------------------------------------------------
// <copyright file="IsAtomLiteralVisitor.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;

/// <summary>
/// Visitor class to determine if a literal is an AtomLiteral.
/// </summary>
public class IsAtomLiteralVisitor : LiteralVisitor<bool>
{
  /// <summary>
  /// Visits a LiteralBody and returns whether its contained literal is an AtomLiteral.
  /// </summary>
  /// <param name="literalBody">The LiteralBody to visit.</param>
  /// <returns>Whether the contained literal is an AtomLiteral.</returns>
  public override bool Visit(LiteralBody literalBody)
  {
    return literalBody.Literal.Accept(this);
  }

  /// <summary>
  /// Visits an AtomLiteral and returns true, indicating the literal is an AtomLiteral.
  /// </summary>
  /// <param name="atomLiteral">The AtomLiteral to visit.</param>
  /// <returns>Whether the literal is an AtomLiteral.</returns>
  public override bool Visit(AtomLiteral atomLiteral)
  {
    ArgumentNullException.ThrowIfNull(atomLiteral, "Is not supposed to be null");

    return true;
  }
}