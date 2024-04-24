namespace Interpreter.Lib.Solver;
public class ListComparer<T> : IEqualityComparer<List<T>>
    where T : IEquatable<T>
{
  public bool Equals(List<T>? x, List<T>? y)
  {
    if (x == null || y == null)
    {
      return false;
    }

    return x.SequenceEqual(y);
  }

  public int GetHashCode(List<T> obj)
  {
    unchecked
    {
      int hash = 19;
      foreach (var item in obj)
      {
        hash = hash * 31 + item.GetHashCode();
      }
      return hash;
    }
  }
}