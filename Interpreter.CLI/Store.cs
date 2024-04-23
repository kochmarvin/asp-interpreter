using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Rule;

namespace Interpreter.CLI;

public class Store()
{
  public List<List<Atom>> AnswerSets
  {
    get;
    set;
  } = [];
}