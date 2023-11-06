namespace Foraging_Kentucky.Common;

public static class Logger
{
    public static void Log<T>(this T obj, string message)
    {

        string logFilePath = "./log.txt";
        string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} : {obj} - {message}";

        try
        {
            if (!File.Exists(logFilePath))
            {
                using (StreamWriter writer = File.CreateText(logFilePath))
                {
                    writer.WriteLine(logEntry);
                }
            }
            else
            {
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    writer.WriteLine(logEntry);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error logging: {ex.Message}");
        }
    }

    // This method will be used for unit testing
    public static string LogByReturnForTesting<T>(this T obj, string message)
    {
        return $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} : {obj} - {message}";
    }

    public static string success = "The operation was successful.";
    public static string error = "An error occurred.";
    public static string invalid = "Invalid input.";
}
