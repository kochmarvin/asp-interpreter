using Antlr4.Runtime.Tree;

namespace Interpreter.Lib.Visitors;

/// <summary>
/// The interface for the query visitor.
/// </summary>
/// <typeparam name="T">The object of the query.</typeparam>
public interface IQueryVisitor<T> : IParseTreeVisitor<T>
{
  T VisitQuery(LparseParser.ProgramContext context);
}