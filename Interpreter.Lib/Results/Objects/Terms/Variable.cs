
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

  public override List<string> GetVariables()
  {
    if (HasVariables())
    {
      return [Name];
    }

    return [];
  }

  public override bool HasVariables()
  {
    if (string.IsNullOrEmpty(Name))
    {
      return false;
    }

    return char.IsUpper(Name[0]);
  }

  public override bool HasVariables(string variable)
  {
    if (string.IsNullOrEmpty(Name))
    {
      return false;
    }

    return variable.Equals(Name);
  }

  public override bool Match(Term other, Dictionary<string, Term> substiutionen)
  {
    if (substiutionen.TryGetValue(Name, out Term? t))
    {
      return ((Variable)t).Name == ((Variable)other).Name;
    }

    // TODO check if this fucks something up
    if (this.HasVariables())
    {
      substiutionen.Add(Name, other);
    }

    return true;
  }

  public override string ToString()
  {
    return Name;
  }
}