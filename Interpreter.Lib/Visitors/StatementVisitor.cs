using Interpreter.Lib.Results;

public class StatementsVisitor : LparseBaseVisitor<List<Atom>>
{
  public override List<Atom> VisitStatements(LparseParser.StatementsContext context)
  {
    List<Atom> atoms = [];
    foreach (var statementContext in context.statement())
    {
      Console.WriteLine("hihi");
      Atom a = new Atom();
      if (statementContext.head() != null)
      {
        Console.WriteLine("gurl");
        a.Name = statementContext.head().disjunction().classical_literal()[0].ID().GetText();
      }
      atoms.Add(a);
    }

    return atoms;
  }
}