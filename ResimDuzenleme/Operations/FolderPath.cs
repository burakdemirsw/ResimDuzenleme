using ResimDuzenleme.Ubl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResimDuzenleme.Operations
{
    public class FileOperations
    {
        public static string FilePath(string type, string Direction)
        {
            string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (type == nameof(EI.Type.INVOICE))
            {
                return string.Format("{0}{1}", folderpath, Direction.Equals(nameof(EI.Direction.IN)) ? @"\GelenFatura\" : Direction.Equals(nameof(EI.Direction.OUT)) ? @"\GidenFatura\" : @"\TaslakFatura\");
            }
            else if (type == nameof(EI.Type.DESPATCH))
            {
                return string.Format("{0}{1}", folderpath, Direction.Equals(nameof(EI.Direction.IN)) ? @"\Gelenİrsaliye\" : Direction.Equals(nameof(EI.Direction.OUT)) ? @"\Gidenİrsaliye\" : @"\Taslakİrsaliye\");
            }
            else if (type == nameof(EI.Type.EARCHIVEINVOICE))
            {
                return string.Format("{0}{1}", folderpath, @"\ArşivFatura\");
            }
            else if (type == nameof(EI.Type.CREDITNOTE))
            {
                return string.Format("{0}{1}", folderpath, @"\E-Mühtahsil\");
            }
            else if (type == nameof(EI.Type.RECEIPT))
            {
                return string.Format("{0}{1}", folderpath, @"\EIrsaliyeYanıt\");
            }
            return null;
        }

        public static string Files(string proces, string type)
        {
            if (type == nameof(EI.Type.INVOICE))
            {
                FileYesNo(FilePaths.InvoicePath);
                return string.Format("{0}{1}", FilePaths.InvoicePath, proces.Equals(nameof(EI.FileName.LOADINVOICE)) ? @"\LoadInvoice\" : @"\SendInvoice\");
            }
            else if (type == nameof(EI.Type.DESPATCH))
            {
                FileYesNo(FilePaths.InvoicePath);
                return string.Format("{0}{1}", FilePaths.DespatchPath, proces.Equals(nameof(EI.FileName.LOADDESPATCH)) ? @"\LoadDespatch\" : @"\SendDespatch\");
            }
            else if (type == nameof(EI.Type.EARCHIVEINVOICE))
            {
                FileYesNo(FilePaths.InvoicePath);
                return string.Format("{0}{1}", FilePaths.ArchiveInvoicePath, proces.Equals(nameof(EI.FileName.EARCHIVEINVOICEDRAFT)) ? @"\DraftEArchive\" : @"\EArchive\");
            }
            else if (type == nameof(EI.Type.CREDITNOTE))
            {
                FileYesNo(FilePaths.InvoicePath);
                return string.Format("{0}{1}", FilePaths.CreditNotePath, proces.Equals(nameof(EI.FileName.CREDITNOTELOAD)) ? @"\DraftCreditNote\" : @"\CreditNote\");
            }
            else if (type == nameof(EI.Type.RECEIPT))
            {
                FileYesNo(FilePaths.InvoicePath);
                return string.Format("{0}{1}", FilePaths.ReceiptDespatchPath, proces.Equals(nameof(EI.FileName.RECEIPTLOAD)) ? @"\LoadReceipt\" : @"\SendReceipt\");
            }
            else if (type == nameof(EI.Type.SMM))
            {
                FileYesNo(FilePaths.InvoicePath);
                return string.Format("{0}{1}", FilePaths.SmmPath, proces.Equals(nameof(EI.FileName.SMMSEND)) ? @"\SmmSend\" : @"\SmmLoad\");
            }

            return null;
        }


        public static void FileYesNo(String path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }


        public static void SendAndLoadSaveToDisk(string process, string ID, string UUID, byte[] zipFile, string type)//Send ve load invoicelarda istek başarılı ise gönderilen(programdaki xml dosyası) diske yazmak için
        {
            string filePath = Files(process, type);

            FileYesNo(filePath);

            File.WriteAllBytes(filePath + ID + "-" + UUID + ".zip", zipFile);
        }


        public static string SaveToDisk(byte[] xmlContent, string Filename_UUID, string Direction, string Compressed, string type, string documentType, string Filename_ID = "")
        {
            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var specificFolder = ""; // Özel klasör adı, örneğin "Faturalar"

            if (type == nameof(EI.Type.EARCHIVEINVOICE))
            {
                specificFolder = "ArşivFaturalar";
            }
            // Diğer dosya türleri için benzer koşullar ekleyebilirsiniz.

            var filePath = Path.Combine(folderPath, specificFolder);
            FileYesNo(filePath); // Klasör var mı diye kontrol eder, yoksa oluşturur.

            string savedFilePath;
            string fileName = Filename_ID != "" ? Filename_ID + "-" + Filename_UUID : Filename_UUID;

            if (documentType == "NULL")
            {
                savedFilePath = Path.Combine(filePath, fileName + ".xml");
                // Burada HTML içeriğini 'decodedString' olarak varsayıyorum.
                string decodedString = Encoding.UTF8.GetString(xmlContent);
                File.WriteAllText(savedFilePath, decodedString);
            }
            else
            {
                // PDF veya diğer formatları kaydetme işlemi
                string fileExtension = documentType.ToLower();
                savedFilePath = Path.Combine(filePath, fileName + "." + fileExtension);
                File.WriteAllBytes(savedFilePath, xmlContent);
            }

            return savedFilePath;
        }

        public static byte[] DocumentUnzip(byte[] xmlContent, string compressed)
        {
            if (compressed.Equals(nameof(EI.YesNo.Y)))
            {
                return xmlContent = Compress.ZipFile(xmlContent);
            }
            return xmlContent;
        }

        public static byte[] ArchiveUnzip(byte[] xmlContent, string compressed, string documentType)
        {
            if (compressed.Equals(nameof(EI.YesNo.Y)) && documentType == "HTML")
            {
                return xmlContent = Compress.ZipFile(Compress.ZipFile(xmlContent));
            }
            else if (documentType == "PDF")
            {
                return xmlContent = Compress.ZipFile(xmlContent);
            }
            return xmlContent;
        }


    }
}
