//-----------------------------------------------------------------------
// <copyright file="IGrounder.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.Rule;

/// <summary>
/// The interface for the grounder of the program.
/// </summary>
public interface IGrounder
{
  /// <summary>
  /// Gets a list of warnings generated during the grounding progress.
  /// </summary>
  List<string> Warnings
  {
    get;
  }

  /// <summary>
  /// Grounds the program and transorming them into a list of program rules.
  /// </summary>
  /// <returns>A list of grounded program rules.</returns>
  List<ProgramRule> Ground();
}