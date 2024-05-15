using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Solver.Interfaces;
using Interpreter.FunctionalLib;
using Microsoft.FSharp.Collections;
using Interpreter.Lib.Logger;

namespace Interpreter.Lib.Solver.defaults;

/// <summary>
/// Implementation of the default sat transformer.
/// </summary>
public class SatTransformer : ITransformer
{
  private Preperation? _preperation;

  // Dictionary to find the corresponding index for a atom string
  private Dictionary<string, int> _mappedAtoms = [];

  // Dictionary to find the fictional state of a choice index.
  private Dictionary<int, int> _choiceNotState = [];

  // Dictionary to have a reference of the atom based on its string
  private Dictionary<string, Atom> _mappedRules = [];

  // Dictionary which is reveresed to  get the string of Atom based on its index.
  private Dictionary<int, string> _reMappedAtoms = [];

  /// <summary>
  /// Transforms a formular pased on the remainder of the preperation.
  /// </summary>
  /// <param name="preperation">The preperation which the preparer produced.</param>
  /// <returns>A List with list of integers where each row is and and each col or combined.</returns>
  public List<List<int>> TransformToFormular(Preperation preperation)
  {
    var watch = StopWatch.Start();
    _preperation = preperation;

    // Create an empty list of F# expressions
    List<ConjunctiveNormalForm.Expression> expressions = [];

    // Index reference for the atom to add it up.
    int index = 1;
    for (int i = 0; i < preperation.Remainder.Count; i++)
    {
      var rule = preperation.Remainder[i];

      // If the rule is headless we transform the headless expression
      if (rule.Head is Headless headless)
      {
        expressions.Add(TransformHeadless(rule.Body, ref index));
      }

      // If the rule head is a choice we transform the choice expression
      if (rule.Head is ChoiceHead choiceHead)
      {
        foreach (var choice in choiceHead.Atoms)
        {
          // Generate or find a new index for the string of the choice.
          int foundIndex = GetIndexOfString(choice.ToString(), ref index, choice);

          // Generate or find a new index for the fictional index "choice not active" state
          int notIndex = GetNotStateOfChoice(foundIndex, ref index);

          // Create a new expression and combine it XOR to get either fictional or the choice itself.
          expressions.Add(CNFWrapper.NewExpression().SetXor(
            CNFWrapper.CreateVariable(foundIndex),
            CNFWrapper.CreateVariable(notIndex)).Create()
          );

          // If the choice has a body parse the body.
          if (rule.Body.Count > 0)
          {
            expressions.Add(TransformBodyLiterals(foundIndex, rule.Body, [], ref index, notIndex));
          }
        }
      }

      // if the rule is a simple head we transform it
      if (rule.Head is AtomHead atomHead)
      {
        // Firstly generate or find the index of the head atom.
        int foundIndex = GetIndexOfString(atomHead.Atom.ToString(), ref index, atomHead.Atom);

        // If the body has no elements we just ad it as a variable to the expression
        if (rule.Body.Count == 0)
        {
          expressions.Add(CNFWrapper.CreateVariable(foundIndex));
          continue;
        }

        // Finding all or rules with linq. This are all rules which heave the same head as me
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

        // Print out or rules if there are any in debug mode
        string rules = "Or Rules for " + rule + " \n--------------------------------\n";
        foreach (var orRule in orRules)
        {
          rules += orRule.ToString() + "\n";
        }
        Logger.Logger.Debug(rules + "--------------------------------");

        // Remove all rule we found so the wont get transformed again.
        _preperation.Remainder.RemoveAll(orRules.Contains);

        // Transform the body with the correspongin orrules
        expressions.Add(TransformBodyLiterals(foundIndex, rule.Body, orRules, ref index));
      }
    }

    // Add the transformed expression for the loop rules
    foreach (var loopRule in _preperation.LoopRules)
    {
      // create a new expression and define left and right
      CNFWrapper expresion = CNFWrapper.NewExpression();
      ConjunctiveNormalForm.Expression left;
      ConjunctiveNormalForm.Expression right;

      // if the looprule head is greater then one we have to compne all heads or
      if (loopRule.Head.Count > 1)
      {
        // firstly we take the first and second elemnt and set them combined to or.
        expresion = CNFWrapper.NewExpression().SetOr
        (CNFWrapper.CreateVariable(_mappedAtoms[loopRule.Head[0].ToString()]),
          CNFWrapper.CreateVariable(_mappedAtoms[loopRule.Head[1].ToString()])
        );

        // after that for every next element we just add an or
        for (int i = 2; i < loopRule.Head.Count; i++)
        {
          expresion.AddOr(CNFWrapper.CreateVariable(_mappedAtoms[loopRule.Head[i].ToString()]));
        }

        // last step is to create the expression
        left = expresion.Create();
      }
      else
      {
        // if there is only one head we create the variable.
        left = CNFWrapper.CreateVariable(_mappedAtoms[loopRule.Head[0].ToString()]);
      }

      // For the right side we parse the loop rule body.
      right = LoopRuleOrBody(loopRule.Body, ref index);

      // Lastly create a new implication with the left and right side.
      expressions.Add(CNFWrapper.NewExpression().SetImplication(left, right).Create());
    }

    List<List<int>> results = [];

    // After all expression have been parsed we generate with F# the cnf and convert it to a list.
    foreach (var expression in expressions)
    {
      Logger.Logger.Debug(expression.ToString());
      var cnf = ConjunctiveNormalForm.createCNF(expression);
      var list = ConjunctiveNormalForm.cnfToList(cnf);

      results.AddRange(ConvertFSharpListToList(list));
    }

    // For debug purposes we print it out in debug mode.
    foreach (var map in _mappedAtoms)
    {
      Logger.Logger.Debug(map.Key + " is equivalent to " + map.Value);
    }

    // Add the -1 state to every cnf with corresponds to the "falsum" state
    results.Add([-1]);
    Logger.Logger.Debug("Created CNF for programm. \n"
               + "Duration was " + watch.Stop());
    return results.Distinct(new ListComparer<int>()).ToList();
  }

  /// <summary>
  /// This function transforms the looprule bodys.
  /// </summary>
  /// <param name="atomLiterals">All bodys which have been found as external support.</param>
  /// <param name="index">The reference of the index if a new atom has to be generated.</param>
  /// <returns>A new and fresh expression.</returns>
  private ConjunctiveNormalForm.Expression LoopRuleOrBody(List<List<AtomLiteral>> atomLiterals, ref int index)
  {
    // If there is no literal which means no external support we say that it is impssible to get to that state
    if (atomLiterals.Count == 0)
    {
      return CNFWrapper.CreateNegativeVariable(CNFWrapper.CreateNegativeVariable(1));
    }

    // If we only found one body we transform this and return it
    if (atomLiterals.Count == 1)
    {
      return LoopRuleAndBody(atomLiterals[0], ref index);
    }

    // If multiple bodys e.g more then one have been found we say that the first to bodys have to get or
    // connected and after that connect every next body again with an or.s
    CNFWrapper expression = CNFWrapper.NewExpression();
    expression.SetOr(LoopRuleAndBody(atomLiterals[0], ref index), LoopRuleAndBody(atomLiterals[1], ref index));

    for (int i = 2; i < atomLiterals.Count; i++)
    {
      expression.AddOr(LoopRuleAndBody(atomLiterals[i], ref index));
    }

    return expression.Create();
  }

  /// <summary>
  /// Function to parse a loop rule body which is and connnected.
  /// </summary>
  /// <param name="atomLiterals">Die Literals which should get and connected</param>
  /// <param name="index">The reference of the index if a new atom has to be generated.</param>
  /// <returns>A fresh expression with th bodies connected.</returns>
  private ConjunctiveNormalForm.Expression LoopRuleAndBody(List<AtomLiteral> atomLiterals, ref int index)
  {
    // If the body count is one just generate the variable and return it
    if (atomLiterals.Count == 1)
    {
      return LoopAtomLiteralExpression(atomLiterals[0], ref index);
    }

    // If it is more then one then connect the first two with an and and add a new and for 
    // every next occuring  literal
    CNFWrapper expression = CNFWrapper.NewExpression();
    expression.SetAnd(LoopAtomLiteralExpression(atomLiterals[0], ref index),
    LoopAtomLiteralExpression(atomLiterals[1], ref index));

    for (int i = 2; i < atomLiterals.Count; i++)
    {
      expression.AddAnd(LoopAtomLiteralExpression(atomLiterals[i], ref index));
    }

    return expression.Create();
  }


  /// <summary>
  /// Function to retransform the solutions to answer sets.
  /// </summary>
  /// <param name="results">The Results of the Solver.</param>
  /// <returns>A List of answer sets.</returns>
  /// <exception cref="InvalidOperationException">If you try to call the retransform without using a preperation.</exception>
  public List<List<Atom>> ReTransform(List<List<int>> results)
  {
    if (_preperation == null)
    {
      throw new InvalidOperationException("You have to Transform the data first to retransform it!");
    }

    // If there are no results its unsatisfibale
    if (results.Count == 0)
    {
      return [];
    }

    List<List<Atom>> transformed = [];
    List<Atom> alwaysTrue = [];

    // Iterate over the factually true atoms and add it to every answer set, because they have to be prensent in every
    foreach (var rule in _preperation.FactuallyTrue)
    {
      if (rule.Head is AtomHead atomHead)
      {
        alwaysTrue.Add(atomHead.Atom);
      }
    }

    // if there are no results just return the factually true facts
    if (results.Count == 0)
    {
      return [alwaysTrue];
    }

    List<List<int>> filteredResults = [];

    // Now we remove all intergers which do not have an atom as reference becuase the are just fictional
    foreach (var set in results)
    {
      List<int> form = [];
      foreach (var variable in set)
      {
        if (_reMappedAtoms.TryGetValue(variable, out string? key))
        {
          if (string.IsNullOrEmpty(key))
          {
            continue;
          }

          form.Add(variable);
        }
      }

      filteredResults.Add(form);
    }

    // After that we remove all duplicates
    var uniqueLists = new HashSet<List<int>>(filteredResults, new ListComparer<int>());

    // Now we iterate through every set and retransform it to the corresponding atom
    foreach (var set in uniqueLists.ToList())
    {
      List<Atom> answers = [.. alwaysTrue];

      Logger.Logger.Debug("SET NUMBERS = " + string.Join(", ", set.OrderBy(x => x)));
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


    // Now we gain filter all answer sets so there are no duplicate ones
    List<List<Atom>> distinctAtomLists = RemoveDuplicates(transformed);

    List<List<Atom>> uniqueAtomLists = distinctAtomLists.Select(list =>
           list
            .GroupBy(atom => atom.ToString())
            .Select(g => g.First())
            .OrderByDescending(atom => atom.ToString())
            .ToList()
       ).ToList();

    HashSet<string> uniqueListRepresentations = new(
        uniqueAtomLists.Select(list => string.Join(",", list.Select(atom => atom.ToString())))
    );

    List<List<Atom>> dist = uniqueAtomLists
        .Where(list => uniqueListRepresentations.Contains(string.Join(",", list.Select(atom => atom.ToString()))))
        .ToList();


    return dist;
  }

  /// <summary>
  /// This functions removes all duplicates from a list.
  /// </summary>
  /// <param name="originalLists">The list which should get distininesd.</param>
  /// <returns>A list wihtout duplicates</returns>
  private List<List<Atom>> RemoveDuplicates(List<List<Atom>> originalLists)
  {
    var uniqueLists = new HashSet<List<Atom>>(new AtomListComparer());
    foreach (var list in originalLists)
    {
      uniqueLists.Add(list);
    }
    return uniqueLists.ToList();
  }

  /// <summary>
  /// This function converts a F# list to a C# list.
  /// </summary>
  /// <param name="fsharpListOfLists">The F# List which should get converted.</param>
  /// <returns>A converted List.</returns>
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


  /// <summary>
  /// This functions manages all combinations and transforms the bodies.
  /// </summary>
  /// <param name="headIndex">The index of the head.</param>
  /// <param name="bodies">The bodies you want to connect.</param>
  /// <param name="orBodies">The possible or bodies you want to connect.</param>
  /// <param name="index">The reference of the index if a new atom has to be generated.</param>
  /// <param name="fictionalIndex">Important for a choice if there is a not state.</param>
  /// <returns>The built expression.</returns>
  /// <exception cref="InvalidOperationException">If the head is negative -1.</exception>
  private ConjunctiveNormalForm.Expression TransformBodyLiterals(int headIndex, List<Body> bodies, List<ProgramRule> orBodies, ref int index, int fictionalIndex = -1)
  {
    // if the head index is -1 we throw an error because that cannot happen
    if (headIndex == -1)
    {
      throw new InvalidOperationException("The head is not possible to be a negative number");
    }

    // the expression of the head
    var headExpression = CNFWrapper.CreateVariable(headIndex);

    // first comnination is that there is not fictianl no orbodies and only one and body.
    if (bodies.Count == 1 && orBodies.Count == 0 && fictionalIndex == -1)
    {
      return CNFWrapper.NewExpression()
      .SetEquality(headExpression, AtomLiteralExpression(bodies[0], ref index)).Create();
    }

    CNFWrapper expression = CNFWrapper.NewExpression();
    
    // if there is at least on body and more then one or bodies we set an or with the only body and the transformed or body
    if (bodies.Count == 1 && orBodies.Count >= 1 && fictionalIndex == -1)
    {
      expression = expression.SetOr(AtomLiteralExpression(bodies[0], ref index), TransformAnd(orBodies[0], ref index));
    }

    // if there are more bodys and a ficional state we set an and with the first one and the fictional one
    if (bodies.Count >= 1 && fictionalIndex != -1)
    {
      expression = expression.SetAnd(AtomLiteralExpression(bodies[0], ref index), CNFWrapper.CreateNegativeVariable(fictionalIndex));
    }

    // if there are more bodys and no fictional we set the first two to be an and
    if (bodies.Count >= 2 && fictionalIndex == -1)
    {
      var leftExpression = AtomLiteralExpression(bodies[0], ref index);
      var rightExpression = AtomLiteralExpression(bodies[1], ref index);
      expression = CNFWrapper.NewExpression().SetAnd(leftExpression, rightExpression);
    }

    // now we need to decide how many and bodys we have to add, which index we start from
    int andStartIndex = fictionalIndex != -1 ? 1 : 2;
    for (int i = andStartIndex; i < bodies.Count; i++)
    {
      // Adding an and for every body.
      var bodyExpression = AtomLiteralExpression(bodies[i], ref index);
      expression = expression.AddAnd(bodyExpression);
    }

    // decide where to start with the or bodies
    int orStartIndex = bodies.Count == 1 ? 1 : 0;
    for (int i = orStartIndex; i < orBodies.Count; i++)
    {
      // add an or for every transformed or body
      expression = expression.AddOr(TransformOrBodie(orBodies, ref index));
    }

    var right = expression.Create();

    // create the equality between head and the right side
    return CNFWrapper.NewExpression().SetEquality(headExpression, right).Create();
  }

  /// <summary>
  /// This function transforms all or bodies and combines it with an or and and.
  /// </summary>
  /// <param name="orBodies">The Rules  you want to combine with or.</param>
  /// <param name="index">The reference of the index if a new atom has to be generated.</param>
  /// <returns>The or combined expression.</returns>
  private ConjunctiveNormalForm.Expression TransformOrBodie(List<ProgramRule> orBodies, ref int index)
  {
    // If the or body is just one big we combine the body itself and and return it
    if (orBodies.Count == 1)
    {
      return TransformAnd(orBodies[0], ref index);
    }

    // if there are more or bodies we combine the first two with or and then add an or for every new one
    CNFWrapper orExpression = CNFWrapper.NewExpression();

    orExpression.SetOr(TransformAnd(orBodies[0], ref index), TransformAnd(orBodies[1], ref index));

    for (int i = 2; i < orBodies.Count; i++)
    {
      // or bodies are outside connected with or but the body itself is and connected.
      orExpression.AddOr(TransformAnd(orBodies[0], ref index));
    }

    return orExpression.Create();
  }

  /// <summary>
  /// This function transforms a whole rule and combines it bodies with an and.
  /// </summary>
  /// <param name="rule">The rule you want to combine with and.</param>
  /// <param name="index">The reference of the index if a new atom has to be generated.</param>
  /// <returns>The and combined expression.</returns>
  public ConjunctiveNormalForm.Expression TransformAnd(ProgramRule rule, ref int index)
  {
    // The body is just one element big, there is nothing to be and connected
    // so just return the literal expression
    if (rule.Body.Count == 1)
    {
      return AtomLiteralExpression(rule.Body[0], ref index);
    }

    // Otherweise connect the first two bodies and set them to an and and then add an end for every body.
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

  /// <summary>
  /// Checks if the body is a literalbody and returns the atom literal
  /// </summary>
  /// <param name="body">The body you want the literal of.</param>
  /// <returns>The transformed Atom literal.</returns>
  /// <exception cref="InvalidOperationException">If another literal has crossed this way like is or comparrison.</exception>
  private AtomLiteral GetAtomOfBody(Body body)
  {
    if (body is LiteralBody literalBody && literalBody.Literal is AtomLiteral atomLiteral)
    {
      return atomLiteral;
    }
    throw new InvalidOperationException("Somehow a body literal, not of type AtomLiteral has come accross my way");
  }

  /// <summary>
  /// Creates a expresson depending if the atomliteral is positiv or not.
  /// </summary>
  /// <param name="literal">The atomLiteral you want to transform.</param>
  /// <param name="index">The reference of the index if a new atom has to be generated.</param>
  /// <returns>The corresponding expression.</returns>
  private ConjunctiveNormalForm.Expression CreateDynamicVariable(AtomLiteral literal, int index)
  {
    return literal.Positive ? CNFWrapper.CreateVariable(index) :
      CNFWrapper.CreateNegativeVariable(index);
  }


  /// <summary>
  /// Generates or returns the fictional index for a choice.
  /// </summary>
  /// <param name="choiceIndex">The choice index which you want the fictional from.</param>
  /// <param name="index">The reference of the index if a new atom has to be generated.</param>
  /// <returns>The finctional index.</returns>
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

  /// <summary>
  /// This function generates or returns a index for a corresponding signature.
  /// </summary>
  /// <param name="signature">The signature you want the index of.</param>
  /// <param name="index">The reference of the index if a new atom has to be generated.</param>
  /// <param name="atom">The atom as reference for remapping.</param>
  /// <returns>The corresponding index of the atom.</returns>
  private int GetIndexOfString(string signature, ref int index, Atom? atom = null)
  {
    int foundIndex;

    if (!_mappedAtoms.TryGetValue(signature, out foundIndex))
    {
      ++index;

      _mappedAtoms.Add(signature, index);
      _reMappedAtoms.Add(index, signature);

      if (atom != null)
      {
        _mappedRules.Add(signature, atom);
      }

      foundIndex = index;
    }

    return foundIndex;
  }


  /// <summary>
  /// This function generates the corresponding expression for a body.
  /// </summary>
  /// <param name="body">The body which you want the expression of.</param>
  /// <param name="index">The reference of the index if a new atom has to be generated.</param>
  /// <returns>The corresponding expression.</returns>
  private ConjunctiveNormalForm.Expression AtomLiteralExpression(Body body, ref int index)
  {
    var atomLiteral = GetAtomOfBody(body);
    return LoopAtomLiteralExpression(atomLiteral, ref index);
  }

  /// <summary>
  /// This function generates the corresponding expression for a literla.
  /// </summary>
  /// <param name="atomLiteral">The atom literal which you want the expression of.</param>
  /// <param name="index">The reference of the index if a new atom has to be generated.</param>
  /// <returns>The corresponding expression.</returns>
  private ConjunctiveNormalForm.Expression LoopAtomLiteralExpression(AtomLiteral atomLiteral, ref int index)
  {
    int foundIndex = GetIndexOfString(atomLiteral.Atom.ToString(), ref index, atomLiteral.Atom);
    return CreateDynamicVariable(atomLiteral, foundIndex);
  }
}