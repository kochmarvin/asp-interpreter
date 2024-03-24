namespace Interpreter.Lib.Results;

public class ProgramVisitor : LparseBaseVisitor<Programm>, IProgramVisitor<Programm>
{
  public override Programm VisitProgram(LparseParser.ProgramContext context)
  {
    Programm programm = new Programm();
    Console.WriteLine("BABY");
    if (context.statements() != null)
    {
      Console.WriteLine("selam?");
      var statementsVisitor = new StatementsVisitor();
      programm.Atoms = statementsVisitor.Visit(context.statements());
    }

    return programm;
  }
}