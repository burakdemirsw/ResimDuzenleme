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
    public partial class frmMagazalar : Form
    {
        public frmMagazalar()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string database2 = txtKullanici.Text;
            string sirketKodu = txtSifre.Text;

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ZTMSGStore (StoreCode, Store) VALUES (@Database, @SirketKodu )";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Database", database2);
                    command.Parameters.AddWithValue("@SirketKodu", sirketKodu);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT StoreCode, Store FROM ZTMSGStore Order By StoreCode asc", connection))
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

        private void frmMagazalar_Load(object sender, EventArgs e)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT StoreCode, Store FROM ZTMSGStore Order By StoreCode asc", connection))
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

        private void btnsil_Click(object sender, EventArgs e)
        {

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            // DataGridView'den seçili olan satırın SirketKodu değerini al
            string selectedSirketKodu = dataGridView1.CurrentRow.Cells["StoreCode"].Value.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ZTMSGStore WHERE StoreCode = @StoreCode";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StoreCode", selectedSirketKodu);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT StoreCode, Store FROM ZTMSGStore Order By StoreCode asc", connection))
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
    }
}
