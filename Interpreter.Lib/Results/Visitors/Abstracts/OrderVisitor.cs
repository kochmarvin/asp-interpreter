using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;

namespace Interpreter.Lib.Results.Vistors;

public abstract class OrderVisitor : ILiteralOrder, IBodyOrder
{
  public abstract int Order(AtomLiteral atomLiteral);
  public abstract int Order(LiteralBody literalBody);
  public abstract int Order(IsLiteral atomLiteral);
  public abstract int Order(CommentLiteral atomLiteral);
  public abstract int Order(ComparisonLiteral atomLiteral);
}