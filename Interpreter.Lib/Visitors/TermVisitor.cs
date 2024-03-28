using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Visitors;

public class TermVisitor : LparseBaseVisitor<Term>
{
  public override Term VisitTerm(LparseParser.TermContext context)
  {
    if (context.terms() != null)
    {
      string name = context.ID().GetText();
      name = context.MINUS() != null ? "-" + name : name;
      List<Term> subTerms = new TermsVisitor().Visit(context.terms());

      return new FunctionTerm(name, subTerms);
    }

    if (context.ID() != null)
    {
      return new Variable(context.ID().GetText());
    }

    if (context.NUMBER() != null)
    {
      return new Number(int.Parse(context.NUMBER().GetText()));
    }

    // TODO maybe remove?
    if (context.ANONYMOUS_VARIABLE() != null)
    {
      return new Variable("_");
    }

    if (context.VARIABLE() != null)
    {
      return new Variable(context.VARIABLE().GetText());
    }

    return null;
  }
}