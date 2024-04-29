using Interpreter.Lib.Graph;
using Interpreter.Lib.Grounder;
using Interpreter.Lib.Results.Objects;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Solver.Interfaces;

namespace Interpreter.Lib.Solver;

public class QuerySolver
{

  private readonly IPreparer _preparer;
  private readonly List<Atom> _set;
  private readonly Query _query;

  public QuerySolver(Query query, List<Atom> set, IPreparer preparer)
  {
    _preparer = preparer;
    _set = set;
    _query = query;
  }

  public List<ProgramRule> Answers()
  {
    List<List<ProgramRule>> results = [];
    List<ProgramRule> rules = [];

    foreach (var atom in _set)
    {
      rules.Add(new ProgramRule(new AtomHead(atom), []));
    }

    rules.Add(_query.ParsedQuery);

    DependencyGraph graph = new DependencyGraph(rules);
    Grounding grounding = new Grounding(graph);
    var grounded = grounding.Ground();

    foreach (var warning in grounding.Warnings)
    {
      Logger.Logger.Warning("atom does not occur in any rule head: \n" + warning);
    }

    var prepared = _preparer.Prepare(grounded);

    return prepared.FactuallyTrue
        .Where(rule => rule.Head is AtomHead &&
              ((AtomHead)rule.Head).Atom.Name.StartsWith(_query.Name) &&
               rule.Body.Count == 0)
        .ToList();

  }
}