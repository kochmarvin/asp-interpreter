namespace Interpreter.Lib.Results.Objects.Terms;

public class Number(int value) : Term
{
  public int Value { get; } = value;
  public override string ToString()
  {
    return Value.ToString();
  }

}