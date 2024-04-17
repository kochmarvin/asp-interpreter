
namespace Interpreter.Lib.Results.Objects.Terms;

public class Variable(string name) : Term
{
  public string Name { get; } = name;

  public override Term Apply(Dictionary<string, Term> substitutions)
  {
    if (substitutions.TryGetValue(Name, out Term? term))
    {
      return term;
    }

    return this;
  }

  public override bool HasVariable()
  {
    if (string.IsNullOrEmpty(Name))
    {
      return false;
    }

    return Char.IsUpper(Name[0]);
  }

  public override bool HasVariables()
  {
    if (string.IsNullOrEmpty(Name))
    {
      return false;
    }

    return char.IsUpper(Name[0]);
  }

  public override bool Match(Term other, Dictionary<string, Term> substiutionen)
  {
    if (substiutionen.TryGetValue(Name, out Term? t))
    {
      return ((Variable)t).Name == ((Variable)other).Name;
    }

    substiutionen.Add(Name, other);

    return true;
  }

  public override string ToString()
  {
    return Name;
  }
}