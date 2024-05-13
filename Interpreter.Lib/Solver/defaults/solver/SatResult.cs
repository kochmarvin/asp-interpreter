namespace Interpreter.Lib.Solver.defaults;

/// <summary>
/// The result of a sat solver
/// </summary>
/// <param name="satisfiable">If it was satisfiable or not</param>
/// <param name="assignments">The variable assignemnt</param>
public class SatResult(bool satisfiable, List<int> assignments)
{
  /// <summary>
  /// If the formular was satisfiable or not
  /// </summary>
  public bool Satisfiable { get; } = satisfiable;

  /// <summary>
  /// The variable assignements
  /// </summary>
  public List<int> Assignments { get; } = assignments;
}