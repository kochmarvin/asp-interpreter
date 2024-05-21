using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.Atoms;

/// <summary>
/// The Atom, so every costrcut of hello(X) or hello(1, 1, 3).
/// </summary>
public class Atom : IMatch<Atom>, IApplier<Atom>, IHasVariables, IGetVariables
{
  private string name;
  private List<Term> args;
  public string Name
  {
    get
    {
      return name;
    }

    private set
    {
      name = value ?? throw new ArgumentNullException(nameof(Name), "Is not supposed to be null");
    }
  }
  public List<Term> Args
  {
    get
    {
      return args;
    }
    private set
    {
      args = value ?? throw new ArgumentNullException(nameof(Args), "Is not supposed to be null");
    }
  }

  public Atom(string name, List<Term> args)
  {
    Name = name;
    Args = args;
  }

  /// <summary>
  /// Returns the signature of the atom e.g hello/2
  /// </summary>
  public string Signature
  {
    get
    {
      return $"{Name}/{Args.Count}";
    }
  }

  /// <summary>
  /// Applies the substiution to the object.
  /// </summary>
  /// <param name="substitutions">The found subsitituions.</param>
  /// <returns>A new object instance.</returns>
  public Atom Apply(Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    var appliedArgs = Args.Select(arg => arg.Apply(substitutions)).ToList();
    return new Atom(Name, appliedArgs);
  }

  public bool Equals(Atom? other)
  {
    ArgumentNullException.ThrowIfNull(other, "Is not supposed to be null");

    return other?.ToString() == ToString();
  }
  /// <summary>
  /// Returns all the variables of the object as a list.
  /// </summary>
  /// <returns>The available variables.</returns>
  public List<string> GetVariables()
  {
    return Args.SelectMany(arg => arg.GetVariables()).ToList();
  }

  /// <summary>
  /// Checks if the object has any varibles.
  /// </summary>
  /// <returns>Either if there are variables or not.</returns>

  public bool HasVariables()
  {
    foreach (var term in Args)
    {
      if (term.HasVariables())
      {
        return true;
      }
    }

    return false;
  }

  // <summary>
  /// Checks if the object has a specific variable.
  /// </summary>
  /// <param name="variable">The variable to be checked.</param>
  /// <returns>Either if it includes the variable or not.</returns>
  public bool HasVariables(string variable)
  {
    foreach (var term in Args)
    {
      if (term.HasVariables())
      {
        return true;
      }

    }
    return false;
  }

  /// <summary>
  /// Checks if two atoms are match.
  /// </summary>
  /// <param name="other">The atom you want to check if it is a match.</param>
  /// <param name="substiutionen">The found substittuions.</param>
  /// <returns>Either if it is a match or not</returns>
  public bool Match(Atom other, Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(other, "Is not supposed to be null");
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    if (Name != other.Name || Args.Count != other.Args.Count)
    {
      return false;
    }

    for (int i = 0; i < Args.Count; i++)
    {
      if (!Args[i].Match(other.Args[i], substitutions))
      {
        return false;
      }
    }

    return true;
  }

  /// <summary>
  /// Basic to string method.
  /// </summary>
  /// <returns>The string equivalent.</returns>
  public override string ToString()
  {
    if (Args.Count == 0)
    {
      return Name;
    }

    var argsString = string.Join(", ", Args.Select(arg => arg.ToString()));
    return $"{Name}({argsString})";
  }
}