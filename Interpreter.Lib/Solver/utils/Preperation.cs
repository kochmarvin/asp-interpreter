using Interpreter.Lib.Results.Objects.Rule;

namespace Interpreter.Lib.Solver;

/// <summary>
/// Structrue which the preparer returns
/// </summary>
/// <param name="factuallyTrue">All facts which are known to be factually true.</param>
/// <param name="remainder">The raimender which has to be solved.</param>
/// <param name="loopRules">And the found looprules for the solver.</param>
public class Preperation(List<ProgramRule> factuallyTrue, List<ProgramRule> remainder, List<LoopRule> loopRules)
{
  public List<ProgramRule> FactuallyTrue { get; set; } = factuallyTrue;
  public List<ProgramRule> Remainder { get; set; } = remainder;
  public List<LoopRule> LoopRules { get; set; } = loopRules;
}