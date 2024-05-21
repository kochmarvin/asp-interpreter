using Interpreter.Lib.Logger;
using System.Data;
using Antlr4.Runtime;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Listeners;
using Interpreter.Lib.Visitors;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Enums;

namespace Interpreter.CLI.Commands;

public class ExplainCommand : ICommand
{
  public void Execute(string[] args, CommandManager manager)
  {

    if (args.Length < 2)
    {
      Logger.Error("No Path provided");
      return;
    }

    string filePath = string.Join(" ", args, 1, args.Length - 1);

    if (string.IsNullOrEmpty(filePath))
    {
      Logger.Error("No File selected");
      return;
    }

    Logger.Information($"Explaining file: {args[1]}");

    var inputStream = new AntlrInputStream(File.ReadAllText(args[1]));
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
      if (rule.Body.Count == 0) continue;
      if (rule.Body[0] is LiteralBody lit && lit.Literal is CommentLiteral comment)
      {
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
      if (rule.Body.Count == 0) continue;
      if (rule.Head is not AtomHead) continue;

      AtomHead atomHead = (AtomHead)rule.Head;
      var sig = atomHead.Atom.Signature;

      if (rule.Body[0] is LiteralBody lit && lit.Literal is CommentLiteral comment)
      {
        if (atomHead.Atom.Args.Count == 0)
        {
          Logger.Information(comment.ToString());
          continue;
        }

        foreach (var sigRule in FindSameSigs(rules, sig, rule))
        {
          var sigHead = (AtomHead)sigRule.Head;
          if (sigRule.Body.Count == 0)
          {
            Logger.Information(Print(comment, sigHead.Atom));
            continue;
          }

          if (sigRule.Body.Count > 0)
          {
            string basis = Print(comment, sigHead.Atom, 0, "if") + "\n";
            basis += BodyExplain(rules, sigRule);
            Logger.Information(basis);
            continue;
          }

        }
      }
    }
  }
  private string BodyExplain(List<ProgramRule> rules, ProgramRule rule)
  {
    string basis = "";
    for (int i = 0; i < rule.Body.Count; i++)
    {
      if (rule.Body[i] is LiteralBody literalBody)
      {
        if (literalBody.Literal is AtomLiteral atomLiteral)
        {
          Atom atom = atomLiteral.Atom;
          var sig = atom.Signature.Replace("-", "");

          var comment = rules
          .Where(r => r.Body.Count > 0)
          .Where(r => r.Body[0] is LiteralBody lB && lB.Literal is CommentLiteral)
          .Where((r) => r.Head is AtomHead)
          .Where(r =>
          {
            AtomHead head = (AtomHead)r.Head;
            return head.Atom.Signature == sig;
          }).ToList();

          var holdings = rules
          .Where(r => r.Body.Count == 0)
          .Where((r) => r.Head is AtomHead)
          .Where(r =>
          {
            AtomHead head = (AtomHead)r.Head;
            return head.Atom.Signature == sig;
          }).ToList();

          if (comment.Count == 0)
          {
            if (holdings.Count != 0)
            {
              basis += "          " + holdings[0].ToString().Replace(".", "") + " holds \n";
            }

            continue;
          }

          CommentLiteral comm = (CommentLiteral)((LiteralBody)comment[0].Body[0]).Literal;
          string prefix = atomLiteral.Positive ? "" : "there is no evidence that";
          prefix += atom.ToString().StartsWith("-") ? $" it is not the case that" : "";

          basis += Print(comm, atom, 4, i != rule.Body.Count - 1 ? " and " : "", prefix) + "\n";
        }

        if (literalBody.Literal is ComparisonLiteral comparison)
        {

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

    }

    return basis;
  }

  private List<ProgramRule> FindSameSigs(List<ProgramRule> rules, string signature, ProgramRule reference)
  {
    return rules
        .Where(r => r != reference)
        .Where(
          (rule) => rule.Head is AtomHead
        ).Where((atomHead) =>
        {
          AtomHead atom = (AtomHead)atomHead.Head;
          return atom.Atom.Signature == signature;
        }).ToList();
  }

  private string Print(CommentLiteral literal, Atom atom, int indents = 0, string addition = "", string prefix = "")
  {
    List<string> varOder = [];

    foreach (var arrgs in atom.Args)
    {
      varOder.Add(arrgs.ToString());
    }

    string toPrint = literal.GetText(varOder);
    List<string> indent = [];
    for (int i = 0; i < indents; i++)
    {
      indent.Add("  ");
    }

    return string.Join("", indent) + " " + prefix + " " + toPrint + " " + addition;
  }
}
