//-----------------------------------------------------------------------
// <copyright file="ParseException.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Errors;

/// <summary>
/// The parser exception for the syntax error listener.
/// </summary>
public class ParseException : Exception
{
  /// <summary>
  /// Initializes a new instance of the <see cref="ParseException"/> class.
  /// </summary>
  /// <param name="message">The error message of the exception.</param>
  public ParseException(string message)
    : base(message)
  {
  }
}