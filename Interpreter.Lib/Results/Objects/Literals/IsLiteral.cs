using Interpreter.Lib.Results.Enums;
using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.Literals;

/// <summary>
/// The is Literal to calculate things.
/// </summary>
/// <param name="newVar">The new var which will get the result.</param>
/// <param name="left">The left side of the operation</param>
/// <param name="op">The operator.</param>
/// <param name="right">The right side of the opreation</param>
public class IsLiteral : Literal
{
  private Variable newVar;
  private Term left;
  private Term right;

  public Variable New
  {
    get
    {
      return newVar;
    }
    private set
    {
      newVar = value ?? throw new ArgumentNullException(nameof(New), "Is not supposed to be null");
    }
  }

  public Term Left
  {
    get { return left; }
    private set
    {
      left = value ?? throw new ArgumentNullException(nameof(Left), "Is not supposed to be null");
    }
  }
  public Operator Operator { get; private set; }

  public Term Right
  {
    get { return right; }
    private set
    {
      right = value ?? throw new ArgumentNullException(nameof(Right), "Is not supposed to be null");
    }
  }

  public IsLiteral(Variable newVar, Term left, Operator op, Term right)
  {
    Operator = op;
    Right = right;
    Left = left;
    New = newVar;
  }

  public override T? Accept<T>(LiteralVisitor<T> visitor) where T : default
  {
    return visitor.Visit(this);
  }

  public override void AddToGraph(ILiteralAddToGraph literalAddToGraph)
  {
    return;
  }

  /// <summary>
  /// Applies the substiution to the object.
  /// </summary>
  /// <param name="substitutions">The found subsitituions.</param>
  /// <returns>A new object instance.</returns>
  public override Literal Apply(Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    Term appliedLeft = Left.Apply(substitutions);
    Term appliedRight = Right.Apply(substitutions);
    return new IsLiteral(New, appliedLeft, Operator, appliedRight);
  }

  public override List<Atom> GetLiteralAtoms()
  {
    return [];
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

  /// <summary>
  /// Checks if the object has a specific variable.
  /// </summary>
  /// <param name="variable">The variable to be checked.</param>
  /// <returns>Either if it includes the variable or not.</returns>
  public override bool HasVariables(string variable)
  {
    return Left.HasVariables(variable) || Right.HasVariables(variable);
  }

  /// <summary>
  /// Returns all the variables of the object as a list.
  /// </summary>
  /// <returns>The available variables.</returns>
  public override string ToString()
  {
    return $"{New} is {Left}{OperatorExtension.ToSymbol(Operator)}{Right}";
  }
}