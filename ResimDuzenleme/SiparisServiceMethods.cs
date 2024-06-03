using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ResimDuzenleme.SiparisServis;
using System.Data.SqlClient;
using System.Threading;


namespace ResimDuzenleme
{
    public static class SiparisServiceMethods
    {
        public static List<WebSiparis> GetSiparisWithRetry(string WSYetki, WebSiparisFiltre webSiparisFiltre, WebSiparisSayfalama webSiparisSayfalama, int maxAttempts = 3, int delayBetweenAttempts = 1000)
        {
            int attempts = 0;
            List<WebSiparis> siparisListe = null;

            while (attempts < maxAttempts && (siparisListe == null || siparisListe.Count == 0))
            {
                try
                {
                    attempts++;
                    siparisListe = StaticVariables.siparisServisClient.SelectSiparis(WSYetki, webSiparisFiltre, webSiparisSayfalama);
                    if (siparisListe != null && siparisListe.Count > 0) break; // Eğer sipariş listesi alındıysa döngüden çık
                }
                catch (Exception ex)
                {
                    // Loglama veya hata yönetimi
                    Console.WriteLine($"Deneme {attempts}: {ex.Message}");
                }

                // Belirlenen süre kadar bekleyin
                if (siparisListe == null || siparisListe.Count == 0)
                {
                    Thread.Sleep(delayBetweenAttempts);
                }
            }

            return siparisListe;
        }
        //public List<WebSiparis> GetSiparisWithRetry(WSYetki y, WebSiparisFiltre f, WebSiparisSayfalama s, int maxAttempts = 3, int delayBetweenAttempts = 1000)
        //{
        //    int attempts = 0;
        //    List<WebSiparis> siparisListe = null;

        //    while (attempts < maxAttempts && (siparisListe == null || !siparisListe.Any()))
        //    {
        //        try
        //        {
        //            attempts++;
        //            siparisListe = StaticVariables.siparisServisClient.SelectSiparis(y, f, s);
        //            if (siparisListe != null && siparisListe.Any()) break; // Eğer sipariş listesi alındıysa döngüden çık
        //        }
        //        catch (Exception ex)
        //        {
        //            // Loglama veya hata yönetimi
        //            Console.WriteLine($"Deneme {attempts}: {ex.Message}");
        //        }

        //        // Belirlenen süre kadar bekleyin
        //        if (siparisListe == null || !siparisListe.Any())
        //        {
        //            Thread.Sleep(delayBetweenAttempts);
        //        }
        //    }

        //    return siparisListe;
        //}
        public static List<WebSiparis> SelectSiparis()
        {
            try
            {
                // Tüm integer alanlar için -1 gönderildiğinde o alana filtreleme yapılmaz. Hiçbir alan zorunlu değil filtrelemek istenilen bilgilere göre doldurulabilir.

                // ödeme durumu değişkenleri=  
                // 0 - onay bekliyor, 1 - onaylandı, 2 - hatalı , 3 - iade edilmiş, 4 - iptal edilmiş 

                // ödeme tipi değişkenleri =
                //KrediKarti = 0,  Havale = 1, KapidaOdemeNakit = 2, KapidaOdemeKrediKarti = 3, MobilOdeme = 4,
                //BkmEkspress = 5, PayPal = 6, Cari = 7, MailOrder = 8, iPara = 9, Nakit = 10, 
                //PayUOneClick = 11, CariKredi = 12, GarantiPay = 13, PayuBkmEkspress = 14, NestPay = 15,
                //PayCell = 16, IyziPay = 17, Hopi = 18, PayByMe = 19, HediyeCeki = 20, PayGuruMobil = 21,
                //Paynet = 22, Telr = 23, ComPay = 24, PayTR = 25, MaximumMobil = 26, MagazadaOde = 27

                //Sipariş durumu değişkenleri 
                //0 = ön sipariş,  1 = onay bekliyor, 2 = onaylandı, 3 = ödeme bekliyor, 4 = paketleniyor, 5 = tedarik ediliyor
                //6 = kargoya verildi, 7 = teslim edildi, 8 = iptal edildi, 9 = iade edildi, 10 - silinmiş, 11 - iade talebi alındı, 12 - iade ulaştı ödeme yapılacak, 13 - iade ödemesi yapıldı, 14 - teslimat öncesi iptal talebi, 15 - iptal talebi, 16 - kısmi iade talebi, 17 - kısmi iade yapıldı



                WebSiparisFiltre webSiparisFiltre = new WebSiparisFiltre
                {
                    EntegrasyonAktarildi = 0,  // sipariş aktarılma durumu 0 = aktarılmayanlar,  1 = aktarılanlar, -1 = hepsi  
                    EntegrasyonParams = new WebSiparisEntegrasyon
                    {
                        AlanDeger = "",
                        Deger = "",
                        EntegrasyonKodu = "",
                        EntegrasyonParamsAktif = false,
                        TabloAlan = "",
                        Tanim = ""
                    },
                    IptalEdilmisUrunler = false, // iptal edilmiş siparişlerin kontrolü 

                    FaturaNo = "",
                    OdemeDurumu = -1,
                    OdemeTipi = -1, // siparisin ödeme tipi durumu 
                    SiparisDurumu = -1,
                    SiparisID = -1,
                    SiparisKaynagi = "",
                    SiparisKodu = "",
                    SiparisTarihiBas = Convert.ToDateTime(DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd")), //Son 10 günlük siparişler çekiliyor.
                    SiparisTarihiSon = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")),
                    //SiparisTarihiBas = Convert.ToDateTime("2019-02-04"), //filtrede kullanılacak sipariş başlangıç tarihi
                    //SiparisTarihiSon = Convert.ToDateTime("2019-02-06"), // filtrede kullanılacak sipariş bitiş tarihi
                    StrSiparisDurumu = "",
                    TedarikciID = -1,
                    UyeID = -1,
                    SiparisNo = "",
                    UyeTelefon = ""

                };

                WebSiparisSayfalama webSiparisSayfalama = new WebSiparisSayfalama
                {
                    BaslangicIndex = 0, // bulunan kayıtların baslangıç index i  - zorunlu değil 
                    KayitSayisi = 100, // kaç kayıt getirileceği bilgisi, - zorunlu değil girilmez ise bulunan tüm kayıtlar gösterilir.
                    SiralamaDegeri = "id", // kayıtların hangi alana göre sıralanacağı - zorunlu değil 
                    SiralamaYonu = "Desc" // Sıralama yönü. Artan için "ASC" azalan için "DESC" - zorunlu değil 
                };
                string sitead = Properties.Settings.Default.txtSiteAdi;
                string WSYetki = Properties.Settings.Default.txtWsYetki;
                StaticVariables.siparisServisClient = new SiparisServis.SiparisServisClient();
       
                StaticVariables.siparisServisClient.Endpoint.Address = new System.ServiceModel.EndpointAddress($"https://{sitead}/Servis/SiparisServis.svc");

                List<WebSiparisUrun> uyeAdresListe = new List<WebSiparisUrun>();
                List<WebSiparis> siparisListe = SiparisServiceMethods.GetSiparisWithRetry(WSYetki, webSiparisFiltre, webSiparisSayfalama);
                if (siparisListe != null && siparisListe.Count > 0)
                {
                    SaveSiparisToDatabase(siparisListe);
                }
                else
                {
                    

                            MessageBox.Show("Siparişler Çekilemedi Tekrar deneyin.");
                            // Sipariş listesi alınamadıysa uygun bir hata mesajı göster
                   
                }
                // List<WebSiparisUrun> uyeAdresListe = SiparisServiceMethods.SelectSiparisDetay();
                // MessageBox.Show("Son 10 günün siparişleri listelendi");

                //StaticFunctions.CevapListele(siparisListe.Cast<object>().ToList(), "Siparişler");

                return siparisListe;
            }
            catch (Exception exception)
            {
              MessageBox.Show(exception.Message);
                return null;
            }
        }


        public static List<WebSiparis> SelectSiparisKoctas()
        {
            try
            {
                // Tüm integer alanlar için -1 gönderildiğinde o alana filtreleme yapılmaz. Hiçbir alan zorunlu değil filtrelemek istenilen bilgilere göre doldurulabilir.

                // ödeme durumu değişkenleri=  
                // 0 - onay bekliyor, 1 - onaylandı, 2 - hatalı , 3 - iade edilmiş, 4 - iptal edilmiş 

                // ödeme tipi değişkenleri =
                //KrediKarti = 0,  Havale = 1, KapidaOdemeNakit = 2, KapidaOdemeKrediKarti = 3, MobilOdeme = 4,
                //BkmEkspress = 5, PayPal = 6, Cari = 7, MailOrder = 8, iPara = 9, Nakit = 10, 
                //PayUOneClick = 11, CariKredi = 12, GarantiPay = 13, PayuBkmEkspress = 14, NestPay = 15,
                //PayCell = 16, IyziPay = 17, Hopi = 18, PayByMe = 19, HediyeCeki = 20, PayGuruMobil = 21,
                //Paynet = 22, Telr = 23, ComPay = 24, PayTR = 25, MaximumMobil = 26, MagazadaOde = 27

                //Sipariş durumu değişkenleri 
                //0 = ön sipariş,  1 = onay bekliyor, 2 = onaylandı, 3 = ödeme bekliyor, 4 = paketleniyor, 5 = tedarik ediliyor
                //6 = kargoya verildi, 7 = teslim edildi, 8 = iptal edildi, 9 = iade edildi, 10 - silinmiş, 11 - iade talebi alındı, 12 - iade ulaştı ödeme yapılacak, 13 - iade ödemesi yapıldı, 14 - teslimat öncesi iptal talebi, 15 - iptal talebi, 16 - kısmi iade talebi, 17 - kısmi iade yapıldı



                WebSiparisFiltre webSiparisFiltre = new WebSiparisFiltre
                {
                    EntegrasyonAktarildi =-1,  // sipariş aktarılma durumu 0 = aktarılmayanlar,  1 = aktarılanlar, -1 = hepsi  
                    EntegrasyonParams = new WebSiparisEntegrasyon
                    {
                        AlanDeger = "",
                        Deger = "",
                        EntegrasyonKodu = "",
                        EntegrasyonParamsAktif = false,
                        TabloAlan = "",
                        Tanim = ""
                    },
                    IptalEdilmisUrunler = false, // iptal edilmiş siparişlerin kontrolü 

                    FaturaNo = "",
                    OdemeDurumu = 1,
                    OdemeTipi = -1, // siparisin ödeme tipi durumu 
                    SiparisDurumu = -1,
                    SiparisID = -1,
                    SiparisKaynagi = "",
                    SiparisKodu = "",
                    SiparisTarihiBas = Convert.ToDateTime(DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd")), //Son 10 günlük siparişler çekiliyor.
                    SiparisTarihiSon = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")),
                    //SiparisTarihiBas = Convert.ToDateTime("2019-02-04"), //filtrede kullanılacak sipariş başlangıç tarihi
                    //SiparisTarihiSon = Convert.ToDateTime("2019-02-06"), // filtrede kullanılacak sipariş bitiş tarihi
                    StrSiparisDurumu = "",
                    TedarikciID = -1,
                    UyeID = -1,
                    SiparisNo = "",
                    UyeTelefon = ""

                };

                WebSiparisSayfalama webSiparisSayfalama = new WebSiparisSayfalama
                {
                    BaslangicIndex = 0, // bulunan kayıtların baslangıç index i  - zorunlu değil 
                    KayitSayisi = 1000, // kaç kayıt getirileceği bilgisi, - zorunlu değil girilmez ise bulunan tüm kayıtlar gösterilir.
                    SiralamaDegeri = "id", // kayıtların hangi alana göre sıralanacağı - zorunlu değil 
                    SiralamaYonu = "Desc" // Sıralama yönü. Artan için "ASC" azalan için "DESC" - zorunlu değil 
                };
                string sitead = Properties.Settings.Default.txtSiteAdi;
                string WSYetki = Properties.Settings.Default.txtWsYetki;
                StaticVariables.siparisServisClient = new SiparisServis.SiparisServisClient();

                StaticVariables.siparisServisClient.Endpoint.Address = new System.ServiceModel.EndpointAddress($"https://{sitead}/Servis/SiparisServis.svc");

                List<WebSiparisUrun> uyeAdresListe = new List<WebSiparisUrun>();
                List<WebSiparis> siparisListe = SiparisServiceMethods.GetSiparisWithRetry(WSYetki, webSiparisFiltre, webSiparisSayfalama);
                if (siparisListe != null && siparisListe.Count > 0)
                {
                    SaveSiparisToDatabaseKoctas(siparisListe);
                }
                else
                {


                    MessageBox.Show("Siparişler Çekilemedi Tekrar deneyin.");
                    // Sipariş listesi alınamadıysa uygun bir hata mesajı göster

                }
                // List<WebSiparisUrun> uyeAdresListe = SiparisServiceMethods.SelectSiparisDetay();
                // MessageBox.Show("Son 10 günün siparişleri listelendi");

                //StaticFunctions.CevapListele(siparisListe.Cast<object>().ToList(), "Siparişler");

                return siparisListe;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }

        public static void SaveSiparisToDatabaseKoctas(List<WebSiparis> siparisListe)
        {

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (var uye in siparisListe)
                {
                    string query = @"INSERT INTO ZTMSGTicSiparisList 
                        (AdiSoyadi, SiparisID, MarketPlaceKampanyaKodu, 
                         SiparisNo, SiparisTarihi)
                        SELECT @AdiSoyadi, @SiparisID, @MarketPlaceKampanyaKodu, 
                         @SiparisNo, @SiparisTarihi
                        WHERE @SiparisID NOT IN (SELECT SiparisID FROM ZTMSGTicSiparisList) and  @MarketPlaceKampanyaKodu != ''  and @MarketPlaceKampanyaKodu not like '%-%'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AdiSoyadi", uye.AdiSoyadi);
                        command.Parameters.AddWithValue("@SiparisID", uye.ID);
                        if (uye.MarketplaceKampanyaKodu == null)
                        {
                            command.Parameters.AddWithValue("@MarketPlaceKampanyaKodu", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@MarketPlaceKampanyaKodu", uye.MarketplaceKampanyaKodu);
                        }
                        command.Parameters.AddWithValue("@SiparisNo", uye.SiparisNo);
                        command.Parameters.AddWithValue("@SiparisTarihi", uye.SiparisTarihi);

                        command.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }
        public static void SaveSiparisToDatabase(List<WebSiparis> siparisListe)
        {

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (var uye in siparisListe)
                {
                    string query = @"INSERT INTO ZTMSGTicSiparisList 
                        (AdiSoyadi, SiparisID, MarketPlaceKampanyaKodu, 
                         SiparisNo, SiparisTarihi)
                        SELECT @AdiSoyadi, @SiparisID, @MarketPlaceKampanyaKodu, 
                         @SiparisNo, @SiparisTarihi
                        WHERE @SiparisID NOT IN (SELECT SiparisID FROM ZTMSGTicSiparisList)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AdiSoyadi", uye.AdiSoyadi);
                        command.Parameters.AddWithValue("@SiparisID", uye.ID);
                        if (uye.MarketplaceKampanyaKodu == null)
                        {
                            command.Parameters.AddWithValue("@MarketPlaceKampanyaKodu", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@MarketPlaceKampanyaKodu", uye.MarketplaceKampanyaKodu);
                        }
                        command.Parameters.AddWithValue("@SiparisNo", uye.SiparisNo);
                        command.Parameters.AddWithValue("@SiparisTarihi", uye.SiparisTarihi);

                        command.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }
        }

        public static List<WebSiparisUrun> SelectSiparisDetay()
        {
           
            StaticVariables.siparisServisClient = new SiparisServis.SiparisServisClient();
            string sitead = Properties.Settings.Default.txtSiteAdi;
            StaticVariables.siparisServisClient.Endpoint.Address = new System.ServiceModel.EndpointAddress($"https://{sitead}/Servis/SiparisServis.svc");

            List<WebSiparisUrun> uyeAdresListe = new List<WebSiparisUrun>();
            List<int> uyeIdList = new List<int>();


            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT SiparisID FROM ZTMSGTicSiparisList where Createddate  >= GETDATE()-'00:05:00.000'", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                uyeIdList.Add(reader.GetInt32(0));
                            }
                        }
                    }

                    foreach (int uyeId in uyeIdList)
                    {
                        string WSYetki = Properties.Settings.Default.txtWsYetki;
                        var adresListesi2 = StaticVariables.siparisServisClient.SelectSiparisUrun(WSYetki, uyeId, false);
                        //List<WebSiparisUrun> urunListe = StaticVariables.siparisServisClient.SelectSiparisUrun(StaticVariables.uyeKodu, uyeId, false);

                        foreach (var uyeAdres in adresListesi2)
                        {
                            // SQL'e kaydediyoruz.
                            string query = @"INSERT INTO ZTMSGTicSiparisListDetay 
(SiparisID, SiparisDetayID, Barkod, Adet, MagazaKodu) 
select @SiparisID, @SiparisDetayID, @Barkod, @Adet, @MagazaKodu
where @SiparisDetayID not in (select SiparisDetayID from ZTMSGTicSiparisListDetay)";
                            using (SqlCommand insertCommand = new SqlCommand(query, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@SiparisID", uyeAdres.SiparisID);
                                insertCommand.Parameters.AddWithValue("@SiparisDetayID", uyeAdres.ID);
                                insertCommand.Parameters.AddWithValue("@Barkod", uyeAdres.Barkod);
                                insertCommand.Parameters.AddWithValue("@Adet", uyeAdres.Adet);
                                insertCommand.Parameters.AddWithValue("@MagazaKodu", uyeAdres.MagazaKodu);
                                insertCommand.ExecuteNonQuery();

                            }
                        }

                        uyeAdresListe.AddRange(adresListesi2);
                    }
                }

                //  MessageBox.Show("Filtrelere göre bulunan üye adres sayısı: " + uyeAdresListe.Count);
                //    StaticFunctions.CevapListele(uyeAdresListe.Cast<object>().ToList(), "Üye Adresleri");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                //  MessageBox.Show(exception.Message);
                return null;
            }



            return uyeAdresListe;
        }






        //public static List<WebSiparisUrun> SelectSiparisUrun()
        //{
        //    try
        //    {
        //        // İptalEdilmisUrunler değeri false gönderilirse iptal edilen ürünler getirilmez. 
        //        List<WebSiparisUrun> urunListe = StaticVariables.siparisServisClient.SelectSiparisUrun(StaticVariables.uyeKodu, 5993, false);

        //        MessageBox.Show("Siparişteki ürünler listelendi. Bulunan ürün sayısı: " + urunListe.Count);

        //        //StaticFunctions.CevapListele(urunListe.Cast<object>().ToList(), "Ürünler");

        //        return urunListe;
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message);
        //        return null;
        //    }
        //}

    }
}
