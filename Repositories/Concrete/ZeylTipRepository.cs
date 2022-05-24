using Ganss.Excel;
using NPOI.SS.Formula.Functions;
using ReadWriteConsoleApp.Models;
using ReadWriteConsoleApp.Repositories.Abstract;

namespace ReadWriteConsoleApp.Repositories.Concrete;

public class ZeylTipRepository:ExcelRepositoryBase<ZeylTip>,IZeylTipRepository
{
    
    public Zeyl GetByPolID(string fileName,string id)
    {
        var filePath = $"{baseFilePath}/{fileName}"; 
        var records = new ExcelMapper(filePath).Fetch<Zeyl>(); // -> IEnumerable<dynamic>
        return records.FirstOrDefault(p=>p.POLID==id);
    }
}