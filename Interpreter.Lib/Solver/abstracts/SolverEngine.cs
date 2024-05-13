using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Solver.Interfaces;

namespace Interpreter.Lib.Solver.Abstracts;

/// <summary>
/// Abstract class of a solver engine.
/// </summary>
/// <param name="preparer">The used preparer</param>
/// <param name="transformer">The used transformer</param>
/// <param name="solver">The used soolver</param>
public abstract class SolverEngine(IPreparer preparer, ITransformer transformer, ISolver solver)
{
  public IPreparer Preparer { get; } = preparer;
  public ITransformer Transformer { get; } = transformer;
  public ISolver Solver { get; } = solver;

  public abstract List<List<Atom>>? Execute();
}