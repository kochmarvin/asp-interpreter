namespace Interpreter.Lib.Results;

public class Atom
{
  public string Name { get; set; }
  public List<string> Arguments { get; set; }

  public override string ToString()
  {
    return Name + "().";
  }
}