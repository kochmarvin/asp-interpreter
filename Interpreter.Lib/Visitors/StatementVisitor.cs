using System.Data;
using Interpreter.Lib.Results;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Objects.Terms;
using static LparseParser;

namespace Interpreter.Lib.Visitors;

public class StatementsVisitor : LparseBaseVisitor<List<ProgramRule>>
{
  public override List<ProgramRule> VisitStatements(LparseParser.StatementsContext context)
  {
    List<ProgramRule> atoms = [];
    foreach (var statementContext in context.statement())
    {
      List<Head> headLiterals = [new Headless()];
      List<List<Body>> bodyLiterals = [];

      HeadContext head = statementContext.head();
      BodiesContext bodies = statementContext.bodies();

      if (head != null)
      {
        headLiterals = new HeadVisitor().Visit(head);
      }

      if (bodies != null)
      {
        foreach (var body in bodies.body())
        {

          bodyLiterals.Add([.. new BodyVisitor().Visit(body)]);
        }
      }


      // ich check den schäh nicht 
      foreach (var headLiteral in headLiterals)
      {

        if (bodyLiterals.Count == 0)
        {
          atoms.Add(new ProgramRule(headLiteral, []));
        }

        foreach (var body in bodyLiterals)
        {
          atoms.Add(new ProgramRule(headLiteral, body));
        }


        /* TODO 
          checken ob der current body, variablen hat,
          => aus dem head alle variables (Terme) ziehen, die diese Variablen haben,
          => und dann einen neuen HEad machen nur mit den allen heads
          => das füe jeden body wegen oder.

        */
      }
    }

    return atoms;
  }


  private List<ProgramRule> BodySplitter(Head headLiteral, List<List<Body>> bodyLiterals)
  {
    List<ProgramRule> atoms = [];
    if (bodyLiterals.Count == 0)
    {
      atoms.Add(new ProgramRule(headLiteral, []));
    }

    foreach (var body in bodyLiterals)
    {
      if (!headLiteral.HasVariables())
      {
        atoms.Add(new ProgramRule(headLiteral, body));
        continue;
      }

      var variableList = body.SelectMany(bod => bod.GetVariables());


      if (headLiteral is AtomHead atomHead)
      {
        var newAtomHead = new AtomHead(new Atom(atomHead.Atom.Name, []));
        foreach (var variable in variableList)
        {
          newAtomHead.Atom.Args.AddRange(CreateNewAtom(variable, atomHead.Atom));
        }
        atoms.Add(new ProgramRule(newAtomHead, body));
      }

      if (headLiteral is ChoiceHead choiceHead)
      {
        var newChoiceHead = new ChoiceHead([]);

        foreach (var choice in choiceHead.Atoms)
        {
          var newAtom = new Atom(choice.Name, []);
          foreach (var variable in variableList)
          {
            newAtom.Args.AddRange(CreateNewAtom(variable, choice));
          }
          newChoiceHead.Atoms.Add(newAtom);
        }

        atoms.Add(new ProgramRule(newChoiceHead, body));
      }
    }

    return atoms;
  }

  private List<Term> CreateNewAtom(string variable, Atom atom)
  {
    List<Term> headTerms = [];
    foreach (var term in atom.Args)
    {
      if (!term.HasVariables() || term.HasVariables(variable))
      {
        headTerms.Add(term);
      }
    }

    return headTerms;
  }
}