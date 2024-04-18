// Generated from /Users/marvinkoch/Desktop/asp-interpreter/Interpreter.Lib/ANTLR/Lparse.g4 by ANTLR 4.13.1
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
		NAF=1, NUMBER=2, ID=3, VARIABLE=4, DOT=5, COMMA=6, QUERY_MARK=7, COLON=8, 
		SEMICOLON=9, CONS=10, PLUS=11, MINUS=12, TIMES=13, DIV=14, PAREN_OPEN=15, 
		PAREN_CLOSE=16, SQUARE_OPEN=17, SQUARE_CLOSE=18, CURLY_OPEN=19, CURLY_CLOSE=20, 
		EQUAL=21, UNEQUAL=22, LESS=23, GREATER=24, LESS_OR_EQ=25, GREATER_OR_EQ=26, 
		COMMENT=27, WS=28;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"NAF", "NUMBER", "ID", "VARIABLE", "DOT", "COMMA", "QUERY_MARK", "COLON", 
			"SEMICOLON", "CONS", "PLUS", "MINUS", "TIMES", "DIV", "PAREN_OPEN", "PAREN_CLOSE", 
			"SQUARE_OPEN", "SQUARE_CLOSE", "CURLY_OPEN", "CURLY_CLOSE", "EQUAL", 
			"UNEQUAL", "LESS", "GREATER", "LESS_OR_EQ", "GREATER_OR_EQ", "COMMENT", 
			"WS"
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
		"\u0004\u0000\u001c\u009d\u0006\uffff\uffff\u0002\u0000\u0007\u0000\u0002"+
		"\u0001\u0007\u0001\u0002\u0002\u0007\u0002\u0002\u0003\u0007\u0003\u0002"+
		"\u0004\u0007\u0004\u0002\u0005\u0007\u0005\u0002\u0006\u0007\u0006\u0002"+
		"\u0007\u0007\u0007\u0002\b\u0007\b\u0002\t\u0007\t\u0002\n\u0007\n\u0002"+
		"\u000b\u0007\u000b\u0002\f\u0007\f\u0002\r\u0007\r\u0002\u000e\u0007\u000e"+
		"\u0002\u000f\u0007\u000f\u0002\u0010\u0007\u0010\u0002\u0011\u0007\u0011"+
		"\u0002\u0012\u0007\u0012\u0002\u0013\u0007\u0013\u0002\u0014\u0007\u0014"+
		"\u0002\u0015\u0007\u0015\u0002\u0016\u0007\u0016\u0002\u0017\u0007\u0017"+
		"\u0002\u0018\u0007\u0018\u0002\u0019\u0007\u0019\u0002\u001a\u0007\u001a"+
		"\u0002\u001b\u0007\u001b\u0001\u0000\u0001\u0000\u0001\u0000\u0001\u0000"+
		"\u0001\u0001\u0001\u0001\u0001\u0001\u0005\u0001A\b\u0001\n\u0001\f\u0001"+
		"D\t\u0001\u0003\u0001F\b\u0001\u0001\u0002\u0001\u0002\u0005\u0002J\b"+
		"\u0002\n\u0002\f\u0002M\t\u0002\u0001\u0003\u0001\u0003\u0005\u0003Q\b"+
		"\u0003\n\u0003\f\u0003T\t\u0003\u0001\u0004\u0001\u0004\u0001\u0005\u0001"+
		"\u0005\u0001\u0006\u0001\u0006\u0001\u0007\u0001\u0007\u0001\b\u0001\b"+
		"\u0001\t\u0001\t\u0001\t\u0001\n\u0001\n\u0001\u000b\u0001\u000b\u0001"+
		"\f\u0001\f\u0001\r\u0001\r\u0001\u000e\u0001\u000e\u0001\u000f\u0001\u000f"+
		"\u0001\u0010\u0001\u0010\u0001\u0011\u0001\u0011\u0001\u0012\u0001\u0012"+
		"\u0001\u0013\u0001\u0013\u0001\u0014\u0001\u0014\u0001\u0015\u0001\u0015"+
		"\u0001\u0015\u0001\u0015\u0003\u0015}\b\u0015\u0001\u0016\u0001\u0016"+
		"\u0001\u0017\u0001\u0017\u0001\u0018\u0001\u0018\u0001\u0018\u0001\u0019"+
		"\u0001\u0019\u0001\u0019\u0001\u001a\u0001\u001a\u0005\u001a\u008b\b\u001a"+
		"\n\u001a\f\u001a\u008e\t\u001a\u0001\u001a\u0003\u001a\u0091\b\u001a\u0001"+
		"\u001a\u0001\u001a\u0001\u001a\u0001\u001a\u0001\u001b\u0004\u001b\u0098"+
		"\b\u001b\u000b\u001b\f\u001b\u0099\u0001\u001b\u0001\u001b\u0000\u0000"+
		"\u001c\u0001\u0001\u0003\u0002\u0005\u0003\u0007\u0004\t\u0005\u000b\u0006"+
		"\r\u0007\u000f\b\u0011\t\u0013\n\u0015\u000b\u0017\f\u0019\r\u001b\u000e"+
		"\u001d\u000f\u001f\u0010!\u0011#\u0012%\u0013\'\u0014)\u0015+\u0016-\u0017"+
		"/\u00181\u00193\u001a5\u001b7\u001c\u0001\u0000\b\u0001\u000019\u0001"+
		"\u000009\u0001\u0000az\u0003\u0000AZ__az\u0001\u0000AZ\u0004\u000009A"+
		"Z__az\u0002\u0000\n\n\r\r\u0003\u0000\t\n\r\r  \u00a4\u0000\u0001\u0001"+
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
		"\u0001\u0000\u0000\u0000\u00007\u0001\u0000\u0000\u0000\u00019\u0001\u0000"+
		"\u0000\u0000\u0003E\u0001\u0000\u0000\u0000\u0005G\u0001\u0000\u0000\u0000"+
		"\u0007N\u0001\u0000\u0000\u0000\tU\u0001\u0000\u0000\u0000\u000bW\u0001"+
		"\u0000\u0000\u0000\rY\u0001\u0000\u0000\u0000\u000f[\u0001\u0000\u0000"+
		"\u0000\u0011]\u0001\u0000\u0000\u0000\u0013_\u0001\u0000\u0000\u0000\u0015"+
		"b\u0001\u0000\u0000\u0000\u0017d\u0001\u0000\u0000\u0000\u0019f\u0001"+
		"\u0000\u0000\u0000\u001bh\u0001\u0000\u0000\u0000\u001dj\u0001\u0000\u0000"+
		"\u0000\u001fl\u0001\u0000\u0000\u0000!n\u0001\u0000\u0000\u0000#p\u0001"+
		"\u0000\u0000\u0000%r\u0001\u0000\u0000\u0000\'t\u0001\u0000\u0000\u0000"+
		")v\u0001\u0000\u0000\u0000+|\u0001\u0000\u0000\u0000-~\u0001\u0000\u0000"+
		"\u0000/\u0080\u0001\u0000\u0000\u00001\u0082\u0001\u0000\u0000\u00003"+
		"\u0085\u0001\u0000\u0000\u00005\u0088\u0001\u0000\u0000\u00007\u0097\u0001"+
		"\u0000\u0000\u00009:\u0005n\u0000\u0000:;\u0005o\u0000\u0000;<\u0005t"+
		"\u0000\u0000<\u0002\u0001\u0000\u0000\u0000=F\u00050\u0000\u0000>B\u0007"+
		"\u0000\u0000\u0000?A\u0007\u0001\u0000\u0000@?\u0001\u0000\u0000\u0000"+
		"AD\u0001\u0000\u0000\u0000B@\u0001\u0000\u0000\u0000BC\u0001\u0000\u0000"+
		"\u0000CF\u0001\u0000\u0000\u0000DB\u0001\u0000\u0000\u0000E=\u0001\u0000"+
		"\u0000\u0000E>\u0001\u0000\u0000\u0000F\u0004\u0001\u0000\u0000\u0000"+
		"GK\u0007\u0002\u0000\u0000HJ\u0007\u0003\u0000\u0000IH\u0001\u0000\u0000"+
		"\u0000JM\u0001\u0000\u0000\u0000KI\u0001\u0000\u0000\u0000KL\u0001\u0000"+
		"\u0000\u0000L\u0006\u0001\u0000\u0000\u0000MK\u0001\u0000\u0000\u0000"+
		"NR\u0007\u0004\u0000\u0000OQ\u0007\u0005\u0000\u0000PO\u0001\u0000\u0000"+
		"\u0000QT\u0001\u0000\u0000\u0000RP\u0001\u0000\u0000\u0000RS\u0001\u0000"+
		"\u0000\u0000S\b\u0001\u0000\u0000\u0000TR\u0001\u0000\u0000\u0000UV\u0005"+
		".\u0000\u0000V\n\u0001\u0000\u0000\u0000WX\u0005,\u0000\u0000X\f\u0001"+
		"\u0000\u0000\u0000YZ\u0005?\u0000\u0000Z\u000e\u0001\u0000\u0000\u0000"+
		"[\\\u0005:\u0000\u0000\\\u0010\u0001\u0000\u0000\u0000]^\u0005;\u0000"+
		"\u0000^\u0012\u0001\u0000\u0000\u0000_`\u0005:\u0000\u0000`a\u0005-\u0000"+
		"\u0000a\u0014\u0001\u0000\u0000\u0000bc\u0005+\u0000\u0000c\u0016\u0001"+
		"\u0000\u0000\u0000de\u0005-\u0000\u0000e\u0018\u0001\u0000\u0000\u0000"+
		"fg\u0005*\u0000\u0000g\u001a\u0001\u0000\u0000\u0000hi\u0005/\u0000\u0000"+
		"i\u001c\u0001\u0000\u0000\u0000jk\u0005(\u0000\u0000k\u001e\u0001\u0000"+
		"\u0000\u0000lm\u0005)\u0000\u0000m \u0001\u0000\u0000\u0000no\u0005[\u0000"+
		"\u0000o\"\u0001\u0000\u0000\u0000pq\u0005]\u0000\u0000q$\u0001\u0000\u0000"+
		"\u0000rs\u0005{\u0000\u0000s&\u0001\u0000\u0000\u0000tu\u0005}\u0000\u0000"+
		"u(\u0001\u0000\u0000\u0000vw\u0005=\u0000\u0000w*\u0001\u0000\u0000\u0000"+
		"xy\u0005<\u0000\u0000y}\u0005>\u0000\u0000z{\u0005!\u0000\u0000{}\u0005"+
		"=\u0000\u0000|x\u0001\u0000\u0000\u0000|z\u0001\u0000\u0000\u0000},\u0001"+
		"\u0000\u0000\u0000~\u007f\u0005<\u0000\u0000\u007f.\u0001\u0000\u0000"+
		"\u0000\u0080\u0081\u0005>\u0000\u0000\u00810\u0001\u0000\u0000\u0000\u0082"+
		"\u0083\u0005<\u0000\u0000\u0083\u0084\u0005=\u0000\u0000\u00842\u0001"+
		"\u0000\u0000\u0000\u0085\u0086\u0005>\u0000\u0000\u0086\u0087\u0005=\u0000"+
		"\u0000\u00874\u0001\u0000\u0000\u0000\u0088\u008c\u0005%\u0000\u0000\u0089"+
		"\u008b\b\u0006\u0000\u0000\u008a\u0089\u0001\u0000\u0000\u0000\u008b\u008e"+
		"\u0001\u0000\u0000\u0000\u008c\u008a\u0001\u0000\u0000\u0000\u008c\u008d"+
		"\u0001\u0000\u0000\u0000\u008d\u0090\u0001\u0000\u0000\u0000\u008e\u008c"+
		"\u0001\u0000\u0000\u0000\u008f\u0091\u0005\r\u0000\u0000\u0090\u008f\u0001"+
		"\u0000\u0000\u0000\u0090\u0091\u0001\u0000\u0000\u0000\u0091\u0092\u0001"+
		"\u0000\u0000\u0000\u0092\u0093\u0005\n\u0000\u0000\u0093\u0094\u0001\u0000"+
		"\u0000\u0000\u0094\u0095\u0006\u001a\u0000\u0000\u00956\u0001\u0000\u0000"+
		"\u0000\u0096\u0098\u0007\u0007\u0000\u0000\u0097\u0096\u0001\u0000\u0000"+
		"\u0000\u0098\u0099\u0001\u0000\u0000\u0000\u0099\u0097\u0001\u0000\u0000"+
		"\u0000\u0099\u009a\u0001\u0000\u0000\u0000\u009a\u009b\u0001\u0000\u0000"+
		"\u0000\u009b\u009c\u0006\u001b\u0000\u0000\u009c8\u0001\u0000\u0000\u0000"+
		"\t\u0000BEKR|\u008c\u0090\u0099\u0001\u0006\u0000\u0000";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}