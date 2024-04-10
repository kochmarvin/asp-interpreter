using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Solver.Interfaces;

namespace Interpreter.Lib.Solver.defaults;

public class SatTransformer : ITransformer
{
  private Preperation? _preperation;
  private Dictionary<string, int> _mappedAtoms = [];

  public List<List<int>> TransformToFormular(Preperation preperation)
  {
    _preperation = preperation;
    if (_preperation.Remainder.Count == 0)
    {
      return [];
    }

    List<List<int>> formular = [];

    int index = 1;
    foreach (var rule in _preperation.Remainder)
    {
      List<int> logicalRule = [];

      formular.Add(logicalRule);
    }

    // TODO transform the whole thing to numbers.

    return formular;
  }

  public List<List<Atom>>? ReTransform(List<List<int>> results)
  {
    if (_preperation == null)
    {
      throw new InvalidOperationException("You have to Transform the data first to retransform it!");
    }

    if (results == null) {
      return null;
    }

    List<List<Atom>> transformed = [];
    List<Atom> alwaysTrue = [];

    foreach (var rule in _preperation.FactuallyTrue)
    {
      if (rule.Head is AtomHead atomHead)
      {
        alwaysTrue.Add(atomHead.Atom);
      }
    }

    if (results.Count == 0)
    {
      return [alwaysTrue];
    }

    foreach (var set in results)
    {
      List<Atom> answers = [.. alwaysTrue];

      // TODO actually remap the findings and retransform the not and remove imaginary classes


      transformed.Add(answers);
    }



    return transformed;
  }
}