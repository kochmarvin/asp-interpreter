//-----------------------------------------------------------------------
// <copyright file="Body.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Objects.BodyLiterals;

using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// The abstract class of the body of a program rule.
/// </summary>
public abstract class Body : IApplier<Body>, IHasVariables, IGetVariables, IGetBodyAtoms, ILiteralAccept
{
  /// <summary>
  /// Applies the substitutions to the body.
  /// </summary>
  /// <param name="substitutions">The substitutions that are being applied.</param>
  /// <returns>The applied body.</returns>
  public abstract Body Apply(Dictionary<string, Term> substitutions);

  /// <summary>
  /// Gets all of the variables of the body.
  /// </summary>
  /// <returns>A list of all variables of contained in the body.</returns>
  public abstract List<string> GetVariables();

  /// <summary>
  /// Checks if the body has any variables.
  /// </summary>
  /// <returns>Whether the body has any variables.</returns>
  public abstract bool HasVariables();

  /// <summary>
  /// Checks whether a specific variable if contained in the body.
  /// </summary>
  /// <param name="variable">The variable to be checked.</param>
  /// <returns>Whether the given variable is contained in the body.</returns>
  public abstract bool HasVariables(string variable);

  /// <summary>
  /// The method that converts the body into a string.
  /// </summary>
  /// <returns>The string representation of the body.</returns>
  public override string? ToString()
  {
    return base.ToString();
  }

  /// <summary>
  /// Adds this body to the graph using the add body to graph interface.
  /// </summary>
  /// <param name="addToGraphVisitor">The given interface with which the body is added to the graoh.</param>
  public abstract void AddToGraph(IBodyAddToGraph addToGraphVisitor);

  /// <summary>
  /// Gets all of the atom of the body and returns them.
  /// </summary>
  /// <returns>A list of all of the atoms contained in the body.</returns>
  public abstract List<Atom> GetBodyAtoms();

  /// <summary>
  /// Accepts an instance of literal visitor and executes it, returning a type of T.
  /// </summary>
  /// <typeparam name="T">The type of the object that is excepted.</typeparam>
  /// <param name="visitor">The visitor that is executed.</param>
  /// <returns>The excepted object of type T.</returns>
  public abstract T? Accept<T>(LiteralVisitor<T> visitor);
}