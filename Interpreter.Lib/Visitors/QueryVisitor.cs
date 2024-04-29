using System.Data;
using Interpreter.Lib.Results.Objects;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Visitors;

public class QueryVisitor : LparseBaseVisitor<List<Query>>, IQueryVisitor<List<Query>>
{
  public List<Query> VisitQuery(LparseParser.ProgramContext context)
  {
    if (context.query() != null && context.query().body() != null)
    {
      var bodyVisitor = new BodyVisitor();

      List<List<Body>> bodies = [];

      foreach (var body in context.query().body())
      {
        bodies.Add(bodyVisitor.Visit(body));
      }

      List<Query> queries = [];
      foreach (var body in bodies)
      {
        List<string> variables = body.SelectMany(current => current.GetVariables()).ToList();
        HashSet<string> variablesSet = [.. variables];
        List<Term> terms = [];

        variablesSet.ToList().ForEach(term => terms.Add(new Variable(term)));

        AtomHead head = new AtomHead(new Atom(Guid.NewGuid().ToString(), terms));

        Query query = new Query(new ProgramRule(head, body), variablesSet);
        queries.Add(query);
      }

      return queries;
    }

    throw new SyntaxErrorException("Could not parse the query, maybe a typo? ._.");
  }
}