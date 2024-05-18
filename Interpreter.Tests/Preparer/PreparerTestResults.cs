using Interpreter.Lib.Solver;

namespace Interpreter.Tests;

public class PrepareResults(string file, Preperation expected)
{
  public string File { get; set; } = file;
  public Preperation Expected { get; set; } = expected;
}