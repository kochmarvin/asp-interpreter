using System.Data;
using Interpreter.Lib.Results;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Rule;
using static LparseParser;

public class StatementsVisitor : LparseBaseVisitor<List<ProgramRule>>
{
  public override List<ProgramRule> VisitStatements(LparseParser.StatementsContext context)
  {
    List<ProgramRule> atoms = [];
    foreach (var statementContext in context.statement())
    {
      HeadLiteral headLiteral = new Headless();
      List<BodyLiteral> bodyLiterals = [];

      HeadContext head = statementContext.head();
      BodyContext body = statementContext.body();

      if (head != null)
      {
        headLiteral = new HeadVisitor().Visit(head);
      }

      if (body != null)
      {
        bodyLiterals = new BodyVisitor().Visit(body);
      }

      atoms.Add(new ProgramRule(headLiteral, bodyLiterals));
    }

    return atoms;
  }
}