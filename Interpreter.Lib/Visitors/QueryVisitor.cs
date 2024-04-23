using System.Data;
using Interpreter.Lib.Results.Objects;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Visitors;

public class QueryVisitor : LparseBaseVisitor<Query>, IQueryVisitor<Query>
{
  public Query VisitQuery(LparseParser.ProgramContext context)
  {
    if (context.query() != null && context.query().body() != null)
    {
      var bodyVisitor = new BodyVisitor();
      var bodies = bodyVisitor.Visit(context.query().body());

      List<string> variables = bodies.SelectMany(body => body.GetVariables()).ToList();
      HashSet<string> variablesSet = [.. variables];
      List<Term> terms = [];

      variablesSet.ToList().ForEach(term => terms.Add(new Variable(term)));

      AtomHead head = new AtomHead(new Atom(Guid.NewGuid().ToString(), terms));

      Query query = new Query(new ProgramRule(head, bodies), variablesSet);
      return query;
    }

    throw new SyntaxErrorException("Could not parse the query, maybe a typo? ._.");
  }
}