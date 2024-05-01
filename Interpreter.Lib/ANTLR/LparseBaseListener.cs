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
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="ILparseListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.Diagnostics.DebuggerNonUserCode]
[System.CLSCompliant(false)]
public partial class LparseBaseListener : ILparseListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterProgram([NotNull] LparseParser.ProgramContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitProgram([NotNull] LparseParser.ProgramContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.statements"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStatements([NotNull] LparseParser.StatementsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.statements"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStatements([NotNull] LparseParser.StatementsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.query"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterQuery([NotNull] LparseParser.QueryContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.query"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitQuery([NotNull] LparseParser.QueryContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStatement([NotNull] LparseParser.StatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStatement([NotNull] LparseParser.StatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.bodies"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBodies([NotNull] LparseParser.BodiesContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.bodies"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBodies([NotNull] LparseParser.BodiesContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.head"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterHead([NotNull] LparseParser.HeadContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.head"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitHead([NotNull] LparseParser.HeadContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.body"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBody([NotNull] LparseParser.BodyContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.body"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBody([NotNull] LparseParser.BodyContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.disjunction"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDisjunction([NotNull] LparseParser.DisjunctionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.disjunction"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDisjunction([NotNull] LparseParser.DisjunctionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.range"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRange([NotNull] LparseParser.RangeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.range"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRange([NotNull] LparseParser.RangeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.choice"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterChoice([NotNull] LparseParser.ChoiceContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.choice"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitChoice([NotNull] LparseParser.ChoiceContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.choice_elements"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterChoice_elements([NotNull] LparseParser.Choice_elementsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.choice_elements"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitChoice_elements([NotNull] LparseParser.Choice_elementsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.choice_element"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterChoice_element([NotNull] LparseParser.Choice_elementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.choice_element"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitChoice_element([NotNull] LparseParser.Choice_elementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.naf_literal"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNaf_literal([NotNull] LparseParser.Naf_literalContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.naf_literal"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNaf_literal([NotNull] LparseParser.Naf_literalContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.classical_literal"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterClassical_literal([NotNull] LparseParser.Classical_literalContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.classical_literal"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitClassical_literal([NotNull] LparseParser.Classical_literalContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.range_literal"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRange_literal([NotNull] LparseParser.Range_literalContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.range_literal"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRange_literal([NotNull] LparseParser.Range_literalContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.range_binding"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRange_binding([NotNull] LparseParser.Range_bindingContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.range_binding"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRange_binding([NotNull] LparseParser.Range_bindingContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.range_number"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterRange_number([NotNull] LparseParser.Range_numberContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.range_number"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitRange_number([NotNull] LparseParser.Range_numberContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.builtin_atom"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBuiltin_atom([NotNull] LparseParser.Builtin_atomContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.builtin_atom"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBuiltin_atom([NotNull] LparseParser.Builtin_atomContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.is_operator"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIs_operator([NotNull] LparseParser.Is_operatorContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.is_operator"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIs_operator([NotNull] LparseParser.Is_operatorContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.operand"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterOperand([NotNull] LparseParser.OperandContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.operand"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitOperand([NotNull] LparseParser.OperandContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.binop"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBinop([NotNull] LparseParser.BinopContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.binop"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBinop([NotNull] LparseParser.BinopContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.terms"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTerms([NotNull] LparseParser.TermsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.terms"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTerms([NotNull] LparseParser.TermsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.term"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTerm([NotNull] LparseParser.TermContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.term"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTerm([NotNull] LparseParser.TermContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="LparseParser.arithop"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterArithop([NotNull] LparseParser.ArithopContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="LparseParser.arithop"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitArithop([NotNull] LparseParser.ArithopContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
