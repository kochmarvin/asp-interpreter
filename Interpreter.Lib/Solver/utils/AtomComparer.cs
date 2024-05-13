using Interpreter.Lib.Results.Objects.Atoms;

/// <summary>
/// Compares two atoms List and checks if they are equal
/// </summary>
public class AtomListComparer : IEqualityComparer<List<Atom>>
{
  public bool Equals(List<Atom> x, List<Atom> y)
  {
    if (x.Count != y.Count) return false;
    for (int i = 0; i < x.Count; i++)
    {
      if (x[i].ToString() != y[i].ToString())
        return false;
    }
    return true;
  }

  public int GetHashCode(List<Atom> obj)
  {
    unchecked // Overflow is fine
    {
      int hash = 19;
      foreach (var atom in obj)
      {
        hash = hash * 31 + atom.ToString().GetHashCode();
      }
      return hash;
    }
  }
}