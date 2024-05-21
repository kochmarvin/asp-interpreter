using Interpreter.Lib.Results.Interfaces;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;

public abstract class AddToGraphVisitor : IAddToGraphVisitor
{
  private Action<ProgramRule, Atom> action;
  private ProgramRule rule;
  public bool OnlyPositives { get; private set; }
  public Action<ProgramRule, Atom> Action
  {
    get { return action; }
    private set
    {
      action = value ?? throw new ArgumentNullException(nameof(action) + "Is not supposed to be null");
    }
  }

  public ProgramRule Rule
  {
    get
    {
      return rule;
    }

    private set
    {
      rule = value ?? throw new ArgumentNullException(nameof(rule) + "Is not supposed to be null");
    }
  }

  public AddToGraphVisitor()
  {
  }

  public AddToGraphVisitor(ProgramRule rule, Action<ProgramRule, Atom> action, bool onlyPositves)
  {
    Rule = rule;
    Action = action;
    OnlyPositives = onlyPositves;
  }

  public abstract AddToGraphVisitor CreateInstance(ProgramRule rule, Action<ProgramRule, Atom> action, bool onlyPositves);

  public abstract void AddToGraph(AtomLiteral atomLiteral);

  public abstract void AddToGraph(LiteralBody literalBody);
}