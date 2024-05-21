namespace Interpreter.Lib.Results.Objects.Literals;

using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// A basic Atom litereral so everything that is not hello(X) or just hello(X).
/// </summary>
/// <param name="positive">If the atom has a not or not a not infront of it</param>
/// <param name="atom">The Atom.</param>
public class AtomLiteral : Literal
{
  private bool positiv;
  private Atom atom;

  public bool Positive
  {
    get
    {
      return positiv;
    }
    private set
    {
      positiv = value;
    }
  }

  public Atom Atom
  {
    get
    {
      return atom;
    }
    private set
    {
      atom = value ?? throw new ArgumentNullException(nameof(Atom), "Is not supposed to be null");
    }
  }

  public AtomLiteral(bool positive, Atom atom)
  {
    Positive = positive;
    Atom = atom;
  }


  public override T? Accept<T>(LiteralVisitor<T> visitor) where T : default
  {
    ArgumentNullException.ThrowIfNull(visitor, "Is not supposed to be null");
    return visitor.Visit(this);
  }

  public override void AddToGraph(ILiteralAddToGraph literalAddToGraph)
  {
    ArgumentNullException.ThrowIfNull(literalAddToGraph, "Is not supposed to be null");
    literalAddToGraph.AddToGraph(this);
  }

  /// <summary>
  /// Applies the substiution to the object.
  /// </summary>
  /// <param name="substitutions">The found subsitituions.</param>
  /// <returns>A new object instance.</returns>
  public override Literal Apply(Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");
    Atom appliedAtom = Atom.Apply(substitutions);
    return new AtomLiteral(Positive, appliedAtom);
  }

  public override List<Atom> GetLiteralAtoms()
  {
    return [Atom];
  }

  /// <summary>
  /// Returns all the variables of the object as a list.
  /// </summary>
  /// <returns>The available variables.</returns>
  public override List<string> GetVariables()
  {
    return Atom.GetVariables();
  }

  /// <summary>
  /// Checks if the object has any varibles.
  /// </summary>
  /// <returns>Either if there are variables or not.</returns>
  public override bool HasVariables()
  {
    return Atom.HasVariables();
  }

  // <summary>
  /// Checks if the object has a specific variable.
  /// </summary>
  /// <param name="variable">The variable to be checked.</param>
  /// <returns>Either if it includes the variable or not.</returns>
  public override bool HasVariables(string variable)
  {
    return Atom.HasVariables(variable);
  }

  /// <summary>
  /// Basic to string method.
  /// </summary>
  /// <returns>The string equivalent.</returns>
  public override string ToString()
  {
    return $"{(Positive ? "" : "not ")}{Atom}";
  }
}