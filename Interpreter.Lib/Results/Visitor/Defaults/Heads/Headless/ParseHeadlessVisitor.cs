//-----------------------------------------------------------------------
// <copyright file="ParseHeadlessVisitor.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.HeadLiterals;

/// <summary>
/// Visitor class to parse and return a Headless.
/// </summary>
public class ParseHeadlessVisitor : HeadVisitor<Headless>
{
  /// <summary>
  /// Visits a Headless and returns it.
  /// </summary>
  /// <param name="headless">The headless that is visited.</param>
  /// <returns>The visited headless.</returns>
  public override Headless Visit(Headless headless)
  {
    ArgumentNullException.ThrowIfNull(headless, "Is not supposed to be null");

    return headless;
  }
}