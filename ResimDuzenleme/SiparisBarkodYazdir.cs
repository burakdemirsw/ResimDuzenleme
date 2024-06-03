using DevExpress.XtraReports.Parameters;
using DevExpress.XtraReports.UI;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace ResimDuzenleme
{
    public partial class SiparisBarkodYazdir : Form
    {
        public SiparisBarkodYazdir( )
        {
            InitializeComponent();
        }

        private void SiparisBarkodYazdir_Load(object sender, EventArgs e)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("MSG_SiparisList", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDa = new SqlDataAdapter(cmd);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);

                dataGridView1.DataSource = dtbl;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string orderNumber = dataGridView1.Rows[e.RowIndex].Cells["OrderNumber"].Value.ToString();

            // Yeni form aç
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string BarkodTipi = Properties.Settings.Default.txtBarkodTipi;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("MSG_SiparisBarkod", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BarcodeTypeCode", BarkodTipi);
                cmd.Parameters.AddWithValue("@OrderNumber", orderNumber);

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);

                dataGridView2.DataSource = dt;
                //Report'u DataTable'ye bağla

                // Report'un tasarımını yükle (eğer varsa)
                string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                string reportPath = Path.Combine(projectPath, "", "Barkod.repx");

                XtraReport report = new XtraReport();

                // Parametreleri oluştur
                Parameter parameter1 = new Parameter();
                parameter1.Name = "parameter1";
                parameter1.Type = typeof(string);
                parameter1.Value = BarkodTipi;
                parameter1.Visible = false;

                Parameter parameter2 = new Parameter();
                parameter2.Name = "parameter2";
                parameter2.Type = typeof(string);
                parameter2.Value = orderNumber;
                parameter2.Visible = false;

                // Parametreleri rapora ekleyin
                report.Parameters.Add(parameter1);
                report.Parameters.Add(parameter2);

                // Parametrelerin isteğe bağlı olmadığını belirtin (böylece değerlerin atanması zorunlu olur)
                report.RequestParameters = false;

                report.DataSource = dt;
                // Report'un tasarımını yükle (eğer varsa)
                if (File.Exists(reportPath))
                {
                    report.LoadLayout(reportPath);
                }

                // Raporu istediğiniz gibi değiştirin veya manipüle edin

                // Report'u güncelle ve yeniden kaydet
                report.CreateDocument();
                report.SaveLayout(reportPath);

                // Report'u önizleme penceresinde göster
                ReportPrintTool printTool = new ReportPrintTool(report);
                printTool.ShowPreview();
            }
        }

    }
}
