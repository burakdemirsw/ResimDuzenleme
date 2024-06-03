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
    public partial class NebimBarkod : Form
    {
        public NebimBarkod()
        {
            InitializeComponent();
        }
        public string AnaUrunKodu { get; set; }
        private void Btnbarkod_Click(object sender, EventArgs e)
        {
            
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string Barcode = Properties.Settings.Default.txtBarkodTipi;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";



            // Btnbarkod_Click olayı
            using (SqlConnection connection2 = new SqlConnection(connectionString))
            {
                connection2.Open();

                // DataTable'i alın
                DataTable dataTable = (DataTable)dataGridView1.DataSource;

                // Boş olan hücreleri sayın ve güncelleyin
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(dataTable.Rows[i]["Barcode"].ToString()))
                    {
                        // Stored procedure'ü çalıştırın
                        using (SqlCommand command = new SqlCommand($"exec sp_LastBarcodeNum @BarcodeTypeCode={Barcode}", connection2))
                        {
                            // Barkodu alın
                            string barcode = (string)command.ExecuteScalar();

                            // Güncelleme işlemi için gerekli olan veriyi alın (örneğin, Itemcode)
                            string itemCode = dataTable.Rows[i]["Itemcode"].ToString();
                            string ColorCode = dataTable.Rows[i]["Colorcode"].ToString();
                            string itemdim1code = dataTable.Rows[i]["Itemdim1Code"].ToString();

                            // Güncelleme sorgusunu çalıştırın
                            using (SqlCommand updateCommand = new SqlCommand("UPDATE ZTMSGTicUrunVariant SET Barcode = @Barcode WHERE Itemcode = @Itemcode AND Colorcode = @Colorcode AND Itemdim1code = @Itemdim1code", connection2))
                            {
                                updateCommand.Parameters.AddWithValue("@Barcode", barcode);
                                updateCommand.Parameters.AddWithValue("@Itemcode", itemCode);
                                updateCommand.Parameters.AddWithValue("@ColorCode", ColorCode);
                                updateCommand.Parameters.AddWithValue("@Itemdim1code", itemdim1code);
                                updateCommand.ExecuteNonQuery();
                            }

                            // DataTable'deki hücreyi güncelleyin
                            dataTable.Rows[i]["Barcode"] = barcode;
                        }
                    }
                }

                // DataGridView'i güncelleyin
                dataGridView1.DataSource = dataTable;
            }









        }
        private void LoadNebimOzellikForm()
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // NebimBarkod_Load olayı
                using (SqlCommand command1 = new SqlCommand("select Itemcode, Colorcode, Colordescription, Itemdim1code, Barcode, SirketKodu from ZTMSGTicUrunKartiAcma Left Outer Join ZTMSGTicUrunVariant on ZTMSGTicUrunVariant.Itemcode = ZTMSGTicUrunKartiAcma.NebimUrunKodu where AnaUrunKodu = @AnaUrunKodu and Itemcode is not null Order by Itemcode,SirketKodu", connection))
                {
                    string anaUrunKodu = AnaUrunKodu ?? "";
                    command1.Parameters.AddWithValue("@AnaUrunKodu", anaUrunKodu);
                    using (SqlDataReader reader1 = command1.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader1);
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }
        private void NebimBarkod_Load(object sender, EventArgs e)
        {
            LoadNebimOzellikForm();

        }
    }
}
