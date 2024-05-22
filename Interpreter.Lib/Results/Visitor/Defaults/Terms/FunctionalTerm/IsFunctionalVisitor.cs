//-----------------------------------------------------------------------
// <copyright file="IsFunctionalVisitor.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// Visitor class to determine if a term is a FunctionTerm.
/// </summary>
public class IsFunctionalVisitor : TermVisitor<bool>
{
  /// <summary>
  /// Checking whether the FunctionTerm is a function term.
  /// </summary>
  /// <param name="functionTerm">The function term to be checked.</param>
  /// <returns>Whether the term is a function term.</returns>
  public override bool Visit(FunctionTerm functionTerm)
  {
    ArgumentNullException.ThrowIfNull(functionTerm, "Is not supposed to be null");

    return true;
  }
}