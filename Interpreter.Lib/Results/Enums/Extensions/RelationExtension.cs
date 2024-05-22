//-----------------------------------------------------------------------
// <copyright file="RelationExtension.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Enums;

/// <summary>
/// Relation extension for the Relation enum.
/// </summary>
public static class RelationExtension
{
  /// <summary>
  /// Returns the corresponding symbol of the relation.
  /// </summary>
  /// <param name="relation">the relation you want the symbol from.</param>
  /// <returns>The relation as string.</returns>
  /// <exception cref="NotImplementedException">If you enter a relation which is not supported.</exception>
  public static string ToSymbol(this Relation relation)
  {
    return relation switch
    {
      Relation.LessThan => "<",
      Relation.LessEqual => "<=",
      Relation.GreaterThan => ">",
      Relation.GreaterEqual => ">=",
      Relation.Unification => "=",
      Relation.Equal => "==",
      Relation.Inequal => "!=",
      _ => throw new NotImplementedException(),
    };
  }
}