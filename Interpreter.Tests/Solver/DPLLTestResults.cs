namespace Interpreter.Tests;

public class DPLLTestResults(string file, List<List<int>> expected)
{
  public string File { get; set; } = file;
  public List<List<int>> Expected { get; set; } = expected;
}