using Ganss.Excel;
using ReadWriteConsoleApp.Models;
using ReadWriteConsoleApp.Repositories.Abstract;

namespace ReadWriteConsoleApp.Repositories.Concrete;

public class TarifeRepository:ExcelRepositoryBase<Tarife>,ITarifeRepository
{
    public Tarife GetByTarifeNo(string fileName,string tarifeNo)
    {
        var filePath = $"{baseFilePath}/{fileName}"; 
        var records = new ExcelMapper(filePath).Fetch<Tarife>(); // -> IEnumerable<dynamic>
        return records.FirstOrDefault(t=>t.TARIFENO==tarifeNo);
    }
}