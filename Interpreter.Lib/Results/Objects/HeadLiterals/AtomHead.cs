//-----------------------------------------------------------------------
// <copyright file="AtomHead.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Objects.HeadLiterals;

using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// Represents the head that contains an atom.
/// </summary>
public class AtomHead : Head
{
  private Atom atom;

  /// <summary>
  /// Initializes a new instance of the <see cref="AtomHead"/> class.
  /// </summary>
  /// <param name="atom">The atom contained in teh head.</param>
  public AtomHead(Atom atom)
  {
    this.Atom = atom;
  }

  /// <summary>
  /// Gets the atom contained in the head.
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
  /// Applies the given substitutions on the atom of the head.
  /// </summary>
  /// <param name="substitutions">The substitutions that are applied.</param>
  /// <returns>An applied head.</returns>
  public override Head Apply(Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    return new AtomHead(this.Atom.Apply(substitutions));
  }

  /// <summary>
  /// Gets all of the atoms of the head.
  /// </summary>
  /// <returns>A list of all atoms contained in the head.</returns>
  public override List<Atom> GetHeadAtoms()
  {
    return [this.Atom];
  }

  /// <summary>
  /// Gets all of the variables out of the head.
  /// </summary>
  /// <returns>A list of all the variables contained in the head.</returns>
  public override List<string> GetVariables()
  {
    return this.Atom.GetVariables();
  }

  /// <summary>
  /// Checks whether the head has any variables.
  /// </summary>
  /// <returns>Whether the head has any variables.</returns>
  public override bool HasVariables()
  {
    return this.Atom.HasVariables();
  }

  /// <summary>
  /// Checks whether the head contains a specific variable.
  /// </summary>
  /// <param name="variable">The variable to be checked.</param>
  /// <returns>Whether the specific is contained in the head.</returns>
  public override bool HasVariables(string variable)
  {
    return this.Atom.HasVariables(variable);
  }

  /// <summary>
  /// Represents the atom head as a string.
  /// </summary>
  /// <returns>The converted representation as a string.</returns>
  public override string ToString()
  {
    return this.Atom.ToString() + " ";
  }

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
}