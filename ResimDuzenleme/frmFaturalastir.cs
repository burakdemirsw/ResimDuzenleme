using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
//using PdfiumViewer;

using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace ResimDuzenleme
{
    public partial class frmFaturalastir : Form
    {
        public frmFaturalastir( )
        {
            InitializeComponent();
        }

        string ipAdresi = Properties.Settings.Default.txtEntegrator;
        private void ExecuteStoredProc(string barcode)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            string query = @"INSERT INTO ZTMSGKargoTakip (KargoNo)
                   select  @kargono where @kargono not in (select Kargono from ZTMSGKargoTakip)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    cmd.Parameters.AddWithValue("@kargono", textBox1.Text);


                    cmd.ExecuteNonQuery();

                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM ZTMSGKargoTakip WHERE KargoNo = @KargoNo ORDER BY KargoNo", connection))
                {
                    command.Parameters.AddWithValue("@kargono", textBox1.Text);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        DataTable tempTable = (DataTable)dataGridView1.DataSource;

                        if (tempTable != null)
                        {
                            // Eğer önceki veriler varsa, yeni verileri ekleyin
                            foreach (DataRow row in dataTable.Rows)
                            {
                                tempTable.ImportRow(row);
                                dataTable.DefaultView.Sort = "CreatedDate DESC"; // Sıralama sütunu ve sıralama yönüne göre ayarlayın
                                dataTable = dataTable.DefaultView.ToTable();
                            }
                            dataTable.DefaultView.Sort = "CreatedDate DESC"; // Sıralama sütunu ve sıralama yönüne göre ayarlayın
                            dataTable = dataTable.DefaultView.ToTable();
                            dataGridView1.DataSource = tempTable;
                        }
                        else
                        {
                            dataGridView1.DataSource = dataTable;
                        }
                        dataTable.DefaultView.Sort = "CreatedDate DESC"; // Sıralama sütunu ve sıralama yönüne göre ayarlayın
                        dataTable = dataTable.DefaultView.ToTable();
                    }
                }

            }
            textBox1.Clear(); // txtBarcode temizlenir
            textBox1.Focus();

        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                string barcode = textBox1.Text;
                ExecuteStoredProc(barcode);
            }
        }

        private void txtFaturaNo_MouseClick(object sender, MouseEventArgs e)
        {
            txtFaturaNo.Text = "";
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
        private async Task<List<ZtNebimFaturaROnline>> VeritabanindanMusteriGetirFaturaR(string Firma)
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

        private async Task<List<FaturaBilgisi>> GetFaturaBilgileriPDF( )
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



        private HttpClient httpClient = new HttpClient();


        private async void btnFaturalastir_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "Fatura Aktarımı Başladı...";
            List<FaturaBilgisi> faturaBilgileri = await GetFaturaBilgileriFromDatabase();

            foreach (var faturaBilgisi in faturaBilgileri)
            {
                string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                List<ZtNebimFaturaROnline> items = await VeritabanindanMusteriGetirFaturaR(faturaBilgisi.Firma);

                labelStatus.Text = $"Veritabanından {items.Count} adet veri çekildi. Şimdi POST işlemi başlatılıyor...";
                int postCount = 0;
                var tasks = items.Select(async item =>
                {
                    string json = JsonConvert.SerializeObject(item);
                    try
                    {
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        var response = await httpClient.PostAsync($"http://{faturaBilgisi.IpAdres}/(S({sessionID}))/IntegratorService/post?", content);

                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsStringAsync();
                            labelStatus.Text = $"POST işlemi {postCount}/{items.Count} veri için tamamlandı...";
                        }
                        else
                        {
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
        }

        private static readonly HttpClient httpClientt = new HttpClient();

        public async Task<string> Authenticate(string username, string password)
        {
            var authUrl = "https://connector.doganedonusum.com/AuthenticationWS?wsdl"; // Doğan E-Dönüşüm'ün auth URL'si

            // Kimlik doğrulama için gerekli veriler
            var authData = new
            {
                Username = "misigostore",
                Password = "Ehil1524"
            };

            // JSON'a dönüştür
            string json = JsonConvert.SerializeObject(authData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // HTTP POST isteği gönder
            var response = await httpClientt.PostAsync(authUrl, content);

            if (response.IsSuccessStatusCode)
            {
                // Başarılı yanıtı işle
                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent; // Session ID veya başka bir kimlik doğrulama token'ı burada dönebilir
            }
            else
            {
                // Hata durumunu işle
                return null;
            }
        }
        public async Task<string> ReadInvoiceFromArchive(string sessionID, string invoiceID)
        {
            var requestHeader = new
            {
                SESSION_ID = sessionID,
                APPLICATION_NAME = "misigostore", // Uygulamanızın adını buraya girin
                COMPRESSED = "N"
            };

            var request = new
            {
                REQUEST_HEADER = requestHeader,
                INVOICE_ID = invoiceID,
                PORTAL_DIRECTION = "OUT", // Fatura alıcıya gönderildiyse "OUT", gönderen ise "IN" kullanılır
                PROFILE = "PDF" // İstediğiniz fatura formatı: PDF, HTML, XML
            };

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("E-Arşiv Fatura Okuma servisinin URL'si", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return responseContent; // Fatura içeriği burada döner
            }
            else
            {
                return null; // Hata durumu
            }
        }
        private void ShowPdfFromBase64(string base64String)
        {
            // Base64 string'ini byte dizisine çevir
            byte[] pdfBytes = Convert.FromBase64String(base64String);

            // Geçici bir dosya yolu oluştur
            string tempFilePath = Path.GetTempFileName() + ".pdf";

            // Byte dizisini dosyaya yaz
            File.WriteAllBytes(tempFilePath, pdfBytes);

            // Sistemde varsayılan PDF görüntüleyici ile dosyayı aç
            Process.Start(tempFilePath);
        }
        private void BtnFaturaGoster_Click(object sender, EventArgs e)
        {

        }

        private void txtFaturaNo_Enter(object sender, EventArgs e)
        {

        }

        private void frmFaturalastir_Load(object sender, EventArgs e)
        {

        }
    }
}
