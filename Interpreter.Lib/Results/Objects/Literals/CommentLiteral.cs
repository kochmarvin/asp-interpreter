
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Terms;

/// <summary>
/// The comment literal for the explanation method
/// </summary>
/// <param name="vars">The variales which are inside the literal.</param>
/// <param name="strings">The text which should get printed.</param>
public class CommentLiteral(List<Variable> vars, List<string> strings) : Literal
{
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
  /// Returns all the variables of the comment ltieral.
  /// </summary>
  /// <returns>The variables which the comment literal throws.</returns>
  public override List<string> GetVariables()
  {
    List<string> foundVariables = [];
    foreach (var current in vars)
    {
      foundVariables.Add(current.Name);
    }

    return foundVariables;
  }

  /// <summary>
  /// Checks if the object has any varibles.
  /// </summary>
  /// <returns>Either if there are variables or not.</returns>
  public override bool HasVariables()
  {
    return vars.Count != 0;
  }

  // <summary>
  /// Checks if the object has a specific variable.
  /// </summary>
  /// <param name="variable">The variable to be checked.</param>
  /// <returns>Either if it includes the variable or not.</returns>
  public override bool HasVariables(string variable)
  {
    foreach (var current in vars)
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
    var baseString = string.Join(" ", strings);
    for (int i = 0; i < vars.Count; i++)
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
    var baseString = string.Join(" ", strings);
    for (int i = 0; i < vars.Count; i++)
    {
      baseString = baseString.Replace(i.ToString(), "@(" + vars[i].Name + ")");
    }

    return baseString;
  }
}