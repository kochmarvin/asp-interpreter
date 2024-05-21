using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Terms;

public class IsChoiceHeadVisitor : HeadVisitor<bool>
{
  public override bool Visit(ChoiceHead choiceHead)
  {
    ArgumentNullException.ThrowIfNull(choiceHead, "Is not supposed to be null");

    return true;
  }
}