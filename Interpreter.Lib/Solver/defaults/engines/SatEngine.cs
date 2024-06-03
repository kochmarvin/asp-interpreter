//-----------------------------------------------------------------------
// <copyright file="SatEngine.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Solver.Defaults;

using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Solver.Abstracts;

/// <summary>
/// Default Solver engine which useses a basic preparer a basic sattransformer and the DPLL in the backend.
/// </summary>
public class SatEngine : SolverEngine
{
  private List<ProgramRule> program;

  /// <summary>
  /// Initializes a new instance of the <see cref="SatEngine"/> class.
  /// </summary>
  /// <param name="program">The program rules that are being solved.</param>
  public SatEngine(List<ProgramRule> program)
    : base(new Preparer(new Checker(), new ObjectParser()), new SatTransformer(new Checker(), new ObjectParser()), new DPLLSolver())
  {
    this.Program = program;
  }

  /// <summary>
  /// Gets the program rules for the sat engine.
  /// </summary>
  public List<ProgramRule> Program
  {
    get
    {
      return this.program;
    }

    private set
    {
      this.program = value ?? throw new ArgumentNullException(nameof(this.Program), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Executes the Backend and solves it.
  /// </summary>
  /// <returns>The Solved answer sets.</returns>
  public override List<List<Atom>> Execute()
  {
    HashSet<ProgramRule> uniqueRules = new(this.Program);
    List<ProgramRule> deduplicatedRules = new(uniqueRules);

    // Start the preparerer and get the preperation
    var preperation = this.Preparer.Prepare(deduplicatedRules);

    Logger.Logger.Debug("Created prepared Program.");

    string rules = "Factually True \n--------------------------------\n";
    foreach (var rule in preperation.FactuallyTrue)
    {
      rules += rule.ToString() + "\n";
    }

    Logger.Logger.Debug(rules + "--------------------------------");

    rules = "Remainder for solver \n--------------------------------\n";
    foreach (var rule in preperation.Remainder)
    {
      rules += rule.ToString() + "\n";
    }

    Logger.Logger.Debug(rules + "--------------------------------");

    // Transform the remainded rules
    var transformed = this.Transformer.TransformToFormular(preperation);

    Logger.Logger.Debug("Created cnf for solver.");

    rules = "CNF in integer format \n--------------------------------\n";
    foreach (var transform in transformed)
    {
      string rule = string.Empty;
      foreach (var value in transform)
      {
        rule += value + " ";
      }

      rules += rule + "\n";
    }

    Logger.Logger.Debug(rules + "--------------------------------");

    // Find all solutions with the DPLL and return the Sets
    var solved = this.Solver.FindAllSolutions(transformed);
    return this.Transformer.ReTransform(solved.Select(set => set.Assignments).ToList());
  }
}