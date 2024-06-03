//-----------------------------------------------------------------------
// <copyright file="IGetHeadAtoms.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.Atoms;

/// <summary>
/// The interface for getting all atoms of a specific object.
/// </summary>
public interface IGetHeadAtoms
{
  /// <summary>
  /// Gets all atoms out of the head and returns a list of all atoms.
  /// </summary>
  /// <returns>A list of all atoms out of the head.</returns>
  public List<Atom> GetHeadAtoms();
}