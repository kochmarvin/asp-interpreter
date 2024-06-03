//-----------------------------------------------------------------------
// <copyright file="IGroundMatcher.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// An interface for matching ground literals with substitutions.
/// </summary>
public interface IGroundMatcher
{
  /// <summary>
  /// Matches an atom literal with the given substitutions.
  /// </summary>
  /// <param name="substitutions">The current substitutions dictionary.</param>
  /// <param name="atomLiteral">The atom literal to be matched.</param>
  /// <returns>A list of dictionaries containing the new substitutions after matching the atom literal.</returns>
  List<Dictionary<string, Term>> MatchAtomLiteral(Dictionary<string, Term> substitutions, AtomLiteral atomLiteral);

  /// <summary>
  /// Matches a comparison literal with the given substitutions.
  /// </summary>
  /// <param name="substitutions">The current substitutions dictionary.</param>
  /// <param name="comparisonLiteral">The comparison literal to be matched.</param>
  /// <returns>A list of dictionaries containing the new substitutions after matching the comparison literal.</returns>
  List<Dictionary<string, Term>> MatchComparisonLiteral(Dictionary<string, Term> substitutions, ComparisonLiteral comparisonLiteral);

  /// <summary>
  /// Matches an is literal with the given substitutions.
  /// </summary>
  /// <param name="substitutions">The current substitutions dictionary.</param>
  /// <param name="isLiteral">The is literal to be matched.</param>
  /// <returns>A list of dictionaries containing the new substitutions after matching the is literal.</returns>
  List<Dictionary<string, Term>> MatchIsLiteral(Dictionary<string, Term> substitutions, IsLiteral isLiteral);
}