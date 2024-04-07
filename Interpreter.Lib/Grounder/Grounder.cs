using System.Data;
using Interpreter.Lib.Graph;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Grounder;

public class Grounder
{
  private List<Atom> _visited;
  public DependencyGraph Graph { get; }

  public Grounder(DependencyGraph graph)
  {
    _visited = [];
    Graph = graph;
  }

  public List<ProgramRule> Ground()
  {
    var groundedProgram = new List<ProgramRule>();

    foreach (var subProgram in GenerateGroundingSequence())
    {
      groundedProgram.AddRange(GroundComponent(subProgram));
    }

    return groundedProgram;
  }

  // TODO wurde zu einer doppel liste gechanged checken ob das eh nichts kaputt macht
  public List<List<ProgramRule>> GenerateGroundingSequence()
  {
     var sequence = new List<List<ProgramRule>>();

    foreach (var scc in Graph.CreateGraph())
    {
      foreach (var posScc in new DependencyGraph(scc).CreateGraph(true))
      {
        sequence.Add(posScc);
      }
    }

    sequence.Reverse();
    return sequence;
  }

  private List<ProgramRule> GroundComponent(List<ProgramRule> subProgram)
  {
    var groundedSubProgram = new List<ProgramRule>();

    foreach (var rule in subProgram)
    {
      groundedSubProgram.AddRange(GroundProgramRule([], rule));
    }

    foreach (var rule in groundedSubProgram)
    {
      if (rule.Head is AtomHead atomHead)
      {
        _visited.Add(atomHead.Atom);
      }

      if (rule.Head is ChoiceHead choiceHead)
      {
        choiceHead.Atoms.ForEach(_visited.Add);
      }
    }

    return groundedSubProgram;
  }

  private List<ProgramRule> GroundProgramRule(Dictionary<string, Term> substitutions, ProgramRule rule, int index = 0)
  {
    var groundedRules = new List<ProgramRule>();

    if (index >= rule.Body.Count)
    {
      groundedRules.Add(rule.Apply(substitutions));
      return groundedRules;
    }

    if (rule.Body[index] is LiteralBody literalBody)
    {
      foreach (var foundSubstituations in Matches(substitutions, literalBody.Literal))
      {
        groundedRules.AddRange(GroundProgramRule(foundSubstituations, rule, ++index));
      }
    }

    return groundedRules;
  }

  private List<Dictionary<string, Term>> Matches(Dictionary<string, Term> substitutions, Literal literal)
  {
    // TODO find matches 
    // TODO comparison
    return [];
  }
}