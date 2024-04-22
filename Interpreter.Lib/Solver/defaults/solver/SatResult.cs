namespace Interpreter.Lib.Solver.defaults;

public class SatResult
{
  public bool Satisfiable { get; }
  public List<int> Assignments { get; }

  public SatResult(bool satisfiable, List<int> assignments)
  {
    Satisfiable = satisfiable;
    Assignments = assignments;
  }
}