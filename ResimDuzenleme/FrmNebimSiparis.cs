using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using System.Threading;

using ResimDuzenleme.SiparisServis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ResimDuzenleme
{
    public partial class FrmNebimSiparis : Form
    {
        public FrmNebimSiparis( )
        {
            InitializeComponent();
        }
        string ipAdresi = Properties.Settings.Default.txtEntegrator;
        private HttpClient httpClient = new HttpClient();
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


        private async Task<List<ZtNebimFaturaROnlineReturn>> VeritabanindanMusteriGetirFaturaROnlineToplu(string Firma)
        {

            try
            {
                List<ZtNebimFaturaROnlineReturn> musteriler = new List<ZtNebimFaturaROnlineReturn>();
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";


                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    await conn.OpenAsync();
                    SqlCommand command = new SqlCommand("MSG_GetOrderForInvoiceToplu_REOnlineReturnToplu", conn);
                    command.CommandTimeout = 3000;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Firma", Firma);

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        ZtNebimFaturaROnlineReturn musteri = new ZtNebimFaturaROnlineReturn();
                        musteri.ModelType = Convert.ToInt32(reader["ModelType"]);
                        musteri.Isreturn = bool.Parse(reader["Isreturn"].ToString());
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
                        musteri.Series = reader["Series"].ToString();
                        musteri.SeriesNumber = reader["SeriesNumber"].ToString();

                        if (reader["Invoicedate"] != DBNull.Value)
                        {
                            musteri.Invoicedate = Convert.ToDateTime(reader["Invoicedate"]); // DateTime'a çevirildi
                        }


                        musteri.Description = reader["Description"].ToString();
                        musteri.InternalDescription = reader["InternalDescription"].ToString();

                        //   musteri.CustomerTypeCode = Convert.ToInt32(reader["CustomerTypeCode"]);

                        string LinesJson = reader["Lines"].ToString();
                        JArray LinesArray = JArray.Parse(LinesJson);
                        musteri.Lines = LinesArray.ToObject<List<InvoiceLinesReturn>>();

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
                    command.CommandTimeout = 3000;
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
        private void ShowHtmlFromBase64(string base64String)
        {
            // Base64 string'ini byte dizisine çevir ve string'e dönüştür
            byte[] htmlBytes = Convert.FromBase64String(base64String);
            string htmlContent = Encoding.UTF8.GetString(htmlBytes);

            // HTML içeriğini WebBrowser kontrolünde göster

        }


        private async Task<int> GetOrderForInvoiceToplamAsync(string Firma)
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
                using (SqlCommand cmd = new SqlCommand("MSG_GetOrderForInvoiceToplu_REOnlineToplam", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Eğer SP parametre alıyorsa, burada parametreleri ekleyin.
                    // cmd.Parameters.AddWithValue("@ParamName", value);
                    cmd.CommandTimeout = 3000;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Firma", Firma);

                    var returnValue = await cmd.ExecuteScalarAsync();
                    return Convert.ToInt32(returnValue);
                }
            }
        }



        private async Task<int> GetOrderForInvoiceReturnToplamAsync( )
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
                using (SqlCommand cmd = new SqlCommand("MSG_GetOrderForInvoiceToplu_REOnlineReturnToplam", conn))
                {
                    cmd.CommandTimeout = 3000;
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Eğer SP parametre alıyorsa, burada parametreleri ekleyin.
                    // cmd.Parameters.AddWithValue("@ParamName", value);

                    var returnValue = await cmd.ExecuteScalarAsync();
                    return Convert.ToInt32(returnValue);
                }
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "Fatura Aktarımı Başladı...";
            List<FaturaBilgisi> faturaBilgileri = await GetFaturaBilgileriFromDatabasee();
            try
            {
                foreach (var faturaBilgisi in faturaBilgileri)
                {
                    //string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                    //List<ZtNebimFaturaROnline> items = await VeritabanindanMusteriGetirFaturaROnline(faturaBilgisi.Firma);

                    int totalRepeatCount = 30; // Toplam tekrar sayısı

                    //selamm

                    for (int repeat = 0; repeat < totalRepeatCount; repeat++)
                    {
                        string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                        List<ZtNebimFaturaROnline> items = await VeritabanindanMusteriGetirFaturaROnline(faturaBilgisi.Firma);

                        //var currentBatch = items.Skip(repeat * batchSize).Take(batchSize).ToList();
                        labelStatus.Text = $"Veritabanından {items.Count} adet veri çekildi. Şimdi POST işlemi başlatılıyor...";
                        int postCount = 0;
                        try
                        {
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
                                        postCount++;
                                        //var result = await response.Content.ReadAsStringAsync();
                                        labelStatus.Text = $"POST işlemi {postCount}/{items.Count} veri için tamamlandı...";


                                        using (SqlConnection conn = new SqlConnection(connectionString))
                                        {
                                            string query = "INSERT INTO ZTMSGTicSiparisKontrol (FaturaNo,Request,Cevap) VALUES (@FaturaNo,@Request,@Cevap)";
                                            using (SqlCommand cmd = new SqlCommand(query, conn))
                                            {
                                                var result = await response.Content.ReadAsStringAsync();
                                                dynamic jsonResponse = JsonConvert.DeserializeObject(result);

                                                cmd.Parameters.AddWithValue("@FaturaNo", item.CustomerCode);
                                                cmd.Parameters.AddWithValue("@Request", json);
                                                cmd.Parameters.AddWithValue("@Cevap", "Aktarım Başarılı");
                                                //cmd.Parameters.Add(new SqlParameter("@Request", SqlDbType.NVarChar, -1) { Value = json });
                                                //cmd.Parameters.Add(new SqlParameter("@Cevap", SqlDbType.NVarChar, -1) { Value = jsonResponse });

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
                                        postCount++;
                                        //var result = await response.Content.ReadAsStringAsync();
                                        labelStatus.Text = $"POST işlemi {postCount}/{items.Count} veri için tamamlandı...";

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

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Hata Alındı Tekrar Faturalaştır Tuşuna basınız.");

                        }


                        try
                        {
                            int miktar = await GetOrderForInvoiceToplamAsync(faturaBilgisi.Firma);
                            if (miktar == 0)
                            {
                                labelStatus.Text = "İşlem tamamlandı, daha fazla fatura bulunamadı.";
                                break; // Döngüyü sonlandır
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Hata Alındı Tekrar Faturalaştır Tuşuna basınız.");

                        }


                        // Eğer miktar 0'dan büyükse, işlemlere devam edin
                        //     labelStatus.Text = $"İşlem devam ediyor, kalan miktar: {miktar}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata Alındı Tekrar Faturalaştır Tuşuna basınız.");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<WebSiparis> uyeListe = SiparisServiceMethods.SelectSiparisKoctas();
            List<WebSiparisUrun> uyeAdresListe = SiparisServiceMethods.SelectSiparisDetay();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "Fatura Aktarımı Başladı...";
            List<FaturaBilgisi> faturaBilgileri = await GetFaturaBilgileriFromDatabasee();

            foreach (var faturaBilgisi in faturaBilgileri)
            {
                //string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                //List<ZtNebimFaturaROnline> items = await VeritabanindanMusteriGetirFaturaROnline(faturaBilgisi.Firma);

                int totalRepeatCount = 5; // Toplam tekrar sayısı

                for (int repeat = 0; repeat < totalRepeatCount; repeat++)
                {
                    string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                    List<ZtNebimFaturaROnlineReturn> items = await VeritabanindanMusteriGetirFaturaROnlineToplu(faturaBilgisi.Firma);

                    //var currentBatch = items.Skip(repeat * batchSize).Take(batchSize).ToList();
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
                                postCount++;
                                //var result = await response.Content.ReadAsStringAsync();
                                labelStatus.Text = $"POST işlemi {postCount}/{items.Count} veri için tamamlandı...";


                                using (SqlConnection conn = new SqlConnection(connectionString))
                                {
                                    string query = "INSERT INTO ZTMSGTicSiparisKontrol (FaturaNo,Request,Cevap) VALUES (@FaturaNo,@Request,@Cevap)";
                                    using (SqlCommand cmd = new SqlCommand(query, conn))
                                    {
                                        var result = await response.Content.ReadAsStringAsync();
                                        dynamic jsonResponse = JsonConvert.DeserializeObject(result);

                                        cmd.Parameters.AddWithValue("@FaturaNo", item.CustomerCode);
                                        cmd.Parameters.AddWithValue("@Request", json);
                                        cmd.Parameters.AddWithValue("@Cevap", "Aktarım Başarılı");
                                        //cmd.Parameters.Add(new SqlParameter("@Request", SqlDbType.NVarChar, -1) { Value = json });
                                        //cmd.Parameters.Add(new SqlParameter("@Cevap", SqlDbType.NVarChar, -1) { Value = jsonResponse });

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
                                postCount++;
                                //var result = await response.Content.ReadAsStringAsync();
                                labelStatus.Text = $"POST işlemi {postCount}/{items.Count} veri için tamamlandı...";

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



                    int miktar = await GetOrderForInvoiceReturnToplamAsync();
                    if (miktar == 0)
                    {
                        labelStatus.Text = "İşlem tamamlandı, daha fazla fatura bulunamadı.";
                        break; // Döngüyü sonlandır
                    }

                    // Eğer miktar 0'dan büyükse, işlemlere devam edin
                    //     labelStatus.Text = $"İşlem devam ediyor, kalan miktar: {miktar}";
                }
            }
        }
    }
}
