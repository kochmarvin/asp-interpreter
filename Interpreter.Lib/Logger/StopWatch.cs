using System.Diagnostics;

namespace Interpreter.Lib.Logger;

/// <summary>
/// Basic wrapper for stopwatch to fetch how long an action is taking
/// </summary>
public class StopWatch
{
  private Stopwatch _stopwatch;
  private StopWatch()
  {
    _stopwatch = Stopwatch.StartNew();
  }
  public static StopWatch Start()
  {
    return new StopWatch();
  }

  public string Stop()
  {
    _stopwatch.Stop();
    TimeSpan timeTaken = _stopwatch.Elapsed;
    return string.Format("{0:hh\\:mm\\:ss\\:fff}", timeTaken);
  }

}