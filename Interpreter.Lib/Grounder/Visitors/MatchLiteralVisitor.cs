using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Terms;

public class MatchLiteralVisitor : LiteralVisitor<List<Dictionary<string, Term>>>
{
  private IGroundMatcher groundMatcher;
  private Dictionary<string, Term> substitutions;

  public IGroundMatcher GroundMatcher
  {
    get
    {
      return groundMatcher;

    }

    private set
    {
      groundMatcher = value ?? throw new ArgumentNullException(nameof(GroundMatcher) + "Is not supposed to be null");
    }
  }

  public Dictionary<string, Term> Substitutions
  {
    get
    {
      return substitutions;
    }

    private set
    {
      substitutions = value ?? throw new ArgumentNullException(nameof(Substitutions) + "Is not supposed to be null");
    }
  }

  public MatchLiteralVisitor(
    Dictionary<string, Term> substitutions,
    IGroundMatcher groundMatcher
  )
  {
    GroundMatcher = groundMatcher;
    Substitutions = substitutions;
  }

  public override List<Dictionary<string, Term>> Visit(LiteralBody literalBody)
  {
    ArgumentNullException.ThrowIfNull(literalBody, "Is not supposed to be null");
   
    return literalBody.Literal.Accept(this) ?? throw new InvalidOperationException("Trying to match a literal which is not supported");
  }

  public override List<Dictionary<string, Term>> Visit(AtomLiteral atomLiteral)
  {
    ArgumentNullException.ThrowIfNull(atomLiteral, "Is not supposed to be null");

    return GroundMatcher.MatchAtomLiteral(Substitutions, atomLiteral);
  }

  public override List<Dictionary<string, Term>> Visit(ComparisonLiteral comparisonLiteral)
  {
    ArgumentNullException.ThrowIfNull(comparisonLiteral, "Is not supposed to be null");

    return GroundMatcher.MatchComparisonLiteral(Substitutions, comparisonLiteral);
  }

  public override List<Dictionary<string, Term>> Visit(IsLiteral isLiteral)
  {
    ArgumentNullException.ThrowIfNull(isLiteral, "Is not supposed to be null");

    return GroundMatcher.MatchIsLiteral(Substitutions, isLiteral);
  }
}