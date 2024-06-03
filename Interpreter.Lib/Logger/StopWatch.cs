//-----------------------------------------------------------------------
// <copyright file="StopWatch.cs" company="FHWN">
//      Copyright (c) FHWN. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Logger;

using System.Diagnostics;

/// <summary>
/// Basic wrapper for stopwatch to fetch how long an action is taking.
/// </summary>
public class StopWatch
{
  private Stopwatch stopwatch;

  /// <summary>
  /// Initializes a new instance of the <see cref="StopWatch"/> class.
  /// </summary>
  private StopWatch()
  {
    this.stopwatch = Stopwatch.StartNew();
  }

  /// <summary>
  /// Creates a new instance of a stopwatch and starts it.
  /// </summary>
  /// <returns>A new instance of the stopwatch.</returns>
  public static StopWatch Start()
  {
    return new StopWatch();
  }

  /// <summary>
  /// Stops the stopwatch and returns the elapsed time.
  /// </summary>
  /// <returns>The elapsed time as a string.</returns>
  public string Stop()
  {
    this.stopwatch.Stop();
    TimeSpan timeTaken = this.stopwatch.Elapsed;
    return string.Format("{0:hh\\:mm\\:ss\\:fff}", timeTaken);
  }
}