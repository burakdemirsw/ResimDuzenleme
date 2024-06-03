using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace ResimDuzenleme
{
    public partial class MisigoFirmaBilgileri : Form
    {
        public MisigoFirmaBilgileri( )
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string database2 = txtDatabase.Text;
            string sirketKodu = txtsirket.Text;
            string IpAdres = txtNebimUrl.Text;
            string FirmaKisaKod = txtFirmaKodu.Text;
            string Resim1 = txtResim1.Text;
            string Resim2 = txtResim2.Text;
            string Resim3 = txtResim3.Text;
            string Resim4 = txtResim4.Text;
            string Resim5 = txtResim5.Text;
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ZTMSGMisigoUrunAcmaParametreleri (DataBaseNebim, SirketKodu,IpAdres,FirmaKisaKod,Resim1,Resim2,Resim3,Resim4,Resim5) VALUES (@Database, @SirketKodu ,@IpAdres,@FirmaKisaKod,@Resim1,@Resim2,@Resim3,@Resim4,@Resim5)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Database", database2);
                    command.Parameters.AddWithValue("@SirketKodu", sirketKodu);
                    command.Parameters.AddWithValue("@IpAdres", IpAdres);
                    command.Parameters.AddWithValue("@FirmaKisaKod", FirmaKisaKod);
                    command.Parameters.AddWithValue("@Resim1", Resim1);
                    command.Parameters.AddWithValue("@Resim2", Resim2);
                    command.Parameters.AddWithValue("@Resim3", Resim3);
                    command.Parameters.AddWithValue("@Resim4", Resim4);
                    command.Parameters.AddWithValue("@Resim5", Resim5);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT DataBaseNebim, SirketKodu,IpAdres,FirmaKisaKod,Resim1,Resim2,Resim3,Resim4,Resim5 FROM ZTMSGMisigoUrunAcmaParametreleri Order By SirketKodu asc", connection))
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
                string query = "DELETE FROM ZTMSGMisigoUrunAcmaParametreleri WHERE SirketKodu = @SirketKodu";

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

                using (SqlCommand command = new SqlCommand("SELECT DataBaseNebim, SirketKodu,IpAdres,FirmaKisaKod,Resim1,Resim2,Resim3,Resim4,Resim5 FROM ZTMSGMisigoUrunAcmaParametreleri Order By SirketKodu asc", connection))
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

        private void MisigoFirmaBilgileri_Load(object sender, EventArgs e)
        {

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT DataBaseNebim, SirketKodu,IpAdres,FirmaKisaKod,Resim1,Resim2,Resim3,Resim4,Resim5 FROM ZTMSGMisigoUrunAcmaParametreleri Order By SirketKodu asc", connection))
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
    }
}
