//-----------------------------------------------------------------------
// <copyright file="IHasVariables.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Interfaces;

/// <summary>
/// Interfance to check whether an object has variables.
/// </summary>
public interface IHasVariables
{
  /// <summary>
  /// Checks if there are variables in general.
  /// </summary>
  /// <returns>Either if there are variables or not.</returns>
  public bool HasVariables();

  /// <summary>
  /// Checks if there is a specific variable.
  /// </summary>
  /// <param name="variable">The variable you want to check if it is in it.</param>
  /// <returns>Either if the variable is in it or not.</returns>
  public bool HasVariables(string variable);
}