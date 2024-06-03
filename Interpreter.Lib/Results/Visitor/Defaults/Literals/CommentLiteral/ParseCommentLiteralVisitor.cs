//-----------------------------------------------------------------------
// <copyright file="ParseCommentLiteralVisitor.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.BodyLiterals;

/// <summary>
/// Visitor class to parse and return an CommentLiteral.
/// </summary>
public class ParseCommentLiteralVisitor : LiteralVisitor<CommentLiteral>
{
  /// <summary>
  /// Visits a LiteralBody and returns its contained CommentLiteral.
  /// </summary>
  /// <param name="literalBody">The LiteralBody that is visited.</param>
  /// <returns>The parsed CommentLiteral.</returns>
  /// <exception cref="InvalidOperationException">Thrown if the contained literal is not the right instance.</exception>
  public override CommentLiteral Visit(LiteralBody literalBody)
  {
    return literalBody.Literal.Accept(this) ?? throw new InvalidOperationException("Trying to parse literal which is not the right instance");
  }

  /// <summary>
  /// Visits a CommentLiteral and returns its contained CommentLiteral.
  /// </summary>
  /// <param name="commentLiteral">The CommentLiteral that is visited.</param>
  /// <returns>The parsed CommentLiteral.</returns>
  public override CommentLiteral Visit(CommentLiteral commentLiteral)
  {
    ArgumentNullException.ThrowIfNull(commentLiteral, "Is not supposed to be null");

    return commentLiteral;
  }
}