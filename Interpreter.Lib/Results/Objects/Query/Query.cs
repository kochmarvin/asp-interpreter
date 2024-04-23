using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Rule;

namespace Interpreter.Lib.Results.Objects;

public class Query(ProgramRule query, HashSet<string> variables)
{
  public ProgramRule ParsedQuery { get; set; } = query;
  public HashSet<string> Variables { get; set; } = variables;
  public string Name
  {
    get
    {
      return ((AtomHead)ParsedQuery.Head).Atom.Name;
    }
  }

}