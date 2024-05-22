//-----------------------------------------------------------------------
// <copyright file="IsChoiceHeadVisitor.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.HeadLiterals;

/// <summary>
/// Visitor class to determine if a rule head is a ChoiceHead.
/// </summary>
public class IsChoiceHeadVisitor : HeadVisitor<bool>
{
  /// <summary>
  /// Visits a ChoiceHead and returns true, indicating the head is a ChoiceHead.
  /// </summary>
  /// <param name="choiceHead">The choice head that is visited.</param>
  /// <returns>Whether the head is a choice head.</returns>
  public override bool Visit(ChoiceHead choiceHead)
  {
    ArgumentNullException.ThrowIfNull(choiceHead, "Is not supposed to be null");

    return true;
  }
}