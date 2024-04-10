namespace Interpreter.Lib.Solver.Interfaces;

public interface ISolver
{
  // Every List is one answer Set, List of Answert sets thats why double list
  public List<List<int>> Solve(List<List<int>> formular);
}