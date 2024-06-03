//-----------------------------------------------------------------------
// <copyright file="ListComparer.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Solver;

/// <summary>
/// A generic list comparere of two list.
/// </summary>
/// <typeparam name="T">The type of the list.</typeparam>
public class ListComparer<T> : IEqualityComparer<List<T>>
{
  /// <summary>
  /// Determines whether the specified lists are equal.
  /// </summary>
  /// <param name="expected">The first list to compare.</param>
    /// <param name="compare">The second list to compare.</param>
    /// <returns>true if the specified lists are equal; otherwise, false.</returns>
  public bool Equals(List<T>? expected, List<T>? compare)
  {
    if (expected == null || compare == null)
    {
      return expected == compare;
    }

    // Sort both lists and then compare
    var sortedX = expected.OrderBy(item => item).ToList();
    var sortedY = compare.OrderBy(item => item).ToList();

    return sortedX.SequenceEqual(sortedY);
  }

  /// <summary>
  /// Returns a hash code for the specified list.
  /// </summary>
  /// <param name="obj">The list for which to get a hash code.</param>
  /// <returns>A hash code for the specified list.</returns>
  public int GetHashCode(List<T> obj)
  {
    if (obj == null)
    {
      return 0;
    }

    // Generate hash code based on sorted elements
    int hash = 17;
    foreach (var item in obj.OrderBy(i => i))
    {
      hash = (hash * 23) + (item == null ? 0 : item.GetHashCode());
    }

    return hash;
  }
}