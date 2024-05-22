//-----------------------------------------------------------------------
// <copyright file="ParseVariableVisitor.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// Visitor class to parse and return a variable.
/// </summary>
public class ParseVariableVisitor : TermVisitor<Variable>
{
  /// <summary>
  /// Visits a term and returns a visited variable.
  /// </summary>
  /// <param name="variable">The variable to visit.</param>
  /// <returns>The parsed variable.</returns>
  public override Variable Visit(Variable variable)
  {
    ArgumentNullException.ThrowIfNull(variable, "Is not supposed to be null");

    return variable;
  }
}