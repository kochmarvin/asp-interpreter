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
using Interpreter.Lib.Logger;

namespace Interpreter.Lib.Solver.defaults;

/*
  TODO Classical negation add
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
    var watch = StopWatch.Start();
    _preperation = preperation;
    List<ConjunctiveNormalForm.Expression> expressions = [];

    int index = 1;
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

          Logger.Logger.Error("" + foundIndex);

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

        if (rule.Body.Count == 0)
        {
          expressions.Add(CNFWrapper.CreateVariable(foundIndex));
          continue;
        }

        var orRules = preperation.Remainder.
        Where(watchRule => watchRule != rule).
        Where(rule => rule.Head is AtomHead).
        Where(rule => rule.Body.Count > 0).
        Where(
          rule =>
          {
            var ruleHead = rule.Head as AtomHead;
            return ruleHead?.Atom.ToString() == atomHead.Atom.ToString();
          }
        ).ToList();


        string rules = "Or Rules for " + rule + " \n--------------------------------\n";
        foreach (var orRule in orRules)
        {
          rules += orRule.ToString() + "\n";
        }
        Logger.Logger.Debug(rules + "--------------------------------");
        _preperation.Remainder.RemoveAll(orRules.Contains);

        expressions.Add(TransformBodyLiterals(foundIndex, rule.Body, orRules, ref index));
      }
    }

    foreach (var loopRule in _preperation.LoopRules)
    {

      CNFWrapper expresion = CNFWrapper.NewExpression();
      ConjunctiveNormalForm.Expression left;
      ConjunctiveNormalForm.Expression right;
      if (loopRule.Head.Count > 1)
      {
        expresion = CNFWrapper.NewExpression().SetOr
        (CNFWrapper.CreateVariable(_mappedAtoms[loopRule.Head[0].ToString()]),
          CNFWrapper.CreateVariable(_mappedAtoms[loopRule.Head[1].ToString()])
        );

        for (int i = 2; i < loopRule.Head.Count; i++)
        {
          expresion.AddOr(CNFWrapper.CreateVariable(_mappedAtoms[loopRule.Head[i].ToString()]));
        }

        left = expresion.Create();
      }
      else
      {
        left = CNFWrapper.CreateVariable(_mappedAtoms[loopRule.Head[0].ToString()]);
      }

      right = LoopRuleOrBody(loopRule.Body, ref index);
      expressions.Add(CNFWrapper.NewExpression().SetImplication(left, right).Create());
    }

    List<List<int>> results = [];
    foreach (var expression in expressions)
    {
      Logger.Logger.Debug(expression.ToString());
      var cnf = ConjunctiveNormalForm.createCNF(expression);
      var list = ConjunctiveNormalForm.cnfToList(cnf);

      results.AddRange(ConvertFSharpListToList(list));
    }

    foreach (var map in _mappedAtoms)
    {
      Logger.Logger.Debug(map.Key + " is equivalent to " + map.Value);
    }

    results.Add([-1]);
    Logger.Logger.Debug("Created CNF for programm. \n"
               + "Duration was " + watch.Stop());
    return results.Distinct(new ListComparer<int>()).ToList();
  }

  private ConjunctiveNormalForm.Expression LoopRuleOrBody(List<List<AtomLiteral>> atomLiterals, ref int index)
  {
    if (atomLiterals.Count == 0)
    {
      return CNFWrapper.CreateNegativeVariable(CNFWrapper.CreateNegativeVariable(1));
    }

    if (atomLiterals.Count == 1)
    {
      return LoopRuleAndBody(atomLiterals[0], ref index);
    }

    CNFWrapper expression = CNFWrapper.NewExpression();
    expression.SetOr(LoopRuleAndBody(atomLiterals[0], ref index), LoopRuleAndBody(atomLiterals[1], ref index));

    for (int i = 2; i < atomLiterals.Count; i++)
    {
      expression.AddOr(LoopRuleAndBody(atomLiterals[i], ref index));
    }

    return expression.Create();
  }

  private ConjunctiveNormalForm.Expression LoopRuleAndBody(List<AtomLiteral> atomLiterals, ref int index)
  {
    if (atomLiterals.Count == 1)
    {
      return LoopAtomLiteralExpression(atomLiterals[0], ref index);
    }

    CNFWrapper expression = CNFWrapper.NewExpression();
    expression.SetAnd(LoopAtomLiteralExpression(atomLiterals[0], ref index),
    LoopAtomLiteralExpression(atomLiterals[1], ref index));

    for (int i = 2; i < atomLiterals.Count; i++)
    {
      expression.AddAnd(LoopAtomLiteralExpression(atomLiterals[i], ref index));
    }

    return expression.Create();
  }


  public List<List<Atom>> ReTransform(List<List<int>> results)
  {
    if (_preperation == null)
    {
      throw new InvalidOperationException("You have to Transform the data first to retransform it!");
    }

    if (results.Count == 0)
    {
      return [];
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

      Logger.Logger.Debug("SET NUMBERS = " + string.Join(", ", set));
      foreach (var variable in set)
      {
        if (_reMappedAtoms.TryGetValue(variable, out string? key))
        {
          if (string.IsNullOrEmpty(key))
          {
            continue;
          }

          answers.Add(_mappedRules[key]);
        }
      }

      transformed.Add(answers);
    }

    List<List<Atom>> uniqueAtomLists = transformed.Select(list =>
           list
               .GroupBy(atom => atom.ToString())
               .Select(g => g.First())
               .OrderByDescending(atom => atom.ToString())
               .ToList()
       ).ToList();

    HashSet<string> uniqueListRepresentations = new(
        uniqueAtomLists.Select(list => string.Join(",", list.Select(atom => atom.ToString())))
    );

    List<List<Atom>> distinctAtomLists = uniqueAtomLists
        .Where(list => uniqueListRepresentations.Contains(string.Join(",", list.Select(atom => atom.ToString()))))
        .ToList();


    return distinctAtomLists;
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


  private ConjunctiveNormalForm.Expression TransformBodyLiterals(int headIndex, List<Body> bodies, List<ProgramRule> orBodies, ref int index, int fictionalIndex = -1)
  {
    if (headIndex == -1)
    {
      throw new InvalidOperationException("The head is not possible to be a negative number");
    }

    var headExpression = CNFWrapper.CreateVariable(headIndex);

    if (bodies.Count == 1 && orBodies.Count == 0 && fictionalIndex == -1)
    {
      return CNFWrapper.NewExpression()
      .SetEquality(headExpression, AtomLiteralExpression(bodies[0], ref index)).Create();
    }

    CNFWrapper expression = CNFWrapper.NewExpression();

    if (bodies.Count == 1 && orBodies.Count >= 1 && fictionalIndex == -1)
    {
      expression = expression.SetOr(AtomLiteralExpression(bodies[0], ref index), TransformAnd(orBodies[0], ref index));
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

    int andStartIndex = fictionalIndex != -1 ? 1 : 2;
    for (int i = andStartIndex; i < bodies.Count; i++)
    {
      var bodyExpression = AtomLiteralExpression(bodies[i], ref index);
      expression = expression.AddAnd(bodyExpression);
    }

    int orStartIndex = bodies.Count == 1 ? 1 : 0;
    for (int i = orStartIndex; i < orBodies.Count; i++)
    {
      expression = expression.AddOr(TransformOrBodie(orBodies, ref index));
    }

    var y = expression.Create();

    return CNFWrapper.NewExpression().SetEquality(headExpression, y).Create();
  }

  private ConjunctiveNormalForm.Expression TransformOrBodie(List<ProgramRule> orBodies, ref int index)
  {
    if (orBodies.Count == 1)
    {
      return TransformAnd(orBodies[0], ref index);
    }

    CNFWrapper orExpression = CNFWrapper.NewExpression();

    orExpression.SetOr(TransformAnd(orBodies[0], ref index), TransformAnd(orBodies[1], ref index));

    for (int i = 2; i < orBodies.Count; i++)
    {
      orExpression.AddOr(TransformAnd(orBodies[0], ref index));
    }

    return orExpression.Create();
  }

  public ConjunctiveNormalForm.Expression TransformAnd(ProgramRule rule, ref int index)
  {
    if (rule.Body.Count == 1)
    {
      return AtomLiteralExpression(rule.Body[0], ref index);
    }

    CNFWrapper expression = CNFWrapper.NewExpression();

    expression.SetAnd(
      AtomLiteralExpression(rule.Body[0], ref index),
      AtomLiteralExpression(rule.Body[1], ref index)
    );

    for (int i = 2; i < rule.Body.Count; i++)
    {
      expression.AddAnd(AtomLiteralExpression(rule.Body[i], ref index));
    }

    return expression.Create();
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
      ++index;

      if (signature.StartsWith("-"))
      {
        _mappedAtoms.Add(signature, index);
        _mappedAtoms.Add(signature[1..], -index);
        foundIndex = -index;
      }
      else
      {
        _mappedAtoms.Add(signature, index);
        _mappedAtoms.Add("-" + signature, -index);
        foundIndex = index;
      }

      _reMappedAtoms.Add(index, signature);

      if (atom != null)
      {
        _mappedRules.Add(signature, atom);
      }

    }

    if (!_reMappedAtoms.TryGetValue(foundIndex, out string? sig))
    {
      _reMappedAtoms[foundIndex] = signature;
    }

    return foundIndex;
  }

  private ConjunctiveNormalForm.Expression AtomLiteralExpression(Body body, ref int index)
  {
    var atomLiteral = GetAtomOfBody(body);
    return LoopAtomLiteralExpression(atomLiteral, ref index);
  }

  private ConjunctiveNormalForm.Expression LoopAtomLiteralExpression(AtomLiteral atomLiteral, ref int index)
  {
    int foundIndex = GetIndexOfString(atomLiteral.Atom.ToString(), ref index, atomLiteral.Atom);
    return CreateDynamicVariable(atomLiteral, foundIndex);
  }
}