//-----------------------------------------------------------------------
// <copyright file="Preperation.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Solver;

using Interpreter.Lib.Results.Objects.Rule;

/// <summary>
/// Structrue which the preparer returns.
/// </summary>
public class Preperation
{
  private List<ProgramRule> factuallyTrue;
  private List<ProgramRule> remainder;
  private List<LoopRule> loopRules;

  /// <summary>
  /// Initializes a new instance of the <see cref="Preperation"/> class.
  /// </summary>
  /// <param name="factuallyTrue">All facts which are known to be factually true.</param>
  /// <param name="remainder">The remainder which has to be solved.</param>
  /// <param name="loopRules">And the found looprules for the solver.</param>
  public Preperation(List<ProgramRule> factuallyTrue, List<ProgramRule> remainder, List<LoopRule> loopRules)
  {
    this.FactuallyTrue = factuallyTrue;
    this.Remainder = remainder;
    this.LoopRules = loopRules;
  }

  /// <summary>
  /// Gets the all the facts which are known to be factually true.
  /// </summary>
  public List<ProgramRule> FactuallyTrue
  {
    get
    {
      return this.factuallyTrue;
    }

    private set
    {
      this.factuallyTrue = value ?? throw new ArgumentNullException(nameof(this.FactuallyTrue), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Gets the remainder which has to be solved.
  /// </summary>
  public List<ProgramRule> Remainder
  {
    get
    {
      return this.remainder;
    }

    private set
    {
      this.remainder = value ?? throw new ArgumentNullException(nameof(this.Remainder), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Gets the found loop rules for the solver.
  /// </summary>
  public List<LoopRule> LoopRules
  {
    get
    {
      return this.loopRules;
    }

    private set
    {
      this.loopRules = value ?? throw new ArgumentNullException(nameof(this.LoopRules), "Is not supposed to be null");
    }
  }
}