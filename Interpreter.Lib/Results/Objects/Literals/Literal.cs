using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.Literals;

/// <summary>
/// Abstract Class for a Literal
/// </summary>
public abstract class Literal : IApplier<Literal>, IHasVariables, IGetVariables, IGetLiteralAtoms, ILiteralAccept
{
  /// <summary>
  /// Applies the substiution to the object.
  /// </summary>
  /// <param name="substitutions">The found subsitituions.</param>
  /// <returns>A new object instance.</returns>
  public abstract Literal Apply(Dictionary<string, Term> substitutions);

  public abstract List<Atom> GetLiteralAtoms();

  /// <summary>
  /// Returns all the variables of the object as a list.
  /// </summary>
  /// <returns>The available variables.</returns>
  public abstract List<string> GetVariables();

  /// <summary>
  /// Checks if the object has any varibles.
  /// </summary>
  /// <returns>Either if there are variables or not.</returns>
  public abstract bool HasVariables();

  // <summary>
  /// Checks if the object has a specific variable.
  /// </summary>
  /// <param name="variable">The variable to be checked.</param>
  /// <returns>Either if it includes the variable or not.</returns>
  public abstract bool HasVariables(string variable);

  public abstract void AddToGraph(ILiteralAddToGraph literalAddToGraph);

  /// <summary>
  /// Basic to string method.
  /// </summary>
  /// <returns>The string equivalent.</returns>
  public override string? ToString()
  {
    return base.ToString();
  }

  public abstract T? Accept<T>(LiteralVisitor<T> visitor);
}