namespace Interpreter.Lib.Results;

public class Programm
{
  public List<Atom> Atoms { get; set; }

  public override string ToString()
  {
    string program = "";

    foreach(var atom in Atoms) {
      program += atom.ToString();
    }

    return program;
  }
}