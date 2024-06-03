//-----------------------------------------------------------------------
// <copyright file="AtomLiteral.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Objects.Literals;

using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// A basic Atom litereral so everything that is not hello(X) or just hello(X).
/// </summary>
public class AtomLiteral : Literal
{
  private bool positiv;
  private Atom atom;

  /// <summary>
  /// Initializes a new instance of the <see cref="AtomLiteral"/> class.
  /// </summary>
  /// <param name="positive">Whether the literal is positive or not.</param>
  /// <param name="atom">The atom of the literal.</param>
  public AtomLiteral(bool positive, Atom atom)
  {
    this.Positive = positive;
    this.Atom = atom;
  }

  /// <summary>
  /// Gets a value indicating whether the atom literal is positiv.
  /// </summary>
  public bool Positive
  {
    get
    {
      return this.positiv;
    }

    private set
    {
      this.positiv = value;
    }
  }

  /// <summary>
  /// Gets the atom contained in the literal.
  /// </summary>
  public Atom Atom
  {
    get
    {
      return this.atom;
    }

    private set
    {
      this.atom = value ?? throw new ArgumentNullException(nameof(this.Atom), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Accepts an instance of literal visitor and executes it, returning a type of T.
  /// </summary>
  /// <typeparam name="T">The type of the object taht is accepted.</typeparam>
  /// <param name="visitor">The visitor that is executed.</param>
  /// <returns>The excepted object of type T.</returns>
  public override T? Accept<T>(LiteralVisitor<T> visitor)
    where T : default
  {
    ArgumentNullException.ThrowIfNull(visitor, "Is not supposed to be null");
    return visitor.Visit(this);
  }

  /// <summary>
  /// Adds the atom literal to the graph using the given interface.
  /// </summary>
  /// <param name="literalAddToGraph">The interface that adds the literal.</param>
  public override void AddToGraph(ILiteralAddToGraph literalAddToGraph)
  {
    ArgumentNullException.ThrowIfNull(literalAddToGraph, "Is not supposed to be null");
    literalAddToGraph.AddToGraph(this);
  }

  /// <summary>
  /// Applies the substiution to the object.
  /// </summary>
  /// <param name="substitutions">The found subsitituions.</param>
  /// <returns>A new object instance.</returns>
  public override Literal Apply(Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");
    Atom appliedAtom = this.Atom.Apply(substitutions);
    return new AtomLiteral(this.Positive, appliedAtom);
  }

  /// <summary>
  /// Gets all of the atom out of the literal.
  /// </summary>
  /// <returns>A list of all the atoms contained in the literal.</returns>
  public override List<Atom> GetLiteralAtoms()
  {
    return [this.Atom];
  }

  /// <summary>
  /// Returns all the variables of the object as a list.
  /// </summary>
  /// <returns>The available variables.</returns>
  public override List<string> GetVariables()
  {
    return this.Atom.GetVariables();
  }

  /// <summary>
  /// Checks if the object has any varibles.
  /// </summary>
  /// <returns>Either if there are variables or not.</returns>
  public override bool HasVariables()
  {
    return this.Atom.HasVariables();
  }

  /// <summary>
  /// Checks if the object has a specific variable.
  /// </summary>
  /// <param name="variable">The variable to be checked.</param>
  /// <returns>Either if it includes the variable or not.</returns>
  public override bool HasVariables(string variable)
  {
    return this.Atom.HasVariables(variable);
  }

  /// <summary>
  /// Basic to string method.
  /// </summary>
  /// <returns>The string equivalent.</returns>
  public override string ToString()
  {
    return $"{(this.Positive ? string.Empty : "not ")}{this.Atom}";
  }
}