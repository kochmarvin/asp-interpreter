namespace Interpreter.Lib.Results;

using Antlr4.Runtime.Tree;

public interface IProgramVisitor<T> : IParseTreeVisitor<T>
{
  T VisitProgram(LparseParser.ProgramContext context);
}