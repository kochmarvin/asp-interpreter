using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Interfaces;

public interface IApplier<T> {
  T Apply(Dictionary<string, Term> substitutions);
}