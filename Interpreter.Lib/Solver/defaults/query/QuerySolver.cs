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
public class QuerySolver(Query query, List<Atom> set, IPreparer preparer)
{
  private readonly IPreparer _preparer = preparer;
  private readonly List<Atom> _set = set;
  private readonly Query _query = query;

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
    DependencyGraph graph = new DependencyGraph(rules);
    Grounding grounding = new Grounding(graph);
    var grounded = grounding.Ground();

    foreach (var warning in grounding.Warnings)
    {
      Logger.Logger.Warning("atom does not occur in any rule head: \n" + warning);
    }

    var prepared = _preparer.Prepare(grounded);

    // Returning all the querys which are factually true and could be resolved.
    return prepared.FactuallyTrue
        .Where(rule => rule.Head is AtomHead &&
              ((AtomHead)rule.Head).Atom.Name.StartsWith(_query.Name) &&
               rule.Body.Count == 0)
        .ToList();

  }
}