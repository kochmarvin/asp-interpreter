using System.Text;
using Interpreter.Lib.Results.Objects.Atoms;
using Interpreter.Lib.Results.Objects.BodyLiterals;
using Interpreter.Lib.Results.Objects.HeadLiterals;
using Interpreter.Lib.Results.Objects.Literals;
using Interpreter.Lib.Results.Objects.Rule;
using QuickGraph;

public class Helper
{
  public static void PrintGrdSeq(List<List<List<ProgramRule>>> grdSeq)
  {
    int sccLevel1Index = 0;
    foreach (var sccLevel1 in grdSeq)
    {
      Console.WriteLine($"Level 1 SCC #{sccLevel1Index}:");
      int sccLevel2Index = 0;
      foreach (var sccLevel2 in sccLevel1)
      {
        Console.WriteLine($"\tLevel 2 SCC #{sccLevel2Index}:");
        int ruleIndex = 0;
        foreach (var rule in sccLevel2)
        {
          // Assuming ProgramRule has a meaningful ToString() implementation
          Console.WriteLine($"\t\tRule #{ruleIndex}: {rule}");
          ruleIndex++;
        }
        sccLevel2Index++;
      }
      sccLevel1Index++;
    }
  }
}