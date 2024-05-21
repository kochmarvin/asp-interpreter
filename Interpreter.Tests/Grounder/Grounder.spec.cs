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

    var graph = new MyDependencyGraph(rules, new OrderVisitor(), new MyAddToGraphVisitor());
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
      ":--fly(tux),fly(tux)."
    ];

    var graph = new MyDependencyGraph(rules, new OrderVisitor(), new MyAddToGraphVisitor());
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

    var graph = new MyDependencyGraph(rules, new OrderVisitor(), new MyAddToGraphVisitor());
    Grounding grounder = new Grounding(graph);

    var grounded = grounder.Ground();
    Assert.That(grounded, Has.Count.EqualTo(expected.Count));
    foreach (var r in grounded)
    {
      Assert.That(expected, Does.Contain(r.ToString().Replace(" ", "")), "Generated fact not found in the expected list.");
    }
  }

  [Test]
  public void SchraubTest()
  {
    List<ProgramRule> rules = Utils.ParseProgram("schraub.lp");

    List<string> expected = [
      "{a}.",
      "b:-a.",
      "{c}:-nota.",
      "d:-notb,notc.",
      ":-c,nota."
    ];

    var graph = new MyDependencyGraph(rules, new OrderVisitor(), new MyAddToGraphVisitor());
    Grounding grounder = new Grounding(graph);

    var grounded = grounder.Ground();
    Assert.That(grounded, Has.Count.EqualTo(expected.Count));
    foreach (var r in grounded)
    {
      Assert.That(expected, Does.Contain(r.ToString().Replace(" ", "")), "Generated fact not found in the expected list.");
    }
  }

  [Test]
  public void ComparissonTest()
  {
    List<ProgramRule> rules = Utils.ParseProgram("comparisson.lp");

    List<string> expected = [
      "node(1).",
      "node(2).",
      "node(3).",
      "node(4).",
      "node(5).",
      "node(6).",
      "knoten(4):-node(4),4>3.",
      "knoten(5):-node(5),5>3.",
      "knoten(6):-node(6),6>3.",
      "knoten(3):-node(3),3>=3.",
      "knoten(4):-node(4),4>=3.",
      "knoten(5):-node(5),5>=3.",
      "knoten(6):-node(6),6>=3.",
      "knoten(1):-node(1),1<=3.",
      "knoten(2):-node(2),2<=3.",
      "knoten(3):-node(3),3<=3.",
      "knoten(1):-node(1),1<3.",
      "knoten(2):-node(2),2<3.",
      "knoten(3):-node(3),3==3.",
      "knoten(1):-node(1),1!=3.",
      "knoten(2):-node(2),2!=3.",
      "knoten(4):-node(4),4!=3.",
      "knoten(5):-node(5),5!=3.",
      "knoten(6):-node(6),6!=3.",
    ];

    var graph = new MyDependencyGraph(rules, new OrderVisitor(), new MyAddToGraphVisitor());
    Grounding grounder = new Grounding(graph);

    var grounded = grounder.Ground();

    Assert.That(grounded, Has.Count.EqualTo(expected.Count));
    foreach (var r in grounded)
    {
      Assert.That(expected, Does.Contain(r.ToString().Replace(" ", "")), "Generated fact not found in the expected list.");
    }
  }

  [Test]
  public void MultiChoiceBodyTest()
  {
    List<ProgramRule> rules = Utils.ParseProgram("multichoice_body.lp");

    List<string> expected = [
      "mensch(marvin).",
      "mensch(julia).",
      "{informatiker(marvin);student(marvin)}:-mensch(marvin).",
      "{informatiker(julia);student(julia)}:-mensch(julia).",
    ];

    var graph = new MyDependencyGraph(rules, new OrderVisitor(), new MyAddToGraphVisitor());
    Grounding grounder = new Grounding(graph);

    var grounded = grounder.Ground();

    Assert.That(grounded, Has.Count.EqualTo(expected.Count));
    foreach (var r in grounded)
    {
      Assert.That(expected, Does.Contain(r.ToString().Replace(" ", "")), "Generated fact not found in the expected list.");
    }
  }

  [Test]
  public void NestedTest()
  {
    List<ProgramRule> rules = Utils.ParseProgram("nested.lp");

    List<string> expected = [
      "marvin(findet(julia(cool))).",
      "findetJuliaCool(marvin(findet(findet(julia(cool)))),julia(cool)):-marvin(findet(julia(cool))),marvin(findet(julia(cool)))."
    ];

    var graph = new MyDependencyGraph(rules, new OrderVisitor(), new MyAddToGraphVisitor());
    Grounding grounder = new Grounding(graph);

    var grounded = grounder.Ground();

    Assert.That(grounded, Has.Count.EqualTo(expected.Count));
    foreach (var r in grounded)
    {
      Assert.That(expected, Does.Contain(r.ToString().Replace(" ", "")), "Generated fact not found in the expected list.");
    }
  }

  [Test]
  public void NoVarsTest()
  {
    List<ProgramRule> rules = Utils.ParseProgram("no_vars.lp");

    List<string> expected = [
      "a:-notb.",
      "b:-nota.",
      "x:-a,notc.",
      "x:-y.",
      "y:-x,b."
    ];

    var graph = new MyDependencyGraph(rules, new OrderVisitor(), new MyAddToGraphVisitor());
    Grounding grounder = new Grounding(graph);

    var grounded = grounder.Ground();

    Assert.That(grounded, Has.Count.EqualTo(expected.Count));
    foreach (var r in grounded)
    {
      Assert.That(expected, Does.Contain(r.ToString().Replace(" ", "")), "Generated fact not found in the expected list.");
    }
  }

  [Test]
  public void Fastest()
  {
    List<ProgramRule> rules = Utils.ParseProgram("fastest.lp");

    List<string> expected = [
      "vehicle(bike).",
      "vehicle(skateboard).",
      "faster(bike,skateboard).",
      "is_faster(bike,skateboard):-faster(bike,skateboard).",
      "fastest(bike):-vehicle(bike),notis_faster(bike,bike).",
      "fastest(skateboard):-vehicle(skateboard),notis_faster(bike,skateboard)."
    ];

    var graph = new MyDependencyGraph(rules, new OrderVisitor(), new MyAddToGraphVisitor());
    Grounding grounder = new Grounding(graph);

    var grounded = grounder.Ground();

    Assert.That(grounded, Has.Count.EqualTo(expected.Count));
    foreach (var r in grounded)
    {
      Assert.That(expected, Does.Contain(r.ToString().Replace(" ", "")), "Generated fact not found in the expected list.");
    }
  }
}