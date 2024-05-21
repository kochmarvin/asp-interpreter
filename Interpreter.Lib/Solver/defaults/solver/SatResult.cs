namespace Interpreter.Lib.Solver.defaults;

/// <summary>
/// The result of a sat solver
/// </summary>
/// <param name="satisfiable">If it was satisfiable or not</param>
/// <param name="assignments">The variable assignemnt</param>
public class SatResult
{
  private bool satisfiable;
  private List<int> assignments;

  /// <summary>
  /// If the formular was satisfiable or not
  /// </summary>
  public bool Satisfiable
  {
    get
    {
      return satisfiable;
    }

    private set
    {
      satisfiable = value;
    }
  }

  /// <summary>
  /// The variable assignements
  /// </summary>
  public List<int> Assignments
  {
    get
    {
      return assignments;
    }

    private set
    {
      assignments = value ?? throw new ArgumentNullException(nameof(Assignments), "Is not supposed to be null");
    }
  }

  public SatResult(bool satisfiable, List<int> assignments)
  {
    Satisfiable = satisfiable;
    Assignments = assignments;
  }
}