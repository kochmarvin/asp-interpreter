using Interpreter.Lib.Graph;
using Interpreter.Lib.Grounder;
using Interpreter.Lib.Results.Objects;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Solver.Interfaces;

namespace Interpreter.Lib.Solver;

/// <summary>
/// The standard query solver to solve a query.
/// </summary>
/// <param name="query">The query which should get solved</param>
/// <param name="set">The found sets.</param>
/// <param name="preparer">An instance of an preparer.</param>
public class QuerySolver
{
  private IPreparer _preparer;
  private List<Atom> _set;
  private Query _query;

  public IPreparer Preparer
  {
    get
    {
      return _preparer;
    }

    private set
    {
      _preparer = value ?? throw new ArgumentNullException(nameof(Preparer), "Is not Supposed to be null");
    }
  }

  public List<Atom> Set
  {
    get
    {
      return _set;
    }

    private set
    {
      _set = value ?? throw new ArgumentNullException(nameof(Set), "Is not supposed to be null");
    }
  }

  public Query Query
  {
    get
    {
      return _query;
    }

    private set
    {
      _query = value ?? throw new ArgumentNullException(nameof(Query), "Is not supposed to be null");
    }
  }

  public QuerySolver(Query query, List<Atom> set, IPreparer preparer)
  {
    Query = query;
    Set = set;
    Preparer = preparer;
  }

  /// <summary>
  /// Generates all the answers for the specified query
  /// </summary>
  /// <returns>The found solutions</returns>
  public List<ProgramRule> Answers()
  {
    List<List<ProgramRule>> results = [];
    List<ProgramRule> rules = [];

    foreach (var atom in _set)
    {
      rules.Add(new ProgramRule(new AtomHead(atom), []));
    }

    // add the parsed query to the whole program.
    rules.Add(_query.ParsedQuery);

    // Just make the grounding process again prepare it with that we know what query could be resolved
    DependencyGraph graph = new MyDependencyGraph(rules, new OrderVisitor(), new MyAddToGraphVisitor());
    Grounding grounding = new Grounding(graph);
    var grounded = grounding.Ground();

    foreach (var warning in grounding.Warnings)
    {
      Logger.Logger.Warning("atom does not occur in any rule head: \n" + warning);
    }

    var prepared = _preparer.Prepare(grounded);

    // Returning all the querys which are factually true and could be resolved.
    return prepared.FactuallyTrue
        .Where(rule =>
        {

          if (!rule.Head.Accept(new IsAtomHeadVisitor()))
          {
            return false;
          }

          var parsedHead = rule.Head.Accept(new ParseAtomHeadVisitor()) ?? throw new InvalidOperationException("Something happend which should not happen");

          return parsedHead.Atom.Name.StartsWith(_query.Name) &&
               rule.Body.Count == 0;
        }
        )
        .ToList();
  }
}