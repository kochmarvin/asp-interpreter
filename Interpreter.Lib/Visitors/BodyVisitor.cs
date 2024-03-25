using Interpreter.Lib.Results;
using Interpreter.Lib.Results.Enums;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Terms;
using static LparseParser;

public class BodyVisitor : LparseBaseVisitor<List<BodyLiteral>>
{
  public override List<BodyLiteral> VisitBody(LparseParser.BodyContext context)
  {
    List<BodyLiteral> literals = [];

    foreach (Naf_literalContext naf_Literal in context.naf_literal())
    {
      if (naf_Literal.classical_literal() != null)
      {
        Classical_literalContext classic = naf_Literal.classical_literal();
        string name = classic.ID().GetText();
        name = classic.MINUS() != null ? "-" + name : name;

        List<Term> terms = [];
        if (classic.terms() != null)
        {
          terms = new TermsVisitor().Visit(classic.terms());
        }

        literals.Add(new LiteralBody(new AtomLiteral(naf_Literal.NAF() == null, new Atom(name, terms))));
      }

      if (naf_Literal.builtin_atom() != null)
      {
        Builtin_atomContext btAtom = naf_Literal.builtin_atom();
        var binop = btAtom.binop().GetText();
        Relation relation;

        switch (binop)
        {
          case "=":
            relation = Relation.Equal;
            break;
          case "!=":
          case "<>":
            relation = Relation.Inequal;
            break;
          case ">=":
            relation = Relation.GreaterEqual;
            break;
          case ">":
            relation = Relation.GreaterThan;
            break;
          case "<":
            relation = Relation.LessThan;
            break;
          case "<=":
            relation = Relation.LessEqual;
            break;
          default:
            throw new InvalidOperationException("You used a operator that is not valid!");
        }

        Term left = new TermVisitor().Visit(btAtom.term()[0]);
        Term right = new TermVisitor().Visit(btAtom.term()[1]);

        literals.Add(new LiteralBody(new ComparisonLiteral(left, relation, right)));
      }
    }

    return literals;
  }
}
