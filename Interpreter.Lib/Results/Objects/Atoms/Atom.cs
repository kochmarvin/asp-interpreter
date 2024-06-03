//-----------------------------------------------------------------------
// <copyright file="Atom.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Objects.Atoms;

using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// The atom object of a rule, so every costrcut of hello(X) or hello(1, 1, 3).
/// </summary>
public class Atom : IMatch<Atom>, IApplier<Atom>, IHasVariables, IGetVariables
{
  private string name;
  private List<Term> args;

  /// <summary>
  /// Initializes a new instance of the <see cref="Atom"/> class.
  /// </summary>
  /// <param name="name">The name of the atom.</param>
  /// <param name="args">The arguments of the atom.</param>
  public Atom(string name, List<Term> args)
  {
    this.Name = name;
    this.Args = args;
  }

  /// <summary>
  /// Gets the name of the atom object.
  /// </summary>
  public string Name
  {
    get
    {
      return this.name;
    }

    private set
    {
      this.name = value ?? throw new ArgumentNullException(nameof(this.Name), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Gets the arguments of the atom object.
  /// </summary>
  public List<Term> Args
  {
    get
    {
      return this.args;
    }

    private set
    {
      this.args = value ?? throw new ArgumentNullException(nameof(this.Args), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Gets the signature of the atom e.g hello/2.
  /// </summary>
  public string Signature
  {
    get
    {
      return $"{this.Name}/{this.Args.Count}";
    }
  }

  /// <summary>
  /// Applies the substiution to the object.
  /// </summary>
  /// <param name="substitutions">The found subsitituions.</param>
  /// <returns>A new object instance.</returns>
  public Atom Apply(Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    var appliedArgs = this.Args.Select(arg => arg.Apply(substitutions)).ToList();
    return new Atom(this.Name, appliedArgs);
  }

  /// <summary>
  /// Checks whether this atoms string matches with the given atom.
  /// </summary>
  /// <param name="other">The atom that this class is compared to.</param>
  /// <returns>Whether the atom is equal to the given one or not.</returns>
  public bool Equals(Atom? other)
  {
    ArgumentNullException.ThrowIfNull(other, "Is not supposed to be null");

    return other?.ToString() == this.ToString();
  }

  /// <summary>
  /// Returns all the variables of the object as a list.
  /// </summary>
  /// <returns>The available variables.</returns>
  public List<string> GetVariables()
  {
    return this.Args.SelectMany(arg => arg.GetVariables()).ToList();
  }

  /// <summary>
  /// Checks if the object has any varibles.
  /// </summary>
  /// <returns>Either if there are variables or not.</returns>
  public bool HasVariables()
  {
    foreach (var term in this.Args)
    {
      if (term.HasVariables())
      {
        return true;
      }
    }

    return false;
  }

  /// <summary>
  /// Checks if the object has a specific variable.
  /// </summary>
  /// <param name="variable">The variable to be checked.</param>
  /// <returns>Either if it includes the variable or not.</returns>
  public bool HasVariables(string variable)
  {
    foreach (var term in this.Args)
    {
      if (term.HasVariables())
      {
        return true;
      }
    }

    return false;
  }

  /// <summary>
  /// Checks if two atoms are match.
  /// </summary>
  /// <param name="other">The atom you want to check if it is a match.</param>
  /// <param name="substitutions">The found substittuions.</param>
  /// <returns>Either if it is a match or not.</returns>
  public bool Match(Atom other, Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(other, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    if (this.Name != other.Name || this.Args.Count != other.Args.Count)
    {
      return false;
    }

    for (int i = 0; i < this.Args.Count; i++)
    {
      if (!this.Args[i].Match(other.Args[i], substitutions))
      {
        return false;
      }
    }

    return true;
  }

  /// <summary>
  /// Basic to string method.
  /// </summary>
  /// <returns>The string equivalent.</returns>
  public override string ToString()
  {
    if (this.Args.Count == 0)
    {
      return this.Name;
    }

    var argsString = string.Join(", ", this.Args.Select(arg => arg.ToString()));
    return $"{this.Name}({argsString})";
  }
}