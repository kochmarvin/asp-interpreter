//-----------------------------------------------------------------------
// <copyright file="IQueryVisitor.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Visitors;

using Antlr4.Runtime.Tree;

/// <summary>
/// The interface for the query visitor.
/// </summary>
/// <typeparam name="T">The object of the query.</typeparam>
public interface IQueryVisitor<T> : IParseTreeVisitor<T>
{
  /// <summary>
  /// Parses a query from a given context.
  /// </summary>
  /// <param name="context">The context which should get parsed.</param>
  /// <returns>The parsed query.</returns>
  T VisitQuery(LparseParser.ProgramContext context);
}