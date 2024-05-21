using Interpreter.Lib.Results.Objects.BodyLiterals;

public class IsCommentLiteralVisitor : LiteralVisitor<bool>
{
  public override bool Visit(LiteralBody literalBody)
  {
    ArgumentNullException.ThrowIfNull(literalBody, "Is not supposed to be null");

    return literalBody.Literal.Accept(this);
  }

  public override bool Visit(CommentLiteral commentLiteral)
  {
    ArgumentNullException.ThrowIfNull(commentLiteral, "Is not supposed to be null");

    return true;
  }
}