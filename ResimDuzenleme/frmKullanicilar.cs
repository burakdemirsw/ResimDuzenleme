using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ResimDuzenleme
{
    public partial class frmKullanicilar : Form
    {
        public frmKullanicilar()
        {
            InitializeComponent();

        }
   


        private void LoadYetkiData()
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT YetkiKodu, Yetki FROM ZTMSGYetki order by YetkiKodu asc";
                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBoxYetki.DisplayMember = "Yetki";
                    comboBoxYetki.ValueMember = "YetkiKodu";
                    comboBoxYetki.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }

        private void LoadmagazaData()
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT StoreCode,Store FROM ZTMSGStore order by Storecode asc";
                    SqlDataAdapter da = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboBox1.DisplayMember = "Store";
                    comboBox1.ValueMember = "StoreCode";
                    comboBox1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string database2 = txtKullanici.Text;
            string sirketKodu = txtSifre.Text;
            int yetkiKodu = (int)comboBoxYetki.SelectedValue;
            string StoreKodu = (string)comboBox1.SelectedValue;

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ZTMSGUserLogin (UserName,PassWord,StoreCode,Yetki) VALUES (@UserName, @PassWord ,@StoreCode,@Yetki)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", database2);
                    command.Parameters.AddWithValue("@PassWord", sirketKodu);
                    command.Parameters.AddWithValue("@StoreCode", StoreKodu);
                    command.Parameters.AddWithValue("@Yetki", yetkiKodu);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("select UserName,PassWord,StoreCode,Yetki from ZTMSGUserLogin", connection))
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
            string selectedSirketKodu = dataGridView1.CurrentRow.Cells["UserName"].Value.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ZTMSGUserLogin WHERE UserName = @UserName";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", selectedSirketKodu);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("select UserName,PassWord,StoreCode,Yetki from ZTMSGUserLogin", connection))
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

        private void frmKullanicilar_Load(object sender, EventArgs e)
        {
         
            // ... diğer initializasyon kodları
            LoadYetkiData();
            LoadmagazaData();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                using (SqlCommand command = new SqlCommand("select UserName,PassWord,StoreCode,Yetki from ZTMSGUserLogin", connection))
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedYetkiKodu = (int)comboBoxYetki.SelectedValue;
        }
    }
}
