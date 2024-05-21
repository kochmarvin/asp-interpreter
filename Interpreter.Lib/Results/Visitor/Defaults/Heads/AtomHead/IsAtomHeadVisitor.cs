using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Terms;

public class IsAtomHeadVisitor : HeadVisitor<bool>
{
  public override bool Visit(AtomHead atomHead)
  {
    ArgumentNullException.ThrowIfNull(atomHead, "Is not supposed to be null");

    return true;
  }
}