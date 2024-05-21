using Interpreter.Lib.Results.Objects.Terms;

public class IsNumberVisitor : TermVisitor<bool>
{
  public override bool Visit(Number number)
  {
    ArgumentNullException.ThrowIfNull(number, "Is not supposed to be null");

    return true;
  }
}