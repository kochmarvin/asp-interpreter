using Interpreter.Lib.Results.Objects.Rule;

namespace Interpreter.Lib.Solver;

/// <summary>
/// Structrue which the preparer returns
/// </summary>
/// <param name="factuallyTrue">All facts which are known to be factually true.</param>
/// <param name="remainder">The raimender which has to be solved.</param>
/// <param name="loopRules">And the found looprules for the solver.</param>
public class Preperation
{
  private List<ProgramRule> factuallyTrue;
  private List<ProgramRule> remainder;
  private List<LoopRule> loopRules;
  public List<ProgramRule> FactuallyTrue
  {
    get
    {
      return factuallyTrue;
    }

    private set
    {
      factuallyTrue = value ?? throw new ArgumentNullException(nameof(FactuallyTrue), "Is not supposed to be null");
    }
  }
  public List<ProgramRule> Remainder
  {
    get
    {
      return remainder;
    }

    private set
    {
      remainder = value ?? throw new ArgumentNullException(nameof(Remainder), "Is not supposed to be null");
    }
  }
  public List<LoopRule> LoopRules
  {
    get
    {
      return loopRules;
    }

    private set
    {
      loopRules = value ?? throw new ArgumentNullException(nameof(LoopRules), "Is not supposed to be null");
    }
  }

  public Preperation(List<ProgramRule> factuallyTrue, List<ProgramRule> remainder, List<LoopRule> loopRules)
  {
    FactuallyTrue = factuallyTrue;
    Remainder = remainder;
    LoopRules = loopRules;
  }
}