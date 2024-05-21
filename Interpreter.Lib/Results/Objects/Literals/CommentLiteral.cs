
using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// The comment literal for the explanation method
/// </summary>
/// <param name="vars">The variales which are inside the literal.</param>
/// <param name="strings">The text which should get printed.</param>
public class CommentLiteral : Literal
{
  private List<Variable> vars;
  private List<String> strings;
  
  public List<Variable> Vars
  {
    get { return vars; }
    private set
    {
      vars = value ?? throw new ArgumentNullException(nameof(Vars), "Is not supposed to be null");
    }
  }

  public List<string> Strings
  {
    get
    {
      return strings;
    }
    private set
    {
      strings = value ?? throw new ArgumentNullException(nameof(Strings), "Is not supposed to be null");
    }
  }

  public CommentLiteral(List<Variable> vars, List<string> strings)
  {
    Strings = strings;
    Vars = vars;
  }

  /// <summary>
  /// Returns all the variables of the comment ltieral.
  /// </summary>
  /// <returns>The variables which the comment literal throws.</returns>
  public override List<string> GetVariables()
  {
    List<string> foundVariables = [];
    foreach (var current in Vars)
    {
      foundVariables.Add(current.Name);
    }

    return foundVariables;
  }

  /// <summary>
  /// Will always throw due to not necessary for grounding just for explain mode
  /// </summary>
  /// <param name="substitutions"></param>
  /// <returns></returns>
  /// <exception cref="NotImplementedException"></exception>
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
    return Vars.Count != 0;
  }

  // <summary>
  /// Checks if the object has a specific variable.
  /// </summary>
  /// <param name="variable">The variable to be checked.</param>
  /// <returns>Either if it includes the variable or not.</returns>
  public override bool HasVariables(string variable)
  {
    foreach (var current in Vars)
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
  /// <param name="variables">The variables which shozld get replaced</param>
  /// <returns>A variable less string.</returns>
  public string GetText(List<string> variables)
  {
    var baseString = string.Join(" ", Strings);
    for (int i = 0; i < Vars.Count; i++)
    {
      baseString = baseString.Replace(i.ToString(), "" + variables[i] + "");
    }

    return baseString;
  }

  /// <summary>
  /// Basic to string method.
  /// </summary>
  /// <returns>The string equivalent.</returns>
  public override string ToString()
  {
    var baseString = string.Join(" ", Strings);
    for (int i = 0; i < Vars.Count; i++)
    {
      baseString = baseString.Replace(i.ToString(), "@(" + Vars[i].Name + ")");
    }

    return baseString;
  }

  public override List<Atom> GetLiteralAtoms()
  {
    return [];
  }

  public override void AddToGraph(ILiteralAddToGraph literalAddToGraph)
  {
    return;
  }

  public override T? Accept<T>(LiteralVisitor<T> visitor) where T : default
  {
    return visitor.Visit(this);
  }
}