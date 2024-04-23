using Antlr4.Runtime.Tree;

namespace Interpreter.Lib.Visitors;

public interface IQueryVisitor<T> : IParseTreeVisitor<T>
{
  T VisitQuery(LparseParser.ProgramContext context);
}