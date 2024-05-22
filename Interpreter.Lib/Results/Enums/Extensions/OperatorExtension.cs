//-----------------------------------------------------------------------
// <copyright file="OperatorExtension.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Enums;

/// <summary>
/// Opertor extension for the Operator enum.
/// </summary>
public static class OperatorExtension
{
  /// <summary>
  /// Returns the corresponding symbol of the operator relation.
  /// </summary>
  /// <param name="relation">the relation you want the symbol from.</param>
  /// <returns>The relation as string.</returns>
  /// <exception cref="NotImplementedException">If you enter a operator which is not supported.</exception>
  public static string ToSymbol(this Operator relation)
  {
    return relation switch
    {
      Operator.PLUS => "+",
      Operator.MINUS => "-",
      Operator.DIVIDE => "/",
      Operator.MULTIPLY => "*",
      _ => throw new NotImplementedException(),
    };
  }
}