
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Visitors;

/// <summary>
/// Implementation of the Terms visitor.
/// </summary>
public class TermsVisitor : LparseBaseVisitor<List<Term>>
{
  /// <summary>
  /// Parses the terms context and goes through each term and stores it inside a list.
  /// </summary>
  /// <param name="context">The terms context.</param>
  /// <returns>The parsed list of terms.</returns>
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