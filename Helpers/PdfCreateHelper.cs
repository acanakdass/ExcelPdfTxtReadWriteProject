using System.Text;
using IronPdf;
using ReadWriteConsoleApp.DTOs;

namespace ReadWriteConsoleApp.Helpers;

public static class PdfCreateHelper
{
    public static void CreatePdf(List<PoliceForPdfRenderDto> dtos)
    {
        var ChromePdfRenderer = new ChromePdfRenderer();

        //ChromePdfRenderer.RenderHtmlAsPdf(ImgHtml);
        var htmlFooter = new IronPdf.HtmlHeaderFooter();
        ChromePdfRenderer.RenderingOptions.FitToPaperWidth=true;
        ChromePdfRenderer.RenderingOptions.MarginLeft = 20;
        ChromePdfRenderer.RenderingOptions.MarginTop = 10;
        StringBuilder tableRows = new StringBuilder("");
        dtos.ForEach(dto =>{
            tableRows.Append($@"
                            <tr>
                                 <td>{dto.TC}</td>
                                 <td>{dto.Ad}</td>
                                 <td>{dto.Soyad}</td>
                                 <td>{dto.Uyruk}</td>
                                 <td>{dto.Ulke}</td>
                                 <td>{dto.DogumYeri}</td>
                                 <td>{dto.TarifeUzunAd}</td>
                                 <td>{dto.ZeylTip}</td>
                             </tr>");
        });
        
        var htmlString = $@"
    <!DOCTYPE html>
        <head>
                <link rel=""stylesheet"" href=""./CssForPdf.css"">
                <img class=""center-img"" src=""./bis-logo.svg""/>
        </head>
        <body>
                <div class=""table-container"">
                        <table class=""table"">
                            <tr>
                                <th>T.C.</th>
                                <th>Ad</th>
                                <th>Soyad</th>
                                <th>Uyruk</th>
                                <th>Ülke</th>
                                <th>Doğum Yeri</th>
                                <th>Tarife Uzun Ad</th>
                                <th>Zeyl Tip</th>
                            </tr>
                                {tableRows.ToString()}
                        </table>
                    </div>
                    <footer class=""footer"">
                        <h4 style=""text-align: center"">©2021 Türkiye Sigorta A.Ş.</h4>
                        <h4 style=""text-align: center"">Telefon : +90 (850) 202 20 20</h4>
                        <p style=""text-align: center""><b>Müşteri İletişim Merkezi:</b>
                        Levent Mah. Çayır Çimen Sok. No:7 34330 Levent-Beşiktaş/İSTANBUL</p>
                    </footer>
        </body>
    </html>";
        
        using var PDF = ChromePdfRenderer.RenderHtmlAsPdf(
            htmlString, "/Users/ahmetcanakdas/RiderProjects/ReadWriteProject/ReadWriteConsoleApp/Assets/");
        PDF.SaveAs("/Users/ahmetcanakdas/RiderProjects/ReadWriteProject/ReadWriteConsoleApp/files/pdfFileExample.pdf");
    }
}