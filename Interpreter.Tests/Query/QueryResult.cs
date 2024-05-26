using Interpreter.Lib.Results.Objects.Atoms;

namespace Interpreter.Tests;

public class QueryResult(string file, string query, List<bool> expected)
{
  public string File { get; set; } = file;
  public string Query { get; set; } = query;
  public List<bool> Expected { get; set; } = expected;
}