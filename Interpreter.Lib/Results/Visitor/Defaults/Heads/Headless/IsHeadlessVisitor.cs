using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Terms;

public class IsHeadlessVisitor : HeadVisitor<bool>
{
  public override bool Visit(Headless headless)
  {
    ArgumentNullException.ThrowIfNull(headless, "Is not supposed to be null");

    return true;
  }
}