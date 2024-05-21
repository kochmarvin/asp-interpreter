using Interpreter.Lib.Results.Objects.Rule;
using Microsoft.FSharp.Core;

namespace Interpreter.Lib.Graph;

/// <summary>
/// Genrates the dependecy graph and makes an SCC graph out of it
/// </summary>
public abstract class DependencyGraph
{
  private List<ProgramRule> program;
  private LiteralVisitor<int> orderVisitor;
  private AddToGraphVisitor addToGraphVisitor;

  public List<ProgramRule> Program
  {
    get
    {
      return program;
    }

    set
    {
      program = value ?? throw new ArgumentNullException(nameof(Program) + "Is not supposed to be null");
    }
  }

  public LiteralVisitor<int> OrderVisitor
  {
    get
    {
      return orderVisitor;
    }

    private set
    {
      orderVisitor = value ?? throw new ArgumentNullException(nameof(OrderVisitor) + "Is not supposed to be null");
    }
  }

  public AddToGraphVisitor AddToGraphVisitor
  {
    get
    {
      return addToGraphVisitor;
    }

    private set
    {
      addToGraphVisitor = value ?? throw new ArgumentNullException(nameof(AddToGraphVisitor) + "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Constructor which will order the rules in a certain way
  /// </summary>
  /// <param name="program">The progra which you want the graph of</param>
  public DependencyGraph(List<ProgramRule> program, LiteralVisitor<int> orderVisitor, AddToGraphVisitor addToGraphVisitor)
  {
    Program = program;
    OrderVisitor = orderVisitor;
    AddToGraphVisitor = addToGraphVisitor;
  }

  public abstract DependencyGraph CreateNewGraphInstance(List<ProgramRule> program);

  /// <summary>
  /// Generates the dependency graph of the given program.
  /// </summary>
  /// <param name="onlyPositves">If true it will only get the positive atoms, those which do not contain not, important for loop rules</param>
  /// <returns>The SCC graph.</returns>
  public abstract List<List<ProgramRule>> CreateGraph(bool onlyPositves = false);
}