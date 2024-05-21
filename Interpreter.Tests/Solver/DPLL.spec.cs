using Interpreter.Lib.Graph;
using Interpreter.Lib.Grounder;
using Interpreter.Lib.Results.Objects.Rule;

using Interpreter.Lib.Solver;
using Interpreter.Lib.Solver.defaults;
using Interpreter.Tests;
using Interpreter.Tests.Parser;

namespace Tests.Solver;

[TestFixture]
public class SolverTests
{
    [TestCaseSource(nameof(GetTestCases))]
    public void DPLLSolver(DPLLTestResults obj)
    {
        List<ProgramRule> program = Utils.ParseProgram(obj.File);
        var graph = new MyDependencyGraph(program, new OrderVisitor(), new MyAddToGraphVisitor());
        var grounder = new Grounding(graph);
        var groundedProgram = grounder.Ground();
        var preperation = new Preparer().Prepare(groundedProgram);

        List<List<int>> transformed = new SatTransformer().TransformToFormular(preperation);
        var results = new DPLLSolver().FindAllSolutions(transformed);

        // System.Console.WriteLine(obj.File);
        // foreach (var result in results)
        // {
        //     foreach (var rule in result.Assignments)
        //     {
        //         Console.Write(rule.ToString());
        //     }
        //     Console.WriteLine();
        // }

        Assert.IsTrue(Utils.AreEqual(obj.Expected, results.Select(sr => sr.Assignments).ToList()));
    }

    public static IEnumerable<DPLLTestResults> GetTestCases()
    {
        yield return new DPLLTestResults(
            "birds.lp",
            [
                [2, -3, -1]
            ]
        );

        yield return new DPLLTestResults(
            "blocks.lp",
            [
                [-1]
            ]
        );

        yield return new DPLLTestResults(
           "edge.lp",
           [
               [-1]
           ]
       );

        yield return new DPLLTestResults(
           "family_relations.lp",
           [
               [-1]
           ]
       );

        yield return new DPLLTestResults(
           "faster.lp",
           [
               [-1]
           ]
       );

        yield return new DPLLTestResults(
            "fastest.lp",
            [
                [-1]
            ]
        );

        yield return new DPLLTestResults(
           "happy.lp",
           [
               [-1]
           ]
       );

        yield return new DPLLTestResults(
           "nested.lp",
           [
               [-1]
           ]
       );

        yield return new DPLLTestResults(
            "unsat_1.lp",
            []
        );

        yield return new DPLLTestResults(
           "unsat_2.lp",
           []
       );

    //     yield return new DPLLTestResults(
    //        "test.lp",
    //        [

    //        ]
    //    );
    }
}