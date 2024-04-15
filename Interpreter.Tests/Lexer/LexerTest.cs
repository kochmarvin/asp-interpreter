namespace Tests.Lexer;

using System.Data;
using Antlr4.Runtime;
using Interpreter.Lib.Errors;
using Interpreter.Lib.Listeners;
using Interpreter.Lib.Results.Objects.Rule;
using NUnit.Framework;

[TestFixture]
public class LexerTests
{
  public string _baseURL = "../../../Files/";
  private IList<IToken> GetTokens(string input)
  {
    var inputStream = new AntlrInputStream(input);
    var lexer = new LparseLexer(inputStream);
    var tokens = new CommonTokenStream(lexer);
    tokens.Fill();
    return tokens.GetTokens();
  }

  [Test]
  public void TestFactToken()
  {
    var tokens = GetTokens(File.ReadAllText($"{_baseURL}basic.lp"));

    Assert.Multiple(() =>
    {
      Assert.That(tokens[0].Type, Is.EqualTo(LparseLexer.ID), "The first token should be an ID.");
      Assert.That(tokens[1].Type, Is.EqualTo(LparseLexer.PAREN_OPEN), "The second token should be a PAREN_OPEN.");
      Assert.That(tokens[2].Type, Is.EqualTo(LparseLexer.ID), "The second token should be a ID.");
      Assert.That(tokens[3].Type, Is.EqualTo(LparseLexer.PAREN_CLOSE), "The fourth token should be a PAREN_CLOSE.");
    });
  }

  [Test]
  public void TestInvalidInput()
  {
    Assert.Throws<ParseException>(() =>
        {
          var inputStream = new AntlrInputStream("l");
          StartParser(inputStream);
        }, "Expected Parseexception to be thrown for invalid input.");
  }

  [Test]
  public void TestInvalidChoiceInput()
  {
    Assert.Throws<ParseException>(() =>
        {
          var inputStream = new AntlrInputStream("{c, a}.");
          StartParser(inputStream);

        }, "Expected Parseexception to be thrown for invalid input.");
  }

  [Test]
  public void TestInvalidNestingInput()
  {
    Assert.Throws<ParseException>(() =>
        {
          var inputStream = new AntlrInputStream("marvin(-julia).");
          StartParser(inputStream);

        }, "Expected Parseexception to be thrown for invalid input.");
  }

  [Test]
  public void TestRandomCommaInput()
  {
    Assert.Throws<ParseException>(() =>
        {
          var inputStream = new AntlrInputStream("ma,ka.");
          StartParser(inputStream);

        }, "Expected Parseexception to be thrown for invalid input.");
  }

  [Test]
  public void TestOpenParanthesesInput()
  {
    Assert.Throws<ParseException>(() =>
        {
          var inputStream = new AntlrInputStream("ma(.");
          StartParser(inputStream);

        }, "Expected Parseexception to be thrown for invalid input.");
  }

   [Test]
  public void TestEmptyParanthesesInput()
  {
    Assert.Throws<ParseException>(() =>
        {
          var inputStream = new AntlrInputStream("ma()");
          StartParser(inputStream);

        }, "Expected Parseexception to be thrown for invalid input.");
  }

  private void StartParser(AntlrInputStream input)
  {
    var lexer = new LparseLexer(input);
    var tokens = new CommonTokenStream(lexer);
    var parser = new LparseParser(tokens);
    parser.RemoveErrorListeners();
    parser.AddErrorListener(new SyntaxErrorListener());
    var tree = parser.program();
  }
}