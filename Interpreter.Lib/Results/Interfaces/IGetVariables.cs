using Interpreter.Lib.Results.Objects.Terms;

namespace Interpreter.Lib.Results.Interfaces;

/// <summary>
/// Interface to get All Variables of a specific object
/// </summary>
public interface IGetVariables
{
  public List<string> GetVariables();
}