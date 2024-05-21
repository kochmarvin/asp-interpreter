namespace Interpreter.Lib.Results.Objects.Literals;

using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// A basic Atom litereral so everything that is not hello(X) or just hello(X).
/// </summary>
/// <param name="positive">If the atom has a not or not a not infront of it</param>
/// <param name="atom">The Atom.</param>
public class AtomLiteral(bool positive, Atom atom) : Literal
{
  public bool Positive { get; } = positive;
  public Atom Atom { get; } = atom;

  public override void AddToGraph(ILiteralAddToGraph literalAddToGraph)
  {
    literalAddToGraph.AddToGraph(this);
  }

  /// <summary>
  /// Applies the substiution to the object.
  /// </summary>
  /// <param name="substitutions">The found subsitituions.</param>
  /// <returns>A new object instance.</returns>
  public override Literal Apply(Dictionary<string, Term> substitutions)
  {
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
  /// Gives the order integer of a specific literal.
  /// </summary>
  /// <param name="literalOrder">The literal order visitor.</param>
  /// <returns>The order integer of a spercific literal.</returns>
  public override int Order(ILiteralOrder literalOrder)
  {
    return literalOrder.Order(this);
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