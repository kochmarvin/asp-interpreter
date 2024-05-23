using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Tests.Parser;

[TestFixture]
public class GetVariablesTest
{
  [Test]
  public void NestedVariables()
  {
    List<ProgramRule> rules = Utils.ParseProgram("nested.lp");

    var actual = rules.SelectMany(rule => rule.Head.GetVariables()).ToList();
    List<string> expected = ["X", "Y"];

    CollectionAssert.AreEquivalent(expected, actual, "The lists do not contain the same elements.");
  }
}