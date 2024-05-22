//-----------------------------------------------------------------------
// <copyright file="ParseAtomHeadVisitor.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.HeadLiterals;

/// <summary>
/// Visitor class to parse and return an AtomHead.
/// </summary>
public class ParseAtomHeadVisitor : HeadVisitor<AtomHead>
{
  /// <summary>
  /// Visits an AtomHead and returns it.
  /// </summary>
  /// <param name="atomHead">The AtomHead to visit.</param>
  /// <returns>The visited AtomHead.</returns>
  public override AtomHead Visit(AtomHead atomHead)
  {
    ArgumentNullException.ThrowIfNull(atomHead, "Is not supposed to be null");

    return atomHead;
  }
}