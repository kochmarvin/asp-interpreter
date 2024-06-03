//-----------------------------------------------------------------------
// <copyright file="IGetLiteralAtoms.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.Atoms;

/// <summary>
/// The interface to get all the atoms of a specific object.
/// </summary>
public interface IGetLiteralAtoms
{
  /// <summary>
  /// Gets all of the atoms out of the literal and returns the list.
  /// </summary>
  /// <returns>All of the atoms our of the literal.</returns>
  public List<Atom> GetLiteralAtoms();
}