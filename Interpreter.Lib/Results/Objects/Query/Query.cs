//-----------------------------------------------------------------------
// <copyright file="Query.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Objects;

using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Rule;

/// <summary>
/// The parsed query with its variables.
/// </summary>
/// <param name="query">tThe parsed query.</param>
/// <param name="variables">The variables of the query.</param>
public class Query
{
  private ProgramRule parsedQuery;
  private HashSet<string> variables;

  /// <summary>
  /// Initializes a new instance of the <see cref="Query"/> class.
  /// </summary>
  /// <param name="query">The query as a program rule.</param>
  /// <param name="variables">The variables contained in the query.</param>
  public Query(ProgramRule query, HashSet<string> variables)
  {
    this.ParsedQuery = query;
    this.Variables = variables;
  }

  /// <summary>
  /// Gets the query parsed to a program rule.
  /// </summary>
  public ProgramRule ParsedQuery
  {
    get
    {
      return this.parsedQuery;
    }

    private set
    {
      this.parsedQuery = value ?? throw new ArgumentNullException(nameof(this.ParsedQuery), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Gets the variables of the query.
  /// </summary>
  public HashSet<string> Variables
  {
    get
    {
      return this.variables;
    }

    private set
    {
      this.variables = value ?? throw new ArgumentNullException(nameof(this.Variables), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Gets the Name of the query because it is a random uuid.
  /// </summary>
  public string Name
  {
    get
    {
      return ((AtomHead)this.ParsedQuery.Head).Atom.Name;
    }
  }
}