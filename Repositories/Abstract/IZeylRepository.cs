using ReadWriteConsoleApp.Models;

namespace ReadWriteConsoleApp.Repositories.Abstract;

public interface IZeylRepository:IExcelRepository<Zeyl>
{
    Zeyl GetByPolID(string fileName,string id);
    Zeyl GetByZeylNo(string fileName,string zeylNo);

}