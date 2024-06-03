//-----------------------------------------------------------------------
// <copyright file="IGetBodyAtoms.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.Atoms;

/// <summary>
/// The interface for getting all atoms of a specific object.
/// </summary>
public interface IGetBodyAtoms
{
  /// <summary>
  /// Gets all atoms out of a body and returns a list of atoms.
  /// </summary>
  /// <returns>A list of all atoms from the body.</returns>
  public List<Atom> GetBodyAtoms();
}