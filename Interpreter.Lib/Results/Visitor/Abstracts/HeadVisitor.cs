using Interpreter.Lib.Results.Objects.HeadLiterals;

public abstract class HeadVisitor<T>
{
  public virtual T? Visit(Headless headless) => default;
  public virtual T? Visit(ChoiceHead choiceHead) => default;
  public virtual T? Visit(AtomHead atomHead) => default;
}