//-----------------------------------------------------------------------
// <copyright file="ChoiceHead.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Objects.HeadLiterals;

using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// Represents the head that contains multiple atoms.
/// </summary>
public class ChoiceHead : Head
{
  private List<Atom> atoms;

  /// <summary>
  /// Initializes a new instance of the <see cref="ChoiceHead"/> class.
  /// </summary>
  /// <param name="atoms">The list of atoms contained in teh choice.</param>
  public ChoiceHead(List<Atom> atoms)
  {
    this.Atoms = atoms;
  }

  /// <summary>
  /// Gets the list of atoms contained in the head.
  /// </summary>
  public List<Atom> Atoms
  {
    get
    {
      return this.atoms;
    }

    private set
    {
      this.atoms = value ?? throw new ArgumentNullException(nameof(this.Atoms), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Applies the substitutions given to the head and returns an applied object.
  /// </summary>
  /// <param name="substitutions">The substitutions that the head atoms are applied.</param>
  /// <returns>The newly applied choice head.</returns>
  public override Head Apply(Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    var appliedChoices = this.Atoms.Select(atom => atom.Apply(substitutions)).ToList();
    return new ChoiceHead(appliedChoices);
  }

  /// <summary>
  /// Gets all of the atoms contained in the head.
  /// </summary>
  /// <returns>A list of all of the atoms.</returns>
  public override List<Atom> GetHeadAtoms()
  {
    return this.Atoms;
  }

  /// <summary>
  /// Gets all of the variables contained in the choice head.
  /// </summary>
  /// <returns>A list of all of the variables contained in the choice head.</returns>
  public override List<string> GetVariables()
  {
    List<string> vars = [];

    foreach (var atom in this.Atoms)
    {
      vars.AddRange(atom.GetVariables());
    }

    return vars;
  }

  /// <summary>
  /// Checks whether the choice head has any variables.
  /// </summary>
  /// <returns>Whether the choice head has any variables.</returns>
  public override bool HasVariables()
  {
    foreach (var atom in this.Atoms)
    {
      if (atom.HasVariables())
      {
        return true;
      }
    }

    return false;
  }

  /// <summary>
  /// Checks whether the choice head has a specific variable.
  /// </summary>
  /// <param name="variable">The variable that is to be checked.</param>
  /// <returns>Whether the variable is contained.</returns>
  public override bool HasVariables(string variable)
  {
    foreach (var atom in this.Atoms)
    {
      if (atom.HasVariables(variable))
      {
        return true;
      }
    }

    return false;
  }

  /// <summary>
  /// Generates the string representation of the choice head.
  /// </summary>
  /// <returns>The string representation of the choice head.</returns>
  public override string ToString()
  {
    var headString = this.Atoms.Select(bl => bl.ToString());
    return "{" + $"{string.Join("; ", headString)}" + "} ";
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