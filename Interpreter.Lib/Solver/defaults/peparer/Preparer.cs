using System.Data;
using Interpreter.Lib.Graph;
using Interpreter.Lib.Logger;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Solver.Interfaces;

namespace Interpreter.Lib.Solver.defaults;

/// <summary>
/// The preperator removes all facts from bodys we know have to be true, it also removes all facts from the program
/// This is done to create a much smaller program for the following DPLL. Because facts have always to be true we just 
/// can assume that they are true nontherless. After stating that all facts are always true we look at the bodys of the rules.
/// because if a body is just a concatination of facts that we know are true, the rule itself also has to be true.
/// </summary>
public class Preparer : IPreparer
{
  /// <summary>
  /// This method checks the program for facts that are definitely true and goes thru every rule to remove any facts 
  /// that are known to be true due to these facts.
  /// </summary>
  /// <param name="program">The grouned program</param>
  /// <returns>The preperation with all rules that have to get solved.</returns>
  public Preperation Prepare(List<ProgramRule> program)
  {
    var watch = StopWatch.Start();
    List<ProgramRule> factuallyTrue = [];
    List<string> _notAllowed = [];
    List<string> _trueFacts = [];
    List<string> _heads = [];

    foreach (var rule in program)
    {
      // if it is a headless rule we skip 
      if (rule.Head is Headless)
      {
        continue;
      }

      if (rule.Head is AtomHead atomHead)
      {
        _heads.Add(atomHead.Atom.ToString());
      }

      if (rule.Head is ChoiceHead choiceHead)
      {
        _heads.AddRange(choiceHead.Atoms.Select(atom => atom.ToString()));
      }
    }

    // Specificasion of all rules we cannot remove, because they are in a headless rule.
    // And this has to do the solver due to increasing complexity of the preparerer
    foreach (var headlessRule in program.Where(rule => rule.Head is Headless))
    {
      for (int i = 0; i < headlessRule.Body.Count; i++)
      {
        var literal = ((LiteralBody)headlessRule.Body[i]).Literal;

        // Removing all Comparison Literals in a rule because they are just for grounding
        if (literal is ComparisonLiteral || literal is IsLiteral)
        {
          Logger.Logger.Debug("Remove " + headlessRule.Body[i] + " from " + headlessRule);
          headlessRule.Body.RemoveAt(i);
          i--;
          continue;
        }

        // Add literal to the naughty list so they dont get removed
        if (literal is AtomLiteral atomLiteral)
        {
          _notAllowed.Add(literal.ToString() ?? "");
        }
      }
    }

    int changes = 0;

    // perform this loop as long as there was a single change
    do
    {
      changes = 0;
      for (int i = 0; i < program.Count; i++)
      {
        var rule = program[i];

        // if it is a headless rule we just skip it.
        if (rule.Head is Headless)
        {
          continue;
        }

        // if it is a fact (rule without body) and does not start with a minus we have to maybe add it to the factual true
        if (rule.Head is AtomHead atomHead && rule.Body.Count == 0 && !atomHead.Atom.Name.StartsWith("-"))
        {
          // if it is contained in a headless rule we dont touch it.
          if (_notAllowed.Contains(atomHead.Atom.ToString()))
          {
            continue;
          }

          // otherwise add it to the factually true string list (for easy comparison) and to the true facts
          factuallyTrue.Add(rule);
          _trueFacts.Add(atomHead.Atom.ToString());

          // also remove it from the program because it is always going to be true
          program.RemoveAt(i);

          // tell the loop we made a change to the program.
          changes++;
          i--;
          continue;
        }

        for (int j = 0; j < rule.Body.Count; j++)
        {
          var body = rule.Body[j] as LiteralBody;

          // If it is a Comparison Literal we just remove it because there is no logical equivalent (just neccessary for grounding)
          // TODO check if assumtion is correct
          if (body?.Literal is ComparisonLiteral || body?.Literal is IsLiteral)
          {
            Logger.Logger.Debug("Remove " + rule.Body[j] + " from " + rule);
            rule.Body.RemoveAt(j);
            changes++;
            j--;
            continue;
          }

          if (body?.Literal is AtomLiteral atomLiteral)
          {
            // if it is contained in a headless rule we dont touch it.
            if (_notAllowed.Contains(atomLiteral.ToString()))
            {
              continue;
            }

            // Here we look if the literal is not positive
            if (!atomLiteral.Positive)
            {
              // if it is not positive and we do not know that it exists as a fact we skip it
              if (!_trueFacts.Contains(atomLiteral.Atom.ToString()))
              {
                // if we know that it exists as a fact we check 
                bool remove = true;
                foreach (var head in program.Select(rule => rule.Head))
                {
                  // if the atom we are looking at exists in a choice head we dont remove it 
                  if (head is ChoiceHead choiceToCheck)
                  {
                    var found = choiceToCheck.Atoms.Where((atom) => atom.ToString() == atomLiteral.Atom.ToString()).ToList();

                    if (found.Count > 0)
                    {
                      remove = false;
                      break;
                    }
                  }

                  // if the atom we are looking at is an atom head in the program we dont remove it
                  if (head is AtomHead atomToCheck && atomToCheck.Atom.ToString() == atomLiteral.Atom.ToString())
                  {
                    remove = false;
                    break;

                  }
                }

                // if the negative atom we are looking at didnt exist in any choice or atom head we can remove it 
                // because we know that is is true (negation as failure)
                if (remove)
                {
                  Logger.Logger.Debug("Remove " + rule.Body[j] + " from " + rule);
                  rule.Body.RemoveAt(j);
                  j--;
                  changes++;
                }

                continue;
              }

              // If it exists we know that the rule is going to be false because of the not so remove the whole rule 
              // and watch the next rule NOT the next body element.
              program.RemoveAt(i);
              i--;
              changes++;
              break;
            }

            // Here we check if the current atom we look at is a trueFact which means a bodyless fact e.g person(julia).
            // If this is the case we know that this is always going to be true and we can remove it.
            if (_trueFacts.Contains(atomLiteral.Atom.ToString()))
            {
              rule.Body.RemoveAt(j);
              j--;
              changes++;
              continue;
            }
          }

        }
      }
    } while (changes != 0);

    var loopRules = FindLoopRules(program);

    string rules = "Loop Rules \n--------------------------------\n";
    foreach (var rule in loopRules)
    {
      rules += rule.ToString() + "\n";
    }
    Logger.Logger.Debug(rules + "--------------------------------");

    Logger.Logger.Debug("Minimized program for solver. \n"
           + "Duration was " + watch.Stop());
    return new Preperation(factuallyTrue, program, loopRules);
  }

  /// <summary>
  /// This method checks for any loop rules in the program which are any amount of rules that are 
  /// dependent on each other. 
  /// </summary>
  /// <param name="program">The smaller programm after preparing.</param>
  /// <returns>A list of all the loop rules found in the program.</returns>
  public List<LoopRule> FindLoopRules(List<ProgramRule> program)
  {
    var watch = StopWatch.Start();
    DependencyGraph g = new DependencyGraph(program);
    List<LoopRule> loopRules = [];
    Dictionary<string, LoopRule> rules = [];

    // Go through each subgraph of the grounded program.
    // A subgraph contains all rules which have a loop in it
    // x :- y.
    // y :- x, b.
    // The above would be one subgraph because it has a loop in it x and y.
    // x :- a, not c.
    // this would be its own subgraph because it does not have anything of the loop in it.
    foreach (var subGraph in g.CreateGraph(true))
    {
      LoopRule loopRule = new();
      HashSet<string> heads = [];
      List<Atom> headsReference = [];

      // Now we go through every rule and save the heads
      foreach (var rule in subGraph)
      {
        if (rule.Head is ChoiceHead choices)
        {
          headsReference.AddRange(choices.Atoms);
          choices.Atoms.ForEach(atom => heads.Add(atom.ToString()));
          // TODO checken ob da noch was her gehört
        }

        if (rule.Head is AtomHead atomHead)
        {
          // Here we add the reference for later connections
          // and the head string for easier matching
          headsReference.Add(atomHead.Atom);
          heads.Add(atomHead.Atom.ToString());

          // If we find a rule which has the same head as we do have, we add every rule from our body
          // to the loop rule, because we know for a fact, that it is external support
          if (rules.TryGetValue(atomHead.Atom.ToString(), out LoopRule? loop))
          {
            loopRule = loop;
            List<AtomLiteral> literals = [];
            rule.Body.ForEach(body =>
            {
              if (body is LiteralBody literalBody && literalBody.Literal is AtomLiteral al)
              {
                literals.Add(al);
              }
            }
            );

            loop.AddBody(literals);
          }
        }
      }

      // Now we go through every rule again
      foreach (var rule in subGraph)
      {
        foreach (var body in rule.Body)
        {
          if (body is LiteralBody literalBody && literalBody.Literal is AtomLiteral atomLiteral)
          {
            // If the literal is not positiv we skip it
            if (!atomLiteral.Positive)
            {
              continue;
            }

            // if the heads do not contain the literal of the body we are currently looking at
            // we skip it as well
            if (!heads.Contains(atomLiteral.Atom.ToString()))
            {
              continue;
            }

            // if the heads contain it we know that for this rule, there has to be a loop rule
            foreach (var reference in headsReference)
            {
              // We add every head we saw in the subgraph to the loop rule
              loopRule.AddHead(reference);

              // For every string we store the loop rule for easier access later on
              // so if the current graph is 
              // x :- y.
              // y :- x
              // we add the same reference loop rule for x and y
              rules.TryAdd(reference.ToString(), loopRule);
            }
          }
        }
      }
    }

    foreach (var pair in rules)
    {
      loopRules.Add(pair.Value);
    }

    Logger.Logger.Debug("Added looprules for solver. \n"
           + "Duration was " + watch.Stop());

    return loopRules;
  }
}