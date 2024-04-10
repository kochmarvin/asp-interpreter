using Interpreter.Lib.Results.Objects.Rule;

namespace Interpreter.Lib.Solver;

public class Preperation(List<ProgramRule> factuallyTrue, List<ProgramRule> remainder)
{
  public List<ProgramRule> FactuallyTrue { get; set; } = factuallyTrue;
  public List<ProgramRule> Remainder { get; set; } = remainder;
}