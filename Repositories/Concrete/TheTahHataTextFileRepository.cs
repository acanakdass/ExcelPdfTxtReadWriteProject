using ReadWriteConsoleApp.Helpers;
using ReadWriteConsoleApp.Models;
using ReadWriteConsoleApp.Repositories.Abstract;

namespace ReadWriteConsoleApp.Repositories.Concrete;

public class TheTahHataTextFileRepository : ITextFileRepository<TheTahHata>
{
    private static string fileName = "THE_TAH_HATA_13052022.txt";

    public IList<TheTahHata> GetDatas()
    {
        string[] lines = System.IO.File.ReadAllLines(
            @"/Users/ahmetcanakdas/RiderProjects/ReadWriteProject/ReadWriteConsoleApp/files/" + fileName);
        var theTahHataDatas = new List<TheTahHata>();
        foreach (string line in lines)
        {
            var brans = line.Substring(0, 2).Trim();
            var sayacNo = line.Substring(3, 15).Trim();
            var police = line.Substring(17, 15).Trim();
            var donem = line.Substring(32, 10).Trim();
            var borcTipi = line.Substring(42, 5).Trim();
            var tutar = line.Substring(47, 21).Trim();
            var adSoyad = line.Substring(68, 50).Trim();
            var hataKod = line.Substring(118, 15).Trim();

            if (brans == "Z3")
                brans = "E";
            else if (brans == "Z4")
                brans = "H";
            else if (brans == "Z5")
                brans = "K";

            if (brans != "H" || brans != "K" || brans != "E")
                hataKod = "Geçersiz Branş Kodu";

            var theTahHataData = new TheTahHata()
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
            theTahHataDatas.Add(theTahHataData);
        }

        return theTahHataDatas;
    }

    public void LogDatasToFile(string logFileName, IList<TheTahHata> datasToLog)
    {
        foreach (var tth in datasToLog)
        {   
            FileWriterHelper.LogToFile(logFileName,
                $"{tth.Donem},{tth.AdSoyad},{tth.Police},{tth.Brans}");
        }
    }
}