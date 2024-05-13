using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Literals;

namespace Interpreter.Lib.Solver;

/// <summary>
/// Structure of a Loop rule
/// </summary>
public class LoopRule
{
  public List<Atom> Head { get; } = [];
  public List<List<AtomLiteral>> Body { get; } = [];

  /// <summary>
  /// Adds a head if the head is not already in it.
  /// </summary>
  /// <param name="atom">The head which should get added</param>
  public void AddHead(Atom atom)
  {
    if (Head.Any(head => head.ToString() == atom.ToString()))
    {
      return;
    }

    Head.Add(atom);
  }

  /// <summary>
  /// Just adds a body which is external support.
  /// </summary>
  /// <param name="body">The body which should get added.</param>
  public void AddBody(List<AtomLiteral> body)
  {
    Body.Add(body);
  }

  /// <summary>
  /// Basic to string method to print out the loop rule
  /// </summary>
  /// <returns>The corresponding string of the loop rule</returns>
  public override string ToString()
  {
    string heads = string.Join(";", Head.Select(atom => atom.ToString()));
    string body = Body.Count == 0 ? "-1" : string.Join(";", Body.Select(innerList => string.Join(",", innerList.Select(atom => atom.Atom.ToString()))));
    return heads + " :- " + body;
  }
}