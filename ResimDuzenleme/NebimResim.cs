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
using System.IO;

namespace ResimDuzenleme
{
    public partial class NebimResim : Form
    {
        public NebimResim()
        {
            InitializeComponent();
        }
        public string AnaUrunKodu { get; set; }

        public class SirketKodlari
        {
            public string DataBaseNebim { get; set; }
            public string SirketKodu { get; set; }
            public string ResimYolu { get; set; }
        }
        private List<SirketKodlari> GetSirketKodlari()
          
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            List<SirketKodlari> sirketKodlari = new List<SirketKodlari>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT DataBaseNebim,SirketKodu,ResimYolu FROM ZTMSGTicUrunAcmaParametreleri";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {


                        while (reader.Read())
                        {
                            SirketKodlari sirketKod = new SirketKodlari
                            {
                                DataBaseNebim = reader["DataBaseNebim"].ToString(),
                                SirketKodu = reader["SirketKodu"].ToString(),
                                ResimYolu = reader["ResimYolu"].ToString()
                            };

                            sirketKodlari.Add(sirketKod);
                        }
                      
                    }
                }
            }

            return sirketKodlari;
        }
        public class ColorInfo
        {
            public string Colorcode { get; set; }
            public string ColorDescription { get; set; }
        }
        private List<ColorInfo> GetRenkKodlari()
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            List<ColorInfo> renkKodlari = new List<ColorInfo>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "select Colorcode = ISNULL((ColorCode),SPACE(0)),ColorDescription =ISNULL((ColorDescription),SPACE(0)) from ZTMSGTicUrunKartiAcma Left Outer Join ZTMSGTicUrunVariant on ZTMSGTicUrunVariant.Itemcode = ZTMSGTicUrunKartiAcma.NebimUrunKodu where AnaUrunKodu =  @NebimUrunKodu and Colorcode != '' Group by ColorCode,ColorDescription";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@NebimUrunKodu", AnaUrunKodu);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ColorInfo colorInfo = new ColorInfo
                            {
                                Colorcode = reader["Colorcode"].ToString(),
                                ColorDescription = reader["ColorDescription"].ToString()
                            };

                            renkKodlari.Add(colorInfo);
                        }
                    }
                }
            }

            return renkKodlari;
        }
        private void NebimResim_Load(object sender, EventArgs e)
        {
            label2.Text = AnaUrunKodu;
            List<SirketKodlari> sirketKodlari = GetSirketKodlari();

            comboBox2.DataSource = sirketKodlari;
            comboBox2.DisplayMember = "DataBaseNebim";
            comboBox2.ValueMember = "SirketKodu";
            List<ColorInfo> renkKodlari = GetRenkKodlari();

            comboBox1.DataSource = renkKodlari;
            comboBox1.DisplayMember = "ColorDescription";
            comboBox1.ValueMember = "Colorcode";

        }

        private void btnAnaUrun_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen resmi al
                List<SirketKodlari> sirketListesi = GetSirketKodlari();
            
                string selectedSirketKodu = comboBox2.SelectedValue.ToString(); // combobox'tan seçilen sirket kodunu al
                SirketKodlari sirket = sirketListesi.FirstOrDefault(s => s.SirketKodu == selectedSirketKodu);  // Seçilen resmin yolu
                string sourcePath = openFileDialog.FileName;  // Seçilen resmin yolu

                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "select Itemcode,ResimAdi from (select Itemcode,ResimAdi = Itemcode+'_'+Colorcode from ZTMSGTicUrunKartiAcma Left Outer Join ZTMSGTicUrunVariant on ZTMSGTicUrunVariant.Itemcode = ZTMSGTicUrunKartiAcma.NebimUrunKodu where AnaUrunKodu =  @AnaUrunKodu and Colorcode = @Colorcode and NebimUrunKodu like @NebimUrunKodu) as a Group by Itemcode,ResimAdi";

                    using (SqlCommand command2 = new SqlCommand(sql, connection))
                    {
                        command2.Parameters.AddWithValue("@AnaUrunKodu", AnaUrunKodu);
                        command2.Parameters.AddWithValue("@Colorcode", comboBox1.SelectedValue);
                        command2.Parameters.AddWithValue("@NebimUrunKodu", AnaUrunKodu + '-' + comboBox2.SelectedValue.ToString() + "%");

                        using (SqlDataReader reader = command2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string Itemcode = reader["Itemcode"].ToString();
                                // Her bir ResimAdi için, resmi belirtilen klasöre kaydet
                                string targetPath = Path.Combine(sirket.ResimYolu, $"{Itemcode}", "Colorphotos", reader["ResimAdi"].ToString() + ".jpg");
                                File.Copy(sourcePath, targetPath, true);
                            }
                        }
                    }
                }
            }
        }

        private void btnDigerFotograflar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Multiselect = true // birden fazla dosya seçmeye izin ver
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<SirketKodlari> sirketListesi = GetSirketKodlari();
                string selectedSirketKodu = comboBox2.SelectedValue.ToString();
                SirketKodlari sirket = sirketListesi.FirstOrDefault(s => s.SirketKodu == selectedSirketKodu);

                if (sirket == null)
                {
                    MessageBox.Show("Seçilen şirket kodu bulunamadı.");
                    return;
                }

                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "select Itemcode,ResimAdi from (select Itemcode,ResimAdi = Itemcode+'_'+Colorcode from ZTMSGTicUrunKartiAcma Left Outer Join ZTMSGTicUrunVariant on ZTMSGTicUrunVariant.Itemcode = ZTMSGTicUrunKartiAcma.NebimUrunKodu where AnaUrunKodu =  @AnaUrunKodu and Colorcode = @Colorcode and NebimUrunKodu like @NebimUrunKodu) as a Group by Itemcode,ResimAdi";

                    using (SqlCommand command2 = new SqlCommand(sql, connection))
                    {
                        command2.Parameters.AddWithValue("@AnaUrunKodu", AnaUrunKodu);
                        command2.Parameters.AddWithValue("@Colorcode", comboBox1.SelectedValue);
                        command2.Parameters.AddWithValue("@NebimUrunKodu", AnaUrunKodu + '-' + comboBox2.SelectedValue.ToString() + "%");

                        using (SqlDataReader reader = command2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string Itemcode = reader["Itemcode"].ToString();
                                string resimAdi = reader["ResimAdi"].ToString();
                                string colorcode = comboBox1.SelectedValue.ToString(); // Colorcode'yi al

                                // Her bir dosya için
                                for (int i = 0; i < openFileDialog.FileNames.Length; i++)
                                {
                                    // Dosyanın adını belirle
                                    string sourcePath = openFileDialog.FileNames[i];

                                    // Her bir ResimAdi için, resmi belirtilen klasöre kaydet
                                    string targetPath = Path.Combine(sirket.ResimYolu, $"{Itemcode}", "Colorphotos", colorcode, $"{resimAdi}_{i + 1}.jpg");

                                    // Hedef klasörün var olup olmadığını kontrol et, eğer yoksa oluştur
                                    string directoryName = Path.GetDirectoryName(targetPath);
                                    if (!Directory.Exists(directoryName))
                                    {
                                        Directory.CreateDirectory(directoryName);
                                    }

                                    File.Copy(sourcePath, targetPath, true);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
