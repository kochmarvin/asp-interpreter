namespace Interpreter.Lib.Solver;

/// <summary>
/// A generic list comparere of two list
/// </summary>
/// <typeparam name="T">The type of the list</typeparam>
public class ListComparer<T> : IEqualityComparer<List<T>>
{
  public bool Equals(List<T> x, List<T> y)
  {
    if (x == null || y == null)
      return x == y;

    // Sort both lists and then compare
    var sortedX = x.OrderBy(i => i).ToList();
    var sortedY = y.OrderBy(i => i).ToList();

    return sortedX.SequenceEqual(sortedY);
  }

  public int GetHashCode(List<T> obj)
  {
    if (obj == null)
      return 0;

    // Generate hash code based on sorted elements
    int hash = 17;
    foreach (var item in obj.OrderBy(i => i))
    {
      hash = hash * 23 + (item == null ? 0 : item.GetHashCode());
    }
    return hash;
  }
}