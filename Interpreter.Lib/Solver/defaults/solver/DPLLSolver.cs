//-----------------------------------------------------------------------
// <copyright file="DPLLSolver.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Solver.Defaults;

using System.Collections.Concurrent;
using System.Diagnostics;
using Interpreter.Lib.Solver.Interfaces;

/// <summary>
/// The default solver for the programm a DPLL.
/// </summary>
public class DPLLSolver : ISolver
{
  /// <summary>
  /// How many duplicates a process can find until it stops.
  /// </summary>
  private const int MaxDuplicates = 1;

  /// <summary>
  /// The random instance to take a random variable.
  /// </summary>
  private Random random;

  /// <summary>
  /// Initializes a new instance of the <see cref="DPLLSolver"/> class.
  /// </summary>
  public DPLLSolver()
  {
    this.random = new Random();
  }

  /// <summary>
  /// Solves a given CNF formular with the DPLL algorithm.
  /// </summary>
  /// <param name="formula">The formular to be solved.</param>
  /// <returns>The results of the solved formular.</returns>
  public SatResult Solve(List<List<int>> formula)
  {
    ArgumentNullException.ThrowIfNull(formula, "Is not supposed to be null");

    return this.DPLL(formula);
  }

  /// <summary>
  /// Start of a recursive function which will look for all solutions of a formular.
  /// </summary>
  /// <param name="formula">The formular which should be solved.</param>
  /// <returns>The found Results.</returns>
  public List<SatResult> FindAllSolutions(List<List<int>> formula)
  {
    ArgumentNullException.ThrowIfNull(formula, "Is not supposed to be null");

    var watch = Stopwatch.StartNew();
    var allSolutions = new ConcurrentBag<SatResult>();
    var processedFormulas = new ConcurrentDictionary<string, bool>();
    var lockObject = new object();
    this.FindAllSolutionsRecursive(formula, [], allSolutions, lockObject, processedFormulas, 0);
    Logger.Logger.Debug("Found all possible solutions. \n"
           + "Duration was " + watch.Elapsed);
    return allSolutions.ToList();
  }

  /// <summary>
  /// Recursive function to find all solutios.
  /// </summary>
  /// <param name="formula">The formular which should get solved.</param>
  /// <param name="assignments">The previous assignments.</param>
  /// <param name="allSolutions">All solutions which have been found.</param>
  /// <param name="lockObject">A lock object.</param>
  /// <param name="processedFormulas">All forumulars which have been processed.</param>
  /// <param name="duplicateCount">On which duplicate state the process is.</param>
  private void FindAllSolutionsRecursive(List<List<int>> formula, List<int> assignments, ConcurrentBag<SatResult> allSolutions, object lockObject, ConcurrentDictionary<string, bool> processedFormulas, int duplicateCount)
  {
    ArgumentNullException.ThrowIfNull(formula, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(assignments, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(allSolutions, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(lockObject, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(processedFormulas, "Is not supposed to be null");

    Logger.Logger.Debug("Starting finding solutions process");

    // If the solver is on a formular which has already been processed it wont do it again.
    var normalizedFormulaString = this.NormalizeAndStringifyFormula(formula);
    if (processedFormulas.ContainsKey(normalizedFormulaString))
    {
      Logger.Logger.Debug("Formula already processed, skipping.");
      return;
    }

    // set the formular to be seen.
    processedFormulas[normalizedFormulaString] = true;

    // solve the formualr.
    SatResult result = this.DPLL(formula, []);
    if (!result.Satisfiable)
    {
      Logger.Logger.Debug("Stopping process due to finding unsatisfiable formula");
      return;
    }

    lock (lockObject)
    {
      // if the solution has not been found add it otherwhise add up the duplication count and solve further.
      if (!allSolutions.Any(existing => existing.Assignments.SequenceEqual(result.Assignments)))
      {
        allSolutions.Add(result);
      }
      else
      {
        duplicateCount++;
        Logger.Logger.Debug($"Found duplicate solution. Duplicate count: {duplicateCount}");

        // If the duplicate count is greater or equal stop solving.
        if (duplicateCount >= MaxDuplicates)
        {
          Logger.Logger.Debug("Maximum duplicates reached for this worker, stopping process.");
          return;
        }
      }
    }

    // Add every literal as a not and start the process again to find more solutions.
    Parallel.ForEach(result.Assignments, (literal) =>
    {
      List<List<int>> newFormula = [.. formula, [-literal]];
      this.FindAllSolutionsRecursive(newFormula, [], allSolutions, lockObject, processedFormulas, duplicateCount);
    });
  }

  /// <summary>
  /// Creates the string value of the formular to match it.
  /// </summary>
  /// <param name="formula">The formular which should be stringified.</param>
  /// <returns>The string value of the forumar.</returns>
  private string NormalizeAndStringifyFormula(List<List<int>> formula)
  {
    ArgumentNullException.ThrowIfNull(formula, "Is not supposed to be null");

    var sortedClauses = formula.Select(clause => clause.OrderBy(lit => Math.Abs(lit)).ToList())
                               .OrderBy(clause => string.Join(",", clause));
    return string.Join(";", sortedClauses.Select(clause => string.Join(",", clause)));
  }

  /// <summary>
  /// Recursive dpll sovler method.
  /// </summary>
  /// <param name="formula">The formular which should get solved.</param>
  /// <param name="assignments">The current assignments of the  formular.</param>
  /// <returns>A Sat result.</returns>
  private SatResult DPLL(List<List<int>> formula, List<int>? assignments = null)
  {
    ArgumentNullException.ThrowIfNull(formula, "Is not supposed to be null");

    // If the assignments are not set set it.
    assignments ??= [];

    // if there are no clauses anymore it is a valid formualr.
    if (formula.Count == 0)
    {
      return new SatResult(true, [.. assignments]);
    }

    foreach (var clause in formula.OrderBy(clause => clause.Count))
    {
      // if htere is a an empty clause it was unsatisfiable
      if (clause.Count == 0)
      {
        return new SatResult(false, []);
      }

      // if there is only one varibale combine it and start a new DPLL with the new formular.
      if (clause.Count == 1)
      {
        int literal = clause[0];
        if (!assignments.Contains(literal) && !assignments.Contains(-literal))
        {
          assignments.Add(literal);
        }

        List<List<int>> newCNF = this.UnitPropagate(formula, literal);

        return this.DPLL(newCNF, [.. assignments]);
      }
    }

    // If there is not a single clause with only one literal take a random one and try it with the positve one
    int randomClauseIndex = this.random.Next(formula.Count);
    List<int> randomClause = formula[0];
    int chooseLiteral = randomClause[0];

    SatResult resultTrue = this.DPLL([.. formula, [chooseLiteral]], [.. assignments, chooseLiteral]);
    if (resultTrue.Satisfiable)
    {
      return resultTrue;
    }

    // if this has not worked try it with the negative one
    return this.DPLL([.. formula, [-chooseLiteral]], [.. assignments, -chooseLiteral]);
  }

  /// <summary>
  /// Removes all findings of a literal in all formualrs.
  /// </summary>
  /// <param name="originalFormula">The formular which should get looked at.</param>
  /// <param name="literal">The literal which should get removed.</param>
  /// <returns>The new formular.</returns>
  private List<List<int>> UnitPropagate(List<List<int>> originalFormula, int literal)
  {
    ArgumentNullException.ThrowIfNull(originalFormula, "Is not supposed to be null");

    List<List<int>> result = [];
    foreach (var cnfClause in originalFormula)
    {
      // If it contains the literal itself skip it.
      if (cnfClause.Contains(literal))
      {
        continue;
      }

      // if the literal contains the negative value of the literal filter it.
      if (cnfClause.Contains(-literal))
      {
        List<int> filteredClause = cnfClause.Where(l => l != -literal).ToList();

        // add it to the nrew formular.
        result.Add(filteredClause);
        continue;
      }

      // if nothing has been found just add it whole formular.
      result.Add([.. cnfClause]);
    }

    // the new formular.
    return result;
  }
}
