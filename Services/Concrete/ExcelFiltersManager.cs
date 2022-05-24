using NPOI.SS.Formula.Functions;
using ReadWriteConsoleApp.Repositories.Abstract;
using ReadWriteConsoleApp.Repositories.Concrete;

namespace ReadWriteConsoleApp.Services.Concrete;

public class ExcelFiltersManager
{
    private readonly PoliceManager _policeService;
    private readonly ZeylManager _zeylService;
    private readonly SigortaliManager _sigortaliService;

    public ExcelFiltersManager()
    {
        _sigortaliService = new SigortaliManager();
        _zeylService = new ZeylManager();
        _policeService = new PoliceManager();
    }

    public string KacFarkliZeyltipPoliceVardirVeAciklamalari()
    {
        return "";
    }

    public string OtuzYasUstuMusteriSayisi()
    {
        var resultCount = 0;
        var sigortalis = _sigortaliService.GetRecords();
        foreach (var sigortali in sigortalis)
        {
            var dogumYili = sigortali.DOGTAR.Substring(sigortali.DOGTAR.Length - 4, 4);
            var yas = DateTime.Today.Year - Int32.Parse(dogumYili);
            if (yas > 30) resultCount += 1;
        }

        return $"{resultCount} adet 30 yaş üstünde müşteri vardır.";
    }

    public string KacFarkliTarifeNoyaAitPoliceVardirVeAciklamalari()
    {
        return "";
    }

    public string FKHETipindekiPolicelerdenKacarAdetVardır()
    {
        return "";
    }
}