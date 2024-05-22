using System.Data;
using Interpreter.Lib.Results;
using Interpreter.Lib.Results.Enums;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Terms;
using static LparseParser;

namespace Interpreter.Lib.Visitors;

/// <summary>
/// Implementation of the body visitor.
/// </summary>
public class BodyVisitor : LparseBaseVisitor<List<Body>>
{
  /// <summary>
  /// Parses bodies from its context.
  /// </summary>
  /// <param name="context">The context which should get parsed.</param>
  /// <returns></returns>
  /// <exception cref="SyntaxErrorException">If there are missing things which are necessary.</exception>
  /// <exception cref="InvalidOperationException">If an operation got used which is not allowed.</exception>
  public override List<Body> VisitBody(LparseParser.BodyContext context)
  {
    List<Body> literals = [];

    // Iterate through each naf literal
    foreach (Naf_literalContext naf_Literal in context.naf_literal())
    {
      // if it is a classical literal we parse the atom
      if (naf_Literal.classical_literal() != null)
      {
        Classical_literalContext classic = naf_Literal.classical_literal();
        string name = classic.ID().GetText();

        // If there is a minus context we add a "-" meant to be a classical negation
        name = classic.MINUS() != null ? "-" + name : name;

        List<Term> terms = [];
        // If there are terms parse those and add it to the arguments
        if (classic.terms() != null)
        {
          terms = new TermsVisitor().Visit(classic.terms());
        }

        // add the litaral and check if there is a naf context meaning it has a not in front of it
        literals.Add(new LiteralBody(new AtomLiteral(naf_Literal.NAF() == null, new Atom(name, terms))));
      }

      // Parse the is operator if there is one
      if (naf_Literal.is_operator() != null)
      {
        Is_operatorContext cntxt = naf_Literal.is_operator();

        // Check if there is a variable which will get the value of the is operator
        if (cntxt.VARIABLE() == null)
        {
          throw new SyntaxErrorException("Variable for is operation is missing");
        }

        var variable = cntxt.VARIABLE().GetText();
        var arithop = cntxt.arithop().GetText();

        // Check which operation is used
        var op = arithop switch
        {
          "+" => Operator.PLUS,
          "-" => Operator.MINUS,
          "/" => Operator.DIVIDE,
          "*" => Operator.MULTIPLY,
          _ => throw new InvalidOperationException("You used a operator that is not valid!"),
        };

        List<Term> terms = [];

        // parse the left and the right side
        foreach (var operand in cntxt.operand())
        {
          // if operand is missing there has to be an error
          if (operand == null)
          {
            throw new SyntaxErrorException("Operand is not allowed to be null");
          }

          // If it is a variable add it to the terms
          if (operand.VARIABLE() != null)
          {
            terms.Add(new Variable(operand.VARIABLE().GetText()));
          }

          // if it is a number add it to the  terms
          if (operand.NUMBER() != null)
          {
            terms.Add(new Number(int.Parse(operand.NUMBER().GetText())));
          }
        }

        // Add the new is literal to the body
        literals.Add(new LiteralBody(new IsLiteral(new Variable(variable), terms[0], op, terms[1])));
      }

      // Check if it is a comparrison or a unification
      if (naf_Literal.builtin_atom() != null)
      {
        Builtin_atomContext btAtom = naf_Literal.builtin_atom();
        var binop = btAtom.binop().GetText();

        // check which relation they have and parse it
        var relation = binop switch
        {
          "==" => Relation.Equal,
          "!=" or "<>" => Relation.Inequal,
          ">=" => Relation.GreaterEqual,
          ">" => Relation.GreaterThan,
          "<" => Relation.LessThan,
          "<=" => Relation.LessEqual,
          "=" => Relation.Unification,
          _ => throw new InvalidOperationException("You used a operator that is not valid!"),
        };

        // Parse the left and right side of the comparrison
        Term left = new TermVisitor().Visit(btAtom.term()[0]);
        Term right = new TermVisitor().Visit(btAtom.term()[1]);

        // Add the new literal to the body
        literals.Add(new LiteralBody(new ComparisonLiteral(left, relation, right)));
      }
    }

    return literals;
  }
}
