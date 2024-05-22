namespace Interpreter.Lib.Graph;

using Interpreter.Lib.Results.Objects.Rule;
using Microsoft.FSharp.Core;


/// <summary>
/// 
/// </summary>
public abstract class DependencyGraph
{
  private List<ProgramRule> program;
  private LiteralVisitor<int> orderVisitor;
  private AddToGraphVisitor addToGraphVisitor;

  /// <summary>
  /// 
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
  /// 
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
  /// 
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
  /// 
  /// </summary>
  /// <param name="program"></param>
  /// <param name="orderVisitor"></param>
  /// <param name="addToGraphVisitor"></param>
  public DependencyGraph(List<ProgramRule> program, LiteralVisitor<int> orderVisitor, AddToGraphVisitor addToGraphVisitor)
  {
    this.Program = program;
    this.OrderVisitor = orderVisitor;
    this.AddToGraphVisitor = addToGraphVisitor;
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="program"></param>
  /// <returns></returns>
  public abstract DependencyGraph CreateNewGraphInstance(List<ProgramRule> program);

  /// <summary>
  /// Generates the dependency graph of the given program.
  /// </summary>
  /// <param name="onlyPositves">If true it will only get the positive atoms, those which do not contain not, important for loop rules</param>
  /// <returns>The SCC graph.</returns>
  public abstract List<List<ProgramRule>> CreateGraph(bool onlyPositves = false);
}