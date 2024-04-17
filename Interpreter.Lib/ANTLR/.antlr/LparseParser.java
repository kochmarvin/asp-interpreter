// Generated from /Users/marvinkoch/Desktop/asp-interpreter/Interpreter.Lib/ANTLR/Lparse.g4 by ANTLR 4.13.1
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
		public Classical_literalContext classical_literal() {
			return getRuleContext(Classical_literalContext.class,0);
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
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(99);
			classical_literal();
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
			setState(104);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 278588L) != 0)) {
				{
				setState(101);
				term(0);
				setState(102);
				binop();
				}
			}

			setState(106);
			match(CURLY_OPEN);
			setState(108);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ID || _la==MINUS) {
				{
				setState(107);
				choice_elements();
				}
			}

			setState(110);
			match(CURLY_CLOSE);
			setState(114);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 1056964608L) != 0)) {
				{
				setState(111);
				binop();
				setState(112);
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
			setState(116);
			choice_element();
			setState(121);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==SEMICOLON) {
				{
				{
				setState(117);
				match(SEMICOLON);
				setState(118);
				choice_element();
				}
				}
				setState(123);
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
			setState(124);
			classical_literal();
			setState(127);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COLON) {
				{
				setState(125);
				match(COLON);
				setState(126);
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
			setState(132);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 278588L) != 0)) {
				{
				setState(129);
				term(0);
				setState(130);
				binop();
				}
			}

			setState(134);
			match(CURLY_OPEN);
			setState(135);
			aggregate_elements();
			setState(136);
			match(CURLY_CLOSE);
			setState(140);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 1056964608L) != 0)) {
				{
				setState(137);
				binop();
				setState(138);
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
			setState(142);
			aggregate_element();
			setState(147);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==SEMICOLON) {
				{
				{
				setState(143);
				match(SEMICOLON);
				setState(144);
				aggregate_element();
				}
				}
				setState(149);
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
			setState(157);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,21,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(150);
				terms();
				setState(151);
				match(COLON);
				setState(152);
				naf_literals();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(154);
				terms();
				}
				break;
			case 3:
				enterOuterAlt(_localctx, 3);
				{
				setState(155);
				match(COLON);
				setState(156);
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
			setState(159);
			naf_literal();
			setState(164);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(160);
				match(COMMA);
				setState(161);
				naf_literal();
				}
				}
				setState(166);
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
			setState(172);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,24,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(168);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==NAF) {
					{
					setState(167);
					match(NAF);
					}
				}

				setState(170);
				classical_literal();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(171);
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
			setState(175);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==MINUS) {
				{
				setState(174);
				match(MINUS);
				}
			}

			setState(177);
			match(ID);
			setState(183);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,27,_ctx) ) {
			case 1:
				{
				setState(178);
				match(PAREN_OPEN);
				setState(180);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 278588L) != 0)) {
					{
					setState(179);
					terms();
					}
				}

				setState(182);
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
			setState(185);
			term(0);
			setState(186);
			binop();
			setState(187);
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
			setState(189);
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
			setState(191);
			term(0);
			setState(196);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(192);
				match(COMMA);
				setState(193);
				term(0);
				}
				}
				setState(198);
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
		public TerminalNode MINUS() { return getToken(LparseParser.MINUS, 0); }
		public TerminalNode VARIABLE() { return getToken(LparseParser.VARIABLE, 0); }
		public TerminalNode ANONYMOUS_VARIABLE() { return getToken(LparseParser.ANONYMOUS_VARIABLE, 0); }
		public List<TermContext> term() {
			return getRuleContexts(TermContext.class);
		}
		public TermContext term(int i) {
			return getRuleContext(TermContext.class,i);
		}
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
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(217);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case ID:
				{
				setState(200);
				match(ID);
				setState(205);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,29,_ctx) ) {
				case 1:
					{
					setState(201);
					match(PAREN_OPEN);
					setState(202);
					terms();
					setState(203);
					match(PAREN_CLOSE);
					}
					break;
				}
				}
				break;
			case NUMBER:
			case MINUS:
				{
				setState(208);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==MINUS) {
					{
					setState(207);
					match(MINUS);
					}
				}

				setState(210);
				match(NUMBER);
				}
				break;
			case VARIABLE:
				{
				setState(211);
				match(VARIABLE);
				}
				break;
			case ANONYMOUS_VARIABLE:
				{
				setState(212);
				match(ANONYMOUS_VARIABLE);
				}
				break;
			case PAREN_OPEN:
				{
				setState(213);
				match(PAREN_OPEN);
				setState(214);
				term(0);
				setState(215);
				match(PAREN_CLOSE);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			_ctx.stop = _input.LT(-1);
			setState(225);
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
					setState(219);
					if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
					setState(220);
					arithop();
					setState(221);
					term(2);
					}
					} 
				}
				setState(227);
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
			setState(228);
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
		"\u0004\u0001\u001f\u00e7\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001"+
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
		"\u0007\u0001\u0007\u0001\u0007\u0003\u0007i\b\u0007\u0001\u0007\u0001"+
		"\u0007\u0003\u0007m\b\u0007\u0001\u0007\u0001\u0007\u0001\u0007\u0001"+
		"\u0007\u0003\u0007s\b\u0007\u0001\b\u0001\b\u0001\b\u0005\bx\b\b\n\b\f"+
		"\b{\t\b\u0001\t\u0001\t\u0001\t\u0003\t\u0080\b\t\u0001\n\u0001\n\u0001"+
		"\n\u0003\n\u0085\b\n\u0001\n\u0001\n\u0001\n\u0001\n\u0001\n\u0001\n\u0003"+
		"\n\u008d\b\n\u0001\u000b\u0001\u000b\u0001\u000b\u0005\u000b\u0092\b\u000b"+
		"\n\u000b\f\u000b\u0095\t\u000b\u0001\f\u0001\f\u0001\f\u0001\f\u0001\f"+
		"\u0001\f\u0001\f\u0003\f\u009e\b\f\u0001\r\u0001\r\u0001\r\u0005\r\u00a3"+
		"\b\r\n\r\f\r\u00a6\t\r\u0001\u000e\u0003\u000e\u00a9\b\u000e\u0001\u000e"+
		"\u0001\u000e\u0003\u000e\u00ad\b\u000e\u0001\u000f\u0003\u000f\u00b0\b"+
		"\u000f\u0001\u000f\u0001\u000f\u0001\u000f\u0003\u000f\u00b5\b\u000f\u0001"+
		"\u000f\u0003\u000f\u00b8\b\u000f\u0001\u0010\u0001\u0010\u0001\u0010\u0001"+
		"\u0010\u0001\u0011\u0001\u0011\u0001\u0012\u0001\u0012\u0001\u0012\u0005"+
		"\u0012\u00c3\b\u0012\n\u0012\f\u0012\u00c6\t\u0012\u0001\u0013\u0001\u0013"+
		"\u0001\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0003\u0013\u00ce\b\u0013"+
		"\u0001\u0013\u0003\u0013\u00d1\b\u0013\u0001\u0013\u0001\u0013\u0001\u0013"+
		"\u0001\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0003\u0013\u00da\b\u0013"+
		"\u0001\u0013\u0001\u0013\u0001\u0013\u0001\u0013\u0005\u0013\u00e0\b\u0013"+
		"\n\u0013\f\u0013\u00e3\t\u0013\u0001\u0014\u0001\u0014\u0001\u0014\u0000"+
		"\u0001&\u0015\u0000\u0002\u0004\u0006\b\n\f\u000e\u0010\u0012\u0014\u0016"+
		"\u0018\u001a\u001c\u001e \"$&(\u0000\u0002\u0001\u0000\u0018\u001d\u0001"+
		"\u0000\r\u0010\u00f6\u0000/\u0001\u0000\u0000\u0000\u00021\u0001\u0000"+
		"\u0000\u0000\u00048\u0001\u0000\u0000\u0000\u0006I\u0001\u0000\u0000\u0000"+
		"\bM\u0001\u0000\u0000\u0000\nT\u0001\u0000\u0000\u0000\fc\u0001\u0000"+
		"\u0000\u0000\u000eh\u0001\u0000\u0000\u0000\u0010t\u0001\u0000\u0000\u0000"+
		"\u0012|\u0001\u0000\u0000\u0000\u0014\u0084\u0001\u0000\u0000\u0000\u0016"+
		"\u008e\u0001\u0000\u0000\u0000\u0018\u009d\u0001\u0000\u0000\u0000\u001a"+
		"\u009f\u0001\u0000\u0000\u0000\u001c\u00ac\u0001\u0000\u0000\u0000\u001e"+
		"\u00af\u0001\u0000\u0000\u0000 \u00b9\u0001\u0000\u0000\u0000\"\u00bd"+
		"\u0001\u0000\u0000\u0000$\u00bf\u0001\u0000\u0000\u0000&\u00d9\u0001\u0000"+
		"\u0000\u0000(\u00e4\u0001\u0000\u0000\u0000*,\u0003\u0002\u0001\u0000"+
		"+-\u0003\u0004\u0002\u0000,+\u0001\u0000\u0000\u0000,-\u0001\u0000\u0000"+
		"\u0000-0\u0001\u0000\u0000\u0000.0\u0003\u0004\u0002\u0000/*\u0001\u0000"+
		"\u0000\u0000/.\u0001\u0000\u0000\u00000\u0001\u0001\u0000\u0000\u0000"+
		"15\u0003\u0006\u0003\u000024\u0003\u0006\u0003\u000032\u0001\u0000\u0000"+
		"\u000047\u0001\u0000\u0000\u000053\u0001\u0000\u0000\u000056\u0001\u0000"+
		"\u0000\u00006\u0003\u0001\u0000\u0000\u000075\u0001\u0000\u0000\u0000"+
		"89\u0003\u001e\u000f\u00009:\u0005\b\u0000\u0000:\u0005\u0001\u0000\u0000"+
		"\u0000;=\u0005\f\u0000\u0000<>\u0003\n\u0005\u0000=<\u0001\u0000\u0000"+
		"\u0000=>\u0001\u0000\u0000\u0000>?\u0001\u0000\u0000\u0000?J\u0005\u0006"+
		"\u0000\u0000@B\u0003\b\u0004\u0000AC\u0005\f\u0000\u0000BA\u0001\u0000"+
		"\u0000\u0000BC\u0001\u0000\u0000\u0000CE\u0001\u0000\u0000\u0000DF\u0003"+
		"\n\u0005\u0000ED\u0001\u0000\u0000\u0000EF\u0001\u0000\u0000\u0000FG\u0001"+
		"\u0000\u0000\u0000GH\u0005\u0006\u0000\u0000HJ\u0001\u0000\u0000\u0000"+
		"I;\u0001\u0000\u0000\u0000I@\u0001\u0000\u0000\u0000J\u0007\u0001\u0000"+
		"\u0000\u0000KN\u0003\f\u0006\u0000LN\u0003\u000e\u0007\u0000MK\u0001\u0000"+
		"\u0000\u0000ML\u0001\u0000\u0000\u0000N\t\u0001\u0000\u0000\u0000OU\u0003"+
		"\u001c\u000e\u0000PR\u0005\u0001\u0000\u0000QP\u0001\u0000\u0000\u0000"+
		"QR\u0001\u0000\u0000\u0000RS\u0001\u0000\u0000\u0000SU\u0003\u0014\n\u0000"+
		"TO\u0001\u0000\u0000\u0000TQ\u0001\u0000\u0000\u0000U`\u0001\u0000\u0000"+
		"\u0000V\\\u0005\u0007\u0000\u0000W]\u0003\u001c\u000e\u0000XZ\u0005\u0001"+
		"\u0000\u0000YX\u0001\u0000\u0000\u0000YZ\u0001\u0000\u0000\u0000Z[\u0001"+
		"\u0000\u0000\u0000[]\u0003\u0014\n\u0000\\W\u0001\u0000\u0000\u0000\\"+
		"Y\u0001\u0000\u0000\u0000]_\u0001\u0000\u0000\u0000^V\u0001\u0000\u0000"+
		"\u0000_b\u0001\u0000\u0000\u0000`^\u0001\u0000\u0000\u0000`a\u0001\u0000"+
		"\u0000\u0000a\u000b\u0001\u0000\u0000\u0000b`\u0001\u0000\u0000\u0000"+
		"cd\u0003\u001e\u000f\u0000d\r\u0001\u0000\u0000\u0000ef\u0003&\u0013\u0000"+
		"fg\u0003\"\u0011\u0000gi\u0001\u0000\u0000\u0000he\u0001\u0000\u0000\u0000"+
		"hi\u0001\u0000\u0000\u0000ij\u0001\u0000\u0000\u0000jl\u0005\u0016\u0000"+
		"\u0000km\u0003\u0010\b\u0000lk\u0001\u0000\u0000\u0000lm\u0001\u0000\u0000"+
		"\u0000mn\u0001\u0000\u0000\u0000nr\u0005\u0017\u0000\u0000op\u0003\"\u0011"+
		"\u0000pq\u0003&\u0013\u0000qs\u0001\u0000\u0000\u0000ro\u0001\u0000\u0000"+
		"\u0000rs\u0001\u0000\u0000\u0000s\u000f\u0001\u0000\u0000\u0000ty\u0003"+
		"\u0012\t\u0000uv\u0005\n\u0000\u0000vx\u0003\u0012\t\u0000wu\u0001\u0000"+
		"\u0000\u0000x{\u0001\u0000\u0000\u0000yw\u0001\u0000\u0000\u0000yz\u0001"+
		"\u0000\u0000\u0000z\u0011\u0001\u0000\u0000\u0000{y\u0001\u0000\u0000"+
		"\u0000|\u007f\u0003\u001e\u000f\u0000}~\u0005\t\u0000\u0000~\u0080\u0003"+
		"\u001a\r\u0000\u007f}\u0001\u0000\u0000\u0000\u007f\u0080\u0001\u0000"+
		"\u0000\u0000\u0080\u0013\u0001\u0000\u0000\u0000\u0081\u0082\u0003&\u0013"+
		"\u0000\u0082\u0083\u0003\"\u0011\u0000\u0083\u0085\u0001\u0000\u0000\u0000"+
		"\u0084\u0081\u0001\u0000\u0000\u0000\u0084\u0085\u0001\u0000\u0000\u0000"+
		"\u0085\u0086\u0001\u0000\u0000\u0000\u0086\u0087\u0005\u0016\u0000\u0000"+
		"\u0087\u0088\u0003\u0016\u000b\u0000\u0088\u008c\u0005\u0017\u0000\u0000"+
		"\u0089\u008a\u0003\"\u0011\u0000\u008a\u008b\u0003&\u0013\u0000\u008b"+
		"\u008d\u0001\u0000\u0000\u0000\u008c\u0089\u0001\u0000\u0000\u0000\u008c"+
		"\u008d\u0001\u0000\u0000\u0000\u008d\u0015\u0001\u0000\u0000\u0000\u008e"+
		"\u0093\u0003\u0018\f\u0000\u008f\u0090\u0005\n\u0000\u0000\u0090\u0092"+
		"\u0003\u0018\f\u0000\u0091\u008f\u0001\u0000\u0000\u0000\u0092\u0095\u0001"+
		"\u0000\u0000\u0000\u0093\u0091\u0001\u0000\u0000\u0000\u0093\u0094\u0001"+
		"\u0000\u0000\u0000\u0094\u0017\u0001\u0000\u0000\u0000\u0095\u0093\u0001"+
		"\u0000\u0000\u0000\u0096\u0097\u0003$\u0012\u0000\u0097\u0098\u0005\t"+
		"\u0000\u0000\u0098\u0099\u0003\u001a\r\u0000\u0099\u009e\u0001\u0000\u0000"+
		"\u0000\u009a\u009e\u0003$\u0012\u0000\u009b\u009c\u0005\t\u0000\u0000"+
		"\u009c\u009e\u0003\u001a\r\u0000\u009d\u0096\u0001\u0000\u0000\u0000\u009d"+
		"\u009a\u0001\u0000\u0000\u0000\u009d\u009b\u0001\u0000\u0000\u0000\u009e"+
		"\u0019\u0001\u0000\u0000\u0000\u009f\u00a4\u0003\u001c\u000e\u0000\u00a0"+
		"\u00a1\u0005\u0007\u0000\u0000\u00a1\u00a3\u0003\u001c\u000e\u0000\u00a2"+
		"\u00a0\u0001\u0000\u0000\u0000\u00a3\u00a6\u0001\u0000\u0000\u0000\u00a4"+
		"\u00a2\u0001\u0000\u0000\u0000\u00a4\u00a5\u0001\u0000\u0000\u0000\u00a5"+
		"\u001b\u0001\u0000\u0000\u0000\u00a6\u00a4\u0001\u0000\u0000\u0000\u00a7"+
		"\u00a9\u0005\u0001\u0000\u0000\u00a8\u00a7\u0001\u0000\u0000\u0000\u00a8"+
		"\u00a9\u0001\u0000\u0000\u0000\u00a9\u00aa\u0001\u0000\u0000\u0000\u00aa"+
		"\u00ad\u0003\u001e\u000f\u0000\u00ab\u00ad\u0003 \u0010\u0000\u00ac\u00a8"+
		"\u0001\u0000\u0000\u0000\u00ac\u00ab\u0001\u0000\u0000\u0000\u00ad\u001d"+
		"\u0001\u0000\u0000\u0000\u00ae\u00b0\u0005\u000e\u0000\u0000\u00af\u00ae"+
		"\u0001\u0000\u0000\u0000\u00af\u00b0\u0001\u0000\u0000\u0000\u00b0\u00b1"+
		"\u0001\u0000\u0000\u0000\u00b1\u00b7\u0005\u0003\u0000\u0000\u00b2\u00b4"+
		"\u0005\u0012\u0000\u0000\u00b3\u00b5\u0003$\u0012\u0000\u00b4\u00b3\u0001"+
		"\u0000\u0000\u0000\u00b4\u00b5\u0001\u0000\u0000\u0000\u00b5\u00b6\u0001"+
		"\u0000\u0000\u0000\u00b6\u00b8\u0005\u0013\u0000\u0000\u00b7\u00b2\u0001"+
		"\u0000\u0000\u0000\u00b7\u00b8\u0001\u0000\u0000\u0000\u00b8\u001f\u0001"+
		"\u0000\u0000\u0000\u00b9\u00ba\u0003&\u0013\u0000\u00ba\u00bb\u0003\""+
		"\u0011\u0000\u00bb\u00bc\u0003&\u0013\u0000\u00bc!\u0001\u0000\u0000\u0000"+
		"\u00bd\u00be\u0007\u0000\u0000\u0000\u00be#\u0001\u0000\u0000\u0000\u00bf"+
		"\u00c4\u0003&\u0013\u0000\u00c0\u00c1\u0005\u0007\u0000\u0000\u00c1\u00c3"+
		"\u0003&\u0013\u0000\u00c2\u00c0\u0001\u0000\u0000\u0000\u00c3\u00c6\u0001"+
		"\u0000\u0000\u0000\u00c4\u00c2\u0001\u0000\u0000\u0000\u00c4\u00c5\u0001"+
		"\u0000\u0000\u0000\u00c5%\u0001\u0000\u0000\u0000\u00c6\u00c4\u0001\u0000"+
		"\u0000\u0000\u00c7\u00c8\u0006\u0013\uffff\uffff\u0000\u00c8\u00cd\u0005"+
		"\u0003\u0000\u0000\u00c9\u00ca\u0005\u0012\u0000\u0000\u00ca\u00cb\u0003"+
		"$\u0012\u0000\u00cb\u00cc\u0005\u0013\u0000\u0000\u00cc\u00ce\u0001\u0000"+
		"\u0000\u0000\u00cd\u00c9\u0001\u0000\u0000\u0000\u00cd\u00ce\u0001\u0000"+
		"\u0000\u0000\u00ce\u00da\u0001\u0000\u0000\u0000\u00cf\u00d1\u0005\u000e"+
		"\u0000\u0000\u00d0\u00cf\u0001\u0000\u0000\u0000\u00d0\u00d1\u0001\u0000"+
		"\u0000\u0000\u00d1\u00d2\u0001\u0000\u0000\u0000\u00d2\u00da\u0005\u0002"+
		"\u0000\u0000\u00d3\u00da\u0005\u0004\u0000\u0000\u00d4\u00da\u0005\u0005"+
		"\u0000\u0000\u00d5\u00d6\u0005\u0012\u0000\u0000\u00d6\u00d7\u0003&\u0013"+
		"\u0000\u00d7\u00d8\u0005\u0013\u0000\u0000\u00d8\u00da\u0001\u0000\u0000"+
		"\u0000\u00d9\u00c7\u0001\u0000\u0000\u0000\u00d9\u00d0\u0001\u0000\u0000"+
		"\u0000\u00d9\u00d3\u0001\u0000\u0000\u0000\u00d9\u00d4\u0001\u0000\u0000"+
		"\u0000\u00d9\u00d5\u0001\u0000\u0000\u0000\u00da\u00e1\u0001\u0000\u0000"+
		"\u0000\u00db\u00dc\n\u0001\u0000\u0000\u00dc\u00dd\u0003(\u0014\u0000"+
		"\u00dd\u00de\u0003&\u0013\u0002\u00de\u00e0\u0001\u0000\u0000\u0000\u00df"+
		"\u00db\u0001\u0000\u0000\u0000\u00e0\u00e3\u0001\u0000\u0000\u0000\u00e1"+
		"\u00df\u0001\u0000\u0000\u0000\u00e1\u00e2\u0001\u0000\u0000\u0000\u00e2"+
		"\'\u0001\u0000\u0000\u0000\u00e3\u00e1\u0001\u0000\u0000\u0000\u00e4\u00e5"+
		"\u0007\u0001\u0000\u0000\u00e5)\u0001\u0000\u0000\u0000!,/5=BEIMQTY\\"+
		"`hlry\u007f\u0084\u008c\u0093\u009d\u00a4\u00a8\u00ac\u00af\u00b4\u00b7"+
		"\u00c4\u00cd\u00d0\u00d9\u00e1";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}