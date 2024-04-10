using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Solver.Interfaces;

namespace Interpreter.Lib.Solver.defaults;

public class SatTransformer : ITransformer
{
  private Preperation _preperation;
  public List<List<int>> TransformToFormular(Preperation Preperation)
  {
    _preperation = Preperation;
    if (_preperation.Remainder.Count == 0)
    {
      return [];
    }

    // TODO transform the whole thing to numbers.

    return null;
  }

  public List<List<Atom>> ReTransform(List<List<int>> results)
  {
    List<List<Atom>> transformed = [];
    List<Atom> alwaysTrue = [];

    foreach (var rule in _preperation.FactuallyTrue)
    {
      if (rule.Head is AtomHead atomHead)
      {
        alwaysTrue.Add(atomHead.Atom);
      }
    }

    if (results.Count == 0) {
      return [alwaysTrue];
    }

    foreach(var set in results) {
      List<Atom> answers = [..alwaysTrue];

      // TODO actually remap the findings and retransform the not and remove imaginary classes


      transformed.Add(answers);
    }



    return transformed;
  }
}