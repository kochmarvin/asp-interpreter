//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Lparse.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="LparseParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface ILparseVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProgram([NotNull] LparseParser.ProgramContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.statements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatements([NotNull] LparseParser.StatementsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.query"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitQuery([NotNull] LparseParser.QueryContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] LparseParser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.head"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHead([NotNull] LparseParser.HeadContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.body"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBody([NotNull] LparseParser.BodyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.disjunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDisjunction([NotNull] LparseParser.DisjunctionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.range"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRange([NotNull] LparseParser.RangeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.choice"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitChoice([NotNull] LparseParser.ChoiceContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.choice_elements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitChoice_elements([NotNull] LparseParser.Choice_elementsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.choice_element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitChoice_element([NotNull] LparseParser.Choice_elementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.naf_literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNaf_literal([NotNull] LparseParser.Naf_literalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.classical_literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassical_literal([NotNull] LparseParser.Classical_literalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.range_literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRange_literal([NotNull] LparseParser.Range_literalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.range_binding"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRange_binding([NotNull] LparseParser.Range_bindingContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.range_number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRange_number([NotNull] LparseParser.Range_numberContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.builtin_atom"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBuiltin_atom([NotNull] LparseParser.Builtin_atomContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.binop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBinop([NotNull] LparseParser.BinopContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.terms"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTerms([NotNull] LparseParser.TermsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTerm([NotNull] LparseParser.TermContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="LparseParser.arithop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArithop([NotNull] LparseParser.ArithopContext context);
}
