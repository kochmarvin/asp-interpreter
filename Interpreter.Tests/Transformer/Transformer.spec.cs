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

            ]
        );
    }

}