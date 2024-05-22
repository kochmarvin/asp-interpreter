//-----------------------------------------------------------------------
// <copyright file="Logger.cs" company="PlaceholderCompany">
//      Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Interpreter.Lib.Logger;

using Microsoft.Extensions.Logging;

/// <summary>
/// Basic logger from the microsoft extension with a debug mode.
/// </summary>
public class Logger
{
  /// <summary>
  /// Singelton instance of the logger.
  /// </summary>
  private static Logger? instance;

  /// <summary>
  /// The microsoft logger itself.
  /// </summary>
  private ILogger logger;

  /// <summary>
  /// Initializes a new instance of the <see cref="Logger"/> class.
  /// </summary>
  /// <param name="logger">The interface of the logger to be created.</param>
  private Logger(ILogger logger)
  {
    this.LoggerInstance = logger;
  }

  /// <summary>
  /// Gets the instanc of the logger interface.
  /// </summary>
  public ILogger LoggerInstance
  {
    get
    {
      return this.logger;
    }

    private set
    {
      this.logger = value ?? throw new ArgumentNullException(nameof(this.LoggerInstance), "Is not supposed to be null");
    }
  }

  /// <summary>
  /// Creates the singelton instance of the logger with a certein log level.
  /// </summary>
  /// <param name="debug">If debug is true the loglevel is Trace otherwise informaiton.</param>
  public static void InitLogger(bool debug)
  {
    if (instance != null)
    {
      return;
    }

    using var loggerFactory = LoggerFactory.Create(builder =>
       {
         builder
            .AddFilter("Microsoft", LogLevel.Warning)
            .AddFilter("System", LogLevel.Warning)
            .AddConsole()
            .SetMinimumLevel(debug ? LogLevel.Trace : LogLevel.Information);
       });

    ILogger logger = loggerFactory.CreateLogger("Answer Set Programming");
    instance = new Logger(logger);
  }

  /// <summary>
  /// Loggs the given information string.
  /// </summary>
  /// <param name="message">The string that is to be logged.</param>
  public static void Information(string message)
  {
    if (instance == null)
    {
      InitLogger(false);
    }

    instance?.logger.LogInformation(message);
  }

  /// <summary>
  /// Loggs the given debug information string.
  /// </summary>
  /// <param name="message">The string that is to be logged.</param>
  public static void Debug(string message)
  {
    if (instance == null)
    {
      InitLogger(false);
    }

    instance?.logger.LogDebug(message);
  }

  /// <summary>
  /// Loggs the given error information string.
  /// </summary>
  /// <param name="message">The string that is to be logged.</param>
  public static void Error(string message)
  {
    if (instance == null)
    {
      InitLogger(false);
    }

    instance?.logger.LogError(message);
  }

  /// <summary>
  /// Loggs the warning information string.
  /// </summary>
  /// <param name="message">The string that is to be logged.</param>
  public static void Warning(string message)
  {
    if (instance == null)
    {
      InitLogger(false);
    }

    instance?.logger.LogWarning(message);
  }
}