using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ResimDuzenleme
{
    public partial class MisigoOzellikEslestir : Form
    {
        public MisigoOzellikEslestir( )
        {
            InitializeComponent();
        }
        public string AnaUrunKodu { get; set; }
        public class OzellikDetay : Form
        {
            public DataGridView dataGridView { get; private set; }
            public string SelectedValue { get; private set; }


            public OzellikDetay( )
            {
                dataGridView = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                };

                dataGridView.CellDoubleClick += (sender, e) =>
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Geçerli bir hücreye tıklanmışsa
                    {
                        SelectedValue = dataGridView.Rows[e.RowIndex].Cells["AttributeTypeDescription"].Value.ToString();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                };

                Controls.Add(dataGridView);
            }

        }
        public class Kategori
        {
            public string DataBaseNebim { get; set; }
            public string ProductAttributeType { get; set; }
            public string ProductAttributeValue { get; set; }
            public string AttributeCode { get; set; } // Bu alan eklendi
        }
        private List<Kategori> GetMisigoKategorileri(string marka)
        {
            // ... (bağlantı bilgileri ve SqlConnection açma kodları aynı)
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            List<Kategori> kategoriListesi = new List<Kategori>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("MSG_MisigoKategoriList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Marka", marka);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Kategori kategori = new Kategori
                            {
                                DataBaseNebim = reader["DataBaseNebim"].ToString(),
                                ProductAttributeType = reader["ProductAttributeType"].ToString(),
                                ProductAttributeValue = reader["ProductAttributeValue"].ToString(),
                                AttributeCode = reader["AttributeCode"].ToString()
                            };
                            kategoriListesi.Add(kategori);
                        }
                    }
                }
            }

            return kategoriListesi;
        }

        private void RefreshGridControl(string marka)
        {
            var kategoriListesi = GetMisigoKategorileri(marka);
            gridControl1.DataSource = kategoriListesi;
        }
        //private void LoadNebimOzellikForm(string marka)
        //{
        //    string serverName = Properties.Settings.Default.SunucuAdi;
        //    string userName = Properties.Settings.Default.KullaniciAdi;
        //    string password = Properties.Settings.Default.Sifre;
        //    string database = Properties.Settings.Default.database;
        //    string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        using (SqlCommand command = new SqlCommand("MSG_MisigoKategoriList", connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@Marka", marka);

        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                DataTable dataTable = new DataTable();
        //                dataTable.Load(reader);
        //                gridControl1.DataSource = dataTable;

        //                // Sütun başlıklarını ayarlayın
        //                gridView1.Columns["ProductAttributeType"].Caption = "Özellik Başlığı";
        //                gridView1.Columns["ProductAttributeValue"].Caption = "Özellik Adı";

        //                // AttributeCode için bir sütun ekleyin (varsa)
        //                DevExpress.XtraGrid.Columns.GridColumn AttributeCodeColumn = gridView1.Columns["AttributeCode"];
        //                if (AttributeCodeColumn == null)
        //                {
        //                    AttributeCodeColumn = gridView1.Columns.AddField("AttributeCode");
        //                    AttributeCodeColumn.Caption = "AttributeCode";
        //                    AttributeCodeColumn.Visible = true;
        //                }

        //                // ButtonEdit düzenleyicisini ayarlayın
        //                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit buttonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
        //                AttributeCodeColumn.ColumnEdit = buttonEdit;

        //                // ButtonClick event'ini düzenleyiciye bağlayın
        //                buttonEdit.ButtonClick += (btnSender, eventArgs) =>
        //                {
        //                    // ... [Burada OzellikDetay formunu açan ve sonucu işleyen kodlarınız] ...
        //                };
        //            }
        //        }
        //    }
        //}
        private void LoadNebimOzellikForm(string marka)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("MSG_MisigoKategoriList", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Marka", marka);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        gridControl1.DataSource = dataTable;
                        gridView1.Columns["ProductAttributeType"].Caption = "Özellik Başlığı";
                        gridView1.Columns["ProductAttributeValue"].Caption = "Özellik Adı";
                        DevExpress.XtraGrid.Columns.GridColumn newColumn = gridView1.Columns.ColumnByFieldName("AttributeCode");

                        if (newColumn == null)
                        {
                            // Yeni sütunu oluştur
                            newColumn = gridView1.Columns.AddField("AttributeCode");
                            newColumn.Caption = "AttributeCode";
                        }

                        // ButtonEdit için yeni bir düzenleyici oluştur
                        DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit buttonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                        // Diğer düzenleyici ayarlarını yapabilirsiniz

                        // Düzenleyiciyi sütuna ekle
                        gridView1.Columns["AttributeCode"].ColumnEdit = buttonEdit;



                        // ButtonClick event'ini düzenleyiciye bağlayın
                        buttonEdit.ButtonClick += (btnSender, eventArgs) =>
                        {
                            if (gridView1.GetFocusedRow() != null)
                            {
                                OzellikDetay myForm = new OzellikDetay();

                                // Sorguyu çalıştırın ve sonucu formdaki bir kontrolde gösterin.
                                using (SqlConnection connection2 = new SqlConnection(connectionString))
                                {
                                    connection2.Open();
                                    using (SqlCommand command2 = new SqlCommand("SELECT AttributeTypeCode, AttributeTypeDescription FROM cdItemAttributeTypeDesc WHERE LangCode = 'TR' AND ItemTypeCode = 1", connection2))
                                    {
                                        using (SqlDataReader reader2 = command2.ExecuteReader())
                                        {
                                            DataTable dataTable2 = new DataTable();
                                            dataTable2.Load(reader2);

                                            // Sonucu formdaki DataGridView'ye bind edin
                                            myForm.dataGridView.DataSource = dataTable2;
                                        }
                                    }
                                }

                                // Formu gösterin
                                if (myForm.ShowDialog() == DialogResult.OK)
                                {
                                    var selectedAttributeTypeCode = myForm.SelectedValue;

                                    if (!string.IsNullOrEmpty(selectedAttributeTypeCode))
                                    {
                                        try
                                        {
                                            using (SqlConnection connection3 = new SqlConnection(connectionString))
                                            {
                                                connection3.Open();
                                                using (SqlCommand command3 = new SqlCommand("INSERT INTO ZTMSGMisigoOzellikEslestir (Marka, FirmaAttributeTypeCode, NebimAttributeTypeCode) VALUES (@Marka, @FirmaAttributeTypeCode, @NebimAttributeTypeCode)", connection3))
                                                {
                                                    var AttributeCode = gridView1.GetFocusedRowCellValue("ProductAttributeValue")?.ToString() ?? string.Empty;

                                                    command3.Parameters.AddWithValue("@Marka", marka);
                                                    command3.Parameters.AddWithValue("@FirmaAttributeTypeCode", AttributeCode);
                                                    command3.Parameters.AddWithValue("@NebimAttributeTypeCode", selectedAttributeTypeCode);

                                                    command3.ExecuteNonQuery();
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Hata: " + ex.Message);
                                        }
                                        RefreshGridControl(marka);
                                    }
                                }
                            }
                        };
                    }
                }
            }
        }
        private void MisigoOzellikEslestir_Load(object sender, EventArgs e)
        {

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT DataBaseNebim FROM ZTMSGMisigoUrunAcmaParametreleri", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["DataBaseNebim"].ToString());
                }

                reader.Close();
                conn.Close();
            }


        }
        private void UpdateGridControl(string selectedMarka)
        {
            List<Kategori> kategoriListesi = GetMisigoKategorileri(selectedMarka);
            gridControl1.DataSource = kategoriListesi;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMarka = comboBox1.SelectedItem.ToString();
            UpdateGridControl(selectedMarka);
            LoadNebimOzellikForm(selectedMarka);
            //LoadNebimOzellikForm(selectedMarka);


        }
    }
}
