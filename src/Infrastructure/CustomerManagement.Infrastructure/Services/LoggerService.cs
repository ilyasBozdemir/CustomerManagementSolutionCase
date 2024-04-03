using CustomerManagement.Domain.Seedwork;
using Serilog;
using Serilog.Events;
using System.Globalization;

namespace CustomerManagement.Infrastructure.Services;

public class LoggerService : ILoggerService
{
    private  ILogger _logger;
    public ILogger GetLogger() => _logger;

    public void InitializeLogger(string rootDirectory)
    {
        DirectoryManager directoryManager = new DirectoryManager(rootDirectory);
        string dayDirectory = directoryManager.CreateDirectoryStructure();
        string fileName = $"log_{DateTime.Now:yyyyMMdd_HHmmss}";

        Console.WriteLine($"Oluşturulan gün dizininin yolu: {dayDirectory}");

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.Debug(outputTemplate: DateTime.Now.ToString())
            .WriteTo.Seq("http://localhost:5341")
            .WriteTo.File(
                path: Path.Combine(dayDirectory, $"{fileName}.txt"),
                rollingInterval: RollingInterval.Day,
                fileSizeLimitBytes: null,
                retainedFileCountLimit: null
            )
            .WriteTo.File(
                path: Path.Combine(dayDirectory, $"{fileName}.json"),
                formatter: new Serilog.Formatting.Json.JsonFormatter(),
                rollingInterval: RollingInterval.Day,
                fileSizeLimitBytes: null,
                retainedFileCountLimit: null
            )
            .WriteTo.RollingFile(
                formatter: new Serilog.Formatting.Compact.RenderedCompactJsonFormatter(),
                pathFormat: Path.Combine(dayDirectory, $"{fileName}_{{Date}}.log")
            )
            .WriteTo.Email(
                from: "sender@example.com",
                to: "recipient@example.com",
                host: "smtp.example.com",
                subject: "Log",
                restrictedToMinimumLevel: LogEventLevel.Information,
                formatProvider: CultureInfo.InvariantCulture
            )
            .MinimumLevel.Information()
            .Enrich.WithProperty("AppName", "BDD with Selenium Test Example")
            .Enrich.WithProperty("Environment", "Development")
            .Enrich.WithProperty("Coder", "Bozdemir")
            .CreateLogger();

        _logger = Log.Logger;

        Serilog.Debugging.SelfLog.Enable(msg =>
        {
            Console.WriteLine($"Serilog selflog: {msg}");
        });
    }
}
