using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Rule;

namespace Interpreter.Lib.Results.Objects;

/// <summary>
/// The parsed query with its variables.
/// </summary>
/// <param name="query">tThe parsed query.</param>
/// <param name="variables">The variables of the query.</param>
public class Query(ProgramRule query, HashSet<string> variables)
{
  public ProgramRule ParsedQuery { get; set; } = query;
  public HashSet<string> Variables { get; set; } = variables;

  /// <summary>
  /// Returns the Name of the query because it is a random uuid
  /// </summary>
  public string Name
  {
    get
    {
      return ((AtomHead)ParsedQuery.Head).Atom.Name;
    }
  }

}