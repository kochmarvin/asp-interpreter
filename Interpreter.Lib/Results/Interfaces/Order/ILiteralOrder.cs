using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;

namespace Interpreter.Lib.Results.Interfaces;

/// <summary>
/// Interface to get the order integer of a specific literal
/// </summary>
public interface ILiteralOrder
{
  int Order(AtomLiteral atomLiteral);
  int Order(IsLiteral atomLiteral);
  int Order(CommentLiteral atomLiteral);
  int Order(ComparisonLiteral atomLiteral);
}