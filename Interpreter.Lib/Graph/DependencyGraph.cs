using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using QuickGraph;

namespace Interpreter.Lib.Graph;

public class DependencyGraph
{
  public List<ProgramRule> Program { get; }

  private AdjacencyGraph<ProgramRule, Edge<ProgramRule>> _graph;
  private Dictionary<string, List<ProgramRule>> _predicates;

  public DependencyGraph(List<ProgramRule> program)
  {
    Program = program;
    OrderRules();

  }

  public List<List<ProgramRule>> CreateGraph(bool onlyPositves = false)
  {
    _graph = new AdjacencyGraph<ProgramRule, Edge<ProgramRule>>();
    _predicates = [];

    foreach (var rule in Program)
    {
      _graph.AddVertex(rule);

      if (rule.Head is AtomHead head)
      {
        AddSignature(rule, head.Atom.Signature);
      }

      if (rule.Head is ChoiceHead choices)
      {
        choices.Atoms.ForEach((choice) => AddSignature(rule, choice.Signature));
      }
    }

    foreach (var rule in Program)
    {
      foreach (var body in rule.Body)
      {
        if (body is not LiteralBody)
        {
          continue;
        }

        var bodyLiteral = (LiteralBody)body;

        if (bodyLiteral.Literal is ComparisonLiteral)
        {
          continue;
        }

        var atomLiteral = (AtomLiteral)bodyLiteral.Literal;

        if (atomLiteral.Positive || !onlyPositves)
        {
          AddEdge(rule, atomLiteral.Atom);
        }
      }
    }

    return new Kosaraju<ProgramRule>(_graph).CreateKosaraju();
  }

  private void AddSignature(ProgramRule rule, string signature)
  {
    if (!_predicates.ContainsKey(signature))
    {
      _predicates[signature] = [];
    }

    _predicates[signature].Add(rule);
  }

  private void AddEdge(ProgramRule rule, Atom atom)
  {
    if (_predicates.TryGetValue(atom.Signature, out var dependents))
    {
      foreach (var dependentRule in dependents)
      {
        _graph.AddEdge(new Edge<ProgramRule>(rule, dependentRule));
      }
    }
  }

  private void OrderRules()
  {
    foreach (var rule in Program)
    {
      rule.Body = [.. rule.Body.OrderBy(OrderPredicate)];
    }
  }

  private int OrderPredicate(BodyLiteral body)
  {
    if (body is not LiteralBody)
    {
      return 2;
    }

    Literal literal = ((LiteralBody)body).Literal;

    if (literal is AtomLiteral atomLiteral)
    {
      return atomLiteral.Positive ? 0 : 1;
    }

    return 1;
  }
}