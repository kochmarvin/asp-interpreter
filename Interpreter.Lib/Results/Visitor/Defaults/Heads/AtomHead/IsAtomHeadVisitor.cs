//-----------------------------------------------------------------------
// <copyright file="IsAtomHeadVisitor.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.HeadLiterals;

/// <summary>
/// Visitor class to determine if a rule head is an AtomHead.
/// </summary>
public class IsAtomHeadVisitor : HeadVisitor<bool>
{
  /// <summary>
  /// Visits an AtomHead and returns true, indicating the head is an AtomHead.
  /// </summary>
  /// <param name="atomHead">The AtomHead to visit.</param>
  /// <returns>Whether the head is an AtomHead.</returns>
  public override bool Visit(AtomHead atomHead)
  {
    ArgumentNullException.ThrowIfNull(atomHead, "Is not supposed to be null");

    return true;
  }
}