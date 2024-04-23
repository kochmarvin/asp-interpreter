using Interpreter.Lib.Graph;
using Interpreter.Lib.Grounder;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Solver.Interfaces;

namespace Interpreter.Lib.Solver;

public class QuerySolver
{

  private readonly IPreparer _preparer;
  private readonly List<List<Atom>> _answerSets;
  private readonly ProgramRule _query;

  public QuerySolver(ProgramRule query, List<List<Atom>> answerSets, IPreparer preparer)
  {
    _preparer = preparer;
    _answerSets = answerSets;
    _query = query;
  }

  public List<List<ProgramRule>> Answers()
  {
    List<List<ProgramRule>> results = [];
    foreach (var set in _answerSets)
    {
      List<ProgramRule> rules = [];

      foreach (var atom in set)
      {
        rules.Add(new ProgramRule(new AtomHead(atom), []));
      }

      rules.Add(_query);

      DependencyGraph graph = new DependencyGraph(rules);
      Grounding grounding = new Grounding(graph);
      var grounded = grounding.Ground();
      var prepared = _preparer.Prepare(grounded);

      var filteredRules = prepared.FactuallyTrue
          .Where(rule => rule.Head is AtomHead &&
                ((AtomHead)rule.Head).Atom.Name.StartsWith("query") &&
                 rule.Body.Count == 0)
          .ToList();

      results.Add(filteredRules);
    }

    return results;
  }
}