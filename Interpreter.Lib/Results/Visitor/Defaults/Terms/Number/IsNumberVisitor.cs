//-----------------------------------------------------------------------
// <copyright file="IsNumberVisitor.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// Visitor to determin if the term is a number.
/// </summary>
public class IsNumberVisitor : TermVisitor<bool>
{
  /// <summary>
  /// Checking if the given term is a number.
  /// </summary>
  /// <param name="number">The number term that is visited.</param>
  /// <returns>Whether the term is a number.</returns>
  public override bool Visit(Number number)
  {
    ArgumentNullException.ThrowIfNull(number, "Is not supposed to be null");

    return true;
  }
}