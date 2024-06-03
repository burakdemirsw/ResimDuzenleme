using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ResimDuzenleme
{
    public partial class UrunAcmaParametreleri : Form
    {
        public UrunAcmaParametreleri()
        {
            InitializeComponent();
        }

        private void UrunAcmaParametreleri_Load(object sender, EventArgs e)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
             
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT DataBaseNebim, SirketKodu,ResimYolu,IpAdres FROM ZTMSGTicUrunAcmaParametreleri Order By SirketKodu asc", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string database2 = txtDatabase.Text;
            string sirketKodu = txtSirketKodu.Text;
            string ResimYolu = txtResimYolu.Text;
            string IpAdres = txtNebimUrl.Text;
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ZTMSGTicUrunAcmaParametreleri (DataBaseNebim, SirketKodu,ResimYolu,IpAdres) VALUES (@Database, @SirketKodu ,@ResimYolu,@IpAdres)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Database", database2);
                    command.Parameters.AddWithValue("@SirketKodu", sirketKodu);
                    command.Parameters.AddWithValue("@ResimYolu", ResimYolu);
                    command.Parameters.AddWithValue("@IpAdres", IpAdres);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT DataBaseNebim, SirketKodu,ResimYolu,IpAdres FROM ZTMSGTicUrunAcmaParametreleri Order By SirketKodu asc", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            MessageBox.Show("Kayıt Başarıyla Eklendi.");
            
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            // DataGridView'den seçili olan satırın SirketKodu değerini al
            string selectedSirketKodu = dataGridView1.CurrentRow.Cells["SirketKodu"].Value.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ZTMSGTicUrunAcmaParametreleri WHERE SirketKodu = @SirketKodu";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SirketKodu", selectedSirketKodu);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT DataBaseNebim, SirketKodu,ResimYolu,IpAdres FROM ZTMSGTicUrunAcmaParametreleri Order By SirketKodu asc", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            MessageBox.Show("Kayıt Başarıyla Silindi.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
