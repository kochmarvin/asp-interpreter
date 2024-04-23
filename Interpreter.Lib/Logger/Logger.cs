using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace Interpreter.Lib.Logger;

public class Logger
{
  private static Logger? _instance;
  private ILogger _logger;
  private bool _debug;

  private Logger(ILogger logger, bool debug)
  {
    _logger = logger;
    _debug = debug;
  }

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
    _instance = new Logger(logger, debug);
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