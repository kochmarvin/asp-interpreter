using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Literals;

namespace Interpreter.Lib.Solver;

public class LoopRule
{
  public List<Atom> Head { get; } = [];
  public List<List<AtomLiteral>> Body { get; } = [];

  public void AddHead(Atom atom)
  {
    if (Head.Any(head => head.ToString() == atom.ToString()))
    {
      return;
    }

    Head.Add(atom);
  }

  public void AddBody(List<AtomLiteral> body)
  {
    Body.Add(body);
  }

  public override string ToString()
  {
    string heads = string.Join(";", Head.Select(atom => atom.ToString()));
    string body = Body.Count == 0 ? "-1" : string.Join(";", Body.Select(innerList => string.Join(",", innerList.Select(atom => atom.Atom.ToString()))));
    return heads + " :- " + body;
  }
}