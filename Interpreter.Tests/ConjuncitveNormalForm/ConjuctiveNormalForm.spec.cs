
using Interpreter.FunctionalLib;
using Interpreter.Lib.Graph;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Tests;
using Microsoft.FSharp.Collections;
using static Interpreter.FunctionalLib.ConjunctiveNormalForm;


namespace Tests.Tree;

[TestFixture]
public class ConjunctiveNormalFormTests
{
  [TestCaseSource(nameof(GetTestCases))]
  public void ExpressionToCNF(ExpressionTestObject obj)
  {
    var cnf = createCNF(obj.Expression);
    var list = cnfToList(cnf);

    Assert.That(AreListsEqual(obj.Expected, ConvertFSharpListToList(list)), Is.True);
  }

  private bool AreListsEqual(List<List<int>> list1, List<List<int>> list2)
  {
    var sortedList1 = list1.Select(innerList => innerList.OrderBy(x => x).ToList())
                           .OrderBy(innerList => string.Join(",", innerList)).ToList();
    var sortedList2 = list2.Select(innerList => innerList.OrderBy(x => x).ToList())
                           .OrderBy(innerList => string.Join(",", innerList)).ToList();

    return sortedList1.SequenceEqual(sortedList2, new ListComparer());
  }

  private List<List<int>> ConvertFSharpListToList(FSharpList<FSharpList<int>> fsharpListOfLists)
  {
    return ListModule.OfSeq(fsharpListOfLists)
           .Select(fsharpList => ListModule.OfSeq(fsharpList).ToList())
           .ToList();
  }

  private class ListComparer : IEqualityComparer<List<int>>
  {
    public bool Equals(List<int>? x, List<int>? y)
    {
      if (x == null || y == null)
      {
        return false;
      }
      
      return x.SequenceEqual(y);
    }

    public int GetHashCode(List<int> obj)
    {
      return obj.Aggregate(0, (current, item) => unchecked(current * 31 + item.GetHashCode()));
    }
  }

  public static IEnumerable<ExpressionTestObject> GetTestCases()
  {
    yield return new ExpressionTestObject(
      Expression.NewVar(1),
      [[1]]
    );

    yield return new ExpressionTestObject(
      Expression.NewNot(Expression.NewVar(1)),
      [[-1]]
    );

    yield return new ExpressionTestObject(
      Expression.NewNot(Expression.NewNot(Expression.NewVar(1))),
      [[1]]
    );

    yield return new ExpressionTestObject(
      Expression.NewAnd(Expression.NewVar(1), Expression.NewVar(2)),
      [[1], [2]]
    );

    yield return new ExpressionTestObject(
      Expression.NewOr(Expression.NewVar(1), Expression.NewVar(2)),
      [[1, 2]]
    );

    yield return new ExpressionTestObject(
      Expression.NewImplies(Expression.NewVar(1), Expression.NewVar(2)),
      [[-1, 2]]
    );

    yield return new ExpressionTestObject(
      Expression.NewEquiv(Expression.NewVar(1), Expression.NewVar(2)),
      [[-1, 2], [1, -2]]
    );

    yield return new ExpressionTestObject(
      Expression.NewXor(Expression.NewVar(1), Expression.NewVar(2)),
      [[-1, -2], [1, 2]]
    );

    yield return new ExpressionTestObject(
      Expression.NewAnd(Expression.NewOr(Expression.NewVar(1), Expression.NewVar(2)), Expression.NewNot(Expression.NewVar(3))),
      [[1, 2], [-3]]
    );

    yield return new ExpressionTestObject(
      Expression.NewOr(Expression.NewAnd(Expression.NewVar(1), Expression.NewVar(2)), Expression.NewNot(Expression.NewVar(3))),
      [[1, -3], [2, -3]]
    );

    yield return new ExpressionTestObject(
      Expression.NewAnd(Expression.NewOr(Expression.NewVar(1), Expression.NewVar(2)), Expression.NewOr(Expression.NewVar(3), Expression.NewVar(4))),
      [[1, 2], [3, 4]]
    );

    yield return new ExpressionTestObject(
      Expression.NewOr(Expression.NewAnd(Expression.NewVar(1), Expression.NewNot(Expression.NewVar(2))), Expression.NewAnd(Expression.NewNot(Expression.NewVar(3)), Expression.NewVar(4))),
      [[1, -3], [1, 4], [-2, -3], [-2, 4]]
    );

    yield return new ExpressionTestObject(
      Expression.NewNot(Expression.NewNot(Expression.NewNot(Expression.NewVar(1)))),
      [[-1]]
    );

    yield return new ExpressionTestObject(
      Expression.NewEquiv(Expression.NewImplies(Expression.NewVar(1), Expression.NewVar(2)), Expression.NewAnd(Expression.NewVar(3), Expression.NewVar(4))),
      [[1, 3], [-2, 3], [1, 4], [-2, 4], [-1, 2, -3, -4]]
    );

    yield return new ExpressionTestObject(
      Expression.NewAnd(Expression.NewXor(Expression.NewVar(1), Expression.NewVar(2)), Expression.NewVar(3)),
      [[-1, -2], [1, 2], [3]]
    );
  }
}