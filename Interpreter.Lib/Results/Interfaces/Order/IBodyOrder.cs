using Interpreter.Lib.Results.Objects.BodyLiterals;

namespace Interpreter.Lib.Results.Interfaces;

/// <summary>
/// Interface to get the order integer of a specific body
/// </summary>
public interface IBodyOrder
{
  int Order(LiteralBody literalBody);
}