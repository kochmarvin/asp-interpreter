//-----------------------------------------------------------------------
// <copyright file="OrderVisitor.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;

/// <summary>
/// A class representing the vistor for ordering literals.
/// </summary>
public class OrderVisitor : LiteralVisitor<int>
{
  /// <summary>
  /// Visits a literal body and returns an integer order based on its content.
  /// </summary>
  /// <param name="literalBody">The literal body that is to be visited.</param>
  /// <returns>The order of the visited literal body.</returns>
  public override int Visit(LiteralBody literalBody)
  {
    ArgumentNullException.ThrowIfNull(literalBody, "Is not supposed to be null");
    return literalBody.Literal.Accept(this);
  }

  /// <summary>
  /// Visits a comment literal and returns an integer order based on its content.
  /// </summary>
  /// <param name="commentLiteral">The comment literal that is to be visited.</param>
  /// <returns>The order of the comment literal.</returns>
  public override int Visit(CommentLiteral commentLiteral)
  {
    ArgumentNullException.ThrowIfNull(commentLiteral, "Is not supposed to be null");

    return 2;
  }

  /// <summary>
  /// Visits an atom literal and returns an integer order based on its content.
  /// </summary>
  /// <param name="atomLiteral">The atom literal that is to be visited.</param>
  /// <returns>The order of the atom literal.</returns>
  public override int Visit(AtomLiteral atomLiteral)
  {
    ArgumentNullException.ThrowIfNull(atomLiteral, "Is not supposed to be null");

    if (atomLiteral.Positive)
    {
      return 0;
    }

    return 1;
  }

  /// <summary>
  /// Visits a comparison literal and returns an integer order based on its content.
  /// </summary>
  /// <param name="comparisonLiteral">The comparison literal that is to be visited.</param>
  /// <returns>The order of the comparison literal.</returns>
  public override int Visit(ComparisonLiteral comparisonLiteral)
  {
    ArgumentNullException.ThrowIfNull(comparisonLiteral, "Is not supposed to be null");

    return 2;
  }

  /// <summary>
  /// Visits an is literal and returns an integer order based on its content.
  /// </summary>
  /// <param name="isLiteral">The is literal that is to be visited.</param>
  /// <returns>The order of the is literal.</returns>
  public override int Visit(IsLiteral isLiteral)
  {
    ArgumentNullException.ThrowIfNull(isLiteral, "Is not supposed to be null");

    return 2;
  }
}