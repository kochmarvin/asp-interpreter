using Interpreter.FunctionalLib;

namespace Interpreter.Lib.Solver;

public class CNFWrapper
{

  private ConjunctiveNormalForm.Expression? _expression;

  private CNFWrapper()
  {
    _expression = null;
  }

  public static CNFWrapper NewExpression()
  {
    return new CNFWrapper();
  }

  public static ConjunctiveNormalForm.Expression CreateNegativeVariable(int index)
  {
    return ConjunctiveNormalForm.Expression.NewNot(CreateVariable(index));
  }

  public static ConjunctiveNormalForm.Expression CreateNegativeVariable(ConjunctiveNormalForm.Expression variable)
  {
    return ConjunctiveNormalForm.Expression.NewNot(variable);
  }

  public static ConjunctiveNormalForm.Expression CreateVariable(int index)
  {
    return ConjunctiveNormalForm.Expression.NewVar(index);
  }

  public CNFWrapper SetXor(ConjunctiveNormalForm.Expression left, ConjunctiveNormalForm.Expression right)
  {
    _expression = ConjunctiveNormalForm.Expression.NewXor(left, right);
    return this;
  }

  public CNFWrapper SetOr(ConjunctiveNormalForm.Expression left, ConjunctiveNormalForm.Expression right)
  {
    _expression = ConjunctiveNormalForm.Expression.NewOr(left, right);
    return this;
  }

  public CNFWrapper SetAnd(ConjunctiveNormalForm.Expression left, ConjunctiveNormalForm.Expression right)
  {
    _expression = ConjunctiveNormalForm.Expression.NewAnd(left, right);
    return this;
  }

  public CNFWrapper AddOr(ConjunctiveNormalForm.Expression single)
  {
    _expression = ConjunctiveNormalForm.Expression.NewOr(_expression, single);
    return this;
  }

  public CNFWrapper AddAnd(ConjunctiveNormalForm.Expression single)
  {
    _expression = ConjunctiveNormalForm.Expression.NewAnd(_expression, single);
    return this;
  }

  public CNFWrapper SetImplication(ConjunctiveNormalForm.Expression left, ConjunctiveNormalForm.Expression right)
  {
    _expression = ConjunctiveNormalForm.Expression.NewImplies(left, right);
    return this;
  }

  public CNFWrapper SetEquality(ConjunctiveNormalForm.Expression left, ConjunctiveNormalForm.Expression right)
  {
    _expression = ConjunctiveNormalForm.Expression.NewEquiv(left, right);
    return this;
  }

  public ConjunctiveNormalForm.Expression Create()
  {
    if (_expression == null)
    {
      throw new InvalidOperationException("You are trying to create an empty formula, which is not allowed");
    }

    return _expression;
  }

}