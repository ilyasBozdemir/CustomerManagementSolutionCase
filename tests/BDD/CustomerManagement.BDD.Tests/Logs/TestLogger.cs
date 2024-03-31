namespace CustomerManagement.BDD.Tests.Logs;

public class TestLogger
{
    private static readonly string LogFilePath = "test_log.txt";

    public static void LogMessage(string message)
    {
        using (StreamWriter writer = File.AppendText(LogFilePath))
        {
            writer.WriteLine($"{DateTime.Now}: {message}");
        }
    }

    public static void LogError(Exception ex)
    {
        using (StreamWriter writer = File.AppendText(LogFilePath))
        {
            writer.WriteLine($"{DateTime.Now}: ERROR - {ex.Message}");
            writer.WriteLine($"{DateTime.Now}: STACK TRACE - {ex.StackTrace}");
        }
    }
}