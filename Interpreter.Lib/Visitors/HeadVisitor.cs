using System.Data;
using Interpreter.Lib.Results;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Terms;
using static LparseParser;

namespace Interpreter.Lib.Visitors;

public class HeadVisitor : LparseBaseVisitor<List<Head>>
{
  public override List<Head> VisitHead(LparseParser.HeadContext context)
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

      return [new AtomHead(new Atom(name, terms))];
    }

    if (context.range() != null)
    {
      List<Head> results = [];
      string name = context.range().range_literal().ID().GetText();
      name = context.range().range_literal().MINUS() != null ? "-" + name : name;

      var rangeBinding = context.range().range_literal().range_binding();

      var start = ParseRangeNumber(rangeBinding.range_number()[0]);
      var end = ParseRangeNumber(rangeBinding.range_number()[1]);

      if (start > end)
      {
        throw new SyntaxErrorException("A Range operator has a larger start then end line: " + context.Start.Line);
      }

      for (int i = start; i <= end; i++)
      {
        results.Add(new AtomHead(new Atom(name, [new Number(i)])));
      }

      return results;
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

      return [new ChoiceHead(atoms)];
    }

    throw new SyntaxErrorException("Please revisit every head you made a mistake.");
  }

  private int ParseRangeNumber(Range_numberContext context)
  {
    var number = int.Parse(context.NUMBER().GetText());

    if (context.MINUS() != null)
    {
      return -number;
    }

    return number;
  }
}