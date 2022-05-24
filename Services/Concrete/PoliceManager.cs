using ReadWriteConsoleApp.Models;
using ReadWriteConsoleApp.Repositories.Abstract;
using ReadWriteConsoleApp.Repositories.Concrete;

namespace ReadWriteConsoleApp.Services.Concrete;

public class PoliceManager
{
    private string fileName = "agito.t_police.xls";

    private IPoliceRepository _repository;

    public PoliceManager()
    {
        _repository = new PoliceRepository();
    }

    public IEnumerable<Police> GetRecords()
    {
        return _repository.GetRecords(fileName);
    }
}