//-----------------------------------------------------------------------
// <copyright file="CommentLiteral.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// The comment literal for the explanation method.
/// </summary>
public class CommentLiteral : Literal
{
  private List<Variable> vars;

  private List<string> strings;

  /// <summary>
  /// Initializes a new instance of the <see cref="CommentLiteral"/> class.
  /// </summary>
  /// <param name="vars">The list of variables of the literal.</param>
  /// <param name="strings">The string representing the literal.</param>
  public CommentLiteral(List<Variable> vars, List<string> strings)
  {
    this.Strings = strings;
    this.Vars = vars;
  }

  /// <summary>
  /// Gets the variables of the comment literal.
  /// </summary>
  public List<Variable> Vars
  {
    get
    {
      return this.vars;
    }

    private set
    {
      this.vars = value ?? throw new ArgumentNullException(nameof(this.Vars), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Gets the comment string of the literal.
  /// </summary>
  public List<string> Strings
  {
    get
    {
      return this.strings;
    }

    private set
    {
      this.strings = value ?? throw new ArgumentNullException(nameof(this.Strings), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Returns all the variables of the comment ltieral.
  /// </summary>
  /// <returns>The variables which the comment literal throws.</returns>
  public override List<string> GetVariables()
  {
    List<string> foundVariables = [];
    foreach (var current in this.Vars)
    {
      foundVariables.Add(current.Name);
    }

    return foundVariables;
  }

  /// <summary>
  /// Will always throw due to not necessary for grounding just for explain mode.
  /// </summary>
  /// <param name="substitutions">The substitutions applied on teh literal.</param>
  /// <returns>Null.</returns>
  /// <exception cref="NotImplementedException">Is thrown always.</exception>
  public override Literal Apply(Dictionary<string, Term> substitutions)
  {
    throw new NotImplementedException();
  }

  /// <summary>
  /// Checks if the object has any varibles.
  /// </summary>
  /// <returns>Either if there are variables or not.</returns>
  public override bool HasVariables()
  {
    return this.Vars.Count != 0;
  }

  /// <summary>
  /// Checks if the object has a specific variable.
  /// </summary>
  /// <param name="variable">The variable to be checked.</param>
  /// <returns>Either if it includes the variable or not.</returns>
  public override bool HasVariables(string variable)
  {
    foreach (var current in this.Vars)
    {
      if (current.Name == variable)
      {
        return true;
      }
    }

    return false;
  }

  /// <summary>
  /// Produces a string which will replace all variables in the string.
  /// </summary>
  /// <param name="variables">The variables which shozld get replaced.</param>
  /// <returns>A variable less string.</returns>
  public string GetText(List<string> variables)
  {
    var baseString = string.Join(" ", this.Strings);
    for (int i = 0; i < this.Vars.Count; i++)
    {
      baseString = baseString.Replace(i.ToString(), string.Empty + variables[i] + string.Empty);
    }

    return baseString;
  }

  /// <summary>
  /// Basic to string method.
  /// </summary>
  /// <returns>The string equivalent.</returns>
  public override string ToString()
  {
    var baseString = string.Join(" ", this.Strings);
    for (int i = 0; i < this.Vars.Count; i++)
    {
      baseString = baseString.Replace(i.ToString(), "@(" + this.Vars[i].Name + ")");
    }

    return baseString;
  }

  /// <summary>
  /// Gets all of the atom of the literal.
  /// </summary>
  /// <returns>An empty list.</returns>
  public override List<Atom> GetLiteralAtoms()
  {
    return [];
  }

  /// <summary>
  /// Add the literal to teh graph.
  /// </summary>
  /// <param name="literalAddToGraph">An interface that adds the literal to teh graph.</param>
  public override void AddToGraph(ILiteralAddToGraph literalAddToGraph)
  {
    return;
  }

  /// <summary>
  /// Accepts an instance of literal visitor and executes it, returning a type of T.
  /// </summary>
  /// <typeparam name="T">The type of the object that is excepted.</typeparam>
  /// <param name="visitor">The visitor that is executed.</param>
  /// <returns>The excepted object of type T.</returns>
  public override T? Accept<T>(LiteralVisitor<T> visitor)
    where T : default
  {
    return visitor.Visit(this);
  }
}