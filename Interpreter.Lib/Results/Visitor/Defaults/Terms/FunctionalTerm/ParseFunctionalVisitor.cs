using Interpreter.Lib.Results.Objects.Terms;

public class ParseFunctionalVisitor : TermVisitor<FunctionTerm>
{
  public override FunctionTerm Visit(FunctionTerm functionTerm)
  {
    ArgumentNullException.ThrowIfNull(functionTerm, "Is not supposed to be null");

    return functionTerm;
  }
}