using ReadWriteConsoleApp.Models;
using ReadWriteConsoleApp.Repositories.Abstract;
using ReadWriteConsoleApp.Repositories.Concrete;

namespace ReadWriteConsoleApp.Services.Concrete;

public class SigortaliManager
{
    private string fileName = "agito.t_sigortali.xls";
    private ISigortaliRepository _repository;

    public SigortaliManager()
    {
        _repository = new SigortaliRepository();
    }

    public IEnumerable<Sigortali> GetRecords()
    {
        return _repository.GetRecords(fileName);
    }
    public Sigortali GetByPolID(string id)
    {
        return _repository.GetByPolID(fileName,id);
    }
}