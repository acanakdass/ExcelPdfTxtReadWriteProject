using ReadWriteConsoleApp.Models;

namespace ReadWriteConsoleApp.Repositories.Abstract;

public interface IPersonRepository:IExcelRepository<Person>
{
    Person GetByPID(string fileName,string id);
}