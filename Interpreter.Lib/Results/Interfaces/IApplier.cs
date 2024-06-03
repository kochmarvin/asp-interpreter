//-----------------------------------------------------------------------
// <copyright file="IApplier.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Interfaces;

using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// Interface to Apply substitution and return a type T.
/// </summary>
/// <typeparam name="T">The object which gets applied on.</typeparam>
public interface IApplier<T>
{
  /// <summary>
  /// Applys a substitution and returns a type T.
  /// </summary>
  /// <param name="substitutions">The substitutions to be applied.</param>
  /// <returns>The applied object of type T.</returns>
  T Apply(Dictionary<string, Term> substitutions);
}