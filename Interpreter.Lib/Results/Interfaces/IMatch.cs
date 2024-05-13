using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Interfaces;

/// <summary>
/// Interface to return the matches found of a specific object
/// </summary>
/// <typeparam name="T">The type of the object which gets returned</typeparam>
public interface IMatch<T>
{
  public bool Match(T other, Dictionary<string, Term> substiutionen);
}