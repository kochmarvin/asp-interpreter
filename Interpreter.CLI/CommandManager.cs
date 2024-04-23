using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Interpreter.Lib.Results;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Listeners;
using Interpreter.Lib.Visitors;
using Interpreter.Lib.Graph;
using Interpreter.Lib.Grounder;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Solver;
using Interpreter.Lib.Solver.defaults;
using Interpreter.Lib.Logger;

namespace Interpreter.CLI
{
  public class CommandManager
  {
    public string FilePath { get; set; }

    public void LoadFile(string filePath)
    {
      Logger.Information($"Loading/Reloading file {filePath}");
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

        SatEngine satEnginesatEngine = new SatEngine(groundedProgram, true);

        var answerSets = satEnginesatEngine.Execute();

        if (answerSets.Count == 0)
        {
          Logger.Information("UNSATISFIABLE " + "\n\nDuration: " + watch.Stop());
        }
        else
        {
          foreach (var warning in grounder.Warnings)
          {
            Logger.Warning("atom does not occur in any rule head: \n" + warning);
          }

          for (int i = 0; i < answerSets.Count; i++)
          {
            string atoms = string.Join(", ", answerSets[i].Select(x => x.ToString()));
            Logger.Information("\nAnswer: " + (i + 1) + " \n" + "{ " + atoms + " }\n");
          }

          /*

            1 -1
            -1 2
            1 3 -3
            2 3 4
            -3 1 5
            -5

          */

          Logger.Information("SATISFIABLE \n\nModels: " + answerSets.Count + "\nDuration: " + watch.Stop());
        }
      }
      catch (Exception e)
      {
        Logger.Error(e.Message);
        Logger.Debug(e.StackTrace ?? "");
      }
    }
  }
}
