using Interpreter.Lib.Results.Enums;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.Literals;

public class IsLiteral(Variable newVar, Term left, Operator op, Term right) : Literal
{
  public Variable New { get; } = newVar;
  public Term Left { get; } = left;
  public Operator Operator { get; } = op;
  public Term Right { get; } = right;

  public override Literal Apply(Dictionary<string, Term> substitutions)
  {
    Term appliedLeft = Left.Apply(substitutions);
    Term appliedRight = Right.Apply(substitutions);
    return new IsLiteral(New, appliedLeft, Operator, appliedRight);
  }

  public override List<string> GetVariables()
  {
    return [.. Left.GetVariables(), .. Right.GetVariables()];
  }

  public override bool HasVariables()
  {
    return Left.HasVariables() || Right.HasVariables();
  }

  public override bool HasVariables(string variable)
  {
    return Left.HasVariables(variable) || Right.HasVariables(variable);
  }

  public override string ToString()
  {
    return $"{New} is {Left}{OperatorExtension.ToSymbol(Operator)}{Right}";
  }
}