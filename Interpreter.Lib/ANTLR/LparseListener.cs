//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /Users/marvinkoch/Desktop/asp-interpreter/Interpreter.Lib/ANTLR/Lparse.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="LparseParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface ILparseListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgram([NotNull] LparseParser.ProgramContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgram([NotNull] LparseParser.ProgramContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.statements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatements([NotNull] LparseParser.StatementsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.statements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatements([NotNull] LparseParser.StatementsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.query"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterQuery([NotNull] LparseParser.QueryContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.query"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitQuery([NotNull] LparseParser.QueryContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] LparseParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] LparseParser.StatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.head"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterHead([NotNull] LparseParser.HeadContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.head"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitHead([NotNull] LparseParser.HeadContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.body"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBody([NotNull] LparseParser.BodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.body"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBody([NotNull] LparseParser.BodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.disjunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDisjunction([NotNull] LparseParser.DisjunctionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.disjunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDisjunction([NotNull] LparseParser.DisjunctionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.choice"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterChoice([NotNull] LparseParser.ChoiceContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.choice"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitChoice([NotNull] LparseParser.ChoiceContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.choice_elements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterChoice_elements([NotNull] LparseParser.Choice_elementsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.choice_elements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitChoice_elements([NotNull] LparseParser.Choice_elementsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.choice_element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterChoice_element([NotNull] LparseParser.Choice_elementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.choice_element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitChoice_element([NotNull] LparseParser.Choice_elementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.naf_literals"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNaf_literals([NotNull] LparseParser.Naf_literalsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.naf_literals"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNaf_literals([NotNull] LparseParser.Naf_literalsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.naf_literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNaf_literal([NotNull] LparseParser.Naf_literalContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.naf_literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNaf_literal([NotNull] LparseParser.Naf_literalContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.classical_literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterClassical_literal([NotNull] LparseParser.Classical_literalContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.classical_literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitClassical_literal([NotNull] LparseParser.Classical_literalContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.builtin_atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBuiltin_atom([NotNull] LparseParser.Builtin_atomContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.builtin_atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBuiltin_atom([NotNull] LparseParser.Builtin_atomContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.binop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBinop([NotNull] LparseParser.BinopContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.binop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBinop([NotNull] LparseParser.BinopContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.terms"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTerms([NotNull] LparseParser.TermsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.terms"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTerms([NotNull] LparseParser.TermsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTerm([NotNull] LparseParser.TermContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTerm([NotNull] LparseParser.TermContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.arithop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArithop([NotNull] LparseParser.ArithopContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.arithop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArithop([NotNull] LparseParser.ArithopContext context);
}
