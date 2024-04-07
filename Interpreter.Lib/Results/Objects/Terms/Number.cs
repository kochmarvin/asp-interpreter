
namespace Interpreter.Lib.Results.Objects.Terms;

public class Number(int value) : Term
{
  public int Value { get; } = value;

  public override Term Apply(Dictionary<string, Term> substitutions)
  {
    return this;
  }

  public override bool HasVariable()
  {
    return false;
  }

  public override bool Match(Term other, Dictionary<string, Term> substiutionen)
  {
    return Value == ((Number)other).Value;
  }

  public override string ToString()
  {
    return Value.ToString();
  }
}