//-----------------------------------------------------------------------
// <copyright file="HeadVisitor.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Visitors;

using System.Data;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Terms;
using static LparseParser;

/// <summary>
/// Implementation of the Head visitor.
/// </summary>
public class HeadVisitor : LparseBaseVisitor<List<Head>>
{
  /// <summary>
  /// Parses a head from its context.
  /// </summary>
  /// <param name="context">The head context which should get parsed.</param>
  /// <returns>A List of parsed heads.</returns>
  /// <exception cref="SyntaxErrorException">If there has been a head used which is not recognized.</exception>
  public override List<Head> VisitHead(LparseParser.HeadContext context)
  {
    // Check if it is a normal head, without choice or range
    if (context.disjunction() != null)
    {
      // Add a minus "classical negation" to the name of the head if a minus is present
      Classical_literalContext classic = context.disjunction().classical_literal();
      string name = classic.ID().GetText();
      name = classic.MINUS() != null ? "-" + name : name;

      List<Term> terms = [];

      // Parse the terms of the head if there are any
      if (classic.terms() != null)
      {
        terms = new TermsVisitor().Visit(classic.terms());
      }

      // return a single atom head.
      return [new AtomHead(new Atom(name, terms))];
    }

    // Check if head is maybe a range and if its a range multiple heads are the result
    // because the range gets resolved.
    if (context.range() != null)
    {
      List<Head> results = [];

      // Add a minus "classical negation" to the name of the head if a minus is present
      string name = context.range().range_literal().ID().GetText();
      name = context.range().range_literal().MINUS() != null ? "-" + name : name;

      var rangeBinding = context.range().range_literal().range_binding();

      // Get the start and the end of the range
      var start = this.ParseRangeNumber(rangeBinding.range_number()[0]);
      var end = this.ParseRangeNumber(rangeBinding.range_number()[1]);

      // Would not make sense if start is bigger then end
      if (start > end)
      {
        throw new SyntaxErrorException("A Range operator has a larger start then end line: " + context.Start.Line);
      }

      // Simple for loop to create all atomheads.
      for (int i = start; i <= end; i++)
      {
        results.Add(new AtomHead(new Atom(name, [new Number(i)])));
      }

      return results;
    }

    // Check if it is maybe a choice
    if (context.choice() != null)
    {
      List<Atom> atoms = [];

      // Parse every choice element and add it to the atoms
      foreach (var choice in context.choice().choice_elements().choice_element())
      {
        Classical_literalContext classic = choice.classical_literal();

        // Add a minus "classical negation" to the name of the choice if a minus is present
        string name = classic.ID().GetText();
        name = classic.MINUS() != null ? "-" + name : name;

        List<Term> terms = [];

        // if the choice has terms parse those
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

  /// <summary>
  /// Parse a number given to its context.
  /// </summary>
  /// <param name="context">The number context which should get parsed.</param>
  /// <returns>Either a positive or a negative number.</returns>
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