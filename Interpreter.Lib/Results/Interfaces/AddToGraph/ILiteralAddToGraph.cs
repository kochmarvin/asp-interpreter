using Interpreter.Lib.Results.Objects.Literals;

namespace Interpreter.Lib.Results.Interfaces;

/// <summary>
/// Interface to get the order integer of a specific literal
/// </summary>
public interface ILiteralAddToGraph
{
  void AddToGraph(AtomLiteral atomLiteral);
}