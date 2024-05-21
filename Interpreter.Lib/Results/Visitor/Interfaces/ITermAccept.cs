public interface ITermAccept
{
  public T? Accept<T>(TermVisitor<T> visitor);
}