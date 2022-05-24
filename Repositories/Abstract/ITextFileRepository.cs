namespace ReadWriteConsoleApp.Repositories.Abstract;

public interface ITextFileRepository<T> where T:class
{
    IList<T> GetDatas();
    void LogDatasToFile(string logFileName, IList<T> datasToLog);
}