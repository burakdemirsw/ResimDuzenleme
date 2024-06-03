using DevExpress.XtraBars;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using ResimDuzenleme.EArchiveInvoiceWS;
using ResimDuzenleme.Operations;
//using System.Threading;

using ResimDuzenleme.SiparisServis;
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
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;


namespace ResimDuzenleme
{
    public partial class Magaza : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Encoding encoding = Encoding.UTF8;

        //    string pngOutputPath;
        private FaturaGorsel faturaGorselForm = new FaturaGorsel();

        public Magaza( )
        {
            InitializeComponent();
            this.Height = 1080;

            //foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridView1.Columns)
            //{
            //    column.OptionsColumn.AllowEdit = false; // Hücre düzenlemesini engelle
            //}

            // Çift tıklama olayını bağla

        }

        string ipAdresi = Properties.Settings.Default.txtEntegrator;
        private HttpClient httpClient = new HttpClient();

        private string TransformXmlToHtml(string xml, string xslt)
        {
            XPathDocument xPathDoc = new XPathDocument(new StringReader(xml));
            XslCompiledTransform transform = new XslCompiledTransform();
            transform.Load(new XmlTextReader(new StringReader(xslt)));

            StringBuilder stringBuilder = new StringBuilder();
            using (TextWriter textWriter = new StringWriter(stringBuilder))
            {
                transform.Transform(xPathDoc, null, textWriter);
            }

            return stringBuilder.ToString();
        }

        private Task WaitForDocumentCompletedAsync(WebBrowser browser)
        {
            var tcs = new TaskCompletionSource<object>();
            WebBrowserDocumentCompletedEventHandler handler = null;
            handler = (s, e) =>
            {
                browser.DocumentCompleted -= handler;
                tcs.TrySetResult(null);
            };
            browser.DocumentCompleted += handler;
            return tcs.Task;
        }
        private async Task<List<FaturaBilgisi>> GetFaturaBilgileriFromDatabase( )
        {
            List<FaturaBilgisi> faturaBilgileri = new List<FaturaBilgisi>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;
            string StoreCode = Properties.Settings.Default.StoreCode;
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
                    Firma.Firma = StoreCode;
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
                string storecode = Properties.Settings.Default.StoreCode;

                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    SqlCommand command = new SqlCommand("MSG_GetOrderForInvoiceToplu_RShipment", conn);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Firma", storecode);

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



        private async Task<int> GetOrderForInvoiceToplamAsync( )
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

                    var returnValue = await cmd.ExecuteScalarAsync();
                    return Convert.ToInt32(returnValue);
                }
            }
        }
        private async void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {














            labelStatus.Text = "Fatura Aktarımı Başladı...";
            List<FaturaBilgisi> faturaBilgileri = await GetFaturaBilgileriFromDatabasee();

            foreach (var faturaBilgisi in faturaBilgileri)
            {
                //string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                //List<ZtNebimFaturaROnline> items = await VeritabanindanMusteriGetirFaturaROnline(faturaBilgisi.Firma);

                int totalRepeatCount = 30; // Toplam tekrar sayısı

                for (int repeat = 0; repeat < totalRepeatCount; repeat++)
                {
                    string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                    List<ZtNebimFaturaRShipment> items = await VeritabanindanMusteriGetirFaturaR(faturaBilgisi.Firma);

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



                    int miktar = await GetOrderForInvoiceToplamAsync();
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
        public void ConvertXmlToHtml(string xmlFilePath, string xsltFilePath, string outputHtmlFilePath)
        {
            XslCompiledTransform transform = new XslCompiledTransform();
            transform.Load(xsltFilePath);

            using (StreamWriter writer = new StreamWriter(outputHtmlFilePath))
            {
                transform.Transform(xmlFilePath, null, writer);
            }
        }


        public void ShowInvoice(string htmlContent)
        {
            // FaturaGorsel formunu oluştur
            FaturaGorsel faturaGorselForm = new FaturaGorsel();

            // HTML içeriğini WebBrowser kontrolünde yükle
            faturaGorselForm.webBrowserControl.DocumentText = htmlContent;

            // Formu göster
            faturaGorselForm.Show();
        }
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "XML Dosyası Seçin";
                openFileDialog.Filter = "XML Dosyaları (*.xml)|*.xml";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string xmlFilePath = openFileDialog.FileName;
                    string xsltContent = File.ReadAllText("general.xslt", Encoding.UTF8);
                    string xmlContent = File.ReadAllText(xmlFilePath, Encoding.UTF8);
                    string htmlContent = TransformXmlToHtml(xmlContent, xsltContent);

                    // Fatura görselini göster
                    ShowInvoice(htmlContent);
                }
            }

        }
        private readonly ResimDuzenlemeClient _ResimDuzenlemeClient = new ResimDuzenlemeClient();

        //[Test]
        //public async Task<string> ReadFromArchive_XML(string invoiceID)
        //{
        //    var deger = BaseAdapter.EArchiveRequestHeaderType();
        //    deger.COMPRESSED = nameof(EI.YesNo.N);

        //    var request = new ArchiveInvoiceReadRequest
        //    {
        //        REQUEST_HEADER = deger,
        //        INVOICEID = invoiceID,//E ARŞİV faturalarda hangi faturanın okunmasını isteniyorsa onun uuıd'si yazılmalı
        //        PORTAL_DIRECTION = nameof(EI.Direction.OUT),
        //        PROFILE = nameof(EI.DocumentType.XML)
        //    };

        //    ArchiveInvoiceReadResponse response = _ResimDuzenlemeClient.EInvoiceArchive().ArchiveRead(request);
        //    Assert.AreEqual(response.REQUEST_RETURN.RETURN_CODE, 0);
        //    Assert.IsTrue(response.INVOICE.Length > 0);

        //    string yeni = Convert.ToBase64String(response.INVOICE[0].Value);

        //    if (response.REQUEST_RETURN.RETURN_CODE == 0 && response.INVOICE.Length > 0 && response.INVOICE[0].Value != null)
        //    {
        //        return FileOperations.SaveToDisk(response.INVOICE[0].Value, request.INVOICEID, request.PORTAL_DIRECTION, request.REQUEST_HEADER.COMPRESSED, nameof(EI.Type.EARCHIVEINVOICE), "xml");
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("Fatura içeriği boş veya hata oluştu.");
        //    }
        //}
        [Test]
        //public async Task<string> ReadFromArchive_XML(string invoiceID)
        //{
        //    var deger = BaseAdapter.EArchiveRequestHeaderType();
        //    deger.COMPRESSED = nameof(EI.YesNo.N);

        //    var request = new ArchiveInvoiceReadRequest
        //    {
        //        REQUEST_HEADER = deger,
        //        INVOICEID = invoiceID,//E ARŞİV faturalarda hangi faturanın okunmasını isteniyorsa onun uuıd'si yazılmalı
        //        PORTAL_DIRECTION = nameof(EI.Direction.OUT),
        //        PROFILE = nameof(EI.DocumentType.XML)
        //    };

        //    ArchiveInvoiceReadResponse response = _ResimDuzenlemeClient.EInvoiceArchive().ArchiveRead(request);
        //    Assert.AreEqual(response.REQUEST_RETURN.RETURN_CODE, 0);
        //    Assert.IsTrue(response.INVOICE.Length > 0);

        //    string yeni = Convert.ToBase64String(response.INVOICE[0].Value);

        //    if (response.REQUEST_RETURN.RETURN_CODE == 0 && response.INVOICE.Length > 0 && response.INVOICE[0].Value != null)
        //    {
        //        return FileOperations.SaveToDisk(response.INVOICE[0].Value, request.INVOICEID, request.PORTAL_DIRECTION, request.REQUEST_HEADER.COMPRESSED, nameof(EI.Type.EARCHIVEINVOICE), "xml");
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("Fatura içeriği boş veya hata oluştu.");
        //    }
        //}
        public async Task<string> ReadFromArchive_XML(string invoiceID)
        {
            var deger = BaseAdapter.EArchiveRequestHeaderType();
            deger.COMPRESSED = nameof(EI.YesNo.N);

            var request = new ArchiveInvoiceReadRequest
            {
                REQUEST_HEADER = deger,
                INVOICEID = invoiceID,//E ARŞİV faturalarda hangi faturanın okunmasını isteniyorsa onun uuıd'si yazılmalı
                PORTAL_DIRECTION = nameof(EI.Direction.OUT),
                PROFILE = nameof(EI.DocumentType.XML)
            };

            ArchiveInvoiceReadResponse response = await Task.Run(( ) => _ResimDuzenlemeClient.EInvoiceArchive().ArchiveRead(request));

            Assert.AreEqual(response.REQUEST_RETURN.RETURN_CODE, 0);
            Assert.IsTrue(response.INVOICE.Length > 0);

            if (response.REQUEST_RETURN.RETURN_CODE == 0 && response.INVOICE.Length > 0 && response.INVOICE[0].Value != null)
            {
                return FileOperations.SaveToDisk(response.INVOICE[0].Value, request.INVOICEID, request.PORTAL_DIRECTION, request.REQUEST_HEADER.COMPRESSED, nameof(EI.Type.EARCHIVEINVOICE), "xml");
            }
            else
            {
                throw new InvalidOperationException("Fatura içeriği boş veya hata oluştu.");
            }
        }

        private DataTable LoadNebimOzellikForm(string storeCode)
        {
            DataTable dataTable = new DataTable();

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("MSG_GetInvoiceGorsel", connection))
                {
                    command.CommandType = CommandType.StoredProcedure; // Bu satır önemli!
                    command.Parameters.AddWithValue("@StoreCode", storeCode); // Parametre burada sağlanmalı.

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }

            // GridControl'ün DataSource'una DataTable ataması yapılıyor
            gridControl1.DataSource = dataTable;
            gridView1.Columns["InvoiceID"].Caption = "InvoiceID";
            gridView1.Columns["Müşteri Adı"].Caption = "Müşteri Adı";
            gridView1.Columns["Fatura"].Caption = "Fatura";
            gridView1.Columns["Açıklama"].Caption = "Açıklama";
            gridView1.Columns["Detaylı Açıklama"].Caption = "Detaylı Açıklama";
            gridView1.Columns["Durumu"].Caption = "Durumu";
            gridView1.Columns["InvoiceUrl"].Caption = "InvoiceUrl";
            // ... Diğer sütun başlıkları

            // GridView ayarları...
            gridView1.BestFitColumns();

            return dataTable;
        }



        private DataTable GetInvoiceData(string storeCode)
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
                using (SqlCommand command = new SqlCommand("MSG_GetInvoiceGorsel", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StoreCode", storeCode);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }
        private void Magaza_Load(object sender, EventArgs e)
        {

            string storeCode = Properties.Settings.Default.StoreCode;
            DataTable invoiceData = LoadNebimOzellikForm(storeCode);

            // dataGridView1'in DataSource'una DataTable ataması yapılıyor
            //gridControl1.DataSource = invoiceData;

            gridControl1.MainView = gridView1; // gridView1, önceden tanımlanmış bir GridView nesnesi olmalı.

            // GridControl'ün DataSource'una DataTable ataması yapılıyor
            gridControl1.DataSource = invoiceData;
            gridView1.DoubleClick += gridView1_DoubleClick;
            // GridView'i yeniden çizdir
            gridView1.RefreshData();

        }



        private async void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var point = gridControl1.PointToClient(Control.MousePosition);
            var hitInfo = gridView1.CalcHitInfo(point);
            if (hitInfo.InRow || hitInfo.InRowCell)
            {
                string invoiceID = gridView1.GetRowCellValue(hitInfo.RowHandle, "InvoiceID").ToString();
                string invoiceUrl = gridView1.GetRowCellValue(hitInfo.RowHandle, "InvoiceUrl")?.ToString();

                try
                {
                    if (!string.IsNullOrWhiteSpace(invoiceUrl) && invoiceUrl.Length >= 10)
                    {
                        // Eğer InvoiceUrl doluysa, URL'yi bir web tarayıcısında aç
                        System.Diagnostics.Process.Start(invoiceUrl);
                    }
                    else
                    {
                        // InvoiceUrl boşsa, XML dosyasını oku ve HTML'e dönüştür
                        var filePath = await ReadFromArchive_XML(invoiceID);
                        string xsltContent = File.ReadAllText("general.xslt", Encoding.UTF8);
                        string xmlContent = File.ReadAllText(filePath, Encoding.UTF8);
                        string htmlContent = TransformXmlToHtml(xmlContent, xsltContent);

                        // Fatura görselini göster
                        ShowInvoice(htmlContent);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
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

        private void ShowHtmlFromBase64(string base64String)
        {
            // Base64 string'ini byte dizisine çevir ve string'e dönüştür
            byte[] htmlBytes = Convert.FromBase64String(base64String);
            string htmlContent = Encoding.UTF8.GetString(htmlBytes);

            // HTML içeriğini WebBrowser kontrolünde göster

        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl1.Visible = false;
            FrmNebimSiparis frm = new FrmNebimSiparis();
            frm.MdiParent = this;
            frm.Show();
            //labelStatus.Text = "Fatura Aktarımı Başladı...";
            //List<FaturaBilgisi> faturaBilgileri = await GetFaturaBilgileriFromDatabasee();

            //foreach (var faturaBilgisi in faturaBilgileri)
            //{
            //    string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
            //    List<ZtNebimFaturaROnline> items = await VeritabanindanMusteriGetirFaturaROnline(faturaBilgisi.Firma);

            //    labelStatus.Text = $"Veritabanından {items.Count} adet veri çekildi. Şimdi POST işlemi başlatılıyor...";
            //    int postCount = 0;
            //    var tasks = items.Select(async item =>
            //    {
            //        string json = JsonConvert.SerializeObject(item);
            //        try
            //        {
            //            string serverName = Properties.Settings.Default.SunucuAdi;
            //            string userName = Properties.Settings.Default.KullaniciAdi;
            //            string password = Properties.Settings.Default.Sifre;
            //            string database = Properties.Settings.Default.database;
            //            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

            //            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            //            var content = new StringContent(json, Encoding.UTF8, "application/json");
            //            var response = await httpClient.PostAsync($"http://{faturaBilgisi.IpAdres}/(S({sessionID}))/IntegratorService/post?", content);

            //            if (response.IsSuccessStatusCode)
            //            {
            //                //var result = await response.Content.ReadAsStringAsync();
            //                //labelStatus.Text = $"POST işlemi {postCount}/{items.Count} veri için tamamlandı...";


            //                using (SqlConnection conn = new SqlConnection(connectionString))
            //                {
            //                    string query = "INSERT INTO ZTMSGTicSiparisKontrol (FaturaNo,Request,Cevap) VALUES (@FaturaNo,@Request,@Cevap)";
            //                    using (SqlCommand cmd = new SqlCommand(query, conn))
            //                    {
            //                        var result = await response.Content.ReadAsStringAsync();
            //                        dynamic jsonResponse = JsonConvert.DeserializeObject(result);

            //                        cmd.Parameters.AddWithValue("@FaturaNo", item.CustomerCode);
            //                        cmd.Parameters.AddWithValue("@Request", json);
            //                        cmd.Parameters.AddWithValue("@Cevap", jsonResponse);

            //                        labelStatus.Text = $"POST işlemi {postCount}/{items.Count} veri için tamamlandı...";
            //                        conn.Open();
            //                        cmd.ExecuteNonQuery();

            //                        if (jsonResponse != null && jsonResponse.UnofficialInvoiceString != null)
            //                        {

            //                            ShowHtmlFromBase64(jsonResponse.UnofficialInvoiceString.ToString());
            //                        }
            //                    }
            //                }

            //            }
            //            else
            //            {

            //                using (SqlConnection conn = new SqlConnection(connectionString))
            //                {
            //                    string query = "INSERT INTO ZTMSGTicSiparisKontrol (FaturaNo,Request,Cevap) VALUES (@FaturaNo,@Request,@Cevap)";
            //                    using (SqlCommand cmd = new SqlCommand(query, conn))
            //                    {
            //                        var result = await response.Content.ReadAsStringAsync();
            //                        cmd.Parameters.AddWithValue("@FaturaNo", item.CustomerCode);
            //                        cmd.Parameters.AddWithValue("@Request", json);
            //                        cmd.Parameters.AddWithValue("@Cevap", result);

            //                        conn.Open();
            //                        cmd.ExecuteNonQuery();
            //                    }
            //                }
            //                labelStatus.Text = $"POST işlemi başarısız: {response.StatusCode}";
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            labelStatus.Text = $"Hata: {ex.ToString()}";  // Daha detaylı hata bilgisi
            //        }
            //    }).ToList();

            //    await Task.WhenAll(tasks);

            //    labelStatus.Text = "Fatura Aktarımı tamamlandı.";
            //}

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

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl1.Visible = true;
            string storeCode = Properties.Settings.Default.StoreCode;
            DataTable invoiceData = LoadNebimOzellikForm(storeCode);
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<WebSiparis> uyeListe = SiparisServiceMethods.SelectSiparis();
            List<WebSiparisUrun> uyeAdresListe = SiparisServiceMethods.SelectSiparisDetay();

        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            string storeCode = Properties.Settings.Default.StoreCode;
            SiparisListTicimax report = new SiparisListTicimax();

            // Rapor için veri kaynağını yapılandır
            report.ConfigureDataSource(storeCode);

            // Raporu göstermek için ReportPrintTool kullan
            DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(report);

            // Raporu önizleme olarak göster
            printTool.ShowPreview();
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            SatisForm frm = new SatisForm();
            frm.Show();
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmFaturalastir frm = new frmFaturalastir();
            frm.Show();
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            KargoCikis frm = new KargoCikis();
            frm.Show();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            GiderPusulasi frm = new GiderPusulasi();
            frm.Show();
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmFaturalastirTekli frm = new FrmFaturalastirTekli();
            frm.Show();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl1.Visible = false;
            FrmIrsaliyeFaturalastirTekli frm = new FrmIrsaliyeFaturalastirTekli();
            frm.MdiParent = this;
            frm.Show();

        }
    }
}