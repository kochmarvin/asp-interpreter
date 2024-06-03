//-----------------------------------------------------------------------
// <copyright file="Headless.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Objects.HeadLiterals;

using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// Represents the head of a rule that does not contain a head.
/// </summary>
public class Headless : Head
{
  /// <summary>
  /// Accepts an instance of head visitor and executes it, returning a type of T.
  /// </summary>
  /// <typeparam name="T">The type of the object that is excepted.</typeparam>
  /// <param name="visitor">The visitor that is executed.</param>
  /// <returns>The excepted object of type T.</returns>
  public override T? Accept<T>(HeadVisitor<T> visitor)
    where T : default
  {
    return visitor.Visit(this);
  }

  /// <summary>
  /// Applies the substitutions given to the head.
  /// </summary>
  /// <param name="substitutions">The substitutions that are being applied.</param>
  /// <returns>A newly applied head.</returns>
  public override Head Apply(Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    return this;
  }

  /// <summary>
  /// Returns all of the atoms contained in the headless.
  /// </summary>
  /// <returns>An empty list.</returns>
  public override List<Atom> GetHeadAtoms()
  {
    return [];
  }

  /// <summary>
  /// Gets all of the variables of the headless.
  /// </summary>
  /// <returns>An empty list.</returns>
  public override List<string> GetVariables()
  {
    return [];
  }

  /// <summary>
  /// Whether the headless has any variables.
  /// </summary>
  /// <returns>Returns false.</returns>
  public override bool HasVariables()
  {
    return false;
  }

  /// <summary>
  /// Whether a specific variable is contained in the headless.
  /// </summary>
  /// <param name="variable">The variable that is checked.</param>
  /// <returns>Returns false.</returns>
  public override bool HasVariables(string variable)
  {
    return false;
  }

  /// <summary>
  /// Convertes the headless into a string representation.
  /// </summary>
  /// <returns>An empty string.</returns>
  public override string ToString()
  {
    return string.Empty;
  }
}