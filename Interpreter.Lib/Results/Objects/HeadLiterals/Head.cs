//-----------------------------------------------------------------------
// <copyright file="Head.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Objects.HeadLiterals;

using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// Represents the abstract class of the head of a program rule.
/// </summary>
public abstract class Head : IApplier<Head>, IHasVariables, IGetVariables, IGetHeadAtoms, IHeadAccept
{
  /// <summary>
  /// Accepts an instance of head visitor and executes it, returning a type of T.
  /// </summary>
  /// <typeparam name="T">The type of the object that is excepted.</typeparam>
  /// <param name="visitor">The visitor that is executed.</param>
  /// <returns>The excepted object of type T.</returns>
  public abstract T? Accept<T>(HeadVisitor<T> visitor);

  /// <summary>
  /// Applies the substiitutions to this specific head.
  /// </summary>
  /// <param name="substitutions">The substitutions that are applied.</param>
  /// <returns>The newly applied head.</returns>
  public abstract Head Apply(Dictionary<string, Term> substitutions);

  /// <summary>
  /// Gets all of the atoms of the head object.
  /// </summary>
  /// <returns>A list of all the atoms contained in the head.</returns>
  public abstract List<Atom> GetHeadAtoms();

  /// <summary>
  /// Gets all of the variables of the head.
  /// </summary>
  /// <returns>A list of all the variables of the head.</returns>
  public abstract List<string> GetVariables();

  /// <summary>
  /// Checks whether the head contains any variables.
  /// </summary>
  /// <returns>Whether the head has any variables.</returns>
  public abstract bool HasVariables();

  /// <summary>
  /// Checks whether the head contains a specific variable.
  /// </summary>
  /// <param name="variable">The specific variable that is to be checked.</param>
  /// <returns>Whether the vriable is contained in the head.</returns>
  public abstract bool HasVariables(string variable);

  /// <summary>
  /// Convertes the head into its string representattion.
  /// </summary>
  /// <returns>The string representing the head.</returns>
  public override string? ToString()
  {
    return base.ToString();
  }
}