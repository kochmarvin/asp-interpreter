// Generated from /Users/marvinkoch/Desktop/asp-interpreter/Interpreter.Lib/ANTLR/Lparse.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link LparseParser}.
 */
public interface LparseListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link LparseParser#program}.
	 * @param ctx the parse tree
	 */
	void enterProgram(LparseParser.ProgramContext ctx);
	/**
	 * Exit a parse tree produced by {@link LparseParser#program}.
	 * @param ctx the parse tree
	 */
	void exitProgram(LparseParser.ProgramContext ctx);
	/**
	 * Enter a parse tree produced by {@link LparseParser#statements}.
	 * @param ctx the parse tree
	 */
	void enterStatements(LparseParser.StatementsContext ctx);
	/**
	 * Exit a parse tree produced by {@link LparseParser#statements}.
	 * @param ctx the parse tree
	 */
	void exitStatements(LparseParser.StatementsContext ctx);
	/**
	 * Enter a parse tree produced by {@link LparseParser#query}.
	 * @param ctx the parse tree
	 */
	void enterQuery(LparseParser.QueryContext ctx);
	/**
	 * Exit a parse tree produced by {@link LparseParser#query}.
	 * @param ctx the parse tree
	 */
	void exitQuery(LparseParser.QueryContext ctx);
	/**
	 * Enter a parse tree produced by {@link LparseParser#statement}.
	 * @param ctx the parse tree
	 */
	void enterStatement(LparseParser.StatementContext ctx);
	/**
	 * Exit a parse tree produced by {@link LparseParser#statement}.
	 * @param ctx the parse tree
	 */
	void exitStatement(LparseParser.StatementContext ctx);
	/**
	 * Enter a parse tree produced by {@link LparseParser#head}.
	 * @param ctx the parse tree
	 */
	void enterHead(LparseParser.HeadContext ctx);
	/**
	 * Exit a parse tree produced by {@link LparseParser#head}.
	 * @param ctx the parse tree
	 */
	void exitHead(LparseParser.HeadContext ctx);
	/**
	 * Enter a parse tree produced by {@link LparseParser#body}.
	 * @param ctx the parse tree
	 */
	void enterBody(LparseParser.BodyContext ctx);
	/**
	 * Exit a parse tree produced by {@link LparseParser#body}.
	 * @param ctx the parse tree
	 */
	void exitBody(LparseParser.BodyContext ctx);
	/**
	 * Enter a parse tree produced by {@link LparseParser#disjunction}.
	 * @param ctx the parse tree
	 */
	void enterDisjunction(LparseParser.DisjunctionContext ctx);
	/**
	 * Exit a parse tree produced by {@link LparseParser#disjunction}.
	 * @param ctx the parse tree
	 */
	void exitDisjunction(LparseParser.DisjunctionContext ctx);
	/**
	 * Enter a parse tree produced by {@link LparseParser#choice}.
	 * @param ctx the parse tree
	 */
	void enterChoice(LparseParser.ChoiceContext ctx);
	/**
	 * Exit a parse tree produced by {@link LparseParser#choice}.
	 * @param ctx the parse tree
	 */
	void exitChoice(LparseParser.ChoiceContext ctx);
	/**
	 * Enter a parse tree produced by {@link LparseParser#choice_elements}.
	 * @param ctx the parse tree
	 */
	void enterChoice_elements(LparseParser.Choice_elementsContext ctx);
	/**
	 * Exit a parse tree produced by {@link LparseParser#choice_elements}.
	 * @param ctx the parse tree
	 */
	void exitChoice_elements(LparseParser.Choice_elementsContext ctx);
	/**
	 * Enter a parse tree produced by {@link LparseParser#choice_element}.
	 * @param ctx the parse tree
	 */
	void enterChoice_element(LparseParser.Choice_elementContext ctx);
	/**
	 * Exit a parse tree produced by {@link LparseParser#choice_element}.
	 * @param ctx the parse tree
	 */
	void exitChoice_element(LparseParser.Choice_elementContext ctx);
	/**
	 * Enter a parse tree produced by {@link LparseParser#naf_literals}.
	 * @param ctx the parse tree
	 */
	void enterNaf_literals(LparseParser.Naf_literalsContext ctx);
	/**
	 * Exit a parse tree produced by {@link LparseParser#naf_literals}.
	 * @param ctx the parse tree
	 */
	void exitNaf_literals(LparseParser.Naf_literalsContext ctx);
	/**
	 * Enter a parse tree produced by {@link LparseParser#naf_literal}.
	 * @param ctx the parse tree
	 */
	void enterNaf_literal(LparseParser.Naf_literalContext ctx);
	/**
	 * Exit a parse tree produced by {@link LparseParser#naf_literal}.
	 * @param ctx the parse tree
	 */
	void exitNaf_literal(LparseParser.Naf_literalContext ctx);
	/**
	 * Enter a parse tree produced by {@link LparseParser#classical_literal}.
	 * @param ctx the parse tree
	 */
	void enterClassical_literal(LparseParser.Classical_literalContext ctx);
	/**
	 * Exit a parse tree produced by {@link LparseParser#classical_literal}.
	 * @param ctx the parse tree
	 */
	void exitClassical_literal(LparseParser.Classical_literalContext ctx);
	/**
	 * Enter a parse tree produced by {@link LparseParser#builtin_atom}.
	 * @param ctx the parse tree
	 */
	void enterBuiltin_atom(LparseParser.Builtin_atomContext ctx);
	/**
	 * Exit a parse tree produced by {@link LparseParser#builtin_atom}.
	 * @param ctx the parse tree
	 */
	void exitBuiltin_atom(LparseParser.Builtin_atomContext ctx);
	/**
	 * Enter a parse tree produced by {@link LparseParser#binop}.
	 * @param ctx the parse tree
	 */
	void enterBinop(LparseParser.BinopContext ctx);
	/**
	 * Exit a parse tree produced by {@link LparseParser#binop}.
	 * @param ctx the parse tree
	 */
	void exitBinop(LparseParser.BinopContext ctx);
	/**
	 * Enter a parse tree produced by {@link LparseParser#terms}.
	 * @param ctx the parse tree
	 */
	void enterTerms(LparseParser.TermsContext ctx);
	/**
	 * Exit a parse tree produced by {@link LparseParser#terms}.
	 * @param ctx the parse tree
	 */
	void exitTerms(LparseParser.TermsContext ctx);
	/**
	 * Enter a parse tree produced by {@link LparseParser#term}.
	 * @param ctx the parse tree
	 */
	void enterTerm(LparseParser.TermContext ctx);
	/**
	 * Exit a parse tree produced by {@link LparseParser#term}.
	 * @param ctx the parse tree
	 */
	void exitTerm(LparseParser.TermContext ctx);
	/**
	 * Enter a parse tree produced by {@link LparseParser#arithop}.
	 * @param ctx the parse tree
	 */
	void enterArithop(LparseParser.ArithopContext ctx);
	/**
	 * Exit a parse tree produced by {@link LparseParser#arithop}.
	 * @param ctx the parse tree
	 */
	void exitArithop(LparseParser.ArithopContext ctx);
}