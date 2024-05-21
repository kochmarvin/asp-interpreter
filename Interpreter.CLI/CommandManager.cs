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

/// <summary>
/// Command manager for executing the load and reload command
/// </summary>
public class CommandManager
{
  public string? FilePath { get; set; }
  private Store? _store;

  /// <summary>
  /// Either load or reload the stored file this will exucte the whole engine and print out answer sets
  /// </summary>
  /// <param name="filePath">The filepath of the file which should get loaded</param>
  public void LoadFile(string filePath)
  {
    Logger.Information($"Loading/Reloading file {filePath}");
    _store = new Store();
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
      _store.AnswerSets = answerSets;

      // If there are no answer sets the formular is unsatisfiable.
      if (answerSets.Count == 0)
      {
        Logger.Information("UNSATISFIABLE " + "\n\nDuration: " + watch.Stop());
        return;
      }

      // Print all found warnings (atoms that occur in a body but not a head).
      PrintWarnings(grounder.Warnings);

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
      Logger.Debug(e.StackTrace ?? "");
    }
  }

  /// <summary>
  /// Executes the given query over the answer sets
  /// </summary>
  /// <param name="query">The query string which should get executed</param>
  public void ExecuteQuery(string query)
  {
    // If there is no store, a file has not been loaded.
    if (_store == null)
    {
      Logger.Error("Cannot execute query when no file is loaded");
      return;
    }

    // If there are no answer sets inside the store it is unsat which means always false
    if (_store.AnswerSets.Count == 0)
    {
      Logger.Information("false");
      return;
    }

    try
    {
      // again parse the query to its token and the rule, replace a . with nothing if there is one
      // because adding a point to :q feels just natural.
      var inputStream = new AntlrInputStream(query.Replace(".", "") + "?");
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
      for (int i = 0; i < _store.AnswerSets.Count; i++)
      {
        string rules = "\nSet " + (i + 1) + "\n";

        // Go through each parsed query over the current set and print the solutions
        foreach (var currentQuery in parsedQuery)
        {
          QuerySolver querySolver = new QuerySolver(currentQuery, _store.AnswerSets[i], new Preparer(new Checker(), new ObjectParser()));
          var answers = querySolver.Answers();

          // if there are no answers its just false
          if (answers.Count == 0)
          {
            rules += "false. \n";
          }

          foreach (var rule in answers)
          {
            // if the query did not have any variables just print true if it is out there
            if (rule.Head is AtomHead atomHead && atomHead.Atom.Args.Count == 0)
            {
              rules += "true. \n";
              continue;
            }

            // Otherwise gtet all variables and print it out.
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


  /// <summary>
  /// Prints all the items of the list as a warning
  /// </summary>
  /// <param name="warnings">The strings which should be printed as warnings</param>
  private void PrintWarnings(List<string> warnings)
  {
    foreach (var warning in warnings)
    {
      Logger.Warning("atom does not occur in any rule head: \n" + warning);
    }
  }
}