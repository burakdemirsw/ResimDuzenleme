using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ResimDuzenleme.Services.Helpers
{
    public static class GeneralService
    {

        public static string GenerateRandomNumber( )
        {
            Random rand = new Random();
            StringBuilder sb = new StringBuilder();

            // İlk rakamın 0 olmaması için ayrı bir işlem yapılır
            sb.Append(rand.Next(1, 10));

            // Kalan 14 hane için döngü
            for (int i = 1; i < 15; i++)
            {
                sb.Append(rand.Next(0, 10));
            }

            string randomNumberString = sb.ToString();

            return randomNumberString;
        }
        public static async Task<string> ConvertPngToPdf(string file)
        {
            var pdfDirectoryPath = $"C:\\code\\{Guid.NewGuid()}.pdf";
            using (RichEditDocumentServer server = new RichEditDocumentServer())
            {
                // Insert an image
                DocumentImage docImage = server.Document.Images.Append(DocumentImageSource.FromFile(file));

                // Adjust the page width and height to the image's size
                server.Document.Sections[0].Page.Width = docImage.Size.Width + server.Document.Sections[0].Margins.Right + server.Document.Sections[0].Margins.Left;
                server.Document.Sections[0].Page.Height = docImage.Size.Height + server.Document.Sections[0].Margins.Top + server.Document.Sections[0].Margins.Bottom;

                // Generate the new file path with .pdf extension in the pdf directory


                // Export the result to PDF
                using (FileStream fs = new FileStream(pdfDirectoryPath, FileMode.OpenOrCreate))
                {
                    server.ExportToPdf(fs);
                    return pdfDirectoryPath;
                }
            }
        }
        public static async Task<string> ConvertZplToPng(string zpl)
        {
            var zplAsBytes = System.Text.Encoding.UTF8.GetBytes(zpl);
            var requestContent = new ByteArrayContent(zplAsBytes);

            requestContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(
                "application/x-www-form-urlencoded"
            );

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(
                    "http://api.labelary.com/v1/printers/8dpmm/labels/4x4/0/",
                    requestContent
                );

                if (response.IsSuccessStatusCode)
                {
                    using (var ms = await response.Content.ReadAsStreamAsync())
                    {
                        var guid = Guid.NewGuid().ToString();
                        var path = @"C:\code\" + guid + ".pdf";
                        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                        {
                            ms.CopyTo(fs);
                            fs.Flush();
                        }
                        var pdfPath = await ConvertPngToPdf(path);


                        return pdfPath;
                    }
                }
                else
                {
                    throw new Exception("Kargo Barkodu Oluşturulamadı");
                }
            }
        }

        public static Task PrintWithoutDialog(Bitmap image)
        {
            return Task.Run(( ) =>
            {
                System.Drawing.Printing.PrintDocument printDocument =
                    new System.Drawing.Printing.PrintDocument();

                // Yazdırma yönünü yatay (landscape) olarak ayarla


                printDocument.DefaultPageSettings.Landscape = true;
                // DPI değerlerini al
                int dpiX = (int)(image.HorizontalResolution);
                int dpiY = (int)(image.VerticalResolution);

                // 10cm x 10cm boyutunu piksele çevir
                float cmToInch = 0.393701f; // 1 cm = 0.393701 inç
                int width = (int)(10 * cmToInch * dpiX);
                int height = (int)(10 * cmToInch * dpiY);

                printDocument.PrintPage += (s, args) =>
                {
                    // Belirlenen boyutta ve konumda resmi çiz
                    args.Graphics.DrawImage(image, 0, 0, width, height);
                };

                // Yazıcı adını belirt (örneğinizde "KARGOBARKOD" kullanılmış)
                printDocument.PrinterSettings.PrinterName = "KARGOYAZICISI";

                // Diyalog göstermeden yazdırmak için Standart Yazdırma Kontrolörü kullan
                printDocument.PrintController = new StandardPrintController();

                // Yazdırma işlemini başlat
                printDocument.Print();
            });
        }

        public static async Task<string> ConvertAndPrintBarcode(string zpl)
        {
            var zplAsBytes = System.Text.Encoding.UTF8.GetBytes(zpl);
            var requestContent = new ByteArrayContent(zplAsBytes);

            requestContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(
                "application/x-www-form-urlencoded"
            );

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(
                    "http://api.labelary.com/v1/printers/8dpmm/labels/4x4/0/",
                    requestContent
                );

                if (response.IsSuccessStatusCode)
                {
                    using (var ms = await response.Content.ReadAsStreamAsync())
                    {
                        var guid = Guid.NewGuid().ToString();
                        var path = @"C:\code\" + guid + ".png";
                        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                        {
                            ms.CopyTo(fs);
                            fs.Flush();
                        }

                        Bitmap myBitmap = new Bitmap(path);
                        await PrintWithoutDialog(myBitmap);
                        return path;
                    }
                }
                else
                {
                    throw new Exception("Kargo Barkodu Oluşturulamadı");
                }
            }
        }
    }
}
