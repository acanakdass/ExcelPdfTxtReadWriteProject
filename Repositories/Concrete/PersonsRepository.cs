using Ganss.Excel;
using NPOI.SS.Formula.Functions;
using ReadWriteConsoleApp.Models;
using ReadWriteConsoleApp.Repositories.Abstract;

namespace ReadWriteConsoleApp.Repositories.Concrete;

public class PersonsRepository:ExcelRepositoryBase<Person>,IPersonRepository
{
    public Person GetByPID(string fileName,string id)
    {
        var filePath = $"{baseFilePath}/{fileName}"; 
        var records = new ExcelMapper(filePath).Fetch<Person>(); // -> IEnumerable<dynamic>
        return records.FirstOrDefault(p=>p.PID==id);
    }
}