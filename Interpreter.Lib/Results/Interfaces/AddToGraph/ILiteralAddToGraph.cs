//-----------------------------------------------------------------------
// <copyright file="ILiteralAddToGraph.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Interfaces;

using Interpreter.Lib.Results.Objects.Literals;

/// <summary>
/// Interface to get the order integer of a specific literal.
/// </summary>
public interface ILiteralAddToGraph
{
  /// <summary>
  /// Adds a specific atom literal to the graph.
  /// </summary>
  /// <param name="atomLiteral">The atom literal that is to be added.</param>
  void AddToGraph(AtomLiteral atomLiteral);
}