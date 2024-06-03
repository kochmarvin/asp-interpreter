//-----------------------------------------------------------------------
// <copyright file="TransformToAtomLiteralVisitor.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;

/// <summary>
/// A visitor class for transforming different types of literals into AtomLiterals.
/// </summary>
public class TransformToAtomLiteralVisitor : LiteralVisitor<AtomLiteral>
{
  /// <summary>
  /// Visits a literal body and tries to transform it into an atom literal.
  /// </summary>
  /// <param name="literalBody">The literal body that is to be transformed.</param>
  /// <returns>The transformed atom literal.</returns>
  /// <exception cref="InvalidOperationException">Is thrown if trying to transform a literal that can not be transformed into an atom literal.</exception>
  public override AtomLiteral Visit(LiteralBody literalBody)
  {
    ArgumentNullException.ThrowIfNull(literalBody, "Is not supposed to be null");

    return literalBody.Literal.Accept(this) ?? throw new InvalidOperationException("You are trying to transform a Atom Literal which is none");
  }

  /// <summary>
  /// Visits an atom literal into an atom literal.
  /// </summary>
  /// <param name="atomLiteral">The atom literal that is to be transformed.</param>
  /// <returns>The transformed atom literal.</returns>
  public override AtomLiteral Visit(AtomLiteral atomLiteral)
  {
    ArgumentNullException.ThrowIfNull(atomLiteral, "Is not supposed to be null");

    return atomLiteral;
  }
}