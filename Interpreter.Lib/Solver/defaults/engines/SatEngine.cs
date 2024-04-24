using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Solver.Abstracts;
using Interpreter.Lib.Solver.defaults;

namespace Interpreter.Lib.Solver.defaults;

public class SatEngine(List<ProgramRule> program) : SolverEngine(new Preparer(), new SatTransformer(), new DPLLSolver())
{
  public List<ProgramRule> Program { get; } = program;

  public override List<List<Atom>> Execute()
  {
    var preperation = Preparer.Prepare(Program);

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

    var transformed = Transformer.TransformToFormular(preperation);

    Logger.Logger.Debug("Created cnf for solver.");


    rules = "CNF in integer format \n--------------------------------\n";
    foreach (var r in transformed)
    {
      string rule = "";
      foreach (var k in r)
      {
        rule += k + " ";
      }

      rules += rule + "\n";
    }
    Logger.Logger.Debug(rules + "--------------------------------");

    var solved = Solver.FindAllSolutions(transformed);
    return Transformer.ReTransform(solved.Select(sr => sr.Assignments).ToList());
  }
}