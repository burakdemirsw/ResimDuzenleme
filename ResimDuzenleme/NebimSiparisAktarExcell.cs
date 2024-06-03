using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace ResimDuzenleme
{
    public partial class NebimSiparisAktarExcell : Form
    {

        string ipAdresi = Properties.Settings.Default.txtEntegrator;
        public NebimSiparisAktarExcell( )
        {
            InitializeComponent();
        }
        public DataTable ExcelToDataTable(string filePath)
        {
            using (var pck = new OfficeOpenXml.ExcelPackage())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets["Sayfa1"]; // first worksheet
                DataTable tbl = new DataTable();
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                {
                    tbl.Columns.Add(firstRowCell.Text);
                }
                for (var rowNum = 2; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    DataRow row = tbl.Rows.Add();
                    foreach (var cell in wsRow)
                    {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                }
                return tbl;
            }
        }
        public void SaveToDatabase(DataTable dt)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Write this data to the SQL Server using SqlBulkCopy.
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
                {
                    bulkCopy.DestinationTableName = "ZTMSGNebimSiparisAktarma";
                    bulkCopy.WriteToServer(dt);
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls", Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DataTable dt = ExcelToDataTable(ofd.FileName);
                        // dt is now the DataTable that holds the Excel data.
                        // You can use it as the DataSource for a DataGridView or manipulate it as you like.
                        // For example, to bind it to a DataGridView:
                        dataGridView1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while reading the Excel file: " + ex.Message);
                    }
                }
            }

        }

        private void btnSiparisAktar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveToDatabase((DataTable)dataGridView1.DataSource); // assuming dataGridView1.DataSource is your DataTable
                MessageBox.Show("Data successfully saved to the database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving the data to the database: " + ex.Message);
            }
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

        private void NebimSiparisAktarExcell_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Dosyaları | *.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 'excelFile.xlsx' yerine projenizdeki dosyanın adını yazın
                    string sourcePath = Path.Combine(Application.StartupPath, "Trendyol.xlsx");

                    // Dosyayı kullanıcının belirlediği konuma kopyalar
                    File.Copy(sourcePath, sfd.FileName, true);

                    MessageBox.Show("Dosya başarıyla indirildi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Dosya indirme hatası: {ex.Message}");
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

        private async void button6_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    ImportBarkodToSqlFromExcel(filePath);
                }
            }

            labelStatus.Text = "Müşteri Aktarımı Başladı...";

            string sessionID = await ConnectIntegrator();

            List<ZTMSGTicUyeAdresR> items = await VeritabanindanMusteriGetirR();

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
                    //Console.WriteLine(ex.ToString());
                    labelStatus.Text = $"Hata: {ex.Message}";
                }
            }

            // İşlem bitiş mesajı
            labelStatus.Text = "Müşteri Aktarımı tamamlandı.";


            labelStatus.Text = "Sipariş Aktarımı başladı...";

            string sessionID2 = await ConnectIntegrator();

            List<ZtNebimFaturaR> faturaRs = await VeritabanindanMusteriGetirFaturaR();

            // İşlem sırasındaki mesaj
            labelStatus.Text = $"Veritabanından {faturaRs.Count} adet veri çekildi. Şimdi POST işlemi başlatılıyor...";

            postCount = 0;
            foreach (var item in faturaRs)
            {
                string json = JsonConvert.SerializeObject(item);
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync($"http://{ipAdresi}/(S({sessionID2}))/IntegratorService/post?", content);
                        var result = await response.Content.ReadAsStringAsync();
                        postCount++;
                        labelStatus.Text = $"POST işlemi {postCount}/{faturaRs.Count} veri için tamamlandı...";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    labelStatus.Text = $"Hata: {ex.Message}";
                }
            }

            // İşlem bitiş mesajı
            labelStatus.Text = "Sipariş Aktarımı Bitti tamamlandı.";
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "Müşteri Aktarımı Başladı...";

            string sessionID = await ConnectIntegrator();

            List<ZTMSGTicUyeAdresR> items = await VeritabanindanMusteriGetirR();

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
                    //Console.WriteLine(ex.ToString());
                    labelStatus.Text = $"Hata: {ex.Message}";
                }
            }

            // İşlem bitiş mesajı
            labelStatus.Text = "Müşteri Aktarımı tamamlandı.";

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


        private async void button9_Click(object sender, EventArgs e)
        {

            try
            {
                labelStatus.Text = "Sipariş Aktarımı başladı...";
                int postCount = 0;
                string sessionID2 = await ConnectIntegrator();

                List<ZtNebimFaturaR> faturaRs = await VeritabanindanMusteriGetirFaturaR();

                // İşlem sırasındaki mesaj
                labelStatus.Text = $"Veritabanından {faturaRs.Count} adet veri çekildi. Şimdi POST işlemi başlatılıyor...";

                postCount = 0;
                foreach (var item in faturaRs)
                {
                    string json = JsonConvert.SerializeObject(item);
                    try
                    {
                        using (var httpClient = new HttpClient())
                        {
                            var content = new StringContent(json, Encoding.UTF8, "application/json");
                            var response = await httpClient.PostAsync($"http://{ipAdresi}/(S({sessionID2}))/IntegratorService/post?", content);
                            var result = await response.Content.ReadAsStringAsync();
                            postCount++;
                            labelStatus.Text = $"POST işlemi {postCount}/{faturaRs.Count} veri için tamamlandı...";
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        labelStatus.Text = $"Hata: {ex.Message}";
                    }
                }

                // İşlem bitiş mesajı
                labelStatus.Text = "Sipariş Aktarımı Bitti tamamlandı.";
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Alındı: " + ex.Message);
            }
        }
    }
}
