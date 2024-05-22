//-----------------------------------------------------------------------
// <copyright file="ParseFunctionalVisitor.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// Visitor class to parse and return an FunctionTerm.
/// </summary>
public class ParseFunctionalVisitor : TermVisitor<FunctionTerm>
{
  /// <summary>
  /// Visits the given function term and returns it.
  /// </summary>
  /// <param name="functionTerm">The FunctionTerm that is visited.</param>
  /// <returns>The checked function term.</returns>
  public override FunctionTerm Visit(FunctionTerm functionTerm)
  {
    ArgumentNullException.ThrowIfNull(functionTerm, "Is not supposed to be null");

    return functionTerm;
  }
}