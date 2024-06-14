using CsvHelper;
using Google.Cloud.Translation.V2;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using ResimDuzenleme.SiparisServis;
using System;
using System.Collections.Generic;
//using System.Threading;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;


namespace ResimDuzenleme
{
    public partial class Form1 : Form
    {
        private TrendyolService _trendyolService;
        private DatabaseService _databaseService;
        string ipAdresi = Properties.Settings.Default.txtEntegrator;
        private ServiceController serviceController;

        private int remainingMinutes = 1;


        public Form1( )
        {
            InitializeComponent();
            var apiKey = Properties.Settings.Default.txtApiKey;
            var apiSecret = Properties.Settings.Default.txtApiSecret;
            StaticVariables.alanAdi = Properties.Settings.Default.txtSiteAdi;
            StaticVariables.uyeKodu = Properties.Settings.Default.txtWsYetki;
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;

            var connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            _trendyolService = new TrendyolService(apiKey, apiSecret);
            _databaseService = new DatabaseService();
            Timer myTimer = new Timer();
            myTimer.Interval = 3600000; // 5 dakika
            myTimer.Tick += new EventHandler(MyTimer_Tick);
            myTimer.Start();
        }




        private void MyTimer_Tick(object sender, EventArgs e)
        {
            // Burada butonun click event'ini çağırıyoruz.
            misigoÜrünleriGüncelleToolStripMenuItem.PerformClick();
        }


        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }


        private async Task<string> ConnectIntegrator( )
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://" + ipAdresi + "/IntegratorService/Connect");

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                VM_HttpConnectionRequest session = JsonConvert.DeserializeObject<VM_HttpConnectionRequest>(responseBody);

                string sessionId = session.SessionId;
                // Console.WriteLine(responseBody);
                return sessionId;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP isteği başarısız: {ex.Message}");
                return null;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {


        }
        private void InstallService(string serviceFilePath)
        {
            ManagedInstallerClass.InstallHelper(new string[] { serviceFilePath });
        }

        // Servisi kaldırmak için
        private void UninstallService(string serviceFilePath)
        {
            ManagedInstallerClass.InstallHelper(new string[] { "/u", serviceFilePath });
        }

        // Servis durumunu kontrol etmek için
        private bool IsServiceInstalled(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController service in services)
            {
                if (service.ServiceName == serviceName)
                    return true;
            }
            return false;
        }

        // Servisi başlatmak için
        private void StartService(string serviceName, int timeoutMilliseconds)
        {
            using (ServiceController service = new ServiceController(serviceName))
            {
                try
                {
                    if (service.Status != ServiceControllerStatus.Running)
                    {
                        service.Start();
                        service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMilliseconds(timeoutMilliseconds));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    // Hata işleme
                }
            }
        }

        // Servisi durdurmak için
        private void StopService(string serviceName, int timeoutMilliseconds)
        {
            using (ServiceController service = new ServiceController(serviceName))
            {
                try
                {
                    if (service.Status != ServiceControllerStatus.Stopped)
                    {
                        service.Stop();
                        service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMilliseconds(timeoutMilliseconds));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    // Hata işleme
                }
            }
        }
        //private void StartTimer()
        //{
        //    // Timer'ı başlat
        //    countdownTimer = new System.Threading.Timer(CountdownTick, null, 0, 1000 * 60); // 1 dakika (60 saniye) interval
        //}
        //private async void CountdownTick(object state)
        //{
        //    // Her bir tick'te burası çalışır
        //    remainingMinutes--;

        //    if (remainingMinutes <= 0)
        //    {
        //       await UpdateDownloadedItemUpdate();
        //        await ResimEkle();
        //        await FiyatDuzenle();
        //        await StokGuncelle();
        //        remainingMinutes = 60;
        //    }

        //    // Kalan dakikayı güncelleme işlemleri
        //    UpdateRemainingTime();
        //}

        private void UpdateRemainingTime( )
        {
            if (label2.InvokeRequired)
            {
                ((ISynchronizeInvoke)this).Invoke((MethodInvoker)(( ) =>
                {
                    label2.Text = $"{remainingMinutes} dakika kaldı";
                }), null);
            }
            else
            {
                label2.Text = $"{remainingMinutes} dakika kaldı";
            }
        }

        //private async void TumunuGuncelle()
        //{
        //    await UpdateDownloadedItem();



        //}
        private void Form1_Load(object sender, EventArgs e)
        {


            // Servis adını burada değiştirin.
            serviceController = new ServiceController("TicimaxMusteriAktar");
            try
            {
                if (serviceController.Status == ServiceControllerStatus.Running)
                {
                    // Servis çalışıyorsa düğmeyi yeşil yap.
                    button1.BackColor = System.Drawing.Color.Green;
                }
                else
                {
                    // Servis çalışmıyorsa düğmeyi kırmızı yap.
                    button1.BackColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Olmadı");
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            string spName = "MSG_GetUrunListesi";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ExportToExcel(dt);
            }
        }

        private void ExportToExcel(DataTable dt)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkBook = excelApp.Workbooks.Add();
            Excel._Worksheet excelWorkSheet = excelWorkBook.Sheets[1];

            excelWorkSheet.Columns[1].ColumnWidth = 24; // Column A will be set to approximately 200 pixels in width

            Dictionary<string, int> addedProductCodes = new Dictionary<string, int>(); // Creating a Dictionary to store the Product and Color codes
            int rowCount = 2;  // Indicates the first row where data will be added

            for (int i = 1; i < dt.Columns.Count; i++) // Adding column names to the first row
            {
                excelWorkSheet.Cells[1, i + 2] = dt.Columns[i].ColumnName;
            }

            foreach (DataRow row in dt.Rows)
            {
                string productCode = row["UrunKodu"].ToString();
                string colorCode = row["ColorCode"].ToString();
                string uniqueCode = productCode + "-" + colorCode;  // Generate unique code

                if (!addedProductCodes.ContainsKey(uniqueCode)) // If this unique code was not added before, then add the picture and write 'Misigo'
                {
                    addedProductCodes[uniqueCode] = rowCount;
                    string picturePath = row["Photo"].ToString();
                    float left = (float)((double)excelWorkSheet.Cells[rowCount, 1].Left);
                    float top = (float)((double)excelWorkSheet.Cells[rowCount, 1].Top);

                    if (!File.Exists(picturePath))
                    {
                        picturePath = "C:\\Resim\\resimyok.jpg";  // Replace with your default image path
                    }

                    Excel.Shape picture = excelWorkSheet.Shapes.AddPicture(picturePath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, left, top, 130, 180);

                    rowCount += 12;  // Skip to the 12th row after this one
                }

                int startRow = addedProductCodes[uniqueCode];
                for (int j = 1; j < dt.Columns.Count; j++)
                {
                    excelWorkSheet.Cells[startRow, j + 2] = row[j].ToString();
                }

                addedProductCodes[uniqueCode]++;  // Move to the next row
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel | *.xls;*.xlsx;*.xlsm";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                excelWorkBook.SaveAs(saveFileDialog.FileName);
                excelWorkBook.Close();
                excelApp.Quit();
            }
        }



        private void ExportToCsv(DataTable dt)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Dosyaları | *.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var writer = new StreamWriter(sfd.FileName, false, Encoding.GetEncoding("iso-8859-9"))) // ISO-8859-9 kodlamasını kullan
                {
                    var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        Delimiter = ";"
                    };

                    using (var csv = new CsvWriter(writer, config)) // CultureInfo.InvariantCulture ve yeni ayırıcı karakteri kullan
                    {
                        foreach (DataColumn column in dt.Columns)
                        {
                            csv.WriteField(column.ColumnName);
                        }
                        csv.NextRecord();

                        foreach (DataRow row in dt.Rows)
                        {
                            for (var i = 0; i < dt.Columns.Count; i++)
                            {
                                csv.WriteField(row[i]);
                            }
                            csv.NextRecord();
                        }
                    }
                }
            }
        }


        private void ImportToSqlFromExcel(string filePath)
        {
            IWorkbook workbook;

            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(stream);  // XSSF for .xlsx, HSSF for .xls
            }

            ISheet sheet = workbook.GetSheetAt(0);  // 0-indexed (get the first sheet)

            List<string> barcodeList = new List<string>();

            for (int i = 1; i <= sheet.LastRowNum; i++)  // 0-indexed (skip the header row)
            {
                IRow row = sheet.GetRow(i);

                ICell barcodeCell = row.GetCell(0);  // Assuming the barcode is in the first column (0-indexed)
                string barcode = barcodeCell.ToString();
                barcodeList.Add(barcode);
            }


            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (string Barkod in barcodeList)
                {
                    string insertQuery = "INSERT INTO ZTMSGTrendyolSiparis (Barkod) VALUES (@Barkod)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Barkod", Barkod);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }


        private void ImportBarkodToSqlFromExcel(string filePath)
        {
            IWorkbook workbook;

            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(stream);  // XSSF for .xlsx, HSSF for .xls
            }

            ISheet sheet = workbook.GetSheetAt(0);  // 0-indexed (get the first sheet)

            progressBar1.Minimum = 0;
            progressBar1.Maximum = sheet.LastRowNum;

            for (int i = 1; i <= sheet.LastRowNum; i++)  // 0-indexed (skip the first row)
            {

                try
                {
                    IRow row = sheet.GetRow(i);
                    string cellValue;
                    string Barkod = row.GetCell(0)?.ToString();
                    string PaketNo = row.GetCell(1)?.ToString();
                    string KargoFirmasi = row.GetCell(2)?.ToString();
                    DateTime SiparisTarihi = DateTime.Parse(row.GetCell(3).ToString());
                    DateTime TerminSuresininBittigiTarih = DateTime.Parse(row.GetCell(4).ToString());
                    DateTime KargoyaTeslimTarihi = DateTime.Parse(row.GetCell(5).ToString());
                    string KargoKodu = row.GetCell(6)?.ToString();
                    string SiparisNumarasi = row.GetCell(7)?.ToString();
                    string Alici = row.GetCell(8)?.ToString();
                    string TeslimatAdresi = row.GetCell(9)?.ToString();
                    string UrunAdi = row.GetCell(10)?.ToString();
                    string FaturaAdresi = row.GetCell(11)?.ToString();
                    string AliciFaturaAdresi = row.GetCell(12)?.ToString();
                    string SiparisStatusu = row.GetCell(13)?.ToString();
                    string EPosta = row.GetCell(14)?.ToString();
                    cellValue = row.GetCell(15)?.ToString().Replace('.', ',');
                    decimal KomisyonOrani = decimal.TryParse(cellValue, out decimal komisyonOrani) ? komisyonOrani : 0.00m;

                    string Marka = row.GetCell(16)?.ToString();
                    string StokKodu = row.GetCell(17)?.ToString();
                    int Adet = int.TryParse(row.GetCell(18)?.ToString(), out int adet) ? adet : 0;




                    // float BirimFiyati = float.TryParse(cellValue, out float birimFiyati) ? birimFiyati : 0.0f;
                    //  float BirimFiyati = float.TryParse(row.GetCell(19)?.ToString(), out float birimFiyati) ? birimFiyati : 0.0f;

                    cellValue = row.GetCell(19)?.ToString().Replace('.', ',');
                    decimal BirimFiyati = decimal.TryParse(cellValue, out decimal birimFiyati) ? birimFiyati : 0.00m;

                    cellValue = row.GetCell(20)?.ToString().Replace('.', ',');
                    decimal SatisTutari = decimal.TryParse(cellValue, out decimal satisTutari) ? satisTutari : 0.00m;

                    cellValue = row.GetCell(21)?.ToString().Replace('.', ',');
                    decimal IndirimTutari = decimal.TryParse(cellValue, out decimal indirimTutari) ? indirimTutari : 0.00m;

                    cellValue = row.GetCell(22)?.ToString().Replace('.', ',');
                    decimal TrendyolIndirimTutari = decimal.TryParse(cellValue, out decimal trendyolIndirim) ? trendyolIndirim : 0.00m;

                    cellValue = row.GetCell(23)?.ToString().Replace('.', ',');
                    decimal FaturalanacakTutar = decimal.TryParse(cellValue, out decimal faturalanacakTutar) ? faturalanacakTutar : 0.00m;


                    int ButikNumarasi = int.TryParse(row.GetCell(24)?.ToString(), out int butikNumarasi) ? butikNumarasi : 0;
                    DateTime TeslimTarihi = DateTime.TryParse(row.GetCell(25)?.ToString(), out DateTime parsedSiparisTarihi) ? parsedSiparisTarihi : DateTime.Now;
                    cellValue = row.GetCell(26)?.ToString().Replace('.', ',');
                    decimal KargodanAlinanDesi = decimal.TryParse(cellValue, out decimal kargodanAlinanDesi) ? kargodanAlinanDesi : 0.00m;

                    cellValue = row.GetCell(27)?.ToString().Replace('.', ',');
                    decimal HesapladigimDesi = decimal.TryParse(cellValue, out decimal hesapladigimDesi) ? hesapladigimDesi : 0.00m;

                    cellValue = row.GetCell(28)?.ToString().Replace('.', ',');
                    decimal FaturalananKargoTutari = decimal.TryParse(cellValue, out decimal faturalananKargo) ? faturalananKargo : 0.00m;

                    string AlternatifTeslimatStatusu = row.GetCell(29)?.ToString();
                    string KurumsalFaturaliSiparis = row.GetCell(30)?.ToString();
                    string VergiKimlikNumarasi = row.GetCell(31)?.ToString();
                    string VergiDairesi = row.GetCell(32)?.ToString();
                    string SirketIsmi = row.GetCell(33)?.ToString();
                    string ArkadaslarinlaAlSiparisi = row.GetCell(34)?.ToString();
                    string Fatura = row.GetCell(35)?.ToString();
                    int MusteriSiparisAdedi = int.TryParse(row.GetCell(36)?.ToString(), out int musteriSiparisAdedi) ? musteriSiparisAdedi : 0;

                    InsertDataToSql(Barkod, PaketNo, KargoFirmasi, SiparisTarihi, TerminSuresininBittigiTarih, KargoyaTeslimTarihi, KargoKodu, SiparisNumarasi, Alici, TeslimatAdresi, UrunAdi, FaturaAdresi, AliciFaturaAdresi, SiparisStatusu, EPosta, KomisyonOrani, Marka, StokKodu, Adet, BirimFiyati, SatisTutari, IndirimTutari, TrendyolIndirimTutari, FaturalanacakTutar, ButikNumarasi, TeslimTarihi, KargodanAlinanDesi, HesapladigimDesi, FaturalananKargoTutari, AlternatifTeslimatStatusu, KurumsalFaturaliSiparis, VergiKimlikNumarasi, VergiDairesi, SirketIsmi, ArkadaslarinlaAlSiparisi, Fatura, MusteriSiparisAdedi);

                    progressBar1.Value = i;
                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Satır {i} işlenirken bir hata oluştu: {ex.Message}");
                    // Eğer loglamak isterseniz ya da özel bir işlem yapmak isterseniz burayı kullanabilirsiniz.
                }
            }

            MessageBox.Show("Siparişler Kaydedildi!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InsertDataToSql(string Barkod, string PaketNo, string KargoFirmasi, DateTime SiparisTarihi, DateTime TerminSuresininBittigiTarih, DateTime KargoyaTeslimTarihi, string KargoKodu, string SiparisNumarasi, string Alici, string TeslimatAdresi, string UrunAdi, string FaturaAdresi, string AliciFaturaAdresi, string SiparisStatusu, string EPosta, decimal KomisyonOrani, string Marka, string StokKodu, int Adet, decimal BirimFiyati, decimal SatisTutari, decimal IndirimTutari, decimal TrendyolIndirimTutari, decimal FaturalanacakTutar, int ButikNumarasi, DateTime TeslimTarihi, decimal KargodanAlinanDesi, decimal HesapladigimDesi, decimal FaturalananKargoTutari, string AlternatifTeslimatStatusu, string KurumsalFaturaliSiparis, string VergiKimlikNumarasi, string VergiDairesi, string SirketIsmi, string ArkadaslarinlaAlSiparisi, string Fatura, int MusteriSiparisAdedi)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            string query = @"INSERT INTO ZTMSGTrendyolSiparis (Barkod, PaketNo, KargoFirmasi, SiparisTarihi, TerminSuresininBittigiTarih, KargoyaTeslimTarihi, KargoKodu, SiparisNumarasi, Alici, TeslimatAdresi, UrunAdi, FaturaAdresi, AliciFaturaAdresi, SiparisStatusu, EPosta, KomisyonOrani, Marka, StokKodu, Adet, BirimFiyati, SatisTutari, IndirimTutari, TrendyolIndirimTutari, FaturalanacakTutar, ButikNumarasi, TeslimTarihi, KargodanAlinanDesi, HesapladigimDesi, FaturalananKargoTutari, AlternatifTeslimatStatusu, KurumsalFaturaliSiparis, VergiKimlikNumarasi, VergiDairesi, SirketIsmi, ArkadaslarinlaAlSiparisi, Fatura, MusteriSiparisAdedi)
                   Values( @Barkod, @PaketNo, @KargoFirmasi, @SiparisTarihi, @TerminSuresininBittigiTarih, @KargoyaTeslimTarihi, @KargoKodu, @SiparisNumarasi, @Alici, @TeslimatAdresi, @UrunAdi, @FaturaAdresi, @AliciFaturaAdresi, @SiparisStatusu, @EPosta, @KomisyonOrani, @Marka, @StokKodu, @Adet, @BirimFiyati, @SatisTutari, @IndirimTutari, @TrendyolIndirimTutari, @FaturalanacakTutar, @ButikNumarasi, @TeslimTarihi, @KargodanAlinanDesi, @HesapladigimDesi, @FaturalananKargoTutari, @AlternatifTeslimatStatusu, @KurumsalFaturaliSiparis, @VergiKimlikNumarasi, @VergiDairesi, @SirketIsmi, @ArkadaslarinlaAlSiparisi, @Fatura, @MusteriSiparisAdedi)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@Barkod", Barkod);
                    cmd.Parameters.AddWithValue("@PaketNo", PaketNo);
                    cmd.Parameters.AddWithValue("@KargoFirmasi", KargoFirmasi);
                    cmd.Parameters.AddWithValue("@SiparisTarihi", SiparisTarihi);
                    cmd.Parameters.AddWithValue("@TerminSuresininBittigiTarih", TerminSuresininBittigiTarih);
                    cmd.Parameters.AddWithValue("@KargoyaTeslimTarihi", KargoyaTeslimTarihi);
                    cmd.Parameters.AddWithValue("@KargoKodu", KargoKodu);
                    cmd.Parameters.AddWithValue("@SiparisNumarasi", SiparisNumarasi);
                    cmd.Parameters.AddWithValue("@Alici", Alici);
                    cmd.Parameters.AddWithValue("@TeslimatAdresi", TeslimatAdresi);
                    cmd.Parameters.AddWithValue("@UrunAdi", UrunAdi);
                    cmd.Parameters.AddWithValue("@FaturaAdresi", FaturaAdresi);
                    cmd.Parameters.AddWithValue("@AliciFaturaAdresi", AliciFaturaAdresi);
                    cmd.Parameters.AddWithValue("@SiparisStatusu", SiparisStatusu);
                    cmd.Parameters.AddWithValue("@EPosta", EPosta);
                    cmd.Parameters.AddWithValue("@KomisyonOrani", KomisyonOrani);
                    cmd.Parameters.AddWithValue("@Marka", Marka);
                    cmd.Parameters.AddWithValue("@StokKodu", StokKodu);
                    cmd.Parameters.AddWithValue("@Adet", Adet);
                    cmd.Parameters.AddWithValue("@BirimFiyati", BirimFiyati);
                    cmd.Parameters.AddWithValue("@SatisTutari", SatisTutari);
                    cmd.Parameters.AddWithValue("@IndirimTutari", IndirimTutari);
                    cmd.Parameters.AddWithValue("@TrendyolIndirimTutari", TrendyolIndirimTutari);
                    cmd.Parameters.AddWithValue("@FaturalanacakTutar", FaturalanacakTutar);
                    cmd.Parameters.AddWithValue("@ButikNumarasi", ButikNumarasi);
                    cmd.Parameters.AddWithValue("@TeslimTarihi", TeslimTarihi);
                    cmd.Parameters.AddWithValue("@KargodanAlinanDesi", KargodanAlinanDesi);
                    cmd.Parameters.AddWithValue("@HesapladigimDesi", HesapladigimDesi);
                    cmd.Parameters.AddWithValue("@FaturalananKargoTutari", FaturalananKargoTutari);
                    cmd.Parameters.AddWithValue("@AlternatifTeslimatStatusu", AlternatifTeslimatStatusu);
                    cmd.Parameters.AddWithValue("@KurumsalFaturaliSiparis", KurumsalFaturaliSiparis);
                    cmd.Parameters.AddWithValue("@VergiKimlikNumarasi", VergiKimlikNumarasi);
                    cmd.Parameters.AddWithValue("@VergiDairesi", VergiDairesi);
                    cmd.Parameters.AddWithValue("@SirketIsmi", SirketIsmi);
                    cmd.Parameters.AddWithValue("@ArkadaslarinlaAlSiparisi", ArkadaslarinlaAlSiparisi);
                    cmd.Parameters.AddWithValue("@Fatura", Fatura);
                    cmd.Parameters.AddWithValue("@MusteriSiparisAdedi", MusteriSiparisAdedi);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void trendyolToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nebimToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trendyolToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TrendyolSiparisAktar frm = new TrendyolSiparisAktar();
            frm.Show();
        }

        private void resimDüzenlemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhotoDuzenleme frm = new PhotoDuzenleme();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonProcessImages_Click(object sender, EventArgs e)
        {
            PhotoDuzenleme frm = new PhotoDuzenleme();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void resimDüzenlemeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void trendyolApiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrendyolApi frm = new TrendyolApi();
            frm.Show();
        }

        private void nebimApiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NebimApi frm = new NebimApi();
            frm.Show();
        }

        private void resimDüzenlemeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PhotoDuzenleme frm = new PhotoDuzenleme();
            frm.Show();
        }

        private void excelİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelIslemleri frm = new ExcelIslemleri();
            frm.Show();

        }

        private void nebimExcellSiparişAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NebimSiparisAktarExcell frm = new NebimSiparisAktarExcell();
            frm.Show();
        }

        private void nebimÖdemeYöntemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NebimOdemeYontemleri frm = new NebimOdemeYontemleri();
            frm.Show();
        }

        private void siparişBarkodYazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SiparisBarkodYazdir frm = new SiparisBarkodYazdir();
            frm.Show();
        }

        private void barkodDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //XtraReport1 report = new XtraReport1();

            //// Tasarım aracını oluştur ve göster
            //ReportDesignTool designTool = new ReportDesignTool(report);
            //designTool.ShowDesignerDialog();
        }

        private void nebimÜrünAçmaParametreleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrunAcmaParametreleri frm = new UrunAcmaParametreleri();
            frm.Show();
        }

        private void nebimÜrünAçmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NebimUrunAcma frm = new NebimUrunAcma();
            frm.Show();
        }
        private async Task<List<ZTMSGTicUyeAdres>> VeritabanindanMusteriGetir( )
        {
            List<ZTMSGTicUyeAdres> musteriler = new List<ZTMSGTicUyeAdres>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("MSG_TicimaxMusteri", conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    ZTMSGTicUyeAdres musteri = new ZTMSGTicUyeAdres();

                    musteri.ModelType = Convert.ToInt32(reader["ModelType"]);
                    musteri.CurrAccCode = reader["CurrAccCode"].ToString();
                    musteri.CurrAccDescription = reader["CurrAccDescription"].ToString();
                    musteri.FirstName = reader["FirstName"].ToString();
                    musteri.LastName = reader["LastName"].ToString();
                    musteri.IsIndividualAcc = bool.Parse(reader["IsIndividualAcc"].ToString());
                    musteri.IdentityNum = reader["IdentityNum"].ToString();
                    musteri.TaxNumber = reader["TaxNumber"].ToString();
                    musteri.TaxOfficeCode = reader["TaxOfficeCode"].ToString();
                    musteri.CurrencyCode = reader["CurrencyCode"].ToString();
                    musteri.OfficeCode = reader["OfficeCode"].ToString();
                    musteri.IsSubjectToEInvoice = bool.Parse(reader["IsSubjectToEInvoice"].ToString());
                    musteri.WholeSalePriceGroupCode = reader["WholeSalePriceGroupCode"].ToString();
                    musteri.RetailSalePriceGroupCode = reader["RetailSalePriceGroupCode"].ToString();
                    musteri.CustomerTypeCode = Convert.ToInt32(reader["CustomerTypeCode"]);

                    string postalAddressesJson = reader["PostalAddresses"].ToString();
                    JArray postalAddressesArray = JArray.Parse(postalAddressesJson);
                    musteri.PostalAddresses = postalAddressesArray.ToObject<List<PostalAddress>>();

                    string attributesJson = reader["Attributes"].ToString();
                    JArray attributesArray = JArray.Parse(attributesJson);
                    musteri.Attributes = attributesArray.ToObject<List<Attribute>>();

                    string communicationsJson = reader["Communications"].ToString();
                    JArray communicationsArray = JArray.Parse(communicationsJson);
                    musteri.Communications = communicationsArray.ToObject<List<Communication>>();

                    musteriler.Add(musteri);
                }
            }

            return musteriler;
        }

        private async Task<List<ZTMSGTicUyeAdresR>> VeritabanindanMusteriGetirR( )
        {
            List<ZTMSGTicUyeAdresR> musteriler = new List<ZTMSGTicUyeAdresR>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("MSG_TicimaxMusteri_PR", conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    ZTMSGTicUyeAdresR musteri = new ZTMSGTicUyeAdresR();

                    musteri.ModelType = Convert.ToInt32(reader["ModelType"]);
                    musteri.CurrAccCode = reader["CurrAccCode"].ToString();
                    musteri.CurrAccDescription = reader["CurrAccDescription"].ToString();
                    musteri.FirstName = reader["FirstName"].ToString();
                    musteri.LastName = reader["LastName"].ToString();
                    musteri.IsIndividualAcc = bool.Parse(reader["IsIndividualAcc"].ToString());
                    musteri.IdentityNum = reader["IdentityNum"].ToString();
                    musteri.TaxNumber = reader["TaxNumber"].ToString();
                    musteri.TaxOfficeCode = reader["TaxOfficeCode"].ToString();
                    musteri.CurrencyCode = reader["CurrencyCode"].ToString();
                    musteri.OfficeCode = reader["OfficeCode"].ToString();
                    musteri.IsSubjectToEInvoice = bool.Parse(reader["IsSubjectToEInvoice"].ToString());
                    musteri.WholeSalePriceGroupCode = reader["WholeSalePriceGroupCode"].ToString();
                    musteri.RetailSalePriceGroupCode = reader["RetailSalePriceGroupCode"].ToString();
                    //   musteri.CustomerTypeCode = Convert.ToInt32(reader["CustomerTypeCode"]);

                    string postalAddressesJson = reader["PostalAddresses"].ToString();
                    JArray postalAddressesArray = JArray.Parse(postalAddressesJson);
                    musteri.PostalAddresses = postalAddressesArray.ToObject<List<PostalAddress>>();

                    //string attributesJson = reader["Attributes"].ToString();
                    //JArray attributesArray = JArray.Parse(attributesJson);
                    //musteri.Attributes = attributesArray.ToObject<List<Attribute>>();

                    string communicationsJson = reader["Communications"].ToString();
                    JArray communicationsArray = JArray.Parse(communicationsJson);
                    musteri.Communications = communicationsArray.ToObject<List<Communication>>();

                    musteriler.Add(musteri);
                }
            }

            return musteriler;
        }


        private async Task<List<ZtNebimFaturaR>> VeritabanindanMusteriGetirFaturaR( )
        {

            try
            {
                List<ZtNebimFaturaR> musteriler = new List<ZtNebimFaturaR>();
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    SqlCommand command = new SqlCommand("MSG_GetOrderForInvoiceToplu_RE", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        ZtNebimFaturaR musteri = new ZtNebimFaturaR();
                        musteri.ModelType = Convert.ToInt32(reader["ModelType"]);
                        musteri.CustomerCode = reader["CustomerCode"].ToString();
                        musteri.OfficeCode = reader["OfficeCode"].ToString();
                        musteri.StoreCode = reader["StoreCode"].ToString();
                        musteri.StoreWarehouseCode = reader["StoreWarehouseCode"].ToString();
                        musteri.DeliveryCompanyCode = reader["DeliveryCompanyCode"].ToString(); // Direk string olarak atandı
                        musteri.PosTerminalID = Convert.ToInt32(reader["PosTerminalID"]); // int'e çevirildi
                        musteri.ShipmentMethodCode = Convert.ToInt32(reader["ShipmentMethodCode"]); // int'e çevirildi
                        if (reader["OrderDate"] != DBNull.Value)
                        {
                            musteri.OrderDate = Convert.ToDateTime(reader["OrderDate"]); // DateTime'a çevirildi
                        }
                        musteri.IsSalesViaInternet = bool.Parse(reader["IsSalesViaInternet"].ToString());
                        musteri.DocumentNumber = reader["DocumentNumber"].ToString();
                        musteri.Description = reader["Description"].ToString();
                        musteri.InternalDescription = reader["InternalDescription"].ToString();

                        //   musteri.CustomerTypeCode = Convert.ToInt32(reader["CustomerTypeCode"]);

                        string LinesJson = reader["Lines"].ToString();
                        JArray LinesArray = JArray.Parse(LinesJson);
                        musteri.Lines = LinesArray.ToObject<List<InvoiceLines>>();

                        //string OrdersViaInternetInfosJson = reader["OrdersViaInternetInfo"].ToString();
                        //JToken parsedToken = JToken.Parse(OrdersViaInternetInfosJson);

                        //musteri.OrdersViaInternetInfo = new List<OrdersViaInternetInfo>();

                        //if (parsedToken is JArray) // Eğer dizi olarak başlıyorsa
                        //{
                        //    JArray OrdersViaInternetInfosArray = parsedToken as JArray;
                        //    foreach (var item in OrdersViaInternetInfosArray)
                        //    {
                        //        musteri.OrdersViaInternetInfo.Add(item.ToObject<OrdersViaInternetInfo>());
                        //    }
                        //}
                        //else if (parsedToken is JObject) // Eğer nesne olarak başlıyorsa
                        //{
                        //    OrdersViaInternetInfo singleObject = parsedToken.ToObject<OrdersViaInternetInfo>();
                        //    musteri.OrdersViaInternetInfo.Add(singleObject);
                        //}

                        string OrdersViaInternetInfosJson = reader["OrdersViaInternetInfo"].ToString();
                        JArray OrdersViaInternetInfoArray = JArray.Parse(OrdersViaInternetInfosJson);
                        musteri.OrdersViaInternetInfo = OrdersViaInternetInfoArray.ToObject<List<OrdersViaInternetInfo>>().First();


                        string PaymentsJson = reader["Payments"].ToString();
                        JArray PaymentsArray = JArray.Parse(PaymentsJson);
                        musteri.Payments = PaymentsArray.ToObject<List<Payments>>();

                        //string attributesJson = reader["Attributes"].ToString();
                        //JArray attributesArray = JArray.Parse(attributesJson);
                        //musteri.Attributes = attributesArray.ToObject<List<Attribute>>();


                        musteri.IsCompleted = bool.Parse(reader["IsCompleted"].ToString());
                        musteriler.Add(musteri);
                    }
                }

                return musteriler;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata Alındı");
                return null;
            }

        }

        private async void müşteriAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "İşlem başladı...";

            string sessionID = await ConnectIntegrator();

            List<ZTMSGTicUyeAdres> items = await VeritabanindanMusteriGetir();

            // İşlem sırasındaki mesaj
            labelStatus.Text = $"Veritabanından {items.Count} adet veri çekildi. Şimdi POST işlemi başlatılıyor...";

            int postCount = 0;
            foreach (var item in items)
            {
                string json = JsonConvert.SerializeObject(item);
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync($"http://{ipAdresi}/(S({sessionID}))/IntegratorService/post?", content);
                        var result = await response.Content.ReadAsStringAsync();
                        postCount++;
                        labelStatus.Text = $"POST işlemi {postCount}/{items.Count} veri için tamamlandı...";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    labelStatus.Text = $"Hata: {ex.Message}";
                }
            }

            // İşlem bitiş mesajı
            labelStatus.Text = "İşlem tamamlandı.";
        }
        public void OzellikEkle(Ozellik ozellik, int varyasyonID, Marka2 marka)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO ZTMSGTicOzellikler (Tanim, Deger, VaryasyonID,Marka) " +
                             "select @Tanim, @Deger, @VaryasyonID,@Marka where @VaryasyonID not in (select VaryasyonID from ZTMSGTicOzellikler where VaryasyonID = @VaryasyonID and Deger = @Deger and Marka =@Marka)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Tanim", ozellik.Tanim);
                    cmd.Parameters.AddWithValue("@Deger", ozellik.Deger);
                    cmd.Parameters.AddWithValue("@VaryasyonID", varyasyonID);
                    cmd.Parameters.AddWithValue("@Marka", marka.marka);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UrunEkle(Urun urun, Marka2 marka)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO ZTMSGTicUrunler (UrunKartiID, UrunAdi, OnYazi, Aciklama, MarkaID, KategoriID, SatisBirimi, UrunUrl,OzelAlan1,OzelAlan2,OzelAlan3,OzelAlan4,OzelAlan5, Marka) " +
                             "select @UrunKartiID, @UrunAdi, @OnYazi, @Aciklama, @MarkaID, @KategoriID, @SatisBirimi, @UrunUrl,@OzelAlan1,@OzelAlan2,@OzelAlan3,@OzelAlan4,@OzelAlan5, @Marka where @UrunKartiID not in (select UrunKartiID from ZTMSGTicUrunler where Marka = @Marka)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@UrunKartiID", urun.UrunKartiID);
                    cmd.Parameters.AddWithValue("@UrunAdi", urun.UrunAdi);
                    cmd.Parameters.AddWithValue("@OnYazi", urun.OnYazi);
                    cmd.Parameters.AddWithValue("@Aciklama", urun.Aciklama);
                    cmd.Parameters.AddWithValue("@MarkaID", urun.MarkaID);
                    cmd.Parameters.AddWithValue("@KategoriID", urun.KategoriID);
                    cmd.Parameters.AddWithValue("@SatisBirimi", urun.SatisBirimi);
                    cmd.Parameters.AddWithValue("@UrunUrl", urun.UrunUrl);
                    cmd.Parameters.AddWithValue("@OzelAlan1", (object)urun.OzelAlan1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OzelAlan2", (object)urun.OzelAlan2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OzelAlan3", (object)urun.OzelAlan3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OzelAlan4", (object)urun.OzelAlan4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OzelAlan5", (object)urun.OzelAlan5 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Marka", marka.marka);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SecenekEkle(Secenek secenek, int urunKartiID, Marka2 marka)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "delete ZTMSGTicSecenekler from ZTMSGTicSecenekler  where VaryasyonID = @VaryasyonID and Barkod = @Barkod " +
               "INSERT INTO ZTMSGTicSecenekler (VaryasyonID, StokKodu, Barkod, StokAdedi, AlisFiyati, SatisFiyati, IndirimliFiyat, KDVDahil, KdvOrani, ParaBirimi, Desi, UrunKartiID,Marka) " +
                             "select @VaryasyonID, @StokKodu, @Barkod, @StokAdedi, @AlisFiyati, @SatisFiyati, @IndirimliFiyat, @KDVDahil, @KdvOrani, @ParaBirimi, @Desi, @UrunKartiID, @Marka where @VaryasyonID not in (select VaryasyonID  from ZTMSGTicSecenekler where Marka =@Marka and VaryasyonID = @VaryasyonID)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@VaryasyonID", secenek.VaryasyonID);
                    cmd.Parameters.AddWithValue("@StokKodu", secenek.StokKodu);
                    cmd.Parameters.AddWithValue("@Barkod", secenek.Barkod);
                    cmd.Parameters.AddWithValue("@StokAdedi", secenek.StokAdedi);
                    cmd.Parameters.AddWithValue("@AlisFiyati", secenek.AlisFiyati);
                    cmd.Parameters.AddWithValue("@SatisFiyati", secenek.SatisFiyati);
                    cmd.Parameters.AddWithValue("@IndirimliFiyat", secenek.IndirimliFiyat);
                    cmd.Parameters.AddWithValue("@KDVDahil", secenek.KDVDahil);
                    cmd.Parameters.AddWithValue("@KdvOrani", secenek.KdvOrani);
                    cmd.Parameters.AddWithValue("@ParaBirimi", secenek.ParaBirimi);
                    cmd.Parameters.AddWithValue("@Desi", secenek.Desi);
                    cmd.Parameters.AddWithValue("@UrunKartiID", urunKartiID);
                    cmd.Parameters.AddWithValue("@Marka", marka.marka);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void KategoriEkle(Kategori2 kategori, Marka2 marka)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO ZTMSGTicKategoriler (KategoriID, ParentID, Tanim,Marka) " +
                             "select @KategoriID, @ParentID, @Tanim,@Marka where @KategoriID not in (select KategoriID from ZTMSGTicKategoriler where KategoriID = @KategoriID and Marka = @Marka)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@KategoriID", kategori.KategoriID);
                    cmd.Parameters.AddWithValue("@ParentID", kategori.ParentID);
                    cmd.Parameters.AddWithValue("@Tanim", kategori.Tanim);
                    cmd.Parameters.AddWithValue("@Marka", marka.marka);

                    cmd.ExecuteNonQuery();
                }
            }
        }



        public void BulkInsertOzellikler(List<Ozellik> ozellikler, int varyasyonID, Marka2 marka)
        {
            string connectionString = $"Server={Properties.Settings.Default.SunucuAdi};Database={Properties.Settings.Default.database};User Id={Properties.Settings.Default.KullaniciAdi};Password={Properties.Settings.Default.Sifre};";

            // DataTable oluşturun
            DataTable dt = new DataTable();
            dt.Columns.Add("Tanim");
            dt.Columns.Add("Deger");
            dt.Columns.Add("VaryasyonID", typeof(int));
            dt.Columns.Add("Marka");

            // Ozellik listesindeki her bir öğeyi DataTable'a ekle
            foreach (var ozellik in ozellikler)
            {
                DataRow row = dt.NewRow();
                row["Tanim"] = ozellik.Tanim;
                row["Deger"] = ozellik.Deger;
                row["VaryasyonID"] = varyasyonID;
                row["Marka"] = marka.marka;
                dt.Rows.Add(row);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    // Hedef tablonuzu belirtin
                    bulkCopy.DestinationTableName = "dbo.ZTMSGTicOzellikler";

                    // Eğer hedef tablonuzdaki kolon adları ve DataTable'daki kolon adları farklı ise, kolon eşlemelerini belirtin
                    bulkCopy.ColumnMappings.Add("Tanim", "Tanim");
                    bulkCopy.ColumnMappings.Add("Deger", "Deger");
                    bulkCopy.ColumnMappings.Add("VaryasyonID", "VaryasyonID");
                    bulkCopy.ColumnMappings.Add("Marka", "Marka");

                    // DataTable'ı veritabanına kopyalayın
                    bulkCopy.WriteToServer(dt);
                }
            }
        }
        public void FillAndBulkCopy(List<Urun> urunler, Marka2 marka)
        {
            DataTable urunTable = new DataTable();

            urunTable.Columns.Add("UrunKartiID", typeof(int));
            urunTable.Columns.Add("UrunAdi", typeof(string));
            urunTable.Columns.Add("OnYazi", typeof(string));
            urunTable.Columns.Add("Aciklama", typeof(string));
            urunTable.Columns.Add("MarkaID", typeof(int));
            urunTable.Columns.Add("KategoriID", typeof(int));
            urunTable.Columns.Add("SatisBirimi", typeof(string));
            urunTable.Columns.Add("UrunUrl", typeof(string));
            urunTable.Columns.Add("OzelAlan1", typeof(string));
            urunTable.Columns.Add("OzelAlan2", typeof(string));
            urunTable.Columns.Add("OzelAlan3", typeof(string));
            urunTable.Columns.Add("OzelAlan4", typeof(string));
            urunTable.Columns.Add("OzelAlan5", typeof(string));
            urunTable.Columns.Add("Marka", typeof(string)); // Varsayılan olarak string tipi varsayılmıştır.

            foreach (var urun in urunler)
            {
                DataRow row = urunTable.NewRow();
                row["UrunKartiID"] = urun.UrunKartiID;
                row["UrunAdi"] = urun.UrunAdi; // Null kontrolü
                row["OnYazi"] = urun.OnYazi;
                row["Aciklama"] = urun.Aciklama;
                row["MarkaID"] = urun.MarkaID;
                row["KategoriID"] = urun.KategoriID;
                row["SatisBirimi"] = urun.SatisBirimi;
                row["UrunUrl"] = urun.UrunUrl;
                row["OzelAlan1"] = (object)urun.OzelAlan1 ?? DBNull.Value;
                row["OzelAlan2"] = (object)urun.OzelAlan2 ?? DBNull.Value;
                row["OzelAlan3"] = (object)urun.OzelAlan3 ?? DBNull.Value;
                row["OzelAlan4"] = (object)urun.OzelAlan4 ?? DBNull.Value;
                row["OzelAlan5"] = (object)urun.OzelAlan5 ?? DBNull.Value;

                row["Marka"] = marka.marka; // marka değerini nereden alacağınıza bağlı

                urunTable.Rows.Add(row);
            }
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            // SqlConnection oluştur
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "dbo.ZTMSGTicUrunler";

                    try
                    {
                        bulkCopy.WriteToServer(urunTable);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        public void BulkInsertSecenekler(List<Secenek> secenekler, int urunKartiID, Marka2 marka)
        {
            string connectionString = $"Server={Properties.Settings.Default.SunucuAdi};Database={Properties.Settings.Default.database};User Id={Properties.Settings.Default.KullaniciAdi};Password={Properties.Settings.Default.Sifre};";

            DataTable dt = new DataTable();
            dt.Columns.Add("VaryasyonID", typeof(int));
            dt.Columns.Add("StokKodu");
            dt.Columns.Add("Barkod");
            dt.Columns.Add("StokAdedi", typeof(int));
            dt.Columns.Add("AlisFiyati", typeof(double));
            dt.Columns.Add("SatisFiyati", typeof(double));
            dt.Columns.Add("IndirimliFiyat", typeof(double));
            dt.Columns.Add("KDVDahil", typeof(bool));
            dt.Columns.Add("KdvOrani", typeof(int));
            dt.Columns.Add("ParaBirimi");
            dt.Columns.Add("Desi", typeof(int));
            dt.Columns.Add("UrunKartiID", typeof(int));
            dt.Columns.Add("Marka");

            foreach (var secenek in secenekler)
            {
                DataRow row = dt.NewRow();
                row["VaryasyonID"] = secenek.VaryasyonID;
                row["StokKodu"] = secenek.StokKodu;
                row["Barkod"] = secenek.Barkod;
                row["StokAdedi"] = secenek.StokAdedi;
                row["AlisFiyati"] = secenek.AlisFiyati;
                row["SatisFiyati"] = secenek.SatisFiyati;
                row["IndirimliFiyat"] = secenek.IndirimliFiyat;
                row["KDVDahil"] = secenek.KDVDahil;
                row["KdvOrani"] = secenek.KdvOrani;
                row["ParaBirimi"] = secenek.ParaBirimi;
                row["Desi"] = secenek.Desi;
                row["UrunKartiID"] = urunKartiID;
                row["Marka"] = marka.marka;
                dt.Rows.Add(row);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "dbo.ZTMSGTicSecenekler";

                    bulkCopy.ColumnMappings.Add("VaryasyonID", "VaryasyonID");
                    bulkCopy.ColumnMappings.Add("StokKodu", "StokKodu");
                    bulkCopy.ColumnMappings.Add("Barkod", "Barkod");
                    bulkCopy.ColumnMappings.Add("StokAdedi", "StokAdedi");
                    bulkCopy.ColumnMappings.Add("AlisFiyati", "AlisFiyati");
                    bulkCopy.ColumnMappings.Add("SatisFiyati", "SatisFiyati");
                    bulkCopy.ColumnMappings.Add("IndirimliFiyat", "IndirimliFiyat");
                    bulkCopy.ColumnMappings.Add("KDVDahil", "KDVDahil");
                    bulkCopy.ColumnMappings.Add("KdvOrani", "KdvOrani");
                    bulkCopy.ColumnMappings.Add("ParaBirimi", "ParaBirimi");
                    bulkCopy.ColumnMappings.Add("Desi", "Desi");
                    bulkCopy.ColumnMappings.Add("UrunKartiID", "UrunKartiID");
                    bulkCopy.ColumnMappings.Add("Marka", "Marka");

                    bulkCopy.WriteToServer(dt);
                }
            }
        }

        public List<Marka2> GetMarkalarFromStoredProcedure( )
        {
            List<Marka2> markalar = new List<Marka2>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("MSG_TicimaxUrun", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Marka2 marka = new Marka2();
                            marka.marka = reader["Marka"].ToString();

                            markalar.Add(marka);
                        }
                    }
                }
            }

            return markalar;
        }


        public List<Marka2> GetMarkalarFromStoredProcedureKAT( )
        {
            List<Marka2> markalar = new List<Marka2>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("MSG_TicimaxKategori", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Marka2 marka = new Marka2();
                            marka.marka = reader["Marka"].ToString();

                            markalar.Add(marka);
                        }
                    }
                }
            }

            return markalar;
        }
        public void ProcessXmlItemUrl(string url, Marka2 marka)
        {
            try
            {
                List<Marka2> markalar = GetMarkalarFromStoredProcedure();
                using (WebClient client = new WebClient())
                {
                    // XML dosyasını indir
                    string xmlData = client.DownloadString(url);

                    // XML dosyasını parse et
                    XDocument doc = XDocument.Parse(xmlData);

                    // Ürünleri çek
                    var urunler = doc.Root.Element("Urunler").Elements("Urun").Select(x => new Urun
                    {
                        UrunKartiID = (int)x.Element("UrunKartiID"),
                        UrunAdi = (string)x.Element("UrunAdi"),
                        OnYazi = (string)x.Element("OnYazi"),
                        Aciklama = (string)x.Element("Aciklama"),
                        MarkaID = (int)x.Element("MarkaID"),
                        KategoriID = (int)x.Element("KategoriID"),
                        SatisBirimi = (string)x.Element("SatisBirimi"),
                        UrunUrl = (string)x.Element("UrunUrl"),
                        OzelAlan1 = (string)x.Element("OzelAlan1"),
                        OzelAlan2 = (string)x.Element("OzelAlan2"),
                        OzelAlan3 = (string)x.Element("OzelAlan3"),
                        OzelAlan4 = (string)x.Element("OzelAlan4"),
                        OzelAlan5 = (string)x.Element("OzelAlan5"),
                        UrunSecenek = x.Element("UrunSecenek").Elements("Secenek").Select(s => new Secenek
                        {
                            VaryasyonID = (int)s.Element("VaryasyonID"),
                            StokKodu = (string)s.Element("StokKodu"),
                            Barkod = (string)s.Element("Barkod"),
                            StokAdedi = (int)s.Element("StokAdedi"),
                            AlisFiyati = (double)s.Element("AlisFiyati"),
                            SatisFiyati = (double)s.Element("SatisFiyati"),
                            IndirimliFiyat = (double)s.Element("IndirimliFiyat"),
                            KDVDahil = (bool)s.Element("KDVDahil"),
                            KdvOrani = (int)s.Element("KdvOrani"),
                            ParaBirimi = (string)s.Element("ParaBirimi"),
                            Desi = (int)s.Element("Desi"),
                            EkSecenekOzellik = s.Element("EkSecenekOzellik").Elements("Ozellik").Select(o => new Ozellik
                            {
                                Tanim = (string)o.Attribute("Tanim"),
                                Deger = (string)o.Attribute("Deger")
                            }).ToList()
                        }).ToList()
                    }).ToList();
                    try
                    {
                        foreach (var urun in urunler)
                        {
                            UrunEkle(urun, marka);

                            foreach (var secenek in urun.UrunSecenek)
                            {
                                SecenekEkle(secenek, urun.UrunKartiID, marka);

                                foreach (var ozellik in secenek.EkSecenekOzellik)
                                {
                                    OzellikEkle(ozellik, secenek.VaryasyonID, marka);
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Hata alındı");

                    }

                }
            }
            catch (Exception ex)
            {


                Console.WriteLine("Hata alındı" + ex.Message);
            }

        }





        public void ProcessXmlItemUrl2(string url, Marka2 marka)
        {
            try
            {
                List<Marka2> markalar = GetMarkalarFromStoredProcedure();
                using (WebClient client = new WebClient())
                {
                    // XML dosyasını indir
                    string xmlData = client.DownloadString(url);

                    // XML dosyasını parse et
                    XDocument doc = XDocument.Parse(xmlData);

                    // Ürünleri çek
                    var urunler = doc.Root.Element("Urunler").Elements("Urun").Select(x => new Urun
                    {
                        UrunKartiID = (int)x.Element("UrunKartiID"),
                        UrunAdi = (string)x.Element("UrunAdi"),
                        OnYazi = (string)x.Element("OnYazi"),
                        Aciklama = (string)x.Element("Aciklama"),
                        MarkaID = (int)x.Element("MarkaID"),
                        KategoriID = (int)x.Element("KategoriID"),
                        SatisBirimi = (string)x.Element("SatisBirimi"),
                        UrunUrl = (string)x.Element("UrunUrl"),
                        OzelAlan1 = (string)x.Element("OzelAlan1"),
                        OzelAlan2 = (string)x.Element("OzelAlan2"),
                        OzelAlan3 = (string)x.Element("OzelAlan3"),
                        OzelAlan4 = (string)x.Element("OzelAlan4"),
                        OzelAlan5 = (string)x.Element("OzelAlan5"),
                        UrunSecenek = x.Element("UrunSecenek").Elements("Secenek").Select(s => new Secenek
                        {
                            VaryasyonID = (int)s.Element("VaryasyonID"),
                            StokKodu = (string)s.Element("StokKodu"),
                            Barkod = (string)s.Element("Barkod"),
                            StokAdedi = (int)s.Element("StokAdedi"),
                            AlisFiyati = (double)s.Element("AlisFiyati"),
                            SatisFiyati = (double)s.Element("SatisFiyati"),
                            IndirimliFiyat = (double)s.Element("IndirimliFiyat"),
                            KDVDahil = (bool)s.Element("KDVDahil"),
                            KdvOrani = (int)s.Element("KdvOrani"),
                            ParaBirimi = (string)s.Element("ParaBirimi"),
                            Desi = (int)s.Element("Desi"),
                            EkSecenekOzellik = s.Element("EkSecenekOzellik").Elements("Ozellik").Select(o => new Ozellik
                            {
                                Tanim = (string)o.Attribute("Tanim"),
                                Deger = (string)o.Attribute("Deger")
                            }).ToList()
                        }).ToList()
                    }).ToList();

                    foreach (var urun in urunler)
                    {

                        foreach (var secenek in urun.UrunSecenek)
                        {
                            SecenekEkle(secenek, urun.UrunKartiID, marka);


                        }
                    }
                }
            }
            catch (Exception ex)
            {


                Console.WriteLine("Hata alındı" + ex.Message);
            }

        }
        public void ProcessXmlItemUrls( )
        {
            try
            {
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Stored Procedure'u çağıran komut
                    using (SqlCommand cmd = new SqlCommand("MSG_TicimaxUrun", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string markaAdi = reader["Marka"].ToString();
                                string url = reader["Url"].ToString();

                                Marka2 marka = new Marka2 { marka = markaAdi };

                                // URL'ye göre işlem yap
                                ProcessXmlItemUrl(url, marka);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {


                Console.WriteLine("Hata alındı" + ex.Message);
            }

        }
        public void ProcessXmlItemUrls2( )
        {
            try
            {
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Stored Procedure'u çağıran komut
                    using (SqlCommand cmd = new SqlCommand("MSG_TicimaxUrun", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string markaAdi = reader["Marka"].ToString();
                                string url = reader["Url"].ToString();

                                Marka2 marka = new Marka2 { marka = markaAdi };

                                // URL'ye göre işlem yap
                                ProcessXmlItemUrl2(url, marka);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {


                Console.WriteLine("Hata alındı" + ex.Message);
            }

        }
        public void ProcessXmlUrls( )
        {
            try
            {
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Stored Procedure'u çağıran komut
                    using (SqlCommand cmd = new SqlCommand("MSG_TicimaxResim", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string url = reader["Url"].ToString();
                                string markaAdi = reader["Marka"].ToString();

                                Marka2 marka = new Marka2 { marka = markaAdi };

                                // URL'ye ve marka bilgisine göre işlem yap
                                ProcessXmlUrl(url, marka.marka);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {


                Console.WriteLine("Hata alındı" + ex.Message);
            }

        }
        public void ProcessXmlUrl(string url, string marka)
        {
            // Marka bilgisini Marka sınıfına dönüştür
            Marka2 markaObjesi = new Marka2 { marka = marka };

            ResimleriKaydet(url, markaObjesi);


        }
        private void ResimleriKaydet(string url, Marka2 marka)
        {
            try
            {
                WebClient client = new WebClient();
                string xmlContent = client.DownloadString(url);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlContent);

                XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Resimler/Resim");

                foreach (XmlNode node in nodes)
                {
                    string urunKartiID = node.SelectSingleNode("UrunKartiID").InnerText;
                    string varyasyonID = node.SelectSingleNode("VaryasyonID").InnerText;
                    string resimAdresi = node.SelectSingleNode("ResimAdresi").InnerText;

                    Resim resim = new Resim
                    {
                        UrunKartiID = int.Parse(urunKartiID),
                        VaryasyonID = int.Parse(varyasyonID),
                        ResimAdresi = resimAdresi,
                    };

                    ResimDurumuKaydet(resim, "Başarısız", marka);
                }
            }
            catch (Exception ex)
            {


                Console.WriteLine("Hata alındı" + ex.Message);
            }

        }
        public void ResimDurumuKaydet(Resim resim, string indirmeDurumu, Marka2 marka)
        {
            try
            {
                string query = "INSERT INTO ZTMSGTicResimler (UrunKartiID, VaryasyonID, ResimAdresi, IndirmeDurumu,Marka) " +
                          "select @UrunKartiID, @VaryasyonID, @ResimAdresi, @IndirmeDurumu, @Marka where @ResimAdresi not in (Select ResimAdresi from ZTMSGTicResimler where Marka =@Marka) ";
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UrunKartiID", resim.UrunKartiID);
                        command.Parameters.AddWithValue("@VaryasyonID", resim.VaryasyonID);
                        command.Parameters.AddWithValue("@ResimAdresi", resim.ResimAdresi);
                        command.Parameters.AddWithValue("@IndirmeDurumu", indirmeDurumu);
                        command.Parameters.AddWithValue("@Marka", marka.marka);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {


                Console.WriteLine("Hata alındı" + ex.Message);
            }

        }
        private void ResimDurumuUpdate(Resim resim, string indirmeDurumu, Marka2 marka)
        {
            try
            {
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE ZTMSGTicResimler SET IndirmeDurumu = @IndirmeDurumu WHERE UrunKartiID = @UrunKartiID AND VaryasyonID = @VaryasyonID and ResimAdresi =@ResimAdresi and Marka = @Marka";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IndirmeDurumu", indirmeDurumu);
                    command.Parameters.AddWithValue("@UrunKartiID", resim.UrunKartiID);
                    command.Parameters.AddWithValue("@VaryasyonID", resim.VaryasyonID);
                    command.Parameters.AddWithValue("@ResimAdresi", resim.ResimAdresi);
                    command.Parameters.AddWithValue("@Marka", marka.marka);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {


                Console.WriteLine("Hata alındı" + ex.Message);
            }

        }
        public void ProcessXmlKategoriUrls( )
        {
            try
            {
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Stored Procedure'u çağıran komut
                    using (SqlCommand cmd = new SqlCommand("MSG_TicimaxKategori", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string markaAdi = reader["Marka"].ToString();
                                string url = reader["Url"].ToString();

                                Marka2 marka = new Marka2 { marka = markaAdi };

                                // URL'ye göre işlem yap
                                ProcessXmlKategoriUrl(url, marka);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {


                Console.WriteLine("Hata alındı" + ex.Message);
            }

        }
        public void ProcessXmlKategoriUrl(string url, Marka2 marka)
        {

            try
            {
                List<Marka2> markalar = GetMarkalarFromStoredProcedureKAT();
                using (WebClient client = new WebClient())
                {
                    // XML dosyasını indir
                    string xmlData = client.DownloadString(url);

                    // XML dosyasını parse et
                    XDocument doc = XDocument.Parse(xmlData);

                    // Root kontrolü
                    var root = doc.Root;
                    if (root == null)
                    {
                        throw new Exception("Root is null");
                    }

                    // Kategori elementleri kontrolü
                    var kategoriElements = root.Elements("Kategori");
                    if (kategoriElements == null || !kategoriElements.Any())
                    {
                        throw new Exception("Kategori elements are null or empty");
                    }

                    var kategoriler = kategoriElements.Select(x =>
                    {
                        // KategoriID kontrolü
                        var kategoriIDElement = x.Element("KategoriID");
                        if (kategoriIDElement == null)
                        {
                            throw new Exception("KategoriID element is null");
                        }

                        // ParentID kontrolü
                        var parentIDElement = x.Element("ParentID");
                        if (parentIDElement == null)
                        {
                            throw new Exception("ParentID element is null");
                        }

                        // Tanim kontrolü
                        var tanimElement = x.Element("Tanim");
                        if (tanimElement == null)
                        {
                            throw new Exception("Tanim element is null");
                        }

                        return new Kategori2
                        {
                            KategoriID = (int)kategoriIDElement,
                            ParentID = (int)parentIDElement,
                            Tanim = (string)tanimElement
                        };
                    }).ToList();

                    foreach (var kategori in kategoriler)
                    {
                        KategoriEkle(kategori, marka);


                    }
                }
            }
            catch (Exception ex)
            {


                Console.WriteLine("Hata alındı" + ex.Message);
            }

        }

        private void ürünleriÇekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessXmlItemUrls();
            ProcessXmlUrls();
            ProcessXmlKategoriUrls();

        }
        private async Task DownloadImagesAsync( )
        {
            try
            {
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                string spName = "MSG_TrendyolResimIndirListe";

                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }

                int count = 1;
                string lastBarcode = string.Empty;

                using (HttpClient client = new HttpClient())
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        try
                        {
                            string barcode = row["Barcode"].ToString();
                            string url = row["Url"].ToString();
                            string folderName = row["Marka"].ToString();
                            string folderPath = Path.Combine("C:\\Resimler", folderName);

                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            // Check if this is a new barcode or a repeat
                            if (barcode != lastBarcode)
                            {
                                // This is a new barcode, so reset the count
                                count = 1;
                                lastBarcode = barcode;
                            }

                            string filename = count > 1 ? $"{barcode}_{count}.jpg" : $"{barcode}.jpg";
                            string path = Path.Combine(folderPath, filename);

                            byte[] imageBytes = await client.GetByteArrayAsync(url);

                            using (FileStream sourceStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
                            {
                                await sourceStream.WriteAsync(imageBytes, 0, imageBytes.Length);
                            }

                            // Increment the count for the next loop
                            count++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            // Hata mesajını görmezden gel, sadece kaydet ve işlemi devam ettir
                            // Bu şekilde hata alan verileri atlatabilirsiniz.
                            // Burada hata işlenmiyor ve işlem devam ediyor.
                        }
                    }
                }

                MessageBox.Show("Resim İndirme Tamamlandı!");
            }
            catch (Exception ex)
            {
                // Top seviyedeki hata işleme, uygulamanın çökmemesini sağlar.
                MessageBox.Show("Uygulama genelinde bir hata oluştu: " + ex.Message);
            }
        }

        private async void resimleriAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await DownloadImagesAsync();
        }
        private async Task SendRequest( )

        {
            try
            {
                var sellerId = Properties.Settings.Default.TxtSatici;
                List<TrendyolContentModel> products = await _trendyolService.GetProductsAsync(sellerId);
                var count = 1;
                foreach (var product in products)
                {
                    progressBar1.Value = (count * 100) / products.Count;
                    await _databaseService.SaveProduct(product);
                    var attributes = product.Attributes;
                    foreach (var attribute in attributes)
                    {
                        try
                        {
                            await _databaseService.SaveProductAttribute(product.Barcode, attribute);
                        }
                        catch (Exception ex)
                        {
                            // Burada hatayı loglamak veya kullanıcıya bildirmek gibi işlemler yapabilirsiniz.
                            Console.WriteLine($"An error occurred while saving product attribute. Barcode: {product.Barcode}, Attribute: {attribute}. Error: {ex.Message}");
                        }
                    }


                    List<ProductImage> Images = product.Images;
                    foreach (var image in Images)
                    {
                        await _databaseService.SaveProductImage(product.Barcode, image.Url);

                    }

                    List<ProductImage> Images2 = product.Images;
                    foreach (var image in Images2)
                    {
                        await _databaseService.SaveProductImage2(product.Barcode, image.Url);

                    }
                    // await _databaseService.SaveProductImage(barcode, Url);
                    count++;
                }
                MessageBox.Show("İşlem Tamamlandı.");
            }
            catch (Exception ex)
            {


                Console.WriteLine("Hata alındı" + ex.Message);
            }

        }
        private async void trendyolResimleriÇekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await SendRequest();
        }

        private async Task<List<Item>> VeritabanindanItemGetir( )
        {
            List<Item> items = new List<Item>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("MSG_TicimaxUrunListesi", conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Item item = new Item();

                    item.ModelType = reader["ModelType"].ToString();
                    item.ItemTypeCode = reader["ItemTypeCode"].ToString();
                    item.ItemCode = reader["ItemCode"].ToString();
                    item.ItemDescription = reader["ItemDescription"].ToString();
                    item.ItemDimTypeCode = Convert.ToInt32(reader["ItemDimTypeCode"]);
                    item.ItemTaxGrCode = reader["ItemTaxGrCode"].ToString();
                    item.ProductHierarchyID = Convert.ToInt32(reader["ProductHierarchyID"]);
                    item.UsePOS = Convert.ToBoolean(reader["UsePOS"]);
                    item.UseStore = Convert.ToBoolean(reader["UseStore"]);
                    item.UseInternet = Convert.ToBoolean(reader["UseInternet"]);
                    item.UnitOfMeasureCode1 = reader["UnitOfMeasureCode1"].ToString();
                    item.UseBatch = Convert.ToBoolean(reader["UseBatch"]);
                    item.UseManufacturing = Convert.ToBoolean(reader["UseManufacturing"]);
                    item.UseRoll = Convert.ToBoolean(reader["UseRoll"]);
                    item.UseSerialNumber = Convert.ToBoolean(reader["UseSerialNumber"]);

                    string variantJson = reader["Variant"].ToString();
                    JArray variantArray = JArray.Parse(variantJson);
                    item.Variants = variantArray.ToObject<List<Variant>>();


                    string LotsJson = reader["ProductLots"].ToString();
                    JArray LotsArray = JArray.Parse(LotsJson);
                    item.ProductLots = LotsArray.ToObject<List<ProductLots>>();

                    string BasePricesJson = reader["BasePrices"].ToString();
                    JArray BasePricesArray = JArray.Parse(BasePricesJson);
                    item.BasePrices = BasePricesArray.ToObject<List<BasePrice>>();

                    string BarcodesJson = reader["Barcodes"].ToString();
                    JArray BarcodesArray = JArray.Parse(BarcodesJson);
                    item.Barcodes = BarcodesArray.ToObject<List<Barcodes>>();

                    string DescriptionsJson = reader["Descriptions"].ToString();
                    JArray DescriptionsArray = JArray.Parse(DescriptionsJson);
                    item.Descriptions = DescriptionsArray.ToObject<List<Descriptions>>();


                    string ItemNotesJson = reader["ItemNotes"].ToString();
                    JArray ItemNotesArray = JArray.Parse(ItemNotesJson);
                    item.ItemNotes = ItemNotesArray.ToObject<List<ItemNote>>();

                    // Diğer alanları doldurmak için benzer işlemler...

                    items.Add(item);
                }
            }




            return items;
        }



        private async Task<List<Item3>> VeritabanindanItemGetirMisigo( )
        {
            List<Item3> items = new List<Item3>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("MSG_MisigoUrunListesi", conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Item3 item = new Item3();

                    item.ModelType = reader["ModelType"].ToString();
                    item.ItemTypeCode = reader["ItemTypeCode"].ToString();
                    item.ItemCode = reader["ItemCode"].ToString();
                    item.ItemDescription = reader["ItemDescription"].ToString();
                    item.ItemDimTypeCode = Convert.ToInt32(reader["ItemDimTypeCode"]);
                    item.ItemTaxGrCode = reader["ItemTaxGrCode"].ToString();
                    item.ProductHierarchyID = Convert.ToInt32(reader["ProductHierarchyID"]);
                    item.UsePOS = Convert.ToBoolean(reader["UsePOS"]);
                    item.UseStore = Convert.ToBoolean(reader["UseStore"]);
                    item.UseInternet = Convert.ToBoolean(reader["UseInternet"]);
                    item.UnitOfMeasureCode1 = reader["UnitOfMeasureCode1"].ToString();
                    item.UseBatch = Convert.ToBoolean(reader["UseBatch"]);
                    item.UseManufacturing = Convert.ToBoolean(reader["UseManufacturing"]);
                    item.UseRoll = Convert.ToBoolean(reader["UseRoll"]);
                    item.UseSerialNumber = Convert.ToBoolean(reader["UseSerialNumber"]);

                    string variantJson = reader["Variant"].ToString();
                    JArray variantArray = JArray.Parse(variantJson);
                    item.Variants = variantArray.ToObject<List<Variant>>();


                    //string LotsJson = reader["ProductLots"].ToString();
                    //JArray LotsArray = JArray.Parse(LotsJson);
                    //item.ProductLots = LotsArray.ToObject<List<ProductLots>>();

                    string BasePricesJson = reader["BasePrices"].ToString();
                    JArray BasePricesArray = JArray.Parse(BasePricesJson);
                    item.BasePrices = BasePricesArray.ToObject<List<BasePrice>>();

                    string BarcodesJson = reader["Barcodes"].ToString();
                    JArray BarcodesArray = JArray.Parse(BarcodesJson);
                    item.Barcodes = BarcodesArray.ToObject<List<Barcodes>>();

                    //string DescriptionsJson = reader["Descriptions"].ToString();
                    //JArray DescriptionsArray = JArray.Parse(DescriptionsJson);
                    //item.Descriptions = DescriptionsArray.ToObject<List<Descriptions>>();


                    //string ItemNotesJson = reader["ItemNotes"].ToString();
                    //JArray ItemNotesArray = JArray.Parse(ItemNotesJson);
                    //item.ItemNotes = ItemNotesArray.ToObject<List<ItemNote>>();

                    // Diğer alanları doldurmak için benzer işlemler...

                    items.Add(item);
                }
            }




            return items;
        }


        private async Task<List<Stok>> VeritabanindaStokEkle( )
        {
            List<Stok> stoks = new List<Stok>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("MSG_TicimaxStokEkle", conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Stok stok = new Stok();

                    stok.ModelType = reader["ModelType"].ToString();
                    stok.OfficeCode = reader["OfficeCode"].ToString();
                    stok.StoreCode = reader["StoreCode"].ToString();
                    stok.WarehouseCode = reader["WarehouseCode"].ToString();
                    stok.CompanyCode = Convert.ToInt32(reader["CompanyCode"]);
                    stok.InnerProcessType = Convert.ToInt32(reader["InnerProcessType"]);


                    string LinesJson = reader["Lines"].ToString();
                    JArray variantArray = JArray.Parse(LinesJson);
                    stok.Lines = variantArray.ToObject<List<Lines>>();



                    // Diğer alanları doldurmak için benzer işlemler...

                    stoks.Add(stok);
                }
            }




            return stoks;
        }




        private async Task<List<Stok>> VeritabanindaStokCikar( )
        {
            List<Stok> stoks = new List<Stok>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("MSG_TicimaxStokCikar", conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Stok stok = new Stok();

                    stok.ModelType = reader["ModelType"].ToString();
                    stok.OfficeCode = reader["OfficeCode"].ToString();
                    stok.StoreCode = reader["StoreCode"].ToString();
                    stok.WarehouseCode = reader["WarehouseCode"].ToString();
                    stok.CompanyCode = Convert.ToInt32(reader["CompanyCode"]);
                    stok.InnerProcessType = Convert.ToInt32(reader["InnerProcessType"]);


                    string LinesJson = reader["Lines"].ToString();
                    JArray variantArray = JArray.Parse(LinesJson);
                    stok.Lines = variantArray.ToObject<List<Lines>>();



                    // Diğer alanları doldurmak için benzer işlemler...

                    stoks.Add(stok);
                }
            }




            return stoks;
        }





        private async void ürünleriAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;

            string kolonAdi = Properties.Settings.Default.txtlot; // Kolon adını alır.

            if (!string.IsNullOrWhiteSpace(kolonAdi))
            {
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Şimdi aldığınız veriyi cdLot tablosuna ekleyin.
                    string insertQuery = $"INSERT INTO cdLot (LotCode, ItemDimTypeCode, IsBlocked) " +
                                         $"SELECT {kolonAdi}, 2, 0 " +
                                         $"FROM ZTMSGTicUrunler " +
                                         $"WHERE {kolonAdi} != '' AND {kolonAdi} NOT IN (SELECT LotCode FROM cdLot) " +
                                         $"GROUP BY {kolonAdi}";

                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        int rowsAffected = insertCommand.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} rows inserted.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir kolon adı giriniz!");
            }


            // İşlem başlangıç mesajı
            labelStatus.Text = "İşlem başladı...";

            string sessionID = await ConnectIntegrator();

            List<Item> items = await VeritabanindanItemGetir();

            // İşlem sırasındaki mesaj
            labelStatus.Text = $"Veritabanından {items.Count} adet veri çekildi. Şimdi POST işlemi başlatılıyor...";

            int postCount = 0;
            foreach (var item in items)
            {
                string json = JsonConvert.SerializeObject(item);
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync($"http://{ipAdresi}/(S({sessionID}))/IntegratorService/post?", content);
                        var result = await response.Content.ReadAsStringAsync();
                        postCount++;
                        labelStatus.Text = $"POST işlemi {postCount}/{items.Count} veri için tamamlandı...";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    labelStatus.Text = $"Hata: {ex.Message}";
                }
            }

            // İşlem bitiş mesajı
            labelStatus.Text = "İşlem tamamlandı.";
        }

        private void kategoriEşleştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NebimKategori frm = new NebimKategori();
            frm.Show();
        }

        private void nebimSayimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NebimSayim frm = new NebimSayim();
            frm.Show();
        }


        private void ürünAdlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string apiKey = "AIzaSyAL2M8T6ZaxNV3SuMY49sc1RyuJBkiL92M";
            string[] targetLanguages = { "EN", "RU", "AR", "FR", "DE" }; // Hedef dillerinizi burada listeleyin

            TranslationClient client = TranslationClient.CreateFromApiKey(apiKey);

            try
            {
                // SQL'den verileri al
                DataTable dt = VerileriGetir(); // Bu işlevi oluşturmanız gerekecektir.

                foreach (DataRow row in dt.Rows)
                {
                    string itemcode = row["Itemcode"].ToString();
                    string itemdescription = row["Itemdescription"].ToString();

                    // Her hedef dil için çeviri yap
                    foreach (string targetLanguage in targetLanguages)
                    {
                        CeviriYapVeKaydet(itemcode, targetLanguage, itemdescription, client);
                    }
                }

                MessageBox.Show("Çeviriler tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Google.GoogleApiException ex)
            {
                MessageBox.Show($"Çeviri işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable VerileriGetir( )
        {
            // SQL sorgusu ile verilerinizi çekmek için kullanabileceğiniz bir işlevi burada uygulayın.
            // Veritabanı bağlantısı kurun ve gerekli sorguyu çalıştırın.
            // Alınan verileri bir DataTable içinde döndürün.

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Veri çekme SP'sini çağırma
                using (SqlCommand cmd = new SqlCommand("MSG_UrunListe", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private void CeviriYapVeKaydet(string itemcode, string langcode, string itemdescription, TranslationClient client)
        {
            // Verilen parametreleri kullanarak çeviriyi yapın ve sonucu SQL'e kaydedin.
            // MSG_DilCeviri SP'sini çağırmak için SQL bağlantısı oluşturun ve gerekli parametreleri kullanarak çağırın.

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("MSG_DilCeviri", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Itemcode", itemcode);
                    cmd.Parameters.AddWithValue("@Langcode", langcode);

                    TranslationResult result = client.TranslateText(itemdescription, langcode);
                    cmd.Parameters.AddWithValue("@Itemdescription", result.TranslatedText);

                    cmd.ExecuteNonQuery();
                }
            }
        }




        private DataTable VerileriGetirRenk( )
        {
            // SQL sorgusu ile verilerinizi çekmek için kullanabileceğiniz bir işlevi burada uygulayın.
            // Veritabanı bağlantısı kurun ve gerekli sorguyu çalıştırın.
            // Alınan verileri bir DataTable içinde döndürün.

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Veri çekme SP'sini çağırma
                using (SqlCommand cmd = new SqlCommand("MSG_RenkListe", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private void CeviriYapVeKaydetRenk(string itemcode, string langcode, string itemdescription, TranslationClient client)
        {
            // Verilen parametreleri kullanarak çeviriyi yapın ve sonucu SQL'e kaydedin.
            // MSG_DilCeviri SP'sini çağırmak için SQL bağlantısı oluşturun ve gerekli parametreleri kullanarak çağırın.

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("MSG_DilCeviriRenk", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Itemcode", itemcode);
                    cmd.Parameters.AddWithValue("@Langcode", langcode);

                    TranslationResult result = client.TranslateText(itemdescription, langcode);
                    cmd.Parameters.AddWithValue("@Itemdescription", result.TranslatedText);

                    cmd.ExecuteNonQuery();
                }
            }
        }



        private DataTable VerileriGetirOzellik( )
        {
            // SQL sorgusu ile verilerinizi çekmek için kullanabileceğiniz bir işlevi burada uygulayın.
            // Veritabanı bağlantısı kurun ve gerekli sorguyu çalıştırın.
            // Alınan verileri bir DataTable içinde döndürün.

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Veri çekme SP'sini çağırma
                using (SqlCommand cmd = new SqlCommand("MSG_OzellikListe", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private void CeviriYapVeKaydetOzellik(string attributeTypeCode, string attributeCode, string langcode, string attributeDescription, TranslationClient client)
        {
            // Verilen parametreleri kullanarak çeviriyi yapın ve sonucu SQL'e kaydedin.
            // MSG_DilCeviri SP'sini çağırmak için SQL bağlantısı oluşturun ve gerekli parametreleri kullanarak çağırın.

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("MSG_DilCeviriOzellik", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AttributeTypeCode", attributeTypeCode);
                    cmd.Parameters.AddWithValue("@attributeCode", attributeCode);
                    cmd.Parameters.AddWithValue("@Langcode", langcode);

                    TranslationResult result = client.TranslateText(attributeDescription, langcode);
                    cmd.Parameters.AddWithValue("@Itemdescription", result.TranslatedText);

                    cmd.ExecuteNonQuery();
                }
            }
        }




        private DataTable VerileriGetirOzellikTipi( )
        {
            // SQL sorgusu ile verilerinizi çekmek için kullanabileceğiniz bir işlevi burada uygulayın.
            // Veritabanı bağlantısı kurun ve gerekli sorguyu çalıştırın.
            // Alınan verileri bir DataTable içinde döndürün.

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Veri çekme SP'sini çağırma
                using (SqlCommand cmd = new SqlCommand("MSG_OzellikTipiListe", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private void CeviriYapVeKaydetOzellikTipi(string attributeTypeCode, string langcode, string attributeTypeDescription, TranslationClient client)
        {
            // Verilen parametreleri kullanarak çeviriyi yapın ve sonucu SQL'e kaydedin.
            // MSG_DilCeviri SP'sini çağırmak için SQL bağlantısı oluşturun ve gerekli parametreleri kullanarak çağırın.

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("MSG_DilCeviriOzellikTipi", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AttributeTypeCode", attributeTypeCode);

                    cmd.Parameters.AddWithValue("@Langcode", langcode);

                    TranslationResult result = client.TranslateText(attributeTypeDescription, langcode);
                    cmd.Parameters.AddWithValue("@attributeTypeDescription", result.TranslatedText);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void ürünÖzellikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string apiKey = "AIzaSyAL2M8T6ZaxNV3SuMY49sc1RyuJBkiL92M";
            string[] targetLanguages = { "EN", "RU", "AR", "FR", "DE" }; // Hedef dillerinizi burada listeleyin

            TranslationClient client = TranslationClient.CreateFromApiKey(apiKey);

            try
            {
                // SQL'den verileri al
                DataTable dt = VerileriGetirOzellik(); // Bu işlevi oluşturmanız gerekecektir.

                foreach (DataRow row in dt.Rows)
                {
                    string attributeTypeCode = row["AttributeTypeCode"].ToString();
                    string attributeCode = row["AttributeCode"].ToString();
                    string attributeDescription = row["AttributeDescription"].ToString();

                    // Her hedef dil için çeviri yap
                    foreach (string targetLanguage in targetLanguages)
                    {
                        CeviriYapVeKaydetOzellik(attributeTypeCode, attributeCode, targetLanguage, attributeDescription, client);
                    }
                }

                MessageBox.Show("Çeviriler tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Google.GoogleApiException ex)
            {
                MessageBox.Show($"Çeviri işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void renkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string apiKey = "AIzaSyAL2M8T6ZaxNV3SuMY49sc1RyuJBkiL92M";
            string[] targetLanguages = { "EN", "RU", "AR", "FR", "DE" }; // Hedef dillerinizi burada listeleyin

            TranslationClient client = TranslationClient.CreateFromApiKey(apiKey);

            try
            {
                // SQL'den verileri al
                DataTable dt = VerileriGetirRenk(); // Bu işlevi oluşturmanız gerekecektir.

                foreach (DataRow row in dt.Rows)
                {
                    string itemcode = row["ColorCode"].ToString();
                    string itemdescription = row["Colordescription"].ToString();

                    // Her hedef dil için çeviri yap
                    foreach (string targetLanguage in targetLanguages)
                    {
                        CeviriYapVeKaydetRenk(itemcode, targetLanguage, itemdescription, client);
                    }
                }

                MessageBox.Show("Çeviriler tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Google.GoogleApiException ex)
            {
                MessageBox.Show($"Çeviri işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ürünÖzellikTipleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string apiKey = "AIzaSyAL2M8T6ZaxNV3SuMY49sc1RyuJBkiL92M";
            string[] targetLanguages = { "EN", "RU", "AR", "FR", "DE" }; // Hedef dillerinizi burada listeleyin

            TranslationClient client = TranslationClient.CreateFromApiKey(apiKey);

            try
            {
                // SQL'den verileri al
                DataTable dt = VerileriGetirOzellikTipi(); // Bu işlevi oluşturmanız gerekecektir.

                foreach (DataRow row in dt.Rows)
                {
                    string attributeTypeCode = row["AttributeTypeCode"].ToString();
                    string attributeTypeDescription = row["AttributeTypeDescription"].ToString();

                    // Her hedef dil için çeviri yap
                    foreach (string targetLanguage in targetLanguages)
                    {
                        CeviriYapVeKaydetOzellikTipi(attributeTypeCode, targetLanguage, attributeTypeDescription, client);
                    }
                }

                MessageBox.Show("Çeviriler tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Google.GoogleApiException ex)
            {
                MessageBox.Show($"Çeviri işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void stokEşitleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;




            // İşlem başlangıç mesajı
            labelStatus.Text = "İşlem başladı...";

            string sessionID = await ConnectIntegrator();

            List<Stok> items = await VeritabanindaStokEkle();

            // İşlem sırasındaki mesaj
            labelStatus.Text = $"Veritabanından {items.Count} adet veri çekildi. Şimdi POST işlemi başlatılıyor...";

            int postCount = 0;
            foreach (var item in items)
            {
                string json = JsonConvert.SerializeObject(item);
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync($"http://{ipAdresi}/(S({sessionID}))/IntegratorService/post?", content);
                        var result = await response.Content.ReadAsStringAsync();
                        postCount++;
                        labelStatus.Text = $"POST işlemi {postCount}/{items.Count} veri için tamamlandı...";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    labelStatus.Text = $"Hata: {ex.Message}";
                }
            }




            List<Stok> stoks = await VeritabanindaStokCikar();

            // İşlem sırasındaki mesaj
            labelStatus.Text = $"Veritabanından {stoks.Count} adet veri çekildi. Şimdi POST işlemi başlatılıyor...";


            foreach (var stok in stoks)
            {
                string json = JsonConvert.SerializeObject(stok);
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync($"http://{ipAdresi}/(S({sessionID}))/IntegratorService/post?", content);
                        var result = await response.Content.ReadAsStringAsync();
                        postCount++;
                        labelStatus.Text = $"POST işlemi {postCount}/{items.Count} veri için tamamlandı...";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    labelStatus.Text = $"Hata: {ex.Message}";
                }
            }

            // İşlem bitiş mesajı
            labelStatus.Text = "İşlem tamamlandı.";

        }


        private void offlineSayimToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void müşteriÇekToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }



        private void trendyolYurtDışıSiparişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrendyolYurtDisiSiparis frm = new TrendyolYurtDisiSiparis();
            frm.Show();

        }

        private void qROluşturmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QROlusturma frm = new QROlusturma();
            frm.Show();
        }

        private void nebimToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private bool IsAdministrator( )
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void RunAsAdmin( )
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = Application.ExecutablePath;
            startInfo.UseShellExecute = true;
            startInfo.Verb = "runas"; // UAC penceresini açmak için "runas" komutunu kullanın.

            try
            {
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Yönetici izni istenemedi: " + ex.Message);
            }

            Application.Exit(); // Yeni bir uygulama örneği başlatıldığında mevcut uygulamayı kapatın.
        }
        private async Task<List<ZtNebimFaturaROnline>> VeritabanindanMusteriGetirFaturaROnline(string Firma)
        {

            try
            {
                List<ZtNebimFaturaROnline> musteriler = new List<ZtNebimFaturaROnline>();
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    SqlCommand command = new SqlCommand("MSG_GetOrderForInvoiceToplu_REOnline", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Firma", Firma);

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        ZtNebimFaturaROnline musteri = new ZtNebimFaturaROnline();
                        musteri.ModelType = Convert.ToInt32(reader["ModelType"]);
                        musteri.CustomerCode = reader["CustomerCode"].ToString();
                        musteri.OfficeCode = reader["OfficeCode"].ToString();
                        musteri.StoreCode = reader["StoreCode"].ToString();
                        musteri.WarehouseCode = reader["WarehouseCode"].ToString();
                        musteri.DeliveryCompanyCode = reader["DeliveryCompanyCode"].ToString(); // Direk string olarak atandı
                        musteri.BillingPostalAddressID = reader["BillingPostalAddressID"].ToString();
                        musteri.ShippingPostalAddressID = reader["ShippingPostalAddressID"].ToString(); // Direk string olarak atandı
                        musteri.PosTerminalID = Convert.ToInt32(reader["PosTerminalID"]); // int'e çevirildi
                        musteri.TaxExemptionCode = Convert.ToInt32(reader["TaxExemptionCode"]); // int'e çevirildi
                        musteri.ShipmentMethodCode = Convert.ToInt32(reader["ShipmentMethodCode"]); // int'e çevirildi
                        musteri.SendInvoiceByEMail = bool.Parse(reader["SendInvoiceByEMail"].ToString());
                        musteri.EMailAddress = reader["EMailAddress"].ToString();

                        musteri.IsOrderBase = bool.Parse(reader["IsOrderBase"].ToString());
                        if (reader["Invoicedate"] != DBNull.Value)
                        {
                            musteri.Invoicedate = Convert.ToDateTime(reader["Invoicedate"]); // DateTime'a çevirildi
                        }
                        musteri.IsSalesViaInternet = bool.Parse(reader["IsSalesViaInternet"].ToString());

                        musteri.Description = reader["Description"].ToString();
                        musteri.InternalDescription = reader["InternalDescription"].ToString();

                        //   musteri.CustomerTypeCode = Convert.ToInt32(reader["CustomerTypeCode"]);

                        string LinesJson = reader["Lines"].ToString();
                        JArray LinesArray = JArray.Parse(LinesJson);
                        musteri.Lines = LinesArray.ToObject<List<InvoiceLiness>>();

                        //string OrdersViaInternetInfosJson = reader["OrdersViaInternetInfo"].ToString();
                        //JToken parsedToken = JToken.Parse(OrdersViaInternetInfosJson);

                        //musteri.OrdersViaInternetInfo = new List<OrdersViaInternetInfo>();

                        //if (parsedToken is JArray) // Eğer dizi olarak başlıyorsa
                        //{
                        //    JArray OrdersViaInternetInfosArray = parsedToken as JArray;
                        //    foreach (var item in OrdersViaInternetInfosArray)
                        //    {
                        //        musteri.OrdersViaInternetInfo.Add(item.ToObject<OrdersViaInternetInfo>());
                        //    }
                        //}
                        //else if (parsedToken is JObject) // Eğer nesne olarak başlıyorsa
                        //{
                        //    OrdersViaInternetInfo singleObject = parsedToken.ToObject<OrdersViaInternetInfo>();
                        //    musteri.OrdersViaInternetInfo.Add(singleObject);
                        //}

                        string SalesViaInternetInfosJson = reader["SalesViaInternetInfo"].ToString();
                        JArray SalesViaInternetInfoArray = JArray.Parse(SalesViaInternetInfosJson);
                        musteri.SalesViaInternetInfo = SalesViaInternetInfoArray.ToObject<List<SalesViaInternetInfo>>().First();


                        //string PaymentsJson = reader["Payments"].ToString();
                        //JArray PaymentsArray = JArray.Parse(PaymentsJson);
                        //musteri.Payments = PaymentsArray.ToObject<List<Payments>>();

                        //string attributesJson = reader["Attributes"].ToString();
                        //JArray attributesArray = JArray.Parse(attributesJson);
                        //musteri.Attributes = attributesArray.ToObject<List<Attribute>>();


                        musteri.IsCompleted = bool.Parse(reader["IsCompleted"].ToString());
                        musteriler.Add(musteri);
                    }
                }

                return musteriler;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata Alındı");
                return null;
            }

        }
        private async Task<List<FaturaBilgisi>> GetFaturaBilgileriFromDatabasee( )
        {
            List<FaturaBilgisi> faturaBilgileri = new List<FaturaBilgisi>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("MSG_GetOrderForInvoiceToplu_DB", conn);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    FaturaBilgisi Firma = new FaturaBilgisi();
                    Firma.DataBaseNebim = reader["DataBaseNebim"].ToString();
                    Firma.IpAdres = reader["IpAdres"].ToString();
                    Firma.Firma = reader["Firma"].ToString();
                    faturaBilgileri.Add(Firma);
                }
            }
            // Her bir satır için FaturaBilgisi nesnesi oluşturup listeye ekleyin
            return faturaBilgileri;
        }

        private async Task<List<FaturaBilgisi2>> GetFaturaBilgileriFromDatabasee2( )
        {
            List<FaturaBilgisi2> faturaBilgileri = new List<FaturaBilgisi2>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("MSG_MisigoFirmaBilgileri_DB", conn);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    FaturaBilgisi2 Firma = new FaturaBilgisi2();
                    Firma.DataBaseNebim = reader["DataBaseNebim"].ToString();
                    Firma.IpAdres = reader["IpAdres"].ToString();
                    Firma.Firma = reader["Firma"].ToString();
                    faturaBilgileri.Add(Firma);
                }
            }
            // Her bir satır için FaturaBilgisi nesnesi oluşturup listeye ekleyin
            return faturaBilgileri;
        }



        private HttpClient httpClient = new HttpClient();
        private void ShowHtmlFromBase64(string base64String)
        {
            // Base64 string'ini byte dizisine çevir ve string'e dönüştür
            byte[] htmlBytes = Convert.FromBase64String(base64String);
            string htmlContent = Encoding.UTF8.GetString(htmlBytes);

            // HTML içeriğini WebBrowser kontrolünde göster
            webBrowser1.DocumentText = htmlContent;
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            labelStatus.Text = "Fatura Aktarımı Başladı...";
            List<FaturaBilgisi> faturaBilgileri = await GetFaturaBilgileriFromDatabasee();

            foreach (var faturaBilgisi in faturaBilgileri)
            {
                string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                List<ZtNebimFaturaROnline> items = await VeritabanindanMusteriGetirFaturaROnline(faturaBilgisi.Firma);

                labelStatus.Text = $"Veritabanından {items.Count} adet veri çekildi. Şimdi POST işlemi başlatılıyor...";
                int postCount = 0;
                var tasks = items.Select(async item =>
                {
                    string json = JsonConvert.SerializeObject(item);
                    try
                    {
                        string serverName = Properties.Settings.Default.SunucuAdi;
                        string userName = Properties.Settings.Default.KullaniciAdi;
                        string password = Properties.Settings.Default.Sifre;
                        string database = Properties.Settings.Default.database;
                        string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

                        string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync($"http://{faturaBilgisi.IpAdres}/(S({sessionID}))/IntegratorService/post?", content);

                        if (response.IsSuccessStatusCode)
                        {
                            //var result = await response.Content.ReadAsStringAsync();
                            //labelStatus.Text = $"POST işlemi {postCount}/{items.Count} veri için tamamlandı...";


                            using (SqlConnection conn = new SqlConnection(connectionString))
                            {
                                string query = "INSERT INTO ZTMSGTicSiparisKontrol (FaturaNo,Request,Cevap) VALUES (@FaturaNo,@Request,@Cevap)";
                                using (SqlCommand cmd = new SqlCommand(query, conn))
                                {
                                    var result = await response.Content.ReadAsStringAsync();
                                    dynamic jsonResponse = JsonConvert.DeserializeObject(result);

                                    cmd.Parameters.AddWithValue("@FaturaNo", item.CustomerCode);
                                    cmd.Parameters.AddWithValue("@Request", json);
                                    cmd.Parameters.AddWithValue("@Cevap", jsonResponse);

                                    labelStatus.Text = $"POST işlemi {postCount}/{items.Count} veri için tamamlandı...";
                                    conn.Open();
                                    cmd.ExecuteNonQuery();

                                    if (jsonResponse != null && jsonResponse.UnofficialInvoiceString != null)
                                    {

                                        ShowHtmlFromBase64(jsonResponse.UnofficialInvoiceString.ToString());
                                    }
                                }
                            }

                        }
                        else
                        {

                            using (SqlConnection conn = new SqlConnection(connectionString))
                            {
                                string query = "INSERT INTO ZTMSGTicSiparisKontrol (FaturaNo,Request,Cevap) VALUES (@FaturaNo,@Request,@Cevap)";
                                using (SqlCommand cmd = new SqlCommand(query, conn))
                                {
                                    var result = await response.Content.ReadAsStringAsync();
                                    cmd.Parameters.AddWithValue("@FaturaNo", item.CustomerCode);
                                    cmd.Parameters.AddWithValue("@Request", json);
                                    cmd.Parameters.AddWithValue("@Cevap", result);

                                    conn.Open();
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            labelStatus.Text = $"POST işlemi başarısız: {response.StatusCode}";
                        }
                    }
                    catch (Exception ex)
                    {
                        labelStatus.Text = $"Hata: {ex.ToString()}";  // Daha detaylı hata bilgisi
                    }
                }).ToList();

                await Task.WhenAll(tasks);

                labelStatus.Text = "Fatura Aktarımı tamamlandı.";
            }

            //if (IsAdministrator())
            //{


            //    // Kullanıcı yönetici olarak yetkilendirilmişse hizmeti başlatmaya çalışın.
            //    StartService();
            //    PerformSomeTask();
            //}
            //else
            //{
            //    // Kullanıcı yönetici izni olmadan hizmeti başlatmaya çalıştığında UAC penceresini açın.
            //    RunAsAdmin();
            //    PerformSomeTask();
            //}
        }
        private void StartService( )
        {
            try
            {
                // Servis kontrolcüsünü oluşturun ve servisin adını belirtin.
                ServiceController serviceController = new ServiceController("MSTicimaxMusteriAktar");

                // Servis zaten çalışıyorsa başlatma işlemine gerek yok.
                if (serviceController.Status != ServiceControllerStatus.Running)
                {
                    // Servisi başlatmaya çalışın.
                    serviceController.Start();

                    // Servisin başlamasını bekleyin (isteğe bağlı).
                    serviceController.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30));
                }

                // Servis başlatıldıysa düğmeyi yeşil yapın.
                button1.BackColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bir hata mesajı gösterin.
                MessageBox.Show("Servis başlatma hatası: " + ex.Message);
            }
        }
        private void StartService2( )
        {
            try
            {
                // Servis kontrolcüsünü oluşturun ve servisin adını belirtin.
                ServiceController serviceController = new ServiceController("MSDepolarArasiTransfer");

                // Servis zaten çalışıyorsa başlatma işlemine gerek yok.
                if (serviceController.Status != ServiceControllerStatus.Running)
                {
                    // Servisi başlatmaya çalışın.
                    serviceController.Start();

                    // Servisin başlamasını bekleyin (isteğe bağlı).
                    serviceController.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30));
                }

                // Servis başlatıldıysa düğmeyi yeşil yapın.
                button1.BackColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bir hata mesajı gösterin.
                MessageBox.Show("Servis başlatma hatası: " + ex.Message);
            }
        }
        private void PerformSomeTask( )
        {
            // Herhangi bir işlemi burada gerçekleştirin.

            // İşlem tamamlandığında Form_Load olayını güncelleyin.
            Form1_Load(this, EventArgs.Empty);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (IsAdministrator())
            {
                // Uygulamanın çalıştırılabilir dosyasının bulunduğu dizini al

                // Kullanıcı yönetici olarak yetkilendirilmişse hizmeti başlatmaya çalışın.
                StartService2();
                PerformSomeTask();
            }
            else
            {
                // Kullanıcı yönetici izni olmadan hizmeti başlatmaya çalıştığında UAC penceresini açın.
                RunAsAdmin();
                PerformSomeTask();
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //if (IsAdministrator())
            //{
            //    //// Uygulamanın çalıştırılabilir dosyasının bulunduğu dizini al
            //    //string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //    //// Uygulamanın bulunduğu dizinin tam yolunu al (exe dosyasının adını çıkart)
            //    //string appDirectory = System.IO.Path.GetDirectoryName(exePath);
            //    //// 'MusteriAktar' adlı alt klasördeki 'MusteriAktar.exe' dosyasının yolunu oluştur
            //    //string serviceFilePath = System.IO.Path.Combine(appDirectory, "MusteriAktar", "MusteriAktar.exe");

            //    //// Servisi yüklemek için kullan
            //    //InstallService(serviceFilePath);

            //}
            //else
            //{
            //    RunAsAdmin();
            //}

            //StartTimer();
        }
        private async Task<List<FaturaBilgisi>> GetFaturaBilgileriFromDatabase( )
        {
            List<FaturaBilgisi> faturaBilgileri = new List<FaturaBilgisi>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("MSG_GetOrderForInvoiceToplu_DB", conn);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    FaturaBilgisi Firma = new FaturaBilgisi();
                    Firma.DataBaseNebim = reader["DataBaseNebim"].ToString();
                    Firma.IpAdres = reader["IpAdres"].ToString();
                    Firma.Firma = reader["Firma"].ToString();
                    faturaBilgileri.Add(Firma);
                }
            }
            // Her bir satır için FaturaBilgisi nesnesi oluşturup listeye ekleyin
            return faturaBilgileri;
        }

        private async Task<string> ConnectIntegrator(string IpAdres)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://" + IpAdres + "/IntegratorService/Connect");

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                VM_HttpConnectionRequest session = JsonConvert.DeserializeObject<VM_HttpConnectionRequest>(responseBody);

                string sessionId = session.SessionId;
                // Console.WriteLine(responseBody);
                return sessionId;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP isteği başarısız: {ex.Message}");
                return null;
            }
        }


        private async Task<List<ZtNebimFaturaRShipment>> VeritabanindanMusteriGetirFaturaR(string Firma)
        {

            try
            {
                List<ZtNebimFaturaRShipment> musteriler = new List<ZtNebimFaturaRShipment>();
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    SqlCommand command = new SqlCommand("MSG_GetOrderForInvoiceToplu_RShipment", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Firma", Firma);

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        ZtNebimFaturaRShipment musteri = new ZtNebimFaturaRShipment();
                        musteri.ModelType = Convert.ToInt32(reader["ModelType"]);
                        musteri.CustomerCode = reader["CustomerCode"].ToString();
                        musteri.OfficeCode = reader["OfficeCode"].ToString();
                        musteri.StoreCode = reader["StoreCode"].ToString();
                        musteri.WarehouseCode = reader["WarehouseCode"].ToString();
                        musteri.DeliveryCompanyCode = reader["DeliveryCompanyCode"].ToString(); // Direk string olarak atandı
                        musteri.BillingPostalAddressID = reader["BillingPostalAddressID"].ToString();
                        musteri.ShippingPostalAddressID = reader["ShippingPostalAddressID"].ToString(); // Direk string olarak atandı
                        musteri.PosTerminalID = Convert.ToInt32(reader["PosTerminalID"]); // int'e çevirildi
                        musteri.TaxExemptionCode = Convert.ToInt32(reader["TaxExemptionCode"]); // int'e çevirildi
                        musteri.ShipmentMethodCode = Convert.ToInt32(reader["ShipmentMethodCode"]); // int'e çevirildi
                        musteri.SendInvoiceByEMail = bool.Parse(reader["SendInvoiceByEMail"].ToString());
                        musteri.EMailAddress = reader["EMailAddress"].ToString();

                        musteri.IsShipmentBase = bool.Parse(reader["IsShipmentBase"].ToString());
                        if (reader["Invoicedate"] != DBNull.Value)
                        {
                            musteri.Invoicedate = Convert.ToDateTime(reader["Invoicedate"]); // DateTime'a çevirildi
                        }
                        musteri.IsSalesViaInternet = bool.Parse(reader["IsSalesViaInternet"].ToString());

                        musteri.Description = reader["Description"].ToString();
                        musteri.InternalDescription = reader["InternalDescription"].ToString();

                        //   musteri.CustomerTypeCode = Convert.ToInt32(reader["CustomerTypeCode"]);

                        string LinesJson = reader["Lines"].ToString();
                        JArray LinesArray = JArray.Parse(LinesJson);
                        musteri.Lines = LinesArray.ToObject<List<InvoiceLinesss>>();

                        //string OrdersViaInternetInfosJson = reader["OrdersViaInternetInfo"].ToString();
                        //JToken parsedToken = JToken.Parse(OrdersViaInternetInfosJson);

                        //musteri.OrdersViaInternetInfo = new List<OrdersViaInternetInfo>();

                        //if (parsedToken is JArray) // Eğer dizi olarak başlıyorsa
                        //{
                        //    JArray OrdersViaInternetInfosArray = parsedToken as JArray;
                        //    foreach (var item in OrdersViaInternetInfosArray)
                        //    {
                        //        musteri.OrdersViaInternetInfo.Add(item.ToObject<OrdersViaInternetInfo>());
                        //    }
                        //}
                        //else if (parsedToken is JObject) // Eğer nesne olarak başlıyorsa
                        //{
                        //    OrdersViaInternetInfo singleObject = parsedToken.ToObject<OrdersViaInternetInfo>();
                        //    musteri.OrdersViaInternetInfo.Add(singleObject);
                        //}
                        string PostalAddressJson = reader["PostalAddress"].ToString();
                        //JArray PostalAddressArray = JArray.Parse(PostalAddressJson);
                        musteri.PostalAddress = JsonConvert.DeserializeObject<PostalAddress>(PostalAddressJson);



                        string SalesViaInternetInfosJson = reader["SalesViaInternetInfo"].ToString();
                        JArray SalesViaInternetInfoArray = JArray.Parse(SalesViaInternetInfosJson);
                        musteri.SalesViaInternetInfo = SalesViaInternetInfoArray.ToObject<List<SalesViaInternetInfo>>().First();


                        string PaymentsJson = reader["Payments"].ToString();
                        JArray PaymentsArray = JArray.Parse(PaymentsJson);
                        musteri.Payments = PaymentsArray.ToObject<List<Payments>>();

                        //string attributesJson = reader["Attributes"].ToString();
                        //JArray attributesArray = JArray.Parse(attributesJson);
                        //musteri.Attributes = attributesArray.ToObject<List<Attribute>>();


                        musteri.IsCompleted = bool.Parse(reader["IsCompleted"].ToString());
                        musteriler.Add(musteri);
                    }
                }

                return musteriler;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata Alındı");
                return null;
            }

        }
        private async Task<string> ResimEkle( )
        {
            try
            {

                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    SqlCommand command = new SqlCommand("MSG_MisigoResimListEkle", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = await command.ExecuteReaderAsync();


                }
                // Her bir satır için FaturaBilgisi nesnesi oluşturup listeye ekleyin
                return "İşlem başarılı"; // Gerçek sonuç değerini döndürün
            }
            catch (Exception ex)
            {
                // Hata yönetimi burada yapılabilir
                return $"Hata: {ex.Message}";
            }
        }

        private async Task<string> FiyatDuzenle( )
        {
            try
            {

                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    SqlCommand command = new SqlCommand("MSG_MisigoFiyatDuzenle", conn);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = await command.ExecuteReaderAsync();


                }
                // Her bir satır için FaturaBilgisi nesnesi oluşturup listeye ekleyin
                return "İşlem başarılı"; // Gerçek sonuç değerini döndürün
            }
            catch (Exception ex)
            {
                // Hata yönetimi burada yapılabilir
                return $"Hata: {ex.Message}";
            }
        }




        private async void button6_Click(object sender, EventArgs e)
        {



            labelStatus.Text = "Fatura Aktarımı Başladı...";
            List<FaturaBilgisi> faturaBilgileri = await GetFaturaBilgileriFromDatabase();

            foreach (var faturaBilgisi in faturaBilgileri)
            {
                string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                List<ZtNebimFaturaRShipment> items = await VeritabanindanMusteriGetirFaturaR(faturaBilgisi.Firma);

                labelStatus.Text = $"Veritabanından {items.Count} adet veri çekildi. Şimdi POST işlemi başlatılıyor...";
                int postCount = 0;
                var tasks = items.Select(async item =>
                {
                    string json = JsonConvert.SerializeObject(item);
                    try
                    {
                        string serverName = Properties.Settings.Default.SunucuAdi;
                        string userName = Properties.Settings.Default.KullaniciAdi;
                        string password = Properties.Settings.Default.Sifre;
                        string database = Properties.Settings.Default.database;
                        string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

                        string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync($"http://{faturaBilgisi.IpAdres}/(S({sessionID}))/IntegratorService/post?", content);

                        if (response.IsSuccessStatusCode)
                        {
                            //var result = await response.Content.ReadAsStringAsync();
                            //labelStatus.Text = $"POST işlemi {postCount}/{items.Count} veri için tamamlandı...";

                            using (SqlConnection conn = new SqlConnection(connectionString))
                            {
                                string query = "INSERT INTO ZTMSGTicSiparisKontrol (FaturaNo,Request,Cevap) VALUES (@FaturaNo,@Request,@Cevap)";
                                using (SqlCommand cmd = new SqlCommand(query, conn))
                                {
                                    var result = await response.Content.ReadAsStringAsync();
                                    cmd.Parameters.AddWithValue("@FaturaNo", item.CustomerCode);
                                    cmd.Parameters.AddWithValue("@Request", json);
                                    cmd.Parameters.AddWithValue("@Cevap", result);

                                    labelStatus.Text = $"POST işlemi {postCount}/{items.Count} veri için tamamlandı...";
                                    conn.Open();
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {

                            using (SqlConnection conn = new SqlConnection(connectionString))
                            {
                                string query = "INSERT INTO ZTMSGTicSiparisKontrol (FaturaNo,Request,Cevap) VALUES (@FaturaNo,@Request,@Cevap)";
                                using (SqlCommand cmd = new SqlCommand(query, conn))
                                {
                                    var result = await response.Content.ReadAsStringAsync();
                                    cmd.Parameters.AddWithValue("@FaturaNo", item.CustomerCode);
                                    cmd.Parameters.AddWithValue("@Request", json);
                                    cmd.Parameters.AddWithValue("@Cevap", result);

                                    conn.Open();
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            labelStatus.Text = $"POST işlemi başarısız: {response.StatusCode}";
                        }

                    }
                    catch (Exception ex)
                    {
                        string serverName = Properties.Settings.Default.SunucuAdi;
                        string userName = Properties.Settings.Default.KullaniciAdi;
                        string password = Properties.Settings.Default.Sifre;
                        string database = Properties.Settings.Default.database;
                        string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

                        string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            string query = "INSERT INTO ZTMSGTicSiparisKontrol (FaturaNo,Request,Cevap) VALUES (@FaturaNo,@Request,@Cevap)";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {

                                cmd.Parameters.AddWithValue("@FaturaNo", item.CustomerCode);
                                cmd.Parameters.AddWithValue("@Request", ex.ToString());
                                cmd.Parameters.AddWithValue("@Cevap", ex.ToString());

                                conn.Open();
                                cmd.ExecuteNonQuery();
                            }
                        }
                        labelStatus.Text = $"Hata: {ex.ToString()}";  // Daha detaylı hata bilgisi
                    }
                }).ToList();

                await Task.WhenAll(tasks);

                labelStatus.Text = "Fatura Aktarımı tamamlandı.";
            }
        }

        private void kargoÇıkışKontrolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KargoCikis frm = new KargoCikis();
            frm.Show();
        }

        private void faturalaştırmaİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFaturalastir frm = new frmFaturalastir();
            frm.Show();
        }

        private void dilÇeviriToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void siparişİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nebimSayimAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void faturalaştırToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void canlıSatışEkranıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SatisForm frm = new SatisForm();
            frm.Show();
        }

        private async Task<List<Stok2>> MisigoVeritabanindaStokEkle( )
        {
            List<Stok2> stoks = new List<Stok2>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("MSG_MisigoSayimEkle", conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Stok2 stok = new Stok2();

                    stok.ModelType = reader["ModelType"].ToString();
                    stok.OfficeCode = reader["OfficeCode"].ToString();
                    stok.StoreCode = reader["StoreCode"].ToString();
                    stok.WarehouseCode = reader["WarehouseCode"].ToString();
                    stok.CompanyCode = Convert.ToInt32(reader["CompanyCode"]);
                    stok.InnerProcessType = Convert.ToInt32(reader["InnerProcessType"]);


                    string LinesJson = reader["Lines"].ToString();
                    if (!string.IsNullOrEmpty(LinesJson))
                    {
                        JArray variantArray = JArray.Parse(LinesJson);
                        stok.Lines = variantArray.ToObject<List<Lines2>>();

                    }
                    else
                    {
                        Console.WriteLine("LinesJson boş veya null.");
                    }

                    // Diğer alanları doldurmak için benzer işlemler...

                    stoks.Add(stok);
                }
            }




            return stoks;
        }

        private async Task<List<Stok2>> MisigoVeritabanindaStokCikar( )
        {
            List<Stok2> stoks = new List<Stok2>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("MSG_MisigoSayimCikar", conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Stok2 stok = new Stok2();

                    stok.ModelType = reader["ModelType"].ToString();
                    stok.OfficeCode = reader["OfficeCode"].ToString();
                    stok.StoreCode = reader["StoreCode"].ToString();
                    stok.WarehouseCode = reader["WarehouseCode"].ToString();
                    stok.CompanyCode = Convert.ToInt32(reader["CompanyCode"]);
                    stok.InnerProcessType = Convert.ToInt32(reader["InnerProcessType"]);


                    string LinesJson = reader["Lines"].ToString();
                    if (!string.IsNullOrEmpty(LinesJson))
                    {
                        JArray variantArray = JArray.Parse(LinesJson);
                        stok.Lines = variantArray.ToObject<List<Lines2>>();

                    }
                    else
                    {
                        Console.WriteLine("LinesJson boş veya null.");
                    }


                    // Diğer alanları doldurmak için benzer işlemler...

                    stoks.Add(stok);
                }
            }




            return stoks;
        }









        private async void misigoÜrünleriÇekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await UpdateDownloadedItem2();
            await ResimEkle();
            //await UpdateDownloadedItemUpdate();
            await FiyatDuzenle();
            await StokGuncelle();
            await ItemsEkle();
            //await DownloadImagesAsyncMisigo();
            MessageBox.Show("Ürün Çekme İşlemi Gerçekleşti");




        }




        private async Task StokGuncelle( )
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;




            // İşlem başlangıç mesajı
            labelStatus.Text = "İşlem başladı...";

            string sessionID = await ConnectIntegrator();

            List<Stok2> items = await MisigoVeritabanindaStokEkle();

            // İşlem sırasındaki mesaj
            labelStatus.Text = $"Veritabanından {items.Count} adet veri çekildi. Şimdi POST işlemi başlatılıyor...";

            int postCount = 0;
            foreach (var item in items)
            {
                string json = JsonConvert.SerializeObject(item);
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync($"http://{ipAdresi}/(S({sessionID}))/IntegratorService/post?", content);
                        var result = await response.Content.ReadAsStringAsync();
                        postCount++;
                        labelStatus.Text = $"POST işlemi {postCount}/{items.Count} veri için tamamlandı...";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    labelStatus.Text = $"Hata: {ex.Message}";
                }
            }




            List<Stok2> stoks = await MisigoVeritabanindaStokCikar();

            // İşlem sırasındaki mesaj
            labelStatus.Text = $"Veritabanından {stoks.Count} adet veri çekildi. Şimdi POST işlemi başlatılıyor...";


            foreach (var stok in stoks)
            {
                string json = JsonConvert.SerializeObject(stok);
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync($"http://{ipAdresi}/(S({sessionID}))/IntegratorService/post?", content);
                        var result = await response.Content.ReadAsStringAsync();
                        postCount++;
                        labelStatus.Text = $"POST işlemi {postCount}/{items.Count} veri için tamamlandı...";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    labelStatus.Text = $"Hata: {ex.Message}";
                }
            }

            // İşlem bitiş mesajı
            labelStatus.Text = "İşlem tamamlandı.";

        }


        //private readonly string baseApiUrl = "http://88.247.135.125:7474/photo/";
        //private readonly string localSavePath = "C:\\Foto";
        private string CleanInvalidFileName(string fileName)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            return new string(fileName.Where(c => !invalidChars.Contains(c)).ToArray());
        }



        private async Task ItemsEkle( )
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;

            string kolonAdi = Properties.Settings.Default.txtlot; // Kolon adını alır.

            if (!string.IsNullOrWhiteSpace(kolonAdi))
            {
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Şimdi aldığınız veriyi cdLot tablosuna ekleyin.
                    string insertQuery = $"INSERT INTO cdLot (LotCode, ItemDimTypeCode, IsBlocked) " +
                                         $"SELECT {kolonAdi}, 2, 0 " +
                                         $"FROM ZTMSGTicUrunler " +
                                         $"WHERE {kolonAdi} != '' AND {kolonAdi} NOT IN (SELECT LotCode FROM cdLot) " +
                                         $"GROUP BY {kolonAdi}";

                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        int rowsAffected = insertCommand.ExecuteNonQuery();
                        //   MessageBox.Show($"{rowsAffected} rows inserted.");
                        labelStatus.Text = $"{rowsAffected} rows inserted.";
                    }
                }
            }
            else
            {
                Console.WriteLine("Hata  Alındı");
            }


            // İşlem başlangıç mesajı
            labelStatus.Text = "Ürün Aktarma  İşlem başladı...";

            string sessionID = await ConnectIntegrator();

            List<Item3> items = await VeritabanindanItemGetirMisigo();

            // İşlem sırasındaki mesaj
            labelStatus.Text = $"Veritabanından {items.Count} adet veri çekildi. Şimdi POST işlemi başlatılıyor...";

            int postCount = 0;
            foreach (var item in items)
            {
                string json = JsonConvert.SerializeObject(item);
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync($"http://{ipAdresi}/(S({sessionID}))/IntegratorService/post?", content);
                        var result = await response.Content.ReadAsStringAsync();
                        postCount++;
                        labelStatus.Text = $"POST işlemi {postCount}/{items.Count} veri için tamamlandı...";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    labelStatus.Text = $"Hata: {ex.Message}";
                }
            }

            // İşlem bitiş mesajı
            labelStatus.Text = "Ürün Aktarma İşlem tamamlandı.";
        }

        private async Task UpdateDownloadedItem2( )
        {
            try
            {
                List<FaturaBilgisi2> faturaBilgileri = await GetFaturaBilgileriFromDatabasee2();

                foreach (var faturaBilgisi in faturaBilgileri)
                {
                    try
                    {
                        string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                        var procName = "MSGMusteriUrunList";
                        var jsonData = JsonConvert.SerializeObject(new { ProcName = procName });

                        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var apiUrl = $"http://{faturaBilgisi.IpAdres}/(S({sessionID}))/IntegratorService/RunProc?";

                        var response = await httpClient.PostAsync(apiUrl, content);

                        if (response.IsSuccessStatusCode)
                        {
                            string jsonResponse = await response.Content.ReadAsStringAsync();
                            var yourJsonResponseList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonResponse);

                            var urunListesi = new List<ZTMSGUrunListMisigo>();
                            foreach (var urunBilgisi in yourJsonResponseList)
                            {
                                var urunMisigo = new ZTMSGUrunListMisigo
                                {
                                    ItemCode = urunBilgisi["Ürün Kodu"]?.ToString(),
                                    Itemdescription = urunBilgisi["Ürün Adi"]?.ToString(),
                                    ColorCode = urunBilgisi["Renk Kodu"]?.ToString(),
                                    Color = urunBilgisi["ColorDescription"]?.ToString(),
                                    ItemDim1Code = urunBilgisi["Beden"]?.ToString(),
                                    Barcode = urunBilgisi["Barkod"]?.ToString(),
                                    Envanter = int.TryParse(urunBilgisi["Envanter"]?.ToString(), out int envanterValue) ? envanterValue : 0,

                                    MisigoWebSatis = urunBilgisi["Misigo Web Satış"] != null ? Convert.ToDecimal(urunBilgisi["Misigo Web Satış"]) : 0,
                                    MisigoWebIndirimliSatis = urunBilgisi["Misigo Web Minimum Satış"] != null ? Convert.ToDecimal(urunBilgisi["Misigo Web Minimum Satış"]) : 0,
                                    MisigoPazaryeriSatis = urunBilgisi["Misigo Pazaryeri Satış"] != null ? Convert.ToDecimal(urunBilgisi["Misigo Pazaryeri Satış"]) : 0,
                                    MisigoPazaryeriIndirimliSatis = urunBilgisi["Misigo Pazaryeri Minimum Satış"] != null ? Convert.ToDecimal(urunBilgisi["Misigo Pazaryeri Minimum Satış"]) : 0,
                                    ProductHierarchyLevel01 = urunBilgisi["ProductHierarchyLevel01"]?.ToString(),
                                    ProductHierarchyLevel02 = urunBilgisi["ProductHierarchyLevel02"]?.ToString(),
                                    ProductHierarchyLevel03 = urunBilgisi["ProductHierarchyLevel03"]?.ToString(),
                                    ProductHierarchyLevel04 = urunBilgisi["ProductHierarchyLevel04"]?.ToString(),
                                    ProductAtt01Type = urunBilgisi["ProductAtt01Type"]?.ToString(),
                                    ProductAtt01Desc = urunBilgisi["ProductAtt01Desc"]?.ToString(),
                                    ProductAtt02Type = urunBilgisi["ProductAtt02Type"]?.ToString(),
                                    ProductAtt02Desc = urunBilgisi["ProductAtt02Desc"]?.ToString(),
                                    ProductAtt03Type = urunBilgisi["ProductAtt03Type"]?.ToString(),
                                    ProductAtt03Desc = urunBilgisi["ProductAtt03Desc"]?.ToString(),
                                    ProductAtt04Type = urunBilgisi["ProductAtt04Type"]?.ToString(),
                                    ProductAtt04Desc = urunBilgisi["ProductAtt04Desc"]?.ToString(),
                                    ProductAtt05Type = urunBilgisi["ProductAtt05Type"]?.ToString(),
                                    ProductAtt05Desc = urunBilgisi["ProductAtt05Desc"]?.ToString(),
                                    ProductAtt06Type = urunBilgisi["ProductAtt06Type"]?.ToString(),
                                    ProductAtt06Desc = urunBilgisi["ProductAtt06Desc"]?.ToString(),
                                    ProductAtt07Type = urunBilgisi["ProductAtt07Type"]?.ToString(),
                                    ProductAtt07Desc = urunBilgisi["ProductAtt07Desc"]?.ToString(),
                                    ProductAtt08Type = urunBilgisi["ProductAtt08Type"]?.ToString(),
                                    ProductAtt08Desc = urunBilgisi["ProductAtt08Desc"]?.ToString(),
                                    ProductAtt09Type = urunBilgisi["ProductAtt09Type"]?.ToString(),
                                    ProductAtt09Desc = urunBilgisi["ProductAtt09Desc"]?.ToString(),
                                    ProductAtt10Type = urunBilgisi["ProductAtt10Type"]?.ToString(),
                                    ProductAtt10Desc = urunBilgisi["ProductAtt10Desc"]?.ToString(),
                                    ProductAtt11Type = urunBilgisi["ProductAtt11Type"]?.ToString(),
                                    ProductAtt11Desc = urunBilgisi["ProductAtt11Desc"]?.ToString(),
                                    ProductAtt12Type = urunBilgisi["ProductAtt12Type"]?.ToString(),
                                    ProductAtt12Desc = urunBilgisi["ProductAtt12Desc"]?.ToString(),
                                    ProductAtt13Type = urunBilgisi["ProductAtt13Type"]?.ToString(),
                                    ProductAtt13Desc = urunBilgisi["ProductAtt13Desc"]?.ToString(),
                                    ProductAtt14Type = urunBilgisi["ProductAtt14Type"]?.ToString(),
                                    ProductAtt14Desc = urunBilgisi["ProductAtt14Desc"]?.ToString(),
                                    ProductAtt15Type = urunBilgisi["ProductAtt15Type"]?.ToString(),
                                    ProductAtt15Desc = urunBilgisi["ProductAtt15Desc"]?.ToString(),
                                    ProductAtt16Type = urunBilgisi["ProductAtt16Type"]?.ToString(),
                                    ProductAtt16Desc = urunBilgisi["ProductAtt16Desc"]?.ToString(),
                                    ProductAtt17Type = urunBilgisi["ProductAtt17Type"]?.ToString(),
                                    ProductAtt17Desc = urunBilgisi["ProductAtt17Desc"]?.ToString(),
                                    ProductAtt18Type = urunBilgisi["ProductAtt18Type"]?.ToString(),
                                    ProductAtt18Desc = urunBilgisi["ProductAtt18Desc"]?.ToString(),
                                    ProductAtt19Type = urunBilgisi["ProductAtt19Type"]?.ToString(),
                                    ProductAtt19Desc = urunBilgisi["ProductAtt19Desc"]?.ToString(),
                                    ProductAtt20Type = urunBilgisi["ProductAtt20Type"]?.ToString(),
                                    ProductAtt20Desc = urunBilgisi["ProductAtt20Desc"]?.ToString(),
                                    // ... Diğer özellikler burada eklenmeli
                                };

                                urunListesi.Add(urunMisigo);
                            }
                            if (urunListesi.Any())
                            {
                                await DeleteExistingBarcodes(urunListesi);

                            }
                            if (urunListesi.Any())
                            {
                                await BulkInsertProducts(urunListesi);
                                labelStatus.Text = "Site Aktarım Tamamlandı";
                            }
                        }
                        else
                        {
                            Console.WriteLine("Hata: Yanıt başarısız.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Hata: {ex.ToString()}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.ToString()}");
            }
        }

        private async Task DeleteExistingBarcodes(List<ZTMSGUrunListMisigo> urunListesi)
        {
            try
            {
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;

                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
                int batchSize = 2000; // 2100'den az bir değer seçin
                for (int i = 0; i < urunListesi.Count; i += batchSize)
                {
                    var batch = urunListesi.Skip(i).Take(batchSize);
                    var barkodlar = batch.Select(u => u.Barcode).ToList();
                    var barkodParametreleri = string.Join(", ", barkodlar.Select((s, index) => $"@Barkod{index}")); // "i" yerine "index" kullanın

                    string query = $"DELETE FROM dbo.ZTMSGUrunListMisigo WHERE Barcode IN ({barkodParametreleri})";

                    using (var connection = new SqlConnection(connectionString))
                    {
                        using (var command = new SqlCommand(query, connection))
                        {
                            for (int j = 0; j < barkodlar.Count; j++) // "i" yerine "j" kullanın
                            {
                                command.Parameters.AddWithValue($"@Barkod{j}", barkodlar[j]);
                            }
                            await connection.OpenAsync();
                            await command.ExecuteNonQueryAsync();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"SQL kaydetme hatası: {ex.Message}");
            }

        }

        private async Task BulkInsertProducts(List<ZTMSGUrunListMisigo> urunListesi)
        {

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (var bulkCopy = new SqlBulkCopy(connectionString))
            {
                bulkCopy.BulkCopyTimeout = 600; // Örneğin, 10 dakika

                bulkCopy.DestinationTableName = "dbo.ZTMSGUrunListMisigo"; // Hedef tablo adı

                // Sütun eşlemelerini tanımlayın
                bulkCopy.ColumnMappings.Add("ItemCode", "ItemCode");
                bulkCopy.ColumnMappings.Add("Itemdescription", "Itemdescription");
                bulkCopy.ColumnMappings.Add("ColorCode", "ColorCode");
                bulkCopy.ColumnMappings.Add("Color", "Color");
                bulkCopy.ColumnMappings.Add("ItemDim1Code", "ItemDim1Code");
                bulkCopy.ColumnMappings.Add("Barcode", "Barcode");
                bulkCopy.ColumnMappings.Add("Envanter", "Envanter");
                bulkCopy.ColumnMappings.Add("MisigoWebSatis", "MisigoWebSatis");
                bulkCopy.ColumnMappings.Add("MisigoWebIndirimliSatis", "MisigoWebIndirimliSatis");
                bulkCopy.ColumnMappings.Add("MisigoPazaryeriSatis", "MisigoPazaryeriSatis");
                bulkCopy.ColumnMappings.Add("MisigoPazaryeriIndirimliSatis", "MisigoPazaryeriIndirimliSatis");
                bulkCopy.ColumnMappings.Add("ProductHierarchyLevel01", "ProductHierarchyLevel01");
                bulkCopy.ColumnMappings.Add("ProductHierarchyLevel02", "ProductHierarchyLevel02");
                bulkCopy.ColumnMappings.Add("ProductHierarchyLevel03", "ProductHierarchyLevel03");
                bulkCopy.ColumnMappings.Add("ProductHierarchyLevel04", "ProductHierarchyLevel04");
                bulkCopy.ColumnMappings.Add("ProductAtt01Type", "ProductAtt01Type");
                bulkCopy.ColumnMappings.Add("ProductAtt01Desc", "ProductAtt01Desc");
                bulkCopy.ColumnMappings.Add("ProductAtt02Type", "ProductAtt02Type");
                bulkCopy.ColumnMappings.Add("ProductAtt02Desc", "ProductAtt02Desc");
                bulkCopy.ColumnMappings.Add("ProductAtt03Type", "ProductAtt03Type");
                bulkCopy.ColumnMappings.Add("ProductAtt03Desc", "ProductAtt03Desc");
                bulkCopy.ColumnMappings.Add("ProductAtt04Type", "ProductAtt04Type");
                bulkCopy.ColumnMappings.Add("ProductAtt04Desc", "ProductAtt04Desc");
                bulkCopy.ColumnMappings.Add("ProductAtt05Type", "ProductAtt05Type");
                bulkCopy.ColumnMappings.Add("ProductAtt05Desc", "ProductAtt05Desc");
                bulkCopy.ColumnMappings.Add("ProductAtt06Type", "ProductAtt06Type");
                bulkCopy.ColumnMappings.Add("ProductAtt06Desc", "ProductAtt06Desc");
                bulkCopy.ColumnMappings.Add("ProductAtt07Type", "ProductAtt07Type");
                bulkCopy.ColumnMappings.Add("ProductAtt07Desc", "ProductAtt07Desc");
                bulkCopy.ColumnMappings.Add("ProductAtt08Type", "ProductAtt08Type");
                bulkCopy.ColumnMappings.Add("ProductAtt08Desc", "ProductAtt08Desc");
                bulkCopy.ColumnMappings.Add("ProductAtt09Type", "ProductAtt09Type");
                bulkCopy.ColumnMappings.Add("ProductAtt09Desc", "ProductAtt09Desc");
                bulkCopy.ColumnMappings.Add("ProductAtt10Type", "ProductAtt10Type");
                bulkCopy.ColumnMappings.Add("ProductAtt10Desc", "ProductAtt10Desc");
                bulkCopy.ColumnMappings.Add("ProductAtt11Type", "ProductAtt11Type");
                bulkCopy.ColumnMappings.Add("ProductAtt11Desc", "ProductAtt11Desc");
                bulkCopy.ColumnMappings.Add("ProductAtt12Type", "ProductAtt12Type");
                bulkCopy.ColumnMappings.Add("ProductAtt12Desc", "ProductAtt12Desc");
                bulkCopy.ColumnMappings.Add("ProductAtt13Type", "ProductAtt13Type");
                bulkCopy.ColumnMappings.Add("ProductAtt13Desc", "ProductAtt13Desc");
                bulkCopy.ColumnMappings.Add("ProductAtt14Type", "ProductAtt14Type");
                bulkCopy.ColumnMappings.Add("ProductAtt14Desc", "ProductAtt14Desc");
                bulkCopy.ColumnMappings.Add("ProductAtt15Type", "ProductAtt15Type");
                bulkCopy.ColumnMappings.Add("ProductAtt15Desc", "ProductAtt15Desc");
                bulkCopy.ColumnMappings.Add("ProductAtt16Type", "ProductAtt16Type");
                bulkCopy.ColumnMappings.Add("ProductAtt16Desc", "ProductAtt16Desc");
                bulkCopy.ColumnMappings.Add("ProductAtt17Type", "ProductAtt17Type");
                bulkCopy.ColumnMappings.Add("ProductAtt17Desc", "ProductAtt17Desc");
                bulkCopy.ColumnMappings.Add("ProductAtt18Type", "ProductAtt18Type");
                bulkCopy.ColumnMappings.Add("ProductAtt18Desc", "ProductAtt18Desc");
                bulkCopy.ColumnMappings.Add("ProductAtt19Type", "ProductAtt19Type");
                bulkCopy.ColumnMappings.Add("ProductAtt19Desc", "ProductAtt19Desc");
                bulkCopy.ColumnMappings.Add("ProductAtt20Type", "ProductAtt20Type");
                bulkCopy.ColumnMappings.Add("ProductAtt20Desc", "ProductAtt20Desc");
                // Diğer sütunlar için de benzer şekilde eşleme yapın

                // DataTable oluşturup verileri ekleyin
                // DataTable oluşturup verileri ekleyin
                DataTable dt = new DataTable();
                dt.Columns.Add("ItemCode", typeof(string));
                dt.Columns.Add("Itemdescription", typeof(string));
                dt.Columns.Add("ColorCode", typeof(string));
                dt.Columns.Add("Color", typeof(string));
                dt.Columns.Add("ItemDim1Code", typeof(string));
                dt.Columns.Add("Barcode", typeof(string));
                dt.Columns.Add("Envanter", typeof(int));
                dt.Columns.Add("MisigoWebSatis", typeof(decimal));
                dt.Columns.Add("MisigoWebIndirimliSatis", typeof(decimal));
                dt.Columns.Add("MisigoPazaryeriSatis", typeof(decimal));
                dt.Columns.Add("MisigoPazaryeriIndirimliSatis", typeof(decimal));
                dt.Columns.Add("ProductHierarchyLevel01", typeof(string));
                dt.Columns.Add("ProductHierarchyLevel02", typeof(string));
                dt.Columns.Add("ProductHierarchyLevel03", typeof(string));
                dt.Columns.Add("ProductHierarchyLevel04", typeof(string));
                dt.Columns.Add("ProductAtt01Type", typeof(string));
                dt.Columns.Add("ProductAtt01Desc", typeof(string));
                dt.Columns.Add("ProductAtt02Type", typeof(string));
                dt.Columns.Add("ProductAtt02Desc", typeof(string));
                dt.Columns.Add("ProductAtt03Type", typeof(string));
                dt.Columns.Add("ProductAtt03Desc", typeof(string));
                dt.Columns.Add("ProductAtt04Type", typeof(string));
                dt.Columns.Add("ProductAtt04Desc", typeof(string));
                dt.Columns.Add("ProductAtt05Type", typeof(string));
                dt.Columns.Add("ProductAtt05Desc", typeof(string));
                dt.Columns.Add("ProductAtt06Type", typeof(string));
                dt.Columns.Add("ProductAtt06Desc", typeof(string));
                dt.Columns.Add("ProductAtt07Type", typeof(string));
                dt.Columns.Add("ProductAtt07Desc", typeof(string));
                dt.Columns.Add("ProductAtt08Type", typeof(string));
                dt.Columns.Add("ProductAtt08Desc", typeof(string));
                dt.Columns.Add("ProductAtt09Type", typeof(string));
                dt.Columns.Add("ProductAtt09Desc", typeof(string));
                dt.Columns.Add("ProductAtt10Type", typeof(string));
                dt.Columns.Add("ProductAtt10Desc", typeof(string));
                dt.Columns.Add("ProductAtt11Type", typeof(string));
                dt.Columns.Add("ProductAtt11Desc", typeof(string));
                dt.Columns.Add("ProductAtt12Type", typeof(string));
                dt.Columns.Add("ProductAtt12Desc", typeof(string));
                dt.Columns.Add("ProductAtt13Type", typeof(string));
                dt.Columns.Add("ProductAtt13Desc", typeof(string));
                dt.Columns.Add("ProductAtt14Type", typeof(string));
                dt.Columns.Add("ProductAtt14Desc", typeof(string));
                dt.Columns.Add("ProductAtt15Type", typeof(string));
                dt.Columns.Add("ProductAtt15Desc", typeof(string));
                dt.Columns.Add("ProductAtt16Type", typeof(string));
                dt.Columns.Add("ProductAtt16Desc", typeof(string));
                dt.Columns.Add("ProductAtt17Type", typeof(string));
                dt.Columns.Add("ProductAtt17Desc", typeof(string));
                dt.Columns.Add("ProductAtt18Type", typeof(string));
                dt.Columns.Add("ProductAtt18Desc", typeof(string));
                dt.Columns.Add("ProductAtt19Type", typeof(string));
                dt.Columns.Add("ProductAtt19Desc", typeof(string));
                dt.Columns.Add("ProductAtt20Type", typeof(string));
                dt.Columns.Add("ProductAtt20Desc", typeof(string));
                foreach (var item in urunListesi)
                {
                    dt.Rows.Add(
                        item.ItemCode,
                        item.Itemdescription,
                        item.ColorCode,
                        item.Color,
                        item.ItemDim1Code,
                        item.Barcode,
                        item.Envanter,
                        item.MisigoWebSatis,
                        item.MisigoWebIndirimliSatis,
                        item.MisigoPazaryeriSatis,
                        item.MisigoPazaryeriIndirimliSatis,
                        item.ProductHierarchyLevel01,
                        item.ProductHierarchyLevel02,
                        item.ProductHierarchyLevel03,
                        item.ProductHierarchyLevel04,
                        item.ProductAtt01Type,
                        item.ProductAtt01Desc,
                        item.ProductAtt02Type,
                        item.ProductAtt02Desc,
                        item.ProductAtt03Type,
                        item.ProductAtt03Desc,
                        item.ProductAtt04Type,
                        item.ProductAtt04Desc,
                        item.ProductAtt05Type,
                        item.ProductAtt05Desc,
                        item.ProductAtt06Type,
                        item.ProductAtt06Desc,
                        item.ProductAtt07Type,
                        item.ProductAtt07Desc,
                        item.ProductAtt08Type,
                        item.ProductAtt08Desc,
                        item.ProductAtt09Type,
                        item.ProductAtt09Desc,
                        item.ProductAtt10Type,
                        item.ProductAtt10Desc,
                        item.ProductAtt11Type,
                        item.ProductAtt11Desc,
                        item.ProductAtt12Type,
                        item.ProductAtt12Desc,
                        item.ProductAtt13Type,
                        item.ProductAtt13Desc,
                        item.ProductAtt14Type,
                        item.ProductAtt14Desc,
                        item.ProductAtt15Type,
                        item.ProductAtt15Desc,
                        item.ProductAtt16Type,
                        item.ProductAtt16Desc,
                        item.ProductAtt17Type,
                        item.ProductAtt17Desc,
                        item.ProductAtt18Type,
                        item.ProductAtt18Desc,
                        item.ProductAtt19Type,
                        item.ProductAtt19Desc,
                        item.ProductAtt20Type,
                        item.ProductAtt20Desc
                    // ... ve diğer tüm özellikler
                    );
                }

                try
                {
                    await bulkCopy.WriteToServerAsync(dt);

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"SQL kaydetme hatası: {ex.Message}");
                    // İsteğe bağlı olarak daha ayrıntılı hata bilgilerini de yazdırabilirsiniz.
                } // Veritabanına toplu ekleme yap
            }
        }
        private async Task UpdateDownloadedItemUpdate( )
        {

            try
            {
                List<FaturaBilgisi2> faturaBilgileri = await GetFaturaBilgileriFromDatabasee2();

                foreach (var faturaBilgisi in faturaBilgileri)
                {
                    try
                    {
                        string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                        var procName = "MSGMusteriUrunListUpdate";
                        var jsonData = JsonConvert.SerializeObject(new { ProcName = procName });

                        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                        var apiUrl = $"http://{faturaBilgisi.IpAdres}/(S({sessionID}))/IntegratorService/RunProc?";

                        var response = await httpClient.PostAsync(apiUrl, content);

                        if (response.IsSuccessStatusCode)
                        {
                            string jsonResponse = await response.Content.ReadAsStringAsync();
                            var yourJsonResponseList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonResponse);

                            var urunListesi = new List<ZTMSGUrunListMisigo>();
                            foreach (var urunBilgisi in yourJsonResponseList)
                            {
                                var urunMisigo = new ZTMSGUrunListMisigo
                                {
                                    ItemCode = urunBilgisi["Ürün Kodu"]?.ToString(),
                                    Itemdescription = urunBilgisi["Ürün Adi"]?.ToString(),
                                    ColorCode = urunBilgisi["Renk Kodu"]?.ToString(),
                                    Color = urunBilgisi["ColorDescription"]?.ToString(),
                                    ItemDim1Code = urunBilgisi["Beden"]?.ToString(),
                                    Barcode = urunBilgisi["Barkod"]?.ToString(),
                                    Envanter = int.TryParse(urunBilgisi["Envanter"]?.ToString(), out int envanterValue) ? envanterValue : 0,
                                    MisigoWebSatis = urunBilgisi["Misigo Web Satış"] != null ? Convert.ToDecimal(urunBilgisi["Misigo Web Satış"]) : 0,
                                    MisigoWebIndirimliSatis = urunBilgisi["Misigo Web Minimum Satış"] != null ? Convert.ToDecimal(urunBilgisi["Misigo Web Minimum Satış"]) : 0,
                                    MisigoPazaryeriSatis = urunBilgisi["Misigo Pazaryeri Satış"] != null ? Convert.ToDecimal(urunBilgisi["Misigo Pazaryeri Satış"]) : 0,
                                    MisigoPazaryeriIndirimliSatis = urunBilgisi["Misigo Pazaryeri Minimum Satış"] != null ? Convert.ToDecimal(urunBilgisi["Misigo Pazaryeri Minimum Satış"]) : 0,
                                    ProductHierarchyLevel01 = urunBilgisi["ProductHierarchyLevel01"]?.ToString(),
                                    ProductHierarchyLevel02 = urunBilgisi["ProductHierarchyLevel02"]?.ToString(),
                                    ProductHierarchyLevel03 = urunBilgisi["ProductHierarchyLevel03"]?.ToString(),
                                    ProductHierarchyLevel04 = urunBilgisi["ProductHierarchyLevel04"]?.ToString(),
                                    ProductAtt01Type = urunBilgisi["ProductAtt01Type"]?.ToString(),
                                    ProductAtt01Desc = urunBilgisi["ProductAtt01Desc"]?.ToString(),
                                    ProductAtt02Type = urunBilgisi["ProductAtt02Type"]?.ToString(),
                                    ProductAtt02Desc = urunBilgisi["ProductAtt02Desc"]?.ToString(),
                                    ProductAtt03Type = urunBilgisi["ProductAtt03Type"]?.ToString(),
                                    ProductAtt03Desc = urunBilgisi["ProductAtt03Desc"]?.ToString(),
                                    ProductAtt04Type = urunBilgisi["ProductAtt04Type"]?.ToString(),
                                    ProductAtt04Desc = urunBilgisi["ProductAtt04Desc"]?.ToString(),
                                    ProductAtt05Type = urunBilgisi["ProductAtt05Type"]?.ToString(),
                                    ProductAtt05Desc = urunBilgisi["ProductAtt05Desc"]?.ToString(),
                                    ProductAtt06Type = urunBilgisi["ProductAtt06Type"]?.ToString(),
                                    ProductAtt06Desc = urunBilgisi["ProductAtt06Desc"]?.ToString(),
                                    ProductAtt07Type = urunBilgisi["ProductAtt07Type"]?.ToString(),
                                    ProductAtt07Desc = urunBilgisi["ProductAtt07Desc"]?.ToString(),
                                    ProductAtt08Type = urunBilgisi["ProductAtt08Type"]?.ToString(),
                                    ProductAtt08Desc = urunBilgisi["ProductAtt08Desc"]?.ToString(),
                                    ProductAtt09Type = urunBilgisi["ProductAtt09Type"]?.ToString(),
                                    ProductAtt09Desc = urunBilgisi["ProductAtt09Desc"]?.ToString(),
                                    ProductAtt10Type = urunBilgisi["ProductAtt10Type"]?.ToString(),
                                    ProductAtt10Desc = urunBilgisi["ProductAtt10Desc"]?.ToString(),
                                    ProductAtt11Type = urunBilgisi["ProductAtt11Type"]?.ToString(),
                                    ProductAtt11Desc = urunBilgisi["ProductAtt11Desc"]?.ToString(),
                                    ProductAtt12Type = urunBilgisi["ProductAtt12Type"]?.ToString(),
                                    ProductAtt12Desc = urunBilgisi["ProductAtt12Desc"]?.ToString(),
                                    ProductAtt13Type = urunBilgisi["ProductAtt13Type"]?.ToString(),
                                    ProductAtt13Desc = urunBilgisi["ProductAtt13Desc"]?.ToString(),
                                    ProductAtt14Type = urunBilgisi["ProductAtt14Type"]?.ToString(),
                                    ProductAtt14Desc = urunBilgisi["ProductAtt14Desc"]?.ToString(),
                                    ProductAtt15Type = urunBilgisi["ProductAtt15Type"]?.ToString(),
                                    ProductAtt15Desc = urunBilgisi["ProductAtt15Desc"]?.ToString(),
                                    ProductAtt16Type = urunBilgisi["ProductAtt16Type"]?.ToString(),
                                    ProductAtt16Desc = urunBilgisi["ProductAtt16Desc"]?.ToString(),
                                    ProductAtt17Type = urunBilgisi["ProductAtt17Type"]?.ToString(),
                                    ProductAtt17Desc = urunBilgisi["ProductAtt17Desc"]?.ToString(),
                                    ProductAtt18Type = urunBilgisi["ProductAtt18Type"]?.ToString(),
                                    ProductAtt18Desc = urunBilgisi["ProductAtt18Desc"]?.ToString(),
                                    ProductAtt19Type = urunBilgisi["ProductAtt19Type"]?.ToString(),
                                    ProductAtt19Desc = urunBilgisi["ProductAtt19Desc"]?.ToString(),
                                    ProductAtt20Type = urunBilgisi["ProductAtt20Type"]?.ToString(),
                                    ProductAtt20Desc = urunBilgisi["ProductAtt20Desc"]?.ToString(),
                                    // ... Diğer özellikler burada eklenmeli
                                };

                                urunListesi.Add(urunMisigo);
                            }
                            if (urunListesi.Any())
                            {
                                await DeleteExistingBarcodes(urunListesi);

                            }
                            if (urunListesi.Any())
                            {
                                await BulkInsertProducts(urunListesi);
                                labelStatus.Text = "Site Aktarım Tamamlandı";
                            }
                        }
                        else
                        {
                            Console.WriteLine("Hata: Yanıt başarısız.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Hata: {ex.ToString()}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.ToString()}");
            }

        }
        private async Task UpdateDownloadedUrlAsync(string connectionString, string url)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("MSG_MisigoResimIndirListeGuncelle", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Depolama prosedürü için gerekli parametreleri ekleyin
                        cmd.Parameters.AddWithValue("@Url", url);

                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // Hata yönetimi burada yapılabilir
                // Örneğin: MessageBox.Show("URL güncellenirken bir hata oluştu: " + ex.Message);
            }
        }
        private async Task DownloadImagesAsyncMisigo( )
        {
            try
            {
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                string spName = "MSG_MisigoResimIndirListe";

                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }

                int count = 1;
                string lastBarcode = string.Empty;

                using (HttpClient client = new HttpClient())
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        try
                        {
                            string barcode = row["Barcode"].ToString();
                            string url = row["Url"].ToString();
                            string folderName = row["Marka"].ToString();
                            string folderPath = Path.Combine("C:\\Resimler", folderName);

                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            // Check if this is a new barcode or a repeat
                            if (barcode != lastBarcode)
                            {
                                // This is a new barcode, so reset the count
                                count = 1;
                                lastBarcode = barcode;
                            }

                            string filename = count > 1 ? $"{barcode}_{count}.jpg" : $"{barcode}.jpg";
                            string path = Path.Combine(folderPath, filename);

                            byte[] imageBytes = await client.GetByteArrayAsync(url);

                            using (FileStream sourceStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
                            {
                                await sourceStream.WriteAsync(imageBytes, 0, imageBytes.Length);
                            }
                            await UpdateDownloadedUrlAsync(connectionString, url);

                            // Increment the count for the next loop
                            count++;
                        }
                        catch (Exception ex)
                        {
                            // Hata mesajını görmezden gel, sadece kaydet ve işlemi devam ettir
                            // Bu şekilde hata alan verileri atlatabilirsiniz.
                            // Burada hata işlenmiyor ve işlem devam ediyor.
                            //MessageBox.Show("Uygulama genelinde bir hata oluştu: " + ex.Message);
                            Console.WriteLine($"Hata: Yanıt başarısız." + ex.Message);
                        }
                    }
                }

                MessageBox.Show("Tüm İşlemler Tamamlandı.");
            }
            catch (Exception ex)
            {
                // Top seviyedeki hata işleme, uygulamanın çökmemesini sağlar.
                MessageBox.Show("Uygulama genelinde bir hata oluştu: " + ex.Message);
            }
        }
        private async void misigoResimleriÇekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await DownloadImagesAsyncMisigo();

        }

        private void misigoFirmaBilgileriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MisigoFirmaBilgileri frm = new MisigoFirmaBilgileri();
            frm.Show();
        }

        private async void misigoStokEşitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await StokGuncelle();

        }

        private async void misigoÜrünleriGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // await UpdateDownloadedItem2();

            await UpdateDownloadedItemUpdate();
            await ResimEkle();
            await FiyatDuzenle();
            await StokGuncelle();
            await DownloadImagesAsyncMisigo();
            labelStatus.Text = "Güncelleme İşlemi Gerçekleşti";
        }

        private void misigoKategoriEşleştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MisigoKategoriEslestir frm = new MisigoKategoriEslestir();
            frm.Show();
        }

        private async void misigoEşitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ResimEkle();
            labelStatus.Text = "ResimEkle Bitti";
            //await UpdateDownloadedItemUpdate();
            await FiyatDuzenle();
            labelStatus.Text = "FiyatDuzenle Bitti";
            await StokGuncelle();
            labelStatus.Text = "StokGuncelle Bitti";
            await ItemsEkle();
            labelStatus.Text = "ItemsEkle Bitti";
            await DownloadImagesAsyncMisigo();
            labelStatus.Text = "DownloadImagesAsyncMisigo Bitti";
            MessageBox.Show("Ürün Çekme İşlemi Gerçekleşti");

        }

        private async void misigoÜrünleriAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await ItemsEkle();
            labelStatus.Text = "ItemsEkle Bitti";
        }

        private void misigoÖzellikEşleştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MisigoOzellikEslestir frm = new MisigoOzellikEslestir();
            frm.Show();
        }

        private void kullanıcılarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKullanicilar frm = new frmKullanicilar();
            frm.Show();
        }

        private void magazalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMagazalar frm = new frmMagazalar();
            frm.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //List<WebSiparis> uyeAdresListe = SiparisServiceMethods.SelectUyeAdres();
            //List<WebSiparis> webSiparisListe = SiparisServiceMethods.SelectSiparis();
            List<WebSiparis> uyeListe = SiparisServiceMethods.SelectSiparis();
            List<WebSiparisUrun> uyeAdresListe = SiparisServiceMethods.SelectSiparisDetay();

            //List<UyeAdres> uyeAdresListe = UyeServiceMethods.SelectUyeAdres();
        }
    }
}
