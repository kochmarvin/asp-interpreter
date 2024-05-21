using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Rule;

namespace Interpreter.Lib.Results.Interfaces;

public interface IAddToGraphVisitor : ILiteralAddToGraph, IBodyAddToGraph
{
  public bool OnlyPositives { get; }
  public Action<ProgramRule, Atom> Action { get; }
  public ProgramRule Rule { get; }
}