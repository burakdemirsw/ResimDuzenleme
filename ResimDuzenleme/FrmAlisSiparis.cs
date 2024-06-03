using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using ResimDuzenleme.EArchiveInvoiceWS;
using ResimDuzenleme.Operations;
using System.IO;
using System.Net.Http;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace ResimDuzenleme
{
    public partial class FrmAlisSiparis : Form
    {
        public FrmAlisSiparis()
        {
            InitializeComponent();
        }

        private void buttonEdit1_Toggled(object sender, EventArgs e)
        {
            if (buttonEdit1.IsOn == false)
            {
                label2.Text = "Sipariş Barkod";
            }
            else
            {
                label2.Text = "Lot Barkod";
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
            string barcode = Properties.Settings.Default.txtBarkodTipi;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("MSG_GetOrderForInvoiceToplu_Item", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Invoicenumber", FaturaNo);
                    command.Parameters.AddWithValue("@BarcodeTypeCode", barcode);
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


            gridView1.Columns["OrderNumber"].Caption = "OrderNumber";
            gridView1.Columns["CurrAccCode"].Caption = "CurrAccCode";
            gridView1.Columns["CurrAccDescription"].Caption = "CurrAccDescription";
            gridView1.Columns["Barcode"].Caption = "Barcode";
            gridView1.Columns["ItemCode"].Caption = "ItemCode";
            gridView1.Columns["ColorCode"].Caption = "ColorCode";
            gridView1.Columns["ColorDescription"].Caption = "ColorDescription";
            gridView1.Columns["ItemDim1Code"].Caption = "ItemDim1Code";
            gridView1.Columns["Qty1"].Caption = "Qty1";
            gridView1.Columns["CountQty"].Caption = "CountQty";

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
            if (e.KeyCode == Keys.Enter && textBox1.Text != "")
            {
                string FaturaNo = textBox1.Text;

                // Fatura numarasına göre verileri çek
                DataTable invoiceData = GetInvoiceData(FaturaNo);

                if (gridControl1 != null && gridView1 != null && FaturaNo != "")
                {
                    // gridControl1'in MainView'unu kontrol etmek yerine, doğrudan DataSource'unu ayarla
                    gridControl1.DataSource = invoiceData;

                    // CheckBox sütunu ve GridView ayarlarını yapılandır
                    InitializeGridView(); // Bu satırı ekleyin
                                          //gridView1.SelectAll();
                    gridView1.ClearSelection();

                    gridView1.RefreshData(); // GridView verilerini yenile
                }
                else
                {
                    // gridControl veya gridView null ise, hata mesajı göster veya logla
                    Console.WriteLine("gridControl1 veya gridView1 null. Lütfen kontrol edin.");
                }
            }
        }

        private void ExecuteStoredProcedure(string invoiceNumber, string currAccCode, string barcode, string qty1)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storecode = Properties.Settings.Default.StoreCode;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("[dbo].[MSG_InvoiceItemlistCount]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parametreleri ekleyin
                    command.Parameters.AddWithValue("@Invoicenumber", invoiceNumber);
                    command.Parameters.AddWithValue("@CurrAccCode", currAccCode);
                    command.Parameters.AddWithValue("@Barcode", barcode);
                    command.Parameters.AddWithValue("@Qty1", 1);


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

        private void ExecuteLOTStoredProcedure(string invoiceNumber, string currAccCode, string barcode, string qty1)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storecode = Properties.Settings.Default.StoreCode;
            string BarcodeTypeCode = Properties.Settings.Default.txtBarkodTipi;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("[dbo].[MSG_InvoiceItemLotlistCount]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parametreleri ekleyin
                    command.Parameters.AddWithValue("@Invoicenumber", invoiceNumber);
                    command.Parameters.AddWithValue("@CurrAccCode", currAccCode);
                    command.Parameters.AddWithValue("@LotBarcode", barcode);
                    command.Parameters.AddWithValue("@Qty1", 1);
                    command.Parameters.AddWithValue("@BarcodeTypeCode", BarcodeTypeCode);


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
                using (SqlCommand command = new SqlCommand("[dbo].[MSG_InvoiceItemlistCount_delete]", connection))
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
                using (SqlCommand command = new SqlCommand("[dbo].[MSG_InvoiceItemlistCount_Update]", connection))
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





        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string inputBarcode = textBox2.Text;
                bool matchFound = false;
                if (buttonEdit1.IsOn == false)
                {
                    for (int i = 0; i < gridView1.DataRowCount; i++)
                    {
                        // Burada "Barcode" sütununuzun adını kullanın
                        object barcode = gridView1.GetRowCellValue(i, "Barcode");

                        if (inputBarcode.Equals(barcode?.ToString()) && buttonEdit1.IsOn == false)
                        {
                            // Eşleşme bulunduğunda
                            matchFound = true;
                            gridView1.SelectRow(i); // Satırı seç
                            gridView1.FocusedRowHandle = i; // Fokuslanan satırı ayarla

                            // "Qty1" ve "CountQty" değerlerini kontrol et
                            object qty1Object = gridView1.GetRowCellValue(i, "Qty1");
                            object countQtyObject = gridView1.GetRowCellValue(i, "CountQty");

                            // Null kontrolü yapılıyor ve object tipi uygun türe dönüştürülüyor.
                            int qty1 = qty1Object != null ? Convert.ToInt32(qty1Object) : 0;
                            int countQty = countQtyObject != null ? Convert.ToInt32(countQtyObject) : 0;

                            // Eğer Qty1 ve CountQty eşit değilse stored procedure'ü çalıştır
                            if (qty1 != countQty)
                            {

                                ExecuteStoredProcedure(
                               gridView1.GetRowCellValue(i, "OrderNumber").ToString(), // Fatura numarası veya Sipariş numarası
                               gridView1.GetRowCellValue(i, "CurrAccCode").ToString(), // Cari hesap kodu
                               barcode.ToString(), // Barkod
                               qty1.ToString() // Qty1
                           );
                                CheckOrderCompletionAndProceed(
                               gridView1.GetRowCellValue(i, "OrderNumber").ToString()
                               );


                            }
                            else
                            {
                                if (textBox1.Text != "")
                                {

                                    MessageBox.Show("Siparişte Okuttuğunuz barkod daha önce toplanmıştır");
                                    textBox1.Focus();
                                }
                            }





                            gridView1.RefreshData(); // GridView verilerini yenile
                            break; // Döngüden çık
                        }


                    }
                }
                // Tüm satırları döngüye al
               
                  else 
                {

                    for (int i = 0; i < gridView1.DataRowCount; i++)
                    {
                        // Burada "Barcode" sütununuzun adını kullanın
                        object barcode = gridView1.GetRowCellValue(i, "Barcode");

                        if ( buttonEdit1.IsOn == true)
                        {

                            matchFound = true;
                            gridView1.SelectRow(i); // Satırı seç
                            gridView1.FocusedRowHandle = i; // Fokuslanan satırı ayarla

                            // "Qty1" ve "CountQty" değerlerini kontrol et
                            object qty1Object = gridView1.GetRowCellValue(i, "Qty1");
                            object countQtyObject = gridView1.GetRowCellValue(i, "CountQty");

                            // Null kontrolü yapılıyor ve object tipi uygun türe dönüştürülüyor.
                            int qty1 = qty1Object != null ? Convert.ToInt32(qty1Object) : 0;
                            int countQty = countQtyObject != null ? Convert.ToInt32(countQtyObject) : 0;
                            if (qty1 != countQty)
                            {
                                ExecuteLOTStoredProcedure(
                              gridView1.GetRowCellValue(i, "OrderNumber").ToString(), // Fatura numarası veya Sipariş numarası
                              gridView1.GetRowCellValue(i, "CurrAccCode").ToString(), // Cari hesap kodu
                              textBox2.Text, // Barkod
                              qty1.ToString() // Qty1
                          );
                                CheckOrderCompletionAndProceed(
                               gridView1.GetRowCellValue(i, "OrderNumber").ToString()
                               );
                                break;
                            }
                            else
                            {
                                if (textBox1.Text != "" && qty1 != countQty)
                                {

                                    MessageBox.Show("Siparişte Okuttuğunuz barkod daha önce toplanmıştır");
                                    textBox1.Focus();
                                }
                            }
                            gridView1.RefreshData(); // GridView verilerini yenile
                          //  break;
                        }


                    }


                }


                if (!matchFound)
                {
                    // Eşleşme bulunamazsa kullanıcıya bilgi ver
                    MessageBox.Show("Eşleşen barkod bulunamadı.");
                }
                string FaturaNo = textBox1.Text;

                // Fatura numarasına göre verileri çek
                DataTable invoiceData = GetInvoiceData(FaturaNo);

                if (gridControl1 != null && gridView1 != null)
                {
                    // gridControl1'in MainView'unu kontrol etmek yerine, doğrudan DataSource'unu ayarla
                    gridControl1.DataSource = invoiceData;

                    // CheckBox sütunu ve GridView ayarlarını yapılandır
                    InitializeGridView(); // Bu satırı ekleyin
                                          //gridView1.SelectAll();
                    gridView1.ClearSelection();
                    gridView1.RefreshData(); // GridView verilerini yenile
                }
                else
                {
                    // gridControl veya gridView null ise, hata mesajı göster veya logla
                    Console.WriteLine("gridControl1 veya gridView1 null. Lütfen kontrol edin.");
                }
                // Diğer işlemler...

                textBox2.Text = "";
                textBox2.Focus();
                gridView1.RefreshData();
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

        private async Task<List<ZtNebimFaturaAlis>> VeritabanindanMusteriGetirFaturaROnline(string Ordernumber, string BarcodeType)
        {

            try
            {
                List<ZtNebimFaturaAlis> musteriler = new List<ZtNebimFaturaAlis>();
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    SqlCommand command = new SqlCommand("MSG_GetOrderForInvoiceToplu_BPCount", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Ordernumber", Ordernumber);
                    command.Parameters.AddWithValue("@BarcodeType", BarcodeType);

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        ZtNebimFaturaAlis musteri = new ZtNebimFaturaAlis();
                        musteri.ModelType = Convert.ToInt32(reader["ModelType"]);
                        musteri.InvoiceNumber = reader["InvoiceNumber"].ToString();
                        musteri.VendorCode = reader["VendorCode"].ToString();
                        if (!string.IsNullOrEmpty(textBox4.Text))
                        {
                            musteri.EInvoiceNumber = textBox4.Text;
                        }
                        else
                        {
                            // Eğer TextBox4 boş ise, reader'dan gelen EInvoiceNumber değerini kullan
                            musteri.EInvoiceNumber = reader["EInvoiceNumber"].ToString();
                        }
                        musteri.OfficeCode = reader["OfficeCode"].ToString();
                        musteri.StoreCode = reader["StoreCode"].ToString();
                        musteri.WarehouseCode = reader["WarehouseCode"].ToString();
                        musteri.DeliveryCompanyCode = reader["DeliveryCompanyCode"].ToString(); // Direk string olarak atandı
                        musteri.BillingPostalAddressID = reader["BillingPostalAddressID"].ToString();
                        musteri.ShippingPostalAddressID = reader["ShippingPostalAddressID"].ToString(); // Direk string olarak atandı
                        musteri.PosTerminalID = Convert.ToInt32(reader["PosTerminalID"]); // int'e çevirildi
                        musteri.TaxExemptionCode = Convert.ToInt32(reader["TaxExemptionCode"]); // int'e çevirildi
                        musteri.ShipmentMethodCode = Convert.ToInt32(reader["ShipmentMethodCode"]); // int'e çevirildi
          

                        musteri.IsOrderBase = bool.Parse(reader["IsOrderBase"].ToString());
                        if (reader["Invoicedate"] != DBNull.Value)
                        {
                            musteri.Invoicedate = Convert.ToDateTime(reader["Invoicedate"]); // DateTime'a çevirildi
                        }
                
                        musteri.Description = reader["Description"].ToString();
                        musteri.InternalDescription = reader["InternalDescription"].ToString();

                        //   musteri.CustomerTypeCode = Convert.ToInt32(reader["CustomerTypeCode"]);

                        string LinesJson = reader["Lines"].ToString();
                        JArray LinesArray = JArray.Parse(LinesJson);
                        musteri.Lines = LinesArray.ToObject<List<InvoiceLinesAlis>>();

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
        private async void CheckOrderCompletionAndProceed(string orderNumber)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string barcode = Properties.Settings.Default.txtBarkodTipi;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            object resultFromDb = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("[dbo].[MSG_InvoiceItemlistCount_Complated]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Invoicenumber", orderNumber);
                    command.Parameters.AddWithValue("@BarcodeTypeCode", barcode);

                    connection.Open();

                    resultFromDb = command.ExecuteScalar();
                }
            }
            int siparisDurumu = resultFromDb != null ? Convert.ToInt32(resultFromDb) : 0;
            if (siparisDurumu == 3)
            {
                MessageBox.Show("DURUN!!! Siparişte Toplamaması gereken Ürünler Mevcut... Sipariş İptal Edilmiş olabilir.");
            }
            if (siparisDurumu == 1)
            {
                DialogResult result2 = MessageBox.Show("Sipariş Toplandı. Faturalaştırma yapılacak mı?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result2 == DialogResult.Yes)
                {
                    ExecuteStoredProcedureUpdate(orderNumber);
                    labelStatus.Text = "Fatura Aktarımı Başladı...";
                    List<FaturaBilgisi> faturaBilgileri = await GetFaturaBilgileriFromDatabasee();

                    foreach (var faturaBilgisi in faturaBilgileri)
                    {
                        string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);

                        List<ZtNebimFaturaAlis> items = await VeritabanindanMusteriGetirFaturaROnline(orderNumber, barcode);
                        if (items.Count == 1)
                        {


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
                                        string base64EncodedInvoiceString = invoiceData.UnofficialInvoiceString;

                                        // Base64 kodlu metni byte dizisine dönüştür
                                        byte[] decodedBytes = Convert.FromBase64String(base64EncodedInvoiceString);

                                        // Byte dizisini string'e çevir (Eğer metin UTF-8 kodlamasında ise)
                                        string decodedInvoiceString = Encoding.UTF8.GetString(decodedBytes);

                                        // Decode edilmiş metni ShowInvoice metoduna gönder

                                        using (SqlConnection conn = new SqlConnection(connectionString))
                                        {
                                            string query = "INSERT INTO ZTMSGTicSiparisKontrol (FaturaNo,Request,Cevap) VALUES (@FaturaNo,@Request,@Cevap)";
                                            using (SqlCommand cmd = new SqlCommand(query, conn))
                                            {
                                                var result = await response.Content.ReadAsStringAsync();
                                                dynamic jsonResponse = JsonConvert.DeserializeObject(result);

                                                cmd.Parameters.AddWithValue("@FaturaNo", item.VendorCode);
                                                cmd.Parameters.AddWithValue("@Request", json);
                                                cmd.Parameters.AddWithValue("@Cevap", jsonResponse);

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
                                                cmd.Parameters.AddWithValue("@FaturaNo", item.VendorCode);
                                                cmd.Parameters.AddWithValue("@Request", json);
                                                cmd.Parameters.AddWithValue("@Cevap", result);

                                                conn.Open();
                                                cmd.ExecuteNonQuery();
                                            }
                                        }
                                        MessageBox.Show($"POST işlemi başarısız: {response.StatusCode}");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Hata: {ex.ToString()}");
                                    //MessageBox.Show($"Hata: {ex.ToString()}");   // Daha detaylı hata bilgisi
                                }
                            }).ToList();

                            await Task.WhenAll(tasks);

                            labelStatus.Text = "Fatura Aktarımı tamamlandı.";
                        }
                        else
                        {
                            MessageBox.Show("Aktarım Tamamlanmadı Sipariş Faturalaştırma Sırasında Hata oluştu Sipariş İptal olabilir.");
                        }
                    }


                    textBox1.Text = "";
                    textBox1.Focus();
                }
                else
                {
                    ExecuteStoredProcedureDelete(orderNumber);
                    textBox1.Text = "";
                    textBox1.Focus();
                }

                // İşlemler tamamlandıktan sonra grid ve ilgili kontrolleri temizle
                if (gridControl1.DataSource is DataTable dataTable)
                {
                    dataTable.Clear();
                }
                else
                {
                    gridControl1.DataSource = null;
                }

                gridView1.ClearSelection();
                gridView1.RefreshData();
                textBox1.Text = "";
                textBox1.Focus();
            }
            // Eğer sipariş durumu 0 ise (sipariş toplanmamışsa), herhangi bir işlem yapma.
        }
        private async void btnkaydet_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == gridView1.DataRowCount)
            {



                DialogResult result2 = MessageBox.Show("Sipariş Toplandı. Faturalaştırma yapılacak mı?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result2 == DialogResult.Yes)
                {
                    // Tüm satırlar için işlem yapmak yerine yalnızca bir kez işlem yap
                    if (gridView1.DataRowCount > 0)
                    {
                        // Yalnızca bir kez stored procedure çağır
                        string orderNumber = gridView1.GetRowCellValue(0, "OrderNumber").ToString();
                        ExecuteStoredProcedureUpdate(orderNumber);
                    }

                    labelStatus.Text = "Fatura Aktarımı Başladı...";
                    List<FaturaBilgisi> faturaBilgileri = await GetFaturaBilgileriFromDatabasee();

                    foreach (var faturaBilgisi in faturaBilgileri)
                    {
                        string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                        string orderNumber = gridView1.GetRowCellValue(0, "OrderNumber").ToString();
                        string barcode = Properties.Settings.Default.txtBarkodTipi;
                        List<ZtNebimFaturaAlis> items = await VeritabanindanMusteriGetirFaturaROnline(orderNumber, barcode);

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

                                            cmd.Parameters.AddWithValue("@FaturaNo", item.VendorCode);
                                            cmd.Parameters.AddWithValue("@Request", json);
                                            cmd.Parameters.AddWithValue("@Cevap", jsonResponse);

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
                                            cmd.Parameters.AddWithValue("@FaturaNo", item.VendorCode);
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
                        string orderNumber = gridView1.GetRowCellValue(0, "OrderNumber").ToString();
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
            else
            {
                MessageBox.Show("Lütfen tüm siparişleri seçin.");
            }
        }





        private void OpenNebimFaturaListesi2()
        {
            var nebimFaturaListesi2 = new NebimFaturaListesiAlis();
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

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            var view = sender as GridView;
            if (view != null)
            {
                // Her iki sütunun değerlerini al
                //var qty1Value = view.GetRowCellValue(e.RowHandle, "Qty1");
                //var countQtyValue = view.GetRowCellValue(e.RowHandle, "CountQty");
                object qty1Object = gridView1.GetRowCellValue(e.RowHandle, "Qty1");
                object countQtyObject = gridView1.GetRowCellValue(e.RowHandle, "CountQty");

                // Null kontrolü yapılıyor ve object tipi uygun türe dönüştürülüyor.
                int qty1 = qty1Object != null ? Convert.ToInt32(qty1Object) : 0;
                int countQty = countQtyObject != null ? Convert.ToInt32(countQtyObject) : 0;

                // Eğer her iki değer de null değil ve birbirine eşitse
                if (qty1 == countQty)
                {
                    e.Appearance.BackColor = Color.Green; // Seçili satırın arka planını yeşil yap
                    e.Appearance.ForeColor = Color.White; // Yazı rengini beyaz yap

                    SelectRowsBasedOnCondition();
                }
            }
        }
        private void SelectRowsBasedOnCondition()
        {
            for (int i = 0; i < gridView1.DataRowCount; i++)
            {
                object qty1Object = gridView1.GetRowCellValue(i, "Qty1");
                object countQtyObject = gridView1.GetRowCellValue(i, "CountQty");

                int qty1 = qty1Object != null ? Convert.ToInt32(qty1Object) : 0;
                int countQty = countQtyObject != null ? Convert.ToInt32(countQtyObject) : 0;

                if (qty1 == countQty)
                {
                    gridView1.SelectRow(i);
                }
            }
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch1.IsOn == false)
            {
                textBox3.Visible = false;
            }
            else
            {
                textBox3.Visible = true;
            }
        }
    }
}
