using Interpreter.Lib.Results.Objects.Terms;

public class IsVariableVisitor : TermVisitor<bool>
{
  public override bool Visit(Variable variable)
  {
    ArgumentNullException.ThrowIfNull(variable, "Is not supposed to be null");

    return true;
  }
}