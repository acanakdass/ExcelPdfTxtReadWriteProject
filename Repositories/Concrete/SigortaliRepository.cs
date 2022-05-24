using Ganss.Excel;
using ReadWriteConsoleApp.Models;
using ReadWriteConsoleApp.Repositories.Abstract;

namespace ReadWriteConsoleApp.Repositories.Concrete;

public class SigortaliRepository:ExcelRepositoryBase<Sigortali>,ISigortaliRepository
{
    public Sigortali GetByPolID(string fileName,string id)
    {
        var filePath = $"{baseFilePath}/{fileName}";
        var records = this.GetRecords(fileName); // -> IEnumerable<dynamic>
        return records.FirstOrDefault(p=>p.POLID==id);
    }
}