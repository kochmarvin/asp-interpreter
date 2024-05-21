using Interpreter.Lib.Results.Objects.Terms;

public class ParseNumberVisitor : TermVisitor<Number>
{
  public override Number Visit(Number number)
  {
    ArgumentNullException.ThrowIfNull(number, "Is not supposed to be null");

    return number;
  }
}