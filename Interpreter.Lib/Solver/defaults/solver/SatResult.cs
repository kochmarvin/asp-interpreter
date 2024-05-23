//-----------------------------------------------------------------------
// <copyright file="SatResult.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Solver.Defaults;

/// <summary>
/// The result of a sat solver.
/// </summary>
/// <param name="satisfiable">If it was satisfiable or not.</param>
/// <param name="assignments">The variable assignemnt.</param>
public class SatResult
{
  private bool satisfiable;
  private List<int> assignments;

  /// <summary>
  /// Initializes a new instance of the <see cref="SatResult"/> class.
  /// </summary>
  /// <param name="satisfiable">Whether the program is satisfiable.</param>
  /// <param name="assignments">The assigned literals.</param>
  public SatResult(bool satisfiable, List<int> assignments)
  {
    this.Satisfiable = satisfiable;
    this.Assignments = assignments;
  }

  /// <summary>
  /// Gets a value indicating whether the formular was satisfiable or not.
  /// </summary>
  public bool Satisfiable
  {
    get
    {
      return this.satisfiable;
    }

    private set
    {
      this.satisfiable = value;
    }
  }

  /// <summary>
  /// Gets the variable assignements.
  /// </summary>
  public List<int> Assignments
  {
    get
    {
      return this.assignments;
    }

    private set
    {
      this.assignments = value ?? throw new ArgumentNullException(nameof(this.Assignments), "Is not supposed to be null");
    }
  }

  public override bool Equals(object obj)
  {
    var other = obj as SatResult;
    if (other == null)
    {
      return false;
    }

    return this.Assignments.SequenceEqual(other.Assignments);
  }

  public override int GetHashCode()
  {
    unchecked // Overflow is fine, just wrap
    {
      int hash = 19;
      foreach (var assignment in this.Assignments)
      {
        hash = (hash * 31) + assignment.GetHashCode();
      }

      return hash;
    }
  }
}