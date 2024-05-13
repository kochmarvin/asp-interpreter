using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Interfaces;

/// <summary>
/// Interface to Apply substitution and return a type T
/// </summary>
/// <typeparam name="T">The object which gets applied on.</typeparam>
public interface IApplier<T> {
  T Apply(Dictionary<string, Term> substitutions);
}