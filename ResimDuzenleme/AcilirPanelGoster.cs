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
    public partial class AcilirPanelGoster : Form
    {
        public AcilirPanelGoster()
        {
            InitializeComponent();
        }
        public DegisimListesi NewBarcode { get; set; }
        public DegisimListesi Fiyat2 { get; set; }
        private async void AcilirPanelGoster_Load(object sender, EventArgs e)
        {
            string barcodeTypeCode = Properties.Settings.Default.txtBarkodTipi;
            bool loadAll = checkBox1.Checked; // CheckBox kontrolünden durumu al
            DataTable dataTable = await LoadDataAsync(barcodeTypeCode, loadAll);
            // dataGridView1'in DataSource'una DataTable ataması yapılıyor
            //gridControl1.DataSource = invoiceData;


            // dataGridView1'in DataSource'una DataTable ataması yapılıyor
            //gridControl1.DataSource = invoiceData;

            gridControl1.MainView = gridView1; // gridView1, önceden tanımlanmış bir GridView nesnesi olmalı.

            // GridControl'ün DataSource'una DataTable ataması yapılıyor
            gridControl1.DataSource = dataTable;
          
            gridView1.DoubleClick -= gridView1_DoubleClick; // Önceki bağlantıyı kaldır
            gridView1.DoubleClick += gridView1_DoubleClick; // Olayı yeniden bağla
            // GridView'i yeniden çizdir
            gridView1.RefreshData();
        }

        private async Task<DataTable> LoadDataAsync(string barcodeTypeCode, bool loadAll = false)
        {
            DataTable dataTable = new DataTable();
            string query;
            if (loadAll)
            {
                query = "SELECT * FROM MSG_NebimUrunListesi(@barcodeTypeCode)  Order by [Ürün Kodu],[Renk Kodu],[Beden] "; // Tüm kayıtları çek
            }
            else
            {
                query = "SELECT top 10 * FROM MSG_NebimUrunListesi(@barcodeTypeCode)  Order by [Ürün Kodu],[Renk Kodu],[Beden] "; // İlk 10 kaydı çek
            }

            string connectionString = $"Server={Properties.Settings.Default.SunucuAdi};Database={Properties.Settings.Default.database};User Id={Properties.Settings.Default.KullaniciAdi};Password={Properties.Settings.Default.Sifre};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BarcodeTypeCode", barcodeTypeCode); // Parametreye güvenli bir şekilde değer ekle

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        await Task.Run(() => dataAdapter.Fill(dataTable)); // DataTable'ı veri ile doldur
                    }
                }
            }
            return dataTable; // Doldurulmuş DataTable'ı döndür
        }

        //private DataTable LoadNebimOzellikForm(string BarcodeTypeCode)
        //{
        //    DataTable dataTable = new DataTable();

        //    string serverName = Properties.Settings.Default.SunucuAdi;
        //    string userName = Properties.Settings.Default.KullaniciAdi;
        //    string password = Properties.Settings.Default.Sifre;
        //    string database = Properties.Settings.Default.database;
        //    string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand("MSG_NebimUrunListesi", connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure; // Bu satır önemli!
        //            command.Parameters.AddWithValue("@BarcodeTypeCode", BarcodeTypeCode); // Parametre burada sağlanmalı.

        //            SqlDataAdapter adapter = new SqlDataAdapter(command);
        //            adapter.Fill(dataTable);
        //        }
        //    }

        //    // GridControl'ün DataSource'una DataTable ataması yapılıyor
        //    gridControl1.DataSource = dataTable;
        //    gridView1.Columns["Ürün Kodu"].Caption = "Ürün Kodu";
        //    gridView1.Columns["Ürün Adı"].Caption = "Ürün Adı";
        //    gridView1.Columns["Renk Kodu"].Caption = "Renk Kodu";
        //    gridView1.Columns["Renk Adı"].Caption = "Renk Adı";
        //    gridView1.Columns["Beden"].Caption = "Beden";
        //    gridView1.Columns["Fiyat"].Caption = "Fiyat";
        //    gridView1.Columns["Barcode"].Caption = "Barcode";
        //    // ... Diğer sütun başlıkları

        //    // GridView ayarları...
        //    gridView1.BestFitColumns();

        //    return dataTable;
        //}

        public string SecilenBarcode { get; private set; }
        public string SecilenFiyat { get; private set; }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var point = gridControl1.PointToClient(Control.MousePosition);
            var hitInfo = gridView1.CalcHitInfo(point);
            if (hitInfo.InRow || hitInfo.InRowCell)
            {
                SecilenBarcode = gridView1.GetRowCellValue(hitInfo.RowHandle, "Barcode").ToString();
                SecilenFiyat = gridView1.GetRowCellValue(hitInfo.RowHandle, "Fiyat").ToString();

                this.DialogResult = DialogResult.OK; // Dialog sonucunu OK olarak ayarla
                this.Close(); // Formu kapat
            }
        }

        private async void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                string barcodeTypeCode = Properties.Settings.Default.txtBarkodTipi;
                bool loadAll = checkBox1.Checked; // CheckBox kontrolünden durumu al
                DataTable dataTable = await LoadDataAsync(barcodeTypeCode, false);
            }
            else
            {
                string barcodeTypeCode = Properties.Settings.Default.txtBarkodTipi;
                bool loadAll = checkBox1.Checked; // CheckBox kontrolünden durumu al
                DataTable dataTable = await LoadDataAsync(barcodeTypeCode, true);
            }
        }
    }
}
