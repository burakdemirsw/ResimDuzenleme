using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting; // Yazdırma ve önizleme için
using DevExpress.XtraReports.UserDesigner; // Rapor tasarımcısı için


namespace ResimDuzenleme
{
    public partial class GiderPusulasi : DevExpress.XtraEditors.XtraForm
    {
        public GiderPusulasi()
        {
            InitializeComponent();
        }

        private void LoadYetkiData()
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT OrderCancelReasonCode, OrderCancelReasonDescription FROM OrderCancelReason('TR')  WHERE OrderCancelReasonCode <> SPACE(0) and IsBlocked = 0";
                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBox1.DisplayMember = "OrderCancelReasonDescription";
                    comboBox1.ValueMember = "OrderCancelReasonCode";
                    comboBox1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }
        private void ExecuteStoredProcedureUpdate(string invoiceNumber)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storecode = Properties.Settings.Default.StoreCode;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("[dbo].[MSG_InvoiceReturnItemlistCount_Update]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parametreleri ekleyin
                    command.Parameters.AddWithValue("@Invoicenumber", invoiceNumber);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery(); // Stored Procedure'ü çalıştır
                    }
                    catch (SqlException ex)
                    {
                        // Hata yönetimi
                        MessageBox.Show("Bir veritabanı hatası oluştu: " + ex.Message);
                    }
                }
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
        Encoding encoding = Encoding.UTF8;

   //     string pngOutputPath;
        private FaturaGorsel faturaGorselForm = new FaturaGorsel();
        string ipAdresi = Properties.Settings.Default.txtEntegrator;
        private HttpClient httpClient = new HttpClient();
        private async Task<List<FaturaBilgisi>> GetFaturaBilgileriFromDatabasee()
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
        private async void btnkaydet_Click(object sender, EventArgs e)
        {
            List<int> selectedRows = gridView1.GetSelectedRows().ToList();

            foreach (int rowHandle in selectedRows)
            {
                if (!gridView1.IsGroupRow(rowHandle))
                {
                    // Sütun değerlerini al
                    string InvoiceLineID = gridView1.GetRowCellValue(rowHandle, "InvoiceLineID").ToString();
                    string invoiceNumber = gridView1.GetRowCellValue(rowHandle, "InvoiceNumber").ToString();
                    string currAccCode = gridView1.GetRowCellValue(rowHandle, "CurrAccCode").ToString();
                    string barcode = gridView1.GetRowCellValue(rowHandle, "Barcode").ToString();
                    string qty1 = gridView1.GetRowCellValue(rowHandle, "Qty1").ToString();
                    string ReturnReasonCode = comboBox1.SelectedValue?.ToString();
                    // Stored Procedure'ü her bir satır için çalıştır
                    ExecuteStoredProcedure(InvoiceLineID, invoiceNumber, currAccCode, barcode, qty1, ReturnReasonCode);
                }
            }




            DialogResult result2 = MessageBox.Show("Fatura Toplandı. İade yapılacak mı?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result2 == DialogResult.Yes)
            {
                // Tüm satırlar için işlem yapmak yerine yalnızca bir kez işlem yap
                if (gridView1.DataRowCount > 0)
                {
                    // Yalnızca bir kez stored procedure çağır
                    string orderNumber = gridView1.GetRowCellValue(0, "InvoiceNumber").ToString();
                    ExecuteStoredProcedureUpdate(orderNumber);
                }

                labelStatus.Text = "Fatura Aktarımı Başladı...";
                List<FaturaBilgisi> faturaBilgileri = await GetFaturaBilgileriFromDatabasee();

                foreach (var faturaBilgisi in faturaBilgileri)
                {
                    string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                    string FaturaNo = textBox1.Text;
                    string barcode = Properties.Settings.Default.txtBarkodTipi;
                    List<ZtNebimFaturaROnlineReturn> items = await VeritabanindanMusteriGetirFaturaROnline(FaturaNo);

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

                                //var responseContent = await response.Content.ReadAsStringAsync();
                                //// Yanıt içeriğindeki InvoiceHeaderID'yi çıkarmak için uygun bir yöntem kullanın
                                //// Örnek olarak, JSON'dan çıkarım yapıldığını varsayıyoruz
                                //var invoiceData = JsonConvert.DeserializeObject<dynamic>(responseContent);
                                //string invoiceID = invoiceData.InvoiceHeaderID;

                                //// InvoiceID ile ilgili işlemleri başlat
                                //var filePath = await ReadFromArchive_XML(invoiceID);
                                //string xsltContent = File.ReadAllText("general.xslt", Encoding.UTF8);
                                //string xmlContent = File.ReadAllText(filePath, Encoding.UTF8);
                                //string htmlContent = TransformXmlToHtml(xmlContent, xsltContent);
                                //ShowInvoice(htmlContent);
                                var responseContent = await response.Content.ReadAsStringAsync();
                                var invoiceData = JsonConvert.DeserializeObject<dynamic>(responseContent);
                                dynamic jsonResponse2 = JsonConvert.DeserializeObject(responseContent);

                                // Yanıttan HeaderID değerini al
                                string headerID = jsonResponse2.HeaderID;

                               // string queryName = "OFInvoiceR"; // Bu örnekte sabit bir değer kullanılmıştır

                                // Veritabanı bağlantısı ve sorguyu hazırla
                                using (SqlConnection conn = new SqlConnection(connectionString))
                                {
                                    conn.Open();
                                    string query = @"
            SELECT 
            [QueryName] = RTRIM(LTRIM([bsQuery].[QueryName])),
            [KeyCodes] = RTRIM(LTRIM([bsQuery].[KeyCodes])),
            [QueryText] = [bsQuery].[QueryText]
            FROM [bsQuery] WITH(NOLOCK)
            WHERE 
            ([bsQuery].[QueryName] = @QueryName)
        ";
                                    using (SqlCommand bsCmd = new SqlCommand(query, conn))
                                    {
                                        // QueryName parametresini belirle
                                        bsCmd.Parameters.AddWithValue("@QueryName", "OFInvoiceR");

                                        string queryText = "";
                                        using (SqlDataReader reader = bsCmd.ExecuteReader())
                                        {
                                            // bsQuery sorgusu sonucunu oku
                                            if (reader.Read())
                                            {
                                                queryText = reader["QueryText"].ToString();
                                            }
                                        }

                                        // {LangCode} yer tutucularını 'TR' ile değiştir
                                        queryText = queryText.Replace("{LangCode}", "'TR'");
                                        queryText += " WHERE HeaderID = @p0"; // WHERE koşulunu sorgunun sonuna ekle

                                        //queryText = queryText.Replace("'", "''");
                                        // Dinamik olarak oluşturulan sorguyu çalıştır
                                        //     string storeCode = Properties.Settings.Default.StoreCode;
                                        IadeListTicimax report = new IadeListTicimax();

                                        // Rapor için veri kaynağını yapılandır
                                        report.ConfigureDataSource(headerID);

                                        // Raporu göstermek için ReportPrintTool kullan
                                        DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(report);

                                        // Raporu önizleme olarak göster
                                        printTool.ShowPreview();
                                        //Raporu oluştur
                                        // Rapor örneğini oluştur



                                        //IadeListTicimax report = new IadeListTicimax();

                                        //// Veri kaynağını yapılandır (bu metot sınıfınızın içinde tanımlı olmalıdır)
                                        //report.ConfigureDataSource(headerID);

                                        //// Rapor önizleme aracını oluştur
                                        //ReportPrintTool printTool = new ReportPrintTool(report);

                                        //// Önizleme formunu al
                                        //PrintPreviewFormEx previewForm = printTool.PreviewForm as PrintPreviewFormEx;

                                        //// Özel butonlarınızı önizleme formuna ekleyin
                                        //SimpleButton editButton = new SimpleButton();
                                        //editButton.Text = "Düzenle";
                                        //editButton.Click += (sender, e) =>
                                        //{
                                        //    // Rapor tasarımcısını aç
                                        //    XRDesignRibbonForm designForm = new XRDesignRibbonForm();
                                        //    designForm.OpenReport(report);
                                        //    designForm.ShowDialog();
                                        //};

                                        //// Önizleme formunda düzenle butonunu göster
                                        //previewForm.ribbonControl.Items.Add(editButton);
                                        //previewForm.ribbonControl.Toolbar.ItemLinks.Add(editButton);

                                        //// Raporu önizleme olarak göster
                                        //printTool.ShowPreview();
                                    }
                                }

                                string base64EncodedInvoiceString = invoiceData.UnofficialInvoiceString;

                                // Base64 kodlu metni byte dizisine dönüştür
                                byte[] decodedBytes = Convert.FromBase64String(base64EncodedInvoiceString);

                                // Byte dizisini string'e çevir (Eğer metin UTF-8 kodlamasında ise)
                                string decodedInvoiceString = Encoding.UTF8.GetString(decodedBytes);

                                // Decode edilmiş metni ShowInvoice metoduna gönder
                                //ShowInvoice(decodedInvoiceString);
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

                                        try
                                        {
                                            if (jsonResponse != null && jsonResponse.UnofficialInvoiceString != null)
                                            {

                                                //ShowHtmlFromBase64(jsonResponse.UnofficialInvoiceString.ToString());
                                            }
                                        }
                                        catch (Exception)
                                        {

                                            Console.WriteLine("gridControl1 veya gridView1 null. Lütfen kontrol edin.");
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




                gridView1.ClearSelection(); // Tüm seçimleri temizle
                gridView1.RefreshData(); // GridView verilerini yenile
                textBox1.Focus();
            }
            else
            {
                // Kullanıcı "No" dediğinde yapılacak işlemler
                if (gridView1.DataRowCount > 0)
                {
                    // Yalnızca bir kez stored procedure çağır
                    string orderNumber = gridView1.GetRowCellValue(0, "InvoiceNumber").ToString();
                    ExecuteStoredProcedureDelete(orderNumber);
                }
            }

            // İşlemler tamamlandıktan sonra
            if (gridControl1.DataSource is DataTable dataTable)
            {
                dataTable.Clear();
            }
            else
            {
                gridControl1.DataSource = null;
            }
            textBox1.Text = "";
            gridView1.ClearSelection(); // Tüm seçimleri temizle
            gridView1.RefreshData(); // GridView verilerini yenile
            textBox1.Focus();







        }



        private void ExecuteStoredProcedureDelete(string invoiceNumber)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storecode = Properties.Settings.Default.StoreCode;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("[dbo].[MSG_InvoiceReturnItemlistCount_delete]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parametreleri ekleyin
                    command.Parameters.AddWithValue("@Invoicenumber", invoiceNumber);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery(); // Stored Procedure'ü çalıştır
                    }
                    catch (SqlException ex)
                    {
                        // Hata yönetimi
                        MessageBox.Show("Bir veritabanı hatası oluştu: " + ex.Message);
                    }
                }
            }
        }


        public void GetIadeFromStoredProcedure(string storeCode)
    {
        string serverName = Properties.Settings.Default.SunucuAdi;
        string userName = Properties.Settings.Default.KullaniciAdi;
        string password = Properties.Settings.Default.Sifre;
        string database = Properties.Settings.Default.database;
        string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand("MSG_GetReturnSeriNO", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StoreCode", storeCode);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable); // Veritabanından gelen veriyi DataTable'a doldur

                // DataTable'daki veriyi TextBox'a yazdır
                if (dataTable.Rows.Count > 0)
                {
                    // İlk satırdaki ilk sütunun değerini textBox2'ye yaz
                    textBox2.Text = dataTable.Rows[0][0].ToString();
                    // Eğer ikinci sütun varsa, onun değerini textBox3'e yaz
                    if (dataTable.Columns.Count > 1)
                    {
                        textBox3.Text = dataTable.Rows[0][1].ToString();
                    }
                }
                else
                {
                    textBox2.Text = "Sonuç bulunamadı.";
                }
            }
        }
    }

    private void GiderPusulasi_Load(object sender, EventArgs e)
    {
        LoadYetkiData();
        string storeCode = Properties.Settings.Default.StoreCode;
        GetIadeFromStoredProcedure(storeCode);



    }
    private void ExecuteStoredProcedure(string InvoiceLineID, string invoiceNumber, string currAccCode, string barcode, string qty1, string ReturnReasonCode)
    {
        string serverName = Properties.Settings.Default.SunucuAdi;
        string userName = Properties.Settings.Default.KullaniciAdi;
        string password = Properties.Settings.Default.Sifre;
        string database = Properties.Settings.Default.database;
        string storecode = Properties.Settings.Default.StoreCode;

        string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand("[dbo].[MSG_InvoiceReturnItemlistCount]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Parametreleri ekleyin
                command.Parameters.AddWithValue("@InvoiceLineID", InvoiceLineID);
                command.Parameters.AddWithValue("@Invoicenumber", invoiceNumber);
                command.Parameters.AddWithValue("@CurrAccCode", currAccCode);
                command.Parameters.AddWithValue("@Barcode", barcode);
                command.Parameters.AddWithValue("@Qty1", 1);
                    command.Parameters.AddWithValue("@ReturnReasonCode", ReturnReasonCode);


                    try
                {
                    connection.Open();
                    command.ExecuteNonQuery(); // Stored Procedure'ü çalıştır
                }
                catch (SqlException ex)
                {
                    // Hata yönetimi
                    MessageBox.Show("Bir veritabanı hatası oluştu: " + ex.Message);
                }
            }
        }
    }




    private async Task<List<ZtNebimFaturaROnlineReturn>> VeritabanindanMusteriGetirFaturaROnline(string FaturaNo)
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
                SqlCommand command = new SqlCommand("MSG_GetOrderForInvoiceToplu_REOnlineReturn", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Invoicenumber", FaturaNo);

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
                        musteri.Series = textBox3.Text;
                        musteri.SeriesNumber = textBox2.Text;

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


 

    private DataTable GetInvoiceData(string FaturaNo)
    {
        DataTable dataTable = new DataTable();

        // Veritabanı bağlantı string'inizi buraya ekleyin
        string serverName = Properties.Settings.Default.SunucuAdi;
        string userName = Properties.Settings.Default.KullaniciAdi;
        string password = Properties.Settings.Default.Sifre;
        string database = Properties.Settings.Default.database;
        string storecode = Properties.Settings.Default.StoreCode;
        string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand("MSG_GetOrderForInvoiceToplu_ReturnItem", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Invoicenumber", FaturaNo);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }
        }
        gridControl1.DataSource = dataTable;
        //gridView1.Columns["InvoiceNumber"].Caption = "Fatura NO";
        //gridView1.Columns["CurrAccCode"].Caption = "Müşteri Kodu";
        //gridView1.Columns["CurrAccDescription"].Caption = "Müşteri Adı";
        //gridView1.Columns["ColorCode"].Caption = "Renk";
        //gridView1.Columns["ColorDescription"].Caption = "Renk Açıklama";
        //gridView1.Columns["ItemDim1Code"].Caption = "Beden";
        //gridView1.Columns["Qty1"].Caption = "Miktar";

        gridView1.Columns["InvoiceLineID"].Caption = "InvoiceLineID";
        gridView1.Columns["InvoiceNumber"].Caption = "InvoiceNumber";
        gridView1.Columns["CurrAccCode"].Caption = "CurrAccCode";
        gridView1.Columns["CurrAccDescription"].Caption = "CurrAccDescription";
        gridView1.Columns["Barcode"].Caption = "Barcode";
        gridView1.Columns["ItemCode"].Caption = "ItemCode";
        gridView1.Columns["ColorCode"].Caption = "ColorCode";
        gridView1.Columns["ColorDescription"].Caption = "ColorDescription";
        gridView1.Columns["ItemDim1Code"].Caption = "ItemDim1Code";
        gridView1.Columns["Qty1"].Caption = "Qty1";


        //gridView1.Columns["Fatura NO"].Caption = "InvoiceNumber";
        //gridView1.Columns["Müşteri Kodu"].Caption = "CurrAccCode";
        //gridView1.Columns["Müşteri Adı"].Caption = "CurrAccDescription" ;
        //gridView1.Columns["Renk"].Caption = "ColorCode";
        //gridView1.Columns["Renk Açıklama"].Caption = "ColorDescription";
        //gridView1.Columns["Beden"].Caption = "ItemDim1Code";
        //gridView1.Columns["Miktar"].Caption = "Qty1";
        // ... Diğer sütun başlıkları

        // GridView ayarları...
        gridView1.BestFitColumns();

        return dataTable;
    }
    private void InitializeGridView()
    {
        // CheckBox için RepositoryItemCheckEdit oluştur
        RepositoryItemCheckEdit repositoryItemCheckEdit = new RepositoryItemCheckEdit();
        gridControl1.RepositoryItems.Add(repositoryItemCheckEdit);



        // CheckBox ile satır seçimini etkinleştir
        gridView1.OptionsSelection.MultiSelect = true;
        gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;

        gridView1.BestFitColumns();
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            string FaturaNo = textBox1.Text;

            // Fatura numarasına göre verileri çek
            DataTable invoiceData = GetInvoiceData(FaturaNo);

            if (gridControl1 != null && gridView1 != null)
            {
                // gridControl1'in MainView'unu kontrol etmek yerine, doğrudan DataSource'unu ayarla
                gridControl1.DataSource = invoiceData;

                // CheckBox sütunu ve GridView ayarlarını yapılandır
                InitializeGridView(); // Bu satırı ekleyin
                gridView1.SelectAll();
                gridView1.RefreshData(); // GridView verilerini yenile
            }
            else
            {
                // gridControl veya gridView null ise, hata mesajı göster veya logla
                Console.WriteLine("gridControl1 veya gridView1 null. Lütfen kontrol edin.");
            }
        }
    }

    private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
    {

    }
    private void OpenNebimFaturaListesi2()
    {
        var nebimFaturaListesi2 = new NebimFaturaListesiGider();
        nebimFaturaListesi2.FrmFaturalastirTekliRef = this; // Bu satır önemli
        nebimFaturaListesi2.MdiParent = this.MdiParent;
        nebimFaturaListesi2.Show();
    }

    public string TextBox1Text
    {
        get { return textBox1.Text; }
        set { textBox1.Text = value; }
    }

    public void TriggerEnterOperation()
    {
        // Enter tuşuna basıldığında gerçekleşmesini istediğiniz işlemler
        // Örneğin, simpleButton1'in click event'ini burada çağırabilirsiniz
        simpleButton1.PerformClick();
    }
    private void simpleButton1_Click(object sender, EventArgs e)
    {
        OpenNebimFaturaListesi2();
    }
}
}