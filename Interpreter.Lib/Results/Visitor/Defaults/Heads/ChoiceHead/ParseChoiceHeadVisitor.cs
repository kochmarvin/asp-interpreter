using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Terms;

public class ParseChoiceHeadVisitor : HeadVisitor<ChoiceHead>
{
  public override ChoiceHead Visit(ChoiceHead choiceHead)
  {
    ArgumentNullException.ThrowIfNull(choiceHead, "Is not supposed to be null");

    return choiceHead;
  }
}