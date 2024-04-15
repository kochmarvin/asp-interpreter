using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Solver.Interfaces;

namespace Interpreter.Lib.Solver.defaults;

/*
  TODO Circle detection and adding XOR
*/
public class SatTransformer : ITransformer
{
  private Preperation? _preperation;
  private Dictionary<string, int> _mappedAtoms = [];
  private Dictionary<string, Atom> _mappedRules = [];
  private Dictionary<int, string> _reMappedAtoms = [];

  public List<List<int>> TransformToFormular(Preperation preperation)
  {
    _preperation = preperation;
    if (_preperation.Remainder.Count == 0)
    {
      return [];
    }

    List<List<int>> formular = [];

    int index = 0;
    foreach (var rule in _preperation.Remainder)
    {
      List<int> logicalRule = [];

      if (rule.Head is Headless headless)
      {

        int foundIndex = GetIndexOfString(headless.ToString(), ref index);
        logicalRule.Add(foundIndex);

        // We say that the newley created headless rule is not allowed to happen
        formular.Add([foundIndex * -1]);
        TransformBodyLiterals(rule.Body, logicalRule, ref index);
      }

      if (rule.Head is AtomHead atomHead)
      {
        int foundIndex = GetIndexOfString(atomHead.Atom.ToString(), ref index, atomHead.Atom);

        logicalRule.Add(foundIndex);
        TransformBodyLiterals(rule.Body, logicalRule, ref index);
      }

      if (rule.Head is ChoiceHead choiceHead)
      {
        foreach (var choice in choiceHead.Atoms)
        {
          int foundIndex = GetIndexOfString(choice.ToString(), ref index, choice);

          logicalRule.Add(foundIndex);
          logicalRule.Add(foundIndex * -1);

          TransformBodyLiterals(rule.Body, logicalRule, ref index);
        }
      }

      formular.Add(logicalRule);
    }

    return formular;
  }

  public List<List<Atom>>? ReTransform(List<List<int>> results)
  {
    if (_preperation == null)
    {
      throw new InvalidOperationException("You have to Transform the data first to retransform it!");
    }

    if (results == null)
    {
      return null;
    }

    List<List<Atom>> transformed = [];
    List<Atom> alwaysTrue = [];

    foreach (var rule in _preperation.FactuallyTrue)
    {
      if (rule.Head is AtomHead atomHead)
      {
        alwaysTrue.Add(atomHead.Atom);
      }
    }

    if (results.Count == 0)
    {
      return [alwaysTrue];
    }

    foreach (var set in results)
    {
      List<Atom> answers = [.. alwaysTrue];

      foreach (var variable in set)
      {
        if (variable >= 0)
        {
          if (_reMappedAtoms.TryGetValue(variable, out string? key))
          {
            answers.Add(_mappedRules[key]);
          }
        }
      }

      transformed.Add(answers);
    }

    return transformed;
  }

  private int GetIndexOfString(string signature, ref int index, Atom? atom = null)
  {
    int foundIndex;
    if (!_mappedAtoms.TryGetValue(signature, out foundIndex))
    {
      _mappedAtoms.Add(signature, ++index);
      _reMappedAtoms.Add(index, signature);
      if (atom != null)
      {
        _mappedRules.Add(signature, atom);
      }
      foundIndex = index;
    }

    return foundIndex;
  }

  private void TransformBodyLiterals(List<Body> bodies, List<int> logicalRule, ref int index)
  {
    foreach (var body in bodies)
    {
      if (body is LiteralBody literalBody && literalBody.Literal is AtomLiteral atomLiteral)
      {
        int foundIndex = GetIndexOfString(atomLiteral.Atom.ToString(), ref index, atomLiteral.Atom);

        if (!atomLiteral.Positive)
        {
          logicalRule.Add(foundIndex);
          continue;
        }

        logicalRule.Add(foundIndex * -1);
      }
    }
  }
}