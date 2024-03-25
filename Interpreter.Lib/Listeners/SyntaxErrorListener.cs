using Antlr4.Runtime;
using Interpreter.Lib.Errors;

namespace Interpreter.Lib.Listeners;
public class SyntaxErrorListener : BaseErrorListener
{
  public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg,
           RecognitionException e)
  {
    string errorMessage = $"Syntax error at line {line}:{charPositionInLine} - {msg}";
    throw new ParseException(errorMessage);
  }
}
