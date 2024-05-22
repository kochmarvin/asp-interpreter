//-----------------------------------------------------------------------
// <copyright file="IsLiteral.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Objects.Literals;

using Interpreter.Lib.Results.Enums;
using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// The is Literal to calculate things.
/// </summary>
/// <param name="newVar">The new var which will get the result.</param>
/// <param name="left">The left side of the operation.</param>
/// <param name="op">The operator.</param>
/// <param name="right">The right side of the opreation.</param>
public class IsLiteral : Literal
{
  private Variable newVar;
  private Term left;
  private Term right;

  /// <summary>
  /// Initializes a new instance of the <see cref="IsLiteral"/> class.
  /// </summary>
  /// <param name="newVar">The variable representing the result of the operation.</param>
  /// <param name="left">The left term of the operation.</param>
  /// <param name="op">The operation executed in the terms.</param>
  /// <param name="right">The right term of the operation.</param>
  public IsLiteral(Variable newVar, Term left, Operator op, Term right)
  {
    this.Operator = op;
    this.Right = right;
    this.Left = left;
    this.New = newVar;
  }

  /// <summary>
  /// Gets the result of the terms variable given from the is literal.
  /// </summary>
  public Variable New
  {
    get
    {
      return this.newVar;
    }

    private set
    {
      this.newVar = value ?? throw new ArgumentNullException(nameof(this.New), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Gets the left term of the is literal.
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
  /// Gets the operator between the terms of the literal.
  /// </summary>
  public Operator Operator
  {
    get;
    private set;
  }

  /// <summary>
  /// Gets the right term of the literal.
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
  /// Accepts an instance of literal visitor and executes it, returning a type of T.
  /// </summary>
  /// <typeparam name="T">The type of the object that is excepted.</typeparam>
  /// <param name="visitor">The visitor that is executed.</param>
  /// <returns>The excepted object of type T.</returns>
  public override T? Accept<T>(LiteralVisitor<T> visitor)
    where T : default
  {
    return visitor.Visit(this);
  }

  /// <summary>
  /// Adds the literal to the graph using an interface.
  /// </summary>
  /// <param name="literalAddToGraph">The interface used to add the literal to the graph.</param>
  public override void AddToGraph(ILiteralAddToGraph literalAddToGraph)
  {
    return;
  }

  /// <summary>
  /// Applies the substiution to the object.
  /// </summary>
  /// <param name="substitutions">The found subsitituions.</param>
  /// <returns>A new object instance.</returns>
  public override Literal Apply(Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    Term appliedLeft = this.Left.Apply(substitutions);
    Term appliedRight = this.Right.Apply(substitutions);
    return new IsLiteral(this.New, appliedLeft, this.Operator, appliedRight);
  }

  /// <summary>
  /// Gets all of the atom of this literal.
  /// </summary>
  /// <returns>A list of all the atom in the literal.</returns>
  public override List<Atom> GetLiteralAtoms()
  {
    return [];
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
  /// Returns all the variables of the object as a list.
  /// </summary>
  /// <returns>The available variables.</returns>
  public override string ToString()
  {
    return $"{this.New} is {this.Left}{OperatorExtension.ToSymbol(this.Operator)}{this.Right}";
  }
}