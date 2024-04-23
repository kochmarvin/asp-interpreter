using System.Data;
using Interpreter.Lib.Graph;
using Interpreter.Lib.Results.Enums;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Objects.Terms;
using Interpreter.Lib.Logger;
using System.Diagnostics;

namespace Interpreter.Lib.Grounder;

public class Grounding(DependencyGraph graph)
{
  private readonly List<Atom> _visited = [];
  private readonly List<string> _warnings = [];
  public DependencyGraph Graph { get; } = graph;

  /// <summary>
  /// This is a list of atomliterals that have not been found in a head, just for print out
  /// </summary>
  public List<string> Warnings { get { return _warnings; } }

  /// <summary>
  /// This function creates the grounding secence of the program
  /// </summary>
  /// <returns>Returns a set of programs which is the order.</returns>
  // TODO wurde zu einer doppel liste gechanged checken ob das eh nichts kaputt macht
  public List<List<ProgramRule>> GenerateGroundingSequence()
  {
    var watch = StopWatch.Start();
    var sequence = new List<List<ProgramRule>>();

    foreach (var scc in Graph.CreateGraph())
    {
      foreach (var posScc in new DependencyGraph(scc).CreateGraph(true))
      {
        sequence.Add(posScc);
      }
    }
    // Most important step, why exactly this happens is unclear.
    sequence.Reverse();
    Logger.Logger.Debug("Created dependecy graph. \n"
    + "Creation duration was " + watch.Stop());

    foreach (var list in sequence)
    {
      string rules = "--------------------------------\n";
      foreach (var rule in list)
      {
        rules += rule.ToString() + "\n";
      }
      Logger.Logger.Debug(rules + "--------------------------------");
    }

    return sequence;
  }

  /// <summary>
  /// This functions generates the dependecy graph and grounds every rule 
  /// in the correct sequence. After that it cleans the grounded rules and returns a 
  /// variable free program.
  /// </summary>
  /// <returns>A variable free program.</returns>
  public List<ProgramRule> Ground()
  {
    Logger.Logger.Debug("Start grounding process \n");
    var watch = StopWatch.Start();
    var groundedProgram = new List<ProgramRule>();

    foreach (var subProgram in GenerateGroundingSequence())
    {
      // Add Range is just a simpler way to add it to the list. You could also loop through it and add one by one
      groundedProgram.AddRange(GroundSubProgram(subProgram));
    }
    List<string> availableHeads = [];
    List<string> availableAtoms = GenerateAvailableAtoms(groundedProgram, availableHeads);

    _warnings.RemoveAll(availableHeads.Contains);

    GroundCleanUp(groundedProgram, availableAtoms);

    Logger.Logger.Debug("Created grounded program. \n"
        + "Creation duration was " + watch.Stop());

    string rules = "--------------------------------\n";
    foreach (var rule in groundedProgram)
    {
      rules += rule.ToString() + "\n";
    }
    Logger.Logger.Debug(rules + "--------------------------------");

    return groundedProgram;
  }

  /// <summary>
  /// This function goes throught each rule and (fact) and stores the
  /// head of the rule into a list, beacause it is going to be an initial 
  /// valid value.
  /// </summary>
  /// <param name="groundedProgram">The initial grounded Program.</param>
  /// <returns>All heads as a string list.</returns>
  private List<string> GenerateAvailableAtoms(List<ProgramRule> groundedProgram, List<string> headNamesOnly)
  {
    List<string> availableAtoms = [];
    foreach (var rule in groundedProgram)
    {
      if (rule.Head is ChoiceHead choiceHead)
      {
        availableAtoms.AddRange(choiceHead.Atoms.Select(atom => atom.ToString()));
        headNamesOnly.AddRange(choiceHead.Atoms.Select(atom => atom.Name));
      }

      if (rule.Head is AtomHead atomHead)
      {
        availableAtoms.Add(atomHead.Atom.ToString());
        headNamesOnly.Add(atomHead.Atom.Name);
      }
    }

    return availableAtoms;
  }

  /// <summary>
  /// This function goes through all rules one by one and looks if each
  /// atom in its body contains as a head. If it does not exist as a head it removes
  /// the rule from the program. It also removes its head from the available
  /// atoms list. The process is done until there is no more change which means every atom 
  /// in every rule has been seen.
  /// </summary>
  /// <param name="groundedProgram">The initial grounded program.</param>
  /// <param name="availableAtoms">The heads of each rule.</param>
  private void GroundCleanUp(List<ProgramRule> groundedProgram, List<string> availableAtoms)
  {
    Logger.Logger.Debug("Cleaning up grounded program.");
    List<string> _seen = [];

    for (int i = 0; i < groundedProgram.Count; i++)
    {
      if (_seen.Contains(groundedProgram[i].ToString()))
      {
        groundedProgram.RemoveAt(i);
        i--;
        continue;
      }

      _seen.Add(groundedProgram[i].ToString());
    }

    int changes = 0;
    do
    {
      changes = 0;

      for (int i = 0; i < groundedProgram.Count; i++)
      {
        foreach (var body in groundedProgram[i].Body)
        {
          // Change this if there somehow comes a new body type like aggregations
          var literal = ((LiteralBody)body).Literal;

          if (literal is AtomLiteral atomLiteral && atomLiteral.Positive)
          {
            // Check if the rule we are lookign at is in the valid rules, if not 
            // we have to get rid of every component of the rule
            if (availableAtoms.Contains(atomLiteral.Atom.ToString()))
            {
              continue;
            }

            // Now we now that we are making change, because we delete rules and modify the valid atoms
            changes++;

            // if it is a choice head remove every possible choice from the valid atoms.
            if (groundedProgram[i].Head is ChoiceHead choiceHead)
            {
              // Also a simple way to write the process, could be made longer with for loops, 
              // TODO maybe change for better readability
              choiceHead.Atoms.Select(atom => atom.ToString()).ToList().ForEach((atom) => availableAtoms.Remove(atom.ToString()));
            }

            // if it is a normal head just remove it.
            if (groundedProgram[i].Head is AtomHead atomHead)
            {
              availableAtoms.Remove(atomHead.Atom.ToString());
            }

            groundedProgram.RemoveAt(i);

            // go back in the for loop because the whole list shrunk by one
            i--;
          }
        }
      }
    } while (changes != 0);
  }

  /// <summary>
  /// This function grounds a subprogram, a subprogram therefore is a 
  /// set of rules linked by the dependecy graph,
  /// </summary>
  /// <param name="subPorgram"></param>
  /// <returns>Grounded rules for the given sub program.</returns>
  private List<ProgramRule> GroundSubProgram(List<ProgramRule> subPorgram)
  {
    var groundedSubProgram = new List<ProgramRule>();

    foreach (var rule in subPorgram)
    {
      // If the body is zero we dont need to ground anything because its header a bodyless choice or a fact
      if (rule.Body.Count == 0)
      {
        groundedSubProgram.Add(rule);
        continue;
      }

      // TODO check if this is valid behaviour.
      // if (!rule.HasVariables())
      // {
      //   groundedSubProgram.Add(rule);
      //   continue;
      // }

      groundedSubProgram.AddRange(GroundRule(rule));
    }

    // Add every rule head to visited for future substitutions
    foreach (var rule in groundedSubProgram)
    {
      if (rule.Head is ChoiceHead choiceHead)
      {
        // Due to linq very short way to write this
        choiceHead.Atoms.ForEach(_visited.Add);
      }

      if (rule.Head is AtomHead atomHead)
      {
        _visited.Add(atomHead.Atom);
      }
    }

    return groundedSubProgram;
  }

  /// <summary>
  /// This function grounds a rule. Recursivly with index beeing the literal of the body.
  /// </summary>
  /// <param name="rule">Rule is the rule you want to ground.</param>
  /// <param name="substitutions">The possible values for the grounder to insert.</param>
  /// <param name="index">Is the index of the literal on the body you want to ground.</param>
  /// <returns></returns>
  private List<ProgramRule> GroundRule(ProgramRule rule, Dictionary<string, Term>? substitutions = null, int index = 0)
  {
    // If the substitution is null the initialize it with a new dict.
    substitutions ??= [];
    var groundedRules = new List<ProgramRule>();

    if (index >= rule.Body.Count)
    {
      var newRule = rule.Apply(substitutions);

      groundedRules.Add(newRule);
    }

    // Also change this if there is somehow a new body
    if (index < rule.Body.Count && rule.Body[index] is LiteralBody lit)
    {
      // Here we look if there are any matches with the current literal and the current substituations
      foreach (var foundSubstituations in FindMatches(substitutions, lit.Literal))
      {
        groundedRules.AddRange(GroundRule(rule, foundSubstituations, index + 1));
      }
    }

    return groundedRules;
  }

  private List<Dictionary<string, Term>> FindMatches(Dictionary<string, Term> substitutions, Literal literal)
  {
    // If the literal is an atom literal so everything except exception
    if (literal is AtomLiteral atomLiteral)
    {
      return MatchAtomLiteral(substitutions, atomLiteral);
    }

    // If the literal is a comparisson X = Y, Y <> X
    if (literal is ComparisonLiteral comparisonLiteral)
    {
      var left = comparisonLiteral.Left.Apply(substitutions);
      var right = comparisonLiteral.Right.Apply(substitutions);

      // Here we check if the comparisson is valid because if it fails
      // we wont store the substiturions for it.
      if (EvaluateComparisson(left, comparisonLiteral.Reltation, right))
      {
        return [substitutions];
      }
    }

    return [];
  }


  /// <summary>
  //  This function evaluates the truth value of the relation operation
  /// </summary>
  /// <param name="left">Is the Term on the left hand side.</param>
  /// <param name="relation">Is how the Terms are connected for example =, <></param>
  /// <param name="right">Is the Term on the right hand side.</param>
  /// <returns>If the operations succeds or not.</returns>
  public bool EvaluateComparisson(Term left, Relation relation, Term right)
  {
    return relation switch
    {
      Relation.LessEqual => string.Compare(left.ToString(), right.ToString()) <= 0,
      Relation.LessThan => string.Compare(left.ToString(), right.ToString()) < 0,
      Relation.GreaterEqual => string.Compare(left.ToString(), right.ToString()) >= 0,
      Relation.GreaterThan => string.Compare(left.ToString(), right.ToString()) > 0,
      Relation.Inequal => left.ToString() != right.ToString(),
      Relation.Equal => left.ToString() == right.ToString(),
      _ => false,
    };
  }

  /// <summary>
  /// This function searches for all matches for an atom literal.
  /// </summary>
  /// <param name="substitutions">Possible values for the appliers.</param>
  /// <param name="atomLiteral">The literal you want to find matches for.</param>
  /// <returns>A List of possible matches.</returns>
  private List<Dictionary<string, Term>> MatchAtomLiteral(Dictionary<string, Term> substitutions, AtomLiteral atomLiteral)
  {
    var substituationList = new List<Dictionary<string, Term>>();

    _warnings.Add(atomLiteral.Atom.Name);

    // If it is not positive (not ...) we just assume that it is a possible value.
    // This is important for circular dependecy rules.
    if (!atomLiteral.Positive && !atomLiteral.Atom.Apply(substitutions).HasVariables())
    {
      substituationList.Add(substitutions);
    }

    // Cloneig the atom of the literal by appliend substiutian
    var newAtom = atomLiteral.Atom.Apply(substitutions);

    foreach (var visited in _visited)
    {

      var newSubstituation = new Dictionary<string, Term>(substitutions);

      // If the new atom does not match with the visited node, name etc. skip it. Match also adds new substituations
      if (!newAtom.Match(visited, newSubstituation)) continue;

      substituationList.Add(newSubstituation);
    }

    if (substituationList.Count == 0)
    {
      substituationList.Add([]);
    }

    return substituationList;
  }
}