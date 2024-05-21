namespace Interpreter.Lib.Solver;

/// <summary>
/// A generic list comparere of two list
/// </summary>
/// <typeparam name="T">The type of the list</typeparam>
public class ListComparer<T> : IEqualityComparer<List<T>>
{
  public bool Equals(List<T>? expected, List<T>? compare)
  {
    if (expected == null || compare == null)
      return expected == compare;

    // Sort both lists and then compare
    var sortedX = expected.OrderBy(item => item).ToList();
    var sortedY = compare.OrderBy(item => item).ToList();

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