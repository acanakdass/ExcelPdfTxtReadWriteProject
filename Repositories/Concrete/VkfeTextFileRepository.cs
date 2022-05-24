using ReadWriteConsoleApp.Helpers;
using ReadWriteConsoleApp.Models;
using ReadWriteConsoleApp.Repositories.Abstract;

namespace ReadWriteConsoleApp.Repositories.Concrete;

public class VkfeTextFileRepository : ITextFileRepository<VKFE>
{
    private static string basePath = @"/Users/ahmetcanakdas/RiderProjects/ReadWriteProject/ReadWriteConsoleApp/files";
    private static string vkfeFileName = "VKFE20220513030052.txt";

    public IList<VKFE> GetDatas()
    {
        string[] lines = System.IO.File.ReadAllLines($"{basePath}/{vkfeFileName}");
        var vkfeDatas = new List<VKFE>();
        foreach (string line in lines)
        {
            var brans = line.Substring(0, 1).Trim();
            var sayacNo = line.Substring(2, 15).Trim();
            var police = line.Substring(16, 15).Trim();
            var donem = line.Substring(31, 10).Trim();
            var borcTipi = line.Substring(41, 5).Trim();
            var tutar = line.Substring(46, 21).Trim();
            var adSoyad = line.Substring(67, 50).Trim();
            var hataKod = line.Substring(117, 15).Trim();

            if (!(brans == "H" || brans == "K" || brans == "E"))
                hataKod = "Geçersiz Branş Kodu";


            var vkfeData = new VKFE
            {
                AdSoyad = adSoyad,
                HataKod = hataKod,
                Tutar = tutar,
                BorcTipi = borcTipi,
                Donem = donem,
                Police = police,
                SayacNo = sayacNo,
                Brans = brans
            };
            vkfeDatas.Add(vkfeData);
        }

        return vkfeDatas;
    }

    public void LogDatasToFile(string logFileName, IList<VKFE> datasToLog)
    {
        foreach (var vkfe in datasToLog)
        {
            FileWriterHelper.LogToFile(logFileName,
                $"{vkfe.Donem},{vkfe.AdSoyad},{vkfe.Police},{vkfe.Brans}");
        }
    }
}