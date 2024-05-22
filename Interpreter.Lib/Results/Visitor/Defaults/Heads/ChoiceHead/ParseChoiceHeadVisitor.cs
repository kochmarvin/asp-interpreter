//-----------------------------------------------------------------------
// <copyright file="ParseChoiceHeadVisitor.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.HeadLiterals;

/// <summary>
/// Visitor class to parse and return a ChoiceHead.
/// </summary>
public class ParseChoiceHeadVisitor : HeadVisitor<ChoiceHead>
{
  /// <summary>
  /// Visits a ChoiceHead and returns it.
  /// </summary>
  /// <param name="choiceHead">The choice head to be visited.</param>
  /// <returns>The visited choice head.</returns>
  public override ChoiceHead Visit(ChoiceHead choiceHead)
  {
    ArgumentNullException.ThrowIfNull(choiceHead, "Is not supposed to be null");

    return choiceHead;
  }
}