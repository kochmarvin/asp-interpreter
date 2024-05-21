using Interpreter.Lib.Results.Enums;
using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.Literals;

/// <summary>
/// Literal for a comparison or a unification
/// </summary>
/// <param name="left">The left side of the compairrison</param>
/// <param name="relation">The relation of the comparisson</param>
/// <param name="right">The right side of the comparisson</param>
public class ComparisonLiteral : Literal
{
  private Term left;
  private Term right;
  private Relation relation;

  public Term Left
  {
    get { return left; }
    private set
    {
      left = value ?? throw new ArgumentNullException(nameof(Left), "Is not supposed to be null");
    }
  }

  public Relation TermRelation
  {
    get
    {
      return relation;
    }
    private set
    {
      relation = value;
    }
  }

  public Term Right
  {
    get { return right; }
    private set
    {
      right = value ?? throw new ArgumentNullException(nameof(Right), "Is not supposed to be null");
    }
  }

  public ComparisonLiteral(Term left, Relation relation, Term right)
  {
    Left = left;
    TermRelation = relation;
    Right = right;
  }

  /// <summary>
  /// Applies the substiution to the object.
  /// </summary>
  /// <param name="substitutions">The found subsitituions.</param>
  /// <returns>A new object instance.</returns>
  public override Literal Apply(Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions);

    Term appliedLeft = Left.Apply(substitutions);
    Term appliedRight = Right.Apply(substitutions);
    return new ComparisonLiteral(appliedLeft, TermRelation, appliedRight);
  }

  /// <summary>
  /// Returns all the variables of the object as a list.
  /// </summary>
  /// <returns>The available variables.</returns>
  public override List<string> GetVariables()
  {
    return [.. Left.GetVariables(), .. Right.GetVariables()];
  }

  /// <summary>
  /// Checks if the object has any varibles.
  /// </summary>
  /// <returns>Either if there are variables or not.</returns>
  public override bool HasVariables()
  {
    return Left.HasVariables() || Right.HasVariables();
  }

  // <summary>
  /// Checks if the object has a specific variable.
  /// </summary>
  /// <param name="variable">The variable to be checked.</param>
  /// <returns>Either if it includes the variable or not.</returns>
  public override bool HasVariables(string variable)
  {
    return Left.HasVariables(variable) || Right.HasVariables(variable);
  }

  /// <summary>
  /// Basic to string method.
  /// </summary>
  /// <returns>The string equivalent.</returns>
  public override string ToString()
  {
    return $"{Left}{RelationExtensions.ToSymbol(TermRelation)}{Right}";
  }

  public override List<Atom> GetLiteralAtoms()
  {
    return [];
  }

  public override void AddToGraph(ILiteralAddToGraph literalAddToGraph)
  {
    return;
  }

  public override T? Accept<T>(LiteralVisitor<T> visitor) where T : default
  {
    return visitor.Visit(this);
  }
}