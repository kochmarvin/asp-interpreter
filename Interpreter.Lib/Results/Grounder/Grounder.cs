using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Graph;


namespace Interpreter.Lib.Grounder;

public class Grounder(DependencyGraph graph)
{

  public DependencyGraph Graph { get; } = graph;

  public void Test()
  {
    var x = GenerateGroundingSequence();
    Helper.PrintGrdSeq(x);
  }

  public List<ProgramRule> Ground()
  {
    List<ProgramRule> groudedProgram = [];

    foreach (var group in GenerateGroundingSequence())
    {
      Console.WriteLine("%Ground Component Group");
      foreach (var componnent in group)
      {
        Console.WriteLine("%   Ground Component");
        groudedProgram.AddRange(GroundComponent(componnent));
      }
    }

    return groudedProgram;
  }

  private List<List<List<ProgramRule>>> GenerateGroundingSequence()
  {
    var sequence = new List<List<List<ProgramRule>>>();

    foreach (var scc in Graph.CreateGraph())
    {
      var posSccList = new List<List<ProgramRule>>();
      sequence.Add(posSccList);

      foreach (var posScc in new DependencyGraph(scc).CreateGraph(true))
      {
        posSccList.Add(posScc);
      }
    }

    return sequence;
  }

  private List<ProgramRule> GroundComponent(List<ProgramRule> component)
  {
    List<ProgramRule> groundedComponent = [];

    foreach (var rule in component)
    {
      groundedComponent.AddRange(GroundRule(rule));
    }

    return groundedComponent;
  }

  private List<ProgramRule> GroundRule(ProgramRule rule)
  {
    List<ProgramRule> groundedRule = [];

    for (int i = 0; i < rule.Body.Count; i++)
    {
      if (rule.Body[i] is LiteralBody literal)
      {

      }

    }

    return groundedRule;
  }

}