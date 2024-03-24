using Interpreter.Lib.Results;
using static LparseParser;

public class HeadVisitor : LparseBaseVisitor<Fact>
{
  public override Fact VisitHead(LparseParser.HeadContext context)
  {
    Fact head = new Fact();

    Classical_literalContext classic = context.disjunction().classical_literal()[0];
    head.Name = classic.ID().GetText();

    if (classic.terms() != null) {
      head.Arguments = new TermVisitor().Visit(classic.terms());
    }

    return head;
  }
}