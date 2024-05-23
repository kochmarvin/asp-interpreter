using Interpreter.Lib.Solver.Defaults;

namespace Interpreter.Tests;

public class DPLLTestResults(string file, List<SatResult> expected)
{
  public string File { get; set; } = file;
  public List<SatResult> Expected { get; set; } = expected;
}