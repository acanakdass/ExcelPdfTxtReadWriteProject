using ReadWriteConsoleApp.Models;
using ReadWriteConsoleApp.Repositories.Abstract;
using ReadWriteConsoleApp.Repositories.Concrete;

namespace ReadWriteConsoleApp.Services.Concrete;

public class ZeylManager
{
    private string fileName = "agito.t_zeyl.xls";
    private string zeylTipsFileName = "agito.zeyltips.xls";
    private IZeylRepository _repository;

    public ZeylManager()
    {
        _repository = new ZeylRepository();
    }

    public IEnumerable<Zeyl> GetRecords()
    {
        return _repository.GetRecords(fileName);
    }
    public Zeyl GetByPolID(string id)
    {
        return _repository.GetByPolID(fileName,id);
    }
    public Zeyl GetByZeylNo(string zeylNo)
    {
        return _repository.GetByZeylNo(fileName,zeylNo);
    }
}