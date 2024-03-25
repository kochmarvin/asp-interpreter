namespace Interpreter.Lib.Results.Enums;

public static class RelationExtensions
{
  public static string ToSymbol(this Relation relation)
  {
    return relation switch
    {
      Relation.LessThan => "<",
      Relation.LessEqual => "<=",
      Relation.GreaterThan => ">",
      Relation.GreaterEqual => ">=",
      Relation.Equal => "==",
      Relation.Inequal => "!=",
      _ => throw new NotImplementedException()
    };
  }
}