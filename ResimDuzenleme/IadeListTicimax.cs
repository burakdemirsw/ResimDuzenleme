using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Data.SqlClient;




using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;

using DevExpress.XtraPrinting; // Yazdırma ve önizleme için
using DevExpress.XtraReports.UserDesigner; // Rapor tasarımcısı için

namespace ResimDuzenleme
{
    public partial class IadeListTicimax : DevExpress.XtraReports.UI.XtraReport
    {
        public IadeListTicimax()
        {
            InitializeComponent();
        }
      

        public void ConfigureDataSource(string storeCodeParameter)
        {
            string connectionString = $"Server={Properties.Settings.Default.SunucuAdi};Database={Properties.Settings.Default.database};User Id={Properties.Settings.Default.KullaniciAdi};Password={Properties.Settings.Default.Sifre};";
            string storedProcedureName = "MSG_GetIadeGorsel";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(storedProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@HeaderID", storeCodeParameter); // Dinamik parametre kullanımı

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();

                try
                {
                    connection.Open();
                    adapter.Fill(dataSet);
                    this.DataSource = dataSet; // Raporun veri kaynağını ayarlayın
                    this.DataMember = dataSet.Tables[0].TableName; // İlk tabloyu veri üyesi olarak kullanın
                }
                catch (Exception ex)
                {
                    // Hata yönetimi
                    Console.WriteLine("Hata: " + ex.Message);
                }
            }
        }
    }

}
