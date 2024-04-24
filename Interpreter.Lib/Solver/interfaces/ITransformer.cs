using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Rule;

namespace Interpreter.Lib.Solver.Interfaces;

public interface ITransformer
{
  public List<List<int>> TransformToFormular(Preperation Preperation);
  public List<List<Atom>> ReTransform(List<List<int>> results);
}