public interface IObjectParser
{
  public ParseHeadlessVisitor ParseHeadlessVisitor { get; }
  public ParseChoiceHeadVisitor ParseChoiceHeadVisitor { get; }
  public ParseAtomHeadVisitor ParseAtomHeadVisitor { get; }

  public ParseAtomLiteralVisitor ParseAtomLiteralVisitor { get; }
  public ParseCommentLiteralVisitor ParseCommentLiteralVisitor { get; }
  public ParseComparisonLiteralVisitor ParseComparisonLiteralVisitor { get; }
  public ParseIsLiteralVisitor ParseIsLiteralVisitor { get; }

  public ParseNumberVisitor ParseNumberVisitor { get; }
  public ParseFunctionalVisitor ParseFunctionalVisitor { get; }
  public ParseVariableVisitor ParseVariableVisitor { get; }
}