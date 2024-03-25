namespace Interpreter.Lib.Errors;

public class ParseException : Exception
{
  public ParseException(string message) : base(message) { }
}