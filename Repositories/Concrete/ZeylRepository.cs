using Ganss.Excel;
using NPOI.SS.Formula.Functions;
using ReadWriteConsoleApp.Models;
using ReadWriteConsoleApp.Repositories.Abstract;

namespace ReadWriteConsoleApp.Repositories.Concrete;

public class ZeylRepository:ExcelRepositoryBase<Zeyl>,IZeylRepository
{
    public Zeyl GetByPolID(string fileName,string id)
    {
        var filePath = $"{baseFilePath}/{fileName}"; 
        var records = new ExcelMapper(filePath).Fetch<Zeyl>(); // -> IEnumerable<dynamic>
        return records.FirstOrDefault(p=>p.POLID==id);
    }

    public Zeyl GetByZeylNo(string fileName,string zeylNo)
    {
        return this.GetRecords(fileName).FirstOrDefault(z => z.ZEYLNO == zeylNo);
    }
}