public interface IHeadAccept
{
  public T? Accept<T>(HeadVisitor<T> visitor);
}