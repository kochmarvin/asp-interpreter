//-----------------------------------------------------------------------
// <copyright file="QuerySolver.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Solver;

using Interpreter.Lib.Graph;
using Interpreter.Lib.Grounder;
using Interpreter.Lib.Results.Objects;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Solver.Interfaces;

/// <summary>
/// The standard query solver to solve a query.
/// </summary>
/// <param name="query">The query which should get solved.</param>
/// <param name="set">The found sets.</param>
/// <param name="preparer">An instance of an preparer.</param>
public class QuerySolver
{
  private IPreparer preparer;
  private List<Atom> set;
  private Query query;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuerySolver"/> class.
  /// </summary>
  /// <param name="query">The query to be solved.</param>
  /// <param name="set">The atoms from the answer set of the program the query is run on.</param>
  /// <param name="preparer">The preparer object that preparers the query.</param>
  public QuerySolver(Query query, List<Atom> set, IPreparer preparer)
  {
    this.Query = query;
    this.Set = set;
    this.Preparer = preparer;
  }

  /// <summary>
  /// Gets the preparer needed to prepare the query rule.
  /// </summary>
  public IPreparer Preparer
  {
    get
    {
      return this.preparer;
    }

    private set
    {
      this.preparer = value ?? throw new ArgumentNullException(nameof(this.Preparer), "Is not Supposed to be null");
    }
  }

  /// <summary>
  /// Gets the set of atoms from the answer sets.
  /// </summary>
  public List<Atom> Set
  {
    get
    {
      return this.set;
    }

    private set
    {
      this.set = value ?? throw new ArgumentNullException(nameof(this.Set), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Gets the query for the solver to solve.
  /// </summary>
  public Query Query
  {
    get
    {
      return this.query;
    }

    private set
    {
      this.query = value ?? throw new ArgumentNullException(nameof(this.query), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Generates all the answers for the specified query.
  /// </summary>
  /// <returns>The found solutions.</returns>
  public List<ProgramRule> Answers()
  {
    List<List<ProgramRule>> results = [];
    List<ProgramRule> rules = [];

    foreach (var atom in this.Set)
    {
      rules.Add(new ProgramRule(new AtomHead(atom), []));
    }

    // add the parsed query to the whole program.
    rules.Add(this.Query.ParsedQuery);

    // Just make the grounding process again prepare it with that we know what query could be resolved
    DependencyGraph graph = new MyDependencyGraph(rules, new OrderVisitor(), new MyAddToGraphVisitor());
    Grounding grounding = new Grounding(graph);
    var grounded = grounding.Ground();

    foreach (var warning in grounding.Warnings)
    {
      Logger.Logger.Warning("atom does not occur in any rule head: \n" + warning);
    }

    var prepared = this.Preparer.Prepare(grounded);

    // Returning all the querys which are factually true and could be resolved.
    return prepared.FactuallyTrue
        .Where(rule =>
        {
          if (!rule.Head.Accept(new IsAtomHeadVisitor()))
          {
            return false;
          }

          var parsedHead = rule.Head.Accept(new ParseAtomHeadVisitor()) ?? throw new InvalidOperationException("Something happend which should not happen");

          return parsedHead.Atom.Name.StartsWith(this.Query.Name) &&
               rule.Body.Count == 0;
        }).ToList();
  }
}