//-----------------------------------------------------------------------
// <copyright file="IMatch.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Interfaces;

using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// Interface to return the matches found of a specific object.
/// </summary>
/// <typeparam name="T">The type of the object which gets matched.</typeparam>
public interface IMatch<T>
{
  /// <summary>
  /// Checks whether matches of a specific object was found in the substitutions.
  /// </summary>
  /// <param name="other">The object which gets matched.</param>
  /// <param name="substitutions">The substitutions that the object is matched on.</param>
  /// <returns>Whether the given object has a match in the substitutions.</returns>
  public bool Match(T other, Dictionary<string, Term> substitutions);
}