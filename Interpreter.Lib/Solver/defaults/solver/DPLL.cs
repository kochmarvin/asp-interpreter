using Interpreter.Lib.Solver.Interfaces;

namespace Interpreter.Lib.Solver.defaults;

public class DPLLSolver : ISolver
{

  private Random _random;
  public DPLLSolver()
  {
    _random = new Random();
  }

  public SatResult Solve(List<List<int>> formular)
  {
    return DPLL(formular);
  }

  public List<SatResult> FindAllSolutions(List<List<int>> formula)
  {
    var allSolutions = new List<SatResult>();
    var lockObject = new object();
    FindAllSolutionsRecursive(formula, [], allSolutions, lockObject);
    return allSolutions;
  }

  private void FindAllSolutionsRecursive(List<List<int>> formula, List<int> assignments, List<SatResult> allSolutions, object lockObject)
  {
    SatResult result = DPLL(formula, []);
    if (!result.Satisfiable)
    {
      return;
    }

    lock (lockObject)
    {
      if (allSolutions.Any(sol => AreEquivalent(sol.Assignments, result.Assignments)))
      {
        return;
      }

      allSolutions.Add(result);
    }

    Parallel.ForEach(result.Assignments, (literal) =>
    {
      FindAllSolutionsRecursive([.. formula, [-literal]], [], allSolutions, lockObject);
    });
  }

  private bool AreEquivalent(List<int> list1, List<int> list2)
  {
    var set1 = new HashSet<int>(list1);
    var set2 = new HashSet<int>(list2);
    return set1.SetEquals(set2);
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

    // take a random clause out of the formula
    List<int> randomClause = formula[randomClauseIndex];

    // take a random literal out of the formula
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