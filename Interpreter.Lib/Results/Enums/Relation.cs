//-----------------------------------------------------------------------
// <copyright file="Relation.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Enums;

/// <summary>
/// Valid relation enumerator.
/// </summary>
public enum Relation
{
  /// <summary>
  /// The valid lessThan relation.
  /// </summary>
  LessThan,

  /// <summary>
  /// The valid less equal relation.
  /// </summary>
  LessEqual,

  /// <summary>
  /// The valid greater than relation.
  /// </summary>
  GreaterThan,

  /// <summary>
  /// The valid greater equal relation.
  /// </summary>
  GreaterEqual,

  /// <summary>
  /// The valid equal relation.
  /// </summary>
  Equal,

  /// <summary>
  /// The valid inequal relation.
  /// </summary>
  Inequal,

  /// <summary>
  /// The valid unification relation.
  /// </summary>
  Unification,
}