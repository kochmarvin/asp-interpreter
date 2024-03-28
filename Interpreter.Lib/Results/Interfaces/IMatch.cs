namespace Interpreter.Lib.Results.Interfaces;

public interface IMatch<T> {
  public bool Match(T self, T other);
}