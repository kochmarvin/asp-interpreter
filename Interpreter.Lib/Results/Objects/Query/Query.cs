using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Rule;

namespace Interpreter.Lib.Results.Objects;

/// <summary>
/// The parsed query with its variables.
/// </summary>
/// <param name="query">tThe parsed query.</param>
/// <param name="variables">The variables of the query.</param>
public class Query
{
  private ProgramRule parsedQuery;
  private HashSet<string> variables;

  public ProgramRule ParsedQuery
  {
    get
    {
      return parsedQuery;
    }

    private set
    {
      parsedQuery = value ?? throw new ArgumentNullException(nameof(ParsedQuery), "Is not supposed to be null");
    }
  }

  public HashSet<string> Variables
  {
    get
    {
      return variables;
    }
    private set
    {
      variables = value ?? throw new ArgumentNullException(nameof(Variables), "Is not supposed to be null");
    }
  }

  public Query(ProgramRule query, HashSet<string> variables)
  {
    ParsedQuery = query;
    Variables = variables;
  }

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