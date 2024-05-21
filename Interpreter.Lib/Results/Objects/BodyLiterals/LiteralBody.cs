using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.BodyLiterals;

public class LiteralBody : Body
{
  private Literal literal;
  public Literal Literal
  {
    get
    {
      return literal;
    }
    private set
    {
      literal = value ?? throw new ArgumentNullException(nameof(Literal), "Is not supposed to be null");
    }
  }

  public LiteralBody(Literal literal)
  {
    Literal = literal;
  }

  public override void AddToGraph(IBodyAddToGraph addToGraphVisitor)
  {
    ArgumentNullException.ThrowIfNull(addToGraphVisitor, "Is not supposed to be null");

    addToGraphVisitor.AddToGraph(this);
  }

  public override Body Apply(Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    Literal appliedLiteral = Literal.Apply(substitutions);
    return new LiteralBody(appliedLiteral);
  }

  public override List<string> GetVariables()
  {
    return Literal.GetVariables();
  }

  public override bool HasVariables()
  {
    return Literal.HasVariables();
  }

  public override bool HasVariables(string variable)
  {
    return Literal.HasVariables(variable);
  }

  public override string? ToString()
  {
    return Literal.ToString();
  }

  public override List<Atom> GetBodyAtoms()
  {
    return Literal.GetLiteralAtoms();
  }

  public override T? Accept<T>(LiteralVisitor<T> visitor) where T : default
  {
    return visitor.Visit(this);
  }
}