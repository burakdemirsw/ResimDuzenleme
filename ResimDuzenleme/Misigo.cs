using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.SqlClient;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using CsvHelper;
using System.Globalization;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using DevExpress.XtraReports.UI;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Google.Cloud.Translation.V2;
using System.ServiceProcess;
using System.Diagnostics;
using System.Security.Principal;
using System.Configuration.Install;
//using System.Threading;
using ResimDuzenleme.SiparisServis;
using ResimDuzenleme.UrunServis;
using NUnit.Framework;
using ResimDuzenleme.EArchiveInvoiceWS;
using ResimDuzenleme.Operations;
//using System.Threading;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Net.Http.Headers;
using System.Text.Json;



namespace ResimDuzenleme
{
    public partial class Misigo : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string ipAdresi = Properties.Settings.Default.txtEntegrator;
        private HttpClient httpClient = new HttpClient();
        private System.Timers.Timer timer;
      
        public Misigo()
        {
            InitializeComponent();
     
         

        }


        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmFaturalastirTekli frm = new FrmFaturalastirTekli();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem69_ItemClick(object sender, ItemClickEventArgs e)
        {
            NebimApi frm = new NebimApi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            PhotoDuzenleme frm = new PhotoDuzenleme();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExcelIslemleri frm = new ExcelIslemleri();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExcelIslemleri frm = new ExcelIslemleri();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            GiderPusulasi frm = new GiderPusulasi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmFaturalastir frm = new frmFaturalastir();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            KargoCikis frm = new KargoCikis();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            SatisForm frm = new SatisForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            NebimUrunAcma frm = new NebimUrunAcma();
            frm.MdiParent = this;
            frm.Show();
        }

        //private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    string apiKey = "AIzaSyAL2M8T6ZaxNV3SuMY49sc1RyuJBkiL92M";
        //    string[] targetLanguages = { "EN", "RU", "AR", "FR", "DE" }; // Hedef dillerinizi burada listeleyin

        //    TranslationClient client = TranslationClient.CreateFromApiKey(apiKey);

        //    try
        //    {
        //        // SQL'den verileri al
        //        DataTable dt = VerileriGetir(); // Bu işlevi oluşturmanız gerekecektir.

        //        foreach (DataRow row in dt.Rows)
        //        {
        //            string itemcode = row["Itemcode"].ToString();
        //            string itemdescription = row["Itemdescription"].ToString();

        //            // Her hedef dil için çeviri yap
        //            foreach (string targetLanguage in targetLanguages)
        //            {
        //                CeviriYapVeKaydet(itemcode, targetLanguage, itemdescription, client);
        //            }
        //        }

        //        MessageBox.Show("Çeviriler tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Google.GoogleApiException ex)
        //    {
        //        MessageBox.Show($"Çeviri işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}
        private async void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            string apiKey = "760d30b5-708f-44bc-ab0c-d353a8352f18:fx";
            string[] targetLanguages = { "EN", "RU", "AR", "FR", "DE" }; // Hedef dillerinizi burada listeleyin

            try
            {
                // SQL'den verileri al
                DataTable dt = VerileriGetir(); // Bu işlevi oluşturmanız gerekecektir.

                foreach (DataRow row in dt.Rows)
                {
                    string itemcode = row["Itemcode"].ToString();
                    string itemdescription = row["Itemdescription"].ToString();

                    // Her hedef dil için çeviri yap
                    foreach (string targetLanguage in targetLanguages)
                    {
                        string translatedText = await TranslateTextWithDeepL(itemdescription, targetLanguage, apiKey);
                        CeviriYapVeKaydet(itemcode, targetLanguage, translatedText);
                    }
                }

                MessageBox.Show("Çeviriler tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) // Bu, genel bir hata yakalama örneğidir. İhtiyaçlarınıza göre ayarlayın.
            {
                MessageBox.Show($"Çeviri işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<string> TranslateTextWithDeepL(string text, string targetLang, string apiKey)
        {
            var apiUrl = "https://api-free.deepl.com/v2/translate";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("DeepL-Auth-Key", apiKey);

                var requestBody = new FormUrlEncodedContent(new[]
                {
            new KeyValuePair<string, string>("text", text),
            new KeyValuePair<string, string>("target_lang", targetLang),
              new KeyValuePair<string, string>("domain", "Giyim")
        });

                var response = await client.PostAsync(apiUrl, requestBody);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    // JSON'dan çeviri metnini aşağıdaki gibi parse edin
                    using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
                    {
                        JsonElement root = doc.RootElement;
                        JsonElement translations = root.GetProperty("translations");
                        string translatedText = translations[0].GetProperty("text").GetString();
                        return translatedText;
                    }
                }
                else
                {
                    throw new Exception("Çeviri sırasında bir hata oluştu.");
                }
            }
        }
        private DataTable VerileriGetir()
        {
            // SQL sorgusu ile verilerinizi çekmek için kullanabileceğiniz bir işlevi burada uygulayın.
            // Veritabanı bağlantısı kurun ve gerekli sorguyu çalıştırın.
            // Alınan verileri bir DataTable içinde döndürün.

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Veri çekme SP'sini çağırma
                using (SqlCommand cmd = new SqlCommand("MSG_UrunListe", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        //private void CeviriYapVeKaydet(string itemcode, string langcode, string itemdescription, TranslationClient client)
        //{
        //    // Verilen parametreleri kullanarak çeviriyi yapın ve sonucu SQL'e kaydedin.
        //    // MSG_DilCeviri SP'sini çağırmak için SQL bağlantısı oluşturun ve gerekli parametreleri kullanarak çağırın.

        //    string serverName = Properties.Settings.Default.SunucuAdi;
        //    string userName = Properties.Settings.Default.KullaniciAdi;
        //    string password = Properties.Settings.Default.Sifre;
        //    string database = Properties.Settings.Default.database;
        //    string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();

        //        using (SqlCommand cmd = new SqlCommand("MSG_DilCeviri", connection))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@Itemcode", itemcode);
        //            cmd.Parameters.AddWithValue("@Langcode", langcode);

        //            TranslationResult result = client.TranslateText(itemdescription, langcode);
        //            cmd.Parameters.AddWithValue("@Itemdescription", result.TranslatedText);

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}


        private void CeviriYapVeKaydet(string itemcode, string langcode, string translatedText)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("MSG_DilCeviri", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Itemcode", itemcode);
                    cmd.Parameters.AddWithValue("@Langcode", langcode);
                    cmd.Parameters.AddWithValue("@Itemdescription", translatedText); // Google Translate'den gelen çeviri yerine, DeepL'den gelen çeviri kullanılıyor.

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private DataTable VerileriGetirRenk()
        {
            // SQL sorgusu ile verilerinizi çekmek için kullanabileceğiniz bir işlevi burada uygulayın.
            // Veritabanı bağlantısı kurun ve gerekli sorguyu çalıştırın.
            // Alınan verileri bir DataTable içinde döndürün.

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Veri çekme SP'sini çağırma
                using (SqlCommand cmd = new SqlCommand("MSG_RenkListe", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private void barButtonItem72_ItemClick(object sender, ItemClickEventArgs e)
        {
            string apiKey = "AIzaSyAL2M8T6ZaxNV3SuMY49sc1RyuJBkiL92M";
            string[] targetLanguages = { "EN", "RU", "AR", "FR", "DE" }; // Hedef dillerinizi burada listeleyin

            TranslationClient client = TranslationClient.CreateFromApiKey(apiKey);

            try
            {
                // SQL'den verileri al
                DataTable dt = VerileriGetirRenk(); // Bu işlevi oluşturmanız gerekecektir.

                foreach (DataRow row in dt.Rows)
                {
                    string itemcode = row["ColorCode"].ToString();
                    string itemdescription = row["Colordescription"].ToString();

                    // Her hedef dil için çeviri yap
                    foreach (string targetLanguage in targetLanguages)
                    {
                        CeviriYapVeKaydetRenk(itemcode, targetLanguage, itemdescription, client);
                    }
                }

                MessageBox.Show("Çeviriler tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Google.GoogleApiException ex)
            {
                MessageBox.Show($"Çeviri işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem74_ItemClick(object sender, ItemClickEventArgs e)
        {

            string apiKey = "AIzaSyAL2M8T6ZaxNV3SuMY49sc1RyuJBkiL92M";
            string[] targetLanguages = { "EN", "RU", "AR", "FR", "DE" }; // Hedef dillerinizi burada listeleyin

            TranslationClient client = TranslationClient.CreateFromApiKey(apiKey);

            try
            {
                // SQL'den verileri al
                DataTable dt = VerileriGetirOzellik(); // Bu işlevi oluşturmanız gerekecektir.

                foreach (DataRow row in dt.Rows)
                {
                    string attributeTypeCode = row["AttributeTypeCode"].ToString();
                    string attributeCode = row["AttributeCode"].ToString();
                    string attributeDescription = row["AttributeDescription"].ToString();

                    // Her hedef dil için çeviri yap
                    foreach (string targetLanguage in targetLanguages)
                    {
                        CeviriYapVeKaydetOzellik(attributeTypeCode, attributeCode, targetLanguage, attributeDescription, client);
                    }
                }

                MessageBox.Show("Çeviriler tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Google.GoogleApiException ex)
            {
                MessageBox.Show($"Çeviri işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private DataTable VerileriGetirOzellik()
        {
            // SQL sorgusu ile verilerinizi çekmek için kullanabileceğiniz bir işlevi burada uygulayın.
            // Veritabanı bağlantısı kurun ve gerekli sorguyu çalıştırın.
            // Alınan verileri bir DataTable içinde döndürün.

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Veri çekme SP'sini çağırma
                using (SqlCommand cmd = new SqlCommand("MSG_OzellikListe", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        private void CeviriYapVeKaydetRenk(string itemcode, string langcode, string itemdescription, TranslationClient client)
        {
            // Verilen parametreleri kullanarak çeviriyi yapın ve sonucu SQL'e kaydedin.
            // MSG_DilCeviri SP'sini çağırmak için SQL bağlantısı oluşturun ve gerekli parametreleri kullanarak çağırın.

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("MSG_DilCeviriRenk", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Itemcode", itemcode);
                    cmd.Parameters.AddWithValue("@Langcode", langcode);

                    TranslationResult result = client.TranslateText(itemdescription, langcode);
                    cmd.Parameters.AddWithValue("@Itemdescription", result.TranslatedText);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void CeviriYapVeKaydetOzellik(string attributeTypeCode, string attributeCode, string langcode, string attributeDescription, TranslationClient client)
        {
            // Verilen parametreleri kullanarak çeviriyi yapın ve sonucu SQL'e kaydedin.
            // MSG_DilCeviri SP'sini çağırmak için SQL bağlantısı oluşturun ve gerekli parametreleri kullanarak çağırın.

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("MSG_DilCeviriOzellik", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AttributeTypeCode", attributeTypeCode);
                    cmd.Parameters.AddWithValue("@attributeCode", attributeCode);
                    cmd.Parameters.AddWithValue("@Langcode", langcode);

                    TranslationResult result = client.TranslateText(attributeDescription, langcode);
                    cmd.Parameters.AddWithValue("@Itemdescription", result.TranslatedText);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private DataTable VerileriGetirOzellikTipi()
        {
            // SQL sorgusu ile verilerinizi çekmek için kullanabileceğiniz bir işlevi burada uygulayın.
            // Veritabanı bağlantısı kurun ve gerekli sorguyu çalıştırın.
            // Alınan verileri bir DataTable içinde döndürün.

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Veri çekme SP'sini çağırma
                using (SqlCommand cmd = new SqlCommand("MSG_OzellikTipiListe", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        private void CeviriYapVeKaydetOzellikTipi(string attributeTypeCode, string langcode, string attributeTypeDescription, TranslationClient client)
        {
            // Verilen parametreleri kullanarak çeviriyi yapın ve sonucu SQL'e kaydedin.
            // MSG_DilCeviri SP'sini çağırmak için SQL bağlantısı oluşturun ve gerekli parametreleri kullanarak çağırın.

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("MSG_DilCeviriOzellikTipi", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AttributeTypeCode", attributeTypeCode);

                    cmd.Parameters.AddWithValue("@Langcode", langcode);

                    TranslationResult result = client.TranslateText(attributeTypeDescription, langcode);
                    cmd.Parameters.AddWithValue("@attributeTypeDescription", result.TranslatedText);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void barButtonItem73_ItemClick(object sender, ItemClickEventArgs e)
        {
            string apiKey = "AIzaSyAL2M8T6ZaxNV3SuMY49sc1RyuJBkiL92M";
            string[] targetLanguages = { "EN", "RU", "AR", "FR", "DE" }; // Hedef dillerinizi burada listeleyin

            TranslationClient client = TranslationClient.CreateFromApiKey(apiKey);

            try
            {
                // SQL'den verileri al
                DataTable dt = VerileriGetirOzellikTipi(); // Bu işlevi oluşturmanız gerekecektir.

                foreach (DataRow row in dt.Rows)
                {
                    string attributeTypeCode = row["AttributeTypeCode"].ToString();
                    string attributeTypeDescription = row["AttributeTypeDescription"].ToString();

                    // Her hedef dil için çeviri yap
                    foreach (string targetLanguage in targetLanguages)
                    {
                        CeviriYapVeKaydetOzellikTipi(attributeTypeCode, targetLanguage, attributeTypeDescription, client);
                    }
                }

                MessageBox.Show("Çeviriler tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Google.GoogleApiException ex)
            {
                MessageBox.Show($"Çeviri işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Misigo_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            NebimFaturaList frm = new NebimFaturaList();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmNebimSiparis frm = new FrmNebimSiparis();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmIrsaliyeFaturalastirTekli frm = new FrmIrsaliyeFaturalastirTekli();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExcelIslemleri frm = new ExcelIslemleri();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            NebimSilmeIslemleri frm = new NebimSilmeIslemleri();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Bu İşlem Sizin Lisansınızda bulunmamaktadır.");
        }

        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Bu İşlem Sizin Lisansınızda bulunmamaktadır.");
        }

        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Bu İşlem Sizin Lisansınızda bulunmamaktadır.");
        }

        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            TrendyolSiparisAktar frm = new TrendyolSiparisAktar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
        {
            TrendyolYurtDisiSiparis frm = new TrendyolYurtDisiSiparis();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
        {
            TrendyolResimCek frm = new TrendyolResimCek();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem39_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Bu İşlem Sizin Lisansınızda bulunmamaktadır.");
        }

        private void Akta_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Bu İşlem Sizin Lisansınızda bulunmamaktadır.");
        }

        private void barButtonItem41_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Bu İşlem Sizin Lisansınızda bulunmamaktadır.");
        }

        private void barButtonItem40_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Bu İşlem Sizin Lisansınızda bulunmamaktadır.");
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            TrendyolApi frm = new TrendyolApi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem70_ItemClick(object sender, ItemClickEventArgs e)
        {
            NebimOdemeYontemleri frm = new NebimOdemeYontemleri();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem71_ItemClick(object sender, ItemClickEventArgs e)
        {
            UrunAcmaParametreleri frm = new UrunAcmaParametreleri();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem66_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmKullanicilar frm = new frmKullanicilar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem67_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMagazalar frm = new frmMagazalar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem48_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem49_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem75_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmAlisSiparis frm = new FrmAlisSiparis();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem76_ItemClick(object sender, ItemClickEventArgs e)
        {
            KargoTakip frm = new KargoTakip();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem77_ItemClick(object sender, ItemClickEventArgs e)
        {
            MNGKargo frm = new MNGKargo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem78_ItemClick(object sender, ItemClickEventArgs e)
        {
            DegisimListesi frm = new DegisimListesi();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem79_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem52_ItemClick(object sender, ItemClickEventArgs e)
        {
            MisigoKategoriEslestir frm = new MisigoKategoriEslestir();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem53_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem55_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }
        public static void KategorileriKaydet(List<Kategori> kategoriListesi)
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
                    connection.Open();

                    foreach (Kategori kategori in kategoriListesi)
                    {
                        string query = "INSERT INTO ZTMSGTicimaxKategoriler (ID, Aktif, Icerik, KategoriMenuGoster, Kod, PID, SeoAnahtarKelime, SeoSayfaAciklama, SeoSayfaBaslik, Sira, Tanim, Url) select @ID, @Aktif, @Icerik, @KategoriMenuGoster, @Kod, @PID, @SeoAnahtarKelime, @SeoSayfaAciklama, @SeoSayfaBaslik, @Sira, @Tanim, @Url where @Id not in (Select ID from ZTMSGTicimaxKategoriler)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ID", kategori.ID);
                            command.Parameters.AddWithValue("@Aktif", kategori.Aktif);
                            command.Parameters.AddWithValue("@Icerik", kategori.Icerik ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@KategoriMenuGoster", kategori.KategoriMenuGoster);
                            command.Parameters.AddWithValue("@Kod", kategori.Kod ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@PID", kategori.PID);
                            command.Parameters.AddWithValue("@SeoAnahtarKelime", kategori.SeoAnahtarKelime ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@SeoSayfaAciklama", kategori.SeoSayfaAciklama ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@SeoSayfaBaslik", kategori.SeoSayfaBaslik ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@Sira", kategori.Sira);
                            command.Parameters.AddWithValue("@Tanim", kategori.Tanim ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@Url", kategori.Url ?? (object)DBNull.Value);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Kategoriler başarıyla kaydedildi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanına kayıt sırasında bir hata oluştu: " + ex.Message);
                }
            }
        }

      

        private void barButtonItem80_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<Kategori> KategoriListe = UrunServiceMethods.SelectKategori();

            if (KategoriListe != null && KategoriListe.Count > 0)
            {
                KategorileriKaydet(KategoriListe);
            }
            else
            {


                MessageBox.Show("Siparişler Çekilemedi Tekrar deneyin.");
                // Sipariş listesi alınamadıysa uygun bir hata mesajı göster

            }

        }

        private void barButtonItem81_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<Kategori> KategoriListe = UrunServiceMethods.SelectKategori();

            
            int eklenenKategoriId = UrunServiceMethods.SaveKategori();
            MessageBox.Show("Kategori Aktarımı Tamamlandı...");
        }

        private void barButtonItem82_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<UrunKarti> UrunListe = UrunServiceMethods.SelectUrun();
        }





























        private void barButtonItem83_ItemClick(object sender, ItemClickEventArgs e)
        {
            UrunServiceMethods.SaveUrun();
        }

        private void barButtonItem84_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<Varyasyon> UrunListe = UrunServiceMethods.SelectVaryasyon();
        }
        private async Task<List<Stok>> MSGVeritabanindaStokEkle(string Firma)
        {
            List<Stok> stoks = new List<Stok>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("MSGNebim_SayimEkle", conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Stok stok = new Stok();

                    stok.ModelType = reader["ModelType"].ToString();
                    stok.OfficeCode = reader["OfficeCode"].ToString();
                    stok.StoreCode = reader["StoreCode"].ToString();
                    stok.WarehouseCode = reader["WarehouseCode"].ToString();
                    stok.CompanyCode = Convert.ToInt32(reader["CompanyCode"]);
                    stok.InnerProcessType = Convert.ToInt32(reader["InnerProcessType"]);


                    string LinesJson = reader["Lines"].ToString();
                    JArray variantArray = JArray.Parse(LinesJson);
                    stok.Lines = variantArray.ToObject<List<Lines>>();



                    // Diğer alanları doldurmak için benzer işlemler...

                    stoks.Add(stok);
                }
            }




            return stoks;
        }
        private async Task<List<Stok>> MSGVeritabanindaStokCikar(string Firma)
        {
            List<Stok> stoks = new List<Stok>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("MSGNebim_SayimCikar", conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Stok stok = new Stok();

                    stok.ModelType = reader["ModelType"].ToString();
                    stok.OfficeCode = reader["OfficeCode"].ToString();
                    stok.StoreCode = reader["StoreCode"].ToString();
                    stok.WarehouseCode = reader["WarehouseCode"].ToString();
                    stok.CompanyCode = Convert.ToInt32(reader["CompanyCode"]);
                    stok.InnerProcessType = Convert.ToInt32(reader["InnerProcessType"]);


                    string LinesJson = reader["Lines"].ToString();
                    JArray variantArray = JArray.Parse(LinesJson);
                    stok.Lines = variantArray.ToObject<List<Lines>>();



                    // Diğer alanları doldurmak için benzer işlemler...

                    stoks.Add(stok);
                }
            }




            return stoks;
        }
        private async Task<List<Stok>> MSGVeritabanindaStokCikartemizle(string Firma)
        {
            List<Stok> stoks = new List<Stok>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("MSGNebim_SayimCikartemizle", conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Stok stok = new Stok();

                    stok.ModelType = reader["ModelType"].ToString();
                    stok.OfficeCode = reader["OfficeCode"].ToString();
                    stok.StoreCode = reader["StoreCode"].ToString();
                    stok.WarehouseCode = reader["WarehouseCode"].ToString();
                    stok.CompanyCode = Convert.ToInt32(reader["CompanyCode"]);
                    stok.InnerProcessType = Convert.ToInt32(reader["InnerProcessType"]);


                    string LinesJson = reader["Lines"].ToString();
                    JArray variantArray = JArray.Parse(LinesJson);
                    stok.Lines = variantArray.ToObject<List<Lines>>();



                    // Diğer alanları doldurmak için benzer işlemler...

                    stoks.Add(stok);
                }
            }




            return stoks;
        }

        private async Task<List<FaturaBilgisi>> GetFaturaBilgileriFromDatabasee()
        {
            List<FaturaBilgisi> faturaBilgileri = new List<FaturaBilgisi>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("MSG_GetOrderForInvoiceToplu_DB", conn);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    FaturaBilgisi Firma = new FaturaBilgisi();
                    Firma.DataBaseNebim = reader["DataBaseNebim"].ToString();
                    Firma.IpAdres = reader["IpAdres"].ToString();
                    Firma.Firma = reader["Firma"].ToString();
                    faturaBilgileri.Add(Firma);
                }
            }
            // Her bir satır için FaturaBilgisi nesnesi oluşturup listeye ekleyin
            return faturaBilgileri;
        }
        private async Task<string> ConnectIntegrator(string IpAdres)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync("http://" + IpAdres + "/IntegratorService/Connect");

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                VM_HttpConnectionRequest session = JsonConvert.DeserializeObject<VM_HttpConnectionRequest>(responseBody);

                string sessionId = session.SessionId;
                // Console.WriteLine(responseBody);
                return sessionId;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP isteği başarısız: {ex.Message}");
                return null;
            }
        }
       private async void  SayimCikar()
        {
            List<FaturaBilgisi> faturaBilgileri = await GetFaturaBilgileriFromDatabasee();
            try
            {
                foreach (var faturaBilgisi in faturaBilgileri)
                {
                    //string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                    //List<ZtNebimFaturaROnline> items = await VeritabanindanMusteriGetirFaturaROnline(faturaBilgisi.Firma);

                    int totalRepeatCount = 1; // Toplam tekrar sayısı

                    for (int repeat = 0; repeat < totalRepeatCount; repeat++)
                    {
                        string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                        List<Stok> items = await MSGVeritabanindaStokCikar(faturaBilgisi.Firma);

                        //var currentBatch = items.Skip(repeat * batchSize).Take(batchSize).ToList();
                        //labelStatus.Text = $"Veritabanından {items.Count} adet veri çekildi. Şimdi POST işlemi başlatılıyor...";
                        int postCount = 0;
                        try
                        {
                            var tasks = items.Select(async item =>
                            {
                                string json = JsonConvert.SerializeObject(item);
                                try
                                {
                                    string serverName = Properties.Settings.Default.SunucuAdi;
                                    string userName = Properties.Settings.Default.KullaniciAdi;
                                    string password = Properties.Settings.Default.Sifre;
                                    string database = Properties.Settings.Default.database;
                                    string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

                                    string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                                    var response = await httpClient.PostAsync($"http://{faturaBilgisi.IpAdres}/(S({sessionID}))/IntegratorService/post?", content);

                                    if (response.IsSuccessStatusCode)
                                    {
                                        postCount++;
                                        //var result = await response.Content.ReadAsStringAsync();
                                        var result = await response.Content.ReadAsStringAsync();
                                        Console.WriteLine("Sunucu Yanıtı: " + result); // Sunucu yanıtını yazdır
                                        dynamic jsonResponse = JsonConvert.DeserializeObject(result);

                                    }
                                    else
                                    {
                                        postCount++;
                                        //var result = await response.Content.ReadAsStringAsync();
                                        var result = await response.Content.ReadAsStringAsync();
                                        Console.WriteLine("Sunucu Yanıtı: " + result); // Sunucu yanıtını yazdır
                                        dynamic jsonResponse = JsonConvert.DeserializeObject(result);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Hata: {ex.ToString()}");  // Daha detaylı hata bilgisi
                                }
                            }).ToList();

                            await Task.WhenAll(tasks);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message, "Hata Alındı Tekrar Faturalaştır Tuşuna basınız.");

                        }





                        // Eğer miktar 0'dan büyükse, işlemlere devam edin
                        //     labelStatus.Text = $"İşlem devam ediyor, kalan miktar: {miktar}";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Hata Alındı Tekrar Faturalaştır Tuşuna basınız.");

            }
      
        }


        private async void SayimTemizle()
        {
            List<FaturaBilgisi> faturaBilgileri = await GetFaturaBilgileriFromDatabasee();
            try
            {
                foreach (var faturaBilgisi in faturaBilgileri)
                {
                    //string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                    //List<ZtNebimFaturaROnline> items = await VeritabanindanMusteriGetirFaturaROnline(faturaBilgisi.Firma);

                    int totalRepeatCount = 1; // Toplam tekrar sayısı

                    for (int repeat = 0; repeat < totalRepeatCount; repeat++)
                    {
                        string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                        List<Stok> items = await MSGVeritabanindaStokCikartemizle(faturaBilgisi.Firma);

                        //var currentBatch = items.Skip(repeat * batchSize).Take(batchSize).ToList();
                        //labelStatus.Text = $"Veritabanından {items.Count} adet veri çekildi. Şimdi POST işlemi başlatılıyor...";
                        int postCount = 0;
                        try
                        {
                            var tasks = items.Select(async item =>
                            {
                                string json = JsonConvert.SerializeObject(item);
                                try
                                {
                                    string serverName = Properties.Settings.Default.SunucuAdi;
                                    string userName = Properties.Settings.Default.KullaniciAdi;
                                    string password = Properties.Settings.Default.Sifre;
                                    string database = Properties.Settings.Default.database;
                                    string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

                                    string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                                    var response = await httpClient.PostAsync($"http://{faturaBilgisi.IpAdres}/(S({sessionID}))/IntegratorService/post?", content);

                                    if (response.IsSuccessStatusCode)
                                    {
                                        postCount++;
                                        //var result = await response.Content.ReadAsStringAsync();
                                        var result = await response.Content.ReadAsStringAsync();
                                        Console.WriteLine("Sunucu Yanıtı: " + result); // Sunucu yanıtını yazdır
                                        dynamic jsonResponse = JsonConvert.DeserializeObject(result);

                                    }
                                    else
                                    {
                                        postCount++;
                                        //var result = await response.Content.ReadAsStringAsync();
                                        var result = await response.Content.ReadAsStringAsync();
                                        Console.WriteLine("Sunucu Yanıtı: " + result); // Sunucu yanıtını yazdır
                                        dynamic jsonResponse = JsonConvert.DeserializeObject(result);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Hata: {ex.ToString()}");  // Daha detaylı hata bilgisi
                                }
                            }).ToList();

                            await Task.WhenAll(tasks);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message, "Hata Alındı Tekrar Faturalaştır Tuşuna basınız.");

                        }





                        // Eğer miktar 0'dan büyükse, işlemlere devam edin
                        //     labelStatus.Text = $"İşlem devam ediyor, kalan miktar: {miktar}";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Hata Alındı Tekrar Faturalaştır Tuşuna basınız.");

            }

        }


        private async void SayimEkle()
        {
            List<FaturaBilgisi> faturaBilgileri = await GetFaturaBilgileriFromDatabasee();
            try
            {
                foreach (var faturaBilgisi in faturaBilgileri)
                {
                    //string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                    //List<ZtNebimFaturaROnline> items = await VeritabanindanMusteriGetirFaturaROnline(faturaBilgisi.Firma);

                    int totalRepeatCount = 1; // Toplam tekrar sayısı

                    for (int repeat = 0; repeat < totalRepeatCount; repeat++)
                    {
                        string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                        List<Stok> items = await MSGVeritabanindaStokEkle(faturaBilgisi.Firma);

                        //var currentBatch = items.Skip(repeat * batchSize).Take(batchSize).ToList();
                        //labelStatus.Text = $"Veritabanından {items.Count} adet veri çekildi. Şimdi POST işlemi başlatılıyor...";
                        int postCount = 0;
                        try
                        {
                            var tasks = items.Select(async item =>
                            {
                                string json = JsonConvert.SerializeObject(item);
                                try
                                {
                                    string serverName = Properties.Settings.Default.SunucuAdi;
                                    string userName = Properties.Settings.Default.KullaniciAdi;
                                    string password = Properties.Settings.Default.Sifre;
                                    string database = Properties.Settings.Default.database;
                                    string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

                                    string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                                    var response = await httpClient.PostAsync($"http://{faturaBilgisi.IpAdres}/(S({sessionID}))/IntegratorService/post?", content);

                                    if (response.IsSuccessStatusCode)
                                    {
                                        postCount++;
                                        //var result = await response.Content.ReadAsStringAsync();
                                        var result = await response.Content.ReadAsStringAsync();
                                        Console.WriteLine("Sunucu Yanıtı: " + result); // Sunucu yanıtını yazdır
                                        dynamic jsonResponse = JsonConvert.DeserializeObject(result);


                                    }
                                    else
                                    {
                                        postCount++;
                                        //var result = await response.Content.ReadAsStringAsync();
                                        var result = await response.Content.ReadAsStringAsync();
                                        Console.WriteLine("Sunucu Yanıtı: " + result); // Sunucu yanıtını yazdır
                                        dynamic jsonResponse = JsonConvert.DeserializeObject(result);

                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Hata: {ex.ToString()}");  // Daha detaylı hata bilgisi
                                }
                            }).ToList();

                            await Task.WhenAll(tasks);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message, "Hata Alındı Tekrar Faturalaştır Tuşuna basınız.");

                        }





                        // Eğer miktar 0'dan büyükse, işlemlere devam edin
                        //     labelStatus.Text = $"İşlem devam ediyor, kalan miktar: {miktar}";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Hata Alındı Tekrar Faturalaştır Tuşuna basınız.");

            }
        }
        public static void ServisDurum(string ServisAdi, string Durumu)
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
                    connection.Open();

                    string query2 = "Delete ZTMSGServis where ServisAdi= @ServisAdi";

                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                        command.Parameters.AddWithValue("@ServisAdi", ServisAdi);


                        command.ExecuteNonQuery();
                    }

                    string query = "Insert Into ZTMSGServis(ServisAdi,ServisCalismaTarihi,Durumu) Select @ServisAdi, GETDATE(),@Durumu";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ServisAdi", ServisAdi);
                        command.Parameters.AddWithValue("@Durumu", @Durumu);

                        command.ExecuteNonQuery();
                    }


                    MessageBox.Show("Servis başarıyla kaydedildi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanına kayıt sırasında bir hata oluştu: " + ex.Message);
                }
            }
        }
        private bool isGreen = false;
     
        private void InitializeTimer()
        {
            // Timer oluştur
            timer = new System.Timers.Timer();
            timer.Interval = 1 * 60 * 10000; // 5 dakika
            timer.Elapsed += TimerElapsed;
            timer.AutoReset = true; // Otomatik tekrar et
            timer.Enabled = true; // Timer'ı başlat
        }
        private void InitializeTimer2()
        {
            // Timer oluştur
            timer = new System.Timers.Timer();
            timer.Interval = 1 * 60 * 10000; // 5 dakika
            timer.Elapsed += TimerElapsed2;
            timer.AutoReset = true; // Otomatik tekrar et
            timer.Enabled = true; // Timer'ı başlat
        }

        private void InitializeTimerSiparis()
        {
            // Timer oluştur
            timer = new System.Timers.Timer();
            timer.Interval = 1 * 60 * 10000; // 5 dakika
            timer.Elapsed += TimerElapsedSiparis;
            timer.AutoReset = true; // Otomatik tekrar et
            timer.Enabled = true; // Timer'ı başlat
        }
        private void InitializeTimerIrsaliye()
        {
            // Timer oluştur
            timer = new System.Timers.Timer();
            timer.Interval = 1 * 60 * 10000; // 5 dakika
            timer.Elapsed += TimerElapsedIrsaliye;
            timer.AutoReset = true; // Otomatik tekrar et
            timer.Enabled = true; // Timer'ı başlat
        }
        private void InitializeTimerKoctas()
        {
            // Timer oluştur
            timer = new System.Timers.Timer();
            timer.Interval = 1 * 60 * 10000; // 5 dakika
            timer.Elapsed += TimerElapsedKoctas;
            timer.AutoReset = true; // Otomatik tekrar et
            timer.Enabled = true; // Timer'ı başlat
        }
        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {


            try
            {
                SayimTemizle();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Sayim Çıkarırken hata oluştu" + ex.Message);
            }
            try
            {
                SayimCikar();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Sayim Çıkarırken hata oluştu"+ex.Message);
            }



            try
            {
                SayimEkle();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Sayim Eklerken hata oluştu" + ex.Message);
            }

        

        }
        private void TimerElapsed2(object sender, System.Timers.ElapsedEventArgs e)
        {
            SiparisTopluCek();

        }



        private void TimerElapsedSiparis(object sender, System.Timers.ElapsedEventArgs e)
        {
            FrmNebimSiparis frm = new FrmNebimSiparis();
            frm.TopluFaturalastir();

        }


        private void TimerElapsedIrsaliye(object sender, System.Timers.ElapsedEventArgs e)
        {
            Magaza frm = new Magaza();
            frm.IrsaliyeFaturalastir();

        }


        private void TimerElapsedKoctas(object sender, System.Timers.ElapsedEventArgs e)
        {
            FrmNebimSiparis frm = new FrmNebimSiparis();
            frm.KoctasCek();

        }


        private void barButtonItem85_ItemClick(object sender, ItemClickEventArgs e)
        {
            string Durumu;
            Durumu = "False";
            string ServisAdi;
            ServisAdi = "Nebim Stok Eşitle";
            if (isGreen == false )
            {
                barButtonItem85.Appearance.BackColor = Color.Green;
                isGreen = true;
                Durumu = "true";
                ServisDurum(ServisAdi, Durumu);
                //timer.Enabled = true;
                InitializeTimer();
            }
            else
            {
                barButtonItem85.Appearance.BackColor = Color.Red;
                isGreen = false;
                Durumu = "false";
                ServisDurum(ServisAdi, Durumu);
                timer.Stop();
            }
        
        }

        private void barButtonItem29_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem86_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem87_ItemClick(object sender, ItemClickEventArgs e)
        {

            SayimTemizle();
            SayimCikar();
        }

        private void barButtonItem88_ItemClick(object sender, ItemClickEventArgs e)
        {
            SayimEkle();
        }

        private void barButtonItem89_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExcelIslemleri frm = new ExcelIslemleri();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem90_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExcelIslemleri frm = new ExcelIslemleri();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem91_ItemClick(object sender, ItemClickEventArgs e)
        {
            ExcelIslemleri frm = new ExcelIslemleri();
            frm.MdiParent = this;
            frm.Show();
        }

        private async void barButtonItem95_ItemClick(object sender, ItemClickEventArgs e)
        {
            string apiKey = "760d30b5-708f-44bc-ab0c-d353a8352f18:fx";
            string[] targetLanguages = { "EN", "RU", "AR", "FR", "DE" }; // Hedef dillerinizi burada listeleyin

            try
            {
                // SQL'den verileri al
                DataTable dt = VerileriGetir(); // Bu işlevi oluşturmanız gerekecektir.

                foreach (DataRow row in dt.Rows)
                {
                    string itemcode = row["Itemcode"].ToString();
                    string itemdescription = row["Itemdescription"].ToString();

                    // Her hedef dil için çeviri yap
                    foreach (string targetLanguage in targetLanguages)
                    {
                        string translatedText = await TranslateTextWithDeepL(itemdescription, targetLanguage, apiKey);
                        CeviriYapVeKaydet(itemcode, targetLanguage, translatedText);
                    }
                }

                MessageBox.Show("Çeviriler tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) // Bu, genel bir hata yakalama örneğidir. İhtiyaçlarınıza göre ayarlayın.
            {
                MessageBox.Show($"Çeviri işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem96_ItemClick(object sender, ItemClickEventArgs e)
        {
            string apiKey = "AIzaSyAL2M8T6ZaxNV3SuMY49sc1RyuJBkiL92M";
            string[] targetLanguages = { "EN", "RU", "AR", "FR", "DE" }; // Hedef dillerinizi burada listeleyin

            TranslationClient client = TranslationClient.CreateFromApiKey(apiKey);

            try
            {
                // SQL'den verileri al
                DataTable dt = VerileriGetirRenk(); // Bu işlevi oluşturmanız gerekecektir.

                foreach (DataRow row in dt.Rows)
                {
                    string itemcode = row["ColorCode"].ToString();
                    string itemdescription = row["Colordescription"].ToString();

                    // Her hedef dil için çeviri yap
                    foreach (string targetLanguage in targetLanguages)
                    {
                        CeviriYapVeKaydetRenk(itemcode, targetLanguage, itemdescription, client);
                    }
                }

                MessageBox.Show("Çeviriler tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Google.GoogleApiException ex)
            {
                MessageBox.Show($"Çeviri işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem97_ItemClick(object sender, ItemClickEventArgs e)
        {
            string apiKey = "AIzaSyAL2M8T6ZaxNV3SuMY49sc1RyuJBkiL92M";
            string[] targetLanguages = { "EN", "RU", "AR", "FR", "DE" }; // Hedef dillerinizi burada listeleyin

            TranslationClient client = TranslationClient.CreateFromApiKey(apiKey);

            try
            {
                // SQL'den verileri al
                DataTable dt = VerileriGetirOzellikTipi(); // Bu işlevi oluşturmanız gerekecektir.

                foreach (DataRow row in dt.Rows)
                {
                    string attributeTypeCode = row["AttributeTypeCode"].ToString();
                    string attributeTypeDescription = row["AttributeTypeDescription"].ToString();

                    // Her hedef dil için çeviri yap
                    foreach (string targetLanguage in targetLanguages)
                    {
                        CeviriYapVeKaydetOzellikTipi(attributeTypeCode, targetLanguage, attributeTypeDescription, client);
                    }
                }

                MessageBox.Show("Çeviriler tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Google.GoogleApiException ex)
            {
                MessageBox.Show($"Çeviri işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem98_ItemClick(object sender, ItemClickEventArgs e)
        {

            string apiKey = "AIzaSyAL2M8T6ZaxNV3SuMY49sc1RyuJBkiL92M";
            string[] targetLanguages = { "EN", "RU", "AR", "FR", "DE" }; // Hedef dillerinizi burada listeleyin

            TranslationClient client = TranslationClient.CreateFromApiKey(apiKey);

            try
            {
                // SQL'den verileri al
                DataTable dt = VerileriGetirOzellik(); // Bu işlevi oluşturmanız gerekecektir.

                foreach (DataRow row in dt.Rows)
                {
                    string attributeTypeCode = row["AttributeTypeCode"].ToString();
                    string attributeCode = row["AttributeCode"].ToString();
                    string attributeDescription = row["AttributeDescription"].ToString();

                    // Her hedef dil için çeviri yap
                    foreach (string targetLanguage in targetLanguages)
                    {
                        CeviriYapVeKaydetOzellik(attributeTypeCode, attributeCode, targetLanguage, attributeDescription, client);
                    }
                }

                MessageBox.Show("Çeviriler tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Google.GoogleApiException ex)
            {
                MessageBox.Show($"Çeviri işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void barButtonItem99_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        private void ShowHtmlFromBase64(string base64String)
        {
            // Base64 string'ini byte dizisine çevir ve string'e dönüştür
            byte[] htmlBytes = Convert.FromBase64String(base64String);
            string htmlContent = Encoding.UTF8.GetString(htmlBytes);

            // HTML içeriğini WebBrowser kontrolünde göster

        }

        private async Task<List<ZtNebimFaturaRShipment>> VeritabanindanMusteriGetirFaturaR(string Firma)
        {

            try
            {
                List<ZtNebimFaturaRShipment> musteriler = new List<ZtNebimFaturaRShipment>();
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;
                string storecode = Properties.Settings.Default.StoreCode;

                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    await conn.OpenAsync();
                    SqlCommand command = new SqlCommand("MSG_GetOrderForInvoiceToplu_RShipment", conn);

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Firma", storecode);

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        ZtNebimFaturaRShipment musteri = new ZtNebimFaturaRShipment();
                        musteri.ModelType = Convert.ToInt32(reader["ModelType"]);
                        musteri.CustomerCode = reader["CustomerCode"].ToString();
                        musteri.OfficeCode = reader["OfficeCode"].ToString();
                        musteri.StoreCode = reader["StoreCode"].ToString();
                        musteri.WarehouseCode = reader["WarehouseCode"].ToString();
                        musteri.DeliveryCompanyCode = reader["DeliveryCompanyCode"].ToString(); // Direk string olarak atandı
                        musteri.BillingPostalAddressID = reader["BillingPostalAddressID"].ToString();
                        musteri.ShippingPostalAddressID = reader["ShippingPostalAddressID"].ToString(); // Direk string olarak atandı
                        musteri.PosTerminalID = Convert.ToInt32(reader["PosTerminalID"]); // int'e çevirildi
                        musteri.TaxExemptionCode = Convert.ToInt32(reader["TaxExemptionCode"]); // int'e çevirildi
                        musteri.ShipmentMethodCode = Convert.ToInt32(reader["ShipmentMethodCode"]); // int'e çevirildi
                        musteri.SendInvoiceByEMail = bool.Parse(reader["SendInvoiceByEMail"].ToString());
                        musteri.EMailAddress = reader["EMailAddress"].ToString();

                        musteri.IsShipmentBase = bool.Parse(reader["IsShipmentBase"].ToString());
                        if (reader["Invoicedate"] != DBNull.Value)
                        {
                            musteri.Invoicedate = Convert.ToDateTime(reader["Invoicedate"]); // DateTime'a çevirildi
                        }
                        musteri.IsSalesViaInternet = bool.Parse(reader["IsSalesViaInternet"].ToString());

                        musteri.Description = reader["Description"].ToString();
                        musteri.InternalDescription = reader["InternalDescription"].ToString();

                        //   musteri.CustomerTypeCode = Convert.ToInt32(reader["CustomerTypeCode"]);

                        string LinesJson = reader["Lines"].ToString();
                        JArray LinesArray = JArray.Parse(LinesJson);
                        musteri.Lines = LinesArray.ToObject<List<InvoiceLinesss>>();


                        string PostalAddressJson = reader["PostalAddress"].ToString();
                        //JArray PostalAddressArray = JArray.Parse(PostalAddressJson);
                        musteri.PostalAddress = JsonConvert.DeserializeObject<PostalAddress>(PostalAddressJson);



                        string SalesViaInternetInfosJson = reader["SalesViaInternetInfo"].ToString();
                        JArray SalesViaInternetInfoArray = JArray.Parse(SalesViaInternetInfosJson);
                        musteri.SalesViaInternetInfo = SalesViaInternetInfoArray.ToObject<List<SalesViaInternetInfo>>().First();


                    

                        //string attributesJson = reader["Attributes"].ToString();
                        //JArray attributesArray = JArray.Parse(attributesJson);
                        //musteri.Attributes = attributesArray.ToObject<List<Attribute>>();


                        musteri.IsCompleted = bool.Parse(reader["IsCompleted"].ToString());
                        musteriler.Add(musteri);
                    }
                }

                return musteriler;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata Alındı");
                return null;
            }

        }

        private async Task<int> GetOrderForInvoiceToplamAsync()
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("MSG_GetOrderForInvoiceToplu_REOnlineToplam", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Eğer SP parametre alıyorsa, burada parametreleri ekleyin.
                    // cmd.Parameters.AddWithValue("@ParamName", value);

                    var returnValue = await cmd.ExecuteScalarAsync();
                    return Convert.ToInt32(returnValue);
                }
            }
        }

        private async void barButtonItem100_ItemClick(object sender, ItemClickEventArgs e)
        {



            labelStatus.Text = "Fatura Aktarımı Başladı...";
            List<FaturaBilgisi> faturaBilgileri = await GetFaturaBilgileriFromDatabasee();

            foreach (var faturaBilgisi in faturaBilgileri)
            {
                //string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                //List<ZtNebimFaturaROnline> items = await VeritabanindanMusteriGetirFaturaROnline(faturaBilgisi.Firma);

                int totalRepeatCount = 30; // Toplam tekrar sayısı

                for (int repeat = 0; repeat < totalRepeatCount; repeat++)
                {
                    string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                    List<ZtNebimFaturaRShipment> items = await VeritabanindanMusteriGetirFaturaR(faturaBilgisi.Firma);

                    //var currentBatch = items.Skip(repeat * batchSize).Take(batchSize).ToList();
                    labelStatus.Text = $"Veritabanından {items.Count} adet veri çekildi. Şimdi POST işlemi başlatılıyor...";
                    int postCount = 0;
                    var tasks = items.Select(async item =>
                    {
                        string json = JsonConvert.SerializeObject(item);
                        try
                        {
                            string serverName = Properties.Settings.Default.SunucuAdi;
                            string userName = Properties.Settings.Default.KullaniciAdi;
                            string password = Properties.Settings.Default.Sifre;
                            string database = Properties.Settings.Default.database;
                            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

                            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                            var content = new StringContent(json, Encoding.UTF8, "application/json");
                            var response = await httpClient.PostAsync($"http://{faturaBilgisi.IpAdres}/(S({sessionID}))/IntegratorService/post?", content);

                            if (response.IsSuccessStatusCode)
                            {
                                postCount++;
                                //var result = await response.Content.ReadAsStringAsync();
                             


                                using (SqlConnection conn = new SqlConnection(connectionString))
                                {
                                    string query = "INSERT INTO ZTMSGTicSiparisKontrol (FaturaNo,Request,Cevap) VALUES (@FaturaNo,@Request,@Cevap)";
                                    using (SqlCommand cmd = new SqlCommand(query, conn))
                                    {
                                        var result = await response.Content.ReadAsStringAsync();
                                        dynamic jsonResponse = JsonConvert.DeserializeObject(result);

                                        cmd.Parameters.AddWithValue("@FaturaNo", item.CustomerCode);
                                        cmd.Parameters.AddWithValue("@Request", json);
                                        cmd.Parameters.AddWithValue("@Cevap", "Aktarım Başarılı");
                                        //cmd.Parameters.Add(new SqlParameter("@Request", SqlDbType.NVarChar, -1) { Value = json });
                                        //cmd.Parameters.Add(new SqlParameter("@Cevap", SqlDbType.NVarChar, -1) { Value = jsonResponse });

                                      
                                        conn.Open();
                                        cmd.ExecuteNonQuery();

                                        if (jsonResponse != null && jsonResponse.UnofficialInvoiceString != null)
                                        {

                                            ShowHtmlFromBase64(jsonResponse.UnofficialInvoiceString.ToString());
                                        }
                                    }
                                }

                            }
                            else
                            {
                                postCount++;
                                //var result = await response.Content.ReadAsStringAsync();
                                labelStatus.Text = $"POST işlemi {postCount}/{items.Count} veri için tamamlandı...";

                                using (SqlConnection conn = new SqlConnection(connectionString))
                                {
                                    string query = "INSERT INTO ZTMSGTicSiparisKontrol (FaturaNo,Request,Cevap) VALUES (@FaturaNo,@Request,@Cevap)";
                                    using (SqlCommand cmd = new SqlCommand(query, conn))
                                    {
                                        var result = await response.Content.ReadAsStringAsync();
                                        cmd.Parameters.AddWithValue("@FaturaNo", item.CustomerCode);
                                        cmd.Parameters.AddWithValue("@Request", json);
                                        cmd.Parameters.AddWithValue("@Cevap", result);

                                        conn.Open();
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                labelStatus.Text = $"POST işlemi başarısız: {response.StatusCode}";
                            }
                        }
                        catch (Exception ex)
                        {
                            labelStatus.Text = $"Hata: {ex.ToString()}";  // Daha detaylı hata bilgisi
                        }
                    }).ToList();

                    await Task.WhenAll(tasks);



                    int miktar = await GetOrderForInvoiceToplamAsync();
                    if (miktar == 0)
                    {
                        labelStatus.Text = "İşlem tamamlandı, daha fazla fatura bulunamadı.";
                        break; // Döngüyü sonlandır
                    }

                    // Eğer miktar 0'dan büyükse, işlemlere devam edin
                    //     labelStatus.Text = $"İşlem devam ediyor, kalan miktar: {miktar}";
                }
            }
        }

        private void barButtonItem28_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem26_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem58_ItemClick(object sender, ItemClickEventArgs e)
        {


            string Durumu;
            Durumu = "False";
            string ServisAdi;
            ServisAdi = "Toplu Siparis Çek";
            if (isGreen == false)
            {
                barButtonItem58.Appearance.BackColor = Color.Green;
                isGreen = true;
                Durumu = "true";
                ServisDurum(ServisAdi, Durumu);
                //timer.Enabled = true;
                InitializeTimer2();
            }
            else
            {
                barButtonItem58.Appearance.BackColor = Color.Red;
                isGreen = false;
                Durumu = "false";
                ServisDurum(ServisAdi, Durumu);
                timer.Stop();
            }
      
        }
        private  void SiparisTopluCek()
        {
            List<WebSiparis> uyeListe = SiparisServiceMethods.SelectSiparis();
            List<WebSiparisUrun> uyeAdresListe = SiparisServiceMethods.SelectSiparisDetay();
            SayimEsitle();

        }
        private async Task<List<Stok>> MSGVeritabanindaStokEsitle(string Firma)
        {
            List<Stok> stoks = new List<Stok>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                SqlCommand command = new SqlCommand("MSGNebim_SayimEsitle", conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Stok stok = new Stok();

                    stok.ModelType = reader["ModelType"].ToString();
                    stok.OfficeCode = reader["OfficeCode"].ToString();
                    stok.StoreCode = reader["StoreCode"].ToString();
                    stok.WarehouseCode = reader["WarehouseCode"].ToString();
                    stok.CompanyCode = Convert.ToInt32(reader["CompanyCode"]);
                    stok.InnerProcessType = Convert.ToInt32(reader["InnerProcessType"]);


                    string LinesJson = reader["Lines"].ToString();
                    JArray variantArray = JArray.Parse(LinesJson);
                    stok.Lines = variantArray.ToObject<List<Lines>>();



                    // Diğer alanları doldurmak için benzer işlemler...

                    stoks.Add(stok);
                }
            }




            return stoks;
        }
        private async void SayimEsitle()
        {
            List<FaturaBilgisi> faturaBilgileri = await GetFaturaBilgileriFromDatabasee();
            try
            {
                foreach (var faturaBilgisi in faturaBilgileri)
                {
                    //string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                    //List<ZtNebimFaturaROnline> items = await VeritabanindanMusteriGetirFaturaROnline(faturaBilgisi.Firma);

                    int totalRepeatCount = 30; // Toplam tekrar sayısı

                    for (int repeat = 0; repeat < totalRepeatCount; repeat++)
                    {
                        string sessionID = await ConnectIntegrator(faturaBilgisi.IpAdres);
                        List<Stok> items = await MSGVeritabanindaStokEsitle(faturaBilgisi.Firma);

                        //var currentBatch = items.Skip(repeat * batchSize).Take(batchSize).ToList();
                        //labelStatus.Text = $"Veritabanından {items.Count} adet veri çekildi. Şimdi POST işlemi başlatılıyor...";
                        int postCount = 0;
                        try
                        {
                            var tasks = items.Select(async item =>
                            {
                                string json = JsonConvert.SerializeObject(item);
                                try
                                {
                                    string serverName = Properties.Settings.Default.SunucuAdi;
                                    string userName = Properties.Settings.Default.KullaniciAdi;
                                    string password = Properties.Settings.Default.Sifre;
                                    string database = Properties.Settings.Default.database;
                                    string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

                                    string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                                    var response = await httpClient.PostAsync($"http://{faturaBilgisi.IpAdres}/(S({sessionID}))/IntegratorService/post?", content);

                                    if (response.IsSuccessStatusCode)
                                    {
                                        postCount++;
                                        //var result = await response.Content.ReadAsStringAsync();
                                        var result = await response.Content.ReadAsStringAsync();
                                        Console.WriteLine("Sunucu Yanıtı: " + result); // Sunucu yanıtını yazdır
                                        dynamic jsonResponse = JsonConvert.DeserializeObject(result);

                                    }
                                    else
                                    {
                                        postCount++;
                                        //var result = await response.Content.ReadAsStringAsync();
                                        var result = await response.Content.ReadAsStringAsync();
                                        Console.WriteLine("Sunucu Yanıtı: " + result); // Sunucu yanıtını yazdır
                                        dynamic jsonResponse = JsonConvert.DeserializeObject(result);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Hata: {ex.ToString()}");  // Daha detaylı hata bilgisi
                                }
                            }).ToList();

                            await Task.WhenAll(tasks);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message, "Hata Alındı Tekrar Faturalaştır Tuşuna basınız.");

                        }





                        // Eğer miktar 0'dan büyükse, işlemlere devam edin
                        //     labelStatus.Text = $"İşlem devam ediyor, kalan miktar: {miktar}";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Hata Alındı Tekrar Faturalaştır Tuşuna basınız.");

            }
    
        }

        private void barButtonItem56_ItemClick(object sender, ItemClickEventArgs e)
        {

            string Durumu;
            Durumu = "False";
            string ServisAdi;
            ServisAdi = "Toplu Siparis Faturalaştır";
            if (isGreen == false)
            {
                barButtonItem56.Appearance.BackColor = Color.Green;
                isGreen = true;
                Durumu = "true";
                ServisDurum(ServisAdi, Durumu);
                //timer.Enabled = true;
                InitializeTimerSiparis();
            }
            else
            {
                barButtonItem56.Appearance.BackColor = Color.Red;
                isGreen = false;
                Durumu = "false";
                ServisDurum(ServisAdi, Durumu);
                timer.Stop();
            }
        }

        private void barButtonItem57_ItemClick(object sender, ItemClickEventArgs e)
        {
            string Durumu;
            Durumu = "False";
            string ServisAdi;
            ServisAdi = "Toplu Irsaliye Faturalaştır";
            if (isGreen == false)
            {
                barButtonItem57.Appearance.BackColor = Color.Green;
                isGreen = true;
                Durumu = "true";
                ServisDurum(ServisAdi, Durumu);
                //timer.Enabled = true;
                InitializeTimerIrsaliye();
            }
            else
            {
                barButtonItem57.Appearance.BackColor = Color.Red;
                isGreen = false;
                Durumu = "false";
                ServisDurum(ServisAdi, Durumu);
                timer.Stop();
            }
        }

        private void barButtonItem102_ItemClick(object sender, ItemClickEventArgs e)
        {
            string Durumu;
            Durumu = "False";
            string ServisAdi;
            ServisAdi = "Toplu Koctas Çek";
            if (isGreen == false)
            {
                barButtonItem102.Appearance.BackColor = Color.Green;
                isGreen = true;
                Durumu = "true";
                ServisDurum(ServisAdi, Durumu);
                //timer.Enabled = true;
                InitializeTimerKoctas();
            }
            else
            {
                barButtonItem102.Appearance.BackColor = Color.Red;
                isGreen = false;
                Durumu = "false";
                ServisDurum(ServisAdi, Durumu);
                timer.Stop();
            }
        }

        private async void barButtonItem50_ItemClick(object sender, ItemClickEventArgs e)
        {
            await DownloadImagesAsync();
        }
        private async Task DownloadImagesAsync()
        {
            try
            {
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                string spName = "MSG_TrendyolResimIndirListe";

                DataTable dt = new DataTable();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }

                int count = 1;
                string lastBarcode = string.Empty;

                using (HttpClient client = new HttpClient())
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        try
                        {
                            string barcode = row["Barcode"].ToString();
                            string url = row["Url"].ToString();
                            string folderName = row["Marka"].ToString();
                            string folderPath = Path.Combine("C:\\Resimler", folderName);

                            if (!Directory.Exists(folderPath))
                            {
                                Directory.CreateDirectory(folderPath);
                            }

                            // Check if this is a new barcode or a repeat
                            if (barcode != lastBarcode)
                            {
                                // This is a new barcode, so reset the count
                                count = 1;
                                lastBarcode = barcode;
                            }

                            string filename = count > 1 ? $"{barcode}_{count}.jpg" : $"{barcode}.jpg";
                            string path = Path.Combine(folderPath, filename);

                            byte[] imageBytes = await client.GetByteArrayAsync(url);

                            using (FileStream sourceStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
                            {
                                await sourceStream.WriteAsync(imageBytes, 0, imageBytes.Length);
                            }

                            // Increment the count for the next loop
                            count++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            // Hata mesajını görmezden gel, sadece kaydet ve işlemi devam ettir
                            // Bu şekilde hata alan verileri atlatabilirsiniz.
                            // Burada hata işlenmiyor ve işlem devam ediyor.
                        }
                    }
                }

                MessageBox.Show("Resim İndirme Tamamlandı!");
            }
            catch (Exception ex)
            {
                // Top seviyedeki hata işleme, uygulamanın çökmemesini sağlar.
                MessageBox.Show("Uygulama genelinde bir hata oluştu: " + ex.Message);
            }
        }

    }
}