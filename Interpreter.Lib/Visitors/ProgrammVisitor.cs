namespace Interpreter.Lib.Results;

public class ProgramVisitor : LparseBaseVisitor<Programm>, IProgramVisitor<Programm>
{
  public override Programm VisitProgram(LparseParser.ProgramContext context)
  {
    Programm programm = new Programm();
    if (context.statements() != null)
    {
      var statementsVisitor = new StatementsVisitor();
      programm.Facts = statementsVisitor.Visit(context.statements());
    }

    return programm;
  }
}