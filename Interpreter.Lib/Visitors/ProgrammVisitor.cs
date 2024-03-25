using Interpreter.Lib.Results.Objects.Rule;

namespace Interpreter.Lib.Visitors;

public class ProgramVisitor : LparseBaseVisitor<List<ProgramRule>>, IProgramVisitor<List<ProgramRule>>
{
  public override List<ProgramRule> VisitProgram(LparseParser.ProgramContext context)
  {
    if (context.statements() != null)
    {
      var statementsVisitor = new StatementsVisitor();
      return statementsVisitor.Visit(context.statements());
    }

    throw new InvalidOperationException("Could not parse Programm");
  }
}