using Interpreter.Lib.Results.Objects.Rule;

namespace Interpreter.Lib.Solver.Interfaces;

/// <summary>
/// Interface of what the perparer needs.
/// </summary>
public interface IPreparer
{
  public Preperation Prepare(List<ProgramRule> program);
}