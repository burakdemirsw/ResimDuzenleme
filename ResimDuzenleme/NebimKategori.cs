using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ResimDuzenleme
{
    public partial class NebimKategori : Form
    {
        public NebimKategori( )
        {
            InitializeComponent();
        }

        private void NebimKategori_Load(object sender, EventArgs e)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            DataTable dt3 = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "select ProductHierarchyID,Hierarji = Case When ProductHierarchyLevel05 != '' Then ProductHierarchyLevel01 + ' > '+ ProductHierarchyLevel02+ ' > '+ ProductHierarchyLevel03+ ' > '+ ProductHierarchyLevel04+ ' > '+ ProductHierarchyLevel05 Else  Case When  ProductHierarchyLevel04 != '' THEN ProductHierarchyLevel01 + ' > '+ ProductHierarchyLevel02+ ' > '+ ProductHierarchyLevel03+ ' > '+ ProductHierarchyLevel04 Else  Case When ProductHierarchyLevel03 != '' THEN ProductHierarchyLevel01 + ' > '+ ProductHierarchyLevel02+ ' > '+ ProductHierarchyLevel03 Else  Case When ProductHierarchyLevel02 != '' THEN ProductHierarchyLevel01 + ' > '+ ProductHierarchyLevel02 Else  Case When ProductHierarchyLevel01 != '' THEN ProductHierarchyLevel01  else '' END End ENd End End from MSGAllUrunLer  where  ProductHierarchyLevel01 != '' ORder by ProductHierarchyID";

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

                using (SqlCommand command = new SqlCommand("SELECT * FROM ZTMSGTicKategoriler  ORDER BY Marka", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;
                    }
                }
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
                foreach (var selectedItem in selectedItems)
                {
                    // DataGridView'den NebimKategoriID'yi çekmek
                    // Örneğin: dataGridView1'deki NebimKategoriID kolonunun değerini alıyoruz.
                    int selectedIndex = dataGridView1.SelectedCells[0].RowIndex;
                    int nebimKategoriID = (int)dataGridView1.Rows[selectedIndex].Cells["ID"].Value;
                    // Güncelleme işlemi
                    string updateSql = "UPDATE ZTMSGTicKategoriler SET NebimKategoriID = @selectedItem WHERE ID = @nebimKategoriID";

                    using (SqlCommand cmd = new SqlCommand(updateSql, connection))
                    {
                        cmd.Parameters.AddWithValue("@nebimKategoriID", nebimKategoriID);
                        cmd.Parameters.AddWithValue("@selectedItem", selectedItem);

                        cmd.ExecuteNonQuery();
                    }
                }
                using (SqlCommand command = new SqlCommand("SELECT * FROM ZTMSGTicKategoriler  ORDER BY Marka", connection))
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

        private void checkedListBoxControl1_Validated(object sender, EventArgs e)
        {

        }
    }
}
