//-----------------------------------------------------------------------
// <copyright file="LoopRule.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Solver;

using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Literals;

/// <summary>
/// The structure of a Loop rule.
/// </summary>
public class LoopRule
{
  /// <summary>
  /// Gets or sets the head atoms of the loop rule.
  /// </summary>
  public List<Atom> Head { get; set; } = [];

  /// <summary>
  /// Gets or sets the body literals of the loop rule.
  /// </summary>
  public List<List<AtomLiteral>> Body { get; set; } = [];

  /// <summary>
  /// Adds a head if the head is not already in it.
  /// </summary>
  /// <param name="atom">The head which should get added.</param>
  public void AddHead(Atom atom)
  {
    if (this.Head.Any(head => head.ToString() == atom.ToString()))
    {
      return;
    }

    this.Head.Add(atom);
  }

  /// <summary>
  /// Just adds a body which is external support.
  /// </summary>
  /// <param name="body">The body which should get added.</param>
  public void AddBody(List<AtomLiteral> body)
  {
    this.Body.Add(body);
  }

  /// <summary>
  /// Basic to string method to print out the loop rule.
  /// </summary>
  /// <returns>The corresponding string of the loop rule.</returns>
  public override string ToString()
  {
    string heads = string.Join(";", this.Head.Select(atom => atom.ToString()));
    string body = this.Body.Count == 0 ? "-1" : string.Join(";", this.Body.Select(innerList => string.Join(",", innerList.Select(atom => atom.Atom.ToString()))));
    return heads + " :- " + body;
  }
}