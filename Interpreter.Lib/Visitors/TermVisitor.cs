using Interpreter.Lib.Results;
using static LparseParser;

public class TermVisitor : LparseBaseVisitor<List<string>>
{
  public override List<string> VisitTerms(LparseParser.TermsContext context)
  {
    List<string> arguments = [];

    foreach (var argument in context.term())
    {
      if (argument.ID() != null)
      {
        arguments.Add(argument.ID().GetText());
      }

      if (argument.ANONYMOUS_VARIABLE() != null)
      {
        arguments.Add("_");
      }

      if (argument.VARIABLE() != null)
      {
        arguments.Add(argument.VARIABLE().GetText());
      }

      // can ein term einen term besitzen?
    }

    return arguments;
  }
}