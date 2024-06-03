//-----------------------------------------------------------------------
// <copyright file="AddToGraphVisitor.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;

/// <summary>
/// The abstarct class representing a visitor that adds elements to a graph.
/// </summary>
public abstract class AddToGraphVisitor : IAddToGraphVisitor
{
  private Action<ProgramRule, Atom> action;
  private ProgramRule rule;

  /// <summary>
  /// Initializes a new instance of the <see cref="AddToGraphVisitor"/> class.
  /// </summary>
  public AddToGraphVisitor()
  {
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="AddToGraphVisitor"/> class.
  /// </summary>
  /// <param name="rule">The rule assosiated with the visitor.</param>
  /// <param name="action">The action to perform when adding an atom to the graph.</param>
  /// <param name="onlyPositves">Whether only positiv literals should be added to the graph.</param>
  public AddToGraphVisitor(ProgramRule rule, Action<ProgramRule, Atom> action, bool onlyPositves)
  {
    this.Rule = rule;
    this.Action = action;
    this.OnlyPositives = onlyPositves;
  }

  /// <summary>
  /// Gets a value indicating whether only positive literals should be added to the graph.
  /// </summary>
  public bool OnlyPositives
  {
    get;
    private set;
  }

  /// <summary>
  /// Gets the action to be performed when adding an Atom to the graph.
  /// </summary>
  public Action<ProgramRule, Atom> Action
  {
    get
    {
      return this.action;
    }

    private set
    {
      this.action = value ?? throw new ArgumentNullException(nameof(this.Action) + "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Gets the rule associated with the visitor.
  /// </summary>
  public ProgramRule Rule
  {
    get
    {
      return this.rule;
    }

    private set
    {
      this.rule = value ?? throw new ArgumentNullException(nameof(this.Rule) + "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Creates a new instance of the <see cref="AddToGraphVisitor"/> class with the specified rule, action, and positivity filter.
  /// </summary>
  /// <param name="rule">The rule associated with the new instance.</param>
  /// <param name="action">The action to perform when adding an Atom to the graph.</param>
  /// <param name="onlyPositves">Whether only positive literals should be added to the graph.</param>
  /// <returns>A new insatnce of the add to graph visitor class.</returns>
  public abstract AddToGraphVisitor CreateInstance(ProgramRule rule, Action<ProgramRule, Atom> action, bool onlyPositves);

  /// <summary>
  /// Adds a new atom literal to the graph.
  /// </summary>
  /// <param name="atomLiteral">The atom that is getting added to the graph.</param>
  public abstract void AddToGraph(AtomLiteral atomLiteral);

  /// <summary>
  /// Adds a new literal body to the graph.
  /// </summary>
  /// <param name="literalBody">The literal that is getting added to the graph.</param>
  public abstract void AddToGraph(LiteralBody literalBody);
}