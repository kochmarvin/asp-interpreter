using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;

public abstract class LiteralVisitor<T>
{
  public virtual T? Visit(LiteralBody literalBody) => default;
  public virtual T? Visit(AtomLiteral atomLiteral) => default;
  public virtual T? Visit(ComparisonLiteral comparisonLiteral) => default;
  public virtual T? Visit(IsLiteral isLiteral) => default;
  public virtual T? Visit(CommentLiteral commentLiteral) => default;
}