using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Solver.Abstracts;

namespace Interpreter.Lib.Solver.defaults;

/// <summary>
/// Default Solver engine which useses a basic preparer a basic sattransformer and the DPLL in the backend
/// </summary>
/// <param name="program"></param>
public class SatEngine(List<ProgramRule> program) : SolverEngine(new Preparer(), new SatTransformer(), new DPLLSolver())
{
  public List<ProgramRule> Program { get; } = program;

  /// <summary>
  /// Executes the Backend and solves it.
  /// </summary>
  /// <returns>The Solved answer sets</returns>
  public override List<List<Atom>> Execute()
  {
    HashSet<ProgramRule> uniqueRules = new(Program);
    List<ProgramRule> deduplicatedRules = new(uniqueRules);
    // Start the preparerer and get the preperation
    var preperation = Preparer.Prepare(deduplicatedRules);

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
    var transformed = Transformer.TransformToFormular(preperation);


    Logger.Logger.Debug("Created cnf for solver.");


    rules = "CNF in integer format \n--------------------------------\n";
    foreach (var transform in transformed)
    {
      string rule = "";
      foreach (var value in transform)
      {
        rule += value + " ";
      }

      rules += rule + "\n";
    }
    Logger.Logger.Debug(rules + "--------------------------------");

    // Find all solutions with the DPLL and return the Sets
    var solved = Solver.FindAllSolutions(transformed);
    return Transformer.ReTransform(solved.Select(sr => sr.Assignments).ToList());
  }
}