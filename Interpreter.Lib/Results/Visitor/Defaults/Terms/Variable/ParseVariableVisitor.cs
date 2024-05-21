using Interpreter.Lib.Results.Objects.Terms;

public class ParseVariableVisitor : TermVisitor<Variable>
{
  public override Variable Visit(Variable variable)
  {
    ArgumentNullException.ThrowIfNull(variable, "Is not supposed to be null");

    return variable;
  }
}