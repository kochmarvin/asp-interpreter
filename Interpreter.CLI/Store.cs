using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Rule;

namespace Interpreter.CLI;

/// <summary>
/// Basic wrapper class that stores the found answerr sets
/// </summary>
public class Store()
{
  public List<List<Atom>> AnswerSets
  {
    get;
    set;
  } = [];
}