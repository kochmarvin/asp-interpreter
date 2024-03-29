using Interpreter.Lib.Results.Interfaces;

namespace Interpreter.Lib.Results.Objects.Terms;

public abstract class Term : IMatch<Term>, IApplier<Term>, IComparable<Term>
{
  public abstract Term Apply(Dictionary<string, Term> substitutions);

  public int CompareTo(Term? other)
  {
    throw new NotImplementedException();
  }

  public abstract bool Match(Term other, Dictionary<string, Term> substiutionen);

  public override string ToString()
  {
    return base.ToString();
  }
}