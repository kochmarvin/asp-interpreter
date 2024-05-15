using Antlr4.Runtime.Tree;

namespace Interpreter.Lib.Visitors;

/// <summary>
/// Interface for the Programm visitor
/// </summary>
/// <typeparam name="T">The obejcts which are the result</typeparam>
public interface IProgramVisitor<T> : IParseTreeVisitor<T>
{
  /// <summary>
  /// Parses a Programm from a given context.
  /// </summary>
  /// <param name="context">The context which should get parsed.</param>
  /// <returns>The parsed Program.</returns>
  T VisitProgram(LparseParser.ProgramContext context);
}