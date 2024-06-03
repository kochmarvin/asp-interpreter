//-----------------------------------------------------------------------
// <copyright file="QueryVisitor.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Visitors;

using System.Data;
using Interpreter.Lib.Results.Objects;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// Implementation of the query visitor.
/// </summary>
public class QueryVisitor : LparseBaseVisitor<List<Query>>, IQueryVisitor<List<Query>>
{
  /// <summary>
  /// Parses a query of the program context.
  /// </summary>
  /// <param name="context">The context of the program.</param>
  /// <returns>The parsed query.</returns>
  /// <exception cref="SyntaxErrorException">If there is no query to be found.</exception>
  public List<Query> VisitQuery(LparseParser.ProgramContext context)
  {
    if (context.query() != null && context.query().body() != null)
    {
      var bodyVisitor = new BodyVisitor();

      List<List<Body>> bodies = [];

      // parse the body of the query with the available body pasrser
      foreach (var body in context.query().body())
      {
        bodies.Add(bodyVisitor.Visit(body));
      }

      List<Query> queries = [];

      // Split up the bodies which are or connected and get the variables of each body
      foreach (var body in bodies)
      {
        // get the variables of the body
        List<string> variables = body.SelectMany(current => current.GetVariables()).ToList();

        // remove duplicates
        HashSet<string> variablesSet = [.. variables];
        List<Term> terms = [];

        // make variables out of it
        variablesSet.ToList().ForEach(term => terms.Add(new Variable(term)));

        // create a new atom with a uuid name to not have any matches
        AtomHead head = new AtomHead(new Atom(Guid.NewGuid().ToString(), terms));

        // return the parsed query.
        Query query = new Query(new ObjectParser(), new ProgramRule(head, body), variablesSet);
        queries.Add(query);
      }

      return queries;
    }

    throw new SyntaxErrorException("Could not parse the query, maybe a typo? ._.");
  }
}