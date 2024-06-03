//-----------------------------------------------------------------------
// <copyright file="IsVariableVisitor.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// Visitor to determin if the term is a variable.
/// </summary>
public class IsVariableVisitor : TermVisitor<bool>
{
  /// <summary>
  /// Checking if the given term is a variable.
  /// </summary>
  /// <param name="variable">The term to be visited.</param>
  /// <returns>Whether the term is a variable.</returns>
  public override bool Visit(Variable variable)
  {
    ArgumentNullException.ThrowIfNull(variable, "Is not supposed to be null");

    return true;
  }
}