using Interpreter.Lib.Solver.defaults;

namespace Interpreter.Lib.Solver.Interfaces;

public interface ISolver
{
  // Every List is one answer Set, List of Answert sets thats why double list
  public SatResult Solve(List<List<int>> formular);
  public List<SatResult> FindAllSolutions(List<List<int>> formular);
}