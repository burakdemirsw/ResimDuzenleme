using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Newtonsoft.Json;







namespace ResimDuzenleme
{
    public partial class TrendyolYurtDisiSiparis : Form
    {
        public TrendyolYurtDisiSiparis()
        {
            InitializeComponent();
        }
        string ipAdresi = Properties.Settings.Default.txtEntegrator;
        private void ImportBarkodToSqlFromExcel(string filePath)
        {
            IWorkbook workbook;

            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(stream);  // XSSF for .xlsx, HSSF for .xls
            }

            ISheet sheet = workbook.GetSheetAt(0);  // 0-indexed (get the first sheet)

         

            for (int i = 1; i <= sheet.LastRowNum; i++)  // 0-indexed (skip the first row)
            {

                try
                {
                    IRow row = sheet.GetRow(i);
                    string cellValue;
                    string TakipNo = row.GetCell(0)?.ToString();
                    cellValue = row.GetCell(1)?.ToString().Replace('.', ',');
                    decimal ToptanSatisFiyati = decimal.TryParse(cellValue, out decimal toptanSatisFiyati) ? toptanSatisFiyati : 0.00m;
                    string Barkod = row.GetCell(2)?.ToString();
                    string UrunAdi = row.GetCell(3)?.ToString();
                    int Adet = int.TryParse(row.GetCell(4)?.ToString(), out int adet) ? adet : 0;
                    string MusteriKodu = txtMusteriKodu.Text;
                    string CurrencyCode = textBox1.Text;

                    InsertDataToSql(TakipNo, ToptanSatisFiyati, Barkod, UrunAdi, Adet, MusteriKodu, CurrencyCode);

                 
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


        private void DeleteDataToSql()
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            string deleteQuery = @"DELETE FROM ZTMSGTrendyolSiparisYD ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                {
                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        private void InsertDataToSql(string TakipNo, decimal ToptanSatisFiyati, string Barkod, string UrunAdi, int Adet,string MusteriKodu,string CurrencyCode)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            string query = @"INSERT INTO ZTMSGTrendyolSiparisYD (TakipNo, ToptanSatisFiyati, Barkod, UrunAdi, Adet, MusteriKodu, CurrencyCode)
                   Values( @TakipNo, @ToptanSatisFiyati, @Barkod, @UrunAdi, @Adet, @MusteriKodu, @CurrencyCode)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@TakipNo", TakipNo);
                    cmd.Parameters.AddWithValue("@ToptanSatisFiyati", ToptanSatisFiyati);
                    cmd.Parameters.AddWithValue("@Barkod", Barkod);
                    cmd.Parameters.AddWithValue("@UrunAdi", UrunAdi);
                    cmd.Parameters.AddWithValue("@Adet", Adet);
                    cmd.Parameters.AddWithValue("@MusteriKodu", MusteriKodu);
                    cmd.Parameters.AddWithValue("@CurrencyCode", CurrencyCode);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private async Task<List<ZtNebimFaturaRYD>> VeritabanindanMusteriGetirFaturaR()
        {

            try
            {
                List<ZtNebimFaturaRYD> musteriler = new List<ZtNebimFaturaRYD>();
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    SqlCommand command = new SqlCommand("MSG_GetOrderForInvoiceToplu_REToplu", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        ZtNebimFaturaRYD musteri = new ZtNebimFaturaRYD();
                        musteri.ModelType = Convert.ToInt32(reader["ModelType"]);
                        musteri.CustomerCode = reader["CustomerCode"].ToString();
                        musteri.OfficeCode = reader["OfficeCode"].ToString();
                        musteri.StoreCode = reader["StoreCode"].ToString();
                        musteri.WarehouseCode = reader["WarehouseCode"].ToString();
                        musteri.DocCurrencyCode = reader["DocCurrencyCode"].ToString();
                        musteri.DeliveryCompanyCode = reader["DeliveryCompanyCode"].ToString(); // Direk string olarak atandı
                        musteri.BillingPostalAddressID = reader["BillingPostalAddressID"].ToString(); // Direk string olarak atandı
                        musteri.ShippingPostalAddressID = reader["ShippingPostalAddressID"].ToString(); // Direk string olarak atandı
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
                        musteri.Lines = LinesArray.ToObject<List<InvoiceLinesYD>>();

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

        private async Task<string> ConnectIntegrator()
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
        private async void button1_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    DeleteDataToSql();
                    ImportBarkodToSqlFromExcel(filePath);
                }
            }

        
            string sessionID = await ConnectIntegrator();

            try
            {
                labelStatus.Text = "Sipariş Aktarımı başladı...";
                int postCount = 0;
                string sessionID2 = await ConnectIntegrator();

                List<ZtNebimFaturaRYD> faturaRs = await VeritabanindanMusteriGetirFaturaR();

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

        private void TrendyolYurtDisiSiparis_Load(object sender, EventArgs e)
        {

        }
    }
}
