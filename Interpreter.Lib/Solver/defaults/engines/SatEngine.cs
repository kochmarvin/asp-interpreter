using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Solver.Abstracts;
using Interpreter.Lib.Solver.defaults;

namespace Interpreter.Lib.Solver.defaults;

public class SatEngine(List<ProgramRule> program, bool verbose = false) : SolverEngine(new Preparer(), new SatTransformer(), new DPLL())
{
  public List<ProgramRule> Program { get; } = program;

  public override List<List<Atom>> Execute()
  {
    var preperation = Preparer.Prepare(Program);

    if (verbose)
    {
      Console.WriteLine("");
      Console.WriteLine("==[Factually true]==");
      Console.WriteLine("");
      foreach (var r in preperation.FactuallyTrue)
      {
        Console.WriteLine(r);
      }

      Console.WriteLine("");
      Console.WriteLine("==[Remainder]==");
      Console.WriteLine("");
      foreach (var r in preperation.Remainder)
      {
        Console.WriteLine(r);
      }
    }

    var transformed = Transformer.TransformToFormular(preperation);
    // If solve returns null it is unsatisviable
    var solved = Solver.Solve(transformed) ?? throw new InvalidOperationException("UNSATISFIABLE");

    return Transformer.ReTransform(solved);
  }
}