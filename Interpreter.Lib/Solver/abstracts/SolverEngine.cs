using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Solver.Interfaces;

namespace Interpreter.Lib.Solver.Abstracts;

/// <summary>
/// Abstract class of a solver engine.
/// </summary>
/// <param name="preparer">The used preparer</param>
/// <param name="transformer">The used transformer</param>
/// <param name="solver">The used soolver</param>
public abstract class SolverEngine
{
  private IPreparer preparer;
  private ITransformer transformer;
  private ISolver solver;
  public IPreparer Preparer
  {
    get
    {
      return preparer;
    }
    private set
    {
      preparer = value ?? throw new ArgumentNullException(nameof(Preparer), "Is not supposed to be null");
    }
  }
  
  public ITransformer Transformer
  {
    get
    {
      return transformer;
    }
    private set
    {
      transformer = value ?? throw new ArgumentNullException(nameof(Transformer), "Is not supposed to be null");
    }
  }

  public ISolver Solver
  {
    get
    {
      return solver;
    }
    private set
    {
      solver = value ?? throw new ArgumentNullException(nameof(Solver), "Is not supposed to be null");
    }
  }

  public SolverEngine(IPreparer preparer, ITransformer transformer, ISolver solver)
  {
    Preparer = preparer;
    Transformer = transformer;
    Solver = solver;
  }

  public abstract List<List<Atom>>? Execute();
}