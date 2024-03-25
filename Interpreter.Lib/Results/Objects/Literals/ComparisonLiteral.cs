using Interpreter.Lib.Results.Enums;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.Literals;

public class ComparisonLiteral(Term left, Relation relation, Term right) : Literal
{
  public Term Left { get; } = left;
  public Relation Reltation { get; } = relation;
  public Term Right { get; } = right;

  public override string ToString()
  {
    return $"{Left}{RelationExtensions.ToSymbol(Reltation)}{Right}";
  }
}