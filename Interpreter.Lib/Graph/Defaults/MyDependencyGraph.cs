//-----------------------------------------------------------------------
// <copyright file="MyDependencyGraph.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Graph;

using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Rule;
using QuickGraph;

/// <summary>
/// Genrates the dependecy graph and makes an SCC graph out of it.
/// </summary>
public class MyDependencyGraph : DependencyGraph
{
  /// <summary>
  /// The graph itself done with quickqraph.
  /// </summary>
  private AdjacencyGraph<ProgramRule, Edge<ProgramRule>> graph;

  /// <summary>
  /// Simple dictionary to match the heads better with the preds they are dependent on.
  /// </summary>
  private Dictionary<string, List<ProgramRule>> predicates;

  /// <summary>
  /// Initializes a new instance of the <see cref="MyDependencyGraph"/> class.
  /// </summary>
  /// <param name="program">The program of which the graph will be build from.</param>
  /// <param name="orderVisitor">The literal visitor needed for the graph.</param>
  /// <param name="addToGraphVisitor">The visitor that adds nodes to the graph.</param>
  public MyDependencyGraph(List<ProgramRule> program, LiteralVisitor<int> orderVisitor, AddToGraphVisitor addToGraphVisitor)
    : base(program, orderVisitor, addToGraphVisitor)
  {
    this.OrderRules();
  }

  /// <summary>
  /// Generates the dependency graph of the given program.
  /// </summary>
  /// <param name="onlyPositves">If true it will only get the positive atoms, those which do not contain not, important for loop rules.</param>
  /// <returns>The SCC graph.</returns>
  public override List<List<ProgramRule>> CreateGraph(bool onlyPositves = false)
  {
    this.graph = new AdjacencyGraph<ProgramRule, Edge<ProgramRule>>();
    this.predicates = [];

    // Going through every rule inside the program and add a node
    foreach (var rule in this.Program)
    {
      this.graph.AddVertex(rule);

      foreach (var atom in rule.Head.GetHeadAtoms())
      {
        this.AddSignature(rule, atom.Signature);
      }
    }

    // Go through the program and and create the ecges
    foreach (var rule in this.Program)
    {
      // get all depedencies of the rule through its body
      foreach (var body in rule.Body)
      {
        body.AddToGraph(this.AddToGraphVisitor.CreateInstance(rule, this.AddEdge, onlyPositves));
      }
    }

    // Create the SCC graph of the program
    return new Kosaraju<ProgramRule>(this.graph).CreateKosaraju();
  }

  /// <summary>
  /// Creates a new instance of the dependency graph.
  /// </summary>
  /// <param name="program">The program of which the graph is build from.</param>
  /// <returns>A new instance of the dependency graph.</returns>
  public override DependencyGraph CreateNewGraphInstance(List<ProgramRule> program)
  {
    ArgumentNullException.ThrowIfNull(program, "Is not supposed to be null");

    return new MyDependencyGraph(program, this.OrderVisitor, this.AddToGraphVisitor);
  }

  /// <summary>
  /// Adds a signature to the predicate dictionary.
  /// </summary>
  /// <param name="rule">The rule reference we want to add.</param>
  /// <param name="signature">The signature of the rule.</param>
  private void AddSignature(ProgramRule rule, string signature)
  {
    ArgumentNullException.ThrowIfNull(rule, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(signature, "Is not supposed to be null");

    if (!this.predicates.ContainsKey(signature))
    {
      this.predicates[signature] = [];
    }

    this.predicates[signature].Add(rule);
  }

  /// <summary>
  /// Adds all Edes for a specific rule.
  /// </summary>
  /// <param name="rule">The rule reference.</param>
  /// <param name="atom">The head of the rule refernce to get the Signature.</param>
  private void AddEdge(ProgramRule rule, Atom atom)
  {
    ArgumentNullException.ThrowIfNull(rule, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(atom, "Is not supposed to be null");

    if (this.predicates.TryGetValue(atom.Signature, out var dependents))
    {
      foreach (var dependentRule in dependents)
      {
        this.graph.AddEdge(new Edge<ProgramRule>(rule, dependentRule));
      }
    }
  }

  /// <summary>
  /// Orders the rules in a specific way.
  /// </summary>
  private void OrderRules()
  {
    foreach (var rule in this.Program)
    {
      rule.Body = [.. rule.Body.OrderBy(this.OrderPredicate)];
    }
  }

  /// <summary>
  /// Orders the rules due to its positiviness state.
  /// </summary>
  /// <param name="body">The body we want to get the order into.</param>
  /// <returns>The integer where the body should be.</returns>
  private int OrderPredicate(Body body)
  {
    ArgumentNullException.ThrowIfNull(body, "Is not supposed to be null");

    return body.Accept(this.OrderVisitor);
  }
}