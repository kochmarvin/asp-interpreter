//-----------------------------------------------------------------------
// <copyright file="IsHeadlessVisitor.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.HeadLiterals;

/// <summary>
/// Visitor class to determine if a rule head is a headless head.
/// </summary>
public class IsHeadlessVisitor : HeadVisitor<bool>
{
  /// <summary>
  /// Visits a headless head and returns true, indicating the head is a headless.
  /// </summary>
  /// <param name="headless">The headless that is visited.</param>
  /// <returns>Whether the head is a headless.</returns>
  public override bool Visit(Headless headless)
  {
    ArgumentNullException.ThrowIfNull(headless, "Is not supposed to be null");

    return true;
  }
}