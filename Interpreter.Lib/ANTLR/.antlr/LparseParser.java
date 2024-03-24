// Generated from /Users/marvinkoch/Desktop/Desktop - Marvin’s MacBook Pro/asp-interpreter/Interpreter.Lib/ANTLR/Lparse.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast", "CheckReturnValue"})
public class LparseParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.13.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		NAF=1, NUMBER=2, ID=3, VARIABLE=4, ANONYMOUS_VARIABLE=5, DOT=6, COMMA=7, 
		QUERY_MARK=8, COLON=9, SEMICOLON=10, OR=11, CONS=12, PLUS=13, MINUS=14, 
		TIMES=15, DIV=16, AT=17, PAREN_OPEN=18, PAREN_CLOSE=19, SQUARE_OPEN=20, 
		SQUARE_CLOSE=21, CURLY_OPEN=22, CURLY_CLOSE=23, EQUAL=24, UNEQUAL=25, 
		LESS=26, GREATER=27, LESS_OR_EQ=28, GREATER_OR_EQ=29, COMMENT=30, WS=31;
	public static final int
		RULE_program = 0, RULE_statements = 1, RULE_query = 2, RULE_statement = 3, 
		RULE_head = 4, RULE_body = 5, RULE_disjunction = 6, RULE_choice = 7, RULE_choice_elements = 8, 
		RULE_choice_element = 9, RULE_aggregate = 10, RULE_aggregate_elements = 11, 
		RULE_aggregate_element = 12, RULE_naf_literals = 13, RULE_naf_literal = 14, 
		RULE_classical_literal = 15, RULE_builtin_atom = 16, RULE_binop = 17, 
		RULE_terms = 18, RULE_term = 19, RULE_arithop = 20;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "statements", "query", "statement", "head", "body", "disjunction", 
			"choice", "choice_elements", "choice_element", "aggregate", "aggregate_elements", 
			"aggregate_element", "naf_literals", "naf_literal", "classical_literal", 
			"builtin_atom", "binop", "terms", "term", "arithop"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'not'", null, null, null, "'_'", "'.'", "','", "'?'", "':'", "';'", 
			"'|'", "':-'", "'+'", "'-'", "'*'", "'/'", "'@'", "'('", "')'", "'['", 
			"']'", "'{'", "'}'", "'='", null, "'<'", "'>'", "'<='", "'>='"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "NAF", "NUMBER", "ID", "VARIABLE", "ANONYMOUS_VARIABLE", "DOT", 
			"COMMA", "QUERY_MARK", "COLON", "SEMICOLON", "OR", "CONS", "PLUS", "MINUS", 
			"TIMES", "DIV", "AT", "PAREN_OPEN", "PAREN_CLOSE", "SQUARE_OPEN", "SQUARE_CLOSE", 
			"CURLY_OPEN", "CURLY_CLOSE", "EQUAL", "UNEQUAL", "LESS", "GREATER", "LESS_OR_EQ", 
			"GREATER_OR_EQ", "COMMENT", "WS"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "Lparse.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public LparseParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ProgramContext extends ParserRuleContext {
		public StatementsContext statements() {
			return getRuleContext(StatementsContext.class,0);
		}
		public QueryContext query() {
			return getRuleContext(QueryContext.class,0);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_program; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterProgram(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitProgram(this);
		}
	}

	public final ProgramContext program() throws RecognitionException {
		ProgramContext _localctx = new ProgramContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			setState(47);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(42);
				statements();
				setState(44);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ID || _la==MINUS) {
					{
					setState(43);
					query();
					}
				}

				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(46);
				query();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class StatementsContext extends ParserRuleContext {
		public List<StatementContext> statement() {
			return getRuleContexts(StatementContext.class);
		}
		public StatementContext statement(int i) {
			return getRuleContext(StatementContext.class,i);
		}
		public StatementsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statements; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterStatements(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitStatements(this);
		}
	}

	public final StatementsContext statements() throws RecognitionException {
		StatementsContext _localctx = new StatementsContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_statements);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(49);
			statement();
			setState(53);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,2,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(50);
					statement();
					}
					} 
				}
				setState(55);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,2,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class QueryContext extends ParserRuleContext {
		public Classical_literalContext classical_literal() {
			return getRuleContext(Classical_literalContext.class,0);
		}
		public TerminalNode QUERY_MARK() { return getToken(LparseParser.QUERY_MARK, 0); }
		public QueryContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_query; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterQuery(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitQuery(this);
		}
	}

	public final QueryContext query() throws RecognitionException {
		QueryContext _localctx = new QueryContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_query);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(56);
			classical_literal();
			setState(57);
			match(QUERY_MARK);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class StatementContext extends ParserRuleContext {
		public TerminalNode CONS() { return getToken(LparseParser.CONS, 0); }
		public TerminalNode DOT() { return getToken(LparseParser.DOT, 0); }
		public BodyContext body() {
			return getRuleContext(BodyContext.class,0);
		}
		public HeadContext head() {
			return getRuleContext(HeadContext.class,0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_statement; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterStatement(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitStatement(this);
		}
	}

	public final StatementContext statement() throws RecognitionException {
		StatementContext _localctx = new StatementContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_statement);
		int _la;
		try {
			setState(73);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case CONS:
				enterOuterAlt(_localctx, 1);
				{
				setState(59);
				match(CONS);
				setState(61);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 4472894L) != 0)) {
					{
					setState(60);
					body();
					}
				}

				setState(63);
				match(DOT);
				}
				break;
			case NUMBER:
			case ID:
			case VARIABLE:
			case ANONYMOUS_VARIABLE:
			case MINUS:
			case PAREN_OPEN:
			case CURLY_OPEN:
				enterOuterAlt(_localctx, 2);
				{
				setState(64);
				head();
				setState(66);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==CONS) {
					{
					setState(65);
					match(CONS);
					}
				}

				setState(69);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 4472894L) != 0)) {
					{
					setState(68);
					body();
					}
				}

				setState(71);
				match(DOT);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class HeadContext extends ParserRuleContext {
		public DisjunctionContext disjunction() {
			return getRuleContext(DisjunctionContext.class,0);
		}
		public ChoiceContext choice() {
			return getRuleContext(ChoiceContext.class,0);
		}
		public HeadContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_head; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterHead(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitHead(this);
		}
	}

	public final HeadContext head() throws RecognitionException {
		HeadContext _localctx = new HeadContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_head);
		try {
			setState(77);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,7,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(75);
				disjunction();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(76);
				choice();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class BodyContext extends ParserRuleContext {
		public List<Naf_literalContext> naf_literal() {
			return getRuleContexts(Naf_literalContext.class);
		}
		public Naf_literalContext naf_literal(int i) {
			return getRuleContext(Naf_literalContext.class,i);
		}
		public List<AggregateContext> aggregate() {
			return getRuleContexts(AggregateContext.class);
		}
		public AggregateContext aggregate(int i) {
			return getRuleContext(AggregateContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(LparseParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(LparseParser.COMMA, i);
		}
		public List<TerminalNode> NAF() { return getTokens(LparseParser.NAF); }
		public TerminalNode NAF(int i) {
			return getToken(LparseParser.NAF, i);
		}
		public BodyContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_body; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterBody(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitBody(this);
		}
	}

	public final BodyContext body() throws RecognitionException {
		BodyContext _localctx = new BodyContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_body);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(84);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,9,_ctx) ) {
			case 1:
				{
				setState(79);
				naf_literal();
				}
				break;
			case 2:
				{
				setState(81);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==NAF) {
					{
					setState(80);
					match(NAF);
					}
				}

				setState(83);
				aggregate();
				}
				break;
			}
			setState(96);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(86);
				match(COMMA);
				setState(92);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,11,_ctx) ) {
				case 1:
					{
					setState(87);
					naf_literal();
					}
					break;
				case 2:
					{
					setState(89);
					_errHandler.sync(this);
					_la = _input.LA(1);
					if (_la==NAF) {
						{
						setState(88);
						match(NAF);
						}
					}

					setState(91);
					aggregate();
					}
					break;
				}
				}
				}
				setState(98);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class DisjunctionContext extends ParserRuleContext {
		public List<Classical_literalContext> classical_literal() {
			return getRuleContexts(Classical_literalContext.class);
		}
		public Classical_literalContext classical_literal(int i) {
			return getRuleContext(Classical_literalContext.class,i);
		}
		public List<TerminalNode> OR() { return getTokens(LparseParser.OR); }
		public TerminalNode OR(int i) {
			return getToken(LparseParser.OR, i);
		}
		public DisjunctionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_disjunction; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterDisjunction(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitDisjunction(this);
		}
	}

	public final DisjunctionContext disjunction() throws RecognitionException {
		DisjunctionContext _localctx = new DisjunctionContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_disjunction);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(99);
			classical_literal();
			setState(104);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==OR) {
				{
				{
				setState(100);
				match(OR);
				setState(101);
				classical_literal();
				}
				}
				setState(106);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ChoiceContext extends ParserRuleContext {
		public TerminalNode CURLY_OPEN() { return getToken(LparseParser.CURLY_OPEN, 0); }
		public TerminalNode CURLY_CLOSE() { return getToken(LparseParser.CURLY_CLOSE, 0); }
		public List<TermContext> term() {
			return getRuleContexts(TermContext.class);
		}
		public TermContext term(int i) {
			return getRuleContext(TermContext.class,i);
		}
		public List<BinopContext> binop() {
			return getRuleContexts(BinopContext.class);
		}
		public BinopContext binop(int i) {
			return getRuleContext(BinopContext.class,i);
		}
		public Choice_elementsContext choice_elements() {
			return getRuleContext(Choice_elementsContext.class,0);
		}
		public ChoiceContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_choice; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterChoice(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitChoice(this);
		}
	}

	public final ChoiceContext choice() throws RecognitionException {
		ChoiceContext _localctx = new ChoiceContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_choice);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(110);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 278588L) != 0)) {
				{
				setState(107);
				term(0);
				setState(108);
				binop();
				}
			}

			setState(112);
			match(CURLY_OPEN);
			setState(114);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ID || _la==MINUS) {
				{
				setState(113);
				choice_elements();
				}
			}

			setState(116);
			match(CURLY_CLOSE);
			setState(120);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 1056964608L) != 0)) {
				{
				setState(117);
				binop();
				setState(118);
				term(0);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Choice_elementsContext extends ParserRuleContext {
		public List<Choice_elementContext> choice_element() {
			return getRuleContexts(Choice_elementContext.class);
		}
		public Choice_elementContext choice_element(int i) {
			return getRuleContext(Choice_elementContext.class,i);
		}
		public List<TerminalNode> SEMICOLON() { return getTokens(LparseParser.SEMICOLON); }
		public TerminalNode SEMICOLON(int i) {
			return getToken(LparseParser.SEMICOLON, i);
		}
		public Choice_elementsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_choice_elements; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterChoice_elements(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitChoice_elements(this);
		}
	}

	public final Choice_elementsContext choice_elements() throws RecognitionException {
		Choice_elementsContext _localctx = new Choice_elementsContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_choice_elements);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(122);
			choice_element();
			setState(127);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==SEMICOLON) {
				{
				{
				setState(123);
				match(SEMICOLON);
				setState(124);
				choice_element();
				}
				}
				setState(129);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Choice_elementContext extends ParserRuleContext {
		public Classical_literalContext classical_literal() {
			return getRuleContext(Classical_literalContext.class,0);
		}
		public TerminalNode COLON() { return getToken(LparseParser.COLON, 0); }
		public Naf_literalsContext naf_literals() {
			return getRuleContext(Naf_literalsContext.class,0);
		}
		public Choice_elementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_choice_element; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterChoice_element(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitChoice_element(this);
		}
	}

	public final Choice_elementContext choice_element() throws RecognitionException {
		Choice_elementContext _localctx = new Choice_elementContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_choice_element);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(130);
			classical_literal();
			setState(133);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COLON) {
				{
				setState(131);
				match(COLON);
				setState(132);
				naf_literals();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class AggregateContext extends ParserRuleContext {
		public TerminalNode CURLY_OPEN() { return getToken(LparseParser.CURLY_OPEN, 0); }
		public Aggregate_elementsContext aggregate_elements() {
			return getRuleContext(Aggregate_elementsContext.class,0);
		}
		public TerminalNode CURLY_CLOSE() { return getToken(LparseParser.CURLY_CLOSE, 0); }
		public List<TermContext> term() {
			return getRuleContexts(TermContext.class);
		}
		public TermContext term(int i) {
			return getRuleContext(TermContext.class,i);
		}
		public List<BinopContext> binop() {
			return getRuleContexts(BinopContext.class);
		}
		public BinopContext binop(int i) {
			return getRuleContext(BinopContext.class,i);
		}
		public AggregateContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_aggregate; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterAggregate(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitAggregate(this);
		}
	}

	public final AggregateContext aggregate() throws RecognitionException {
		AggregateContext _localctx = new AggregateContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_aggregate);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(138);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 278588L) != 0)) {
				{
				setState(135);
				term(0);
				setState(136);
				binop();
				}
			}

			setState(140);
			match(CURLY_OPEN);
			setState(141);
			aggregate_elements();
			setState(142);
			match(CURLY_CLOSE);
			setState(146);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 1056964608L) != 0)) {
				{
				setState(143);
				binop();
				setState(144);
				term(0);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Aggregate_elementsContext extends ParserRuleContext {
		public List<Aggregate_elementContext> aggregate_element() {
			return getRuleContexts(Aggregate_elementContext.class);
		}
		public Aggregate_elementContext aggregate_element(int i) {
			return getRuleContext(Aggregate_elementContext.class,i);
		}
		public List<TerminalNode> SEMICOLON() { return getTokens(LparseParser.SEMICOLON); }
		public TerminalNode SEMICOLON(int i) {
			return getToken(LparseParser.SEMICOLON, i);
		}
		public Aggregate_elementsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_aggregate_elements; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterAggregate_elements(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitAggregate_elements(this);
		}
	}

	public final Aggregate_elementsContext aggregate_elements() throws RecognitionException {
		Aggregate_elementsContext _localctx = new Aggregate_elementsContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_aggregate_elements);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(148);
			aggregate_element();
			setState(153);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==SEMICOLON) {
				{
				{
				setState(149);
				match(SEMICOLON);
				setState(150);
				aggregate_element();
				}
				}
				setState(155);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Aggregate_elementContext extends ParserRuleContext {
		public TermsContext terms() {
			return getRuleContext(TermsContext.class,0);
		}
		public TerminalNode COLON() { return getToken(LparseParser.COLON, 0); }
		public Naf_literalsContext naf_literals() {
			return getRuleContext(Naf_literalsContext.class,0);
		}
		public Aggregate_elementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_aggregate_element; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterAggregate_element(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitAggregate_element(this);
		}
	}

	public final Aggregate_elementContext aggregate_element() throws RecognitionException {
		Aggregate_elementContext _localctx = new Aggregate_elementContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_aggregate_element);
		try {
			setState(163);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,22,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(156);
				terms();
				setState(157);
				match(COLON);
				setState(158);
				naf_literals();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(160);
				terms();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(161);
				match(COLON);
				setState(162);
				naf_literals();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Naf_literalsContext extends ParserRuleContext {
		public List<Naf_literalContext> naf_literal() {
			return getRuleContexts(Naf_literalContext.class);
		}
		public Naf_literalContext naf_literal(int i) {
			return getRuleContext(Naf_literalContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(LparseParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(LparseParser.COMMA, i);
		}
		public Naf_literalsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_naf_literals; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterNaf_literals(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitNaf_literals(this);
		}
	}

	public final Naf_literalsContext naf_literals() throws RecognitionException {
		Naf_literalsContext _localctx = new Naf_literalsContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_naf_literals);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(165);
			naf_literal();
			setState(170);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(166);
				match(COMMA);
				setState(167);
				naf_literal();
				}
				}
				setState(172);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Naf_literalContext extends ParserRuleContext {
		public Classical_literalContext classical_literal() {
			return getRuleContext(Classical_literalContext.class,0);
		}
		public TerminalNode NAF() { return getToken(LparseParser.NAF, 0); }
		public Builtin_atomContext builtin_atom() {
			return getRuleContext(Builtin_atomContext.class,0);
		}
		public Naf_literalContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_naf_literal; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterNaf_literal(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitNaf_literal(this);
		}
	}

	public final Naf_literalContext naf_literal() throws RecognitionException {
		Naf_literalContext _localctx = new Naf_literalContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_naf_literal);
		int _la;
		try {
			setState(178);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,25,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(174);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==NAF) {
					{
					setState(173);
					match(NAF);
					}
				}

				setState(176);
				classical_literal();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(177);
				builtin_atom();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Classical_literalContext extends ParserRuleContext {
		public TerminalNode ID() { return getToken(LparseParser.ID, 0); }
		public TerminalNode MINUS() { return getToken(LparseParser.MINUS, 0); }
		public TerminalNode PAREN_OPEN() { return getToken(LparseParser.PAREN_OPEN, 0); }
		public TerminalNode PAREN_CLOSE() { return getToken(LparseParser.PAREN_CLOSE, 0); }
		public TermsContext terms() {
			return getRuleContext(TermsContext.class,0);
		}
		public Classical_literalContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_classical_literal; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterClassical_literal(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitClassical_literal(this);
		}
	}

	public final Classical_literalContext classical_literal() throws RecognitionException {
		Classical_literalContext _localctx = new Classical_literalContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_classical_literal);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(181);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==MINUS) {
				{
				setState(180);
				match(MINUS);
				}
			}

			setState(183);
			match(ID);
			setState(189);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,28,_ctx) ) {
			case 1:
				{
				setState(184);
				match(PAREN_OPEN);
				setState(186);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 278588L) != 0)) {
					{
					setState(185);
					terms();
					}
				}

				setState(188);
				match(PAREN_CLOSE);
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class Builtin_atomContext extends ParserRuleContext {
		public List<TermContext> term() {
			return getRuleContexts(TermContext.class);
		}
		public TermContext term(int i) {
			return getRuleContext(TermContext.class,i);
		}
		public BinopContext binop() {
			return getRuleContext(BinopContext.class,0);
		}
		public Builtin_atomContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_builtin_atom; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterBuiltin_atom(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitBuiltin_atom(this);
		}
	}

	public final Builtin_atomContext builtin_atom() throws RecognitionException {
		Builtin_atomContext _localctx = new Builtin_atomContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_builtin_atom);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(191);
			term(0);
			setState(192);
			binop();
			setState(193);
			term(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class BinopContext extends ParserRuleContext {
		public TerminalNode EQUAL() { return getToken(LparseParser.EQUAL, 0); }
		public TerminalNode UNEQUAL() { return getToken(LparseParser.UNEQUAL, 0); }
		public TerminalNode LESS() { return getToken(LparseParser.LESS, 0); }
		public TerminalNode GREATER() { return getToken(LparseParser.GREATER, 0); }
		public TerminalNode LESS_OR_EQ() { return getToken(LparseParser.LESS_OR_EQ, 0); }
		public TerminalNode GREATER_OR_EQ() { return getToken(LparseParser.GREATER_OR_EQ, 0); }
		public BinopContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_binop; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterBinop(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitBinop(this);
		}
	}

	public final BinopContext binop() throws RecognitionException {
		BinopContext _localctx = new BinopContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_binop);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(195);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 1056964608L) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TermsContext extends ParserRuleContext {
		public List<TermContext> term() {
			return getRuleContexts(TermContext.class);
		}
		public TermContext term(int i) {
			return getRuleContext(TermContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(LparseParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(LparseParser.COMMA, i);
		}
		public TermsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_terms; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterTerms(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitTerms(this);
		}
	}

	public final TermsContext terms() throws RecognitionException {
		TermsContext _localctx = new TermsContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_terms);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(197);
			term(0);
			setState(202);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(198);
				match(COMMA);
				setState(199);
				term(0);
				}
				}
				setState(204);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class TermContext extends ParserRuleContext {
		public TerminalNode ID() { return getToken(LparseParser.ID, 0); }
		public TerminalNode PAREN_OPEN() { return getToken(LparseParser.PAREN_OPEN, 0); }
		public TermsContext terms() {
			return getRuleContext(TermsContext.class,0);
		}
		public TerminalNode PAREN_CLOSE() { return getToken(LparseParser.PAREN_CLOSE, 0); }
		public TerminalNode NUMBER() { return getToken(LparseParser.NUMBER, 0); }
		public TerminalNode VARIABLE() { return getToken(LparseParser.VARIABLE, 0); }
		public TerminalNode ANONYMOUS_VARIABLE() { return getToken(LparseParser.ANONYMOUS_VARIABLE, 0); }
		public List<TermContext> term() {
			return getRuleContexts(TermContext.class);
		}
		public TermContext term(int i) {
			return getRuleContext(TermContext.class,i);
		}
		public TerminalNode MINUS() { return getToken(LparseParser.MINUS, 0); }
		public ArithopContext arithop() {
			return getRuleContext(ArithopContext.class,0);
		}
		public TermContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_term; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterTerm(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitTerm(this);
		}
	}

	public final TermContext term() throws RecognitionException {
		return term(0);
	}

	private TermContext term(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		TermContext _localctx = new TermContext(_ctx, _parentState);
		TermContext _prevctx = _localctx;
		int _startState = 38;
		enterRecursionRule(_localctx, 38, RULE_term, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(222);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case ID:
				{
				setState(206);
				match(ID);
				setState(211);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,30,_ctx) ) {
				case 1:
					{
					setState(207);
					match(PAREN_OPEN);
					setState(208);
					terms();
					setState(209);
					match(PAREN_CLOSE);
					}
					break;
				}
				}
				break;
			case NUMBER:
				{
				setState(213);
				match(NUMBER);
				}
				break;
			case VARIABLE:
				{
				setState(214);
				match(VARIABLE);
				}
				break;
			case ANONYMOUS_VARIABLE:
				{
				setState(215);
				match(ANONYMOUS_VARIABLE);
				}
				break;
			case PAREN_OPEN:
				{
				setState(216);
				match(PAREN_OPEN);
				setState(217);
				term(0);
				setState(218);
				match(PAREN_CLOSE);
				}
				break;
			case MINUS:
				{
				setState(220);
				match(MINUS);
				setState(221);
				term(2);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			_ctx.stop = _input.LT(-1);
			setState(230);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,32,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new TermContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_term);
					setState(224);
					if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
					setState(225);
					arithop();
					setState(226);
					term(2);
					}
					} 
				}
				setState(232);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,32,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	@SuppressWarnings("CheckReturnValue")
	public static class ArithopContext extends ParserRuleContext {
		public TerminalNode PLUS() { return getToken(LparseParser.PLUS, 0); }
		public TerminalNode MINUS() { return getToken(LparseParser.MINUS, 0); }
		public TerminalNode TIMES() { return getToken(LparseParser.TIMES, 0); }
		public TerminalNode DIV() { return getToken(LparseParser.DIV, 0); }
		public ArithopContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_arithop; }
		@Override
		public void enterRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).enterArithop(this);
		}
		@Override
		public void exitRule(ParseTreeListener listener) {
			if ( listener instanceof LparseListener ) ((LparseListener)listener).exitArithop(this);
		}
	}

	public final ArithopContext arithop() throws RecognitionException {
		ArithopContext _localctx = new ArithopContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_arithop);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(233);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 122880L) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 19:
			return term_sempred((TermContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean term_sempred(TermContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 1);
		}
		return true;
	}

	public static final String _serializedATN =
		"\u0004\u0001\u001f\u00ec\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001"+
		"\u0002\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002\u0004\u0007\u0004"+
		"\u0002\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002\u0007\u0007\u0007"+
		"\u0002\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002\u000b\u0007\u000b"+
		"\u0002\f\u0007\f\u0002\r\u0007\r\u0002\u000e\u0007\u000e\u0002\u000f\u0007"+
		"\u000f\u0002\u0010\u0007\u0010\u0002\u0011\u0007\u0011\u0002\u0012\u0007"+
		"\u0012\u0002\u0013\u0007\u0013\u0002\u0014\u0007\u0014\u0001\u0000\u0001"+
		"\u0000\u0003\u0000-\b\u0000\u0001\u0000\u0003\u00000\b\u0000\u0001\u0001"+
		"\u0001\u0001\u0005\u00014\b\u0001\n\u0001\f\u00017\t\u0001\u0001\u0002"+
		"\u0001\u0002\u0001\u0002\u0001\u0003\u0001\u0003\u0003\u0003>\b\u0003"+
		"\u0001\u0003\u0001\u0003\u0001\u0003\u0003\u0003C\b\u0003\u0001\u0003"+
		"\u0003\u0003F\b\u0003\u0001\u0003\u0001\u0003\u0003\u0003J\b\u0003\u0001"+
		"\u0004\u0001\u0004\u0003\u0004N\b\u0004\u0001\u0005\u0001\u0005\u0003"+
		"\u0005R\b\u0005\u0001\u0005\u0003\u0005U\b\u0005\u0001\u0005\u0001\u0005"+
		"\u0001\u0005\u0003\u0005Z\b\u0005\u0001\u0005\u0003\u0005]\b\u0005\u0005"+
		"\u0005_\b\u0005\n\u0005\f\u0005b\t\u0005\u0001\u0006\u0001\u0006\u0001"+
		"\u0006\u0005\u0006g\b\u0006\n\u0006\f\u0006j\t\u0006\u0001\u0007\u0001"+
		"\u0007\u0001\u0007\u0003\u0007o\b\u0007\u0001\u0007\u0001\u0007\u0003"+
		"\u0007s\b\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0003"+
		"\u0007y\b\u0007\u0001\b\u0001\b\u0001\b\u0005\b~\b\b\n\b\f\b\u0081\t\b"+
		"\u0001\t\u0001\t\u0001\t\u0003\t\u0086\b\t\u0001\n\u0001\n\u0001\n\u0003"+
		"\n\u008b\b\n\u0001\n\u0001\n\u0001\n\u0001\n\u0001\n\u0001\n\u0003\n\u0093"+
		"\b\n\u0001\u000b\u0001\u000b\u0001\u000b\u0005\u000b\u0098\b\u000b\n\u000b"+
		"\f\u000b\u009b\t\u000b\u0001\f\u0001\f\u0001\f\u0001\f\u0001\f\u0001\f"+
		"\u0001\f\u0003\f\u00a4\b\f\u0001\r\u0001\r\u0001\r\u0005\r\u00a9\b\r\n"+
		"\r\f\r\u00ac\t\r\u0001\u000e\u0003\u000e\u00af\b\u000e\u0001\u000e\u0001"+
		"\u000e\u0003\u000e\u00b3\b\u000e\u0001\u000f\u0003\u000f\u00b6\b\u000f"+
		"\u0001\u000f\u0001\u000f\u0001\u000f\u0003\u000f\u00bb\b\u000f\u0001\u000f"+
		"\u0003\u000f\u00be\b\u000f\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010"+
		"\u0001\u0011\u0001\u0011\u0001\u0012\u0001\u0012\u0001\u0012\u0005\u0012"+
		"\u00c9\b\u0012\n\u0012\f\u0012\u00cc\t\u0012\u0001\u0013\u0001\u0013\u0001"+
		"\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0003\u0013\u00d4\b\u0013\u0001"+
		"\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0001"+
		"\u0013\u0001\u0013\u0001\u0013\u0003\u0013\u00df\b\u0013\u0001\u0013\u0001"+
		"\u0013\u0001\u0013\u0001\u0013\u0005\u0013\u00e5\b\u0013\n\u0013\f\u0013"+
		"\u00e8\t\u0013\u0001\u0014\u0001\u0014\u0001\u0014\u0000\u0001&\u0015"+
		"\u0000\u0002\u0004\u0006\b\n\f\u000e\u0010\u0012\u0014\u0016\u0018\u001a"+
		"\u001c\u001e \"$&(\u0000\u0002\u0001\u0000\u0018\u001d\u0001\u0000\r\u0010"+
		"\u00fc\u0000/\u0001\u0000\u0000\u0000\u00021\u0001\u0000\u0000\u0000\u0004"+
		"8\u0001\u0000\u0000\u0000\u0006I\u0001\u0000\u0000\u0000\bM\u0001\u0000"+
		"\u0000\u0000\nT\u0001\u0000\u0000\u0000\fc\u0001\u0000\u0000\u0000\u000e"+
		"n\u0001\u0000\u0000\u0000\u0010z\u0001\u0000\u0000\u0000\u0012\u0082\u0001"+
		"\u0000\u0000\u0000\u0014\u008a\u0001\u0000\u0000\u0000\u0016\u0094\u0001"+
		"\u0000\u0000\u0000\u0018\u00a3\u0001\u0000\u0000\u0000\u001a\u00a5\u0001"+
		"\u0000\u0000\u0000\u001c\u00b2\u0001\u0000\u0000\u0000\u001e\u00b5\u0001"+
		"\u0000\u0000\u0000 \u00bf\u0001\u0000\u0000\u0000\"\u00c3\u0001\u0000"+
		"\u0000\u0000$\u00c5\u0001\u0000\u0000\u0000&\u00de\u0001\u0000\u0000\u0000"+
		"(\u00e9\u0001\u0000\u0000\u0000*,\u0003\u0002\u0001\u0000+-\u0003\u0004"+
		"\u0002\u0000,+\u0001\u0000\u0000\u0000,-\u0001\u0000\u0000\u0000-0\u0001"+
		"\u0000\u0000\u0000.0\u0003\u0004\u0002\u0000/*\u0001\u0000\u0000\u0000"+
		"/.\u0001\u0000\u0000\u00000\u0001\u0001\u0000\u0000\u000015\u0003\u0006"+
		"\u0003\u000024\u0003\u0006\u0003\u000032\u0001\u0000\u0000\u000047\u0001"+
		"\u0000\u0000\u000053\u0001\u0000\u0000\u000056\u0001\u0000\u0000\u0000"+
		"6\u0003\u0001\u0000\u0000\u000075\u0001\u0000\u0000\u000089\u0003\u001e"+
		"\u000f\u00009:\u0005\b\u0000\u0000:\u0005\u0001\u0000\u0000\u0000;=\u0005"+
		"\f\u0000\u0000<>\u0003\n\u0005\u0000=<\u0001\u0000\u0000\u0000=>\u0001"+
		"\u0000\u0000\u0000>?\u0001\u0000\u0000\u0000?J\u0005\u0006\u0000\u0000"+
		"@B\u0003\b\u0004\u0000AC\u0005\f\u0000\u0000BA\u0001\u0000\u0000\u0000"+
		"BC\u0001\u0000\u0000\u0000CE\u0001\u0000\u0000\u0000DF\u0003\n\u0005\u0000"+
		"ED\u0001\u0000\u0000\u0000EF\u0001\u0000\u0000\u0000FG\u0001\u0000\u0000"+
		"\u0000GH\u0005\u0006\u0000\u0000HJ\u0001\u0000\u0000\u0000I;\u0001\u0000"+
		"\u0000\u0000I@\u0001\u0000\u0000\u0000J\u0007\u0001\u0000\u0000\u0000"+
		"KN\u0003\f\u0006\u0000LN\u0003\u000e\u0007\u0000MK\u0001\u0000\u0000\u0000"+
		"ML\u0001\u0000\u0000\u0000N\t\u0001\u0000\u0000\u0000OU\u0003\u001c\u000e"+
		"\u0000PR\u0005\u0001\u0000\u0000QP\u0001\u0000\u0000\u0000QR\u0001\u0000"+
		"\u0000\u0000RS\u0001\u0000\u0000\u0000SU\u0003\u0014\n\u0000TO\u0001\u0000"+
		"\u0000\u0000TQ\u0001\u0000\u0000\u0000U`\u0001\u0000\u0000\u0000V\\\u0005"+
		"\u0007\u0000\u0000W]\u0003\u001c\u000e\u0000XZ\u0005\u0001\u0000\u0000"+
		"YX\u0001\u0000\u0000\u0000YZ\u0001\u0000\u0000\u0000Z[\u0001\u0000\u0000"+
		"\u0000[]\u0003\u0014\n\u0000\\W\u0001\u0000\u0000\u0000\\Y\u0001\u0000"+
		"\u0000\u0000]_\u0001\u0000\u0000\u0000^V\u0001\u0000\u0000\u0000_b\u0001"+
		"\u0000\u0000\u0000`^\u0001\u0000\u0000\u0000`a\u0001\u0000\u0000\u0000"+
		"a\u000b\u0001\u0000\u0000\u0000b`\u0001\u0000\u0000\u0000ch\u0003\u001e"+
		"\u000f\u0000de\u0005\u000b\u0000\u0000eg\u0003\u001e\u000f\u0000fd\u0001"+
		"\u0000\u0000\u0000gj\u0001\u0000\u0000\u0000hf\u0001\u0000\u0000\u0000"+
		"hi\u0001\u0000\u0000\u0000i\r\u0001\u0000\u0000\u0000jh\u0001\u0000\u0000"+
		"\u0000kl\u0003&\u0013\u0000lm\u0003\"\u0011\u0000mo\u0001\u0000\u0000"+
		"\u0000nk\u0001\u0000\u0000\u0000no\u0001\u0000\u0000\u0000op\u0001\u0000"+
		"\u0000\u0000pr\u0005\u0016\u0000\u0000qs\u0003\u0010\b\u0000rq\u0001\u0000"+
		"\u0000\u0000rs\u0001\u0000\u0000\u0000st\u0001\u0000\u0000\u0000tx\u0005"+
		"\u0017\u0000\u0000uv\u0003\"\u0011\u0000vw\u0003&\u0013\u0000wy\u0001"+
		"\u0000\u0000\u0000xu\u0001\u0000\u0000\u0000xy\u0001\u0000\u0000\u0000"+
		"y\u000f\u0001\u0000\u0000\u0000z\u007f\u0003\u0012\t\u0000{|\u0005\n\u0000"+
		"\u0000|~\u0003\u0012\t\u0000}{\u0001\u0000\u0000\u0000~\u0081\u0001\u0000"+
		"\u0000\u0000\u007f}\u0001\u0000\u0000\u0000\u007f\u0080\u0001\u0000\u0000"+
		"\u0000\u0080\u0011\u0001\u0000\u0000\u0000\u0081\u007f\u0001\u0000\u0000"+
		"\u0000\u0082\u0085\u0003\u001e\u000f\u0000\u0083\u0084\u0005\t\u0000\u0000"+
		"\u0084\u0086\u0003\u001a\r\u0000\u0085\u0083\u0001\u0000\u0000\u0000\u0085"+
		"\u0086\u0001\u0000\u0000\u0000\u0086\u0013\u0001\u0000\u0000\u0000\u0087"+
		"\u0088\u0003&\u0013\u0000\u0088\u0089\u0003\"\u0011\u0000\u0089\u008b"+
		"\u0001\u0000\u0000\u0000\u008a\u0087\u0001\u0000\u0000\u0000\u008a\u008b"+
		"\u0001\u0000\u0000\u0000\u008b\u008c\u0001\u0000\u0000\u0000\u008c\u008d"+
		"\u0005\u0016\u0000\u0000\u008d\u008e\u0003\u0016\u000b\u0000\u008e\u0092"+
		"\u0005\u0017\u0000\u0000\u008f\u0090\u0003\"\u0011\u0000\u0090\u0091\u0003"+
		"&\u0013\u0000\u0091\u0093\u0001\u0000\u0000\u0000\u0092\u008f\u0001\u0000"+
		"\u0000\u0000\u0092\u0093\u0001\u0000\u0000\u0000\u0093\u0015\u0001\u0000"+
		"\u0000\u0000\u0094\u0099\u0003\u0018\f\u0000\u0095\u0096\u0005\n\u0000"+
		"\u0000\u0096\u0098\u0003\u0018\f\u0000\u0097\u0095\u0001\u0000\u0000\u0000"+
		"\u0098\u009b\u0001\u0000\u0000\u0000\u0099\u0097\u0001\u0000\u0000\u0000"+
		"\u0099\u009a\u0001\u0000\u0000\u0000\u009a\u0017\u0001\u0000\u0000\u0000"+
		"\u009b\u0099\u0001\u0000\u0000\u0000\u009c\u009d\u0003$\u0012\u0000\u009d"+
		"\u009e\u0005\t\u0000\u0000\u009e\u009f\u0003\u001a\r\u0000\u009f\u00a4"+
		"\u0001\u0000\u0000\u0000\u00a0\u00a4\u0003$\u0012\u0000\u00a1\u00a2\u0005"+
		"\t\u0000\u0000\u00a2\u00a4\u0003\u001a\r\u0000\u00a3\u009c\u0001\u0000"+
		"\u0000\u0000\u00a3\u00a0\u0001\u0000\u0000\u0000\u00a3\u00a1\u0001\u0000"+
		"\u0000\u0000\u00a4\u0019\u0001\u0000\u0000\u0000\u00a5\u00aa\u0003\u001c"+
		"\u000e\u0000\u00a6\u00a7\u0005\u0007\u0000\u0000\u00a7\u00a9\u0003\u001c"+
		"\u000e\u0000\u00a8\u00a6\u0001\u0000\u0000\u0000\u00a9\u00ac\u0001\u0000"+
		"\u0000\u0000\u00aa\u00a8\u0001\u0000\u0000\u0000\u00aa\u00ab\u0001\u0000"+
		"\u0000\u0000\u00ab\u001b\u0001\u0000\u0000\u0000\u00ac\u00aa\u0001\u0000"+
		"\u0000\u0000\u00ad\u00af\u0005\u0001\u0000\u0000\u00ae\u00ad\u0001\u0000"+
		"\u0000\u0000\u00ae\u00af\u0001\u0000\u0000\u0000\u00af\u00b0\u0001\u0000"+
		"\u0000\u0000\u00b0\u00b3\u0003\u001e\u000f\u0000\u00b1\u00b3\u0003 \u0010"+
		"\u0000\u00b2\u00ae\u0001\u0000\u0000\u0000\u00b2\u00b1\u0001\u0000\u0000"+
		"\u0000\u00b3\u001d\u0001\u0000\u0000\u0000\u00b4\u00b6\u0005\u000e\u0000"+
		"\u0000\u00b5\u00b4\u0001\u0000\u0000\u0000\u00b5\u00b6\u0001\u0000\u0000"+
		"\u0000\u00b6\u00b7\u0001\u0000\u0000\u0000\u00b7\u00bd\u0005\u0003\u0000"+
		"\u0000\u00b8\u00ba\u0005\u0012\u0000\u0000\u00b9\u00bb\u0003$\u0012\u0000"+
		"\u00ba\u00b9\u0001\u0000\u0000\u0000\u00ba\u00bb\u0001\u0000\u0000\u0000"+
		"\u00bb\u00bc\u0001\u0000\u0000\u0000\u00bc\u00be\u0005\u0013\u0000\u0000"+
		"\u00bd\u00b8\u0001\u0000\u0000\u0000\u00bd\u00be\u0001\u0000\u0000\u0000"+
		"\u00be\u001f\u0001\u0000\u0000\u0000\u00bf\u00c0\u0003&\u0013\u0000\u00c0"+
		"\u00c1\u0003\"\u0011\u0000\u00c1\u00c2\u0003&\u0013\u0000\u00c2!\u0001"+
		"\u0000\u0000\u0000\u00c3\u00c4\u0007\u0000\u0000\u0000\u00c4#\u0001\u0000"+
		"\u0000\u0000\u00c5\u00ca\u0003&\u0013\u0000\u00c6\u00c7\u0005\u0007\u0000"+
		"\u0000\u00c7\u00c9\u0003&\u0013\u0000\u00c8\u00c6\u0001\u0000\u0000\u0000"+
		"\u00c9\u00cc\u0001\u0000\u0000\u0000\u00ca\u00c8\u0001\u0000\u0000\u0000"+
		"\u00ca\u00cb\u0001\u0000\u0000\u0000\u00cb%\u0001\u0000\u0000\u0000\u00cc"+
		"\u00ca\u0001\u0000\u0000\u0000\u00cd\u00ce\u0006\u0013\uffff\uffff\u0000"+
		"\u00ce\u00d3\u0005\u0003\u0000\u0000\u00cf\u00d0\u0005\u0012\u0000\u0000"+
		"\u00d0\u00d1\u0003$\u0012\u0000\u00d1\u00d2\u0005\u0013\u0000\u0000\u00d2"+
		"\u00d4\u0001\u0000\u0000\u0000\u00d3\u00cf\u0001\u0000\u0000\u0000\u00d3"+
		"\u00d4\u0001\u0000\u0000\u0000\u00d4\u00df\u0001\u0000\u0000\u0000\u00d5"+
		"\u00df\u0005\u0002\u0000\u0000\u00d6\u00df\u0005\u0004\u0000\u0000\u00d7"+
		"\u00df\u0005\u0005\u0000\u0000\u00d8\u00d9\u0005\u0012\u0000\u0000\u00d9"+
		"\u00da\u0003&\u0013\u0000\u00da\u00db\u0005\u0013\u0000\u0000\u00db\u00df"+
		"\u0001\u0000\u0000\u0000\u00dc\u00dd\u0005\u000e\u0000\u0000\u00dd\u00df"+
		"\u0003&\u0013\u0002\u00de\u00cd\u0001\u0000\u0000\u0000\u00de\u00d5\u0001"+
		"\u0000\u0000\u0000\u00de\u00d6\u0001\u0000\u0000\u0000\u00de\u00d7\u0001"+
		"\u0000\u0000\u0000\u00de\u00d8\u0001\u0000\u0000\u0000\u00de\u00dc\u0001"+
		"\u0000\u0000\u0000\u00df\u00e6\u0001\u0000\u0000\u0000\u00e0\u00e1\n\u0001"+
		"\u0000\u0000\u00e1\u00e2\u0003(\u0014\u0000\u00e2\u00e3\u0003&\u0013\u0002"+
		"\u00e3\u00e5\u0001\u0000\u0000\u0000\u00e4\u00e0\u0001\u0000\u0000\u0000"+
		"\u00e5\u00e8\u0001\u0000\u0000\u0000\u00e6\u00e4\u0001\u0000\u0000\u0000"+
		"\u00e6\u00e7\u0001\u0000\u0000\u0000\u00e7\'\u0001\u0000\u0000\u0000\u00e8"+
		"\u00e6\u0001\u0000\u0000\u0000\u00e9\u00ea\u0007\u0001\u0000\u0000\u00ea"+
		")\u0001\u0000\u0000\u0000!,/5=BEIMQTY\\`hnrx\u007f\u0085\u008a\u0092\u0099"+
		"\u00a3\u00aa\u00ae\u00b2\u00b5\u00ba\u00bd\u00ca\u00d3\u00de\u00e6";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}