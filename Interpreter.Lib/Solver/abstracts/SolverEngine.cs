//-----------------------------------------------------------------------
// <copyright file="SolverEngine.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Solver.Abstracts;

using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Solver.Interfaces;

/// <summary>
/// Abstract class of a solver engine.
/// </summary>
public abstract class SolverEngine
{
  private IPreparer preparer;
  private ITransformer transformer;
  private ISolver solver;

  /// <summary>
  /// Initializes a new instance of the <see cref="SolverEngine"/> class.
  /// </summary>
  /// <param name="preparer">The preparer needed to prepare the program rules.</param>
  /// <param name="transformer">The transformer needed to transform the program rules.</param>
  /// <param name="solver">The solver needed to solve the program.</param>
  public SolverEngine(IPreparer preparer, ITransformer transformer, ISolver solver)
  {
    this.Preparer = preparer;
    this.Transformer = transformer;
    this.Solver = solver;
  }

  /// <summary>
  /// Gets the preparer interface for the solving engine.
  /// </summary>
  public IPreparer Preparer
  {
    get
    {
      return this.preparer;
    }

    private set
    {
      this.preparer = value ?? throw new ArgumentNullException(nameof(this.Preparer), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Gets the transformer interface for the solver engine.
  /// </summary>
  public ITransformer Transformer
  {
    get
    {
      return this.transformer;
    }

    private set
    {
      this.transformer = value ?? throw new ArgumentNullException(nameof(this.Transformer), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Gets the solver interface for the solver engine.
  /// </summary>
  public ISolver Solver
  {
    get
    {
      return this.solver;
    }

    private set
    {
      this.solver = value ?? throw new ArgumentNullException(nameof(this.Solver), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Execute the solving engine algorithm.
  /// </summary>
  /// <returns>The solved program as atoms.</returns>
  public abstract List<List<Atom>>? Execute();
}