using Interpreter.Lib.Results.Objects.Rule;

public interface IGrounder
{
  List<ProgramRule> Ground();
  List<string> Warnings { get; }
}