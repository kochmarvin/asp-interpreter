using Interpreter.Lib.Results.Objects.Terms;

public class IsFunctionalVisitor : TermVisitor<bool>
{
  public override bool Visit(FunctionTerm functionTerm)
  {
    ArgumentNullException.ThrowIfNull(functionTerm, "Is not supposed to be null");

    return true;
  }
}