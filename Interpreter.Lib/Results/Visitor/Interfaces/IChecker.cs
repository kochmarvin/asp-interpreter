public interface IChecker
{
  public IsAtomHeadVisitor IsAtomHeadVisitor { get; }
  public IsHeadlessVisitor IsHeadlessVisitor { get; }
  public IsChoiceHeadVisitor IsChoiceHeadVisitor { get; }

  public IsAtomLiteralVisitor IsAtomLiteralVisitor { get; }
  public IsIsLiteralVisitor IsIsLiteralVisitor { get; }
  public IsComparisonLiteralVisitor IsComparisonLiteralVisitor { get; }
  public IsCommentLiteralVisitor IsCommentLiteralVisitor { get; }

  public IsFunctionalVisitor IsFunctionalVisitor { get; }
  public IsVariableVisitor IsVariableVisitor { get; }
  public IsNumberVisitor IsNumberVisitor { get; }
}