//-----------------------------------------------------------------------
// <copyright file="IsCommentLiteralVisitor.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.BodyLiterals;

/// <summary>
/// Visitor class to determine if a literal is an CommentLiteral.
/// </summary>
public class IsCommentLiteralVisitor : LiteralVisitor<bool>
{
  /// <summary>
  /// Visits a LiteralBody and returns whether its contained literal is a LiteralBody.
  /// </summary>
  /// <param name="literalBody">The visited LiteralBody.</param>
  /// <returns>Whether the literal is a LiteralBody.</returns>
  public override bool Visit(LiteralBody literalBody)
  {
    ArgumentNullException.ThrowIfNull(literalBody, "Is not supposed to be null");

    return literalBody.Literal.Accept(this);
  }

  /// <summary>
  /// Visits an CommentLiteral and returns true, indicating the literal is an CommentLiteral.
  /// </summary>
  /// <param name="commentLiteral">The visited CommentLiteral.</param>
  /// <returns>Whether the literal is a CommentLiteral.</returns>
  public override bool Visit(CommentLiteral commentLiteral)
  {
    ArgumentNullException.ThrowIfNull(commentLiteral, "Is not supposed to be null");

    return true;
  }
}