//-----------------------------------------------------------------------
// <copyright file="IBodyAddToGraph.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Interfaces;

using Interpreter.Lib.Results.Objects.BodyLiterals;

/// <summary>
/// Interface to get the order integer of a specific body.
/// </summary>
public interface IBodyAddToGraph
{
  /// <summary>
  /// Adds a literal body to the graph.
  /// </summary>
  /// <param name="literalBody">The literal body that is to be added.</param>
  void AddToGraph(LiteralBody literalBody);
}