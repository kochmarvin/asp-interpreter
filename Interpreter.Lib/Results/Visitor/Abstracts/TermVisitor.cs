using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Terms;

public abstract class TermVisitor<T>
{
  public virtual T? Visit(Number number) => default;
  public virtual T? Visit(Variable variable) => default;
  public virtual T? Visit(FunctionTerm functionTerm) => default;
}