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
      Query parsedQuery = programVisitor.VisitQuery(tree);
      List<string> variables = [.. parsedQuery.Variables];

      QuerySolver querySolver = new QuerySolver(parsedQuery, _store.AnswerSets, new Preparer());
      var answers = querySolver.Answers();

      string rules = "Query Solution\n--------------------------------";
      for (int i = 0; i < answers.Count; i++)
      {
        rules += "\nSet " + i + "\n";

        if (answers[i].Count == 0)
        {
          rules += "false. \n";
          continue;
        }

        foreach (var answer in answers[i])
        {
          if (answer.Head is AtomHead atomHead && atomHead.Atom.Args.Count == 0)
          {
            rules += "true. \n";
            continue;
          }

          AtomHead head = (AtomHead)answer.Head;
          for (int j = 0; j < head.Atom.Args.Count; j++)
          {
            rules += variables[j] + " = " + head.Atom.Args[j] + " ";
          }
          rules += "\n";
        }
      }
      Logger.Information(rules + "--------------------------------");
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