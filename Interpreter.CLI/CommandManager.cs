using System.Data;
using Antlr4.Runtime;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Listeners;
using Interpreter.Lib.Visitors;
using Interpreter.Lib.Graph;
using Interpreter.Lib.Grounder;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Solver;
using Interpreter.Lib.Solver.defaults;
using Interpreter.Lib.Logger;
using Interpreter.Lib.Results.Objects;

namespace Interpreter.CLI;
public class CommandManager
{
  public string? FilePath { get; set; }
  private Store? _store;

  public void LoadFile(string filePath)
  {
    Logger.Information($"Loading/Reloading file {filePath}");
    _store = new Store();
    try
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

      StopWatch watch = StopWatch.Start();

      Logger.Information("Solving...");
      DependencyGraph graph = new DependencyGraph(rules);
      Grounding grounder = new Grounding(graph);
      var groundedProgram = grounder.Ground();

      SatEngine satEnginesatEngine = new SatEngine(groundedProgram);

      var answerSets = satEnginesatEngine.Execute();
      _store.AnswerSets = answerSets;

      if (answerSets.Count == 0)
      {
        Logger.Information("UNSATISFIABLE " + "\n\nDuration: " + watch.Stop());
      }
      else
      {
        PrintWarnings(grounder.Warnings);

        for (int i = 0; i < answerSets.Count; i++)
        {
          string atoms = string.Join(", ", answerSets[i].Select(x => x.ToString()));
          Logger.Information("\nAnswer: " + (i + 1) + " \n" + "{ " + atoms + " }\n");
        }

        Logger.Information("SATISFIABLE \n\nModels: " + answerSets.Count + "\nDuration: " + watch.Stop());
      }
    }
    catch (Exception e)
    {
      Logger.Error(e.Message);
      Logger.Debug(e.StackTrace ?? "");
    }
  }

  public void ExecuteQuery(string query)
  {
    if (_store == null)
    {
      Logger.Error("Cannot execute query when no file is loaded");
      return;
    }

    if (_store.AnswerSets.Count == 0)
    {
      Logger.Information("false");
      return;
    }

    try
    {
      var inputStream = new AntlrInputStream(query + "?");
      var lexer = new LparseLexer(inputStream);
      var tokens = new CommonTokenStream(lexer);

      var parser = new LparseParser(tokens);
      parser.RemoveErrorListeners();
      parser.AddErrorListener(new SyntaxErrorListener());

      var tree = parser.program();

      var programVisitor = new QueryVisitor();
      List<Query> parsedQuery = programVisitor.VisitQuery(tree);

      foreach (Query q in parsedQuery)
      {
        Console.WriteLine(q.ParsedQuery);
      }

      // node(X), node(Y), Y == 5, X == 10; node(X), node(Y), Y == X
      // /Users/marvinkoch/Desktop/x.lp
      for (int i = 0; i < _store.AnswerSets.Count; i++)
      {
        string rules = "\nSet " + (i + 1) + "\n";
        foreach (var currentQuery in parsedQuery)
        {
          QuerySolver querySolver = new QuerySolver(currentQuery, _store.AnswerSets[i], new Preparer());
          var answers = querySolver.Answers();

          if (answers.Count == 0)
          {
            rules += "false. \n";
          }

          foreach (var rule in answers)
          {
            if (rule.Head is AtomHead atomHead && atomHead.Atom.Args.Count == 0)
            {
              rules += "true. \n";
              continue;
            }

            AtomHead head = (AtomHead)rule.Head;
            List<string> vars = [.. currentQuery.Variables];

            for (int m = 0; m < head.Atom.Args.Count; m++)
            {
              rules += vars[m] + " = " + head.Atom.Args[m] + " ";
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
      Logger.Debug(e.StackTrace ?? "");
    }
  }


  private void PrintWarnings(List<string> warnings)
  {
    foreach (var warning in warnings)
    {
      Logger.Warning("atom does not occur in any rule head: \n" + warning);
    }
  }
}