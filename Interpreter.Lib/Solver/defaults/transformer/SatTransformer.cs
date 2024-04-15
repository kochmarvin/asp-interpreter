using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Solver.Interfaces;

namespace Interpreter.Lib.Solver.defaults;

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
        int foundIndex;
        if (!_mappedAtoms.TryGetValue(headless.ToString(), out foundIndex))
        {
          _mappedAtoms.Add(headless.ToString(), ++index);
          _reMappedAtoms.Add(index, headless.ToString());
          foundIndex = index;
        }

        logicalRule.Add(foundIndex);
        formular.Add([foundIndex * -1]);

        foreach (var body in rule.Body)
        {
          if (body is LiteralBody literalBody)
          {
            var literal = literalBody.Literal;

            if (literal is AtomLiteral atomLiteral)
            {
              if (!_mappedAtoms.TryGetValue(atomLiteral.Atom.ToString(), out foundIndex))
              {
                _mappedAtoms.Add(atomLiteral.Atom.ToString(), ++index);
                _mappedRules.Add(atomLiteral.Atom.ToString(), atomLiteral.Atom);
                _reMappedAtoms.Add(index, atomLiteral.Atom.ToString());
                foundIndex = index;
              }

              if (!atomLiteral.Positive)
              {
                logicalRule.Add(foundIndex);
              }
              else
              {
                logicalRule.Add(foundIndex * -1);
              }
            }

          }
        }

        // We say that the newley created headless rule is not allowed to happen
      }

      if (rule.Head is AtomHead atomHead)
      {
        int foundIndex;
        if (!_mappedAtoms.TryGetValue(atomHead.Atom.ToString(), out foundIndex))
        {
          _mappedAtoms.Add(atomHead.Atom.ToString(), ++index);
          _mappedRules.Add(atomHead.Atom.ToString(), atomHead.Atom);
          _reMappedAtoms.Add(index, atomHead.Atom.ToString());
          foundIndex = index;
        }

        logicalRule.Add(foundIndex);

        foreach (var body in rule.Body)
        {
          if (body is LiteralBody literalBody)
          {
            var literal = literalBody.Literal;

            if (literal is AtomLiteral atomLiteral)
            {
              if (!_mappedAtoms.TryGetValue(atomLiteral.Atom.ToString(), out foundIndex))
              {
                _mappedAtoms.Add(atomLiteral.Atom.ToString(), ++index);
                _mappedRules.Add(atomLiteral.Atom.ToString(), atomLiteral.Atom);
                _reMappedAtoms.Add(index, atomLiteral.Atom.ToString());
                foundIndex = index;
              }

              if (!atomLiteral.Positive)
              {
                logicalRule.Add(foundIndex);
              }
              else
              {
                logicalRule.Add(foundIndex * -1);
              }
            }
          }
        }
      }

      if (rule.Head is ChoiceHead choiceHead)
      {
        foreach (var choice in choiceHead.Atoms)
        {
          int foundIndex;
          if (!_mappedAtoms.TryGetValue(choice.ToString(), out foundIndex))
          {
            _mappedAtoms.Add(choice.ToString(), ++index);
            _mappedRules.Add(choice.ToString(), choice);
            _reMappedAtoms.Add(index, choice.ToString());
            foundIndex = index;
          }

          logicalRule.Add(foundIndex);
          logicalRule.Add(foundIndex * -1);

          foreach (var body in rule.Body)
          {
            if (body is LiteralBody literalBody)
            {
              var literal = literalBody.Literal;

              if (literal is AtomLiteral atomLiteral)
              {
                if (!_mappedAtoms.TryGetValue(atomLiteral.Atom.ToString(), out foundIndex))
                {
                  _mappedAtoms.Add(atomLiteral.Atom.ToString(), ++index);
                  _mappedRules.Add(atomLiteral.Atom.ToString(), atomLiteral.Atom);
                  _reMappedAtoms.Add(index, atomLiteral.Atom.ToString());
                  foundIndex = index;
                }

                if (!atomLiteral.Positive)
                {
                  logicalRule.Add(foundIndex);
                }
                else
                {
                  logicalRule.Add(foundIndex * -1);
                }
              }
            }
          }
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
}