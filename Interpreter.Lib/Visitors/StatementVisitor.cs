using Interpreter.Lib.Results;
using static LparseParser;

public class StatementsVisitor : LparseBaseVisitor<List<Fact>>
{
  public override List<Fact> VisitStatements(LparseParser.StatementsContext context)
  {
    List<Fact> atoms = [];
    foreach (var statementContext in context.statement())
    {
      Fact newFact = new Fact();

      HeadContext head = statementContext.head();
      BodyContext body = statementContext.body();

      if (head == null)
      {
        // parse rule that is not allowed
        continue;
      }

      if (head.disjunction() != null)
      {
        newFact = new HeadVisitor().Visit(head);
      }

      if (head.choice() != null) {
        // parse choice.
      }

      if (body != null)
      {
        foreach (Naf_literalContext naf_Literal in body.naf_literal())
        {
          Fact bodyLiteral = new Fact();

          if (naf_Literal.classical_literal() != null)
          {
            Classical_literalContext classic = naf_Literal.classical_literal();
            bodyLiteral.Name = classic.ID().GetText();

            foreach (var argument in classic.terms().term())
            {
              if (argument.ID() != null)
              {
                bodyLiteral.Arguments.Add(argument.ID().GetText());
              }

              if (argument.ANONYMOUS_VARIABLE() != null)
              {
                bodyLiteral.Arguments.Add("_");
              }

              if (argument.VARIABLE() != null)
              {
                bodyLiteral.Arguments.Add(argument.VARIABLE().GetText());
              }
            }
          }

          // da muss man noch das = und so machne.

          newFact.Body.Add(bodyLiteral);
        }
      }


      if (head.choice() != null)
      {
        // parse choice
      }

      atoms.Add(newFact);
    }

    return atoms;
  }
}