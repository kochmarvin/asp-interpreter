//-----------------------------------------------------------------------
// <copyright file="Literal.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Objects.Literals;

using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// Abstract Class for a Literal.
/// </summary>
public abstract class Literal : IApplier<Literal>, IHasVariables, IGetVariables, IGetLiteralAtoms, ILiteralAccept
{
  /// <summary>
  /// Applies the substiution to the object.
  /// </summary>
  /// <param name="substitutions">The found subsitituions.</param>
  /// <returns>A new object instance.</returns>
  public abstract Literal Apply(Dictionary<string, Term> substitutions);

  /// <summary>
  /// Gets all of the atoms out of the literal.
  /// </summary>
  /// <returns>A list of all the atoms of the literal.</returns>
  public abstract List<Atom> GetLiteralAtoms();

  /// <summary>
  /// Returns all the variables of the object as a list.
  /// </summary>
  /// <returns>The available variables.</returns>
  public abstract List<string> GetVariables();

  /// <summary>
  /// Checks if the object has any varibles.
  /// </summary>
  /// <returns>Either if there are variables or not.</returns>
  public abstract bool HasVariables();

  /// <summary>
  /// Checks if the object has a specific variable.
  /// </summary>
  /// <param name="variable">The variable to be checked.</param>
  /// <returns>Either if it includes the variable or not.</returns>
  public abstract bool HasVariables(string variable);

  /// <summary>
  /// Adds the literal to the graph using the interface.
  /// </summary>
  /// <param name="literalAddToGraph">The interface used to add the literal to the graph.</param>
  public abstract void AddToGraph(ILiteralAddToGraph literalAddToGraph);

  /// <summary>
  /// Basic to string method.
  /// </summary>
  /// <returns>The string equivalent.</returns>
  public override string? ToString()
  {
    return base.ToString();
  }

  /// <summary>
  /// Accepts an instance of literal visitor and executes it, returning a type of T.
  /// </summary>
  /// <typeparam name="T">The type of the object that is excepted.</typeparam>
  /// <param name="visitor">The visitor that is executed.</param>
  /// <returns>The excepted object of type T.</returns>
  public abstract T? Accept<T>(LiteralVisitor<T> visitor);
}