using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.Atoms;

public class Atom(string name, List<Term> args) : IMatch<Atom>, IApplier<Atom>, IHasVariables, IEquatable<Atom>
{
  public string Name { get; } = name;
  public List<Term> Args { get; } = args;

  public string Signature
  {
    get
    {
      return $"{Name}/{Args.Count}";
    }
  }

  public Atom Apply(Dictionary<string, Term> substitutions)
  {
    var appliedArgs = Args.Select(arg => arg.Apply(substitutions)).ToList();
    return new Atom(Name, appliedArgs);
  }

  public bool Equals(Atom? other)
  {
    return other?.ToString() == ToString();
  }

  public bool HasVariables()
  {
    bool hasVariables = false;

    foreach (var term in Args)
    {
      if (term.HasVariables())
      {
        hasVariables = true;
        break;
      }
    }

    return hasVariables;
  }

  public bool Match(Atom other, Dictionary<string, Term> substiutionen)
  {
    if (Name != other.Name || Args.Count != other.Args.Count)
    {
      return false;
    }

    for (int i = 0; i < Args.Count; i++)
    {
      if (!Args[i].Match(other.Args[i], substiutionen))
      {
        return false;
      }
    }

    return true;
  }

  public override string ToString()
  {
    if (Args.Count == 0)
    {
      return Name;
    }

    var argsString = string.Join(", ", Args.Select(arg => arg.ToString()));
    return $"{Name}({argsString})";
  }
}