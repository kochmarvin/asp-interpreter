public class Checker : IChecker
{
  public IsAtomHeadVisitor IsAtomHeadVisitor { get; } = new();
  public IsHeadlessVisitor IsHeadlessVisitor { get; } = new();
  public IsChoiceHeadVisitor IsChoiceHeadVisitor { get; } = new();

  public IsAtomLiteralVisitor IsAtomLiteralVisitor { get; } = new();
  public IsIsLiteralVisitor IsIsLiteralVisitor { get; } = new();
  public IsComparisonLiteralVisitor IsComparisonLiteralVisitor { get; } = new();
  public IsCommentLiteralVisitor IsCommentLiteralVisitor { get; } = new();

  public IsFunctionalVisitor IsFunctionalVisitor { get; } = new();
  public IsVariableVisitor IsVariableVisitor { get; } = new();
  public IsNumberVisitor IsNumberVisitor { get; } = new();

}