using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Solver.Abstracts;
using Interpreter.Lib.Solver.defaults;

namespace Interpreter.Lib.Solver.defaults;

public class SatEngine(List<ProgramRule> program, bool verbose = false) : SolverEngine(new Preparer(), new SatTransformer(), new DPLLSolver())
{
  public List<ProgramRule> Program { get; } = program;

  public override List<List<Atom>>? Execute()
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

    if (verbose)
    {
      Console.WriteLine("");
      Console.WriteLine("==[Transformed formular]==");
      Console.WriteLine("");
      foreach (var r in transformed)
      {
        foreach (var k in r)
        {
          Console.Write(k + " ");
        }
        Console.WriteLine();
      }
    }

    var solved = Solver.FindAllSolutions(transformed);
    return Transformer.ReTransform(solved.Select(sr => sr.Assignments).ToList());
  }
}