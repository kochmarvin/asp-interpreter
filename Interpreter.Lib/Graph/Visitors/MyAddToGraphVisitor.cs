using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;

public class MyAddToGraphVisitor : AddToGraphVisitor
{
  public MyAddToGraphVisitor()
  {
  }
  
  public MyAddToGraphVisitor(ProgramRule rule, Action<ProgramRule, Atom> action, bool onlyPositves) : base(rule, action, onlyPositves)
  {
  }

  public override AddToGraphVisitor CreateInstance(ProgramRule rule, Action<ProgramRule, Atom> action, bool onlyPositves)
  {
    return new MyAddToGraphVisitor(rule, action, onlyPositves);
  }

  public override void AddToGraph(AtomLiteral atomLiteral)
  {
    if (atomLiteral.Positive || !OnlyPositives)
    {
      Action(Rule, atomLiteral.Atom);
    }
  }

  public override void AddToGraph(LiteralBody literalBody)
  {
    literalBody.Literal.AddToGraph(this);
  }
}