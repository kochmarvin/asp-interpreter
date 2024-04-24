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
		NAF=1, NUMBER=2, ID=3, VARIABLE=4, DOT=5, COMMA=6, QUERY_MARK=7, COLON=8, 
		SEMICOLON=9, CONS=10, PLUS=11, MINUS=12, TIMES=13, DIV=14, PAREN_OPEN=15, 
		PAREN_CLOSE=16, SQUARE_OPEN=17, SQUARE_CLOSE=18, CURLY_OPEN=19, CURLY_CLOSE=20, 
		EQUAL=21, UNEQUAL=22, LESS=23, GREATER=24, LESS_OR_EQ=25, GREATER_OR_EQ=26, 
		COMMENT=27, WS=28;
	public static final int
		RULE_program = 0, RULE_statements = 1, RULE_query = 2, RULE_statement = 3, 
		RULE_head = 4, RULE_body = 5, RULE_disjunction = 6, RULE_choice = 7, RULE_choice_elements = 8, 
		RULE_choice_element = 9, RULE_naf_literals = 10, RULE_naf_literal = 11, 
		RULE_classical_literal = 12, RULE_builtin_atom = 13, RULE_binop = 14, 
		RULE_terms = 15, RULE_term = 16, RULE_arithop = 17;
	private static String[] makeRuleNames() {
		return new String[] {
			"program", "statements", "query", "statement", "head", "body", "disjunction", 
			"choice", "choice_elements", "choice_element", "naf_literals", "naf_literal", 
			"classical_literal", "builtin_atom", "binop", "terms", "term", "arithop"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'not'", null, null, null, "'.'", "','", "'?'", "':'", "';'", "':-'", 
			"'+'", "'-'", "'*'", "'/'", "'('", "')'", "'['", "']'", "'{'", "'}'", 
			"'='", null, "'<'", "'>'", "'<='", "'>='"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "NAF", "NUMBER", "ID", "VARIABLE", "DOT", "COMMA", "QUERY_MARK", 
			"COLON", "SEMICOLON", "CONS", "PLUS", "MINUS", "TIMES", "DIV", "PAREN_OPEN", 
			"PAREN_CLOSE", "SQUARE_OPEN", "SQUARE_CLOSE", "CURLY_OPEN", "CURLY_CLOSE", 
			"EQUAL", "UNEQUAL", "LESS", "GREATER", "LESS_OR_EQ", "GREATER_OR_EQ", 
			"COMMENT", "WS"
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
			setState(41);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,1,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(36);
				statements();
				setState(38);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==ID || _la==MINUS) {
					{
					setState(37);
					query();
					}
				}

				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(40);
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
			setState(43);
			statement();
			setState(47);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,2,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(44);
					statement();
					}
					} 
				}
				setState(49);
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
			setState(50);
			classical_literal();
			setState(51);
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
			setState(67);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case CONS:
				enterOuterAlt(_localctx, 1);
				{
				setState(53);
				match(CONS);
				setState(55);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 36894L) != 0)) {
					{
					setState(54);
					body();
					}
				}

				setState(57);
				match(DOT);
				}
				break;
			case NUMBER:
			case ID:
			case VARIABLE:
			case MINUS:
			case PAREN_OPEN:
			case CURLY_OPEN:
				enterOuterAlt(_localctx, 2);
				{
				setState(58);
				head();
				setState(60);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==CONS) {
					{
					setState(59);
					match(CONS);
					}
				}

				setState(63);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 36894L) != 0)) {
					{
					setState(62);
					body();
					}
				}

				setState(65);
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
			setState(71);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,7,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(69);
				disjunction();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(70);
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
		public List<TerminalNode> COMMA() { return getTokens(LparseParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(LparseParser.COMMA, i);
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
			{
			setState(73);
			naf_literal();
			}
			setState(78);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(74);
				match(COMMA);
				{
				setState(75);
				naf_literal();
				}
				}
				}
				setState(80);
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
			setState(81);
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
			setState(86);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 36892L) != 0)) {
				{
				setState(83);
				term(0);
				setState(84);
				binop();
				}
			}

			setState(88);
			match(CURLY_OPEN);
			setState(90);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ID || _la==MINUS) {
				{
				setState(89);
				choice_elements();
				}
			}

			setState(92);
			match(CURLY_CLOSE);
			setState(96);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 132120576L) != 0)) {
				{
				setState(93);
				binop();
				setState(94);
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
			setState(98);
			choice_element();
			setState(103);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==SEMICOLON) {
				{
				{
				setState(99);
				match(SEMICOLON);
				setState(100);
				choice_element();
				}
				}
				setState(105);
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
			setState(106);
			classical_literal();
			setState(109);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==COLON) {
				{
				setState(107);
				match(COLON);
				setState(108);
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
		enterRule(_localctx, 20, RULE_naf_literals);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(111);
			naf_literal();
			setState(116);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(112);
				match(COMMA);
				setState(113);
				naf_literal();
				}
				}
				setState(118);
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
		enterRule(_localctx, 22, RULE_naf_literal);
		int _la;
		try {
			setState(124);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,16,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(120);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==NAF) {
					{
					setState(119);
					match(NAF);
					}
				}

				setState(122);
				classical_literal();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(123);
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
		enterRule(_localctx, 24, RULE_classical_literal);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(127);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==MINUS) {
				{
				setState(126);
				match(MINUS);
				}
			}

			setState(129);
			match(ID);
			setState(135);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,19,_ctx) ) {
			case 1:
				{
				setState(130);
				match(PAREN_OPEN);
				setState(132);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if ((((_la) & ~0x3f) == 0 && ((1L << _la) & 36892L) != 0)) {
					{
					setState(131);
					terms();
					}
				}

				setState(134);
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
		enterRule(_localctx, 26, RULE_builtin_atom);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(137);
			term(0);
			setState(138);
			binop();
			setState(139);
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
		enterRule(_localctx, 28, RULE_binop);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(141);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 132120576L) != 0)) ) {
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
		enterRule(_localctx, 30, RULE_terms);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(143);
			term(0);
			setState(148);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(144);
				match(COMMA);
				setState(145);
				term(0);
				}
				}
				setState(150);
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
		int _startState = 32;
		enterRecursionRule(_localctx, 32, RULE_term, _p);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(168);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case ID:
				{
				setState(152);
				match(ID);
				setState(157);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,21,_ctx) ) {
				case 1:
					{
					setState(153);
					match(PAREN_OPEN);
					setState(154);
					terms();
					setState(155);
					match(PAREN_CLOSE);
					}
					break;
				}
				}
				break;
			case NUMBER:
			case MINUS:
				{
				setState(160);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==MINUS) {
					{
					setState(159);
					match(MINUS);
					}
				}

				setState(162);
				match(NUMBER);
				}
				break;
			case VARIABLE:
				{
				setState(163);
				match(VARIABLE);
				}
				break;
			case PAREN_OPEN:
				{
				setState(164);
				match(PAREN_OPEN);
				setState(165);
				term(0);
				setState(166);
				match(PAREN_CLOSE);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			_ctx.stop = _input.LT(-1);
			setState(176);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,24,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new TermContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_term);
					setState(170);
					if (!(precpred(_ctx, 1))) throw new FailedPredicateException(this, "precpred(_ctx, 1)");
					setState(171);
					arithop();
					setState(172);
					term(2);
					}
					} 
				}
				setState(178);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,24,_ctx);
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
		enterRule(_localctx, 34, RULE_arithop);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(179);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 30720L) != 0)) ) {
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
		case 16:
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
		"\u0004\u0001\u001c\u00b6\u0002\u0000\u0007\u0000\u0002\u0001\u0007\u0001"+
		"\u0002\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002\u0004\u0007\u0004"+
		"\u0002\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002\u0007\u0007\u0007"+
		"\u0002\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002\u000b\u0007\u000b"+
		"\u0002\f\u0007\f\u0002\r\u0007\r\u0002\u000e\u0007\u000e\u0002\u000f\u0007"+
		"\u000f\u0002\u0010\u0007\u0010\u0002\u0011\u0007\u0011\u0001\u0000\u0001"+
		"\u0000\u0003\u0000\'\b\u0000\u0001\u0000\u0003\u0000*\b\u0000\u0001\u0001"+
		"\u0001\u0001\u0005\u0001.\b\u0001\n\u0001\f\u00011\t\u0001\u0001\u0002"+
		"\u0001\u0002\u0001\u0002\u0001\u0003\u0001\u0003\u0003\u00038\b\u0003"+
		"\u0001\u0003\u0001\u0003\u0001\u0003\u0003\u0003=\b\u0003\u0001\u0003"+
		"\u0003\u0003@\b\u0003\u0001\u0003\u0001\u0003\u0003\u0003D\b\u0003\u0001"+
		"\u0004\u0001\u0004\u0003\u0004H\b\u0004\u0001\u0005\u0001\u0005\u0001"+
		"\u0005\u0005\u0005M\b\u0005\n\u0005\f\u0005P\t\u0005\u0001\u0006\u0001"+
		"\u0006\u0001\u0007\u0001\u0007\u0001\u0007\u0003\u0007W\b\u0007\u0001"+
		"\u0007\u0001\u0007\u0003\u0007[\b\u0007\u0001\u0007\u0001\u0007\u0001"+
		"\u0007\u0001\u0007\u0003\u0007a\b\u0007\u0001\b\u0001\b\u0001\b\u0005"+
		"\bf\b\b\n\b\f\bi\t\b\u0001\t\u0001\t\u0001\t\u0003\tn\b\t\u0001\n\u0001"+
		"\n\u0001\n\u0005\ns\b\n\n\n\f\nv\t\n\u0001\u000b\u0003\u000by\b\u000b"+
		"\u0001\u000b\u0001\u000b\u0003\u000b}\b\u000b\u0001\f\u0003\f\u0080\b"+
		"\f\u0001\f\u0001\f\u0001\f\u0003\f\u0085\b\f\u0001\f\u0003\f\u0088\b\f"+
		"\u0001\r\u0001\r\u0001\r\u0001\r\u0001\u000e\u0001\u000e\u0001\u000f\u0001"+
		"\u000f\u0001\u000f\u0005\u000f\u0093\b\u000f\n\u000f\f\u000f\u0096\t\u000f"+
		"\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010"+
		"\u0003\u0010\u009e\b\u0010\u0001\u0010\u0003\u0010\u00a1\b\u0010\u0001"+
		"\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0003"+
		"\u0010\u00a9\b\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0001\u0010\u0005"+
		"\u0010\u00af\b\u0010\n\u0010\f\u0010\u00b2\t\u0010\u0001\u0011\u0001\u0011"+
		"\u0001\u0011\u0000\u0001 \u0012\u0000\u0002\u0004\u0006\b\n\f\u000e\u0010"+
		"\u0012\u0014\u0016\u0018\u001a\u001c\u001e \"\u0000\u0002\u0001\u0000"+
		"\u0015\u001a\u0001\u0000\u000b\u000e\u00be\u0000)\u0001\u0000\u0000\u0000"+
		"\u0002+\u0001\u0000\u0000\u0000\u00042\u0001\u0000\u0000\u0000\u0006C"+
		"\u0001\u0000\u0000\u0000\bG\u0001\u0000\u0000\u0000\nI\u0001\u0000\u0000"+
		"\u0000\fQ\u0001\u0000\u0000\u0000\u000eV\u0001\u0000\u0000\u0000\u0010"+
		"b\u0001\u0000\u0000\u0000\u0012j\u0001\u0000\u0000\u0000\u0014o\u0001"+
		"\u0000\u0000\u0000\u0016|\u0001\u0000\u0000\u0000\u0018\u007f\u0001\u0000"+
		"\u0000\u0000\u001a\u0089\u0001\u0000\u0000\u0000\u001c\u008d\u0001\u0000"+
		"\u0000\u0000\u001e\u008f\u0001\u0000\u0000\u0000 \u00a8\u0001\u0000\u0000"+
		"\u0000\"\u00b3\u0001\u0000\u0000\u0000$&\u0003\u0002\u0001\u0000%\'\u0003"+
		"\u0004\u0002\u0000&%\u0001\u0000\u0000\u0000&\'\u0001\u0000\u0000\u0000"+
		"\'*\u0001\u0000\u0000\u0000(*\u0003\u0004\u0002\u0000)$\u0001\u0000\u0000"+
		"\u0000)(\u0001\u0000\u0000\u0000*\u0001\u0001\u0000\u0000\u0000+/\u0003"+
		"\u0006\u0003\u0000,.\u0003\u0006\u0003\u0000-,\u0001\u0000\u0000\u0000"+
		".1\u0001\u0000\u0000\u0000/-\u0001\u0000\u0000\u0000/0\u0001\u0000\u0000"+
		"\u00000\u0003\u0001\u0000\u0000\u00001/\u0001\u0000\u0000\u000023\u0003"+
		"\u0018\f\u000034\u0005\u0007\u0000\u00004\u0005\u0001\u0000\u0000\u0000"+
		"57\u0005\n\u0000\u000068\u0003\n\u0005\u000076\u0001\u0000\u0000\u0000"+
		"78\u0001\u0000\u0000\u000089\u0001\u0000\u0000\u00009D\u0005\u0005\u0000"+
		"\u0000:<\u0003\b\u0004\u0000;=\u0005\n\u0000\u0000<;\u0001\u0000\u0000"+
		"\u0000<=\u0001\u0000\u0000\u0000=?\u0001\u0000\u0000\u0000>@\u0003\n\u0005"+
		"\u0000?>\u0001\u0000\u0000\u0000?@\u0001\u0000\u0000\u0000@A\u0001\u0000"+
		"\u0000\u0000AB\u0005\u0005\u0000\u0000BD\u0001\u0000\u0000\u0000C5\u0001"+
		"\u0000\u0000\u0000C:\u0001\u0000\u0000\u0000D\u0007\u0001\u0000\u0000"+
		"\u0000EH\u0003\f\u0006\u0000FH\u0003\u000e\u0007\u0000GE\u0001\u0000\u0000"+
		"\u0000GF\u0001\u0000\u0000\u0000H\t\u0001\u0000\u0000\u0000IN\u0003\u0016"+
		"\u000b\u0000JK\u0005\u0006\u0000\u0000KM\u0003\u0016\u000b\u0000LJ\u0001"+
		"\u0000\u0000\u0000MP\u0001\u0000\u0000\u0000NL\u0001\u0000\u0000\u0000"+
		"NO\u0001\u0000\u0000\u0000O\u000b\u0001\u0000\u0000\u0000PN\u0001\u0000"+
		"\u0000\u0000QR\u0003\u0018\f\u0000R\r\u0001\u0000\u0000\u0000ST\u0003"+
		" \u0010\u0000TU\u0003\u001c\u000e\u0000UW\u0001\u0000\u0000\u0000VS\u0001"+
		"\u0000\u0000\u0000VW\u0001\u0000\u0000\u0000WX\u0001\u0000\u0000\u0000"+
		"XZ\u0005\u0013\u0000\u0000Y[\u0003\u0010\b\u0000ZY\u0001\u0000\u0000\u0000"+
		"Z[\u0001\u0000\u0000\u0000[\\\u0001\u0000\u0000\u0000\\`\u0005\u0014\u0000"+
		"\u0000]^\u0003\u001c\u000e\u0000^_\u0003 \u0010\u0000_a\u0001\u0000\u0000"+
		"\u0000`]\u0001\u0000\u0000\u0000`a\u0001\u0000\u0000\u0000a\u000f\u0001"+
		"\u0000\u0000\u0000bg\u0003\u0012\t\u0000cd\u0005\t\u0000\u0000df\u0003"+
		"\u0012\t\u0000ec\u0001\u0000\u0000\u0000fi\u0001\u0000\u0000\u0000ge\u0001"+
		"\u0000\u0000\u0000gh\u0001\u0000\u0000\u0000h\u0011\u0001\u0000\u0000"+
		"\u0000ig\u0001\u0000\u0000\u0000jm\u0003\u0018\f\u0000kl\u0005\b\u0000"+
		"\u0000ln\u0003\u0014\n\u0000mk\u0001\u0000\u0000\u0000mn\u0001\u0000\u0000"+
		"\u0000n\u0013\u0001\u0000\u0000\u0000ot\u0003\u0016\u000b\u0000pq\u0005"+
		"\u0006\u0000\u0000qs\u0003\u0016\u000b\u0000rp\u0001\u0000\u0000\u0000"+
		"sv\u0001\u0000\u0000\u0000tr\u0001\u0000\u0000\u0000tu\u0001\u0000\u0000"+
		"\u0000u\u0015\u0001\u0000\u0000\u0000vt\u0001\u0000\u0000\u0000wy\u0005"+
		"\u0001\u0000\u0000xw\u0001\u0000\u0000\u0000xy\u0001\u0000\u0000\u0000"+
		"yz\u0001\u0000\u0000\u0000z}\u0003\u0018\f\u0000{}\u0003\u001a\r\u0000"+
		"|x\u0001\u0000\u0000\u0000|{\u0001\u0000\u0000\u0000}\u0017\u0001\u0000"+
		"\u0000\u0000~\u0080\u0005\f\u0000\u0000\u007f~\u0001\u0000\u0000\u0000"+
		"\u007f\u0080\u0001\u0000\u0000\u0000\u0080\u0081\u0001\u0000\u0000\u0000"+
		"\u0081\u0087\u0005\u0003\u0000\u0000\u0082\u0084\u0005\u000f\u0000\u0000"+
		"\u0083\u0085\u0003\u001e\u000f\u0000\u0084\u0083\u0001\u0000\u0000\u0000"+
		"\u0084\u0085\u0001\u0000\u0000\u0000\u0085\u0086\u0001\u0000\u0000\u0000"+
		"\u0086\u0088\u0005\u0010\u0000\u0000\u0087\u0082\u0001\u0000\u0000\u0000"+
		"\u0087\u0088\u0001\u0000\u0000\u0000\u0088\u0019\u0001\u0000\u0000\u0000"+
		"\u0089\u008a\u0003 \u0010\u0000\u008a\u008b\u0003\u001c\u000e\u0000\u008b"+
		"\u008c\u0003 \u0010\u0000\u008c\u001b\u0001\u0000\u0000\u0000\u008d\u008e"+
		"\u0007\u0000\u0000\u0000\u008e\u001d\u0001\u0000\u0000\u0000\u008f\u0094"+
		"\u0003 \u0010\u0000\u0090\u0091\u0005\u0006\u0000\u0000\u0091\u0093\u0003"+
		" \u0010\u0000\u0092\u0090\u0001\u0000\u0000\u0000\u0093\u0096\u0001\u0000"+
		"\u0000\u0000\u0094\u0092\u0001\u0000\u0000\u0000\u0094\u0095\u0001\u0000"+
		"\u0000\u0000\u0095\u001f\u0001\u0000\u0000\u0000\u0096\u0094\u0001\u0000"+
		"\u0000\u0000\u0097\u0098\u0006\u0010\uffff\uffff\u0000\u0098\u009d\u0005"+
		"\u0003\u0000\u0000\u0099\u009a\u0005\u000f\u0000\u0000\u009a\u009b\u0003"+
		"\u001e\u000f\u0000\u009b\u009c\u0005\u0010\u0000\u0000\u009c\u009e\u0001"+
		"\u0000\u0000\u0000\u009d\u0099\u0001\u0000\u0000\u0000\u009d\u009e\u0001"+
		"\u0000\u0000\u0000\u009e\u00a9\u0001\u0000\u0000\u0000\u009f\u00a1\u0005"+
		"\f\u0000\u0000\u00a0\u009f\u0001\u0000\u0000\u0000\u00a0\u00a1\u0001\u0000"+
		"\u0000\u0000\u00a1\u00a2\u0001\u0000\u0000\u0000\u00a2\u00a9\u0005\u0002"+
		"\u0000\u0000\u00a3\u00a9\u0005\u0004\u0000\u0000\u00a4\u00a5\u0005\u000f"+
		"\u0000\u0000\u00a5\u00a6\u0003 \u0010\u0000\u00a6\u00a7\u0005\u0010\u0000"+
		"\u0000\u00a7\u00a9\u0001\u0000\u0000\u0000\u00a8\u0097\u0001\u0000\u0000"+
		"\u0000\u00a8\u00a0\u0001\u0000\u0000\u0000\u00a8\u00a3\u0001\u0000\u0000"+
		"\u0000\u00a8\u00a4\u0001\u0000\u0000\u0000\u00a9\u00b0\u0001\u0000\u0000"+
		"\u0000\u00aa\u00ab\n\u0001\u0000\u0000\u00ab\u00ac\u0003\"\u0011\u0000"+
		"\u00ac\u00ad\u0003 \u0010\u0002\u00ad\u00af\u0001\u0000\u0000\u0000\u00ae"+
		"\u00aa\u0001\u0000\u0000\u0000\u00af\u00b2\u0001\u0000\u0000\u0000\u00b0"+
		"\u00ae\u0001\u0000\u0000\u0000\u00b0\u00b1\u0001\u0000\u0000\u0000\u00b1"+
		"!\u0001\u0000\u0000\u0000\u00b2\u00b0\u0001\u0000\u0000\u0000\u00b3\u00b4"+
		"\u0007\u0001\u0000\u0000\u00b4#\u0001\u0000\u0000\u0000\u0019&)/7<?CG"+
		"NVZ`gmtx|\u007f\u0084\u0087\u0094\u009d\u00a0\u00a8\u00b0";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}