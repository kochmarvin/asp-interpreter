namespace Interpreter.Lib.Results.Enums;

public static class OperatorExtension
{
  public static string ToSymbol(this Operator relation)
  {
    return relation switch
    {
      Operator.PLUS => "+",
      Operator.MINUS => "-",
      Operator.DIVIDE => "/",
      Operator.MULTIPLY => "*",
      _ => throw new NotImplementedException()
    };
  }
}