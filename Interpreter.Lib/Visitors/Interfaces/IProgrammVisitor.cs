using Antlr4.Runtime.Tree;

namespace Interpreter.Lib.Visitors;

public interface IProgramVisitor<T> : IParseTreeVisitor<T>
{
  T VisitProgram(LparseParser.ProgramContext context);
}