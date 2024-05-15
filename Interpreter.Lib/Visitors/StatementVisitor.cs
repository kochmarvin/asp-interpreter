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

/// <summary>
/// Implementation of the statement visitor.
/// </summary>
public class StatementsVisitor : LparseBaseVisitor<List<ProgramRule>>
{
  /// <summary>
  /// Parses all statements of the programm context.
  /// </summary>
  /// <param name="context">The statement context</param>
  /// <returns>A List of parsed rules</returns>
  public override List<ProgramRule> VisitStatements(LparseParser.StatementsContext context)
  {
    List<ProgramRule> atoms = [];

    // go through every statement inside the context.
    foreach (var statementContext in context.statement())
    {
      // default case is that it is headless
      List<Head> headLiterals = [new Headless()];
      List<List<Body>> bodyLiterals = [];

      HeadContext head = statementContext.head();
      BodiesContext bodies = statementContext.bodies();
      Comment_bodsContext comment = statementContext.comment_bods();

      // If the head context is not null parse the head.
      if (head != null)
      {
        headLiterals = new HeadVisitor().Visit(head);
      }

      // If the bodies context is not null parse the bodies.
      if (bodies != null)
      {
        // Could be more bodies due to splitting of the ";" or
        foreach (var body in bodies.body())
        {
          bodyLiterals.Add([.. new BodyVisitor().Visit(body)]);
        }
      }

      // If the comment for explaining is not null add it.
      if (comment != null)
      {
        List<Variable> vars = [];
        List<string> strings = [];

        // go through the body of the cimment.
        foreach (var specials in comment.comment_bod())
        {
          // if its a specail e.g a variable parse it.
          if (specials.special() != null)
          {
            bool found = false;
            
            // check if the variable is arleady in it, so no duplicates get added
            for (int i = 0; i < vars.Count; i++)
            {
              if (vars[i].Name == specials.special().VARIABLE().GetText())
              {
                strings.Add(i.ToString());
                found = true;
                break;
              }
            }

            // if the variable is not in it add it.
            if (!found)
            {
              strings.Add(vars.Count.ToString());
              vars.Add(new Variable(specials.special().VARIABLE().GetText()));
            }
          }

          // if the text conxt is not null then parse the strings
          if (specials.text() != null)
          {
            // text is just a bunch load of ids so just add it up
            foreach (var id in specials.text().ID())
            {
              strings.Add(id.GetText());
            }
          }
        }

        bodyLiterals.Add([new LiteralBody(new CommentLiteral(vars, strings))]);
      }

      // Go thorugh each head annd add the bodies, multiple heads could be due to an range operator.
      foreach (var headLiteral in headLiterals)
      {

        if (bodyLiterals.Count == 0)
        {
          atoms.Add(new ProgramRule(headLiteral, []));
        }

        // and if there are multiple bodeis due to or, create multiple rules
        foreach (var body in bodyLiterals)
        {
          atoms.Add(new ProgramRule(headLiteral, body));
        }
      }
    }

    return atoms;
  }
}