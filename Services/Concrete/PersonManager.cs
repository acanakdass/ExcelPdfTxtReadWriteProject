using ReadWriteConsoleApp.Models;
using ReadWriteConsoleApp.Repositories.Abstract;
using ReadWriteConsoleApp.Repositories.Concrete;

namespace ReadWriteConsoleApp.Services.Concrete;

public class PersonManager
{
    private IPersonRepository _repository;
    private string fileName = "agito.t_person.xls";
    public PersonManager()
    {
        _repository = new PersonsRepository();
    }

    public IEnumerable<Person> GetRecords()
    {
        return _repository.GetRecords(fileName);
    }
    public Person GetByPID(string id)
    {
        return _repository.GetByPID(fileName,id);
    }
}