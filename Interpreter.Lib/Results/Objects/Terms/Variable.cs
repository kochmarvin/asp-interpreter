namespace Interpreter.Lib.Results.Objects.Terms;

public class Variable(string name) : Term
{
  public string Name { get; } = name;

  public override string ToString() {
    return Name;
  }
}