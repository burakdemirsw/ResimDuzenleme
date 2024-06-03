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
    public partial class NebimFaturaListesiAlis : Form
    {
        public NebimFaturaListesiAlis()
        {
            InitializeComponent();
        }
        public FrmAlisSiparis FrmFaturalastirTekliRef { get; set; }
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void NebimFaturaListesiAlis_Load(object sender, EventArgs e)
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
                using (SqlCommand command = new SqlCommand("MSG_GetAlisSiparis", connection))
                {
                    command.CommandType = CommandType.StoredProcedure; // Bu satır önemli!
                    command.Parameters.AddWithValue("@StoreCode", storeCode); // Parametre burada sağlanmalı.

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }

            // GridControl'ün DataSource'una DataTable ataması yapılıyor
            gridControl1.DataSource = dataTable;
            gridView1.Columns["OrderID"].Caption = "OrderID";
            gridView1.Columns["Müşteri Adı"].Caption = "Müşteri Adı";
            gridView1.Columns["SiparisNo"].Caption = "SiparisNo";
            gridView1.Columns["Açıklama"].Caption = "Açıklama";
            gridView1.Columns["Detaylı Açıklama"].Caption = "Detaylı Açıklama";
            gridView1.Columns["Durumu"].Caption = "Durumu";

            // ... Diğer sütun başlıkları

            // GridView ayarları...
            gridView1.BestFitColumns();

            return dataTable;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var point = gridControl1.PointToClient(Control.MousePosition);
            var hitInfo = gridView1.CalcHitInfo(point);
            if (hitInfo.InRow || hitInfo.InRowCell)
            {
                var invoiceNumber = gridView1.GetRowCellValue(hitInfo.RowHandle, "SiparisNo").ToString();
                if (FrmFaturalastirTekliRef != null)
                {
                    FrmFaturalastirTekliRef.TextBox1Text = invoiceNumber;
                    // Gerekirse burada FrmFaturalastirTekli formunda başka işlemler de yapabilirsiniz
                    this.Close(); // Şu anki formu (NebimFaturaListesi2) kapat
                }
                else
                {
                    MessageBox.Show("FrmFaturalastirTekli formuna referans bulunamadı.");
                }
            }
        }
    }
}
