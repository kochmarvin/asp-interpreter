using Interpreter.Lib.Solver.defaults;

namespace Tests.Grounder;

[TestFixture]
public class DPLLTests
{
  [Test]
  public void ChoiceKNFBraveSolve()
  {

    List<List<int>> formular = [
      [-1, -2],
      [1, 2],
      [-3, 1],
      [-1, 3],
      [-4, -5],
      [4, 5],
      [-4, -1],
      [-4, -5],
      [1, 5, 4],
      [-6, -3],
      [-6, -4],
      [3, 4, 6],
      [-4, 1],
   ];

    DPLLSolver solver = new DPLLSolver();
    var result = solver.FindAllSolutions(formular);

    List<List<int>> expected = [[1, 3, 5, -2, -4, -6], [2, 5, 6, -1, -3, -4]];

    Assert.That(AreEquivalent(result.Select(sr => sr.Assignments).ToList(), expected), Is.True);
  }
  [Test]
  public void UnsatisfiableSovle()
  {

    List<List<int>> formular = [
      [-1],
      [1],
   ];

    DPLLSolver solver = new DPLLSolver();
    var result = solver.Solve(formular);

    Assert.That(result.Assignments.Count, Is.EqualTo(0));
  }

  private bool AreEquivalent(List<List<int>> a, List<List<int>> b)
  {
    if (a.Count != b.Count)
      return false;

    var listA = a.Select(x => new HashSet<int>(x)).ToList();
    var listB = b.Select(x => new HashSet<int>(x)).ToList();

    foreach (var setA in listA)
    {
      if (!listB.Any(setB => setB.SetEquals(setA)))
        return false;
    }

    return true;
  }

}