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
		NAF=1, NUMBER=2, ID=3, VARIABLE=4, DOT=5, DOTDOT=6, COMMA=7, QUERY_MARK=8, 
		COLON=9, SEMICOLON=10, CONS=11, PLUS=12, MINUS=13, TIMES=14, DIV=15, PAREN_OPEN=16, 
		PAREN_CLOSE=17, SQUARE_OPEN=18, SQUARE_CLOSE=19, CURLY_OPEN=20, CURLY_CLOSE=21, 
		EQUAL=22, UNEQUAL=23, LESS=24, GREATER=25, LESS_OR_EQ=26, GREATER_OR_EQ=27, 
		LINE_COMMENT=28, WS=29;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"NAF", "NUMBER", "ID", "VARIABLE", "DOT", "DOTDOT", "COMMA", "QUERY_MARK", 
			"COLON", "SEMICOLON", "CONS", "PLUS", "MINUS", "TIMES", "DIV", "PAREN_OPEN", 
			"PAREN_CLOSE", "SQUARE_OPEN", "SQUARE_CLOSE", "CURLY_OPEN", "CURLY_CLOSE", 
			"EQUAL", "UNEQUAL", "LESS", "GREATER", "LESS_OR_EQ", "GREATER_OR_EQ", 
			"LINE_COMMENT", "WS"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'not'", null, null, null, "'.'", "'..'", "','", "'?'", "':'", 
			"';'", "':-'", "'+'", "'-'", "'*'", "'/'", "'('", "')'", "'['", "']'", 
			"'{'", "'}'", "'='", null, "'<'", "'>'", "'<='", "'>='"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, "NAF", "NUMBER", "ID", "VARIABLE", "DOT", "DOTDOT", "COMMA", "QUERY_MARK", 
			"COLON", "SEMICOLON", "CONS", "PLUS", "MINUS", "TIMES", "DIV", "PAREN_OPEN", 
			"PAREN_CLOSE", "SQUARE_OPEN", "SQUARE_CLOSE", "CURLY_OPEN", "CURLY_CLOSE", 
			"EQUAL", "UNEQUAL", "LESS", "GREATER", "LESS_OR_EQ", "GREATER_OR_EQ", 
			"LINE_COMMENT", "WS"
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
		"\u0004\u0000\u001d\u009d\u0006\uffff\uffff\u0002\u0000\u0007\u0000\u0002"+
		"\u0001\u0007\u0001\u0002\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002"+
		"\u0004\u0007\u0004\u0002\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002"+
		"\u0007\u0007\u0007\u0002\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002"+
		"\u000b\u0007\u000b\u0002\f\u0007\f\u0002\r\u0007\r\u0002\u000e\u0007\u000e"+
		"\u0002\u000f\u0007\u000f\u0002\u0010\u0007\u0010\u0002\u0011\u0007\u0011"+
		"\u0002\u0012\u0007\u0012\u0002\u0013\u0007\u0013\u0002\u0014\u0007\u0014"+
		"\u0002\u0015\u0007\u0015\u0002\u0016\u0007\u0016\u0002\u0017\u0007\u0017"+
		"\u0002\u0018\u0007\u0018\u0002\u0019\u0007\u0019\u0002\u001a\u0007\u001a"+
		"\u0002\u001b\u0007\u001b\u0002\u001c\u0007\u001c\u0001\u0000\u0001\u0000"+
		"\u0001\u0000\u0001\u0000\u0001\u0001\u0001\u0001\u0001\u0001\u0005\u0001"+
		"C\b\u0001\n\u0001\f\u0001F\t\u0001\u0003\u0001H\b\u0001\u0001\u0002\u0001"+
		"\u0002\u0005\u0002L\b\u0002\n\u0002\f\u0002O\t\u0002\u0001\u0003\u0001"+
		"\u0003\u0005\u0003S\b\u0003\n\u0003\f\u0003V\t\u0003\u0001\u0004\u0001"+
		"\u0004\u0001\u0005\u0001\u0005\u0001\u0005\u0001\u0006\u0001\u0006\u0001"+
		"\u0007\u0001\u0007\u0001\b\u0001\b\u0001\t\u0001\t\u0001\n\u0001\n\u0001"+
		"\n\u0001\u000b\u0001\u000b\u0001\f\u0001\f\u0001\r\u0001\r\u0001\u000e"+
		"\u0001\u000e\u0001\u000f\u0001\u000f\u0001\u0010\u0001\u0010\u0001\u0011"+
		"\u0001\u0011\u0001\u0012\u0001\u0012\u0001\u0013\u0001\u0013\u0001\u0014"+
		"\u0001\u0014\u0001\u0015\u0001\u0015\u0001\u0016\u0001\u0016\u0001\u0016"+
		"\u0001\u0016\u0003\u0016\u0082\b\u0016\u0001\u0017\u0001\u0017\u0001\u0018"+
		"\u0001\u0018\u0001\u0019\u0001\u0019\u0001\u0019\u0001\u001a\u0001\u001a"+
		"\u0001\u001a\u0001\u001b\u0001\u001b\u0005\u001b\u0090\b\u001b\n\u001b"+
		"\f\u001b\u0093\t\u001b\u0001\u001b\u0001\u001b\u0001\u001c\u0004\u001c"+
		"\u0098\b\u001c\u000b\u001c\f\u001c\u0099\u0001\u001c\u0001\u001c\u0000"+
		"\u0000\u001d\u0001\u0001\u0003\u0002\u0005\u0003\u0007\u0004\t\u0005\u000b"+
		"\u0006\r\u0007\u000f\b\u0011\t\u0013\n\u0015\u000b\u0017\f\u0019\r\u001b"+
		"\u000e\u001d\u000f\u001f\u0010!\u0011#\u0012%\u0013\'\u0014)\u0015+\u0016"+
		"-\u0017/\u00181\u00193\u001a5\u001b7\u001c9\u001d\u0001\u0000\b\u0001"+
		"\u000019\u0001\u000009\u0001\u0000az\u0003\u0000AZ__az\u0001\u0000AZ\u0004"+
		"\u000009AZ__az\u0002\u0000\n\n\r\r\u0003\u0000\t\n\r\r  \u00a3\u0000\u0001"+
		"\u0001\u0000\u0000\u0000\u0000\u0003\u0001\u0000\u0000\u0000\u0000\u0005"+
		"\u0001\u0000\u0000\u0000\u0000\u0007\u0001\u0000\u0000\u0000\u0000\t\u0001"+
		"\u0000\u0000\u0000\u0000\u000b\u0001\u0000\u0000\u0000\u0000\r\u0001\u0000"+
		"\u0000\u0000\u0000\u000f\u0001\u0000\u0000\u0000\u0000\u0011\u0001\u0000"+
		"\u0000\u0000\u0000\u0013\u0001\u0000\u0000\u0000\u0000\u0015\u0001\u0000"+
		"\u0000\u0000\u0000\u0017\u0001\u0000\u0000\u0000\u0000\u0019\u0001\u0000"+
		"\u0000\u0000\u0000\u001b\u0001\u0000\u0000\u0000\u0000\u001d\u0001\u0000"+
		"\u0000\u0000\u0000\u001f\u0001\u0000\u0000\u0000\u0000!\u0001\u0000\u0000"+
		"\u0000\u0000#\u0001\u0000\u0000\u0000\u0000%\u0001\u0000\u0000\u0000\u0000"+
		"\'\u0001\u0000\u0000\u0000\u0000)\u0001\u0000\u0000\u0000\u0000+\u0001"+
		"\u0000\u0000\u0000\u0000-\u0001\u0000\u0000\u0000\u0000/\u0001\u0000\u0000"+
		"\u0000\u00001\u0001\u0000\u0000\u0000\u00003\u0001\u0000\u0000\u0000\u0000"+
		"5\u0001\u0000\u0000\u0000\u00007\u0001\u0000\u0000\u0000\u00009\u0001"+
		"\u0000\u0000\u0000\u0001;\u0001\u0000\u0000\u0000\u0003G\u0001\u0000\u0000"+
		"\u0000\u0005I\u0001\u0000\u0000\u0000\u0007P\u0001\u0000\u0000\u0000\t"+
		"W\u0001\u0000\u0000\u0000\u000bY\u0001\u0000\u0000\u0000\r\\\u0001\u0000"+
		"\u0000\u0000\u000f^\u0001\u0000\u0000\u0000\u0011`\u0001\u0000\u0000\u0000"+
		"\u0013b\u0001\u0000\u0000\u0000\u0015d\u0001\u0000\u0000\u0000\u0017g"+
		"\u0001\u0000\u0000\u0000\u0019i\u0001\u0000\u0000\u0000\u001bk\u0001\u0000"+
		"\u0000\u0000\u001dm\u0001\u0000\u0000\u0000\u001fo\u0001\u0000\u0000\u0000"+
		"!q\u0001\u0000\u0000\u0000#s\u0001\u0000\u0000\u0000%u\u0001\u0000\u0000"+
		"\u0000\'w\u0001\u0000\u0000\u0000)y\u0001\u0000\u0000\u0000+{\u0001\u0000"+
		"\u0000\u0000-\u0081\u0001\u0000\u0000\u0000/\u0083\u0001\u0000\u0000\u0000"+
		"1\u0085\u0001\u0000\u0000\u00003\u0087\u0001\u0000\u0000\u00005\u008a"+
		"\u0001\u0000\u0000\u00007\u008d\u0001\u0000\u0000\u00009\u0097\u0001\u0000"+
		"\u0000\u0000;<\u0005n\u0000\u0000<=\u0005o\u0000\u0000=>\u0005t\u0000"+
		"\u0000>\u0002\u0001\u0000\u0000\u0000?H\u00050\u0000\u0000@D\u0007\u0000"+
		"\u0000\u0000AC\u0007\u0001\u0000\u0000BA\u0001\u0000\u0000\u0000CF\u0001"+
		"\u0000\u0000\u0000DB\u0001\u0000\u0000\u0000DE\u0001\u0000\u0000\u0000"+
		"EH\u0001\u0000\u0000\u0000FD\u0001\u0000\u0000\u0000G?\u0001\u0000\u0000"+
		"\u0000G@\u0001\u0000\u0000\u0000H\u0004\u0001\u0000\u0000\u0000IM\u0007"+
		"\u0002\u0000\u0000JL\u0007\u0003\u0000\u0000KJ\u0001\u0000\u0000\u0000"+
		"LO\u0001\u0000\u0000\u0000MK\u0001\u0000\u0000\u0000MN\u0001\u0000\u0000"+
		"\u0000N\u0006\u0001\u0000\u0000\u0000OM\u0001\u0000\u0000\u0000PT\u0007"+
		"\u0004\u0000\u0000QS\u0007\u0005\u0000\u0000RQ\u0001\u0000\u0000\u0000"+
		"SV\u0001\u0000\u0000\u0000TR\u0001\u0000\u0000\u0000TU\u0001\u0000\u0000"+
		"\u0000U\b\u0001\u0000\u0000\u0000VT\u0001\u0000\u0000\u0000WX\u0005.\u0000"+
		"\u0000X\n\u0001\u0000\u0000\u0000YZ\u0005.\u0000\u0000Z[\u0005.\u0000"+
		"\u0000[\f\u0001\u0000\u0000\u0000\\]\u0005,\u0000\u0000]\u000e\u0001\u0000"+
		"\u0000\u0000^_\u0005?\u0000\u0000_\u0010\u0001\u0000\u0000\u0000`a\u0005"+
		":\u0000\u0000a\u0012\u0001\u0000\u0000\u0000bc\u0005;\u0000\u0000c\u0014"+
		"\u0001\u0000\u0000\u0000de\u0005:\u0000\u0000ef\u0005-\u0000\u0000f\u0016"+
		"\u0001\u0000\u0000\u0000gh\u0005+\u0000\u0000h\u0018\u0001\u0000\u0000"+
		"\u0000ij\u0005-\u0000\u0000j\u001a\u0001\u0000\u0000\u0000kl\u0005*\u0000"+
		"\u0000l\u001c\u0001\u0000\u0000\u0000mn\u0005/\u0000\u0000n\u001e\u0001"+
		"\u0000\u0000\u0000op\u0005(\u0000\u0000p \u0001\u0000\u0000\u0000qr\u0005"+
		")\u0000\u0000r\"\u0001\u0000\u0000\u0000st\u0005[\u0000\u0000t$\u0001"+
		"\u0000\u0000\u0000uv\u0005]\u0000\u0000v&\u0001\u0000\u0000\u0000wx\u0005"+
		"{\u0000\u0000x(\u0001\u0000\u0000\u0000yz\u0005}\u0000\u0000z*\u0001\u0000"+
		"\u0000\u0000{|\u0005=\u0000\u0000|,\u0001\u0000\u0000\u0000}~\u0005<\u0000"+
		"\u0000~\u0082\u0005>\u0000\u0000\u007f\u0080\u0005!\u0000\u0000\u0080"+
		"\u0082\u0005=\u0000\u0000\u0081}\u0001\u0000\u0000\u0000\u0081\u007f\u0001"+
		"\u0000\u0000\u0000\u0082.\u0001\u0000\u0000\u0000\u0083\u0084\u0005<\u0000"+
		"\u0000\u00840\u0001\u0000\u0000\u0000\u0085\u0086\u0005>\u0000\u0000\u0086"+
		"2\u0001\u0000\u0000\u0000\u0087\u0088\u0005<\u0000\u0000\u0088\u0089\u0005"+
		"=\u0000\u0000\u00894\u0001\u0000\u0000\u0000\u008a\u008b\u0005>\u0000"+
		"\u0000\u008b\u008c\u0005=\u0000\u0000\u008c6\u0001\u0000\u0000\u0000\u008d"+
		"\u0091\u0005%\u0000\u0000\u008e\u0090\b\u0006\u0000\u0000\u008f\u008e"+
		"\u0001\u0000\u0000\u0000\u0090\u0093\u0001\u0000\u0000\u0000\u0091\u008f"+
		"\u0001\u0000\u0000\u0000\u0091\u0092\u0001\u0000\u0000\u0000\u0092\u0094"+
		"\u0001\u0000\u0000\u0000\u0093\u0091\u0001\u0000\u0000\u0000\u0094\u0095"+
		"\u0006\u001b\u0000\u0000\u00958\u0001\u0000\u0000\u0000\u0096\u0098\u0007"+
		"\u0007\u0000\u0000\u0097\u0096\u0001\u0000\u0000\u0000\u0098\u0099\u0001"+
		"\u0000\u0000\u0000\u0099\u0097\u0001\u0000\u0000\u0000\u0099\u009a\u0001"+
		"\u0000\u0000\u0000\u009a\u009b\u0001\u0000\u0000\u0000\u009b\u009c\u0006"+
		"\u001c\u0000\u0000\u009c:\u0001\u0000\u0000\u0000\b\u0000DGMT\u0081\u0091"+
		"\u0099\u0001\u0006\u0000\u0000";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}