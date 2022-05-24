using Ganss.Excel;
using NPOI.SS.Formula.Functions;
using ReadWriteConsoleApp.Models;
using ReadWriteConsoleApp.Repositories.Abstract;
using ReadWriteConsoleApp.Repositories.Concrete;

namespace ReadWriteConsoleApp.Repositories.Concrete;

public class ExcelRepositoryBase<T>:IExcelRepository<T> where T:class, IEntity ,new()
{
    public string baseFilePath =
        "/Users/ahmetcanakdas/RiderProjects/ReadWriteProject/ReadWriteConsoleApp/files";
    public IEnumerable<T> GetRecords(string fileName)
    {
        var filePath = $"{baseFilePath}/{fileName}"; 
        var records = new ExcelMapper(filePath).Fetch<T>(); // -> IEnumerable<dynamic>
        return records;   
    }
}