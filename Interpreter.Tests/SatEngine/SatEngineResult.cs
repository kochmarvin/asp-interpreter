using Interpreter.Lib.Results.Objects.Atoms;
using static Interpreter.FunctionalLib.ConjunctiveNormalForm;

namespace Interpreter.Tests;

public class SatEngineResult(string file, List<List<Atom>> expected)
{
  public string File { get; set; } = file;
  public List<List<Atom>> Expected { get; set; } = expected;
}