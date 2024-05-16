using Interpreter.Lib.Solver.defaults;

namespace Tests.Solver;

[TestFixture]
public class SolverTests
{
    // [Test]
    // public void Solve_ReturnsCorrectResult_ForSatisfiableFormula()
    // {
    //     // Arrange
    //     var solver = new DPLLSolver();
    //     var formula = new List<List<int>>()
    //         {
    //             new List<int>() { 1, 2, -3 },
    //             new List<int>() { -1, 3 },
    //             new List<int>() { -2, -3 }
    //         };

    //     // Act
    //     var result = solver.Solve(formula);

    //     // Assert
    //     Assert.IsTrue(result.Satisfiable);
    //     CollectionAssert.AreEquivalent(new List<int>() { 1, -2, 3 }, result.Assignments);
    // }

    [Test]
    public void Solve_ReturnsCorrectResult_ForUnsatisfiableFormula()
    {
        // Arrange
        var solver = new DPLLSolver();
        var formula = new List<List<int>>()
            {
                new List<int>() { 1 },
                new List<int>() { -1 }
            };

        // Act
        var result = solver.Solve(formula);

        // Assert
        Assert.IsFalse(result.Satisfiable);
        CollectionAssert.IsEmpty(result.Assignments);
    }

    // [Test]
    // public void FindAllSolutions_ReturnsAllSolutions_ForSatisfiableFormula()
    // {
    //     // Arrange
    //     var solver = new DPLLSolver();
    //     var formula = new List<List<int>>()
    //         {
    //             new List<int>() { 1, 2, -3 },
    //             new List<int>() { -1, 3 },
    //             new List<int>() { -2, -3 }
    //         };

    //     // Act
    //     var solutions = solver.FindAllSolutions(formula);

    //     // Assert
    //     Assert.AreEqual(3, solutions.Count); // In this case, only one unique solution
    //     Assert.IsTrue(solutions[0].Satisfiable);
    //     CollectionAssert.AreEquivalent(new List<int>() { 1, -2, 3 }, solutions[0].Assignments);
    // }
}