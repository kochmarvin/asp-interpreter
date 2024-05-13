using Antlr4.Runtime.Tree;

namespace Interpreter.Lib.Visitors;

/// <summary>
/// Interface for the Programm visitor
/// </summary>
/// <typeparam name="T">The obejcts which are the result</typeparam>
public interface IProgramVisitor<T> : IParseTreeVisitor<T>
{
  T VisitProgram(LparseParser.ProgramContext context);
}