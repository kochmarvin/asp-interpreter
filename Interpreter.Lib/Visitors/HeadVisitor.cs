using Interpreter.Lib.Results;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Terms;
using static LparseParser;

namespace Interpreter.Lib.Visitors;

public class HeadVisitor : LparseBaseVisitor<Head>
{
  public override Head VisitHead(LparseParser.HeadContext context)
  {
    if (context.disjunction() != null)
    {
      Classical_literalContext classic = context.disjunction().classical_literal();
      string name = classic.ID().GetText();
      name = classic.MINUS() != null ? "-" + name : name;

      List<Term> terms = [];
      if (classic.terms() != null)
      {
        terms = new TermsVisitor().Visit(classic.terms());
      }

      return new AtomHead(new Atom(name, terms));
    }

    if (context.choice() != null)
    {
      List<Atom> atoms = [];

      foreach (var choice in context.choice().choice_elements().choice_element())
      {
        Classical_literalContext classic = choice.classical_literal();
        string name = classic.ID().GetText();

        List<Term> terms = [];
        if (classic.terms() != null)
        {
          terms = new TermsVisitor().Visit(classic.terms());
        }

        atoms.Add(new Atom(name, terms));
      }

      return new ChoiceHead(atoms);
    }

    return null;
  }
}