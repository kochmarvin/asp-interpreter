using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.Atoms;

public class Atom(string name, List<Term> args)
{
  public string Name { get; } = name;
  public List<Term> Args { get; } = args;

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