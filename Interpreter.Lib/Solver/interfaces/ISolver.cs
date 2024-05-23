//-----------------------------------------------------------------------
// <copyright file="ISolver.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Solver.Interfaces;

using Interpreter.Lib.Solver.Defaults;

/// <summary>
/// Interface for the solver.
/// </summary>
public interface ISolver
{
  /// <summary>
  /// Solves the given CNF folrumal using an algorithm.
  /// </summary>
  /// <param name="formular">The formular to be solved.</param>
  /// <returns>The solved sat result.</returns>
  public SatResult Solve(List<List<int>> formular);

  /// <summary>
  /// Finds all possible solutions from a formular.
  /// </summary>
  /// <param name="formular">The formular to be solved.</param>
  /// <returns>All possible sat results.</returns>
  public List<SatResult> FindAllSolutions(List<List<int>> formular);
}