using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Interfaces;

public interface IMatch<T>
{
  public bool Match(T other, Dictionary<string, Term> substiutionen);
}