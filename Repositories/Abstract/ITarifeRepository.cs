using ReadWriteConsoleApp.Models;

namespace ReadWriteConsoleApp.Repositories.Abstract;

public interface ITarifeRepository:IExcelRepository<Tarife>
{
    Tarife GetByTarifeNo(string fileName,string tarifeNo);
}