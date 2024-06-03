//-----------------------------------------------------------------------
// <copyright file="Query.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Objects;

using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Rule;

/// <summary>
/// The parsed query with its variables.
/// </summary>
public class Query
{
  private ProgramRule parsedQuery;
  private HashSet<string> variables;
  private IObjectParser objectParser;

  /// <summary>
  /// Initializes a new instance of the <see cref="Query"/> class.
  /// </summary>
  /// <param name="objectParser">The object parser.</param>
  /// <param name="query">The query as a program rule.</param>
  /// <param name="variables">The variables contained in the query.</param>
  public Query(IObjectParser objectParser, ProgramRule query, HashSet<string> variables)
  {
    this.ParsedQuery = query;
    this.Variables = variables;
    this.ObjectParser = objectParser;
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
  /// Gets the object parser.
  /// </summary>
  public IObjectParser ObjectParser
  {
    get
    {
      return this.objectParser;
    }

    private set
    {
      this.objectParser = value ?? throw new ArgumentNullException(nameof(this.ObjectParser), "Is not supposed to be null");
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
      var atomHead = this.ParsedQuery.Head.Accept(this.ObjectParser.ParseAtomHeadVisitor) ?? throw new ArgumentNullException("Should be a reference of atomhead");
      return atomHead.Atom.Name;
    }
  }
}