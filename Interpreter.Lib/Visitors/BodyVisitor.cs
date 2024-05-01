using System.Data;
using Interpreter.Lib.Results;
using Interpreter.Lib.Results.Enums;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Terms;
using static LparseParser;

namespace Interpreter.Lib.Visitors;

public class BodyVisitor : LparseBaseVisitor<List<Body>>
{
  public override List<Body> VisitBody(LparseParser.BodyContext context)
  {
    List<Body> literals = [];

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

      if (naf_Literal.is_operator() != null)
      {
        Is_operatorContext cntxt = naf_Literal.is_operator();

        if (cntxt.VARIABLE() == null)
        {
          throw new SyntaxErrorException("Variable for is operation is missing");
        }

        var variable = cntxt.VARIABLE().GetText();
        var arithop = cntxt.arithop().GetText();
        Operator op;

        switch (arithop)
        {
          case "+":
            op = Operator.PLUS;
            break;
          case "-":
            op = Operator.MINUS;
            break;
          case "/":
            op = Operator.DIVIDE;
            break;
          case "*":
            op = Operator.MULTIPLY;
            break;
          default:
            throw new InvalidOperationException("You used a operator that is not valid!");

        }

        List<Term> terms = [];
        foreach (var operand in cntxt.operand())
        {
          if (operand == null)
          {
            throw new SyntaxErrorException("Operand is not allowed to be null");
          }

          if (operand.VARIABLE() != null)
          {
            terms.Add(new Variable(operand.VARIABLE().GetText()));
          }

          if (operand.NUMBER() != null)
          {
            terms.Add(new Number(int.Parse(operand.NUMBER().GetText())));
          }
        }

        literals.Add(new LiteralBody(new IsLiteral(new Variable(variable), terms[0], op, terms[1])));
      }

      if (naf_Literal.builtin_atom() != null)
      {
        Builtin_atomContext btAtom = naf_Literal.builtin_atom();
        var binop = btAtom.binop().GetText();
        Relation relation;

        switch (binop)
        {
          case "==":
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
          case "=":
            relation = Relation.Unification;
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
