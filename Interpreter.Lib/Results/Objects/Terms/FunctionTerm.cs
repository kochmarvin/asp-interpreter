namespace Interpreter.Lib.Results.Objects.Terms;

public class FunctionTerm(string name, List<Term> arguments) : Term
{
  public string Name { get; } = name;
  public List<Term> Arguments { get; } = arguments;

  public override Term Apply(Dictionary<string, Term> substitutions)
  {
    var appliedArgs = Arguments.Select(arg => arg.Apply(substitutions)).ToList();
    return new FunctionTerm(Name, appliedArgs);

  }

  public override bool HasVariables()
  {
    foreach (var term in Arguments)
    {
      if (term.HasVariables())
      {
        return true;
      }
    }

    return false;
  }

  public override bool Match(Term other, Dictionary<string, Term> substiutionen)
  {
    FunctionTerm converted = (FunctionTerm)other;
    if (Name != converted.Name || Arguments.Count != converted.Arguments.Count)
    {
      return false;
    }

    for (int i = 0; i < Arguments.Count; i++)
    {
      if (!Arguments[i].Match(converted.Arguments[i], substiutionen))
      {
        return false;
      }
    }

    return true;
  }

  public override string ToString()
  {
    if (Arguments.Count == 0)
    {
      return Name;
    }

    return $"{Name}({string.Join(", ", Arguments)})";
  }
}