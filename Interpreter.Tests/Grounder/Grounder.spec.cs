using Interpreter.Lib.Graph;
using Interpreter.Lib.Results.Objects.Rule;
using Interpreter.Lib.Grounder;
using Interpreter.Tests.Parser;

namespace Tests.GrounderTests;

[TestFixture]
public class GrounderTests
{

  [Test]
  public void GrounderFasterTest()
  {
    List<ProgramRule> rules = Utils.ParseProgram("faster.lp");

    List<string> expected = [
      "faster(niko,michi).",
      "faster(werner,niko).",
      "faster(marvin,werner).",
      "isFaster(marvin,werner):-faster(marvin,werner).",
      "isFaster(niko,michi):-faster(niko,michi).",
      "isFaster(werner,niko):-faster(werner,niko).",
      "isFaster(marvin,niko):-faster(marvin,werner),isFaster(werner,niko).",
      "isFaster(werner,michi):-faster(werner,niko),isFaster(niko,michi).",
      "isFaster(marvin,michi):-faster(marvin,werner),isFaster(werner,michi).",
    ];

    DependencyGraph graph = new DependencyGraph(rules);
    Grounding grounder = new Grounding(graph);
    var grounded = grounder.Ground();
    Assert.That(grounded, Has.Count.EqualTo(expected.Count));

    foreach (var r in grounded)
    {
      Assert.That(expected, Does.Contain(r.ToString().Replace(" ", "")), "Generated fact not found in the expected list.");
    }
  }

  [Test]
  public void GrounderBirdsTest()
  {
    List<ProgramRule> rules = Utils.ParseProgram("birds.lp");

    List<string> expected = [
      "eagle(eddy).",
      "penguin(tux).",
      "bird(tux):-penguin(tux).",
      "bird(eddy):-eagle(eddy).",
      "-fly(tux):-penguin(tux).",
      "fly(tux):-bird(tux),not-fly(tux).",
      "fly(eddy):-bird(eddy),not-fly(eddy).",
    ];

    DependencyGraph graph = new DependencyGraph(rules);
    Grounding grounder = new Grounding(graph);

    var grounded = grounder.Ground();
    Assert.That(grounded, Has.Count.EqualTo(expected.Count));
    foreach (var r in grounded)
    {
      Assert.That(expected, Does.Contain(r.ToString().Replace(" ", "")), "Generated fact not found in the expected list.");
    }
  }


  [Test]
  public void GrounderCircluarTest()
  {
    List<ProgramRule> rules = Utils.ParseProgram("circular.lp");

    List<string> expected = [
      "mensch(marvin).",
      "single(marvin):-mensch(marvin),notmarried(marvin).",
      "married(marvin):-mensch(marvin),notsingle(marvin)."
    ];

    DependencyGraph graph = new DependencyGraph(rules);
    Grounding grounder = new Grounding(graph);

    var grounded = grounder.Ground();
    Assert.That(grounded, Has.Count.EqualTo(expected.Count));
    foreach (var r in grounded)
    {
      Assert.That(expected, Does.Contain(r.ToString().Replace(" ", "")), "Generated fact not found in the expected list.");
    }
  }
}