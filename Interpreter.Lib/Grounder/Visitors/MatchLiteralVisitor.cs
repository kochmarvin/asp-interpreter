//-----------------------------------------------------------------------
// <copyright file="MatchLiteralVisitor.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// A visitor class for finding matches for literals.
/// </summary>
public class MatchLiteralVisitor : LiteralVisitor<List<Dictionary<string, Term>>>
{
  private IGroundMatcher groundMatcher;
  private Dictionary<string, Term> substitutions;

  /// <summary>
  /// Initializes a new instance of the <see cref="MatchLiteralVisitor"/> class.
  /// </summary>
  /// <param name="substitutions">The substituions that are going to be matched.</param>
  /// <param name="groundMatcher">The grouning matcher for this visitor.</param>
  public MatchLiteralVisitor(Dictionary<string, Term> substitutions, IGroundMatcher groundMatcher)
  {
    this.GroundMatcher = groundMatcher;
    this.Substitutions = substitutions;
  }

  /// <summary>
  /// Gets the interface of the ground matcher for the visitor.
  /// </summary>
  public IGroundMatcher GroundMatcher
  {
    get
    {
      return this.groundMatcher;
    }

    private set
    {
      this.groundMatcher = value ?? throw new ArgumentNullException(nameof(this.GroundMatcher) + "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Gets the dictionary of substitutions for the visitor.
  /// </summary>
  public Dictionary<string, Term> Substitutions
  {
    get
    {
      return this.substitutions;
    }

    private set
    {
      this.substitutions = value ?? throw new ArgumentNullException(nameof(this.Substitutions) + "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Visits a literal body and tries to match it.
  /// </summary>
  /// <param name="literalBody">The literal body to be matched.</param>
  /// <returns>A list of dictionaries containing the new substitutions after matching the literal body.</returns>
  /// <exception cref="InvalidOperationException">Thrown when trying to match a literal which is not supported.</exception>
  public override List<Dictionary<string, Term>> Visit(LiteralBody literalBody)
  {
    ArgumentNullException.ThrowIfNull(literalBody, "Is not supposed to be null");

    return literalBody.Literal.Accept(this) ?? throw new InvalidOperationException("Trying to match a literal which is not supported");
  }

  /// <summary>
  /// Visits an atom literal and tries to match it.
  /// </summary>
  /// <param name="atomLiteral">The atom literal to be matched.</param>
  /// <returns>A list of dictionaries containing the new substitutions after matching the atom literal.</returns>
  public override List<Dictionary<string, Term>> Visit(AtomLiteral atomLiteral)
  {
    ArgumentNullException.ThrowIfNull(atomLiteral, "Is not supposed to be null");

    return this.GroundMatcher.MatchAtomLiteral(this.Substitutions, atomLiteral);
  }

  /// <summary>
  /// Visits a comparison literal and tries to match it.
  /// </summary>
  /// <param name="comparisonLiteral">The comparison literal to be matched.</param>
  /// <returns>A list of dictionaries containing the new substitutions after matching the comparison literal.</returns>
  public override List<Dictionary<string, Term>> Visit(ComparisonLiteral comparisonLiteral)
  {
    ArgumentNullException.ThrowIfNull(comparisonLiteral, "Is not supposed to be null");

    return this.GroundMatcher.MatchComparisonLiteral(this.Substitutions, comparisonLiteral);
  }

  /// <summary>
  /// Visits an is literal and tries to match it.
  /// </summary>
  /// <param name="isLiteral">The is literal to be matched.</param>
  /// <returns>A list of dictionaries containing the new substitutions after matching the is literal.</returns>
  public override List<Dictionary<string, Term>> Visit(IsLiteral isLiteral)
  {
    ArgumentNullException.ThrowIfNull(isLiteral, "Is not supposed to be null");

    return this.GroundMatcher.MatchIsLiteral(this.Substitutions, isLiteral);
  }
}