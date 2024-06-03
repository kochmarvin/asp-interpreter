//-----------------------------------------------------------------------
// <copyright file="IGetVariables.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Interfaces;

/// <summary>
/// Interface to get all variables of a specific object.
/// </summary>
public interface IGetVariables
{
  /// <summary>
  /// Gets all variables out of a specific object.
  /// </summary>
  /// <returns>A list of all variables from the specific object.</returns>
  public List<string> GetVariables();
}