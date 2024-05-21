using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Objects.BodyLiterals;

public abstract class Body : IApplier<Body>, IHasVariables, IGetVariables, IGetBodyAtoms
{
  public abstract Body Apply(Dictionary<string, Term> substitutions);

  public abstract List<string> GetVariables();

  public abstract bool HasVariables();

  public abstract bool HasVariables(string variable);

  public override string? ToString()
  {
    return base.ToString();
  }
  public abstract int Order(IBodyOrder orderVisitor);

  public abstract void AddToGraph(IBodyAddToGraph addToGraphVisitor);

  public abstract List<Atom> GetBodyAtoms();
}