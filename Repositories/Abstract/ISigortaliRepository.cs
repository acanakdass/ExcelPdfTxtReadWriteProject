using ReadWriteConsoleApp.Models;

namespace ReadWriteConsoleApp.Repositories.Abstract;

public interface ISigortaliRepository:IExcelRepository<Sigortali>
{
    Sigortali GetByPolID(string fileName,string id);

}