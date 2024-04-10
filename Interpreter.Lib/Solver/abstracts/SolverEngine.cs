using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Solver.Interfaces;

namespace Interpreter.Lib.Solver.Abstracts;

public abstract class SolverEngine(IPreparer preparer, ITransformer transformer, ISolver solver)
{
  public IPreparer Preparer { get; } = preparer;
  public ITransformer Transformer { get; } = transformer;
  public ISolver Solver { get; } = solver;

  public abstract List<List<Atom>> Execute();
}