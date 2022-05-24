using ReadWriteConsoleApp.Models;
using ReadWriteConsoleApp.Repositories.Abstract;
using ReadWriteConsoleApp.Repositories.Concrete;

namespace ReadWriteConsoleApp.Services.Concrete;

public class ZeylTipManager
{
    private string fileName = "agito.zeyltips.xls";
    private IZeylTipRepository _repository;

    public ZeylTipManager()
    {
        _repository = new ZeylTipRepository();
    }

    public IEnumerable<ZeylTip> GetRecords()
    {
        return _repository.GetRecords(fileName);
    }
}