using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ResimDuzenleme
{
    public partial class MisigoKategoriEslestir : Form
    {
        DataTable dt3 = new DataTable();
        public MisigoKategoriEslestir( )
        {
            InitializeComponent();
        }
        List<string> tumListeItems = new List<string>();

        private void GetInvoiceDate( )
        {

            // Veritabanı bağlantı string'inizi buraya ekleyin
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storecode = Properties.Settings.Default.StoreCode;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("MSGMisigoKategoriGuncelle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;



                }

            }


        }
        private void MisigoKategoriEslestir_Load(object sender, EventArgs e)
        {
            GetInvoiceDate();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            // DataTable dt3 = new DataTable();
            //  DataTable tumListeItems = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("exec MSGMisigoKategoriGuncelle", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select ProductHierarchyID,Hierarji = Case When ProductHierarchyLevel05 != '' Then ProductHierarchyLevel01 + ' > '+ ProductHierarchyLevel02+ ' > '+ ProductHierarchyLevel03+ ' > '+ ProductHierarchyLevel04+ ' > '+ ProductHierarchyLevel05 Else  Case When  ProductHierarchyLevel04 != '' THEN ProductHierarchyLevel01 + ' > '+ ProductHierarchyLevel02+ ' > '+ ProductHierarchyLevel03+ ' > '+ ProductHierarchyLevel04 Else  Case When ProductHierarchyLevel03 != '' THEN ProductHierarchyLevel01 + ' > '+ ProductHierarchyLevel02+ ' > '+ ProductHierarchyLevel03 Else  Case When ProductHierarchyLevel02 != '' THEN ProductHierarchyLevel01 + ' > '+ ProductHierarchyLevel02 Else  Case When ProductHierarchyLevel01 != '' THEN ProductHierarchyLevel01  else '' END End ENd End End from MSGAllUrunLer  where  ProductHierarchyLevel01 != '' ORder by ProductHierarchyLevel01,ProductHierarchyLevel02,ProductHierarchyLevel03";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt3);
                }
            }

            checkedListBoxControl1.DataSource = dt3;
            checkedListBoxControl1.DisplayMember = "Hierarji";
            checkedListBoxControl1.ValueMember = "ProductHierarchyID";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("select ProductHierarchyID,ProductHierarchyLevel01,ProductHierarchyLevel02,ProductHierarchyLevel03,ProductHierarchyLevel04,Marka,MarProductHierarchyLevel01,MarProductHierarchyLevel02,MarProductHierarchyLevel03,MarProductHierarchyLevel04,Cinsiyet,Alan='' from ZTMSGKategoriListMisigo where MarProductHierarchyLevel01 != '' Group by ProductHierarchyID,ProductHierarchyLevel01,ProductHierarchyLevel02,ProductHierarchyLevel03,ProductHierarchyLevel04,Marka,MarProductHierarchyLevel01,MarProductHierarchyLevel02,MarProductHierarchyLevel03,MarProductHierarchyLevel04,Cinsiyet Order by Marka,MarProductHierarchyLevel01,MarProductHierarchyLevel02,MarProductHierarchyLevel03,MarProductHierarchyLevel04", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            foreach (DataRow row in dt3.Rows)
            {
                tumListeItems.Add(row["Hierarji"].ToString());
            }

            // CheckedListBoxControl'ü doldur
            foreach (var item in tumListeItems)
            {
                checkedListBoxControl1.Items.Add(item);
            }
            //foreach (DataRowView item in checkedListBox1.CheckedItems)
            //{
            //    string HierarchyID = item["ProductHierarchyID"].ToString();
            //    string Hierarji = item["Hierarji"].ToString();
            //    // colorDescription ve colorCode değerlerini istediğiniz şekilde kullanabilirsiniz.
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedItems = checkedListBoxControl1.CheckedItems.Cast<DataRowView>().Select(item => item.Row.Field<int>("ProductHierarchyID")).ToList();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Her bir seçili öğe için güncelleme işlemi
                foreach (DataGridViewRow selectedRow in dataGridView1.SelectedRows)
                {
                    string marka = Convert.ToString(selectedRow.Cells["Marka"].Value);
                    string MarProductHierarchyLevel01 = Convert.ToString(selectedRow.Cells["MarProductHierarchyLevel01"].Value);
                    string MarProductHierarchyLevel02 = Convert.ToString(selectedRow.Cells["MarProductHierarchyLevel02"].Value);
                    string MarProductHierarchyLevel03 = Convert.ToString(selectedRow.Cells["MarProductHierarchyLevel03"].Value);
                    string MarProductHierarchyLevel04 = Convert.ToString(selectedRow.Cells["MarProductHierarchyLevel04"].Value);

                    // CheckedListBox'dan seçilen her öğe için
                    foreach (var selectedItem in selectedItems)
                    {
                        string updateSql = "UPDATE ZTMSGKategoriListMisigo SET ProductHierarchyID = @selectedItem WHERE marka = @marka and MarProductHierarchyLevel01=@MarProductHierarchyLevel01 and MarProductHierarchyLevel02=@MarProductHierarchyLevel02 and MarProductHierarchyLevel03= @MarProductHierarchyLevel03 and MarProductHierarchyLevel04 =@MarProductHierarchyLevel04";

                        using (SqlCommand cmd = new SqlCommand(updateSql, connection))
                        {
                            cmd.Parameters.AddWithValue("@marka", marka);
                            cmd.Parameters.AddWithValue("@selectedItem", selectedItem);
                            cmd.Parameters.AddWithValue("@MarProductHierarchyLevel01", MarProductHierarchyLevel01);
                            cmd.Parameters.AddWithValue("@MarProductHierarchyLevel02", MarProductHierarchyLevel02);
                            cmd.Parameters.AddWithValue("@MarProductHierarchyLevel03", MarProductHierarchyLevel03);
                            cmd.Parameters.AddWithValue("@MarProductHierarchyLevel04", MarProductHierarchyLevel04);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                using (SqlCommand command = new SqlCommand("select ProductHierarchyID,ProductHierarchyLevel01,ProductHierarchyLevel02,ProductHierarchyLevel03,ProductHierarchyLevel04,Marka,MarProductHierarchyLevel01,MarProductHierarchyLevel02,MarProductHierarchyLevel03,MarProductHierarchyLevel04,Cinsiyet,Alan='' from ZTMSGKategoriListMisigo where MARProductHierarchyLevel01 != '' Group by ProductHierarchyID,ProductHierarchyLevel01,ProductHierarchyLevel02,ProductHierarchyLevel03,ProductHierarchyLevel04,Marka,MarProductHierarchyLevel01,MarProductHierarchyLevel02,MarProductHierarchyLevel03,MarProductHierarchyLevel04,Cinsiyet Order by Marka,MarProductHierarchyLevel01,MarProductHierarchyLevel02,MarProductHierarchyLevel03,MarProductHierarchyLevel04", connection))
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Enter tuşuna basıldığında arama yap
                FilterCheckedListBox();
            }
        }
        private void FilterCheckedListBox( )
        {

            string filterText = textBox1.Text.ToLower();
            DataView dv = new DataView(dt3);

            if (!string.IsNullOrEmpty(filterText))
            {
                dv.RowFilter = string.Format("Hierarji LIKE '%{0}%'", filterText.Replace("'", "''")); // SQL enjeksiyonunu önlemek için
            }
            else
            {
                dv.RowFilter = ""; // Filtre yok
            }

            checkedListBoxControl1.DataSource = dv;
        }
    }
}
