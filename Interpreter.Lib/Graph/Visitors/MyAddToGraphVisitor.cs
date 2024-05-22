//-----------------------------------------------------------------------
// <copyright file="MyAddToGraphVisitor.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;

/// <summary>
/// A class representing a visitor that adds elements to a graph.
/// </summary>
public class MyAddToGraphVisitor : AddToGraphVisitor
{
  /// <summary>
  /// Initializes a new instance of the <see cref="MyAddToGraphVisitor"/> class.
  /// </summary>
  public MyAddToGraphVisitor()
  {
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="MyAddToGraphVisitor"/> class.
  /// </summary>
  /// <param name="rule">The rule assosiated with the visitor.</param>
  /// <param name="action">The action to perform when adding an atom to the graph.</param>
  /// <param name="onlyPositves">Whether only positiv literals should be added to the graph.</param>
  public MyAddToGraphVisitor(ProgramRule rule, Action<ProgramRule, Atom> action, bool onlyPositves)
    : base(rule, action, onlyPositves)
  {
  }

  /// <summary>
  /// Creates a new instance of the add to graph visitor.
  /// </summary>
  /// <param name="rule">The rule assosiated with the visitor.</param>
  /// <param name="action">The action to perform when adding an atom to the graph.</param>
  /// <param name="onlyPositves">Whether only positiv literals should be added to the graph.</param>
  /// <returns>A new instance of the add to graph visitor.</returns>
  public override AddToGraphVisitor CreateInstance(ProgramRule rule, Action<ProgramRule, Atom> action, bool onlyPositves)
  {
    return new MyAddToGraphVisitor(rule, action, onlyPositves);
  }

  /// <summary>
  /// Adds a new atom literal to the graph.
  /// </summary>
  /// <param name="atomLiteral">The atom literal that is to be added.</param>
  public override void AddToGraph(AtomLiteral atomLiteral)
  {
    if (atomLiteral.Positive || !this.OnlyPositives)
    {
      this.Action(this.Rule, atomLiteral.Atom);
    }
  }

  /// <summary>
  /// Adds a new literal body to the graph.
  /// </summary>
  /// <param name="literalBody">The literal body that is to be added.</param>
  public override void AddToGraph(LiteralBody literalBody)
  {
    literalBody.Literal.AddToGraph(this);
  }
}