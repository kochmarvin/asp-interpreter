//-----------------------------------------------------------------------
// <copyright file="SyntaxErrorListener.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Listeners;

using Antlr4.Runtime;
using Interpreter.Lib.Errors;

/// <summary>
/// Override for the syntax error listener to print out the custom syntax error.
/// </summary>
public class SyntaxErrorListener : BaseErrorListener
{
  /// <summary>
  /// Overrides the SyntaxError method to throw a custom ParseException with a detailed error message.
  /// </summary>
  /// <param name="output">The TextWriter to write the error message to.</param>
  /// <param name="recognizer">The recognizer where the error occurred.</param>
  /// <param name="offendingSymbol">The offending symbol that caused the error.</param>
  /// <param name="line">The line number where the error occurred.</param>
  /// <param name="charPositionInLine">The position in the line where the error occurred.</param>
  /// <param name="msg">The error message.</param>
  /// <param name="e">The exception that was thrown.</param>
  /// <exception cref="ParseException">Thrown when a syntax error is encountered.</exception>
  public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
  {
    string errorMessage = $"Syntax error at line {line}:{charPositionInLine} - {msg}";
    throw new ParseException(errorMessage);
  }
}
