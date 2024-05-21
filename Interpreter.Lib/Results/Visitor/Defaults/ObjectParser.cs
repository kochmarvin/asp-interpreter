public class ObjectParser : IObjectParser
{
  public ParseHeadlessVisitor ParseHeadlessVisitor { get; } = new();
  public ParseChoiceHeadVisitor ParseChoiceHeadVisitor { get; } = new();
  public ParseAtomHeadVisitor ParseAtomHeadVisitor { get; } = new();

  public ParseAtomLiteralVisitor ParseAtomLiteralVisitor { get; } = new();
  public ParseCommentLiteralVisitor ParseCommentLiteralVisitor { get; } = new();
  public ParseComparisonLiteralVisitor ParseComparisonLiteralVisitor { get; } = new();
  public ParseIsLiteralVisitor ParseIsLiteralVisitor { get; } = new();

  public ParseNumberVisitor ParseNumberVisitor { get; } = new();
  public ParseFunctionalVisitor ParseFunctionalVisitor { get; } = new();
  public ParseVariableVisitor ParseVariableVisitor { get; } = new();
}