using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Terms;

public class ParseAtomHeadVisitor : HeadVisitor<AtomHead>
{
  public override AtomHead Visit(AtomHead atomHead)
  {
    ArgumentNullException.ThrowIfNull(atomHead, "Is not supposed to be null");

    return atomHead;
  }
}