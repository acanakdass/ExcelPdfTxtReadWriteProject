namespace ReadWriteConsoleApp.Repositories.Abstract;

public interface IExcelRepository<T>
    where T : class
{
    IEnumerable<T> GetRecords(string fileName);
}