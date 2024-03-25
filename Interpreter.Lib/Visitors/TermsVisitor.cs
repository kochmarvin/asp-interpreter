
using Interpreter.Lib.Results.Objects.Terms;

public class TermsVisitor : LparseBaseVisitor<List<Term>>
{
  public override List<Term> VisitTerms(LparseParser.TermsContext context)
  {
    List<Term> terms = [];

    foreach (var argument in context.term())
    {
      Term term = new TermVisitor().Visit(argument);

      if (term != null)
      {
        terms.Add(term);
      }
    }
    return terms;
  }
}