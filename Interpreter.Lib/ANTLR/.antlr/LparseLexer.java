// Generated from /Users/marvinkoch/Desktop/Desktop - Marvin’s MacBook Pro/asp-interpreter/Interpreter.Lib/ANTLR/Lparse.g4 by ANTLR 4.13.1
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast", "CheckReturnValue", "this-escape"})
public class LparseLexer extends Lexer {
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
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"NAF", "NUMBER", "ID", "VARIABLE", "ANONYMOUS_VARIABLE", "DOT", "COMMA", 
			"QUERY_MARK", "COLON", "SEMICOLON", "OR", "CONS", "PLUS", "MINUS", "TIMES", 
			"DIV", "AT", "PAREN_OPEN", "PAREN_CLOSE", "SQUARE_OPEN", "SQUARE_CLOSE", 
			"CURLY_OPEN", "CURLY_CLOSE", "EQUAL", "UNEQUAL", "LESS", "GREATER", "LESS_OR_EQ", 
			"GREATER_OR_EQ", "COMMENT", "WS"
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


	public LparseLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "Lparse.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\u0004\u0000\u001f\u00a7\u0006\uffff\uffff\u0002\u0000\u0007\u0000\u0002"+
		"\u0001\u0007\u0001\u0002\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002"+
		"\u0004\u0007\u0004\u0002\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002"+
		"\u0007\u0007\u0007\u0002\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002"+
		"\u000b\u0007\u000b\u0002\f\u0007\f\u0002\r\u0007\r\u0002\u000e\u0007\u000e"+
		"\u0002\u000f\u0007\u000f\u0002\u0010\u0007\u0010\u0002\u0011\u0007\u0011"+
		"\u0002\u0012\u0007\u0012\u0002\u0013\u0007\u0013\u0002\u0014\u0007\u0014"+
		"\u0002\u0015\u0007\u0015\u0002\u0016\u0007\u0016\u0002\u0017\u0007\u0017"+
		"\u0002\u0018\u0007\u0018\u0002\u0019\u0007\u0019\u0002\u001a\u0007\u001a"+
		"\u0002\u001b\u0007\u001b\u0002\u001c\u0007\u001c\u0002\u001d\u0007\u001d"+
		"\u0002\u001e\u0007\u001e\u0001\u0000\u0001\u0000\u0001\u0000\u0001\u0000"+
		"\u0001\u0001\u0001\u0001\u0001\u0001\u0005\u0001G\b\u0001\n\u0001\f\u0001"+
		"J\t\u0001\u0003\u0001L\b\u0001\u0001\u0002\u0004\u0002O\b\u0002\u000b"+
		"\u0002\f\u0002P\u0001\u0003\u0001\u0003\u0005\u0003U\b\u0003\n\u0003\f"+
		"\u0003X\t\u0003\u0001\u0004\u0001\u0004\u0001\u0005\u0001\u0005\u0001"+
		"\u0006\u0001\u0006\u0001\u0007\u0001\u0007\u0001\b\u0001\b\u0001\t\u0001"+
		"\t\u0001\n\u0001\n\u0001\u000b\u0001\u000b\u0001\u000b\u0001\f\u0001\f"+
		"\u0001\r\u0001\r\u0001\u000e\u0001\u000e\u0001\u000f\u0001\u000f\u0001"+
		"\u0010\u0001\u0010\u0001\u0011\u0001\u0011\u0001\u0012\u0001\u0012\u0001"+
		"\u0013\u0001\u0013\u0001\u0014\u0001\u0014\u0001\u0015\u0001\u0015\u0001"+
		"\u0016\u0001\u0016\u0001\u0017\u0001\u0017\u0001\u0018\u0001\u0018\u0001"+
		"\u0018\u0001\u0018\u0003\u0018\u0087\b\u0018\u0001\u0019\u0001\u0019\u0001"+
		"\u001a\u0001\u001a\u0001\u001b\u0001\u001b\u0001\u001b\u0001\u001c\u0001"+
		"\u001c\u0001\u001c\u0001\u001d\u0001\u001d\u0005\u001d\u0095\b\u001d\n"+
		"\u001d\f\u001d\u0098\t\u001d\u0001\u001d\u0003\u001d\u009b\b\u001d\u0001"+
		"\u001d\u0001\u001d\u0001\u001d\u0001\u001d\u0001\u001e\u0004\u001e\u00a2"+
		"\b\u001e\u000b\u001e\f\u001e\u00a3\u0001\u001e\u0001\u001e\u0000\u0000"+
		"\u001f\u0001\u0001\u0003\u0002\u0005\u0003\u0007\u0004\t\u0005\u000b\u0006"+
		"\r\u0007\u000f\b\u0011\t\u0013\n\u0015\u000b\u0017\f\u0019\r\u001b\u000e"+
		"\u001d\u000f\u001f\u0010!\u0011#\u0012%\u0013\'\u0014)\u0015+\u0016-\u0017"+
		"/\u00181\u00193\u001a5\u001b7\u001c9\u001d;\u001e=\u001f\u0001\u0000\u0007"+
		"\u0001\u000019\u0001\u000009\u0001\u0000az\u0001\u0000AZ\u0004\u00000"+
		"9AZ__az\u0002\u0000\n\n\r\r\u0003\u0000\t\n\r\r  \u00ae\u0000\u0001\u0001"+
		"\u0000\u0000\u0000\u0000\u0003\u0001\u0000\u0000\u0000\u0000\u0005\u0001"+
		"\u0000\u0000\u0000\u0000\u0007\u0001\u0000\u0000\u0000\u0000\t\u0001\u0000"+
		"\u0000\u0000\u0000\u000b\u0001\u0000\u0000\u0000\u0000\r\u0001\u0000\u0000"+
		"\u0000\u0000\u000f\u0001\u0000\u0000\u0000\u0000\u0011\u0001\u0000\u0000"+
		"\u0000\u0000\u0013\u0001\u0000\u0000\u0000\u0000\u0015\u0001\u0000\u0000"+
		"\u0000\u0000\u0017\u0001\u0000\u0000\u0000\u0000\u0019\u0001\u0000\u0000"+
		"\u0000\u0000\u001b\u0001\u0000\u0000\u0000\u0000\u001d\u0001\u0000\u0000"+
		"\u0000\u0000\u001f\u0001\u0000\u0000\u0000\u0000!\u0001\u0000\u0000\u0000"+
		"\u0000#\u0001\u0000\u0000\u0000\u0000%\u0001\u0000\u0000\u0000\u0000\'"+
		"\u0001\u0000\u0000\u0000\u0000)\u0001\u0000\u0000\u0000\u0000+\u0001\u0000"+
		"\u0000\u0000\u0000-\u0001\u0000\u0000\u0000\u0000/\u0001\u0000\u0000\u0000"+
		"\u00001\u0001\u0000\u0000\u0000\u00003\u0001\u0000\u0000\u0000\u00005"+
		"\u0001\u0000\u0000\u0000\u00007\u0001\u0000\u0000\u0000\u00009\u0001\u0000"+
		"\u0000\u0000\u0000;\u0001\u0000\u0000\u0000\u0000=\u0001\u0000\u0000\u0000"+
		"\u0001?\u0001\u0000\u0000\u0000\u0003K\u0001\u0000\u0000\u0000\u0005N"+
		"\u0001\u0000\u0000\u0000\u0007R\u0001\u0000\u0000\u0000\tY\u0001\u0000"+
		"\u0000\u0000\u000b[\u0001\u0000\u0000\u0000\r]\u0001\u0000\u0000\u0000"+
		"\u000f_\u0001\u0000\u0000\u0000\u0011a\u0001\u0000\u0000\u0000\u0013c"+
		"\u0001\u0000\u0000\u0000\u0015e\u0001\u0000\u0000\u0000\u0017g\u0001\u0000"+
		"\u0000\u0000\u0019j\u0001\u0000\u0000\u0000\u001bl\u0001\u0000\u0000\u0000"+
		"\u001dn\u0001\u0000\u0000\u0000\u001fp\u0001\u0000\u0000\u0000!r\u0001"+
		"\u0000\u0000\u0000#t\u0001\u0000\u0000\u0000%v\u0001\u0000\u0000\u0000"+
		"\'x\u0001\u0000\u0000\u0000)z\u0001\u0000\u0000\u0000+|\u0001\u0000\u0000"+
		"\u0000-~\u0001\u0000\u0000\u0000/\u0080\u0001\u0000\u0000\u00001\u0086"+
		"\u0001\u0000\u0000\u00003\u0088\u0001\u0000\u0000\u00005\u008a\u0001\u0000"+
		"\u0000\u00007\u008c\u0001\u0000\u0000\u00009\u008f\u0001\u0000\u0000\u0000"+
		";\u0092\u0001\u0000\u0000\u0000=\u00a1\u0001\u0000\u0000\u0000?@\u0005"+
		"n\u0000\u0000@A\u0005o\u0000\u0000AB\u0005t\u0000\u0000B\u0002\u0001\u0000"+
		"\u0000\u0000CL\u00050\u0000\u0000DH\u0007\u0000\u0000\u0000EG\u0007\u0001"+
		"\u0000\u0000FE\u0001\u0000\u0000\u0000GJ\u0001\u0000\u0000\u0000HF\u0001"+
		"\u0000\u0000\u0000HI\u0001\u0000\u0000\u0000IL\u0001\u0000\u0000\u0000"+
		"JH\u0001\u0000\u0000\u0000KC\u0001\u0000\u0000\u0000KD\u0001\u0000\u0000"+
		"\u0000L\u0004\u0001\u0000\u0000\u0000MO\u0007\u0002\u0000\u0000NM\u0001"+
		"\u0000\u0000\u0000OP\u0001\u0000\u0000\u0000PN\u0001\u0000\u0000\u0000"+
		"PQ\u0001\u0000\u0000\u0000Q\u0006\u0001\u0000\u0000\u0000RV\u0007\u0003"+
		"\u0000\u0000SU\u0007\u0004\u0000\u0000TS\u0001\u0000\u0000\u0000UX\u0001"+
		"\u0000\u0000\u0000VT\u0001\u0000\u0000\u0000VW\u0001\u0000\u0000\u0000"+
		"W\b\u0001\u0000\u0000\u0000XV\u0001\u0000\u0000\u0000YZ\u0005_\u0000\u0000"+
		"Z\n\u0001\u0000\u0000\u0000[\\\u0005.\u0000\u0000\\\f\u0001\u0000\u0000"+
		"\u0000]^\u0005,\u0000\u0000^\u000e\u0001\u0000\u0000\u0000_`\u0005?\u0000"+
		"\u0000`\u0010\u0001\u0000\u0000\u0000ab\u0005:\u0000\u0000b\u0012\u0001"+
		"\u0000\u0000\u0000cd\u0005;\u0000\u0000d\u0014\u0001\u0000\u0000\u0000"+
		"ef\u0005|\u0000\u0000f\u0016\u0001\u0000\u0000\u0000gh\u0005:\u0000\u0000"+
		"hi\u0005-\u0000\u0000i\u0018\u0001\u0000\u0000\u0000jk\u0005+\u0000\u0000"+
		"k\u001a\u0001\u0000\u0000\u0000lm\u0005-\u0000\u0000m\u001c\u0001\u0000"+
		"\u0000\u0000no\u0005*\u0000\u0000o\u001e\u0001\u0000\u0000\u0000pq\u0005"+
		"/\u0000\u0000q \u0001\u0000\u0000\u0000rs\u0005@\u0000\u0000s\"\u0001"+
		"\u0000\u0000\u0000tu\u0005(\u0000\u0000u$\u0001\u0000\u0000\u0000vw\u0005"+
		")\u0000\u0000w&\u0001\u0000\u0000\u0000xy\u0005[\u0000\u0000y(\u0001\u0000"+
		"\u0000\u0000z{\u0005]\u0000\u0000{*\u0001\u0000\u0000\u0000|}\u0005{\u0000"+
		"\u0000},\u0001\u0000\u0000\u0000~\u007f\u0005}\u0000\u0000\u007f.\u0001"+
		"\u0000\u0000\u0000\u0080\u0081\u0005=\u0000\u0000\u00810\u0001\u0000\u0000"+
		"\u0000\u0082\u0083\u0005<\u0000\u0000\u0083\u0087\u0005>\u0000\u0000\u0084"+
		"\u0085\u0005!\u0000\u0000\u0085\u0087\u0005=\u0000\u0000\u0086\u0082\u0001"+
		"\u0000\u0000\u0000\u0086\u0084\u0001\u0000\u0000\u0000\u00872\u0001\u0000"+
		"\u0000\u0000\u0088\u0089\u0005<\u0000\u0000\u00894\u0001\u0000\u0000\u0000"+
		"\u008a\u008b\u0005>\u0000\u0000\u008b6\u0001\u0000\u0000\u0000\u008c\u008d"+
		"\u0005<\u0000\u0000\u008d\u008e\u0005=\u0000\u0000\u008e8\u0001\u0000"+
		"\u0000\u0000\u008f\u0090\u0005>\u0000\u0000\u0090\u0091\u0005=\u0000\u0000"+
		"\u0091:\u0001\u0000\u0000\u0000\u0092\u0096\u0005%\u0000\u0000\u0093\u0095"+
		"\b\u0005\u0000\u0000\u0094\u0093\u0001\u0000\u0000\u0000\u0095\u0098\u0001"+
		"\u0000\u0000\u0000\u0096\u0094\u0001\u0000\u0000\u0000\u0096\u0097\u0001"+
		"\u0000\u0000\u0000\u0097\u009a\u0001\u0000\u0000\u0000\u0098\u0096\u0001"+
		"\u0000\u0000\u0000\u0099\u009b\u0005\r\u0000\u0000\u009a\u0099\u0001\u0000"+
		"\u0000\u0000\u009a\u009b\u0001\u0000\u0000\u0000\u009b\u009c\u0001\u0000"+
		"\u0000\u0000\u009c\u009d\u0005\n\u0000\u0000\u009d\u009e\u0001\u0000\u0000"+
		"\u0000\u009e\u009f\u0006\u001d\u0000\u0000\u009f<\u0001\u0000\u0000\u0000"+
		"\u00a0\u00a2\u0007\u0006\u0000\u0000\u00a1\u00a0\u0001\u0000\u0000\u0000"+
		"\u00a2\u00a3\u0001\u0000\u0000\u0000\u00a3\u00a1\u0001\u0000\u0000\u0000"+
		"\u00a3\u00a4\u0001\u0000\u0000\u0000\u00a4\u00a5\u0001\u0000\u0000\u0000"+
		"\u00a5\u00a6\u0006\u001e\u0000\u0000\u00a6>\u0001\u0000\u0000\u0000\t"+
		"\u0000HKPV\u0086\u0096\u009a\u00a3\u0001\u0006\u0000\u0000";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}