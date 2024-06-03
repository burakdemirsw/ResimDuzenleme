
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using QRCoder;
using System.Xml.Linq;
using System.IO;




namespace ResimDuzenleme
{
    public partial class QROlusturma : Form
    {
        public QROlusturma()
        {
            InitializeComponent();
        }
        public void ProcessXmlItemUrls()
        {
            try
            {
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Stored Procedure'u çağıran komut
                    using (SqlCommand cmd = new SqlCommand("MSG_TicimaxUrun", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string markaAdi = reader["Marka"].ToString();
                                string url = reader["Url"].ToString();

                                Marka2 marka = new Marka2 { marka = markaAdi };

                                // URL'ye göre işlem yap
                                ProcessXmlItemUrl(url, marka);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {


                Console.WriteLine("Hata alındı" + ex.Message);
            }

        }

        public void OzellikEkle(Ozellik ozellik, int varyasyonID, Marka2 marka)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO ZTMSGTicOzellikler (Tanim, Deger, VaryasyonID,Marka) " +
                             "select @Tanim, @Deger, @VaryasyonID,@Marka where @VaryasyonID not in (select VaryasyonID from ZTMSGTicOzellikler where VaryasyonID = @VaryasyonID and Deger = @Deger and Marka =@Marka)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Tanim", ozellik.Tanim);
                    cmd.Parameters.AddWithValue("@Deger", ozellik.Deger);
                    cmd.Parameters.AddWithValue("@VaryasyonID", varyasyonID);
                    cmd.Parameters.AddWithValue("@Marka", marka.marka);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UrunEkle(Urun urun, Marka2 marka)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO ZTMSGTicUrunler (UrunKartiID, UrunAdi, OnYazi, Aciklama, MarkaID, KategoriID, SatisBirimi, UrunUrl,OzelAlan1,OzelAlan2,OzelAlan3,OzelAlan4,OzelAlan5, Marka) " +
                             "select @UrunKartiID, @UrunAdi, @OnYazi, @Aciklama, @MarkaID, @KategoriID, @SatisBirimi, @UrunUrl,@OzelAlan1,@OzelAlan2,@OzelAlan3,@OzelAlan4,@OzelAlan5, @Marka where @UrunKartiID not in (select UrunKartiID from ZTMSGTicUrunler where Marka = @Marka)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@UrunKartiID", urun.UrunKartiID);
                    cmd.Parameters.AddWithValue("@UrunAdi", urun.UrunAdi);
                    cmd.Parameters.AddWithValue("@OnYazi", urun.OnYazi);
                    cmd.Parameters.AddWithValue("@Aciklama", urun.Aciklama);
                    cmd.Parameters.AddWithValue("@MarkaID", urun.MarkaID);
                    cmd.Parameters.AddWithValue("@KategoriID", urun.KategoriID);
                    cmd.Parameters.AddWithValue("@SatisBirimi", urun.SatisBirimi);
                    cmd.Parameters.AddWithValue("@UrunUrl", urun.UrunUrl);
                    cmd.Parameters.AddWithValue("@OzelAlan1", (object)urun.OzelAlan1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OzelAlan2", (object)urun.OzelAlan2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OzelAlan3", (object)urun.OzelAlan3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OzelAlan4", (object)urun.OzelAlan4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@OzelAlan5", (object)urun.OzelAlan5 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Marka", marka.marka);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void SecenekEkle(Secenek secenek, int urunKartiID, Marka2 marka)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "delete ZTMSGTicSecenekler from ztTicSecenekler  where VaryasyonID = @VaryasyonID and Barkod = @Barkod " +
               "INSERT INTO ZTMSGTicSecenekler (VaryasyonID, StokKodu, Barkod, StokAdedi, AlisFiyati, SatisFiyati, IndirimliFiyat, KDVDahil, KdvOrani, ParaBirimi, Desi, UrunKartiID,Marka) " +
                             "select @VaryasyonID, @StokKodu, @Barkod, @StokAdedi, @AlisFiyati, @SatisFiyati, @IndirimliFiyat, @KDVDahil, @KdvOrani, @ParaBirimi, @Desi, @UrunKartiID, @Marka where @VaryasyonID not in (select VaryasyonID  from ZTMSGTicSecenekler where Marka =@Marka and VaryasyonID = @VaryasyonID)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@VaryasyonID", secenek.VaryasyonID);
                    cmd.Parameters.AddWithValue("@StokKodu", secenek.StokKodu);
                    cmd.Parameters.AddWithValue("@Barkod", secenek.Barkod);
                    cmd.Parameters.AddWithValue("@StokAdedi", secenek.StokAdedi);
                    cmd.Parameters.AddWithValue("@AlisFiyati", secenek.AlisFiyati);
                    cmd.Parameters.AddWithValue("@SatisFiyati", secenek.SatisFiyati);
                    cmd.Parameters.AddWithValue("@IndirimliFiyat", secenek.IndirimliFiyat);
                    cmd.Parameters.AddWithValue("@KDVDahil", secenek.KDVDahil);
                    cmd.Parameters.AddWithValue("@KdvOrani", secenek.KdvOrani);
                    cmd.Parameters.AddWithValue("@ParaBirimi", secenek.ParaBirimi);
                    cmd.Parameters.AddWithValue("@Desi", secenek.Desi);
                    cmd.Parameters.AddWithValue("@UrunKartiID", urunKartiID);
                    cmd.Parameters.AddWithValue("@Marka", marka.marka);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void KategoriEkle(Kategori2 kategori, Marka2 marka)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO ZTMSGTicKategoriler (KategoriID, ParentID, Tanim,Marka) " +
                             "select @KategoriID, @ParentID, @Tanim,@Marka where @KategoriID not in (select KategoriID from ZTMSGTicKategoriler where KategoriID = @KategoriID and Marka = @Marka)";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@KategoriID", kategori.KategoriID);
                    cmd.Parameters.AddWithValue("@ParentID", kategori.ParentID);
                    cmd.Parameters.AddWithValue("@Tanim", kategori.Tanim);
                    cmd.Parameters.AddWithValue("@Marka", marka.marka);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ProcessXmlItemUrl(string url, Marka2 marka)
        {
            try
            {
                List<Marka2> markalar = GetMarkalarFromStoredProcedure();
                using (WebClient client = new WebClient())
                {
                    // XML dosyasını indir
                    string xmlData = client.DownloadString(url);

                    // XML dosyasını parse et
                    XDocument doc = XDocument.Parse(xmlData);

                    // Ürünleri çek
                    var urunler = doc.Root.Element("Urunler").Elements("Urun").Select(x => new Urun
                    {
                        UrunKartiID = (int)x.Element("UrunKartiID"),
                        UrunAdi = (string)x.Element("UrunAdi"),
                        OnYazi = (string)x.Element("OnYazi"),
                        Aciklama = (string)x.Element("Aciklama"),
                        MarkaID = (int)x.Element("MarkaID"),
                        KategoriID = (int)x.Element("KategoriID"),
                        SatisBirimi = (string)x.Element("SatisBirimi"),
                        UrunUrl = (string)x.Element("UrunUrl"),
                        OzelAlan1 = (string)x.Element("OzelAlan1"),
                        OzelAlan2 = (string)x.Element("OzelAlan2"),
                        OzelAlan3 = (string)x.Element("OzelAlan3"),
                        OzelAlan4 = (string)x.Element("OzelAlan4"),
                        OzelAlan5 = (string)x.Element("OzelAlan5"),
                        UrunSecenek = x.Element("UrunSecenek").Elements("Secenek").Select(s => new Secenek
                        {
                            VaryasyonID = (int)s.Element("VaryasyonID"),
                            StokKodu = (string)s.Element("StokKodu"),
                            Barkod = (string)s.Element("Barkod"),
                            StokAdedi = (int)s.Element("StokAdedi"),
                            AlisFiyati = (double)s.Element("AlisFiyati"),
                            SatisFiyati = (double)s.Element("SatisFiyati"),
                            IndirimliFiyat = (double)s.Element("IndirimliFiyat"),
                            KDVDahil = (bool)s.Element("KDVDahil"),
                            KdvOrani = (int)s.Element("KdvOrani"),
                            ParaBirimi = (string)s.Element("ParaBirimi"),
                            Desi = (int)s.Element("Desi"),
                            EkSecenekOzellik = s.Element("EkSecenekOzellik").Elements("Ozellik").Select(o => new Ozellik
                            {
                                Tanim = (string)o.Attribute("Tanim"),
                                Deger = (string)o.Attribute("Deger")
                            }).ToList()
                        }).ToList()
                    }).ToList();
                    try
                    {
                        foreach (var urun in urunler)
                        {
                            UrunEkle(urun, marka);

                            foreach (var secenek in urun.UrunSecenek)
                            {
                                SecenekEkle(secenek, urun.UrunKartiID, marka);

                                foreach (var ozellik in secenek.EkSecenekOzellik)
                                {
                                    OzellikEkle(ozellik, secenek.VaryasyonID, marka);
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Hata alındı");

                    }

                }
            }
            catch (Exception ex)
            {


                Console.WriteLine("Hata alındı" + ex.Message);
            }

        }





        public void ProcessXmlUrls()
        {
            try
            {
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Stored Procedure'u çağıran komut
                    using (SqlCommand cmd = new SqlCommand("MSG_TicimaxResim", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string url = reader["Url"].ToString();
                                string markaAdi = reader["Marka"].ToString();

                                Marka2 marka = new Marka2 { marka = markaAdi };

                                // URL'ye ve marka bilgisine göre işlem yap
                                ProcessXmlUrl(url, marka.marka);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {


                Console.WriteLine("Hata alındı" + ex.Message);
            }

        }

        public void ProcessXmlUrl(string url, string marka)
        {
            // Marka bilgisini Marka sınıfına dönüştür
            Marka2 markaObjesi = new Marka2 { marka = marka };

            ResimleriKaydet(url, markaObjesi);


        }
        public void ProcessXmlKategoriUrls()
        {
            try
            {
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Stored Procedure'u çağıran komut
                    using (SqlCommand cmd = new SqlCommand("MSG_TicimaxKategori", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string markaAdi = reader["Marka"].ToString();
                                string url = reader["Url"].ToString();

                                Marka2 marka = new Marka2 { marka = markaAdi };

                                // URL'ye göre işlem yap
                                ProcessXmlKategoriUrl(url, marka);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {


                Console.WriteLine("Hata alındı" + ex.Message);
            }

        }

        public List<Marka2> GetMarkalarFromStoredProcedureKAT()
        {
            List<Marka2> markalar = new List<Marka2>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("MSG_TicimaxKategori", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Marka2 marka = new Marka2();
                            marka.marka = reader["Marka"].ToString();

                            markalar.Add(marka);
                        }
                    }
                }
            }

            return markalar;
        }
        public void ProcessXmlKategoriUrl(string url, Marka2 marka)
        {

            try
            {
                List<Marka2> markalar = GetMarkalarFromStoredProcedureKAT();
                using (WebClient client = new WebClient())
                {
                    // XML dosyasını indir
                    string xmlData = client.DownloadString(url);

                    // XML dosyasını parse et
                    XDocument doc = XDocument.Parse(xmlData);

                    // Root kontrolü
                    var root = doc.Root;
                    if (root == null)
                    {
                        throw new Exception("Root is null");
                    }

                    // Kategori elementleri kontrolü
                    var kategoriElements = root.Elements("Kategori");
                    if (kategoriElements == null || !kategoriElements.Any())
                    {
                        throw new Exception("Kategori elements are null or empty");
                    }

                    var kategoriler = kategoriElements.Select(x =>
                    {
                        // KategoriID kontrolü
                        var kategoriIDElement = x.Element("KategoriID");
                        if (kategoriIDElement == null)
                        {
                            throw new Exception("KategoriID element is null");
                        }

                        // ParentID kontrolü
                        var parentIDElement = x.Element("ParentID");
                        if (parentIDElement == null)
                        {
                            throw new Exception("ParentID element is null");
                        }

                        // Tanim kontrolü
                        var tanimElement = x.Element("Tanim");
                        if (tanimElement == null)
                        {
                            throw new Exception("Tanim element is null");
                        }

                        return new Kategori2
                        {
                            KategoriID = (int)kategoriIDElement,
                            ParentID = (int)parentIDElement,
                            Tanim = (string)tanimElement
                        };
                    }).ToList();

                    foreach (var kategori in kategoriler)
                    {
                        KategoriEkle(kategori, marka);


                    }
                }
            }
            catch (Exception ex)
            {


                Console.WriteLine("Hata alındı" + ex.Message);
            }

        }

        private void ResimleriKaydet(string url, Marka2 marka)
        {
            try
            {
                WebClient client = new WebClient();
                string xmlContent = client.DownloadString(url);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlContent);

                XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Resimler/Resim");

                foreach (XmlNode node in nodes)
                {
                    string urunKartiID = node.SelectSingleNode("UrunKartiID").InnerText;
                    string varyasyonID = node.SelectSingleNode("VaryasyonID").InnerText;
                    string resimAdresi = node.SelectSingleNode("ResimAdresi").InnerText;

                    Resim resim = new Resim
                    {
                        UrunKartiID = int.Parse(urunKartiID),
                        VaryasyonID = int.Parse(varyasyonID),
                        ResimAdresi = resimAdresi,
                    };

                    ResimDurumuKaydet(resim, "Başarısız", marka);
                }
            }
            catch (Exception ex)
            {


                Console.WriteLine("Hata alındı" + ex.Message);
            }

        }

        public void ResimDurumuKaydet(Resim resim, string indirmeDurumu, Marka2 marka)
        {
            try
            {
                string query = "INSERT INTO ZTMSGTicResimler (UrunKartiID, VaryasyonID, ResimAdresi, IndirmeDurumu,Marka) " +
                          "select @UrunKartiID, @VaryasyonID, @ResimAdresi, @IndirmeDurumu, @Marka where @ResimAdresi not in (Select ResimAdresi from ZTMSGTicResimler where Marka =@Marka) ";
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UrunKartiID", resim.UrunKartiID);
                        command.Parameters.AddWithValue("@VaryasyonID", resim.VaryasyonID);
                        command.Parameters.AddWithValue("@ResimAdresi", resim.ResimAdresi);
                        command.Parameters.AddWithValue("@IndirmeDurumu", indirmeDurumu);
                        command.Parameters.AddWithValue("@Marka", marka.marka);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {


                Console.WriteLine("Hata alındı" + ex.Message);
            }

        }

      
     
        private void btnQRServisKontrol_Click(object sender, EventArgs e)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            // Klasörün bulunduğu yol
            string folderPath = @"C:\QRBarkod";

            // Klasör yoksa oluştur
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Çekilecek olan stored procedure adı ve bağlantı nesnesi belirtilir.
                using (SqlCommand command = new SqlCommand("MSG_TicimaxUrunQR", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string barkod = reader["Barkod"].ToString();
                            string url = reader["UrunUrl"].ToString();
                            string outputPath = Path.Combine(folderPath, $"{barkod}.jpg"); // QR kodunun kaydedileceği yol

                            // QR kod oluştur ve kaydet
                            GenerateAndSaveQRCode(url, outputPath);

                            // Eğer QR kod oluşturma işlemi başarılı ise veritabanına kayıt ekle
                            if (File.Exists(outputPath))
                            {
                                InsertQRCodeToDatabase( barkod, url);
                            }
                        }
                        // SqlDataReader'ı kapatın veya Dispose edin
                        reader.Close(); // veya reader.Dispose();
                    }
                }
            }
        }


        private void GenerateAndSaveQRCode(string url, string outputPath)
        {
            try
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);

                using (Bitmap qrCodeImage = qrCode.GetGraphic(20)) // 20 is the size of each module in pixels
                {
                    qrCodeImage.Save(outputPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
            catch (Exception ex)
            {
                // Hata mesajını konsola yazdır
                Console.WriteLine($"QR kod oluşturma ve kaydetme hatası: {ex.Message}");
                // İsterseniz hatayı loglama veya başka işlemler yapabilirsiniz
            }
        }
        private void InsertQRCodeToDatabase( string barkod, string url)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand insertCommand = new SqlCommand("MSG_TicimaxUrunQRInsert", connection))
                {
                    insertCommand.CommandType = CommandType.StoredProcedure;
                    insertCommand.Parameters.AddWithValue("@Barkod", barkod);
                    insertCommand.Parameters.AddWithValue("@Url", url);

                    int result = insertCommand.ExecuteNonQuery();
                    if (result > 0)
                    {
                        // Ekleme başarılı
              
                    }
                }
            }
        }
        public List<Marka2> GetMarkalarFromStoredProcedure()
        {
            List<Marka2> markalar = new List<Marka2>();
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("MSG_TicimaxUrun", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Marka2 marka = new Marka2();
                            marka.marka = reader["Marka"].ToString();

                            markalar.Add(marka);
                        }
                    }
                }
            }

            return markalar;
        }

        private void QROlusturma_Load(object sender, EventArgs e)
        {

        }

        private void btnQRcek_Click(object sender, EventArgs e)
        {
            // txtBarkod TextBox'ından barkodu al
            string barkod = textBox1.Text;

            // Geçerli bir barkod varsa işlemleri yap
            if (!string.IsNullOrEmpty(barkod))
            {
                // Klasörün bulunduğu yol
                string folderPath = @"C:\QRBarkod";

                // Klasör yoksa oluştur
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Veritabanı bağlantısı oluştur
                string serverName = Properties.Settings.Default.SunucuAdi;
                string userName = Properties.Settings.Default.KullaniciAdi;
                string password = Properties.Settings.Default.Sifre;
                string database = Properties.Settings.Default.database;
                string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Çekilecek olan stored procedure adı ve bağlantı nesnesi belirtilir.
                    using (SqlCommand command = new SqlCommand("MSG_TicimaxUrunQRSorgula", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Parametre ekleyin
                        command.Parameters.AddWithValue("@Barkod", barkod);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string dbBarkod = reader["Barkod"].ToString();
                                string url = reader["UrunUrl"].ToString();
                                string outputPath = Path.Combine(folderPath, $"{dbBarkod}.jpg"); // QR kodunun kaydedileceği yol

                                // Eğer barkodlar eşleşiyorsa QR kod oluştur ve kaydet
                                if (barkod == dbBarkod)
                                {
                                    GenerateAndSaveQRCode(url, outputPath);

                                    // Eğer QR kod oluşturma işlemi başarılı ise veritabanına kayıt ekle
                                    if (File.Exists(outputPath))
                                    {
                                        InsertQRCodeToDatabase(dbBarkod, url);
                                    }
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("QRBarkod oluşturuldu.");
            }
            else
            {
                // Barkod alanı boşsa kullanıcıya uyarı ver
                MessageBox.Show("Barkod alanı boş olamaz.");
            }
        }

        private void btnUrunleriCek_Click(object sender, EventArgs e)
        {
            ProcessXmlItemUrls();
            ProcessXmlUrls();
            ProcessXmlKategoriUrls();
        }
    }
}
