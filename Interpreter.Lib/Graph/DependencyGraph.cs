using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using QuickGraph;

namespace Interpreter.Lib.Graph;

/// <summary>
/// Genrates the dependecy graph and makes an SCC graph out of it
/// </summary>
public class DependencyGraph
{
  /// <summary>
  /// The program itself with all the rules
  /// </summary>
  public List<ProgramRule> Program { get; set; }

  /// <summary>
  /// The graph itself done with quickqraph
  /// </summary>
  private AdjacencyGraph<ProgramRule, Edge<ProgramRule>> _graph;

  /// <summary>
  /// Simple dictionary to match the heads better with the preds they are dependent on
  /// </summary>
  private Dictionary<string, List<ProgramRule>> _predicates;

  /// <summary>
  /// Constructor which will order the rules in a certain way
  /// </summary>
  /// <param name="program">The progra which you want the graph of</param>
  public DependencyGraph(List<ProgramRule> program)
  {
    Program = program;
    OrderRules();
  }

  /// <summary>
  /// Generates the dependency graph of the given program.
  /// </summary>
  /// <param name="onlyPositves">If true it will only get the positive atoms, those which do not contain not, important for loop rules</param>
  /// <returns>The SCC graph.</returns>
  public List<List<ProgramRule>> CreateGraph(bool onlyPositves = false)
  {
    _graph = new AdjacencyGraph<ProgramRule, Edge<ProgramRule>>();
    _predicates = [];

    // Going through every rule inside the program and add a node
    foreach (var rule in Program)
    {
      _graph.AddVertex(rule);

      // Get the head of the rule and its signature e.g hello/2 and store it
      if (rule.Head is AtomHead head)
      {
        AddSignature(rule, head.Atom.Signature);
      }

      // If it is a choice head to it for every choice
      if (rule.Head is ChoiceHead choices)
      {
        choices.Atoms.ForEach((choice) => AddSignature(rule, choice.Signature));
      }
    }

    // Go through the program and and create the ecges
    foreach (var rule in Program)
    {
      // get all depedencies of the rule through its body
      foreach (var body in rule.Body)
      {
        // if it is not a literal body skip it
        if (body is not LiteralBody)
        {
          continue;
        }

        var bodyLiteral = (LiteralBody)body;

        // if it is a comparison literal skip it
        if (bodyLiteral.Literal is ComparisonLiteral)
        {
          continue;
        }

        // if it is a is literal skip it
        if (bodyLiteral.Literal is IsLiteral)
        {
          continue;
        }

        var atomLiteral = (AtomLiteral)bodyLiteral.Literal;

        // Add the edge if it is postives or only postives is false.
        if (atomLiteral.Positive || !onlyPositves)
        {
          AddEdge(rule, atomLiteral.Atom);
        }
      }
    }

    // Create the SCC graph of the program
    return new Kosaraju<ProgramRule>(_graph).CreateKosaraju();
  }

  /// <summary>
  /// Adds a signature to the predicate dictionary
  /// </summary>
  /// <param name="rule">The rule reference we want to add.</param>
  /// <param name="signature">The signature of the rule.</param>
  private void AddSignature(ProgramRule rule, string signature)
  {
    if (!_predicates.ContainsKey(signature))
    {
      _predicates[signature] = [];
    }

    _predicates[signature].Add(rule);
  }

  /// <summary>
  /// Adds all Edes for a specific rule
  /// </summary>
  /// <param name="rule">The rule reference.</param>
  /// <param name="atom">The head of the rule refernce to get the Signature</param>
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

  /// <summary>
  /// Orders the rules in a specific way.
  /// </summary>
  private void OrderRules()
  {
    foreach (var rule in Program)
    {
      rule.Body = [.. rule.Body.OrderBy(OrderPredicate)];
    }
  }

  /// <summary>
  /// Orders the rules due to its positiviness state
  /// </summary>
  /// <param name="body">The body we want to get the order int</param>
  /// <returns>The integer where the body should be.</returns>
  private int OrderPredicate(Body body)
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