//-----------------------------------------------------------------------
// <copyright file="CommandManager.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.CLI;

using System.Data;
using Antlr4.Runtime;
using Interpreter.Lib.Graph;
using Interpreter.Lib.Grounder;
using Interpreter.Lib.Listeners;
using Interpreter.Lib.Logger;
using Interpreter.Lib.Results.Enums;
using Interpreter.Lib.Results.Objects;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Solver;
using Interpreter.Lib.Solver.Defaults;
using Interpreter.Lib.Visitors;

/// <summary>
/// Command manager for executing the load and reload command.
/// </summary>
public class CommandManager
{
  private readonly Checker checker = new();
  private readonly ObjectParser objectParser = new();

  /// <summary>
  /// The property to store the answer sets.
  /// </summary>
  private Store? store;

  /// <summary>
  /// Gets or sets the filepath of the command manager.
  /// </summary>
  public string? FilePath { get; set; }

  /// <summary>
  /// Either load or reload the stored file this will exucte the whole engine and print out answer sets.
  /// </summary>
  /// <param name="filePath">The filepath of the file which should get loaded.</param>
  public void LoadFile(string filePath)
  {
    Logger.Information($"Loading/Reloading file {filePath}");
    this.store = new Store();
    try
    {
      // Get the file and the produce the tokens
      var inputStream = new AntlrInputStream(File.ReadAllText(filePath));
      var lexer = new LparseLexer(inputStream);
      var tokens = new CommonTokenStream(lexer);

      // parse the tokens
      var parser = new LparseParser(tokens);
      parser.RemoveErrorListeners();
      parser.AddErrorListener(new SyntaxErrorListener());

      var tree = parser.program();

      var programVisitor = new ProgramVisitor();
      List<ProgramRule> rules = programVisitor.Visit(tree);

      StopWatch watch = StopWatch.Start();

      Logger.Information("Solving...");

      // Building the graph and starting the grounder
      DependencyGraph graph = new MyDependencyGraph(rules, new OrderVisitor(), new MyAddToGraphVisitor());
      Grounding grounder = new Grounding(graph);
      var groundedProgram = grounder.Ground();

      // Default is the sat engine so start the sat engine, it will produce the answer sets
      SatEngine satEnginesatEngine = new SatEngine(groundedProgram);

      var answerSets = satEnginesatEngine.Execute();
      this.store.AnswerSets = answerSets;

      // If there are no answer sets the formular is unsatisfiable.
      if (answerSets.Count == 0)
      {
        Logger.Information("UNSATISFIABLE " + "\n\nDuration: " + watch.Stop());
        return;
      }

      // Print all found warnings (atoms that occur in a body but not a head).
      this.PrintWarnings(grounder.Warnings);

      // Basic Print function for the anser sets
      for (int i = 0; i < answerSets.Count; i++)
      {
        string atoms = string.Join(", ", answerSets[i].Select(x => x.ToString()));
        Logger.Information("\nAnswer: " + (i + 1) + " \n" + "{ " + atoms + " }\n");
      }

      Logger.Information("SATISFIABLE \n\nModels: " + answerSets.Count + "\nDuration: " + watch.Stop());
    }
    catch (Exception e)
    {
      Logger.Error(e.Message);
      Logger.Debug(e.StackTrace ?? string.Empty);
    }
  }

  /// <summary>
  /// Executes the given query over the answer sets.
  /// </summary>
  /// <param name="query">The query string which should get executed.</param>
  public void ExecuteQuery(string query)
  {
    // If there is no store, a file has not been loaded.
    if (this.store == null)
    {
      Logger.Error("Cannot execute query when no file is loaded");
      return;
    }

    // If there are no answer sets inside the store it is unsat which means always false
    if (this.store.AnswerSets.Count == 0)
    {
      Logger.Information("false");
      return;
    }

    try
    {
      // again parse the query to its token and the rule, replace a . with nothing if there is one
      // because adding a point to :q feels just natural.
      var inputStream = new AntlrInputStream(query.Replace(".", string.Empty) + "?");
      var lexer = new LparseLexer(inputStream);
      var tokens = new CommonTokenStream(lexer);

      var parser = new LparseParser(tokens);
      parser.RemoveErrorListeners();
      parser.AddErrorListener(new SyntaxErrorListener());

      var tree = parser.program();

      var programVisitor = new QueryVisitor();
      List<Query> parsedQuery = programVisitor.VisitQuery(tree);

      // node(X), node(Y), Y == 5, X == 10; node(X), node(Y), Y == X
      // /Users/marvinkoch/Desktop/x.lp
      for (int i = 0; i < this.store.AnswerSets.Count; i++)
      {
        string rules = "\nSet " + (i + 1) + "\n";

        // Go through each parsed query over the current set and print the solutions
        foreach (var currentQuery in parsedQuery)
        {
          QuerySolver querySolver = new QuerySolver(currentQuery, this.store.AnswerSets[i], new Preparer(this.checker, this.objectParser));
          var answers = querySolver.Answers();

          // if there are no answers its just false
          if (answers.Count == 0)
          {
            rules += "false. \n";
          }

          foreach (var rule in answers)
          {
            var head = rule.Head.GetHeadAtoms();

            // if the query did not have any variables just print true if it is out there
            if (head.Count > 0 && head[0].Args.Count == 0)
            {
              rules += "true. \n";
              continue;
            }

            // Otherwise gtet all variables and print it out.
            List<string> vars = [.. currentQuery.Variables];

            for (int m = 0; m < head[0].Args.Count; m++)
            {
              rules += vars[m] + " = " + head[0].Args[m] + " ";
            }

            rules += "\n";
          }
        }

        Logger.Information(rules + "--------------------------------");
      }
    }
    catch (Exception e)
    {
      Logger.Error(e.Message);
      Logger.Debug(e.StackTrace ?? string.Empty);
    }
  }

  /// <summary>
  /// This method explains a answer set programming file.
  /// </summary>
  /// <param name="filePath">The file which should get explained.</param>
  public void ExplainFile(string filePath)
  {
    var inputStream = new AntlrInputStream(File.ReadAllText(filePath));
    var lexer = new LparseLexer(inputStream);
    var tokens = new CommonTokenStream(lexer);

    var parser = new LparseParser(tokens);
    parser.RemoveErrorListeners();
    parser.AddErrorListener(new SyntaxErrorListener());

    var tree = parser.program();

    var programVisitor = new ProgramVisitor();
    List<ProgramRule> rules = programVisitor.Visit(tree);

    foreach (var rule in rules)
    {
      if (rule.Body.Count == 0)
      {
        continue;
      }

      if (rule.Body[0].Accept(this.checker.IsCommentLiteralVisitor))
      {
        var comment = rule.Body[0].Accept(this.objectParser.ParseCommentLiteralVisitor) ?? throw new InvalidOperationException("Something unsure happend");
        List<string> headVars = rule.Head.GetVariables();
        foreach (var special in comment.GetVariables())
        {
          if (!headVars.Contains(special))
          {
            Logger.Error($"{special} is not occuring in the comment rules head (" + rule.ToString() + ").");
            return;
          }
        }
      }
    }

    foreach (var rule in rules)
    {
      if (rule.Body.Count == 0)
      {
        continue;
      }

      if (!rule.Head.Accept(this.checker.IsAtomHeadVisitor))
      {
        continue;
      }

      AtomHead atomHead = rule.Head.Accept(this.objectParser.ParseAtomHeadVisitor) ?? throw new InvalidOperationException("Something unsure happened");
      var sig = atomHead.Atom.Signature;

      if (rule.Body[0].Accept(this.checker.IsCommentLiteralVisitor))
      {
        var comment = rule.Body[0].Accept(this.objectParser.ParseCommentLiteralVisitor) ?? throw new InvalidOperationException("Something unsure happend");

        if (atomHead.Atom.Args.Count == 0)
        {
          Logger.Information(comment.ToString());
          continue;
        }

        foreach (var sigRule in this.FindSameSigs(rules, sig, rule))
        {
          var sigHead = sigRule.Head.Accept(this.objectParser.ParseAtomHeadVisitor) ?? throw new InvalidOperationException("Something unsure happend");
          if (sigRule.Body.Count == 0)
          {
            Logger.Information(this.Print(comment, sigHead.Atom));
            continue;
          }

          if (sigRule.Body.Count > 0)
          {
            string basis = this.Print(comment, sigHead.Atom, 0, "if") + "\n";
            basis += this.BodyExplain(rules, sigRule);
            Logger.Information(basis);
            continue;
          }
        }
      }
    }
  }

  private string BodyExplain(List<ProgramRule> rules, ProgramRule rule)
  {
    string basis = string.Empty;
    for (int i = 0; i < rule.Body.Count; i++)
    {
      if (rule.Body[i].Accept(this.checker.IsAtomLiteralVisitor))
      {
        AtomLiteral atomLiteral = rule.Body[i].Accept(this.objectParser.ParseAtomLiteralVisitor) ?? throw new InvalidOperationException("Something unsure happend");
        Atom atom = atomLiteral.Atom;
        var sig = atom.Signature.Replace("-", string.Empty);

        var comment = rules
        .Where(rule => rule.Body.Count > 0)
        .Where(rule => rule.Body[0].Accept(this.checker.IsCommentLiteralVisitor))
        .Where(rule => rule.Head.Accept(this.checker.IsAtomHeadVisitor))
        .Where(rule =>
        {
          AtomHead head = rule.Head.Accept(this.objectParser.ParseAtomHeadVisitor) ?? throw new InvalidOperationException("Something unsure happend");
          return head.Atom.Signature == sig;
        }).ToList();

        var holdings = rules
        .Where(rule => rule.Body.Count == 0)
        .Where(rule => rule.Head.Accept(this.checker.IsAtomHeadVisitor))
        .Where(rule =>
        {
          AtomHead head = rule.Head.Accept(this.objectParser.ParseAtomHeadVisitor) ?? throw new InvalidOperationException("Something unsure happend");
          return head.Atom.Signature == sig;
        }).ToList();

        if (comment.Count == 0)
        {
          if (holdings.Count != 0)
          {
            basis += "          " + holdings[0].ToString().Replace(".", string.Empty) + " holds \n";
          }

          continue;
        }

        CommentLiteral comm = comment[0].Body[0].Accept(this.objectParser.ParseCommentLiteralVisitor) ?? throw new InvalidOperationException("Something unsure happend");
        string prefix = atomLiteral.Positive ? string.Empty : "there is no evidence that";
        prefix += atom.ToString().StartsWith('-') ? $" it is not the case that" : string.Empty;

        basis += this.Print(comm, atom, 4, i != rule.Body.Count - 1 ? " and " : string.Empty, prefix) + "\n";
      }

      if (rule.Body[i].Accept(this.checker.IsComparisonLiteralVisitor))
      {
        var comparison = rule.Body[i].Accept(this.objectParser.ParseComparisonLiteralVisitor) ?? throw new InvalidOperationException("Something unsure happend");
        switch (comparison.TermRelation)
        {
          case Relation.Unification:
            basis += "          " + comparison.Left.ToString() + " is " + comparison.Right.ToString() + "\n";
            break;
          case Relation.Equal:
            basis += "          " + comparison.Left.ToString() + " equal to " + comparison.Right.ToString() + "\n";
            break;
          case Relation.GreaterEqual:
            basis += "          " + comparison.Left.ToString() + " greater or equal to " + comparison.Right.ToString() + "\n";
            break;
          case Relation.GreaterThan:
            basis += "          " + comparison.Left.ToString() + " greater than " + comparison.Right.ToString() + "\n";
            break;
          case Relation.Inequal:
            basis += "          " + comparison.Left.ToString() + " not equal " + comparison.Right.ToString() + "\n";
            break;
          case Relation.LessEqual:
            basis += "          " + comparison.Left.ToString() + " less or equal to " + comparison.Right.ToString() + "\n";
            break;
          case Relation.LessThan:
            basis += "          " + comparison.Left.ToString() + " less than " + comparison.Right.ToString() + "\n";
            break;
        }
      }
    }

    return basis;
  }

  private List<ProgramRule> FindSameSigs(List<ProgramRule> rules, string signature, ProgramRule reference)
  {
    return rules
        .Where(rule => rule != reference)
        .Where(rule => rule.Head.Accept(this.checker.IsAtomHeadVisitor))
        .Where(rule =>
        {
          AtomHead head = rule.Head.Accept(this.objectParser.ParseAtomHeadVisitor) ?? throw new InvalidOperationException("Something unsure happend");
          return head.Atom.Signature == signature;
        }).ToList();
  }

  private string Print(CommentLiteral literal, Atom atom, int indents = 0, string addition = "", string prefix = "")
  {
    List<string> varOder = [];

    foreach (var arrgs in atom.Args)
    {
      varOder.Add(arrgs.ToString() ?? string.Empty);
    }

    string toPrint = literal.GetText(varOder);
    List<string> indent = [];
    for (int i = 0; i < indents; i++)
    {
      indent.Add("  ");
    }

    return string.Join(string.Empty, indent) + " " + prefix + " " + toPrint + " " + addition;
  }

  /// <summary>
  /// Prints all the items of the list as a warning.
  /// </summary>
  /// <param name="warnings">The strings which should be printed as warnings.</param>
  private void PrintWarnings(List<string> warnings)
  {
    foreach (var warning in warnings)
    {
      Logger.Warning("atom does not occur in any rule head: \n" + warning);
    }
  }
}