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

    for(int i = 0; i < Graph.CreateGraph().Count; i++){

      foreach (var posScc in new DependencyGraph(Graph.CreateGraph()[i]).CreateGraph(true))
      {
        sequence.Add(posScc);
      }
    }
    
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
    if (literal is AtomLiteral atomLiteral)
    {
      return MatchAtomLiteral(substitutions, atomLiteral);
    }

    // TODO comparison
    return [];
  }

  private List<Dictionary<string, Term>> MatchAtomLiteral(Dictionary<string, Term> substitutions, AtomLiteral atomLiteral)
  {
    var substituationList = new List<Dictionary<string, Term>>();

    if (!atomLiteral.Positive)
    {
      substituationList.Add(substitutions);
      return substituationList;
    }

    var newAtom = atomLiteral.Atom.Apply(substitutions);
    foreach (var visited in _visited)
    {
      var newSubstituation = new Dictionary<string, Term>();

      if (!newAtom.Match(visited, newSubstituation)) continue;

      foreach (var substituation in substitutions)
      {
        newSubstituation.Add(substituation.Key, substituation.Value);
      }

      substituationList.Add(newSubstituation);
    }

    return substituationList;
  }
}