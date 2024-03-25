namespace Interpreter.Lib.Results.Objects.Terms;

public class FunctionTerm(string name, List<Term> arguments) : Term
{
  public string Name { get; } = name;
  public List<Term> Arguments { get; } = arguments;

  public override string ToString()
  {
    if (Arguments.Count == 0)
    {
      return Name;
    }

    return $"{Name}({string.Join(", ", Arguments)})";
  }
}