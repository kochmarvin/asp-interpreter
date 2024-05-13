using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace Interpreter.Lib.Logger;

/// <summary>
/// Basic logger from the microsoft extension with a debug mode.
/// </summary>
public class Logger
{
  /// <summary>
  /// Singelton instance of the logger
  /// </summary>
  private static Logger? _instance;

  /// <summary>
  /// The microsoft logger itself
  /// </summary>
  private ILogger _logger;

  private Logger(ILogger logger)
  {
    _logger = logger;
  }


  /// <summary>
  /// Creates the singelton instance of the logger with a certein log level
  /// </summary>
  /// <param name="debug">If debug is true the loglevel is Trace otherwise informaiton</param>
  public static void InitLogger(bool debug)
  {
    if (_instance != null)
    {
      return;
    }

    using var loggerFactory = LoggerFactory.Create(builder =>
       {
         builder
            .AddFilter("Microsoft", LogLevel.Warning)
            .AddFilter("System", LogLevel.Warning)
            .AddConsole(options =>
            {
              options.TimestampFormat = "HH:mm:ss ";
            })
            .SetMinimumLevel(debug ? LogLevel.Trace : LogLevel.Information);
       });

    ILogger logger = loggerFactory.CreateLogger("Answer Set Programming");
    _instance = new Logger(logger);
  }


  public static void Information(string message)
  {
    if (_instance == null) InitLogger(false);
    _instance?._logger.LogInformation(message);
  }
  public static void Debug(string message)
  {
    if (_instance == null) InitLogger(false);
    _instance?._logger.LogDebug(message);
  }

  public static void Error(string message)
  {
    if (_instance == null) InitLogger(false);
    _instance?._logger.LogError(message);
  }

  public static void Warning(string message)
  {
    if (_instance == null) InitLogger(false);
    _instance?._logger.LogWarning(message);
  }
}