using Interpreter.Lib.Results.Objects.Rule;

namespace Interpreter.Lib.Solver.Interfaces;

public interface IPreparer
{
  public Preperation Prepare(List<ProgramRule> program);
}