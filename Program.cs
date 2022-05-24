using ReadWriteConsoleApp.DTOs;
using ReadWriteConsoleApp.Helpers;
using ReadWriteConsoleApp.Repositories.Concrete;
using ReadWriteConsoleApp.Services.Concrete;

void LogVKFERecords()
{
    var vkfeTextFileRepository = new VkfeTextFileRepository();
    var vkfeDatasToLog = vkfeTextFileRepository.GetDatas().Where(vkfe => vkfe.HataKod != "23").ToList();
    vkfeTextFileRepository.LogDatasToFile("vkfe_logs.txt", vkfeDatasToLog);
}
void LogTheTahHataRecords()
{
    var tthTextFileRepository = new TheTahHataTextFileRepository();
    var datas = tthTextFileRepository.GetDatas();
    var datasToLog = datas.Where(tth => tth.HataKod != "2").ToList();
    tthTextFileRepository.LogDatasToFile("the_tah_hata_logs.txt", datasToLog);
}
void HandlePolicePdfRendering()
{
    var policeService = new PoliceManager();
    var personService = new PersonManager();
    var sigortaliService = new SigortaliManager();
    var zeylService = new ZeylManager();
    var tarifeService = new TarifeManager();
    var records = policeService.GetRecords();
    var dtoListForPdfRender = new List<PoliceForPdfRenderDto>();
    foreach (var police in records)
    {
        var sigortali = sigortaliService.GetByPolID(police.POLID);
        var person = personService.GetByPID(sigortali.PID);
        var zeyl = zeylService.GetByZeylNo(police.SONZEYLNO);
        var tarife = tarifeService.GetByTarifeNo(zeyl.TARIFENO);
        var dtoForPdfRender = new PoliceForPdfRenderDto()
        {
            TC = person.KIMLIKNO,
            Ad = sigortali.AD,
            Soyad = sigortali.SOYAD,
            Uyruk = person.ULKEUYRUK,
            Ulke = person.ULKEUYRUK,
            DogumYeri = person.DOGUMYERI,
            ZeylTip = zeyl.ZEYLTIP,
            TarifeUzunAd = tarife.UZUNAD
        };
        dtoListForPdfRender.Add(dtoForPdfRender);
    }
    PdfCreateHelper.CreatePdf(dtoListForPdfRender);
}

void HandleExcelFilters()
{
    var policeService = new PoliceManager();
    var personService = new PersonManager();
    var sigortaliService = new SigortaliManager();
    var zeylService = new ZeylManager();
    var tarifeService = new TarifeManager();
    var police = policeService.GetRecords();
}

Console.WriteLine("1) The Tah Hata Kayıtlarını Logla");
Console.WriteLine("2) VKFE Kayıtlarını Logla");
Console.WriteLine("3) Police PDF'i oluştur");
Console.WriteLine("4) Excel Üzerinden Veri Filtrele");
Console.Write("Yapmak istediğiniz işlemin numarasını giriniz: ");

var islem = Console.ReadLine();

switch(islem) 
{
    case "1":
        LogTheTahHataRecords();
        Console.WriteLine("Loglama İşlemi Başarılı");
        break;
    case "2":
        LogVKFERecords();
        Console.WriteLine("Loglama İşlemi Başarılı");
        break;
    case "3":
        Console.WriteLine("PDF oluşturuluyor...");
        HandlePolicePdfRendering();
        Console.WriteLine("PDF files klasörü altında oluşturuldu");
        break;
    case "4":
        Console.WriteLine("1) Kaç Farklı Zeyl Tipinde Poliçe Vardır ve Açıklamaları Nelerdir?");
        Console.WriteLine("2) 30 Yaş Üstü Müşteri Sayısı");
        Console.WriteLine("3) Kaç Farklı Tarife Numarasına Ait Poliçe Vardır ve Tarife Numaralarının Açıklamaları Nelerdir?");
        Console.WriteLine("4) Ferdi Kaza, Hayat Emeklilik tipindeki poliçelerden kaçar adet üretim yapılmıştır?");
        Console.Write("Yapmak istediğiniz işlemin numarasını giriniz: ");
        var filtreIslem = Console.ReadLine();
        var excelFilterService = new ExcelFiltersManager();
        switch(filtreIslem) 
        {
            case "1":
                Console.WriteLine(excelFilterService.KacFarkliZeyltipPoliceVardirVeAciklamalari());
                break;
            case "2":
                Console.WriteLine(excelFilterService.OtuzYasUstuMusteriSayisi());
                break;
            case "3":
                Console.WriteLine(excelFilterService.KacFarkliTarifeNoyaAitPoliceVardirVeAciklamalari());
                break;
            case "4":
                Console.WriteLine(excelFilterService.FKHETipindekiPolicelerdenKacarAdetVardır());
                break;
            default:
                break;
        }
        break;
    default:
        break;
}