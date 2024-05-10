using Interpreter.Lib.Logger;
using Interpreter.Lib.Solver.Interfaces;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace Interpreter.Lib.Solver.defaults
{
  public class DPLLSolver : ISolver
  {
    private Random _random;
    private const int MaxDuplicates = 1;

    public DPLLSolver()
    {
      _random = new Random();
    }

    public SatResult Solve(List<List<int>> formula)
    {
      return DPLL(formula);
    }

    public List<SatResult> FindAllSolutions(List<List<int>> formula)
    {
      var watch = Stopwatch.StartNew();
      var allSolutions = new ConcurrentBag<SatResult>();
      var processedFormulas = new ConcurrentDictionary<string, bool>();
      var lockObject = new object();
      FindAllSolutionsRecursive(formula, [], allSolutions, lockObject, processedFormulas, 0);
      Logger.Logger.Debug("Found all possible solutions. \n"
             + "Duration was " + watch.Elapsed);
      return allSolutions.ToList();
    }

    private void FindAllSolutionsRecursive(List<List<int>> formula, List<int> assignments, ConcurrentBag<SatResult> allSolutions, object lockObject, ConcurrentDictionary<string, bool> processedFormulas, int duplicateCount)
    {
      Logger.Logger.Debug("Starting finding solutions process");


      var normalizedFormulaString = NormalizeAndStringifyFormula(formula);
      if (processedFormulas.ContainsKey(normalizedFormulaString))
      {
        Logger.Logger.Debug("Formula already processed, skipping.");
        return;
      }
      processedFormulas[normalizedFormulaString] = true;

      SatResult result = DPLL(formula, []);

      if (!result.Satisfiable)
      {
        Logger.Logger.Debug("Stopping process due to finding unsatisfiable formula");
        return;
      }

      lock (lockObject)
      {
        if (!allSolutions.Any(existing => existing.Assignments.SequenceEqual(result.Assignments)))
        {
          allSolutions.Add(result);
        }
        else
        {
          duplicateCount++;
          Logger.Logger.Debug($"Found duplicate solution. Duplicate count: {duplicateCount}");
          if (duplicateCount >= MaxDuplicates)
          {
            Logger.Logger.Debug("Maximum duplicates reached for this worker, stopping process.");
            return;
          }
        }
      }

      Parallel.ForEach(result.Assignments, (literal) =>
      {
        List<List<int>> newFormula = [.. formula, [-literal]];
        FindAllSolutionsRecursive(newFormula, [], allSolutions, lockObject, processedFormulas, duplicateCount);
      });
    }

    private string NormalizeAndStringifyFormula(List<List<int>> formula)
    {
      var sortedClauses = formula.Select(clause => clause.OrderBy(lit => Math.Abs(lit)).ToList())
                                 .OrderBy(clause => string.Join(",", clause));
      return string.Join(";", sortedClauses.Select(clause => string.Join(",", clause)));
    }

    private SatResult DPLL(List<List<int>> formula, List<int>? assignments = null)
    {
      assignments ??= [];

      if (formula.Count == 0)
      {
        return new SatResult(true, [.. assignments]);
      }

      foreach (var clause in formula.OrderBy(clause => clause.Count))
      {
        if (clause.Count == 0)
        {
          return new SatResult(false, []);
        }

        if (clause.Count == 1)
        {
          int literal = clause[0];
          if (!assignments.Contains(literal) && !assignments.Contains(-literal))
          {
            assignments.Add(literal);
          }

          List<List<int>> newCNF = UnitPropagate(formula, literal);

          return DPLL(newCNF, [.. assignments]);
        }
      }

      int randomClauseIndex = _random.Next(formula.Count);
      List<int> randomClause = formula[randomClauseIndex];
      int chooseLiteral = randomClause[_random.Next(randomClause.Count)];

      SatResult resultTrue = DPLL([.. formula, [chooseLiteral]], [.. assignments, chooseLiteral]);
      if (resultTrue.Satisfiable)
      {
        return resultTrue;
      }

      return DPLL([.. formula, [-chooseLiteral]], [.. assignments, -chooseLiteral]);
    }

    private List<List<int>> UnitPropagate(List<List<int>> originalFormula, int literal)
    {
      List<List<int>> result = [];
      foreach (var cnfClause in originalFormula)
      {
        if (cnfClause.Contains(literal))
        {
          continue;
        }

        if (cnfClause.Contains(-literal))
        {
          List<int> filteredClause = cnfClause.Where(l => l != -literal).ToList();
          result.Add(filteredClause);
          continue;
        }

        result.Add([.. cnfClause]);
      }

      return result;
    }
  }
}
