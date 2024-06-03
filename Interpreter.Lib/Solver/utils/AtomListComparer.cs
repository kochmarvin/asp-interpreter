//-----------------------------------------------------------------------
// <copyright file="AtomListComparer.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.Atoms;

/// <summary>
/// Compares two atoms List and checks if they are equal.
/// </summary>
public class AtomListComparer : IEqualityComparer<List<Atom>>
{
  /// <summary>
  /// Determines whether the specified lists of atoms are equal.
  /// </summary>
  /// <param name="expected">The first list of atoms to compare.</param>
  /// <param name="compare">The second list of atoms to compare.</param>
  /// <returns>true if the specified lists are equal; otherwise, false.</returns>
  public bool Equals(List<Atom>? expected, List<Atom>? compare)
  {
    if (expected == null || compare == null)
    {
      return expected == compare;
    }

    if (expected.Count != compare.Count)
    {
      return false;
    }

    for (int i = 0; i < expected.Count; i++)
    {
      if (expected[i].ToString() != compare[i].ToString())
      {
        return false;
      }
    }

    return true;
  }

  /// <summary>
  /// Returns a hash code for the specified list of atoms.
  /// </summary>
  /// <param name="set">The list of atoms for which to get a hash code.</param>
    /// <returns>A hash code for the specified list of atoms.</returns>
  public int GetHashCode(List<Atom> set)
  {
    unchecked
    {
      int hash = 19;

      foreach (var atom in set)
      {
        hash = (hash * 31) + atom.ToString().GetHashCode();
      }

      return hash;
    }
  }
}