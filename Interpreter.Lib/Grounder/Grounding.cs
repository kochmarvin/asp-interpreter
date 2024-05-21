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
using System.Reflection.Metadata.Ecma335;

namespace Interpreter.Lib.Grounder;

public class Grounding : IGrounder, IGroundMatcher
{
  private readonly List<Atom> _visited = [];
  private readonly List<string> _warnings = [];
  private DependencyGraph graph;
  public Grounding(DependencyGraph graph)
  {
    Graph = graph;
  }

  /// <summary>
  /// This is a list of atomliterals that have not been found in a head, just for print out
  /// </summary>
  public List<string> Warnings { get { return _warnings; } }

  public DependencyGraph Graph
  {
    get
    {
      return graph;
    }

    private set
    {
      graph = value ?? throw new ArgumentNullException(nameof(Graph), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// This function creates the grounding secence of the program
  /// </summary>
  /// <returns>Returns a set of programs which is the order.</returns>
  // TODO wurde zu einer doppel liste gechanged checken ob das eh nichts kaputt macht
  public List<List<ProgramRule>> GenerateGroundingSequence()
  {
    var watch = StopWatch.Start();
    var sequence = new List<List<ProgramRule>>();

    // Going through the programm and remove the comment literal because this is not necessary for gorunding.
    for (int i = 0; i < Graph.Program.Count; i++)
    {
      if (Graph.Program[i].Body.Count != 0)
      {
        foreach (var body in Graph.Program[i].Body)
        {
          if (body.Accept(new IsCommentLiteralVisitor()))
          {
            Graph.Program.RemoveAt(i);
            i--;
          }
        }
      }
    }

    for (int i = 0; i < Graph.Program.Count; i++)
    {
      // First we check if a rule contains any variables that are not in the head or any other body part
      // while skipping anonymous variable (e.g. _ ) 
      foreach (var body in Graph.Program[i].Body)
      {
        bool notInBodyAndHead = false;
        // bool notInHead = false;
        List<string> vars = body.GetVariables();
        var otherVars = Graph.Program[i].Body.Where((b) => b != body).SelectMany(b => b.GetVariables()).ToList();
        otherVars.AddRange(Graph.Program[i].Head.GetVariables());

        foreach (var v in vars)
        {
          if (v.StartsWith("_"))
          {
            continue;
          }

          if (!otherVars.Contains(v))
          {
            notInBodyAndHead = true;
          }
        }

        // if it the variable is not in the head and not in the body we remove it from the program
        if (notInBodyAndHead)
        {
          Graph.Program.RemoveAt(i);

          if (i != 0)
          {
            i--;
            break;
          }
        }
      }
    }

    // After removing from the graph we create it again to get the new program rules
    foreach (var scc in Graph.CreateGraph())
    {
      foreach (var posScc in Graph.CreateNewGraphInstance(scc).CreateGraph(true))
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

    HashSet<ProgramRule> uniqueRules = new(groundedProgram);
    List<ProgramRule> deduplicatedRules = new(uniqueRules);

    List<string> availableAtoms = GenerateAvailableAtoms(deduplicatedRules, availableHeads);

    // removes all warning of heads we have found
    _warnings.RemoveAll(availableHeads.Contains);

    // Cleanup the rules, remvoe all which do not make sense
    GroundCleanUp(deduplicatedRules);

    // Add the constraints for the grounded program.
    AddHeadlessRules(deduplicatedRules);

    GroundCleanUp(deduplicatedRules);

    Logger.Logger.Debug("Created grounded program. \n"
        + "Creation duration was " + watch.Stop());

    string rules = "--------------------------------\n";
    foreach (var rule in deduplicatedRules)
    {
      rules += rule.ToString() + "\n";
    }
    Logger.Logger.Debug(rules + "--------------------------------");

    return deduplicatedRules;
  }

  /// <summary>
  /// This function adds all the headless rule constraints if thre is a classical negation 
  /// </summary>
  /// <param name="rules">The frounded Programm</param>
  private void AddHeadlessRules(List<ProgramRule> rules)
  {
    ArgumentNullException.ThrowIfNull(rules, "Is not supposed to be null");

    List<ProgramRule> newHeadlessRules = [];
    foreach (var rule in rules)
    {
      // If it is a choicehead do it for every atom (choice)
      foreach (var atom in rule.Head.GetHeadAtoms())
      {
        try
        {
          var newRule = AddHeadlessRuleForAtom(atom);
          newHeadlessRules.Add(newRule);
        }
        catch (InvalidOperationException) { }
      }
    }

    // Append all found headless rules to the program.
    rules.AddRange(newHeadlessRules);
  }


  /// <summary>
  /// Generates a headless rule for an atom that starts with -
  /// </summary>
  /// <param name="atom">An atom which you want to generate the rule for</param>
  /// <returns>Either null if it does not start with - or a new headless rule</returns>
  private ProgramRule AddHeadlessRuleForAtom(Atom atom)
  {
    ArgumentNullException.ThrowIfNull(atom, "Is not supposed to be null");

    if (!atom.Name.StartsWith("-"))
    {
      throw new InvalidOperationException("Creating a Headless rule for a positve Atom is not allowed");
    }

    // Create a rule where not both can be true not the positve and not the negative atom at the same time
    var negativeAtom = new LiteralBody(new AtomLiteral(true, new Atom(atom.Name, [.. atom.Args])));
    var postiveAtom = new LiteralBody(new AtomLiteral(true, new Atom(atom.Name[1..], [.. atom.Args])));

    return new ProgramRule(new Headless(), [negativeAtom, postiveAtom]);
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
    ArgumentNullException.ThrowIfNull(groundedProgram, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(headNamesOnly, "Is not supposed to be null");

    List<string> availableAtoms = [];

    foreach (var rule in groundedProgram)
    {
      foreach (var atom in rule.Head.GetHeadAtoms())
      {
        availableAtoms.Add(atom.ToString());
        headNamesOnly.Add(atom.Name);
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
  private void GroundCleanUp(List<ProgramRule> groundedProgram)
  {
    ArgumentNullException.ThrowIfNull(groundedProgram, "Is not supposed to be null");

    Logger.Logger.Debug("Cleaning up grounded program.");
    int changes = 0;
    do
    {
      List<string> availableAtoms = GenerateAvailableAtoms(groundedProgram, []);
      changes = 0;

      for (int i = 0; i < groundedProgram.Count; i++)
      {
        foreach (var body in groundedProgram[i].Body)
        {
          // Change this if there somehow comes a new body type like aggregations
          if (body.Accept(new GrounderCleanUpVisitor()))
          {
            // Check if the rule we are lookign at is in the valid rules, if not 
            // we have to get rid of every component of the rule
            AtomLiteral atomLiteral = body.Accept(new TransformToAtomLiteralVisitor()) ?? throw new InvalidOperationException("Trying to transform wrong literal");

            if (availableAtoms.Contains(atomLiteral.Atom.ToString()))
            {
              continue;
            }

            // Now we now that we are making change, because we delete rules and modify the valid atoms
            changes++;

            foreach (var atom in groundedProgram[i].Head.GetHeadAtoms())
            {
              availableAtoms.Remove(atom.ToString());
            }

            groundedProgram.RemoveAt(i);

            // go back in the for loop because the whole list shrunk by one
            if (i != 0)
            {
              i--;
              break;
            }
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
    ArgumentNullException.ThrowIfNull(subPorgram, "Is not supposed to be null");

    var groundedSubProgram = new List<ProgramRule>();

    foreach (var rule in subPorgram)
    {
      // If the body is zero we dont need to ground anything because its either a bodyless choice or a fact
      if (rule.Body.Count == 0)
      {
        groundedSubProgram.Add(rule);
        continue;
      }

      groundedSubProgram.AddRange(GroundRule(rule));
    }

    // Add every rule head to visited for future substitutions
    foreach (var rule in groundedSubProgram)
    {
      foreach (var atom in rule.Head.GetHeadAtoms())
      {
        _visited.Add(atom);
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
    ArgumentNullException.ThrowIfNull(rule, "Is not supposed to be null");

    // If the substitution is null the initialize it with a new dict.
    substitutions ??= [];
    var groundedRules = new List<ProgramRule>();

    if (index >= rule.Body.Count)
    {
      var newRule = rule.Apply(substitutions);

      groundedRules.Add(newRule);
    }

    // Also change this if there is somehow a new body
    if (index < rule.Body.Count)
    {
      var foundMatches = rule.Body[index].Accept(new MatchLiteralVisitor(substitutions, this)) ?? throw new InvalidOperationException("Trying to match literal which is not allowed");
      // Here we look if there are any matches with the current literal and the current substituations
      foreach (var foundSubstituations in foundMatches)
      {
        groundedRules.AddRange(GroundRule(rule, foundSubstituations, index + 1));
      }
    }

    return groundedRules;
  }

  /// <summary>
  /// This function evaluates the truth value of the relation operation
  /// </summary>
  /// <param name="left">Is the Term on the left hand side.</param>
  /// <param name="relation">Is how the Terms are connected for example =, <></param>
  /// <param name="right">Is the Term on the right hand side.</param>
  /// <returns>If the operations succeds or not.</returns>
  private bool EvaluateComparisson(Term left, Relation relation, Term right, Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(left, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(relation, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(right, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    if (relation == Relation.Unification)
    {
      return EvaluateUnification(left, right, substitutions);
    }

    if (left.Accept(new IsNumberVisitor()) && right.Accept(new IsNumberVisitor()))
    {
      var parsedLeft = left.Accept(new ParseNumberVisitor()) ?? throw new InvalidOperationException("Trying to compare something other then number");
      var parsedRight = right.Accept(new ParseNumberVisitor()) ?? throw new InvalidOperationException("Trying to compare something other then number");
      return EvaluateNumber(parsedLeft, relation, parsedRight);
    }

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

  private bool EvaluateUnification(Term left, Term right, Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(left, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(right, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    if (left.HasVariables() && right.HasVariables())
    {
      return false;
    }

    if (!left.HasVariables() && !right.HasVariables())
    {
      return EvaluateComparisson(left, Relation.Equal, right, substitutions);
    }

    if (right.HasVariables() && !left.HasVariables() && right.GetVariables().Count == 1)
    {
      var subs = new Dictionary<string, Term>
      {
        { right.GetVariables()[0], left }
      };
      var newTerm = right.Apply(subs);

      if (!EvaluateComparisson(left, Relation.Equal, newTerm, substitutions))
      {
        return false;
      }

      substitutions.Add(right.GetVariables()[0], left);
      return true;
    }

    if (left.HasVariables() && !right.HasVariables() && left.GetVariables().Count == 1)
    {
      var subs = new Dictionary<string, Term>
      {
        { left.GetVariables()[0], right }
      };
      var newTerm = right.Apply(subs);
      if (!EvaluateComparisson(newTerm, Relation.Equal, right, substitutions))
      {
        return false;
      }

      substitutions.Add(left.GetVariables()[0], right);
      return true;
    }

    return false;
  }

  private bool EvaluateNumber(Number left, Relation relation, Number right)
  {
    ArgumentNullException.ThrowIfNull(left, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(relation, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(right, "Is not supposed to be null");

    return relation switch
    {
      Relation.LessEqual => left.Value <= right.Value,
      Relation.LessThan => left.Value < right.Value,
      Relation.GreaterEqual => left.Value >= right.Value,
      Relation.GreaterThan => left.Value > right.Value,
      Relation.Inequal => left.Value != right.Value,
      Relation.Equal => left.Value == right.Value,
      _ => false,
    };
  }

  /// <summary>
  /// This function searches for all matches for an atom literal.
  /// </summary>
  /// <param name="substitutions">Possible values for the appliers.</param>
  /// <param name="atomLiteral">The literal you want to find matches for.</param>
  /// <returns>A List of possible matches.</returns>
  public List<Dictionary<string, Term>> MatchAtomLiteral(Dictionary<string, Term> substitutions, AtomLiteral atomLiteral)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(atomLiteral, "Is not supposed to be null");

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

  public List<Dictionary<string, Term>> MatchComparisonLiteral(Dictionary<string, Term> substitutions, ComparisonLiteral comparisonLiteral)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(comparisonLiteral, "Is not supposed to be null");

    var left = comparisonLiteral.Left.Apply(substitutions);
    var right = comparisonLiteral.Right.Apply(substitutions);

    // Here we check if the comparisson is valid because if it fails
    // we wont store the substiturions for it.
    if (EvaluateComparisson(left, comparisonLiteral.TermRelation, right, substitutions))
    {
      return [substitutions];
    }

    return [];
  }

  public List<Dictionary<string, Term>> MatchIsLiteral(Dictionary<string, Term> substitutions, IsLiteral isLiteral)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(isLiteral, "Is not supposed to be null");

    var left = isLiteral.Left.Apply(substitutions);
    var right = isLiteral.Right.Apply(substitutions);

    if (!left.Accept(new IsNumberVisitor()) || !right.Accept(new IsNumberVisitor()))
    {
      return [];
    }

    Number parsedLeft = left.Accept(new ParseNumberVisitor()) ?? throw new InvalidOperationException("Trying to evaluate a Term which is not a number");
    Number parsedRight = right.Accept(new ParseNumberVisitor()) ?? throw new InvalidOperationException("Trying to evaluate a Term which is not a number");

    int calculated = 0;

    switch (isLiteral.Operator)
    {
      case Operator.PLUS:
        calculated = parsedLeft.Value + parsedRight.Value;
        break;
      case Operator.MINUS:
        calculated = parsedLeft.Value - parsedRight.Value;
        break;
      case Operator.DIVIDE:
        calculated = parsedLeft.Value / parsedRight.Value;
        break;
      case Operator.MULTIPLY:
        calculated = parsedLeft.Value * parsedRight.Value;
        break;
    }

    substitutions.Add(isLiteral.New.Name, new Number(calculated));
    return [substitutions];
  }

}