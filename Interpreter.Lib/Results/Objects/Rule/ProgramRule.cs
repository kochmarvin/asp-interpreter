//-----------------------------------------------------------------------
// <copyright file="ProgramRule.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Results.Objects.Rule;

using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// The full programm rule whith its head and body.
/// </summary>
public class ProgramRule : IApplier<ProgramRule>, IHasVariables
{
  private Head head;
  private List<Body> body;

  /// <summary>
  /// Initializes a new instance of the <see cref="ProgramRule"/> class.
  /// </summary>
  /// <param name="head">The head of the program rule.</param>
  /// <param name="body">The body parts of the program rule.</param>
  public ProgramRule(Head head, List<Body> body)
  {
    this.Head = head;
    this.Body = body;
  }

  /// <summary>
  /// Gets the head of the program rule.
  /// </summary>
  public Head Head
  {
    get
    {
      return this.head;
    }

    private set
    {
      this.head = value ?? throw new ArgumentNullException(nameof(this.Head), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Gets or sets the body parts of the program rule.
  /// </summary>
  public List<Body> Body
  {
    get
    {
      return this.body;
    }

    set
    {
      this.body = value ?? throw new ArgumentNullException(nameof(this.Body), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Applies the substitution to every body of the rule.
  /// </summary>
  /// <param name="substitutions">The found substitutions.</param>
  /// <returns>A new rule instance.</returns>
  public ProgramRule Apply(Dictionary<string, Term> substitutions)
  {
    ArgumentNullException.ThrowIfNull(substitutions, "Is not supposed to be null");

    Head appliedHead = this.Head.Apply(substitutions);
    var appliedBody = new List<Body>();
    foreach (var bodyLiteral in this.Body)
    {
      appliedBody.Add(bodyLiteral.Apply(substitutions));
    }

    return new ProgramRule(appliedHead, appliedBody);
  }

  /// <summary>
  /// Checks if either the head or the body has variables.
  /// </summary>
  /// <returns>If Either Head or body has variables.</returns>
  public bool HasVariables()
  {
    if (this.Head.HasVariables())
    {
      return true;
    }

    foreach (var bodyLiteral in this.Body)
    {
      if (bodyLiteral.HasVariables())
      {
        return true;
      }
    }

    return false;
  }

  /// <summary>
  /// Checks if either head or body have a spcefic variable.
  /// </summary>
  /// <param name="variable">The specific variable you want to check.</param>
  /// <returns>If the varable is either inside the head or body.</returns>
  public bool HasVariables(string variable)
  {
    if (this.Head.HasVariables(variable))
    {
      return true;
    }

    foreach (var bodyLiteral in this.Body)
    {
      if (bodyLiteral.HasVariables(variable))
      {
        return true;
      }
    }

    return false;
  }

  /// <summary>
  /// Checks if the given object is equal with this program rule.
  /// </summary>
  /// <param name="obj">The object to check.</param>
  /// <returns>Whether the object matches this.</returns>
  public override bool Equals(object? obj)
  {
    if (obj == null || this.GetType() != obj.GetType())
    {
      return false;
    }

    ProgramRule p = (ProgramRule)obj;
    return this.ToString() == p.ToString();
  }

  /// <summary>
  /// Gets the hash code of the string of this rule.
  /// </summary>
  /// <returns>The hash code of this.</returns>
  public override int GetHashCode()
  {
    return this.ToString().GetHashCode();
  }

  /// <summary>
  /// Creates a string representation of this program rule.
  /// </summary>
  /// <returns>The string representation of this program rule.</returns>
  public override string ToString()
  {
    var headString = this.Head.ToString();
    if (this.Body.Count > 0)
    {
      var bodyStrings = this.Body.Select(bl => bl.ToString());
      return $"{headString}:- {string.Join(", ", bodyStrings)}.";
    }

    return $"{headString}.".Replace(" ", string.Empty);
  }
}