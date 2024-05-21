using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Terms;

public class ParseHeadlessVisitor : HeadVisitor<Headless>
{
  public override Headless Visit(Headless headless)
  {
    ArgumentNullException.ThrowIfNull(headless, "Is not supposed to be null");

    return headless;
  }
}