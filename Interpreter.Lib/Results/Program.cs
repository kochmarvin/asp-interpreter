namespace Interpreter.Lib.Results;

public class Programm
{
  public List<Fact> Facts { get; set; } = [];

  public override string ToString()
  {
    string program = "";

    foreach(var atom in Facts) {
      program += atom.ToString();
    }

    return program;
  }
}