using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ResimDuzenleme
{
    public partial class NebimOzellik : Form
    {
        public NebimOzellik( )
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
                    // burada sütun adı "AttributeCode" olacaktır, kendi sütun adınıza göre değiştirin
                    SelectedValue = dataGridView.Rows[e.RowIndex].Cells["AttributeCode"].Value.ToString();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                };

                Controls.Add(dataGridView);
            }

        }
        private List<string> GetSirketKodlari( )
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            List<string> sirketKodlari = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "select NebimUrunKodu from ZTMSGTicUrunKartiAcma where AnaUrunKodu = @NebimUrunKodu ";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@NebimUrunKodu", AnaUrunKodu);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sirketKodlari.Add(reader["NebimUrunKodu"].ToString());
                        }
                    }
                }
            }

            return sirketKodlari;
        }
        private void LoadNebimOzellikForm( )
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("select AttributeTypeCode, AttributeTypeDescription=MAX(AttributeTypeDescription), Attributecode=MAX(Attributecode) from (SELECT AttributeTypeCode, AttributeTypeDescription, Attributecode = '' FROM ItemAttributeType(N'TR') WHERE ItemTypeCode = 1 AND ItemTypeCode <> 0 and IsBlocked = 0 UNION ALL SELECT AttributeTypeCode, AttributeTypeDescription = '', AttributeCode as Attributecode from ZTMSGTicUrunKartiAcma Left Outer Join ZTMSGTicNebimUrunOzellik on ZTMSGTicNebimUrunOzellik.NebimUrunKodu = ZTMSGTicUrunKartiAcma.NebimUrunKodu where Attributetypecode is not null and ZTMSGTicUrunKartiAcma.AnaUrunKodu = @AnaUrunKodu GROUP BY AttributeTypeCode, AttributeCode) as a GROUP BY AttributeTypeCode", connection))
                {
                    string anaUrunKodu = AnaUrunKodu ?? "";
                    command.Parameters.AddWithValue("@AnaUrunKodu", anaUrunKodu);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        gridControl1.DataSource = dataTable;
                        gridView1.Columns["AttributeTypeCode"].Caption = "Özellik Kodu";
                        gridView1.Columns["AttributeTypeDescription"].Caption = "Tanımı";
                        DevExpress.XtraGrid.Columns.GridColumn newColumn = gridView1.Columns.ColumnByFieldName("Attributecode");

                        if (newColumn == null)
                        {
                            // Yeni sütunu oluştur
                            newColumn = gridView1.Columns.AddField("Attributecode");
                            newColumn.Caption = "Attributecode";
                        }

                        // ButtonEdit için yeni bir düzenleyici oluştur
                        DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit buttonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
                        // Diğer düzenleyici ayarlarını yapabilirsiniz

                        // Düzenleyiciyi sütuna ekle
                        gridView1.Columns["Attributecode"].ColumnEdit = buttonEdit;



                        // ButtonClick event'ini düzenleyiciye bağlayın
                        buttonEdit.ButtonClick += (btnSender, eventArgs) =>
                            {
                                // AttributeTypeCode değerini alın
                                var attributeTypeCode = gridView1.GetFocusedRowCellValue("AttributeTypeCode").ToString();

                                // Formunuzu oluşturun
                                OzellikDetay myForm = new OzellikDetay();

                                // Sorgunuzu çalıştırın ve sonucu formdaki bir kontrolde gösterin.
                                using (SqlConnection connection2 = new SqlConnection(connectionString))
                                {
                                    connection2.Open();
                                    using (SqlCommand command2 = new SqlCommand($"SELECT AttributeCode, AttributeDescription FROM cdItemAttributeDesc WHERE AttributeTypeCode = {attributeTypeCode} AND Langcode ='TR'", connection2))
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
                                    // OzellikDetay formundan seçili değeri alın
                                    var attributeCode = myForm.SelectedValue;

                                    // Ekleme işlemini yapın
                                    using (SqlConnection connection3 = new SqlConnection(connectionString))
                                    {
                                        connection3.Open();
                                        foreach (string sirketKodu in GetSirketKodlari())
                                        {
                                            var nebimUrunKodu = $"{sirketKodu}";

                                            using (SqlCommand command3 = new SqlCommand("INSERT INTO ZTMSGTicNebimUrunOzellik (NebimUrunKodu, AttributeTypeCode, AttributeCode) VALUES (@NebimUrunKodu, @AttributeTypeCode, @AttributeCode)", connection3))
                                            {
                                                command3.Parameters.AddWithValue("@NebimUrunKodu", nebimUrunKodu);
                                                command3.Parameters.AddWithValue("@AttributeTypeCode", attributeTypeCode);
                                                command3.Parameters.AddWithValue("@AttributeCode", attributeCode);

                                                command3.ExecuteNonQuery();
                                            }
                                        }
                                    }

                                    // NebimOzellik formunu yeniden yükle
                                    LoadNebimOzellikForm();
                                }
                            };
                    }
                }
            }
        }

        private void NebimOzellik_Load(object sender, EventArgs e)
        {

            LoadNebimOzellikForm();
        }
    }
}
