//-----------------------------------------------------------------------
// <copyright file="IAddToGraphVisitor.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Interfaces;

using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Rule;

/// <summary>
/// The interface of the Add to graph visitor.
/// </summary>
public interface IAddToGraphVisitor : ILiteralAddToGraph, IBodyAddToGraph
{
  /// <summary>
  /// Gets a value indicating whether only positives should be added to the graph.
  /// </summary>
  public bool OnlyPositives { get; }

  /// <summary>
  /// Gets the action to perform when adding an atom to the graph.
  /// </summary>
  public Action<ProgramRule, Atom> Action { get; }

  /// <summary>
  /// Gets the rule assisiated with the visitor.
  /// </summary>
  public ProgramRule Rule { get; }
}