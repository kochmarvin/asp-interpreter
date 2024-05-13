using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Visitors;

public class TermVisitor : LparseBaseVisitor<Term>
{

  /// <summary>
  /// Parses the context of a term and either returns a number an or an variable
  /// </summary>
  /// <param name="context">The context of a term.</param>
  /// <returns>The parsed term</returns>
  public override Term VisitTerm(LparseParser.TermContext context)
  {
    // If the term has terms its a function term so call it recursivly
    if (context.terms() != null && context.ID() != null)
    {
      string name = context.ID().GetText();
      // the minus suggorates a classical negation
      name = context.MINUS() != null ? "-" + name : name;
      List<Term> subTerms = new TermsVisitor().Visit(context.terms());

      return new FunctionTerm(name, subTerms);
    }

    // if the id is not null it is a normal vairable
    if (context.ID() != null)
    {
      return new Variable(context.ID().GetText());
    }

    // If number is not null its a normal number with a minus contect it is negative 
    if (context.NUMBER() != null)
    {
      return new Number(int.Parse(context.NUMBER().GetText()) * (context.MINUS() != null ? -1 : 1));
    }

    // if the varable context is not null its a vairable.
    if (context.VARIABLE() != null)
    {
      return new Variable(context.VARIABLE().GetText());
    }

    return null;
  }
}