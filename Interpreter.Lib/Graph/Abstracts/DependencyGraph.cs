//-----------------------------------------------------------------------
// <copyright file="DependencyGraph.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Graph;

using Interpreter.Lib.Results.Objects.Rule;

/// <summary>
/// The abstract class of the dependency graph.
/// </summary>
public abstract class DependencyGraph
{
  private List<ProgramRule> program;
  private LiteralVisitor<int> orderVisitor;
  private AddToGraphVisitor addToGraphVisitor;

  /// <summary>
  /// Initializes a new instance of the <see cref="DependencyGraph"/> class.
  /// </summary>
  /// <param name="program">The program of which the graph will be build.</param>
  /// <param name="orderVisitor">The literal visitor used for the dependency graph.</param>
  /// <param name="addToGraphVisitor">The visitor that adds nodes to the graph.</param>
  public DependencyGraph(List<ProgramRule> program, LiteralVisitor<int> orderVisitor, AddToGraphVisitor addToGraphVisitor)
  {
    this.Program = program;
    this.OrderVisitor = orderVisitor;
    this.AddToGraphVisitor = addToGraphVisitor;
  }

  /// <summary>
  /// Gets or sets the program for the dependency graph.
  /// </summary>
  public List<ProgramRule> Program
  {
    get
    {
      return this.program;
    }

    set
    {
      this.program = value ?? throw new ArgumentNullException(nameof(this.Program) + "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Gets the literal visitor for the dependency graph.
  /// </summary>
  public LiteralVisitor<int> OrderVisitor
  {
    get
    {
      return this.orderVisitor;
    }

    private set
    {
      this.orderVisitor = value ?? throw new ArgumentNullException(nameof(this.OrderVisitor) + "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Gets the object of the add to graph visitor for the dependency graph.
  /// </summary>
  public AddToGraphVisitor AddToGraphVisitor
  {
    get
    {
      return this.addToGraphVisitor;
    }

    private set
    {
      this.addToGraphVisitor = value ?? throw new ArgumentNullException(nameof(this.AddToGraphVisitor) + "Is not supposed to be null");
    }
  }

  /// <summary>
  /// The abstract method for creating a new insance of the dependency graph.
  /// </summary>
  /// <param name="program">The program of which the dependency graph will be created from.</param>
  /// <returns>A new instance of the dependency graph.</returns>
  public abstract DependencyGraph CreateNewGraphInstance(List<ProgramRule> program);

  /// <summary>
  /// Generates the dependency graph of the given program.
  /// </summary>
  /// <param name="onlyPositves">If true it will only get the positive atoms, those which do not contain not, important for loop rules.</param>
  /// <returns>The SCC graph.</returns>
  public abstract List<List<ProgramRule>> CreateGraph(bool onlyPositves = false);
}