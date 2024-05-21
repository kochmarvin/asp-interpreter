using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Terms;

public interface IGroundMatcher
{
  List<Dictionary<string, Term>> MatchAtomLiteral(Dictionary<string, Term> substitutions, AtomLiteral atomLiteral);
  List<Dictionary<string, Term>> MatchComparisonLiteral(Dictionary<string, Term> substitutions, ComparisonLiteral comparisonLiteral);
  List<Dictionary<string, Term>> MatchIsLiteral(Dictionary<string, Term> substitutions, IsLiteral isLiteral);
}