//-----------------------------------------------------------------------
// <copyright file="IPreparer.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Solver.Interfaces;

using Interpreter.Lib.Results.Objects.Rule;

/// <summary>
/// Interface for the preparer object.
/// </summary>
public interface IPreparer
{
  /// <summary>
  /// Prepares a given list of program rules for the solver.
  /// </summary>
  /// <param name="program">The program that is being prepared.</param>
  /// <param name="queryMode">Turns on query mode and prepares in another way.</param>
  /// <returns>The prepared program.</returns>
  public Preperation Prepare(List<ProgramRule> program, bool queryMode = false);
}