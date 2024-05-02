// Generated from /Users/marvinkoch/Desktop/asp-interpreter/Interpreter.Lib/ANTLR/lparse.g4 by ANTLR 4.13.1
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
		NAF=1, IS=2, NUMBER=3, ID=4, VARIABLE=5, DOT=6, DOTDOT=7, COMMA=8, QUERY_MARK=9, 
		COLON=10, SEMICOLON=11, CONS=12, PLUS=13, MINUS=14, TIMES=15, DIV=16, 
		PAREN_OPEN=17, PAREN_CLOSE=18, SQUARE_OPEN=19, SQUARE_CLOSE=20, CURLY_OPEN=21, 
		CURLY_CLOSE=22, UNIFICATION=23, EQUAL=24, UNEQUAL=25, LESS=26, GREATER=27, 
		LESS_OR_EQ=28, GREATER_OR_EQ=29, LINE_COMMENT=30, WS=31;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"NAF", "IS", "NUMBER", "ID", "VARIABLE", "DOT", "DOTDOT", "COMMA", "QUERY_MARK", 
			"COLON", "SEMICOLON", "CONS", "PLUS", "MINUS", "TIMES", "DIV", "PAREN_OPEN", 
			"PAREN_CLOSE", "SQUARE_OPEN", "SQUARE_CLOSE", "CURLY_OPEN", "CURLY_CLOSE", 
			"UNIFICATION", "EQUAL", "UNEQUAL", "LESS", "GREATER", "LESS_OR_EQ", "GREATER_OR_EQ", 
			"LINE_COMMENT", "WS"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'not'", "'is'", null, null, null, "'.'", "'..'", "','", "'?'", 
			"':'", "';'", "':-'", "'+'", "'-'", "'*'", "'/'", "'('", "')'", "'['", 
			"']'", "'{'", "'}'", "'='", "'=='", null, "'<'", "'>'", "'<='", "'>='"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "NAF", "IS", "NUMBER", "ID", "VARIABLE", "DOT", "DOTDOT", "COMMA", 
			"QUERY_MARK", "COLON", "SEMICOLON", "CONS", "PLUS", "MINUS", "TIMES", 
			"DIV", "PAREN_OPEN", "PAREN_CLOSE", "SQUARE_OPEN", "SQUARE_CLOSE", "CURLY_OPEN", 
			"CURLY_CLOSE", "UNIFICATION", "EQUAL", "UNEQUAL", "LESS", "GREATER", 
			"LESS_OR_EQ", "GREATER_OR_EQ", "LINE_COMMENT", "WS"
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
	public String getGrammarFileName() { return "lparse.g4"; }

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
		"\u0001\u0001\u0001\u0001\u0001\u0001\u0001\u0002\u0001\u0002\u0001\u0002"+
		"\u0005\u0002J\b\u0002\n\u0002\f\u0002M\t\u0002\u0003\u0002O\b\u0002\u0001"+
		"\u0003\u0001\u0003\u0005\u0003S\b\u0003\n\u0003\f\u0003V\t\u0003\u0001"+
		"\u0004\u0001\u0004\u0005\u0004Z\b\u0004\n\u0004\f\u0004]\t\u0004\u0001"+
		"\u0005\u0001\u0005\u0001\u0006\u0001\u0006\u0001\u0006\u0001\u0007\u0001"+
		"\u0007\u0001\b\u0001\b\u0001\t\u0001\t\u0001\n\u0001\n\u0001\u000b\u0001"+
		"\u000b\u0001\u000b\u0001\f\u0001\f\u0001\r\u0001\r\u0001\u000e\u0001\u000e"+
		"\u0001\u000f\u0001\u000f\u0001\u0010\u0001\u0010\u0001\u0011\u0001\u0011"+
		"\u0001\u0012\u0001\u0012\u0001\u0013\u0001\u0013\u0001\u0014\u0001\u0014"+
		"\u0001\u0015\u0001\u0015\u0001\u0016\u0001\u0016\u0001\u0017\u0001\u0017"+
		"\u0001\u0017\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0018\u0003\u0018"+
		"\u008c\b\u0018\u0001\u0019\u0001\u0019\u0001\u001a\u0001\u001a\u0001\u001b"+
		"\u0001\u001b\u0001\u001b\u0001\u001c\u0001\u001c\u0001\u001c\u0001\u001d"+
		"\u0001\u001d\u0005\u001d\u009a\b\u001d\n\u001d\f\u001d\u009d\t\u001d\u0001"+
		"\u001d\u0001\u001d\u0001\u001e\u0004\u001e\u00a2\b\u001e\u000b\u001e\f"+
		"\u001e\u00a3\u0001\u001e\u0001\u001e\u0000\u0000\u001f\u0001\u0001\u0003"+
		"\u0002\u0005\u0003\u0007\u0004\t\u0005\u000b\u0006\r\u0007\u000f\b\u0011"+
		"\t\u0013\n\u0015\u000b\u0017\f\u0019\r\u001b\u000e\u001d\u000f\u001f\u0010"+
		"!\u0011#\u0012%\u0013\'\u0014)\u0015+\u0016-\u0017/\u00181\u00193\u001a"+
		"5\u001b7\u001c9\u001d;\u001e=\u001f\u0001\u0000\b\u0001\u000019\u0001"+
		"\u000009\u0001\u0000az\u0003\u0000AZ__az\u0001\u0000AZ\u0004\u000009A"+
		"Z__az\u0002\u0000\n\n\r\r\u0003\u0000\t\n\r\r  \u00ad\u0000\u0001\u0001"+
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
		"\u0001?\u0001\u0000\u0000\u0000\u0003C\u0001\u0000\u0000\u0000\u0005N"+
		"\u0001\u0000\u0000\u0000\u0007P\u0001\u0000\u0000\u0000\tW\u0001\u0000"+
		"\u0000\u0000\u000b^\u0001\u0000\u0000\u0000\r`\u0001\u0000\u0000\u0000"+
		"\u000fc\u0001\u0000\u0000\u0000\u0011e\u0001\u0000\u0000\u0000\u0013g"+
		"\u0001\u0000\u0000\u0000\u0015i\u0001\u0000\u0000\u0000\u0017k\u0001\u0000"+
		"\u0000\u0000\u0019n\u0001\u0000\u0000\u0000\u001bp\u0001\u0000\u0000\u0000"+
		"\u001dr\u0001\u0000\u0000\u0000\u001ft\u0001\u0000\u0000\u0000!v\u0001"+
		"\u0000\u0000\u0000#x\u0001\u0000\u0000\u0000%z\u0001\u0000\u0000\u0000"+
		"\'|\u0001\u0000\u0000\u0000)~\u0001\u0000\u0000\u0000+\u0080\u0001\u0000"+
		"\u0000\u0000-\u0082\u0001\u0000\u0000\u0000/\u0084\u0001\u0000\u0000\u0000"+
		"1\u008b\u0001\u0000\u0000\u00003\u008d\u0001\u0000\u0000\u00005\u008f"+
		"\u0001\u0000\u0000\u00007\u0091\u0001\u0000\u0000\u00009\u0094\u0001\u0000"+
		"\u0000\u0000;\u0097\u0001\u0000\u0000\u0000=\u00a1\u0001\u0000\u0000\u0000"+
		"?@\u0005n\u0000\u0000@A\u0005o\u0000\u0000AB\u0005t\u0000\u0000B\u0002"+
		"\u0001\u0000\u0000\u0000CD\u0005i\u0000\u0000DE\u0005s\u0000\u0000E\u0004"+
		"\u0001\u0000\u0000\u0000FO\u00050\u0000\u0000GK\u0007\u0000\u0000\u0000"+
		"HJ\u0007\u0001\u0000\u0000IH\u0001\u0000\u0000\u0000JM\u0001\u0000\u0000"+
		"\u0000KI\u0001\u0000\u0000\u0000KL\u0001\u0000\u0000\u0000LO\u0001\u0000"+
		"\u0000\u0000MK\u0001\u0000\u0000\u0000NF\u0001\u0000\u0000\u0000NG\u0001"+
		"\u0000\u0000\u0000O\u0006\u0001\u0000\u0000\u0000PT\u0007\u0002\u0000"+
		"\u0000QS\u0007\u0003\u0000\u0000RQ\u0001\u0000\u0000\u0000SV\u0001\u0000"+
		"\u0000\u0000TR\u0001\u0000\u0000\u0000TU\u0001\u0000\u0000\u0000U\b\u0001"+
		"\u0000\u0000\u0000VT\u0001\u0000\u0000\u0000W[\u0007\u0004\u0000\u0000"+
		"XZ\u0007\u0005\u0000\u0000YX\u0001\u0000\u0000\u0000Z]\u0001\u0000\u0000"+
		"\u0000[Y\u0001\u0000\u0000\u0000[\\\u0001\u0000\u0000\u0000\\\n\u0001"+
		"\u0000\u0000\u0000][\u0001\u0000\u0000\u0000^_\u0005.\u0000\u0000_\f\u0001"+
		"\u0000\u0000\u0000`a\u0005.\u0000\u0000ab\u0005.\u0000\u0000b\u000e\u0001"+
		"\u0000\u0000\u0000cd\u0005,\u0000\u0000d\u0010\u0001\u0000\u0000\u0000"+
		"ef\u0005?\u0000\u0000f\u0012\u0001\u0000\u0000\u0000gh\u0005:\u0000\u0000"+
		"h\u0014\u0001\u0000\u0000\u0000ij\u0005;\u0000\u0000j\u0016\u0001\u0000"+
		"\u0000\u0000kl\u0005:\u0000\u0000lm\u0005-\u0000\u0000m\u0018\u0001\u0000"+
		"\u0000\u0000no\u0005+\u0000\u0000o\u001a\u0001\u0000\u0000\u0000pq\u0005"+
		"-\u0000\u0000q\u001c\u0001\u0000\u0000\u0000rs\u0005*\u0000\u0000s\u001e"+
		"\u0001\u0000\u0000\u0000tu\u0005/\u0000\u0000u \u0001\u0000\u0000\u0000"+
		"vw\u0005(\u0000\u0000w\"\u0001\u0000\u0000\u0000xy\u0005)\u0000\u0000"+
		"y$\u0001\u0000\u0000\u0000z{\u0005[\u0000\u0000{&\u0001\u0000\u0000\u0000"+
		"|}\u0005]\u0000\u0000}(\u0001\u0000\u0000\u0000~\u007f\u0005{\u0000\u0000"+
		"\u007f*\u0001\u0000\u0000\u0000\u0080\u0081\u0005}\u0000\u0000\u0081,"+
		"\u0001\u0000\u0000\u0000\u0082\u0083\u0005=\u0000\u0000\u0083.\u0001\u0000"+
		"\u0000\u0000\u0084\u0085\u0005=\u0000\u0000\u0085\u0086\u0005=\u0000\u0000"+
		"\u00860\u0001\u0000\u0000\u0000\u0087\u0088\u0005<\u0000\u0000\u0088\u008c"+
		"\u0005>\u0000\u0000\u0089\u008a\u0005!\u0000\u0000\u008a\u008c\u0005="+
		"\u0000\u0000\u008b\u0087\u0001\u0000\u0000\u0000\u008b\u0089\u0001\u0000"+
		"\u0000\u0000\u008c2\u0001\u0000\u0000\u0000\u008d\u008e\u0005<\u0000\u0000"+
		"\u008e4\u0001\u0000\u0000\u0000\u008f\u0090\u0005>\u0000\u0000\u00906"+
		"\u0001\u0000\u0000\u0000\u0091\u0092\u0005<\u0000\u0000\u0092\u0093\u0005"+
		"=\u0000\u0000\u00938\u0001\u0000\u0000\u0000\u0094\u0095\u0005>\u0000"+
		"\u0000\u0095\u0096\u0005=\u0000\u0000\u0096:\u0001\u0000\u0000\u0000\u0097"+
		"\u009b\u0005%\u0000\u0000\u0098\u009a\b\u0006\u0000\u0000\u0099\u0098"+
		"\u0001\u0000\u0000\u0000\u009a\u009d\u0001\u0000\u0000\u0000\u009b\u0099"+
		"\u0001\u0000\u0000\u0000\u009b\u009c\u0001\u0000\u0000\u0000\u009c\u009e"+
		"\u0001\u0000\u0000\u0000\u009d\u009b\u0001\u0000\u0000\u0000\u009e\u009f"+
		"\u0006\u001d\u0000\u0000\u009f<\u0001\u0000\u0000\u0000\u00a0\u00a2\u0007"+
		"\u0007\u0000\u0000\u00a1\u00a0\u0001\u0000\u0000\u0000\u00a2\u00a3\u0001"+
		"\u0000\u0000\u0000\u00a3\u00a1\u0001\u0000\u0000\u0000\u00a3\u00a4\u0001"+
		"\u0000\u0000\u0000\u00a4\u00a5\u0001\u0000\u0000\u0000\u00a5\u00a6\u0006"+
		"\u001e\u0000\u0000\u00a6>\u0001\u0000\u0000\u0000\b\u0000KNT[\u008b\u009b"+
		"\u00a3\u0001\u0006\u0000\u0000";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}