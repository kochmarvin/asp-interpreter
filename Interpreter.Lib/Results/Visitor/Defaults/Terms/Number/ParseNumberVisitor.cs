//-----------------------------------------------------------------------
// <copyright file="ParseNumberVisitor.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// Visitor class to parse and return a Number.
/// </summary>
public class ParseNumberVisitor : TermVisitor<Number>
{
  /// <summary>
  /// Visits a term and returns a visited number.
  /// </summary>
  /// <param name="number">The number to visit.</param>
  /// <returns>The parsed number.</returns>
  public override Number Visit(Number number)
  {
    ArgumentNullException.ThrowIfNull(number, "Is not supposed to be null");

    return number;
  }
}