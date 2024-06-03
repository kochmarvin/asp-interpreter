//-----------------------------------------------------------------------
// <copyright file="LiteralBody.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Objects.BodyLiterals;

using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// Represents the body containing a literal of the program rule.
/// </summary>
public class LiteralBody : Body
{
  private Literal literal;

  /// <summary>
  /// Initializes a new instance of the <see cref="LiteralBody"/> class.
  /// </summary>
  /// <param name="literal">The literal that is contained in the body.</param>
  public LiteralBody(Literal literal)
  {
    this.Literal = literal;
  }

  /// <summary>
  /// Gets the Literal of the literal body.
  /// </summary>
  public Literal Literal
  {
    get
    {
      return this.literal;
    }

    private set
    {
      this.literal = value ?? throw new ArgumentNullException(nameof(this.Literal), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Adds the literal body to the graph using the body add to graph interface.
  /// </summary>
  /// <param name="addToGraphVisitor">The interface used to add the body to the graph.</param>
  public override void AddToGraph(IBodyAddToGraph addToGraphVisitor)
  {
    ArgumentNullException.ThrowIfNull(addToGraphVisitor, "Is not supposed to be null");

    addToGraphVisitor.AddToGraph(this);
  }

  /// <summary>
  /// Applies the given substitutions on this literal body.
  /// </summary>
  /// <param name="substitutions">The substitutions that are being applied.</param>
  /// <returns>A new applied literal body.</returns>
  public override Body Apply(Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    Literal appliedLiteral = this.Literal.Apply(substitutions);
    return new LiteralBody(appliedLiteral);
  }

  /// <summary>
  /// Gets all of the variables of this literal body.
  /// </summary>
  /// <returns>A list of all of the variables.</returns>
  public override List<string> GetVariables()
  {
    return this.Literal.GetVariables();
  }

  /// <summary>
  /// Checks whether the literal body has any variables.
  /// </summary>
  /// <returns>Whether the literal body has any variables.</returns>
  public override bool HasVariables()
  {
    return this.Literal.HasVariables();
  }

  /// <summary>
  /// Checks whether the literal body has a specific variable.
  /// </summary>
  /// <param name="variable">The variable that is to be checked.</param>
  /// <returns>Whether the variable is contained in the body.</returns>
  public override bool HasVariables(string variable)
  {
    return this.Literal.HasVariables(variable);
  }

  /// <summary>
  /// Converts the literal body into a string.
  /// </summary>
  /// <returns>The converted string representing the literal body.</returns>
  public override string? ToString()
  {
    return this.Literal.ToString();
  }

  /// <summary>
  /// Gets all of the atom of the literal body.
  /// </summary>
  /// <returns>A list of all of the atoms contained in the body.</returns>
  public override List<Atom> GetBodyAtoms()
  {
    return this.Literal.GetLiteralAtoms();
  }

  /// <summary>
  /// Accepts an instance of literal visitor and executes it on this body, returning a type of T.
  /// </summary>
  /// <typeparam name="T">The type of the object taht is accepted.</typeparam>
  /// <param name="visitor">The visitor that is executed.</param>
  /// <returns>The excepted object of type T.</returns>
  public override T? Accept<T>(LiteralVisitor<T> visitor)
    where T : default
  {
    return visitor.Visit(this);
  }
}