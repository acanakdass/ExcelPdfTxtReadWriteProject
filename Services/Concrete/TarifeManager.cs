using ReadWriteConsoleApp.Models;
using ReadWriteConsoleApp.Repositories.Abstract;
using ReadWriteConsoleApp.Repositories.Concrete;

namespace ReadWriteConsoleApp.Services.Concrete;

public class TarifeManager
{
    private string fileName = "agito.tarife.xls";
    private ITarifeRepository _repository;

    public TarifeManager()
    {
        _repository = new TarifeRepository();
    }

    public IEnumerable<Tarife> GetRecords()
    {
        return _repository.GetRecords(fileName);
    }
    public Tarife GetByTarifeNo(string tarifeNo)
    {
        return _repository.GetByTarifeNo(fileName,tarifeNo);
    }
}