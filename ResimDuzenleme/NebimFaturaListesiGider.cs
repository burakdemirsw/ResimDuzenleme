//using System.Threading;

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ResimDuzenleme
{
    public partial class NebimFaturaListesiGider : Form
    {
        public NebimFaturaListesiGider( )
        {
            InitializeComponent();
        }
        public GiderPusulasi FrmFaturalastirTekliRef { get; set; }
        public DegisimListesi FrmFaturalastirTekliRef2 { get; set; }
        private void NebimFaturaListesiGider_Load(object sender, EventArgs e)
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

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var point = gridControl1.PointToClient(Control.MousePosition);
            var hitInfo = gridView1.CalcHitInfo(point);
            if (hitInfo.InRow || hitInfo.InRowCell)
            {
                var invoiceNumber = gridView1.GetRowCellValue(hitInfo.RowHandle, "FaturaNo").ToString();
                if (FrmFaturalastirTekliRef != null)
                {
                    FrmFaturalastirTekliRef.TextBox1Text = invoiceNumber;

                    // Gerekirse burada FrmFaturalastirTekli formunda başka işlemler de yapabilirsiniz
                    this.Close(); // Şu anki formu (NebimFaturaListesi2) kapat
                }
                else
                {
                    Console.WriteLine("FrmFaturalastirTekli formuna referans bulunamadı.");
                }


                if (FrmFaturalastirTekliRef2 != null)
                {
                    FrmFaturalastirTekliRef2.TextBox1Text = invoiceNumber;
                    // Gerekirse burada FrmFaturalastirTekli formunda başka işlemler de yapabilirsiniz
                    this.Close(); // Şu anki formu (NebimFaturaListesi2) kapat
                }
                else
                {
                    Console.WriteLine("FrmFaturalastirTekli formuna referans bulunamadı.");
                }
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
                using (SqlCommand command = new SqlCommand("MSG_GetFaturaGider", connection))
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
            gridView1.Columns["FaturaNo"].Caption = "FaturaNo";
            gridView1.Columns["Açıklama"].Caption = "Açıklama";
            gridView1.Columns["Detaylı Açıklama"].Caption = "Detaylı Açıklama";
            gridView1.Columns["Durumu"].Caption = "Durumu";

            // ... Diğer sütun başlıkları

            // GridView ayarları...
            gridView1.BestFitColumns();

            return dataTable;
        }



    }
}
