using Interpreter.Lib.Results.Enums;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.Literals;

public class ComparisonLiteral(Term left, Relation relation, Term right) : Literal
{
  public Term Left { get; } = left;
  public Relation Reltation { get; } = relation;
  public Term Right { get; } = right;

  public override Literal Apply(Dictionary<string, Term> substitutions)
  {
    Term appliedLeft = Left.Apply(substitutions);
    Term appliedRight = Right.Apply(substitutions);
    return new ComparisonLiteral(appliedLeft, Reltation, appliedRight);
  }

  public override List<string> GetVariables()
  {
    return [.. Left.GetVariables(), .. Right.GetVariables()];
  }

  public override bool HasVariables()
  {
    return Left.HasVariables() || Right.HasVariables();
  }

  public override string ToString()
  {
    return $"{Left}{RelationExtensions.ToSymbol(Reltation)}{Right}";
  }
}