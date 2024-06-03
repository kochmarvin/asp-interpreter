//-----------------------------------------------------------------------
// <copyright file="CNFWrapper.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Solver;

using Interpreter.FunctionalLib;

/// <summary>
/// A simple wrapper to create an expression for the F# library,
/// was made due to the long namespace of the f# library.
/// </summary>
public class CNFWrapper
{
  private ConjunctiveNormalForm.Expression? expression;

  private CNFWrapper()
  {
    this.expression = null;
  }

  /// <summary>
  /// Creates a new instacnce of the CNF Wrapper.
  /// </summary>
  /// <returns>A new instance of the Wrapper.</returns>
  public static CNFWrapper NewExpression()
  {
    return new CNFWrapper();
  }

  /// <summary>
  /// Creaes a negative variable.
  /// </summary>
  /// <param name="index">the index of the variable.</param>
  /// <returns>The negative variable.</returns>
  public static ConjunctiveNormalForm.Expression CreateNegativeVariable(int index)
  {
    return ConjunctiveNormalForm.Expression.NewNot(CreateVariable(index));
  }

  /// <summary>
  /// Creates a new negative variable.
  /// </summary>
  /// <param name="variable">the value of the variable.</param>
  /// <returns>The negative variable.</returns>
  public static ConjunctiveNormalForm.Expression CreateNegativeVariable(ConjunctiveNormalForm.Expression variable)
  {
    ArgumentNullException.ThrowIfNull(variable, "Is not supposed to be null");

    return ConjunctiveNormalForm.Expression.NewNot(variable);
  }

  /// <summary>
  /// Creaes a variable.
  /// </summary>
  /// <param name="index">the index of the variable.</param>
  /// <returns>The  variable.</returns>
  public static ConjunctiveNormalForm.Expression CreateVariable(int index)
  {
    return ConjunctiveNormalForm.Expression.NewVar(index);
  }

  /// <summary>
  /// Sets the first expression to be an xor.
  /// </summary>
  /// <param name="left">The left side of the expression.</param>
  /// <param name="right">The right side of the expression.</param>
  /// <returns>The expression wrapper.</returns>
  public CNFWrapper SetXor(ConjunctiveNormalForm.Expression left, ConjunctiveNormalForm.Expression right)
  {
    ArgumentNullException.ThrowIfNull(left, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(right, "Is not supposed to be null");

    this.expression = ConjunctiveNormalForm.Expression.NewXor(left, right);
    return this;
  }

  /// <summary>
  /// Sets the first expression to be an or.
  /// </summary>
  /// <param name="left">The left side of the expression.</param>
  /// <param name="right">The right side of the expression.</param>
  /// <returns>The expression wrapper.</returns>
  public CNFWrapper SetOr(ConjunctiveNormalForm.Expression left, ConjunctiveNormalForm.Expression right)
  {
    ArgumentNullException.ThrowIfNull(left, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(right, "Is not supposed to be null");

    this.expression = ConjunctiveNormalForm.Expression.NewOr(left, right);
    return this;
  }

  /// <summary>
  /// Sets the first expression to be an and.
  /// </summary>
  /// <param name="left">The left side of the expression.</param>
  /// <param name="right">The right side of the expression.</param>
  /// <returns>The expression wrapper.</returns>
  public CNFWrapper SetAnd(ConjunctiveNormalForm.Expression left, ConjunctiveNormalForm.Expression right)
  {
    ArgumentNullException.ThrowIfNull(left, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(right, "Is not supposed to be null");

    this.expression = ConjunctiveNormalForm.Expression.NewAnd(left, right);
    return this;
  }

  /// <summary>
  /// Adds a new or to the existing expression.
  /// </summary>
  /// <param name="single">The expressin wich should get or connected.</param>
  /// <returns>The expression wrapper.</returns>
  public CNFWrapper AddOr(ConjunctiveNormalForm.Expression single)
  {
    ArgumentNullException.ThrowIfNull(single, "Is not supposed to be null");

    this.expression = ConjunctiveNormalForm.Expression.NewOr(this.expression, single);
    return this;
  }

  /// <summary>
  /// Adds a new and to the existing expression.
  /// </summary>
  /// <param name="single">The expressin wich should get and connected.</param>
  /// <returns>The expression wrapper.</returns>
  public CNFWrapper AddAnd(ConjunctiveNormalForm.Expression single)
  {
    ArgumentNullException.ThrowIfNull(single, "Is not supposed to be null");

    this.expression = ConjunctiveNormalForm.Expression.NewAnd(this.expression, single);
    return this;
  }

  /// <summary>
  /// Sets the first expression to be an implication.
  /// </summary>
  /// <param name="left">The left side of the expression.</param>
  /// <param name="right">The right side of the expression.</param>
  /// <returns>The expression wrapper.</returns>
  public CNFWrapper SetImplication(ConjunctiveNormalForm.Expression left, ConjunctiveNormalForm.Expression right)
  {
    ArgumentNullException.ThrowIfNull(left, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(right, "Is not supposed to be null");

    this.expression = ConjunctiveNormalForm.Expression.NewImplies(left, right);
    return this;
  }

  /// <summary>
  /// Sets the first expression to be an equality.
  /// </summary>
  /// <param name="left">The left side of the expression.</param>
  /// <param name="right">The right side of the expression.</param>
  /// <returns>The expression wrapper.</returns>
  public CNFWrapper SetEquality(ConjunctiveNormalForm.Expression left, ConjunctiveNormalForm.Expression right)
  {
    ArgumentNullException.ThrowIfNull(left, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(right, "Is not supposed to be null");

    this.expression = ConjunctiveNormalForm.Expression.NewEquiv(left, right);
    return this;
  }

  /// <summary>
  /// Finishes the expression and creates it.
  /// </summary>
  /// <returns>The created expression.</returns>
  /// <exception cref="InvalidOperationException">If you try to create a expriossson which is null.</exception>
  public ConjunctiveNormalForm.Expression Create()
  {
    if (this.expression == null)
    {
      throw new InvalidOperationException("You are trying to create an empty formula, which is not allowed");
    }

    return this.expression;
  }
}