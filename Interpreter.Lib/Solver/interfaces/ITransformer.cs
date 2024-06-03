//-----------------------------------------------------------------------
// <copyright file="ITransformer.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Solver.Interfaces;

using Interpreter.Lib.Results.Objects.Atoms;

/// <summary>
/// Interface for the transformer.
/// </summary>
public interface ITransformer
{
  /// <summary>
  /// Transformes the given preperation into an integer format.
  /// </summary>
  /// <param name="preperation">The preperation that is being transformed.</param>
  /// <returns>The transformed preperation.</returns>
  public List<List<int>> TransformToFormular(Preperation preperation);

  /// <summary>
  /// Transformes the results back to the list of list of atoms.
  /// </summary>
  /// <param name="results">The results that are being transformed.</param>
  /// <returns>The retransformed results.</returns>
  public List<List<Atom>> ReTransform(List<List<int>> results);
}