using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace ResimDuzenleme
{
    public partial class KargoCikis : Form
    {
        public KargoCikis()
        {
            InitializeComponent();
        }
        string ipAdresi = Properties.Settings.Default.txtEntegrator;
        private void ExecuteStoredProc(string barcode , string Kargo)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            string query = @"INSERT INTO ZTMSGKargoTakipKontrol (KargoNo,PazaryeriBarkod)
                   select  @KargoNo,@PazaryeriBarkod where @PazaryeriBarkod not in (select PazaryeriBarkod from ZTMSGKargoTakipKontrol)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@KargoNo", textBox1.Text);

                    cmd.Parameters.AddWithValue("@PazaryeriBarkod", textBox2.Text);


                    cmd.ExecuteNonQuery();

                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM ZTMSGKargoTakipKontrol WHERE PazaryeriBarkod = @PazaryeriBarkod ORDER BY KargoNo", connection))
                {
                    command.Parameters.AddWithValue("@KargoNo", textBox1.Text);
                    command.Parameters.AddWithValue("@PazaryeriBarkod", textBox2.Text);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        DataTable tempTable = (DataTable)dataGridView1.DataSource;

                        if (tempTable != null)
                        {
                            // Eğer önceki veriler varsa, yeni verileri ekleyin
                            foreach (DataRow row in dataTable.Rows)
                            {
                                tempTable.ImportRow(row);
                                dataTable.DefaultView.Sort = "CreatedDate DESC"; // Sıralama sütunu ve sıralama yönüne göre ayarlayın
                                dataTable = dataTable.DefaultView.ToTable();
                            }
                            dataTable.DefaultView.Sort = "CreatedDate DESC"; // Sıralama sütunu ve sıralama yönüne göre ayarlayın
                            dataTable = dataTable.DefaultView.ToTable();
                            dataGridView1.DataSource = tempTable;
                        }
                        else
                        {
                            dataGridView1.DataSource = dataTable;
                        }
                        dataTable.DefaultView.Sort = "CreatedDate DESC"; // Sıralama sütunu ve sıralama yönüne göre ayarlayın
                        dataTable = dataTable.DefaultView.ToTable();
                    }
                }

            }
            textBox1.Clear();
            textBox2.Clear();// txtBarcode temizlenir
            textBox1.Focus();

        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string Kargo = textBox1.Text;
                string barcode = textBox2.Text;
                ExecuteStoredProc(barcode,Kargo);
            }
        }

        private void KargoCikis_Load(object sender, EventArgs e)
        {

        }
    }
}
