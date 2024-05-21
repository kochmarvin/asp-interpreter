public interface ILiteralAccept
{
  public T? Accept<T>(LiteralVisitor<T> visitor);
}