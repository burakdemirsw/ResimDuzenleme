using NUnit.Framework;
using ResimDuzenleme.EArchiveInvoiceWS;
using ResimDuzenleme.Operations;
//using System.Threading;

using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;


namespace ResimDuzenleme
{
    public partial class NebimFaturaList : Form
    {
        public NebimFaturaList( )
        {
            InitializeComponent();
        }

        private void NebimFaturaList_Load(object sender, EventArgs e)
        {
            string storeCode = Properties.Settings.Default.StoreCode;
            DataTable invoiceData = LoadNebimOzellikForm(storeCode);

            // dataGridView1'in DataSource'una DataTable ataması yapılıyor
            //gridControl1.DataSource = invoiceData;

            gridControl1.MainView = gridView1; // gridView1, önceden tanımlanmış bir GridView nesnesi olmalı.

            // GridControl'ün DataSource'una DataTable ataması yapılıyor
            gridControl1.DataSource = invoiceData;
            gridView1.DoubleClick -= gridView1_DoubleClick; // Önceki bağlantıyı kaldır
            gridView1.DoubleClick += gridView1_DoubleClick; // Olayı yeniden bağla
            // GridView'i yeniden çizdir
            gridView1.RefreshData();
        }
        private readonly ResimDuzenlemeClient _ResimDuzenlemeClient = new ResimDuzenlemeClient();
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
    }
}
