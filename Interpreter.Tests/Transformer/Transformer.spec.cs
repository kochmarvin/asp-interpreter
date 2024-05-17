using Interpreter.Lib.Graph;
using Interpreter.Lib.Grounder;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Solver;
using Interpreter.Lib.Solver.defaults;
using Interpreter.Tests.Parser;

namespace Interpreter.Tests.Transformer;

[TestFixture]
public class TransformerTests
{
    [TestCaseSource(nameof(GetTestCases))]
    public void SatTransformer(SatTransformerResult obj)
    {
        List<ProgramRule> program = Utils.ParseProgram(obj.File);
        var graph = new DependencyGraph(program);
        var grounder = new Grounding(graph);
        var groundedProgram = grounder.Ground();
        var preperation = new Preparer().Prepare(groundedProgram);

        List<List<int>> results = new SatTransformer().TransformToFormular(preperation);

        System.Console.WriteLine(obj.File);
        foreach (var result in results)
        {
            foreach (var rule in result)
            {
                System.Console.Write(rule.ToString());
            }
            System.Console.WriteLine();
        }

        Assert.IsTrue(AreEqual(obj.Expected, results));
    }

    public bool AreEqual(List<List<int>> x, List<List<int>> y)
    {
        if (x == null || y == null)
        {
            return x == null && y == null;
        }

        if (x.Count != y.Count)
        {
            return false;
        }

        // Sort each inner list before comparing
        for (int i = 0; i < x.Count; i++)
        {
            x[i].Sort();
            y[i].Sort();
        }

        // Sort outer list before comparing
        x.Sort(CompareLists);
        y.Sort(CompareLists);

        return Enumerable.SequenceEqual(x, y, new ListComparer<int>());
    }

    private int CompareLists(List<int> list1, List<int> list2)
    {
        if (list1 == null || list2 == null)
        {
            return list1 == null ? (list2 == null ? 0 : -1) : 1;
        }

        for (int i = 0; i < Math.Min(list1.Count, list2.Count); i++)
        {
            int comparison = list1[i].CompareTo(list2[i]);
            if (comparison != 0)
            {
                return comparison;
            }
        }

        return list1.Count.CompareTo(list2.Count);
    }

    public static IEnumerable<SatTransformerResult> GetTestCases()
    {
        yield return new SatTransformerResult(
            "schraub.lp",
            [
                [-2, -3],
                [2, 3],
                [-4, 2],
                [-2, 4],
                [-5, -6],
                [5, 6],
                [-5, -2],
                [2, 6, 5],
                [-7, -4],
                [-7, -5],
                [4,5,7],
                [-5,2],
                [-1]
            ]
        );

        yield return new SatTransformerResult(
            "birds.lp",
            [
                [2],
                [-3, -2],
                [2, 3],
                [-1]
            ]
        );

        yield return new SatTransformerResult(
            "blocks.lp",
            [
                [-1]
            ]

        );

        yield return new SatTransformerResult(
            "choice_head.lp",
            [
                [-2, -3],
                [2,3],
                [-4, -5],
                [4,5],
                [-6, -7],
                [6,7],
                [-8, -9],
                [8, 9],
                [-8, 2],
                [-2, 9, 8],
                [-1]
            ]
        );

        yield return new SatTransformerResult(
            "circular.lp",
            [
                [-2, -3],
                [3, 2],
                [-1]
            ]

        );

        yield return new SatTransformerResult(
            "edge_2.lp",
            [
                [2],
                [3],
                [4],
                [-2, -3, -3, 5, 6],
                [-2, -4, -4, 7, 8],
                [-1]
            ]
        );

        yield return new SatTransformerResult(
            "multichoice_body.lp",
            [
                [-2, -3],
                [2, 3],
                [-4, -5],
                [4, 5],
                [-6, -7],
                [6, 7],
                [-8, -9],
                [8, 9],
                [-1]
            ]
        );

        yield return new SatTransformerResult(
            "negations.lp",
            [
                [-2, -3],
                [3, 2],
                [-1]
            ]
        );

        yield return new SatTransformerResult(
           "no_vars.lp",
           [
                [-2, -3],
                [3, 2],
                [-4, 2, 5],
                [-2, 4],
                [-5, 4],
                [-5, 3],
                [-4, -3, 5],
                [-4, 2],
                [-5, 2],
                [-1]
           ]
       );

        yield return new SatTransformerResult(
            "teaches.lp",
            [
                [2],
                [3],
                [4],
                [-5, 2],
                [-5, -6],
                [-2, 6, 5],
                [-7, 2],
                [-2, 7],
                [-8, 3],
                [-8, -9],
                [-3, 9, 8],
                [-10, 3],
                [-10, -11],
                [-3, 11, 10],
                [-12, 4],
                [-12, -13],
                [-4, 13, 12],
                [-14, 4],
                [-4, 14],
                [-6, 2],
                [-6, 8],
                [-2, -8, 6],
                [-15, 2, 2],
                [-15, 2, 12],
                [-15, 10, 2],
                [-15, 10, 12],
                [-2, -10, 15],
                [-2, -12, 15],
                [-16, 2],
                [-16, 14],
                [-2, -14, 16],
                [-9, 3],
                [-9, 5],
                [-3, -5, 9],
                [-11, 3],
                [-11, 12],
                [-3, -12, 11],
                [-17, 3],
                [-17, 7],
                [-3, -7, 17],
                [-18, 3],
                [-18, 14],
                [-3, -14, 18],
                [-19, 4, 4],
                [-19, 4, 8],
                [-19, 5, 4],
                [-19, 5, 8],
                [-4, -5, 19],
                [-4, -8, 19],
                [-13, 4],
                [-13, 10],
                [-4, -10, 13],
                [-20, 4],
                [-20, 7],
                [-4, -7, 20],
                [-21, 2, 2],
                [-21, 2, 7],
                [-21, 5, 2],
                [-21, 5, 7],
                [-2, -5, 21],
                [-2, -7, 21],
                [-22, 3, 3],
                [-22, 3, 10],
                [-22, 8, 3],
                [-22, 8, 10],
                [-3, -8, 22],
                [-3, -10, 22],
                [-23, 4, 4],
                [-23, 4, 14],
                [-23, 12, 4],
                [-23, 12, 14],
                [-4, -12, 23],
                [-4, -14, 23],
                [-2, 21],
                [-3, 22],
                [-4, 23],
                [-1]
            ]
        );

    }

}