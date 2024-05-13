using System.Data;
using Interpreter.Lib.Results.Objects.Rule;

namespace Interpreter.Lib.Visitors;

/// <summary>
/// Implementation of the Programm Visitor.
/// </summary>
public class ProgramVisitor : LparseBaseVisitor<List<ProgramRule>>, IProgramVisitor<List<ProgramRule>>
{
  /// <summary>
  /// Goes into the statements and starts a new Statments visitor.
  /// </summary>
  /// <param name="context">The context of the program.</param>
  /// <returns></returns>
  /// <exception cref="SyntaxErrorException">If there are no statements</exception>
  public override List<ProgramRule> VisitProgram(LparseParser.ProgramContext context)
  {
    if (context.statements() != null)
    {
      var statementsVisitor = new StatementsVisitor();
      return statementsVisitor.Visit(context.statements());
    }

    throw new SyntaxErrorException("Could not parse Programm");
  }
}