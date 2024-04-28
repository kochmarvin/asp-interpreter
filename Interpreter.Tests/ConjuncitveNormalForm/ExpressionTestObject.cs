using static Interpreter.FunctionalLib.ConjunctiveNormalForm;

namespace Interpreter.Tests;

public class ExpressionTestObject(Expression expression, List<List<int>> expected)
{
  public Expression Expression { get; set; } = expression;
  public List<List<int>> Expected { get; set; } = expected;
}