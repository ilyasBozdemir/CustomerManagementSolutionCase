namespace CustomerManagement.BDD.Tests.Reports;

public class TestReport
{
    public static void GenerateHTMLReport(string filePath, string[] testResults)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
       
            writer.WriteLine("<html><head><title>Test Results</title></head><body>");
            writer.WriteLine("<h1>Test Results</h1>");
            foreach (string result in testResults)
            {
                writer.WriteLine($"<p>{result}</p>");
            }

            writer.WriteLine("</body></html>");
        }
    }
}