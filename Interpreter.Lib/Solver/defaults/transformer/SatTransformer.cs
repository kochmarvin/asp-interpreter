using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Solver.Interfaces;
using Interpreter.FunctionalLib;
using System.Linq.Expressions;
using Microsoft.FSharp.Collections;
using Antlr4.Runtime.Atn;

namespace Interpreter.Lib.Solver.defaults;

/*
  TODO Circle detection and adding XOR
*/
public class SatTransformer : ITransformer
{
  private Preperation? _preperation;
  private Dictionary<string, int> _mappedAtoms = [];
  private Dictionary<int, int> _choiceNotState = [];
  private Dictionary<string, Atom> _mappedRules = [];
  private Dictionary<int, string> _reMappedAtoms = [];

  public List<List<int>> TransformToFormular(Preperation preperation)
  {
    _preperation = preperation;
    List<ConjunctiveNormalForm.Expression> expressions = [];

    int index = 0;

    for (int i = 0; i < preperation.Remainder.Count; i++)
    {
      var rule = preperation.Remainder[i];
      if (rule.Head is Headless headless)
      {
        expressions.Add(TransformHeadless(rule.Body, ref index));
      }

      if (rule.Head is ChoiceHead choiceHead)
      {
        foreach (var choice in choiceHead.Atoms)
        {
          int foundIndex = GetIndexOfString(choice.ToString(), ref index, choice);
          int notIndex = GetNotStateOfChoice(foundIndex, ref index);

          expressions.Add(CNFWrapper.NewExpression().SetXor(
            CNFWrapper.CreateVariable(foundIndex),
            CNFWrapper.CreateVariable(notIndex)).Create()
          );

          if (rule.Body.Count > 0)
          {
            expressions.Add(TransformBodyLiterals(foundIndex, rule.Body, [], ref index, notIndex));
          }
        }
      }

      if (rule.Head is AtomHead atomHead)
      {
        int foundIndex = GetIndexOfString(atomHead.Atom.ToString(), ref index, atomHead.Atom);

        if (rule.Body.Count > 0)
        {
          var orRules = preperation.Remainder.
          Where(watchRule => watchRule != rule).
          Where(rule => rule.Head is AtomHead).
          Where(
            rule =>
            {
              var ruleHead = rule.Head as AtomHead;
              return ruleHead?.Atom.ToString() == atomHead.Atom.ToString();
            }
          ).ToList();

          _preperation.Remainder.RemoveAll(orRules.Contains);

          Console.WriteLine("====[OR RUles]====");
          Console.WriteLine("This: " + rule.ToString());
          foreach (var orRule in orRules)
          {
            Console.WriteLine(orRule.ToString());
          }
          Console.WriteLine("====[OR RUles]====");

          expressions.Add(TransformBodyLiterals(foundIndex, rule.Body, orRules.SelectMany(orRule => orRule.Body).ToList(), ref index));
        }
      }
    }

    foreach (var key in _mappedAtoms.Keys)
    {
      Console.WriteLine(key + " = " + _mappedAtoms[key]);
    }

    List<List<int>> results = [];
    foreach (var expression in expressions)
    {
      var cnf = ConjunctiveNormalForm.createCNF(expression);
      var list = ConjunctiveNormalForm.cnfToList(cnf);

      results.AddRange(ConvertFSharpListToList(list));
    }

    return results;
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

  private List<List<int>> ConvertFSharpListToList(FSharpList<FSharpList<int>> fsharpListOfLists)
  {
    return ListModule.OfSeq(fsharpListOfLists)
           .Select(fsharpList => ListModule.OfSeq(fsharpList).ToList())
           .ToList();
  }

  private ConjunctiveNormalForm.Expression TransformHeadless(List<Body> bodies, ref int index)
  {

    if (bodies.Count == 1)
    {
      var singleExpression = AtomLiteralExpression(bodies[0], ref index);
      return CNFWrapper.CreateNegativeVariable(singleExpression);
    }

    CNFWrapper expression = CNFWrapper.NewExpression();

    var leftExpression = AtomLiteralExpression(bodies[0], ref index);
    var rightExpression = AtomLiteralExpression(bodies[1], ref index);
    expression = CNFWrapper.NewExpression().SetAnd(leftExpression, rightExpression);

    for (int i = 2; i < bodies.Count; i++)
    {
      var bodyExpression = AtomLiteralExpression(bodies[i], ref index);
      expression = expression.AddAnd(bodyExpression);
    }

    return CNFWrapper.CreateNegativeVariable(expression.Create());
  }


  private ConjunctiveNormalForm.Expression TransformBodyLiterals(int headIndex, List<Body> bodies, List<Body> orBodies, ref int index, int fictionalIndex = -1)
  {
    if (headIndex == -1)
    {
      throw new InvalidOperationException("The head is not possible to be a negative number");
    }

    var headExpression = CNFWrapper.CreateVariable(headIndex);

    Console.WriteLine(orBodies.Count);
    Console.WriteLine(bodies.Count == 1 && orBodies.Count == 0 && fictionalIndex == -1);

    if (bodies.Count == 1 && orBodies.Count == 0 && fictionalIndex == -1)
    {
      Console.WriteLine("HALLO");
      return CNFWrapper.NewExpression()
      .SetEquality(headExpression, AtomLiteralExpression(bodies[0], ref index)).Create();
    }

    CNFWrapper expression = CNFWrapper.NewExpression();

    if (bodies.Count == 1 && orBodies.Count >= 1 && fictionalIndex == -1)
    {
      Console.WriteLine("BODIES " + bodies.Count);
      Console.WriteLine("ORBODIES " + orBodies.Count);
      expression = expression.SetOr(AtomLiteralExpression(bodies[0], ref index), AtomLiteralExpression(orBodies[0], ref index));
    }

    if (bodies.Count >= 1 && fictionalIndex != -1)
    {
      expression = expression.SetAnd(AtomLiteralExpression(bodies[0], ref index), CNFWrapper.CreateNegativeVariable(fictionalIndex));
    }

    if (bodies.Count >= 2 && fictionalIndex == -1)
    {
      var leftExpression = AtomLiteralExpression(bodies[0], ref index);
      var rightExpression = AtomLiteralExpression(bodies[1], ref index);
      expression = CNFWrapper.NewExpression().SetAnd(leftExpression, rightExpression);
    }

    for (int i = 2; i < bodies.Count; i++)
    {
      var bodyExpression = AtomLiteralExpression(bodies[i], ref index);
      expression = expression.AddAnd(bodyExpression);
    }

    for (int i = 1; i < orBodies.Count; i++)
    {
      var bodyExpression = AtomLiteralExpression(orBodies[i], ref index);
      expression = expression.AddOr(bodyExpression);
    }

    var y = expression.Create();

    return CNFWrapper.NewExpression().SetEquality(headExpression, y).Create();
  }

  private AtomLiteral GetAtomOfBody(Body body)
  {
    if (body is LiteralBody literalBody && literalBody.Literal is AtomLiteral atomLiteral)
    {
      return atomLiteral;
    }
    throw new InvalidOperationException("Somehow a body literal, not of type AtomLiteral has come accross my way");
  }

  private ConjunctiveNormalForm.Expression CreateDynamicVariable(AtomLiteral literal, int index)
  {
    return literal.Positive ? CNFWrapper.CreateVariable(index) :
      CNFWrapper.CreateNegativeVariable(index);
  }


  private int GetNotStateOfChoice(int choiceIndex, ref int index)
  {
    int notIndex;
    if (!_choiceNotState.TryGetValue(choiceIndex, out notIndex))
    {
      notIndex = ++index;
      _choiceNotState.Add(choiceIndex, notIndex);
    }

    return notIndex;
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

  private ConjunctiveNormalForm.Expression AtomLiteralExpression(Body body, ref int index)
  {
    var atomLiteral = GetAtomOfBody(body);
    int foundIndex = GetIndexOfString(atomLiteral.Atom.ToString(), ref index, atomLiteral.Atom);
    return CreateDynamicVariable(atomLiteral, foundIndex);
  }
}