namespace Interpreter.Lib.Results;

/*
  Fact with empty body = fact;
  Fact with not empty body = implication;
*/
public class Fact
{
  public string Name { get; set; }
  public List<string> Arguments { get; set; } = [];

  public List<Fact> Body { get; set; } = [];

  public override string ToString()
  {
    string head = Name + "(" + string.Join(",", Arguments) + ")";
    if (Body.Count == 0) {
      return head + ".";
    }

    return head + ":-" + string.Join(",", Body.Select(fact => fact.ToString())) + ".";
  }
}