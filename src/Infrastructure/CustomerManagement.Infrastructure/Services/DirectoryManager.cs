using System;
using System.Globalization;
using System.IO;


namespace CustomerManagement.Infrastructure.Services;

public class DirectoryManager
{
    private readonly string _rootDirectory;

    public DirectoryManager(string rootDirectory)
    {
        _rootDirectory = rootDirectory;
    }

    public string CreateDirectoryStructure()
    {
        string currentDate = DateTime.Now.ToString("yyyyMMdd");

       
        string year = currentDate.Substring(0, 4);
        string month = DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);
        string day = currentDate.Substring(6, 2);

        string yearDirectory = GetOrCreateDirectory(_rootDirectory, year);

        string monthDirectory = GetOrCreateDirectory(yearDirectory, month);

       
        string dayDirectory = GetOrCreateDirectory(monthDirectory, day);

        Console.WriteLine("Directories successfully created.");

     
        return dayDirectory;
    }

    private string GetOrCreateDirectory(string parentDirectory, string directoryName)
    {
        string directoryPath = Path.Combine(parentDirectory, directoryName);

     
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        return directoryPath;
    }
}





