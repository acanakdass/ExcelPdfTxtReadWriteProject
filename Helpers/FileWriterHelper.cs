namespace ReadWriteConsoleApp.Helpers;

public static class FileWriterHelper
{
    public static void LogToFile(string filename, string textToWrite)
    {
        using StreamWriter file =
            new("/Users/ahmetcanakdas/RiderProjects/ReadWriteProject/ReadWriteConsoleApp/Logs/" + filename,
                append: true);
        file.WriteLineAsync(textToWrite);
    }
}