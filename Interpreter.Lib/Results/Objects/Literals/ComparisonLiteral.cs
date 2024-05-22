//-----------------------------------------------------------------------
// <copyright file="ComparisonLiteral.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Objects.Literals;

using Interpreter.Lib.Results.Enums;
using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// Literal for a comparison or a unification.
/// </summary>
/// <param name="left">The left side of the compairrison.</param>
/// <param name="relation">The relation of the comparisson.</param>
/// <param name="right">The right side of the comparisson.</param>
public class ComparisonLiteral : Literal
{
  private Term left;
  private Term right;
  private Relation relation;

  /// <summary>
  /// Initializes a new instance of the <see cref="ComparisonLiteral"/> class.
  /// </summary>
  /// <param name="left">The left term of the comparison.</param>
  /// <param name="relation">The relation between the terms.</param>
  /// <param name="right">The right term of the comparison.</param>
  public ComparisonLiteral(Term left, Relation relation, Term right)
  {
    this.Left = left;
    this.TermRelation = relation;
    this.Right = right;
  }

  /// <summary>
  /// Gets the left term of the comparison literal.
  /// </summary>
  public Term Left
  {
    get
    {
      return this.left;
    }

    private set
    {
      this.left = value ?? throw new ArgumentNullException(nameof(this.Left), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Gets the term relation between the terms.
  /// </summary>
  public Relation TermRelation
  {
    get
    {
      return this.relation;
    }

    private set
    {
      this.relation = value;
    }
  }

  /// <summary>
  /// Gets the right term of the comparison literal.
  /// </summary>
  public Term Right
  {
    get
    {
      return this.right;
    }

    private set
    {
      this.right = value ?? throw new ArgumentNullException(nameof(this.Right), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Applies the substiution to the object.
  /// </summary>
  /// <param name="substitutions">The found subsitituions.</param>
  /// <returns>A new object instance.</returns>
  public override Literal Apply(Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions);

    Term appliedLeft = this.Left.Apply(substitutions);
    Term appliedRight = this.Right.Apply(substitutions);
    return new ComparisonLiteral(appliedLeft, this.TermRelation, appliedRight);
  }

  /// <summary>
  /// Returns all the variables of the object as a list.
  /// </summary>
  /// <returns>The available variables.</returns>
  public override List<string> GetVariables()
  {
    return [.. this.Left.GetVariables(), .. this.Right.GetVariables()];
  }

  /// <summary>
  /// Checks if the object has any varibles.
  /// </summary>
  /// <returns>Either if there are variables or not.</returns>
  public override bool HasVariables()
  {
    return this.Left.HasVariables() || this.Right.HasVariables();
  }

  /// <summary>
  /// Checks if the object has a specific variable.
  /// </summary>
  /// <param name="variable">The variable to be checked.</param>
  /// <returns>Either if it includes the variable or not.</returns>
  public override bool HasVariables(string variable)
  {
    return this.Left.HasVariables(variable) || this.Right.HasVariables(variable);
  }

  /// <summary>
  /// Basic to string method.
  /// </summary>
  /// <returns>The string equivalent.</returns>
  public override string ToString()
  {
    return $"{this.Left}{RelationExtension.ToSymbol(this.TermRelation)}{this.Right}";
  }

  /// <summary>
  /// Gets all of the atom of the comparison literal.
  /// </summary>
  /// <returns>An empty list.</returns>
  public override List<Atom> GetLiteralAtoms()
  {
    return [];
  }

  /// <summary>
  /// Adds the literal to the graph using the interface.
  /// </summary>
  /// <param name="literalAddToGraph">The interface used to add the literal.</param>
  public override void AddToGraph(ILiteralAddToGraph literalAddToGraph)
  {
    return;
  }

  /// <summary>
  /// Accepts an instance of head visitor and executes it, returning a type of T.
  /// </summary>
  /// <typeparam name="T">The type of the object that is excepted.</typeparam>
  /// <param name="visitor">The visitor that is executed.</param>
  /// <returns>The excepted object of type T.</returns>
  public override T? Accept<T>(LiteralVisitor<T> visitor)
    where T : default
  {
    return visitor.Visit(this);
  }
}