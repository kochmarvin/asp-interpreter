using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Vistors;
using QuickGraph;

namespace Interpreter.Lib.Graph;

/// <summary>
/// Genrates the dependecy graph and makes an SCC graph out of it
/// </summary>
public class MyDependencyGraph : DependencyGraph
{
  /// <summary>
  /// The graph itself done with quickqraph
  /// </summary>
  private AdjacencyGraph<ProgramRule, Edge<ProgramRule>> graph;

  /// <summary>
  /// Simple dictionary to match the heads better with the preds they are dependent on
  /// </summary>
  private Dictionary<string, List<ProgramRule>> predicates;

  /// <summary>
  /// Constructor which will order the rules in a certain way
  /// </summary>
  /// <param name="program">The progra which you want the graph of</param>
  public MyDependencyGraph(List<ProgramRule> program, OrderVisitor orderVisitor, AddToGraphVisitor addToGraphVisitor) : base(program, orderVisitor, addToGraphVisitor)
  {
    OrderRules();
  }

  /// <summary>
  /// Generates the dependency graph of the given program.
  /// </summary>
  /// <param name="onlyPositves">If true it will only get the positive atoms, those which do not contain not, important for loop rules</param>
  /// <returns>The SCC graph.</returns>
  public override List<List<ProgramRule>> CreateGraph(bool onlyPositves = false)
  {
    graph = new AdjacencyGraph<ProgramRule, Edge<ProgramRule>>();
    predicates = [];

    // Going through every rule inside the program and add a node
    foreach (var rule in Program)
    {
      graph.AddVertex(rule);

      foreach (var atom in rule.Head.GetHeadAtoms())
      {
        AddSignature(rule, atom.Signature);
      }
    }

    // Go through the program and and create the ecges
    foreach (var rule in Program)
    {
      // get all depedencies of the rule through its body
      foreach (var body in rule.Body)
      {
        body.AddToGraph(AddToGraphVisitor.CreateInstance(rule, AddEdge, onlyPositves));
      }
    }

    // Create the SCC graph of the program
    return new Kosaraju<ProgramRule>(graph).CreateKosaraju();
  }

  /// <summary>
  /// Adds a signature to the predicate dictionary
  /// </summary>
  /// <param name="rule">The rule reference we want to add.</param>
  /// <param name="signature">The signature of the rule.</param>
  private void AddSignature(ProgramRule rule, string signature)
  {
    if (!predicates.ContainsKey(signature))
    {
      predicates[signature] = [];
    }

    predicates[signature].Add(rule);
  }

  /// <summary>
  /// Adds all Edes for a specific rule
  /// </summary>
  /// <param name="rule">The rule reference.</param>
  /// <param name="atom">The head of the rule refernce to get the Signature</param>
  private void AddEdge(ProgramRule rule, Atom atom)
  {
    if (predicates.TryGetValue(atom.Signature, out var dependents))
    {
      foreach (var dependentRule in dependents)
      {
        graph.AddEdge(new Edge<ProgramRule>(rule, dependentRule));
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
    return body.Order(OrderVisitor);
  }

  public override DependencyGraph CreateNewGraphInstance(List<ProgramRule> program)
  {
    return new MyDependencyGraph(program, OrderVisitor, AddToGraphVisitor);
  }
}