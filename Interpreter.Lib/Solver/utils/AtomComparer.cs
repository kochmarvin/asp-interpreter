using Interpreter.Lib.Results.Objects.Atoms;

/// <summary>
/// Compares two atoms List and checks if they are equal
/// </summary>
public class AtomListComparer : IEqualityComparer<List<Atom>>
{
  public bool Equals(List<Atom>? excpected, List<Atom>? compare)
  {
    if (excpected == null || compare == null)
      return excpected == compare;

    if (excpected.Count != compare.Count) return false;

    for (int i = 0; i < excpected.Count; i++)
    {
      if (excpected[i].ToString() != compare[i].ToString())
      {
        return false;
      }
    }

    return true;
  }

  public int GetHashCode(List<Atom> set)
  {
    unchecked // Overflow is fine
    {
      int hash = 19;

      foreach (var atom in set)
      {
        hash = hash * 31 + atom.ToString().GetHashCode();
      }

      return hash;
    }
  }
}