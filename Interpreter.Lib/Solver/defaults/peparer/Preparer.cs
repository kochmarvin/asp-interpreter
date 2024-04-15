using System.Data;
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
  /// 
  /// </summary>
  /// <param name="program">The grouned program</param>
  /// <returns>The preperation with all rules that have to get solved.</returns>
  public Preperation Prepare(List<ProgramRule> program)
  {

    List<ProgramRule> factuallyTrue = [];
    List<string> _notAllowed = [];
    List<string> _trueFacts = [];


    // Specificasion of all rules we cannot remove, because they are in a headless rule.
    // And this has to do the solver due to increasing complexity of the preparerer
    foreach (var headlessRule in program.Where(rule => rule.Head is Headless))
    {
      for (int i = 0; i < headlessRule.Body.Count; i++)
      {
        var literal = ((LiteralBody)headlessRule.Body[i]).Literal;

        // Removing all Comparison Literals in a rule because they are just for grounding
        if (literal is ComparisonLiteral)
        {
          headlessRule.Body.RemoveAt(i);
          i--;
          continue;
        }

        // Add literal to the naughty list so they dont get removed
        if (literal is AtomLiteral atomLiteral)
        {
          _notAllowed.Add(literal.ToString());
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


        // if it is a fact (rule without body) we have to maybe add it to the factual true
        if (rule.Head is AtomHead atomHead && rule.Body.Count == 0)
        {
          // if it is contained in a headless rule we dont touch it.
          if (_notAllowed.Contains(atomHead.Atom.ToString()))
          {
            continue;
          }

          //otherwise add it to the factually true string list (for easy comparison) and to the true facts
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
          if (body?.Literal is ComparisonLiteral)
          {
            rule.Body.RemoveAt(j);
            changes++;
            j--;
            continue;
          }

          if (body?.Literal is AtomLiteral atomLiteral)
          {
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

                bool remove = true;
                foreach (var head in program.Select(rule => rule.Head))
                {
                  if (head is ChoiceHead choiceToCheck)
                  {
                    var found = choiceToCheck.Atoms.Where((atom) => atom.ToString() == atomLiteral.Atom.ToString()).ToList();

                    if (found.Count > 0)
                    {
                      remove = false;
                      break;
                    }
                  }

                  if (head is AtomHead atomToCheck && atomToCheck.Atom.ToString() == atomLiteral.Atom.ToString())
                  {
                    remove = false;
                    break;

                  }
                }

                if (remove)
                {
                  rule.Body.RemoveAt(j);
                  j--;
                  changes++;
                }

                continue;
              }

              // If it exists we know that the rule is going to be falls because of the not so remove the rule and 
              // watch the next rule NOT the next body element.
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

    return new Preperation(factuallyTrue, program);
  }
}