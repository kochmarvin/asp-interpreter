//-----------------------------------------------------------------------
// <copyright file="SatResult.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Solver.Defaults;

/// <summary>
/// The result of a sat solver.
/// </summary>
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

  /// <summary>
  /// Checks whether the given object is equal to this object.
  /// </summary>
  /// <param name="obj">The object to check with the current one.</param>
  /// <returns>Whether the objects comapared are equal.</returns>
  public override bool Equals(object? obj)
  {
    var other = obj as SatResult;
    if (other == null)
    {
      return false;
    }

    return this.Assignments.SequenceEqual(other.Assignments);
  }

  /// <summary>
  /// A default hash function.
  /// </summary>
  /// <returns>The hascode for the current object.</returns>
  public override int GetHashCode()
  {
    unchecked
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