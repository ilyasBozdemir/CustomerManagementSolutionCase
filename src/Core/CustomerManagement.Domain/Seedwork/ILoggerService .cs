using Serilog;

namespace CustomerManagement.Domain.Seedwork;

public interface ILoggerService
{
    void InitializeLogger(string rootDirectory);
    ILogger GetLogger();
}