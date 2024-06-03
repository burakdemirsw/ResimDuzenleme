using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ResimDuzenleme.UrunServis;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;


namespace ResimDuzenleme
{
    public static class UrunServiceMethods
    {
        public static void StokAdediGuncelle()
        {
            try
            {
                List<Varyasyon> urunListe = new List<Varyasyon>();

                // id ve stok adedi göndermek yeterlidir. 
                Varyasyon varyasyon = new Varyasyon
                {
                    ID = 1, // kayıtlı varyasyon id değeri
                    StokAdedi = 30
                };
                urunListe.Add(varyasyon);
                StaticVariables.urunServisClient.StokAdediGuncelle(StaticVariables.uyeKodu, urunListe);
                MessageBox.Show(varyasyon.ID + " ID'li varyasyonun stok adedi güncellendi.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        public static SelectMagazaStokResponse selectMagazaStok()
        {
            try
            {
                SelectMagazaStokRequest selectMagazaStokRequest = new SelectMagazaStokRequest
                {
                    MagazaKodu = "mağaza kodu"
                };
                SelectMagazaStokResponse selectMagazaStokResponse = StaticVariables.urunServisClient.SelectMagazaStok(StaticVariables.uyeKodu, selectMagazaStokRequest);

                if (selectMagazaStokResponse.IsError)
                    MessageBox.Show(selectMagazaStokResponse.ErrorMessage);
                else
                {
                    MessageBox.Show("Mağaza stok bilgisi Listelendi.");
                    //StaticFunctions.CevapListele(selectMagazaStokResponse.MagazaStokList.Cast<object>().ToList(), "Mağaza Stoklar");
                }
                return selectMagazaStokResponse;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static WebServisResponse UpdateEkSecenekGrupDil()
        {
            try
            {
                List<EkSecenekGrupDil> ekSecenekGrupDilListe = new List<EkSecenekGrupDil>();
                EkSecenekGrupDil ekSecenekGrupDil = new EkSecenekGrupDil
                {
                    ID = 1,
                    Tanim = "tanım ingilizce"
                };
                ekSecenekGrupDilListe.Add(ekSecenekGrupDil);
                UpdateEkSecenekGrupDilRequest updateEkSecenekGrupDilRequest = new UpdateEkSecenekGrupDilRequest
                {
                    Dil = "en", // dil kodu
                    Liste = ekSecenekGrupDilListe
                };
                UrunServis.WebServisResponse webServisResponse = StaticVariables.urunServisClient.UpdateEkSecenekGrupDil(StaticVariables.uyeKodu, updateEkSecenekGrupDilRequest);

                if (webServisResponse.IsError)
                    MessageBox.Show(webServisResponse.ErrorMessage);
                else
                    MessageBox.Show("Ek seçenek grup dili güncellendi");

                return webServisResponse;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static WebServisResponse UpdateEkSecenekDegerDil()
        {
            try
            {
                List<EkSecenekDegerDil> ekSecenekDegerDilListe = new List<EkSecenekDegerDil>();
                EkSecenekDegerDil ekSecenekDegerDil = new EkSecenekDegerDil
                {
                    ID = 1,
                    Tanim = "tanım ingilizce"
                };
                ekSecenekDegerDilListe.Add(ekSecenekDegerDil);

                UpdateEkSecenekDegerDilRequest updateEkSecenekDegerDilRequest = new UpdateEkSecenekDegerDilRequest
                {
                    Dil = "en", // dil kodu 
                    Liste = ekSecenekDegerDilListe
                };

                UrunServis.WebServisResponse webServisResponse = StaticVariables.urunServisClient.UpdateEkSecenekDegerDil(StaticVariables.uyeKodu, updateEkSecenekDegerDilRequest);

                if (webServisResponse.IsError)
                    MessageBox.Show(webServisResponse.ErrorMessage);
                else
                    MessageBox.Show("Ek seçenek değer dili güncellendi");

                return webServisResponse;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static WebServisResponse UpdateTeknikDetayOzellikDil()
        {
            try
            {
                List<TeknikDetayOzellikDil> teknikDetayOzellikDilListe = new List<TeknikDetayOzellikDil>();
                TeknikDetayOzellikDil teknikDetayOzellikDil = new TeknikDetayOzellikDil
                {
                    ID = 1,
                    Tanim = "tanım ingilizce"
                };
                teknikDetayOzellikDilListe.Add(teknikDetayOzellikDil);

                UpdateTeknikDetayOzellikDilRequest updateTeknikDetayOzellikDilRequest = new UpdateTeknikDetayOzellikDilRequest
                {
                    Dil = "en", // dil kodu 
                    Liste = teknikDetayOzellikDilListe
                };

                UrunServis.WebServisResponse webServisResponse = StaticVariables.urunServisClient.UpdateTeknikDetayOzellikDil(StaticVariables.uyeKodu, updateTeknikDetayOzellikDilRequest);

                if (webServisResponse.IsError)
                    MessageBox.Show(webServisResponse.ErrorMessage);
                else
                    MessageBox.Show("Teknik detay özellik dili güncellendi");

                return webServisResponse;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static WebServisResponse UpdateTeknikDetayGrupDil()
        {
            try
            {
                List<TeknikDetayGrupDil> teknikDetayGrupDilListe = new List<TeknikDetayGrupDil>();
                TeknikDetayGrupDil teknikDetayGrupDil = new TeknikDetayGrupDil
                {
                    ID = 1,
                    Tanim = "tanım ingilizce"
                };
                teknikDetayGrupDilListe.Add(teknikDetayGrupDil);

                UpdateTeknikDetayGrupDilRequest updateTeknikDetayGrupDilRequest = new UpdateTeknikDetayGrupDilRequest
                {
                    Dil = "en", // dil kodu
                    Liste = teknikDetayGrupDilListe
                };

                UrunServis.WebServisResponse webServisResponse = StaticVariables.urunServisClient.UpdateTeknikDetayGrupDil(StaticVariables.uyeKodu, updateTeknikDetayGrupDilRequest);

                if (webServisResponse.IsError)
                    MessageBox.Show(webServisResponse.ErrorMessage);
                else
                    MessageBox.Show("Teknik detay grup dili güncellendi");

                return webServisResponse;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static WebServisResponse UpdateTeknikDetayDegerDil()
        {
            try
            {
                List<TeknikDetayDegerDil> teknikDetayDegerDilListe = new List<TeknikDetayDegerDil>();
                TeknikDetayDegerDil teknikDetayDegerDil = new TeknikDetayDegerDil
                {
                    ID = 1,
                    Tanim = "tanım ingilizce"
                };

                teknikDetayDegerDilListe.Add(teknikDetayDegerDil);

                UpdateTeknikDetayDegerDilRequest updateTeknikDetayDegerDilRequest = new UpdateTeknikDetayDegerDilRequest
                {
                    Dil = "en", // dil kodu 
                    Liste = teknikDetayDegerDilListe
                };

                UrunServis.WebServisResponse webServisResponse = StaticVariables.urunServisClient.UpdateTeknikDetayDegerDil(StaticVariables.uyeKodu, updateTeknikDetayDegerDilRequest);

                if (webServisResponse.IsError)
                    MessageBox.Show(webServisResponse.ErrorMessage);
                else
                    MessageBox.Show("Teknik detay değer dili güncellendi");

                return webServisResponse;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static WebServisResponse UpdateUrunDil()
        {
            try
            {
                UrunDilAyar urunDilAyar = new UrunDilAyar
                {
                    // hangi alanların güncelleneceğini belirtiyoruz. hiç yazmadığımız alanlar da false kabul edilir 
                    AciklamaGuncelle = true,
                    AramaAnahtarKelimeGuncelle = true,
                    OnYaziGuncelle = false,
                    SatisBirimiGuncelle = true,
                    SeoAnahtarKelimeGuncelle = false,
                    SeoNoFollowGuncelle = false,
                    SeoNoIndexGuncelle = false,
                    SeoSayfaAciklamaGuncelle = false,
                    SeoSayfaBaslikGuncelle = false,
                    UrunAdiGuncelle = true
                };

                // ürün dil listesini oluşturuyoruz.
                List<UrunDil> urunDilListe = new List<UrunDil>();

                // ürün dili oluşturuyoruz 
                UrunDil urunDil = new UrunDil
                {
                    // güncellenecek alanların güncellenecek değerlerini dolduruyoruz.
                    ID = 1,
                    Aciklama = "açıklama ingilizce",
                    AramaAnahtarKelime = "arama anahtar kelime ingilizce",
                    SatisBirimi = "satış birimi ingilizce",
                    UrunAdi = "ürün adi ingilizce",
                    //OnYazi="",
                    //SeoAnahtarKelime="",
                    //SeoNoFollow=true,
                    //SeoNoIndex=false,
                    //SeoSayfaAciklama="",
                    //SeoSayfaBaslik=""
                };

                // ürün dili  listeye ekliyoruz 
                urunDilListe.Add(urunDil);

                UpdateUrunDilRequest updateUrunDilRequest = new UpdateUrunDilRequest
                {
                    Ayar = urunDilAyar,
                    Dil = "en", // dil kodu
                    Liste = urunDilListe
                };

                UrunServis.WebServisResponse webServisResponse = StaticVariables.urunServisClient.UpdateUrunDil(StaticVariables.uyeKodu, updateUrunDilRequest);

                if (webServisResponse.IsError)
                    MessageBox.Show(webServisResponse.ErrorMessage);
                else
                    MessageBox.Show("Ürün dili güncellendi");

                return webServisResponse;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static WebServisResponse UpdateKategoriDil()
        {
            try
            {
                //güncelleme yapılacak alanların ayarı 
                // burada girilmeyen veya false girilen alan güncellenmez 
                KategoriDilAyar kategoriDilAyar = new KategoriDilAyar
                {
                    IcerikGuncelle = true,
                    SeoAnahtarKelimeGuncelle = true,
                    SeoSayfaAciklamaGuncelle = true,
                    SeoSayfaBaslikGuncelle = true,
                    TanimGuncelle = true
                };

                List<KategoriDil> kategoriDilListe = new List<KategoriDil>();
                KategoriDil kategoriDil = new KategoriDil
                {
                    ID = 1,
                    Icerik = "icerik ingilizce",
                    SeoAnahtarKelime = "seo anahtar kelime ingilizce",
                    SeoSayfaAciklama = "seo sayfa açıklama ingilizce",
                    SeoSayfaBaslik = "seo sayfa başlık ingilizce",
                    Tanim = "tanım ingilizce"
                };

                kategoriDilListe.Add(kategoriDil);
                UpdateKategoriDilRequest updateKategoriDilRequest = new UpdateKategoriDilRequest
                {
                    Ayar = kategoriDilAyar,
                    Dil = "en", // dil kodu 
                    Liste = kategoriDilListe
                };

                UrunServis.WebServisResponse webServisResponse = StaticVariables.urunServisClient.UpdateKategoriDil(StaticVariables.uyeKodu, updateKategoriDilRequest);

                if (webServisResponse.IsError)
                    MessageBox.Show(webServisResponse.ErrorMessage);
                else
                    MessageBox.Show("Kategori dili güncellendi");

                return webServisResponse;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static List<UrunOdemeSecenekBanka> GetTaksitSecenekleri()
        {
            try
            {
                List<UrunOdemeSecenekBanka> taksitSecenekListe = StaticVariables.urunServisClient.GetTaksitSecenekleri(StaticVariables.uyeKodu, 100, 4, "TRY");

                MessageBox.Show("Taksit seçenekleri listelendi.");

                // StaticFunctions.CevapListele(taksitSecenekListe.Cast<object>().ToList(), "Taksit Seçenekleri");

                return taksitSecenekListe;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static List<ParaBirimi> SelectParaBirimi()
        {
            try
            {
                List<ParaBirimi> paraBirimiListe = StaticVariables.urunServisClient.SelectParaBirimi(StaticVariables.uyeKodu, 0);

                MessageBox.Show("Para birimleri listelendi. " + paraBirimiListe.Count + " adet kayıtlı para biriminiz bulunmaktadır.");

                //StaticFunctions.CevapListele(paraBirimiListe.Cast<object>().ToList(), "Para Birimleri");

                return paraBirimiListe;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static int SaveParaBirimi()
        {
            try
            {
                ParaBirimi paraBirimi = new ParaBirimi
                {
                    ID = 0,//0 girilir ise yeni kayıt oluşturulur, 0 dan büyük girilirse girilen idli kayıt güncellenir.
                    Kur = 5.60,
                    DovizKodu = "USD",
                    Tanim = "Dolar",
                    Aktif = true, // aktiflik durumu eğer göndermezsek default olarak false değerini alır 
                    GuncellemeTarihi = DateTime.Now
                };

                int eklenenParaBirimiId = StaticVariables.urunServisClient.SaveParaBirimi(StaticVariables.uyeKodu, paraBirimi);

                if (eklenenParaBirimiId > 0)
                    MessageBox.Show("Para birimi  eklendi id : " + eklenenParaBirimiId);
                else
                    MessageBox.Show("Para birimi eklenemedi.");

                return eklenenParaBirimiId;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return 0;
            }

        }
        //public static List<EkSecenekGrup> SelectEkSecenekGrup()
        //{
        //    try
        //    {
        //        List<EkSecenekGrup> ekSecenekGrupListe = StaticVariables.urunServisClient.SelectEkSecenekGrup(StaticVariables.uyeKodu, "");

        //        MessageBox.Show("Ek seçenek gruplar listelendi. " + ekSecenekGrupListe.Count + " adet kayıtlı ek seçenek grup bulunmaktadır.");

        //        //StaticFunctions.CevapListele(ekSecenekGrupListe.Cast<object>().ToList(), "Ek Seçenek Gruplar");

        //        return ekSecenekGrupListe;
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message);
        //        return null;
        //    }
        //}
        //public static List<EkSecenekDeger> SelectEkSecenekDeger()
        //{
        //    try
        //    {
        //        List<EkSecenekDeger> ekSecenekDegerListe = StaticVariables.urunServisClient.SelectEkSecenekDeger(StaticVariables.uyeKodu, 0, "");

        //        MessageBox.Show("Ek seçenek değerler listelendi. " + ekSecenekDegerListe.Count + " adet kayıtlı ek seçenek değer bulunmaktadır.");

        //    //    StaticFunctions.CevapListele(ekSecenekDegerListe.Cast<object>().ToList(), "Ek Seçenek Değerler");

        //        return ekSecenekDegerListe;
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message);
        //        return null;
        //    }
        //}
        public static List<AsortiMiktar> SelectAsortiMiktar()
        {
            try
            {
                List<AsortiMiktar> asortiMiktarListe = StaticVariables.urunServisClient.SelectAsortiMiktar(StaticVariables.uyeKodu, 0);

                MessageBox.Show("Asorti miktarlar listelendi. " + asortiMiktarListe.Count + " adet kayıtlı asorti miktar bulunmaktadır.");

                //StaticFunctions.CevapListele(asortiMiktarListe.Cast<object>().ToList(), "Asorti Miktarlar");

                return asortiMiktarListe;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static List<AsortiGrup> SelectAsortiGrup()
        {
            try
            {
                List<AsortiGrup> asortiGrupListe = StaticVariables.urunServisClient.SelectAsortiGrup(StaticVariables.uyeKodu, 0);

                MessageBox.Show("Asorti gruplar listelendi. " + asortiGrupListe.Count + " adet kayıtlı asorti grubunuz bulunmaktadır.");

                //StaticFunctions.CevapListele(asortiGrupListe.Cast<object>().ToList(), "Asorti Gruplar");

                return asortiGrupListe;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static SaveResponse SaveAsortiMiktar()
        {
            try
            {
                AsortiMiktar asortiMiktar = new AsortiMiktar
                {
                    ID = 0, //0 girilir ise yeni kayıt oluşturulur, 0 dan büyük girilirse girilen idli kayıt güncellenir.
                    Adet = 1,
                    EkSecenekTanim = "kırmızı", //  eksecenek  tanımı. Eksecenek tablosunda girilen tanımlı bir eksecenek yok ise asorti miktar eklenmez. 
                    GrupID = 3, // asorti grup ıd
                };
                // gelen cevapte işlemin ne şekilde sonuçlandığına dair bilgi verilmektedir. 
                SaveResponse SaveAsortiMiktarCevap = StaticVariables.urunServisClient.SaveAsortiMiktar(StaticVariables.uyeKodu, asortiMiktar);

                if (SaveAsortiMiktarCevap.IsError)
                    MessageBox.Show(SaveAsortiMiktarCevap.ErrorMessage);
                else
                    MessageBox.Show("Asorti miktar eklendi id: " + SaveAsortiMiktarCevap.ItemId);

                return SaveAsortiMiktarCevap;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static SaveResponse SaveAsortiGrup()
        {
            try
            {
                AsortiGrup asortiGrup = new AsortiGrup
                {
                    ID = 0, //0 girilir ise yeni kayıt oluşturulur, 0 dan büyük girilirse girilen idli kayıt güncellenir.
                    EkSecenekTipi = "Renk", //  eksecenek tipi tanımı. Eksecenek tipi tablosunda girilen tanımlı bir eksecenek yok ise asorti grup eklenmez. 
                    Tanim = "asorti grup adı"
                };
                // gelen cevapte işlemin ne şekilde sonuçlandığına dair bilgi verilmektedir. 
                SaveResponse saveAsortiGrupCevap = StaticVariables.urunServisClient.SaveAsortiGrup(StaticVariables.uyeKodu, asortiGrup);

                if (saveAsortiGrupCevap.IsError)
                    MessageBox.Show(saveAsortiGrupCevap.ErrorMessage);
                else
                    MessageBox.Show("Asorti grup eklendi id: " + saveAsortiGrupCevap.ItemId);

                return saveAsortiGrupCevap;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static void VaryasyonGuncelle()
        {
            try
            {
                Varyasyon varyasyon = new Varyasyon
                {
                    // burada varyasyonun id sini ve bilgilerini giriyoruz. Alttaki değerler örnek olarak girilimiştir id dışında hiçbir değer zorunlu değildir.diğer özellikler de değiştirilmek istenildiği şekilde girilebilir. 

                    ID = 1, // güncelleme yapılacak varyasyona ait id                 
                    AlisFiyati = 10,
                    Aktif = false,
                    Barkod = "4545645565486",
                    Desi = 1,
                    TedarikciKodu = "tedarikçi kodu",
                    StokAdedi = 1285,
                    EksiStokAdedi = 5,
                    IndirimliFiyati = 12.10,
                    KargoUcreti = 4,
                    KdvDahil = true,
                    SatisFiyati = 15,
                    Resimler = new List<string> { "resim url", "resim url 2" }
                };
                VaryasyonAyar varyasyonAyar = new VaryasyonAyar
                {
                    // varyasyonda hangi ayarların güncellenip hangilerinin güncellenmeyeceği bilgisi verilir. Hiç yazılmayan değer de false olarak kabul edilir ve güncellenmez.
                    AktifGuncelle = true,
                    AlisFiyatiGuncelle = false,
                    BarkodGuncelle = true,
                    StokAdediGuncelle = true,
                    KargoAgirligiGuncelle = false,
                    EksiStokAdediGuncelle = true,
                    ResimOlmayanlaraResimEkle = true
                };

                StaticVariables.urunServisClient.VaryasyonGuncelle(StaticVariables.uyeKodu, varyasyon, varyasyonAyar);

                MessageBox.Show("varyasyon güncellendi");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        public static void SaveVaryasyon()
        {
            try
            {
                List<Varyasyon> varyasyonListe = new List<Varyasyon>();
                Varyasyon varyasyon = new Varyasyon
                {
                    // burada varyasyonun id sini ve bilgilerini giriyoruz. Alttaki değerler örnek olarak girilimiştir id dışında hiçbir değer zorunlu değildir.diğer özellikler de değiştirilmek istenildiği şekilde girilebilir. 

                    ID = 1, // güncelleme yapılacak varyasyona ait id                 
                    AlisFiyati = 10,
                    Aktif = false,
                    Barkod = "4545645565486",
                    Desi = 1,
                    TedarikciKodu = "tedarikçi kodu",
                    StokAdedi = 1285,
                    EksiStokAdedi = 5,
                    IndirimliFiyati = 12.10,
                    KargoUcreti = 4,
                    KdvDahil = true,
                    SatisFiyati = 15,
                    Resimler = new List<string> { "resim url", "resim url 2" }
                };
                varyasyonListe.Add(varyasyon);
                VaryasyonAyar varyasyonAyar = new VaryasyonAyar
                {
                    // varyasyonda hangi ayarların güncellenip hangilerinin güncellenmeyeceği bilgisi verilir. Hiç yazılmayan değer de false olarak kabul edilir ve güncellenmez.
                    StokAdediGuncelle = true,
                    //KonsinyeUrunStokAdediGuncelle = true,
                    //TahminiTeslimSuresiTarihGuncelle = true,
                    AktifGuncelle = false,
                    AlisFiyatiGuncelle = true,
                    EksiStokAdediGuncelle = false,
                    BarkodGuncelle = false,
                    EkSecenekGuncelle = true
                };
                //response = 1= başarılı , 0=başarısız
                int response = StaticVariables.urunServisClient.SaveVaryasyon(StaticVariables.uyeKodu, varyasyonListe, varyasyonAyar);

                MessageBox.Show("varyasyon eklendi.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        public static int SelectVaryasyonCount()
        {
            try
            {
                VaryasyonFiltre varyasyonFiltre = new VaryasyonFiltre
                {
                    Aktif = -1, // -1 gönderilir ise bu alana göre filtleme yapılmaz 
                    Barkod = "", // boş gönderilebilir
                                 //StokGuncellemeTarihiBas = DateTime.Now, // filtrede kullanılmak istenmiyor ise yazılmamalı. 
                                 //StokGuncellemeTarihiSon = DateTime.Now, // filtrede kullanılmak istenmiyor ise yazılmamalı.
                    StokKodu = "",// boş gönderilebilir
                    UrunID = -1, // -1 gönderilir ise bu alana göre filtleme yapılmaz
                    UrunKartiID = -1 // -1 gönderilir ise bu alana göre filtreleme yapılmaz.
                };

                int filtrelereGoreVaryasyonSayisi = StaticVariables.urunServisClient.SelectVaryasyonCount(StaticVariables.uyeKodu, varyasyonFiltre);

                MessageBox.Show("Filtrelere göre bulunan varyasyon sayısı: " + filtrelereGoreVaryasyonSayisi);

                return filtrelereGoreVaryasyonSayisi;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return 0;
            }
        }


        public static List<UrunKarti> GetUrunlistWithRetry(string WSYetki, UrunFiltre urunFiltre, UrunSayfalama urunSayfalama, int maxAttempts = 3, int delayBetweenAttempts = 1000)
        {
            int attempts = 0;
            List<UrunKarti> kategoriListe = null;

            while ((kategoriListe == null || kategoriListe.Count == 0))
            {
                try
                {
                    attempts++;
                    kategoriListe = StaticVariables.urunServisClient.SelectUrun(WSYetki, urunFiltre, urunSayfalama);
                    if (kategoriListe != null && kategoriListe.Count > 0) break; // Eğer sipariş listesi alındıysa döngüden çık
                }
                catch (Exception ex)
                {
                    // Loglama veya hata yönetimi
                    Console.WriteLine($"Deneme {attempts}: {ex.Message}");
                }

                // Belirlenen süre kadar bekleyin
                if (kategoriListe == null || kategoriListe.Count == 0)
                {
                    Thread.Sleep(delayBetweenAttempts);
                    return kategoriListe;
                }
            }

            return kategoriListe;
        }

        public static List<Varyasyon> GetUrunlistVaryasyonWithRetry(string WSYetki, VaryasyonFiltre varyasyonFiltre, UrunSayfalama urunSayfalama, SelectVaryasyonAyar selectVaryasyonAyar, int maxAttempts = 3, int delayBetweenAttempts = 1000)
        {
            int attempts = 0;
            List<Varyasyon> kategoriListe = null;

            while ((kategoriListe == null || kategoriListe.Count == 0))
            {
                try
                {
                    attempts++;
                    kategoriListe = StaticVariables.urunServisClient.SelectVaryasyon(WSYetki, varyasyonFiltre, urunSayfalama, selectVaryasyonAyar);
                    if (kategoriListe != null && kategoriListe.Count > 0) break; // Eğer sipariş listesi alındıysa döngüden çık
                }
                catch (Exception ex)
                {
                    // Loglama veya hata yönetimi
                    Console.WriteLine($"Deneme {attempts}: {ex.Message}");
                }

                // Belirlenen süre kadar bekleyin
                if (kategoriListe == null || kategoriListe.Count == 0)
                {
                    Thread.Sleep(delayBetweenAttempts);
                    return kategoriListe;
                }
            }

            return kategoriListe;
        }



        public static List<UrunKarti> SelectUrun()
        {
            try
            {
                // Ürün çekme
                // Filtre değerleri :
                // -1 : Filtre yok
                // 0 : false
                // 1 : true
                // Bu değerler 'Aktif','Firsat','indirimli' ve 'Vitrin' için geçerlidir.
                List<UrunKarti> toplamUrunKartiListesi = new List<UrunKarti>();
                try
                {
                    int baslangicIndex = 0;
                    int kayitSayisi = 1000; // Her seferinde çekilecek kayıt sayısı
                    bool devam = true;
                    string tarihString = "2020-01-15 12:20:13.000";
                    DateTime? eklemeTarihiBaslangic;

                    if (DateTime.TryParse(tarihString, out DateTime parsedDate))
                    {
                        eklemeTarihiBaslangic = parsedDate;
                    }
                    else
                    {
                        eklemeTarihiBaslangic = null; // veya uygun bir hata yönetimi
                    }
                    while (devam)
                    {
                        UrunFiltre urunFiltre = new UrunFiltre
                        {
                            Aktif = -1,
                            Firsat = -1,
                            Indirimli = -1,
                            Vitrin = -1,
                            KategoriID = 0, // 0 gönderilirse filtre yapılmaz.
                            MarkaID = 0, // 0 gönderilirse filtre yapılmaz.
                            UrunKartiID = 0, //0 gönderilirse filtre yapılmaz.    
                            EklemeTarihiBaslangic = eklemeTarihiBaslangic,
                            //Barkod="1564654812", //barkod girilirse sadece o barkodlu ürün gelir. 
                            //ToplamStokAdediBas = 0,
                            //ToplamStokAdediSon = 4,
                            TedarikciID = 0, // 0 gönderilirse filtre yapılmaz
                        };
                        UrunSayfalama urunSayfalama = new UrunSayfalama
                        {
                            BaslangicIndex = baslangicIndex,
                            KayitSayisi = kayitSayisi,
                            SiralamaDegeri = "ID", // Hangi sütuna göre sıralanacağı
                            SiralamaYonu = "ASC", // Artan "ASC", azalan "DESC"                
                        };
                        string sitead = Properties.Settings.Default.txtSiteAdi;
                        string WSYetki = Properties.Settings.Default.txtWsYetki;
                        StaticVariables.urunServisClient = new UrunServis.UrunServisClient();

                        StaticVariables.urunServisClient.Endpoint.Address = new System.ServiceModel.EndpointAddress($"https://{sitead}/Servis/UrunServis.svc");

                        //List<WebSiparisUrun> uyeAdresListe = new List<WebSiparisUrun>();
                        //List<UrunKarti> FiltrelenenUrunKartiListe = UrunServiceMethods.GetUrunlistWithRetry(WSYetki, urunFiltre, urunSayfalama);

                        ////List<Kategori> kategoriListe = UrunServiceMethods.GetUrunWithRetry(WSYetki, 0, "");
                        ////List<UrunKarti> siparisListe = SiparisServiceMethods.GetSiparisWithRetry(WSYetki, webSiparisFiltre, webSiparisSayfalama);
                        //if (FiltrelenenUrunKartiListe != null && FiltrelenenUrunKartiListe.Count > 0)
                        //{
                        //    UrunKartlariniKaydet(FiltrelenenUrunKartiListe);
                        //}
                        //else
                        //{


                        //    MessageBox.Show("Siparişler Çekilemedi Tekrar deneyin.");
                        //    // Sipariş listesi alınamadıysa uygun bir hata mesajı göster

                        //}
                        List<UrunKarti> FiltrelenenUrunKartiListe = UrunServiceMethods.GetUrunlistWithRetry(WSYetki, urunFiltre, urunSayfalama);

                        if (FiltrelenenUrunKartiListe != null && FiltrelenenUrunKartiListe.Count > 0)
                        {
                            toplamUrunKartiListesi.AddRange(FiltrelenenUrunKartiListe);
                            UrunKartlariniKaydet(FiltrelenenUrunKartiListe);
                            baslangicIndex += kayitSayisi; // BaslangicIndex değerini artırın
                        }
                        else
                        {
                            devam = false; // Cevap gelmediğinde döngüyü durdur
                            MessageBox.Show("Tüm ürünler çekildi ve kaydedildi.");
                        }
                    }
                    MessageBox.Show("Tüm ürünler çekildi ve kaydedildi.");
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Bir hata oluştu: " + exception.Message);
                }
                return toplamUrunKartiListesi;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static List<Varyasyon> SelectVaryasyon()
        {
            try
            {
                List<Varyasyon> toplamUrunVaryasyonListesi = new List<Varyasyon>();
                try
                {
                    int baslangicIndex = 0;
                    int kayitSayisi = 1000; // Her seferinde çekilecek kayıt sayısı
                                            // int baslangicIndex = 0;
                                            //  int kayitSayisi = 1000; // Her seferinde çekilecek kayıt sayısı
                    bool devam = true;

                    while (devam)
                    {
                        VaryasyonFiltre varyasyonFiltre = new VaryasyonFiltre
                        {
                            Aktif = -1,
                            Barkod = "", // boş gönderilebilir
                                         //StokGuncellemeTarihiBas = new DateTime(2018,12,05), // filtrede kullanılmak istenmiyor ise yazılmamalı. 
                                         //StokGuncellemeTarihiSon = DateTime.Now, // filtrede kullanılmak istenmiyor ise yazılmamalı.
                            StokKodu = "",// boş gönderilebilir
                            UrunID = -1, // -1 gönderilir ise bu alana göre filtleme yapılmaz
                            UrunKartiID = -1 // -1 gönderilir ise bu alana göre filtreleme yapılmaz.
                        };

                        UrunSayfalama urunSayfalama = new UrunSayfalama
                        {
                            BaslangicIndex = baslangicIndex, // bulunan kayıtların baslangıç index i  - zorunlu değil 
                            KayitSayisi = kayitSayisi, // kaç kayıt getireleceği bilgisi, - zorunlu değil girilmez ise bulunan tüm kayıtlar gösterilir.
                            SiralamaDegeri = "id", // kayıtların hangi alana göre sıralanacağı - zorunlu değil 
                            SiralamaYonu = "Desc" // zorunlu değil 
                        };
                        string sitead = Properties.Settings.Default.txtSiteAdi;
                        string WSYetki = Properties.Settings.Default.txtWsYetki;
                        StaticVariables.urunServisClient = new UrunServis.UrunServisClient();

                        StaticVariables.urunServisClient.Endpoint.Address = new System.ServiceModel.EndpointAddress($"https://{sitead}/Servis/UrunServis.svc");
                        SelectVaryasyonAyar selectVaryasyonAyar = new SelectVaryasyonAyar { KategoriGetir = true };
                        //List<Varyasyon> varyasyonListe = StaticVariables.urunServisClient.SelectVaryasyon(StaticVariables.uyeKodu, varyasyonFiltre, urunSayfalama, selectVaryasyonAyar);

                        List<Varyasyon> varyasyonListe = UrunServiceMethods.GetUrunlistVaryasyonWithRetry(WSYetki, varyasyonFiltre, urunSayfalama, selectVaryasyonAyar);

                        if (varyasyonListe != null && varyasyonListe.Count > 0)
                        {
                            toplamUrunVaryasyonListesi.AddRange(varyasyonListe);
                            UrunVariantlariKaydet(varyasyonListe);
                            baslangicIndex += kayitSayisi; // BaslangicIndex değerini artırın
                        }
                        else
                        {
                            devam = false; // Cevap gelmediğinde döngüyü durdur
                            MessageBox.Show("Tüm ürünler çekildi ve kaydedildi.");
                        }


                    }
                    MessageBox.Show("Tüm Varyasyonlar çekildi ve kaydedildi.");
                    return toplamUrunVaryasyonListesi;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    return null;
                }

            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
                return null;
            }

        }
        public static List<Etiket> SelectEtiket()
        {
            try
            {
                //List<Etiket> etiketListe = StaticVariables.urunServisClient.SelectEtiket(StaticVariables.uyeKodu, 0);

                //MessageBox.Show("Etiketler listelendi. " + etiketListe.Count + "adet kayıtlı etiketiniz bulunmaktadır.");
                MessageBox.Show("Etiketler listelendi. " + StaticVariables.etiketList.Count + " adet kayıtlı etiketiniz bulunmaktadır.");

                //StaticFunctions.CevapListele(StaticVariables.etiketList.Cast<object>().ToList(), "Etiketler");

                return StaticVariables.etiketList;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static int SaveEtiket()
        {
            try
            {
                Etiket etiket = new Etiket
                {
                    ID = 0,//0 girilir ise yeni kayıt oluşturulur, 0 dan büyük girilirse girilen idli kayıt güncellenir.
                    Resim = "", // etiket resmi - boş gönderilebilir.
                    SeoAnahtarKelime = "giysi giyim", // SEO optimizasyonu için kullanılan kelimeler
                    SeoSayfaAciklama = "Açıklama", // SEO optimizasyonu için kullanılan açıklama
                    SeoSayfaBaslik = "Başlık", // SEO optimizasyonu için kullanılan sayfa başlığı
                    Tanim = "etiket adı",
                    Url = "etiket url" // boş gönderilebilir.

                };
                int eklenenEtiketId = StaticVariables.urunServisClient.SaveEtiket(StaticVariables.uyeKodu, etiket);

                if (eklenenEtiketId > 0)
                    MessageBox.Show("Etiket eklendi id: " + eklenenEtiketId);
                else
                    MessageBox.Show("Etiket eklenemedi eklenemedi.");

                return eklenenEtiketId;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return 0;
            }
        }
        //public static List<TeknikDetayOzellik> SelectTeknikDetayOzellik()
        //{
        //    try
        //    {
        //        List<TeknikDetayOzellik> teknikDetayOzellikListe = StaticVariables.urunServisClient.SelectTeknikDetayOzellik(StaticVariables.uyeKodu, 0, "");

        //        MessageBox.Show("Teknik detay özellikler listelendi. " + teknikDetayOzellikListe.Count + " adet kayıtlı teknik detay özelliğiniz bulunmaktadır.");



        //        return teknikDetayOzellikListe;
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message);
        //        return null;
        //    }
        //}
        //public static List<TeknikDetayGrup> SelectTeknikDetayGrup()
        //{
        //    try
        //    {
        //        List<TeknikDetayGrup> teknikDetayGrupListe = StaticVariables.urunServisClient.SelectTeknikDetayGrup(StaticVariables.uyeKodu, 0, "");

        //        MessageBox.Show("Teknik detay gruplar listelendi. " + teknikDetayGrupListe.Count + " adet kayıtlı teknik detay grubunuz bulunmaktadır.");

        //       // StaticFunctions.CevapListele(teknikDetayGrupListe.Cast<object>().ToList(), "Teknik Detay Gruplar");

        //        return teknikDetayGrupListe;
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message);
        //        return null;
        //    }
        //}
        //public static List<TeknikDetayDeger> SelectTeknikDetayDeger()
        //{
        //    try
        //    {
        //        List<TeknikDetayDeger> teknikDetayDegerListe = StaticVariables.urunServisClient.SelectTeknikDetayDeger(StaticVariables.uyeKodu, 0, "");

        //        MessageBox.Show("Teknik detay değerler listelendi. " + teknikDetayDegerListe.Count + " adet kayıtlı teknik detay değeriniz bulunmaktadır.");

        //     //   StaticFunctions.CevapListele(teknikDetayDegerListe.Cast<object>().ToList(), "Teknik Detay Değerler");

        //        return teknikDetayDegerListe;
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message);
        //        return null;
        //    }
        //}
        public static int SaveTeknikDetayOzellik()
        {
            try
            {
                TeknikDetayOzellik teknikDetayOzellik = new TeknikDetayOzellik
                {
                    GrupID = 1,
                    ID = 0, //0 girilir ise yeni kayıt oluşturulur, 0 dan büyük girilirse girilen idli kayıt güncellenir.
                    Sira = 5,
                    Tanim = "özellik tanım"
                };
                int eklenenTeknikDetayOzellikId = StaticVariables.urunServisClient.SaveTeknikDetayOzellik(StaticVariables.uyeKodu, teknikDetayOzellik);

                if (eklenenTeknikDetayOzellikId > 0)
                    MessageBox.Show("Teknik detay özellik eklendi id: " + eklenenTeknikDetayOzellikId);
                else
                    MessageBox.Show("Teknik detay özellik eklenemedi.");

                return eklenenTeknikDetayOzellikId;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return 0;
            }
        }
        public static int SaveTeknikDetayGrup()
        {
            try
            {
                TeknikDetayGrup teknikDetayGrup = new TeknikDetayGrup
                {
                    ID = 0, //0 girilir ise yeni kayıt oluşturulur, 0 dan büyük girilirse girilen idli kayıt güncellenir.
                    Sira = 2,
                    Tanim = "Teknik detay grup ismi"
                };

                int eklenenTeknikDetayGrupId = StaticVariables.urunServisClient.SaveTeknikDetayGrup(StaticVariables.uyeKodu, teknikDetayGrup);

                if (eklenenTeknikDetayGrupId > 0)
                    MessageBox.Show("Teknik detay grup eklendi id: " + eklenenTeknikDetayGrupId);
                else
                    MessageBox.Show("Teknik detay grup eklenemedi.");

                return eklenenTeknikDetayGrupId;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return 0;
            }
        }
        public static int SaveTeknikDetayDeger()
        {
            try
            {
                TeknikDetayDeger teknikDetayDeger = new TeknikDetayDeger
                {
                    ID = 0, //0 girilir ise yeni kayıt oluşturulur, 0 dan büyük girilirse girilen idli kayıt güncellenir. 
                    OzellikID = 1, // Ozellik id değeri. 
                    Tanim = "Teknik detay 1",
                    Sira = 1
                };

                int eklenenTeknikDetayId = StaticVariables.urunServisClient.SaveTeknikDetayDeger(StaticVariables.uyeKodu, teknikDetayDeger);

                if (eklenenTeknikDetayId > 0)
                    MessageBox.Show("Teknik detay değer eklendi id: " + eklenenTeknikDetayId);
                else
                    MessageBox.Show("Teknik detay değer eklenemedi.");

                return eklenenTeknikDetayId;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return 0;
            }
        }
        public static List<UrunKategori> SelectUrunKategori()
        {
            try
            {
                // ürün kartı Id ve ürün kategori id 0 gönderilir ise tüm ürün ve kategori eşleşmeleri getirilir.
                // Eğer ürün karti id 0 dan büyük kategori id 0 olarak gönderilir ise girilen ürün kartı id yi içeren tüm kayıtlar getirilir. 
                // Eğer kategori id 0 dan büyük ürün kartı id 0 gönderilir ise girilen kategori id yi içeren tüm kayıtlar getirilir.

                List<UrunKategori> urunKategori = StaticVariables.urunServisClient.SelectUrunKategori(StaticVariables.uyeKodu, 322, 0);

                MessageBox.Show("Ürün kategoriler listelendi. " + urunKategori.Count + " adet ürün kategori kaydınız bulunmaktadır.");

                //   StaticFunctions.CevapListele(urunKategori.Cast<object>().ToList(), "Ürün Kategorileri");

                return urunKategori;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static List<UrunYorum> SelectUrunYorum()
        {
            try
            {
                List<UrunYorum> urunyorumListe = StaticVariables.urunServisClient.SelectUrunYorum(StaticVariables.uyeKodu, -1);

                MessageBox.Show(urunyorumListe.Count + " adet yorum bulundu.");

                //  StaticFunctions.CevapListele(urunyorumListe.Cast<object>().ToList(), "Ürün Yorumları");

                return urunyorumListe;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static List<UrunOdemeSecenek> SelectUrunOdemeSecenek()
        {
            try
            {


                List<UrunOdemeSecenek> urunOdemeSecenekListe = StaticVariables.urunServisClient.SelectUrunOdemeSecenek(StaticVariables.uyeKodu, 0);

                MessageBox.Show(urunOdemeSecenekListe.Count + " adet ödeme seçenek bulundu.");

                //  StaticFunctions.CevapListele(urunOdemeSecenekListe.Cast<object>().ToList(), "Ürün Ödeme Seçenekleri");

                return urunOdemeSecenekListe;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static int SelectUrunCount()
        {
            try
            {
                // Ürün çekme
                // Filtre değerleri :
                // -1 : Filtre yok
                // 0 : false
                // 1 : true
                // Bu değerler 'Aktif','Firsat','indirimli' ve 'Vitrin' için geçerlidir.

                UrunFiltre urunFiltre = new UrunFiltre
                {
                    Aktif = -1,
                    Firsat = -1,
                    Indirimli = -1,
                    Vitrin = -1,
                    KategoriID = 0, // 0 gönderilirse filtre yapılmaz.
                    MarkaID = 0, // 0 gönderilirse filtre yapılmaz.
                    UrunKartiID = 0, //0 gönderilirse filtre yapılmaz.                                  
                                     //Barkod="1564654812", //barkod girilirse sadece o barkodlu ürün gelir. 
                                     //ToplamStokAdediBas = 0,
                                     //ToplamStokAdediSon = 500,
                    TedarikciID = 0, // 0 gönderilirse filtre yapılmaz
                };

                int urunSayisi = StaticVariables.urunServisClient.SelectUrunCount(StaticVariables.uyeKodu, urunFiltre);

                MessageBox.Show("Filtrelere göre bulunan ürün sayısı: " + urunSayisi);

                return urunSayisi;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return 0;
            }
        }



        public class VaryasyonZ
        {
            public int ID { get; set; } // Varyasyon ID'si
            public int ParaBirimiID { get; set; } // Para birimi ID'si
            public decimal SatisFiyati { get; set; } // Satış fiyatı
            public string TedarikciKodu { get; set; } // Tedarikçi kodu

            // Gerekli olabilecek diğer özellikler buraya eklenebilir.
        }

        public class UrunKartiZ
        {
            public int ID { get; set; } // Ürün kartı ID'si
            public bool Aktif { get; set; } // Ürünün aktif durumu
            public string UrunAdi { get; set; } // Ürün adı
            public string Aciklama { get; set; } // Ürün açıklaması
            public string AnaKategori { get; set; } // Ana kategori
            public int AnaKategoriID { get; set; } // Ana kategori ID'si
            public List<int> Kategoriler { get; set; } // Kategori ID'leri listesi
            public int MarkaID { get; set; } // Marka ID'si
            public int TedarikciID { get; set; } // Tedarikçi ID'si
            public string SatisBirimi { get; set; } // Satış birimi
            public bool UcretsizKargo { get; set; } // Ücretsiz kargo seçeneği
            public List<VaryasyonZ> Varyasyonlar { get; set; } // Varyasyon listesi
            public bool Vitrin { get; set; } // Vitrinde olup olmama durumu
            public bool YeniUrun { get; set; } // Yeni ürün mü değil mi

            // Gerekli olabilecek diğer özellikler ve metodlar buraya eklenebilir.
        }
        public class KategoriZ
        {
            public int KategoriID { get; set; }
        }

        public static List<UrunServis.UrunKarti> GetUrunKartlariFromDatabase()
        {
            List<UrunServis.UrunKarti> urunKartlari = new List<UrunServis.UrunKarti>();

            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};MultipleActiveResultSets=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("MSG_GetMSGTicimaxUrunKategori", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 3000;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var kategoriString = reader.GetString(reader.GetOrdinal("Kategoriler"));
                            var kategoriStringArray = kategoriString.Split(new string[] { "],[" }, StringSplitOptions.None);
                            List<int> kategoriIDs = new List<int>();

                            foreach (var item in kategoriStringArray)
                            {
                                var cleanItem = item.Replace("[", "").Replace("]", "");
                                int kategoriId;
                                if (int.TryParse(cleanItem, out kategoriId))
                                {
                                    kategoriIDs.Add(kategoriId);
                                }
                            }

                            var urunKarti = new UrunServis.UrunKarti
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("UrunID")),
                                Aktif = true,
                                UrunAdi = reader.GetString(reader.GetOrdinal("UrunAdi")),
                                Aciklama = reader.GetString(reader.GetOrdinal("Aciklama")),
                                AnaKategori = reader.GetString(reader.GetOrdinal("AnaKategori")),
                                AnaKategoriID = reader.GetInt32(reader.GetOrdinal("AnaKategoriID")),
                                Kategoriler = kategoriIDs,
                                MarkaID = 0,
                                TedarikciID = 0,
                                SatisBirimi = reader.GetString(reader.GetOrdinal("SatisBirimi")),
                                UcretsizKargo = true,
                                Vitrin = true,
                                YeniUrun = true,
                                // Varyasyonları ve diğer alanları doldurun
                            };

                            // Varyasyonları ve diğer ilişkili verileri doldurun
                            urunKarti.Varyasyonlar = GetVaryasyonlarForUrun(urunKarti.ID, connection);

                            urunKartlari.Add(urunKarti);
                        }
                    }
                }
            }

            return urunKartlari;
        }

        public static List<UrunServis.Varyasyon> GetVaryasyonlarForUrun(int urunId, SqlConnection connection)
        {
            List<UrunServis.Varyasyon> varyasyonlar = new List<UrunServis.Varyasyon>();

            // Varyasyon bilgilerini çekmek için gereken stored procedure veya SQL sorgusunu buraya yazın.
            // Bu örnekte, "GetVaryasyonlar" adında hayali bir stored procedure varsayıyoruz.
            using (SqlCommand command = new SqlCommand("MSG_GetMSGTicimaxUrunVaryasyon", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 3000;
                command.Parameters.AddWithValue("@UrunId", urunId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var varyasyon = new UrunServis.Varyasyon
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("VaryasyonID")),
                            ParaBirimiID = reader.GetInt32(reader.GetOrdinal("ParaBirimiID")),
                            SatisFiyati = 238.99,
                            TedarikciKodu = "",
                            UrunKartiID = reader.GetInt32(reader.GetOrdinal("UrunKartiID"))
                        };
                        varyasyonlar.Add(varyasyon);
                    }
                }
            }

            return varyasyonlar;
        }



        //public static void SaveUrun()
        //{
        //    try
        //    {
        //        // Ürün Ekleme
        //        // Ürünün ait olduğu kategori idleri
        //        List<int> kategoriIDS = new List<int>();
        //        kategoriIDS.Add(12);
        //        kategoriIDS.Add(34);
        //        kategoriIDS.Add(1594);
        //        kategoriIDS.Add(763);
        //        kategoriIDS.Add(55);
        //        //kategoriIDS.Add(1);  // 1 id li bir kategori yoksa ürün eklerken hata alınır.         
        //        // Ürünün resim linkleri
        //        //List<string> resimLinkleri = new List<string>();
        //        //resimLinkleri.Add("http://www.siteniz.com/resim1.png");
        //        //resimLinkleri.Add("http://www.siteniz.com/resim2.png");
        //        // Ürün varyasyon özelliklerini belirleme
        //        //List<UrunServis.VaryasyonOzellik> ozellikler = new List<UrunServis.VaryasyonOzellik>();
        //        //ozellikler.Add(new UrunServis.VaryasyonOzellik { Tanim = "Numara", Deger = "38" });
        //        //ozellikler.Add(new UrunServis.VaryasyonOzellik { Tanim = "Renk", Deger = "Mavi" });
        //        // Ürün varyasyon resim linkleri
        //        //List<string> varyasyonResimler = new List<string>();
        //        //varyasyonResimler.Add("http://www.siteniz.com/varyasyonluResim.png");
        //        //varyasyonResimler.Add("http://www.siteniz.com/varyasyonluResim2.png");
        //        //varyasyonResimler.Add("http://www.siteniz.com/varyasyonluResim3.png");

        //        ////Urun Kartı etiket listeleri
        //        //List<UrunKartiEtiket> urunKartiEtiketListe = new List<UrunKartiEtiket> { new UrunKartiEtiket { EtiketID = 1 } }; // 1 id li bir etiket yoksa ürün eklerken hata alınır.  

        //        //// urun kartı teknik detay liste 
        //        //List<UrunKartiTeknikDetay> urunKartiTeknikDetayListe = new List<UrunKartiTeknikDetay>
        //        //{
        //        //    new UrunKartiTeknikDetay{ DegerID=1 , OzellikID = 1 }
        //        //};

        //        // Ürün varyasyonlarını belirleme. En az bir varyasyon zorunludur!
        //        // * işaretli alanlar zorunlu alanlardır. 
        //        UrunServis.Varyasyon varyasyon = new UrunServis.Varyasyon
        //        {

        //            ID = 7021, //* 0 ise yeni varyasyon ekler, sıfırdan büyük ise o id'ye sahip olan varyasyonu günceller


        //            ParaBirimiID = 1, // * sitede yer alan para birimlerinde birini girmesi gerekir. 

        //            SatisFiyati = 100, // * 


        //            TedarikciKodu = "", // tedarikçi koduna göre güncelle true ise zorunlu

        //        };

        //        List<UrunServis.Varyasyon> varyasyonlar = new List<UrunServis.Varyasyon>();
        //        varyasyonlar.Add(varyasyon);
        //        // Ürün Kartı alanları. "*" işaretli alanlar zorunludur.
        //        UrunServis.UrunKarti urunKarti = new UrunServis.UrunKarti
        //        {
        //            ID = 1603, // 0 ise yeni ürünkartı ekler, sıfırdan büyük ise o id'ye sahip olan ürünkartını
        //                       // günceller.
        //            Aktif = true, // *
        //            UrunAdi = "Ürün Adı", // *
        //            Aciklama = "Açıklama", // *
        //            AnaKategori = "Kadın", // * Breadcrumbs da kullanılacak
        //            AnaKategoriID = 11, // * Breadcrumbs da kullanılacak - zorunlu 0 olursa ürün görünmez. 
        //            Kategoriler = kategoriIDS, // *
        //            MarkaID = StaticVariables.markaList[0].ID, //ilk markanın ID'si. 
        //            //MarkaID = 1, // *  1 idli bir marka olmazsa hata alınır.
        //            TedarikciID = StaticVariables.tedarikciList[0].ID, //ilk tedarikcinin ID'si. 
        //            //TedarikciID = 1, // * 1 idli bir tedarikçi olmazsa hata alınır. 
        //            //Resimler = resimLinkleri, // *
        //            SatisBirimi = "Adet", // *
        //            UcretsizKargo = true, // *

        //            Varyasyonlar = varyasyonlar, // *
        //            Vitrin = true,
        //            YeniUrun = true,




        //        };
        //        // Ürün Kartını listeye ekleme
        //        List<UrunServis.UrunKarti> urunKartlari = new List<UrunServis.UrunKarti>();
        //        urunKartlari.Add(urunKarti);

        //        // Ürün Kartı ayarları.
        //        UrunServis.UrunKartiAyar urunKartiAyar = new UrunServis.UrunKartiAyar
        //        {
        //            AciklamaGuncelle = false,
        //            AktifGuncelle = false,
        //            FBStoreGosterGuncelle = false,
        //            FirsatUrunuGuncelle = false,
        //            KategoriGuncelle = true,
        //            MaksTaksitSayisiGuncelle = false,
        //            MarkaGuncelle = false,
        //            OnYaziGuncelle = false,
        //            ParaPuanGuncelle = false,
        //            SatisBirimiGuncelle = false,
        //            SeoAnahtarKelimeGuncelle = false,
        //            SeoSayfaAciklamaGuncelle = false,
        //            SeoSayfaBaslikGuncelle = false,
        //            TedarikciGuncelle = false,
        //            UcretsizKargoGuncelle = false,
        //            UrunAdiGuncelle = false,
        //            UrunResimGuncelle = false,
        //            VitrinGuncelle = false,
        //            YeniUrunGuncelle = false,
        //            AdwordsAciklamaGuncelle = false,
        //            AdwordsKategoriGuncelle = false,
        //            AdwordsTipGuncelle = false,
        //            UserAgent = "", // boş gönderilebilir .
        //            AramaAnahtarKelimeGuncelle = false,
        //            AsortiGrupGuncelle = false,
        //            Base64Resim = false,
        //            EtiketGuncelle = false,
        //            KargoTipiGuncelle = false,
        //            OncekiKategoriEslestirmeleriniTemizle = false,
        //            OncekiResimleriSil = false,
        //            OzelAlan1Guncelle = false,
        //            OzelAlan2Guncelle = false,
        //            OzelAlan3Guncelle = false,
        //            OzelAlan4Guncelle = false,
        //            OzelAlan5Guncelle = false,
        //            ResimleriIndirme = false,
        //            ResimOlmayanlaraResimEkle = false,
        //            SeoNoFollowGuncelle = false,
        //            SeoNoIndexGuncelle = false,
        //            TahminiTeslimSuresiGuncelle = false,
        //            TedarikciKodunaGoreGuncelle = false,
        //            TeknikDetayGuncelle = false,
        //            UrunAdresiniElleOlustur = false,
        //            UyeAlimMaksGuncelle = false,
        //            UyeAlimMinGuncelle = false


        //        };
        //        // Varyasyon ayarları.
        //        UrunServis.VaryasyonAyar urunVaryasyonAyar = new UrunServis.VaryasyonAyar
        //        {

        //            AktifGuncelle = false,
        //            AlisFiyatiGuncelle = false,
        //            BarkodGuncelle = false,
        //            IndirimliFiyatiGuncelle = false,
        //            KargoUcretiGuncelle = false,
        //            KargoAgirligiGuncelle = false,
        //            ParaBirimiGuncelle = false,
        //            SatisFiyatiGuncelle = false,
        //            StokAdediGuncelle = false,
        //            UyeTipiFiyat1Guncelle = false,
        //            UyeTipiFiyat2Guncelle = false,
        //            UyeTipiFiyat3Guncelle = false,
        //            UyeTipiFiyat4Guncelle = false,
        //            UyeTipiFiyat5Guncelle = false,
        //            EksiStokAdediGuncelle = false,
        //            KdvDahilGuncelle = false,
        //            KdvOraniGuncelle = false,
        //            OncekiResimleriSil = false,
        //            ResimOlmayanlaraResimEkle = false,
        //            StokKoduGuncelle = false,
        //            UrunResimGuncelle = false,

        //        };
        //        // Ürünü ekliyoruz
        //        //  eklenen ürün id leri referans olarak gönderilen urunKartlari listesinde dolu olarak gelir. 
        //        StaticVariables.urunServisClient.SaveUrun(StaticVariables.uyeKodu, ref urunKartlari, urunKartiAyar, urunVaryasyonAyar);

        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message);
        //    }
        //}

        public static void StokFiyatGuncelle()
        {
            try
            {
                // Veritabanından ürün kartlarını ve onlara ait varyasyonları çeken metodu çağır
                List<UrunServis.UrunKarti> urunKartlariZ = GetUrunKartlariFromDatabase();

                // ÜrünServis.UrunKarti ve ÜrünServis.Varyasyon listelerini oluştur
                //  List<UrunKartiZ> urunKartlari = new List<UrunKartiZ>();
                List<UrunServis.Varyasyon> varyasyonlar = new List<UrunServis.Varyasyon>();
                List<UrunServis.UrunKarti> urunServisKartlari = new List<UrunServis.UrunKarti>();

                foreach (var urunKartiZ in urunKartlariZ)
                {
                    foreach (var varyasyonZ in urunKartiZ.Varyasyonlar)
                    {
                        Varyasyon varyasyon = new Varyasyon
                        {
                            ID = varyasyonZ.ID,
                            ParaBirimiID = varyasyonZ.ParaBirimiID,
                            SatisFiyati = varyasyonZ.SatisFiyati, // Decimal'den double'a dönüşüm
                            TedarikciKodu = varyasyonZ.TedarikciKodu,
                            UrunKartiID = varyasyonZ.UrunKartiID
                        };
                        varyasyonlar.Add(varyasyon);
                    }

                    // ÜrünServis.UrunKarti nesnesini doldur
                    UrunServis.UrunKarti urunKarti = new UrunServis.UrunKarti
                    {
                        ID = urunKartiZ.ID,
                        Aktif = urunKartiZ.Aktif,
                        UrunAdi = urunKartiZ.UrunAdi,
                        Aciklama = urunKartiZ.Aciklama,
                        AnaKategori = urunKartiZ.AnaKategori,
                        AnaKategoriID = urunKartiZ.AnaKategoriID,
                        Kategoriler = urunKartiZ.Kategoriler.ToArray().ToList(),// Diziye çevrilmiş kategori ID'leri
                        MarkaID = 4, //ilk markanın ID'si. 
                                     //MarkaID = 1, // *  1 idli bir marka olmazsa hata alınır.
                        TedarikciID = 2, //ilk tedarikcinin ID'si. 
                        SatisBirimi = urunKartiZ.SatisBirimi,
                        UcretsizKargo = urunKartiZ.UcretsizKargo,
                        Vitrin = urunKartiZ.Vitrin,
                        YeniUrun = urunKartiZ.YeniUrun,
                        Varyasyonlar = varyasyonlar.Where(x => x.UrunKartiID == urunKartiZ.ID).ToList()
                        // *
                        // Varyasyonlar ve diğer eksik özellikler burada doldurulabilir.
                    };

                    // VaryasyonZ listesini ÜrünServis.Varyasyon listesine dönüştür

                    /*   urunKarti.Varyasyonlar = varyasyonlar.ToArray().ToList(); */// Diziye çevrilmiş varyasyonlar
                    urunServisKartlari.Add(urunKarti);
                }
                UrunServis.UrunKartiAyar urunKartiAyar = new UrunServis.UrunKartiAyar
                {
                    AciklamaGuncelle = false,
                    AktifGuncelle = false,
                    FBStoreGosterGuncelle = false,
                    FirsatUrunuGuncelle = false,
                    KategoriGuncelle = true,
                    MaksTaksitSayisiGuncelle = false,
                    MarkaGuncelle = false,
                    OnYaziGuncelle = false,
                    ParaPuanGuncelle = false,
                    SatisBirimiGuncelle = false,
                    SeoAnahtarKelimeGuncelle = false,
                    SeoSayfaAciklamaGuncelle = false,
                    SeoSayfaBaslikGuncelle = false,
                    TedarikciGuncelle = false,
                    UcretsizKargoGuncelle = false,
                    UrunAdiGuncelle = false,
                    UrunResimGuncelle = false,
                    VitrinGuncelle = false,
                    YeniUrunGuncelle = false,
                    AdwordsAciklamaGuncelle = false,
                    AdwordsKategoriGuncelle = false,
                    AdwordsTipGuncelle = false,
                    UserAgent = "", // boş gönderilebilir .
                    AramaAnahtarKelimeGuncelle = false,
                    AsortiGrupGuncelle = false,
                    Base64Resim = false,
                    EtiketGuncelle = false,
                    KargoTipiGuncelle = false,
                    OncekiKategoriEslestirmeleriniTemizle = true,
                    OncekiResimleriSil = false,
                    OzelAlan1Guncelle = false,
                    OzelAlan2Guncelle = false,
                    OzelAlan3Guncelle = false,
                    OzelAlan4Guncelle = false,
                    OzelAlan5Guncelle = false,
                    ResimleriIndirme = false,
                    ResimOlmayanlaraResimEkle = false,
                    SeoNoFollowGuncelle = false,
                    SeoNoIndexGuncelle = false,
                    TahminiTeslimSuresiGuncelle = false,
                    TedarikciKodunaGoreGuncelle = false,
                    TeknikDetayGuncelle = false,
                    UrunAdresiniElleOlustur = false,
                    UyeAlimMaksGuncelle = false,
                    UyeAlimMinGuncelle = false


                };
                // Varyasyon ayarları.
                UrunServis.VaryasyonAyar urunVaryasyonAyar = new UrunServis.VaryasyonAyar
                {

                    AktifGuncelle = false,
                    AlisFiyatiGuncelle = true,
                    BarkodGuncelle = false,
                    IndirimliFiyatiGuncelle = true,
                    KargoUcretiGuncelle = false,
                    KargoAgirligiGuncelle = false,
                    ParaBirimiGuncelle = false,
                    SatisFiyatiGuncelle = true,
                    StokAdediGuncelle = true,
                    UyeTipiFiyat1Guncelle = false,
                    UyeTipiFiyat2Guncelle = false,
                    UyeTipiFiyat3Guncelle = false,
                    UyeTipiFiyat4Guncelle = false,
                    UyeTipiFiyat5Guncelle = false,
                    EksiStokAdediGuncelle = false,
                    KdvDahilGuncelle = false,
                    KdvOraniGuncelle = false,
                    OncekiResimleriSil = false,
                    ResimOlmayanlaraResimEkle = false,
                    StokKoduGuncelle = false,
                    UrunResimGuncelle = false,

                };

                // Ürün kartı ve varyasyonları kaydet
                // Not: StaticVariables.urunServisClient.SaveUrun metodunun imzası ve parametreleri semboliktir. Gerçek imzanıza göre düzenlemelisiniz.
                string sitead = Properties.Settings.Default.txtSiteAdi;
                string WSYetki = Properties.Settings.Default.txtWsYetki;
                StaticVariables.urunServisClient = new UrunServis.UrunServisClient();

                StaticVariables.urunServisClient.Endpoint.Address = new System.ServiceModel.EndpointAddress($"https://{sitead}/Servis/UrunServis.svc");
                int batchSize = 100;
                for (int i = 0; i < urunServisKartlari.Count; i += batchSize)
                {
                    // Her seferinde 20 (veya kalan) öğeyi al
                    var batch = urunServisKartlari.Skip(i).Take(batchSize).ToList();

                    // Batch'i işle. Not: SaveUrun metodunun ref olarak beklediği listeyi doğru bir şekilde yönettiğinizden emin olun.
                    // Bu örnek sadece gösterim amaçlıdır, SaveUrun metodunuzun imzasına ve beklediği parametrelere göre düzenlemeler yapmanız gerekebilir.
                    var response = UrunServiceMethods.SaveUrunWithRetry(WSYetki, ref batch, urunKartiAyar, urunVaryasyonAyar);
                    // Burada batch içindeki öğeler başarıyla işlendiyse, gerekiyorsa ek işlemler yapabilirsiniz.
                }

                Console.WriteLine("Ürünler başarıyla kaydedildi.");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Hata: " + exception.Message);
            }
        }

        public static void SaveUrun()
        {
            try
            {
                // Veritabanından ürün kartlarını ve onlara ait varyasyonları çeken metodu çağır
                List<UrunServis.UrunKarti> urunKartlariZ = GetUrunKartlariFromDatabase();

                // ÜrünServis.UrunKarti ve ÜrünServis.Varyasyon listelerini oluştur
                //  List<UrunKartiZ> urunKartlari = new List<UrunKartiZ>();
                List<UrunServis.Varyasyon> varyasyonlar = new List<UrunServis.Varyasyon>();
                List<UrunServis.UrunKarti> urunServisKartlari = new List<UrunServis.UrunKarti>();

                foreach (var urunKartiZ in urunKartlariZ)
                {
                    foreach (var varyasyonZ in urunKartiZ.Varyasyonlar)
                    {
                        Varyasyon varyasyon = new Varyasyon
                        {
                            ID = varyasyonZ.ID,
                            ParaBirimiID = varyasyonZ.ParaBirimiID,
                            SatisFiyati = varyasyonZ.SatisFiyati, // Decimal'den double'a dönüşüm
                            TedarikciKodu = varyasyonZ.TedarikciKodu,
                            UrunKartiID = varyasyonZ.UrunKartiID
                        };
                        varyasyonlar.Add(varyasyon);
                    }

                    // ÜrünServis.UrunKarti nesnesini doldur
                    UrunServis.UrunKarti urunKarti = new UrunServis.UrunKarti
                    {
                        ID = urunKartiZ.ID,
                        Aktif = urunKartiZ.Aktif,
                        UrunAdi = urunKartiZ.UrunAdi,
                        Aciklama = urunKartiZ.Aciklama,
                        AnaKategori = urunKartiZ.AnaKategori,
                        AnaKategoriID = urunKartiZ.AnaKategoriID,
                        Kategoriler = urunKartiZ.Kategoriler.ToArray().ToList(),// Diziye çevrilmiş kategori ID'leri
                        MarkaID = 4, //ilk markanın ID'si. 
                                     //MarkaID = 1, // *  1 idli bir marka olmazsa hata alınır.
                        TedarikciID = 2, //ilk tedarikcinin ID'si. 
                        SatisBirimi = urunKartiZ.SatisBirimi,
                        UcretsizKargo = urunKartiZ.UcretsizKargo,
                        Vitrin = urunKartiZ.Vitrin,
                        YeniUrun = urunKartiZ.YeniUrun,
                        Varyasyonlar = varyasyonlar.Where(x => x.UrunKartiID == urunKartiZ.ID).ToList()
                    // *
                    // Varyasyonlar ve diğer eksik özellikler burada doldurulabilir.
                };

                    // VaryasyonZ listesini ÜrünServis.Varyasyon listesine dönüştür
                 
                    /*   urunKarti.Varyasyonlar = varyasyonlar.ToArray().ToList(); */// Diziye çevrilmiş varyasyonlar
                    urunServisKartlari.Add(urunKarti);
                }
                UrunServis.UrunKartiAyar urunKartiAyar = new UrunServis.UrunKartiAyar
                {
                    AciklamaGuncelle = false,
                    AktifGuncelle = false,
                    FBStoreGosterGuncelle = false,
                    FirsatUrunuGuncelle = false,
                    KategoriGuncelle = true,
                    MaksTaksitSayisiGuncelle = false,
                    MarkaGuncelle = false,
                    OnYaziGuncelle = false,
                    ParaPuanGuncelle = false,
                    SatisBirimiGuncelle = false,
                    SeoAnahtarKelimeGuncelle = false,
                    SeoSayfaAciklamaGuncelle = false,
                    SeoSayfaBaslikGuncelle = false,
                    TedarikciGuncelle = false,
                    UcretsizKargoGuncelle = false,
                    UrunAdiGuncelle = false,
                    UrunResimGuncelle = false,
                    VitrinGuncelle = false,
                    YeniUrunGuncelle = false,
                    AdwordsAciklamaGuncelle = false,
                    AdwordsKategoriGuncelle = false,
                    AdwordsTipGuncelle = false,
                    UserAgent = "", // boş gönderilebilir .
                    AramaAnahtarKelimeGuncelle = false,
                    AsortiGrupGuncelle = false,
                    Base64Resim = false,
                    EtiketGuncelle = false,
                    KargoTipiGuncelle = false,
                    OncekiKategoriEslestirmeleriniTemizle = true,
                    OncekiResimleriSil = false,
                    OzelAlan1Guncelle = false,
                    OzelAlan2Guncelle = false,
                    OzelAlan3Guncelle = false,
                    OzelAlan4Guncelle = false,
                    OzelAlan5Guncelle = false,
                    ResimleriIndirme = false,
                    ResimOlmayanlaraResimEkle = false,
                    SeoNoFollowGuncelle = false,
                    SeoNoIndexGuncelle = false,
                    TahminiTeslimSuresiGuncelle = false,
                    TedarikciKodunaGoreGuncelle = false,
                    TeknikDetayGuncelle = false,
                    UrunAdresiniElleOlustur = false,
                    UyeAlimMaksGuncelle = false,
                    UyeAlimMinGuncelle = false


                };
                // Varyasyon ayarları.
                UrunServis.VaryasyonAyar urunVaryasyonAyar = new UrunServis.VaryasyonAyar
                {

                    AktifGuncelle = false,
                    AlisFiyatiGuncelle = false,
                    BarkodGuncelle = false,
                    IndirimliFiyatiGuncelle = false,
                    KargoUcretiGuncelle = false,
                    KargoAgirligiGuncelle = false,
                    ParaBirimiGuncelle = false,
                    SatisFiyatiGuncelle = false,
                    StokAdediGuncelle = false,
                    UyeTipiFiyat1Guncelle = false,
                    UyeTipiFiyat2Guncelle = false,
                    UyeTipiFiyat3Guncelle = false,
                    UyeTipiFiyat4Guncelle = false,
                    UyeTipiFiyat5Guncelle = false,
                    EksiStokAdediGuncelle = false,
                    KdvDahilGuncelle = false,
                    KdvOraniGuncelle = false,
                    OncekiResimleriSil = false,
                    ResimOlmayanlaraResimEkle = false,
                    StokKoduGuncelle = false,
                    UrunResimGuncelle = false,

                };

                // Ürün kartı ve varyasyonları kaydet
                // Not: StaticVariables.urunServisClient.SaveUrun metodunun imzası ve parametreleri semboliktir. Gerçek imzanıza göre düzenlemelisiniz.
                string sitead = Properties.Settings.Default.txtSiteAdi;
                string WSYetki = Properties.Settings.Default.txtWsYetki;
                StaticVariables.urunServisClient = new UrunServis.UrunServisClient();

                StaticVariables.urunServisClient.Endpoint.Address = new System.ServiceModel.EndpointAddress($"https://{sitead}/Servis/UrunServis.svc");
                int batchSize = 100;
                for (int i = 0; i < urunServisKartlari.Count; i += batchSize)
                {
                    // Her seferinde 20 (veya kalan) öğeyi al
                    var batch = urunServisKartlari.Skip(i).Take(batchSize).ToList();

                    // Batch'i işle. Not: SaveUrun metodunun ref olarak beklediği listeyi doğru bir şekilde yönettiğinizden emin olun.
                    // Bu örnek sadece gösterim amaçlıdır, SaveUrun metodunuzun imzasına ve beklediği parametrelere göre düzenlemeler yapmanız gerekebilir.
                    var response = UrunServiceMethods.SaveUrunWithRetry(WSYetki, ref batch, urunKartiAyar, urunVaryasyonAyar);
                    // Burada batch içindeki öğeler başarıyla işlendiyse, gerekiyorsa ek işlemler yapabilirsiniz.
                }

                Console.WriteLine("Ürünler başarıyla kaydedildi.");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Hata: " + exception.Message);
            }
        }

        public static List<UrunKarti> SaveUrunWithRetry(string WSYetki, ref List<UrunKarti> urunKartlari, UrunKartiAyar urunKartiAyar, VaryasyonAyar urunVaryasyonAyar, int maxAttempts = 3, int delayBetweenAttempts = 1000)
        {
            int attempts = 0;
            List<UrunKarti> failedUrunListe = new List<UrunKarti>();

            while (attempts < maxAttempts && urunKartlari.Count > 0)
            {
                attempts++;
                try
                {
                    TimeSpan tm = new TimeSpan(0, 10, 0);

                    StaticVariables.urunServisClient.Endpoint.Binding.CloseTimeout = tm;
                    // Servisi çağır
                    StaticVariables.urunServisClient.SaveUrun(WSYetki, ref urunKartlari, urunKartiAyar, urunVaryasyonAyar);

                    // Eğer çağrı başarılıysa, tüm ürün kartlarının başarıyla işlendiğini varsay ve döngüden çık
                    break;
                }
                catch (Exception ex)
                {
                    // Loglama veya hata yönetimi
                    Console.WriteLine($"Deneme {attempts}: {ex.Message}");

                    // Hata durumunda, belirlenen süre kadar bekleyip tekrar dene
                    if (attempts < maxAttempts)
                    {
                        Thread.Sleep(delayBetweenAttempts);
                    }
                    else
                    {
                        // Maksimum deneme sayısına ulaşıldığında, başarısız olan ürün kartlarını döndür
                        failedUrunListe.AddRange(urunKartlari);
                    }
                }
            }

            // Başarısız olan ürün kartlarını içeren listeyi döndür
            return failedUrunListe;
        }

        //public static List<UrunKarti> SaveUrunWithRetry(string WSYetki, urunKartlari, UrunKartiAyar urunKartiAyar, VaryasyonAyar urunVaryasyonAyar, int maxAttempts = 3, int delayBetweenAttempts = 1000)
        //{
        //    int attempts = 0;
        //    List<UrunKarti> kategoriListe = null;

        //    while ((kategoriListe == null || kategoriListe.Count == 0))
        //    {
        //        try
        //        {
        //            attempts++;
        //            kategoriListe = StaticVariables.urunServisClient.SaveUrun(WSYetki, urunKartlari, urunKartiAyar, urunVaryasyonAyar);
        //            if (kategoriListe != null && kategoriListe.Count > 0) break; // Eğer sipariş listesi alındıysa döngüden çık
        //        }
        //        catch (Exception ex)
        //        {
        //            // Loglama veya hata yönetimi
        //            Console.WriteLine($"Deneme {attempts}: {ex.Message}");
        //        }

        //        // Belirlenen süre kadar bekleyin
        //        if (kategoriListe == null || kategoriListe.Count == 0)
        //        {
        //            Thread.Sleep(delayBetweenAttempts);
        //        }
        //    }

        //    return kategoriListe;
        //}




        public static void UrunKartlariniKaydet(List<UrunKarti> urunKartiListesi)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // ID'leri tek bir string'e dönüştür
                List<int> varOlanIdler = new List<int>();
                string idListesi = string.Join(",", urunKartiListesi.Select(u => u.ID.ToString()));

                // Geçici tabloyu oluştur

                // ID'leri geçici tabloya doldur
                SqlCommand insertTempTableCmd = new SqlCommand(
                    "INSERT INTO ztTemps (ID) SELECT ID FROM fnSplitter(@idListesi)", connection);
                insertTempTableCmd.Parameters.AddWithValue("@idListesi", idListesi);
                insertTempTableCmd.ExecuteNonQuery();

                using (SqlCommand cmd = new SqlCommand("SELECT ztTemps.ID FROM ztTemps  Left Outer Join ZTMSGTicimaxUrunKarti on ZTMSGTicimaxUrunKarti.ID =ztTemps.ID    WHERE ZTMSGTicimaxUrunKarti.ID is not null", connection))
                {
                    cmd.Parameters.AddWithValue("@idListesi", idListesi);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            varOlanIdler.Add(reader.GetInt32(0));
                        }
                    }
                }
                urunKartiListesi = urunKartiListesi.Where(u => !varOlanIdler.Contains(u.ID)).ToList();
                foreach (UrunKarti urunKarti in urunKartiListesi)
                {
                    // İhtiyacınıza göre alanları ekleyin veya çıkarın
                    string query = @" 
 IF NOT EXISTS (SELECT 1 FROM ZTMSGTicimaxUrunKarti WHERE ID = @ID)
                BEGIN
        INSERT INTO ZTMSGTicimaxUrunKarti (
            ID, Aktif, AnaKategoriID, AramaAnahtarKelime, Marka, SeoAnahtarKelime, 
            SeoSayfaAciklama, SeoSayfaBaslik, UrunAdi, EklemeTarihi, YeniUrun, Sira, 
            ListedeGoster, EntegrasyonID, UrunKapidaOdemeYasakli, UcretsizKargo, 
            Vitrin, FBStoreGoster, FirsatUrunu, MaksTaksitSayisi, UrunAdediKademeDeger, 
            UrunAdediMinimumDeger, UrunAdediVarsayilanDeger, UrunAdediOndalikliSayiGirilebilir, 
            UyeAlimMin, UyeAlimMax, MarkaID, TedarikciID, TedarikciKodu, 
            TedarikciKodu2, YayinTarihi, OnYazi, Aciklama, DuzenleyenKullanici, EkleyenKullanici, KargoTipi, TahminiTeslimSuresi, 
            TahminiTeslimSuresiAyniGun, TahminiTeslimSuresiGoster, TakimKampanyaId, 
            TakimUrun, TeknikDetayGrupID, ToplamStokAdedi, UrunSayfaAdresi, 
            YonlendirmeAdresi, SeoNoFollow, SeoNoIndex, PuanDeger, OzelAlan1, OzelAlan2, 
            OzelAlan3, OzelAlan4, OzelAlan5, AdwordsAciklama, AdwordsKategori, 
            AdwordsTip, AnaKategori, AsortiGrupID, MarketPlaceAktif, 
            MarketPlaceAktif2, MarketPlaceAktif3, SatisBirimi
        ) 
        SELECT 
            @ID, @Aktif, @AnaKategoriID, @AramaAnahtarKelime, @Marka, @SeoAnahtarKelime, 
            @SeoSayfaAciklama, @SeoSayfaBaslik, @UrunAdi, @EklemeTarihi, @YeniUrun, @Sira, 
            @ListedeGoster, @EntegrasyonID, @UrunKapidaOdemeYasakli, @UcretsizKargo, 
            @Vitrin, @FBStoreGoster, @FirsatUrunu, @MaksTaksitSayisi, @UrunAdediKademeDeger, 
            @UrunAdediMinimumDeger, @UrunAdediVarsayilanDeger, @UrunAdediOndalikliSayiGirilebilir, 
            @UyeAlimMin, @UyeAlimMax, @MarkaID, @TedarikciID, @TedarikciKodu, 
            @TedarikciKodu2, @YayinTarihi, @OnYazi, @Aciklama, @DuzenleyenKullanici, @EkleyenKullanici, @KargoTipi, @TahminiTeslimSuresi, 
            @TahminiTeslimSuresiAyniGun, @TahminiTeslimSuresiGoster, @TakimKampanyaId, 
            @TakimUrun, @TeknikDetayGrupID, @ToplamStokAdedi, @UrunSayfaAdresi, 
            @YonlendirmeAdresi, @SeoNoFollow, @SeoNoIndex, @PuanDeger, @OzelAlan1, @OzelAlan2, 
            @OzelAlan3, @OzelAlan4, @OzelAlan5, @AdwordsAciklama, @AdwordsKategori, 
            @AdwordsTip, @AnaKategori, @AsortiGrupID, @MarketPlaceAktif, 
            @MarketPlaceAktif2, @MarketPlaceAktif3, @SatisBirimi
        WHERE NOT EXISTS (SELECT 1 FROM ZTMSGTicimaxUrunKarti WHERE ID = @ID) END";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parametrelerinizi ekleyin
                        command.Parameters.AddWithValue("@ID", urunKarti.ID);
                        command.Parameters.AddWithValue("@Aktif", urunKarti.Aktif);
                        command.Parameters.AddWithValue("@AnaKategoriID", urunKarti.AnaKategoriID);
                        command.Parameters.AddWithValue("@AramaAnahtarKelime", (urunKarti.AramaAnahtarKelime ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@Marka", (urunKarti.Marka ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@SeoAnahtarKelime", (urunKarti.SeoAnahtarKelime ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@SeoSayfaAciklama", (urunKarti.SeoSayfaAciklama ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@SeoSayfaBaslik", (urunKarti.SeoSayfaBaslik ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@UrunAdi", (urunKarti.UrunAdi ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@EklemeTarihi", (urunKarti.EklemeTarihi.Equals(default(DateTime)) ? (object)DBNull.Value : urunKarti.EklemeTarihi));
                        command.Parameters.AddWithValue("@YeniUrun", urunKarti.YeniUrun);
                        command.Parameters.AddWithValue("@Sira", urunKarti.Sira);
                        command.Parameters.AddWithValue("@ListedeGoster", urunKarti.ListedeGoster);
                        command.Parameters.AddWithValue("@EntegrasyonID", (urunKarti.EntegrasyonID ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@UrunKapidaOdemeYasakli", urunKarti.UrunKapidaOdemeYasakli);
                        command.Parameters.AddWithValue("@UcretsizKargo", urunKarti.UcretsizKargo);
                        command.Parameters.AddWithValue("@Vitrin", urunKarti.Vitrin);
                        command.Parameters.AddWithValue("@FBStoreGoster", urunKarti.FBStoreGoster);
                        command.Parameters.AddWithValue("@FirsatUrunu", urunKarti.FirsatUrunu);
                        command.Parameters.AddWithValue("@MaksTaksitSayisi", urunKarti.MaksTaksitSayisi);
                        command.Parameters.AddWithValue("@UrunAdediKademeDeger", urunKarti.UrunAdediKademeDeger);
                        command.Parameters.AddWithValue("@UrunAdediMinimumDeger", urunKarti.UrunAdediMinimumDeger);
                        command.Parameters.AddWithValue("@UrunAdediVarsayilanDeger", urunKarti.UrunAdediVarsayilanDeger);
                        command.Parameters.AddWithValue("@UrunAdediOndalikliSayiGirilebilir", urunKarti.UrunAdediOndalikliSayiGirilebilir);
                        command.Parameters.AddWithValue("@UyeAlimMin", urunKarti.UyeAlimMin);
                        command.Parameters.AddWithValue("@UyeAlimMax", urunKarti.UyeAlimMax);
                        command.Parameters.AddWithValue("@MarkaID", urunKarti.MarkaID);
                        command.Parameters.AddWithValue("@TedarikciID", urunKarti.TedarikciID);
                        command.Parameters.AddWithValue("@TedarikciKodu", (urunKarti.TedarikciKodu ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@TedarikciKodu2", (urunKarti.TedarikciKodu2 ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@YayinTarihi", (urunKarti.YayinTarihi.Equals(default(DateTime)) ? (object)DBNull.Value : urunKarti.YayinTarihi));
                        command.Parameters.AddWithValue("@OnYazi", (urunKarti.OnYazi ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@Aciklama", (urunKarti.Aciklama ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@DuzenleyenKullanici", urunKarti.DuzenleyenKullanici);
                        command.Parameters.AddWithValue("@EkleyenKullanici", urunKarti.EkleyenKullanici);
                        // ... Diğer alanlarınız için de benzer şekilde parametreler ekleyin ...

                        command.Parameters.AddWithValue("@KargoTipi", urunKarti.KargoTipi);
                        command.Parameters.AddWithValue("@TahminiTeslimSuresi", urunKarti.TahminiTeslimSuresi);
                        command.Parameters.AddWithValue("@TahminiTeslimSuresiAyniGun", urunKarti.TahminiTeslimSuresiAyniGun);
                        command.Parameters.AddWithValue("@TahminiTeslimSuresiGoster", urunKarti.TahminiTeslimSuresiGoster);
                        command.Parameters.AddWithValue("@TakimKampanyaId", urunKarti.TakimKampanyaId);
                        command.Parameters.AddWithValue("@TakimUrun", urunKarti.TakimUrun);
                        command.Parameters.AddWithValue("@TeknikDetayGrupID", urunKarti.TeknikDetayGrupID);
                        command.Parameters.AddWithValue("@ToplamStokAdedi", urunKarti.ToplamStokAdedi);
                        command.Parameters.AddWithValue("@UrunSayfaAdresi", (urunKarti.UrunSayfaAdresi ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@YonlendirmeAdresi", (urunKarti.YonlendirmeAdresi ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@SeoNoFollow", urunKarti.SeoNoFollow);
                        command.Parameters.AddWithValue("@SeoNoIndex", urunKarti.SeoNoIndex);
                        command.Parameters.AddWithValue("@PuanDeger", urunKarti.PuanDeger);
                        command.Parameters.AddWithValue("@OzelAlan1", (urunKarti.OzelAlan1 ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@OzelAlan2", (urunKarti.OzelAlan2 ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@OzelAlan3", (urunKarti.OzelAlan3 ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@OzelAlan4", (urunKarti.OzelAlan4 ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@OzelAlan5", (urunKarti.OzelAlan5 ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@AdwordsAciklama", (urunKarti.AdwordsAciklama ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@AdwordsKategori", (urunKarti.AdwordsKategori ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@AdwordsTip", (urunKarti.AdwordsTip ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@AnaKategori", (urunKarti.AnaKategori ?? (object)DBNull.Value));
                        command.Parameters.AddWithValue("@AsortiGrupID", urunKarti.AsortiGrupID);
                        command.Parameters.AddWithValue("@MarketPlaceAktif", urunKarti.MarketPlaceAktif);
                        command.Parameters.AddWithValue("@MarketPlaceAktif2", urunKarti.MarketPlaceAktif2);
                        command.Parameters.AddWithValue("@MarketPlaceAktif3", urunKarti.MarketPlaceAktif3);
                        command.Parameters.AddWithValue("@SatisBirimi", (urunKarti.SatisBirimi ?? (object)DBNull.Value));

                        // Her bir UrunKarti nesnesi için kaydetme işlemini gerçekleştirin
                        command.ExecuteNonQuery();
                    }
                }
                // Geçici tablo ve ZTMSGTicimaxUrunKarti arasında kontrol yap ve yoksa ekle


                // SqlCommand nesnesini oluştur

                // SqlCommand'a parametre olarak DataTable'ı ekle


                // Geçici tabloyu kaldır
                SqlCommand dropTempTableCmd = new SqlCommand("delete ztTemps", connection);
                dropTempTableCmd.ExecuteNonQuery();
            }
        }

        //        public static void UrunVariantlariKaydet(List<Varyasyon> urunVaryasyonListesi)
        //        {
        //            string serverName = Properties.Settings.Default.SunucuAdi;
        //            string userName = Properties.Settings.Default.KullaniciAdi;
        //            string password = Properties.Settings.Default.Sifre;
        //            string database = Properties.Settings.Default.database;
        //            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

        //            using (SqlConnection connection = new SqlConnection(connectionString))
        //            {
        //                connection.Open();

        //                // ID'leri tek bir string'e dönüştür
        //                List<int> varOlanIdler = new List<int>();
        //                string idListesi = string.Join(",", urunVaryasyonListesi.Select(u => u.ID.ToString()));

        //                // Geçici tabloyu oluştur

        //                // ID'leri geçici tabloya doldur
        //                SqlCommand insertTempTableCmd = new SqlCommand(
        //                    "INSERT INTO ztTemps (ID) SELECT ID FROM fnSplitter(@idListesi)", connection);
        //                insertTempTableCmd.Parameters.AddWithValue("@idListesi", idListesi);
        //                insertTempTableCmd.ExecuteNonQuery();

        //                using (SqlCommand cmd = new SqlCommand("SELECT ztTemps.ID FROM ztTemps  Left Outer Join ZTMSGTicimaxUrunKarti on ZTMSGTicimaxUrunKarti.ID =ztTemps.ID    WHERE ZTMSGTicimaxUrunKarti.ID is not null", connection))
        //                {
        //                    cmd.Parameters.AddWithValue("@idListesi", idListesi);
        //                    using (SqlDataReader reader = cmd.ExecuteReader())
        //                    {
        //                        while (reader.Read())
        //                        {
        //                            varOlanIdler.Add(reader.GetInt32(0));
        //                        }
        //                    }
        //                }
        //                urunVaryasyonListesi = urunVaryasyonListesi.Where(u => !varOlanIdler.Contains(u.ID)).ToList();
        //                foreach (Varyasyon urunKarti in urunVaryasyonListesi)
        //                {
        //                    // İhtiyacınıza göre alanları ekleyin veya çıkarın
        //                    string query = @" 
        // IF NOT EXISTS (SELECT 1 FROM ZtTicimaxVaryasyonList WHERE ID = @ID)
        //BEGIN
        //    INSERT INTO ZtTicimaxVaryasyonList (
        //        ID, Aktif, AlisFiyati, Barkod, Desi, Desi2, DuzenleyenKullanici, EkleyenKullanici,
        //        EksiStokAdedi, GtipKodu, IndirimliFiyati, IndirimliFiyati1, IndirimliFiyati2,
        //        IndirimliFiyati3, IndirimliFiyati4, IndirimliFiyati5, IndirimliFiyati6,
        //        IndirimliFiyati7, IndirimliFiyati8, IndirimliFiyati9, IndirimliFiyati10,
        //        IscilikAgirlik, IscilikParaBirimi, IscilikParaBirimiId, IscilikParaBirimiKodu,
        //        KargoUcreti, KdvDahil, KdvDahil1, KdvDahil2, KdvDahil3, KdvDahil4,
        //        KdvDahil5, KdvDahil6, KdvDahil7, KdvDahil8, KdvDahil9, KdvDahil10, KdvOrani,
        //        KdvOrani1, KdvOrani2, KdvOrani3, KdvOrani4, KdvOrani5, KdvOrani6, KdvOrani7,
        //        KdvOrani8, KdvOrani9, KdvOrani10, KonsinyeStokAdedi, MarkaID, MarketPlaceAktif,
        //        MarketPlaceAktif2, MarketPlaceAktif3, MarketPlaceAktif4, MarketPlaceAktif5,
        //        ParaBirimi, ParaBirimiID, ParaBirimiKodu, PiyasaFiyati, SatisFiyati,
        //        SatisFiyati1, SatisFiyati2, SatisFiyati3, SatisFiyati4, SatisFiyati5,
        //        SatisFiyati6, SatisFiyati7, SatisFiyati8, SatisFiyati9, SatisFiyati10,
        //        StokAdedi, StokGuncellemeTarihi, StokKodu, TahminiTeslimSuresi,
        //        TahminiTeslimSuresiAyniGun, TahminiTeslimSuresiGoster, TahminiTeslimSuresiTarih,
        //        TedarikciKodu, TedarikciKodu2, TedarikciKomisyonOrani, UpdateKey, UrunAgirligi,
        //        UrunDerinlik, UrunGenislik, UrunKartiAktif, UrunKartiID, UrunYukseklik,
        //        UyeAlimMax, UyeAlimMin, UyeTipiFiyat1, UyeTipiFiyat2, UyeTipiFiyat3,
        //        UyeTipiFiyat4, UyeTipiFiyat5, UyeTipiFiyat6, UyeTipiFiyat7, UyeTipiFiyat8,
        //        UyeTipiFiyat9, UyeTipiFiyat10
        //    ) 
        //      SELECT 
        //        @ID, @Aktif, @AlisFiyati, @Barkod, @Desi, @Desi2, @DuzenleyenKullanici, @EkleyenKullanici,
        //        @EksiStokAdedi, @GtipKodu, @IndirimliFiyati, @IndirimliFiyati1, @IndirimliFiyati2,
        //        @IndirimliFiyati3, @IndirimliFiyati4, @IndirimliFiyati5, @IndirimliFiyati6,
        //        @IndirimliFiyati7, @IndirimliFiyati8,@IndirimliFiyati9, @IndirimliFiyati10, @IscilikAgirlik, @IscilikParaBirimi, @IscilikParaBirimiId, @IscilikParaBirimiKodu,
        //@KargoUcreti, @KdvDahil, @KdvDahil1, @KdvDahil2, @KdvDahil3, @KdvDahil4,
        //@KdvDahil5, @KdvDahil6, @KdvDahil7, @KdvDahil8, @KdvDahil9, @KdvDahil10, @KdvOrani,
        //@KdvOrani1, @KdvOrani2, @KdvOrani3, @KdvOrani4, @KdvOrani5, @KdvOrani6, @KdvOrani7,
        //@KdvOrani8, @KdvOrani9, @KdvOrani10, @KonsinyeStokAdedi, @MarkaID, @MarketPlaceAktif,
        //@MarketPlaceAktif2, @MarketPlaceAktif3, @MarketPlaceAktif4, @MarketPlaceAktif5,
        //@ParaBirimi, @ParaBirimiID, @ParaBirimiKodu, @PiyasaFiyati, @SatisFiyati,
        //@SatisFiyati1, @SatisFiyati2, @SatisFiyati3, @SatisFiyati4, @SatisFiyati5,
        //@SatisFiyati6, @SatisFiyati7, @SatisFiyati8, @SatisFiyati9, @SatisFiyati10,
        //@StokAdedi, @StokGuncellemeTarihi, @StokKodu, @TahminiTeslimSuresi,
        //@TahminiTeslimSuresiAyniGun, @TahminiTeslimSuresiGoster, @TahminiTeslimSuresiTarih,
        //@TedarikciKodu, @TedarikciKodu2, @TedarikciKomisyonOrani, @UpdateKey, @UrunAgirligi,
        //@UrunDerinlik, @UrunGenislik, @UrunKartiAktif, @UrunKartiID, @UrunYukseklik,
        //@UyeAlimMax, @UyeAlimMin, @UyeTipiFiyat1, @UyeTipiFiyat2, @UyeTipiFiyat3,
        //@UyeTipiFiyat4, @UyeTipiFiyat5, @UyeTipiFiyat6, @UyeTipiFiyat7, @UyeTipiFiyat8,
        //@UyeTipiFiyat9, @UyeTipiFiyat10 WHERE NOT EXISTS (SELECT 1 FROM ZtTicimaxVaryasyonList WHERE ID = @ID);
        //END;";

        //                    using (SqlCommand command = new SqlCommand(query, connection))
        //                    {
        //                        // Parametrelerinizi ekleyin
        //                        command.Parameters.AddWithValue("@ID", urunKarti.ID);
        //                        command.Parameters.AddWithValue("@Aktif", urunKarti.Aktif);
        //                        command.Parameters.AddWithValue("@AlisFiyati", urunKarti.AlisFiyati);
        //                        command.Parameters.AddWithValue("@Barkod", urunKarti.Barkod ?? (object)DBNull.Value);
        //                        command.Parameters.AddWithValue("@Desi", urunKarti.Desi);
        //                        command.Parameters.AddWithValue("@Desi2", urunKarti.Desi2);
        //                        command.Parameters.AddWithValue("@DuzenleyenKullanici", urunKarti.DuzenleyenKullanici);
        //                        command.Parameters.AddWithValue("@EkleyenKullanici", urunKarti.EkleyenKullanici);
        //                        command.Parameters.AddWithValue("@EksiStokAdedi", urunKarti.EksiStokAdedi);
        //                        command.Parameters.AddWithValue("@GtipKodu", urunKarti.GtipKodu ?? (object)DBNull.Value);
        //                        command.Parameters.AddWithValue("@IndirimliFiyati", urunKarti.IndirimliFiyati);
        //                        command.Parameters.AddWithValue("@IndirimliFiyati1", urunKarti.IndirimliFiyati1);
        //                        command.Parameters.AddWithValue("@IndirimliFiyati2", urunKarti.IndirimliFiyati2);
        //                        command.Parameters.AddWithValue("@IndirimliFiyati3", urunKarti.IndirimliFiyati3);
        //                        command.Parameters.AddWithValue("@IndirimliFiyati4", urunKarti.IndirimliFiyati4);
        //                        command.Parameters.AddWithValue("@IndirimliFiyati5", urunKarti.IndirimliFiyati5);
        //                        command.Parameters.AddWithValue("@IndirimliFiyati6", urunKarti.IndirimliFiyati6);
        //                        command.Parameters.AddWithValue("@IndirimliFiyati7", urunKarti.IndirimliFiyati7);
        //                        command.Parameters.AddWithValue("@IndirimliFiyati8", urunKarti.IndirimliFiyati8);
        //                        command.Parameters.AddWithValue("@IndirimliFiyati9", urunKarti.IndirimliFiyati9);
        //                        command.Parameters.AddWithValue("@IndirimliFiyati10", urunKarti.IndirimliFiyati10);
        //                        // Yer alan diğer indirimli fiyatlar için de benzer şekilde parametre eklemeleri
        //                        command.Parameters.AddWithValue("@IscilikAgirlik", urunKarti.IscilikAgirlik);
        //                        command.Parameters.AddWithValue("@IscilikParaBirimi", urunKarti.IscilikParaBirimi ?? (object)DBNull.Value);
        //                        command.Parameters.AddWithValue("@IscilikParaBirimiId", urunKarti.IscilikParaBirimiId);
        //                        command.Parameters.AddWithValue("@IscilikParaBirimiKodu", urunKarti.IscilikParaBirimiKodu ?? (object)DBNull.Value);
        //                        command.Parameters.AddWithValue("@KargoUcreti", urunKarti.KargoUcreti);
        //                        // Varyasyonun kategorileri, JSON formatında saklanabilir veya farklı bir yöntemle yönetilebilir, örneğin ayrı bir tabloda ilişkilendirilebilir.
        //                        command.Parameters.AddWithValue("@KdvDahil", urunKarti.KdvDahil);
        //                        command.Parameters.AddWithValue("@KdvDahil1", urunKarti.KdvDahil1);
        //                        command.Parameters.AddWithValue("@KdvDahil2", urunKarti.KdvDahil2);
        //                        command.Parameters.AddWithValue("@KdvDahil3", urunKarti.KdvDahil3);
        //                        command.Parameters.AddWithValue("@KdvDahil4", urunKarti.KdvDahil4);
        //                        command.Parameters.AddWithValue("@KdvDahil5", urunKarti.KdvDahil5);
        //                        command.Parameters.AddWithValue("@KdvDahil6", urunKarti.KdvDahil6);
        //                        command.Parameters.AddWithValue("@KdvDahil7", urunKarti.KdvDahil7);
        //                        command.Parameters.AddWithValue("@KdvDahil8", urunKarti.KdvDahil8);
        //                        command.Parameters.AddWithValue("@KdvDahil9", urunKarti.KdvOrani9);
        //                        command.Parameters.AddWithValue("@KdvDahil10", urunKarti.KdvOrani10);
        //                        command.Parameters.AddWithValue("@KdvOrani", urunKarti.KdvOrani);
        //                        command.Parameters.AddWithValue("@KdvOrani1", urunKarti.KdvOrani1);
        //                        command.Parameters.AddWithValue("@KdvOrani2", urunKarti.KdvOrani2);
        //                        command.Parameters.AddWithValue("@KdvOrani3", urunKarti.KdvOrani3);
        //                        command.Parameters.AddWithValue("@KdvOrani4", urunKarti.KdvOrani4);
        //                        command.Parameters.AddWithValue("@KdvOrani5", urunKarti.KdvOrani5);
        //                        command.Parameters.AddWithValue("@KdvOrani6", urunKarti.KdvOrani6);
        //                        command.Parameters.AddWithValue("@KdvOrani7", urunKarti.KdvOrani7);
        //                        command.Parameters.AddWithValue("@KdvOrani8", urunKarti.KdvOrani8);
        //                        command.Parameters.AddWithValue("@KdvOrani9", urunKarti.KdvOrani9);
        //                        command.Parameters.AddWithValue("@KdvOrani10", urunKarti.KdvOrani10);
        //                        command.Parameters.AddWithValue("@KonsinyeStokAdedi", urunKarti.KonsinyeStokAdedi);
        //                        command.Parameters.AddWithValue("@MarkaID", urunKarti.MarkaID);
        //                        command.Parameters.AddWithValue("@MarketPlaceAktif", urunKarti.MarketPlaceAktif);
        //                        command.Parameters.AddWithValue("@MarketPlaceAktif2", urunKarti.MarketPlaceAktif2);
        //                        command.Parameters.AddWithValue("@MarketPlaceAktif3", urunKarti.MarketPlaceAktif3);
        //                        command.Parameters.AddWithValue("@MarketPlaceAktif4", urunKarti.MarketPlaceAktif4);
        //                        command.Parameters.AddWithValue("@MarketPlaceAktif5", urunKarti.MarketPlaceAktif5);
        //                        command.Parameters.AddWithValue("@ParaBirimi", urunKarti.ParaBirimi ?? (object)DBNull.Value);
        //                        command.Parameters.AddWithValue("@ParaBirimiID", urunKarti.ParaBirimiID);
        //                        command.Parameters.AddWithValue("@ParaBirimiKodu", urunKarti.ParaBirimiKodu ?? (object)DBNull.Value);
        //                        command.Parameters.AddWithValue("@PiyasaFiyati", urunKarti.PiyasaFiyati);
        //                        command.Parameters.AddWithValue("@SatisFiyati", urunKarti.SatisFiyati);
        //                        command.Parameters.AddWithValue("@SatisFiyati1", urunKarti.SatisFiyati1);
        //                        command.Parameters.AddWithValue("@SatisFiyati2", urunKarti.SatisFiyati2);
        //                        command.Parameters.AddWithValue("@SatisFiyati3", urunKarti.SatisFiyati3);
        //                        command.Parameters.AddWithValue("@SatisFiyati4", urunKarti.SatisFiyati4);
        //                        command.Parameters.AddWithValue("@SatisFiyati5", urunKarti.SatisFiyati5);
        //                        command.Parameters.AddWithValue("@SatisFiyati6", urunKarti.SatisFiyati6);
        //                        command.Parameters.AddWithValue("@SatisFiyati7", urunKarti.SatisFiyati7);
        //                        command.Parameters.AddWithValue("@SatisFiyati8", urunKarti.SatisFiyati8);
        //                        command.Parameters.AddWithValue("@SatisFiyati9", urunKarti.SatisFiyati9);
        //                        command.Parameters.AddWithValue("@SatisFiyati10", urunKarti.SatisFiyati10);
        //                        command.Parameters.AddWithValue("@StokAdedi", urunKarti.StokAdedi);
        //                        command.Parameters.AddWithValue("@StokGuncellemeTarihi", urunKarti.StokGuncellemeTarihi.Equals(default(DateTime)) ? (object)DBNull.Value : urunKarti.StokGuncellemeTarihi);
        //                        command.Parameters.AddWithValue("@StokKodu", urunKarti.StokKodu ?? (object)DBNull.Value);
        //                        command.Parameters.AddWithValue("@TahminiTeslimSuresi", urunKarti.TahminiTeslimSuresi);
        //                        command.Parameters.AddWithValue("@TahminiTeslimSuresiAyniGun", urunKarti.TahminiTeslimSuresiAyniGun);
        //                        command.Parameters.AddWithValue("@TahminiTeslimSuresiGoster", urunKarti.TahminiTeslimSuresiGoster);
        //                        command.Parameters.AddWithValue("@TahminiTeslimSuresiTarih", urunKarti.TahminiTeslimSuresiTarih.Equals(default(DateTime)) ? (object)DBNull.Value : urunKarti.TahminiTeslimSuresiTarih);
        //                        command.Parameters.AddWithValue("@TedarikciKodu", urunKarti.TedarikciKodu ?? (object)DBNull.Value);
        //                        command.Parameters.AddWithValue("@TedarikciKodu2", urunKarti.TedarikciKodu2 ?? (object)DBNull.Value);
        //                        command.Parameters.AddWithValue("@TedarikciKomisyonOrani", urunKarti.TedarikciKomisyonOrani);
        //                        command.Parameters.AddWithValue("@UpdateKey", urunKarti.UpdateKey ?? (object)DBNull.Value);
        //                        command.Parameters.AddWithValue("@UrunAgirligi", urunKarti.UrunAgirligi);
        //                        command.Parameters.AddWithValue("@UrunDerinlik", urunKarti.UrunDerinlik);
        //                        command.Parameters.AddWithValue("@UrunGenislik", urunKarti.UrunGenislik);
        //                        command.Parameters.AddWithValue("@UrunKartiAktif", urunKarti.UrunKartiAktif);
        //                        command.Parameters.AddWithValue("@UrunKartiID", urunKarti.UrunKartiID);
        //                        command.Parameters.AddWithValue("@UrunYukseklik", urunKarti.UrunYukseklik);
        //                        command.Parameters.AddWithValue("@UyeAlimMax", urunKarti.UyeAlimMax);
        //                        command.Parameters.AddWithValue("@UyeAlimMin", urunKarti.UyeAlimMin);
        //                        command.Parameters.AddWithValue("@UyeTipiFiyat1", urunKarti.UyeTipiFiyat1);
        //                        command.Parameters.AddWithValue("@UyeTipiFiyat2", urunKarti.UyeTipiFiyat2);
        //                        command.Parameters.AddWithValue("@UyeTipiFiyat3", urunKarti.UyeTipiFiyat3);
        //                        command.Parameters.AddWithValue("@UyeTipiFiyat4", urunKarti.UyeTipiFiyat4);
        //                        command.Parameters.AddWithValue("@UyeTipiFiyat5", urunKarti.UyeTipiFiyat5);
        //                        command.Parameters.AddWithValue("@UyeTipiFiyat6", urunKarti.UyeTipiFiyat6);
        //                        command.Parameters.AddWithValue("@UyeTipiFiyat7", urunKarti.UyeTipiFiyat7);
        //                        command.Parameters.AddWithValue("@UyeTipiFiyat8", urunKarti.UyeTipiFiyat8);
        //                        command.Parameters.AddWithValue("@UyeTipiFiyat9", urunKarti.UyeTipiFiyat9);
        //                        command.Parameters.AddWithValue("@UyeTipiFiyat10", urunKarti.UyeTipiFiyat10);
        //                        // Her bir UrunKarti nesnesi için kaydetme işlemini gerçekleştirin
        //                        command.ExecuteNonQuery();
        //                    }
        //                }
        //                // Geçici tablo ve ZTMSGTicimaxUrunKarti arasında kontrol yap ve yoksa ekle


        //                // SqlCommand nesnesini oluştur

        //                // SqlCommand'a parametre olarak DataTable'ı ekle


        //                // Geçici tabloyu kaldır
        //                SqlCommand dropTempTableCmd = new SqlCommand("delete ztTemps", connection);
        //                dropTempTableCmd.ExecuteNonQuery();
        //            }
        //        }

        public static void UrunVariantlariKaydet(List<Varyasyon> urunVaryasyonListesi)
        {
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // ID'leri tek bir string'e dönüştür
                List<int> varOlanIdler = new List<int>();
                string idListesi = string.Join(",", urunVaryasyonListesi.Select(u => u.ID.ToString()));

                // Geçici tabloyu oluştur

                // ID'leri geçici tabloya doldur
                SqlCommand insertTempTableCmd = new SqlCommand(
                    "INSERT INTO ztTemps (ID) SELECT ID FROM fnSplitter(@idListesi)", connection);
                insertTempTableCmd.Parameters.AddWithValue("@idListesi", idListesi);
                insertTempTableCmd.ExecuteNonQuery();

                using (SqlCommand cmd = new SqlCommand("SELECT ztTemps.ID FROM ztTemps  Left Outer Join ZtTicimaxVaryasyonList on ZtTicimaxVaryasyonList.ID =ztTemps.ID    WHERE ZtTicimaxVaryasyonList.ID is not null", connection))
                {
                    cmd.Parameters.AddWithValue("@idListesi", idListesi);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            varOlanIdler.Add(reader.GetInt32(0));
                        }
                    }
                }
                urunVaryasyonListesi = urunVaryasyonListesi.Where(u => !varOlanIdler.Contains(u.ID)).ToList();
                foreach (Varyasyon urunKarti in urunVaryasyonListesi)
                {
                    // İhtiyacınıza göre alanları ekleyin veya çıkarın
                    string query = @" 
 IF NOT EXISTS (SELECT 1 FROM ZtTicimaxVaryasyonList WHERE ID = @ID)
BEGIN
    INSERT INTO ZtTicimaxVaryasyonList (
      ID, Aktif, AlisFiyati, Barkod, IndirimliFiyati, KdvDahil, KdvOrani, SatisFiyati,
StokAdedi, StokKodu,
TedarikciKodu, UrunKartiID, UyeTipiFiyat1
    ) 
      SELECT 
        @ID, @Aktif, @AlisFiyati, @Barkod, @IndirimliFiyati, @KdvDahil, @KdvOrani, @SatisFiyati,
@StokAdedi, @StokKodu,
@TedarikciKodu, @UrunKartiID, @UyeTipiFiyat1 WHERE NOT EXISTS (SELECT 1 FROM ZtTicimaxVaryasyonList WHERE ID = @ID);
END;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parametrelerinizi ekleyin
                        command.Parameters.AddWithValue("@ID", urunKarti.ID);
                        command.Parameters.AddWithValue("@Aktif", urunKarti.Aktif);
                        command.Parameters.AddWithValue("@AlisFiyati", urunKarti.AlisFiyati);
                        command.Parameters.AddWithValue("@Barkod", urunKarti.Barkod ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@IndirimliFiyati", urunKarti.IndirimliFiyati);
                        // Varyasyonun kategorileri, JSON formatında saklanabilir veya farklı bir yöntemle yönetilebilir, örneğin ayrı bir tabloda ilişkilendirilebilir.
                        command.Parameters.AddWithValue("@KdvDahil", urunKarti.KdvDahil);
                        command.Parameters.AddWithValue("@KdvOrani", urunKarti.KdvOrani);
                        command.Parameters.AddWithValue("@SatisFiyati", urunKarti.SatisFiyati);
                        command.Parameters.AddWithValue("@StokAdedi", urunKarti.StokAdedi);
                        command.Parameters.AddWithValue("@StokKodu", urunKarti.StokKodu ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@TedarikciKodu", urunKarti.TedarikciKodu ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@UrunKartiID", urunKarti.UrunKartiID);
                        command.Parameters.AddWithValue("@UyeTipiFiyat1", urunKarti.UyeTipiFiyat1);

                        // Her bir UrunKarti nesnesi için kaydetme işlemini gerçekleştirin
                        command.ExecuteNonQuery();
                    }
                }
                // Geçici tablo ve ZTMSGTicimaxUrunKarti arasında kontrol yap ve yoksa ekle


                // SqlCommand nesnesini oluştur

                // SqlCommand'a parametre olarak DataTable'ı ekle


                // Geçici tabloyu kaldır
                SqlCommand dropTempTableCmd = new SqlCommand("delete ztTemps", connection);
                dropTempTableCmd.ExecuteNonQuery();
            }
        }

        public static void UrunKartlariniKaydet3(List<UrunKarti> urunKartiListesi)
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

                    foreach (UrunKarti urunKarti in urunKartiListesi)
                    {
                        // İhtiyacınıza göre alanları ekleyin veya çıkarın
                        string query = @" 
 IF NOT EXISTS (SELECT 1 FROM ZTMSGTicimaxUrunKarti WHERE ID = @ID)
                BEGIN
        INSERT INTO ZTMSGTicimaxUrunKarti (
            ID, Aktif, AnaKategoriID, AramaAnahtarKelime, Marka, SeoAnahtarKelime, 
            SeoSayfaAciklama, SeoSayfaBaslik, UrunAdi, EklemeTarihi, YeniUrun, Sira, 
            ListedeGoster, EntegrasyonID, UrunKapidaOdemeYasakli, UcretsizKargo, 
            Vitrin, FBStoreGoster, FirsatUrunu, MaksTaksitSayisi, UrunAdediKademeDeger, 
            UrunAdediMinimumDeger, UrunAdediVarsayilanDeger, UrunAdediOndalikliSayiGirilebilir, 
            UyeAlimMin, UyeAlimMax, MarkaID, TedarikciID, TedarikciKodu, 
            TedarikciKodu2, YayinTarihi, OnYazi, Aciklama, DuzenleyenKullanici, EkleyenKullanici, KargoTipi, TahminiTeslimSuresi, 
            TahminiTeslimSuresiAyniGun, TahminiTeslimSuresiGoster, TakimKampanyaId, 
            TakimUrun, TeknikDetayGrupID, ToplamStokAdedi, UrunSayfaAdresi, 
            YonlendirmeAdresi, SeoNoFollow, SeoNoIndex, PuanDeger, OzelAlan1, OzelAlan2, 
            OzelAlan3, OzelAlan4, OzelAlan5, AdwordsAciklama, AdwordsKategori, 
            AdwordsTip, AnaKategori, AsortiGrupID, MarketPlaceAktif, 
            MarketPlaceAktif2, MarketPlaceAktif3, SatisBirimi
        ) 
        SELECT 
            @ID, @Aktif, @AnaKategoriID, @AramaAnahtarKelime, @Marka, @SeoAnahtarKelime, 
            @SeoSayfaAciklama, @SeoSayfaBaslik, @UrunAdi, @EklemeTarihi, @YeniUrun, @Sira, 
            @ListedeGoster, @EntegrasyonID, @UrunKapidaOdemeYasakli, @UcretsizKargo, 
            @Vitrin, @FBStoreGoster, @FirsatUrunu, @MaksTaksitSayisi, @UrunAdediKademeDeger, 
            @UrunAdediMinimumDeger, @UrunAdediVarsayilanDeger, @UrunAdediOndalikliSayiGirilebilir, 
            @UyeAlimMin, @UyeAlimMax, @MarkaID, @TedarikciID, @TedarikciKodu, 
            @TedarikciKodu2, @YayinTarihi, @OnYazi, @Aciklama, @DuzenleyenKullanici, @EkleyenKullanici, @KargoTipi, @TahminiTeslimSuresi, 
            @TahminiTeslimSuresiAyniGun, @TahminiTeslimSuresiGoster, @TakimKampanyaId, 
            @TakimUrun, @TeknikDetayGrupID, @ToplamStokAdedi, @UrunSayfaAdresi, 
            @YonlendirmeAdresi, @SeoNoFollow, @SeoNoIndex, @PuanDeger, @OzelAlan1, @OzelAlan2, 
            @OzelAlan3, @OzelAlan4, @OzelAlan5, @AdwordsAciklama, @AdwordsKategori, 
            @AdwordsTip, @AnaKategori, @AsortiGrupID, @MarketPlaceAktif, 
            @MarketPlaceAktif2, @MarketPlaceAktif3, @SatisBirimi
        WHERE NOT EXISTS (SELECT 1 FROM ZTMSGTicimaxUrunKarti WHERE ID = @ID) END";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Parametrelerinizi ekleyin
                            command.Parameters.AddWithValue("@ID", urunKarti.ID);
                            command.Parameters.AddWithValue("@Aktif", urunKarti.Aktif);
                            command.Parameters.AddWithValue("@AnaKategoriID", urunKarti.AnaKategoriID);
                            command.Parameters.AddWithValue("@AramaAnahtarKelime", (urunKarti.AramaAnahtarKelime ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@Marka", (urunKarti.Marka ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@SeoAnahtarKelime", (urunKarti.SeoAnahtarKelime ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@SeoSayfaAciklama", (urunKarti.SeoSayfaAciklama ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@SeoSayfaBaslik", (urunKarti.SeoSayfaBaslik ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@UrunAdi", (urunKarti.UrunAdi ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@EklemeTarihi", (urunKarti.EklemeTarihi.Equals(default(DateTime)) ? (object)DBNull.Value : urunKarti.EklemeTarihi));
                            command.Parameters.AddWithValue("@YeniUrun", urunKarti.YeniUrun);
                            command.Parameters.AddWithValue("@Sira", urunKarti.Sira);
                            command.Parameters.AddWithValue("@ListedeGoster", urunKarti.ListedeGoster);
                            command.Parameters.AddWithValue("@EntegrasyonID", (urunKarti.EntegrasyonID ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@UrunKapidaOdemeYasakli", urunKarti.UrunKapidaOdemeYasakli);
                            command.Parameters.AddWithValue("@UcretsizKargo", urunKarti.UcretsizKargo);
                            command.Parameters.AddWithValue("@Vitrin", urunKarti.Vitrin);
                            command.Parameters.AddWithValue("@FBStoreGoster", urunKarti.FBStoreGoster);
                            command.Parameters.AddWithValue("@FirsatUrunu", urunKarti.FirsatUrunu);
                            command.Parameters.AddWithValue("@MaksTaksitSayisi", urunKarti.MaksTaksitSayisi);
                            command.Parameters.AddWithValue("@UrunAdediKademeDeger", urunKarti.UrunAdediKademeDeger);
                            command.Parameters.AddWithValue("@UrunAdediMinimumDeger", urunKarti.UrunAdediMinimumDeger);
                            command.Parameters.AddWithValue("@UrunAdediVarsayilanDeger", urunKarti.UrunAdediVarsayilanDeger);
                            command.Parameters.AddWithValue("@UrunAdediOndalikliSayiGirilebilir", urunKarti.UrunAdediOndalikliSayiGirilebilir);
                            command.Parameters.AddWithValue("@UyeAlimMin", urunKarti.UyeAlimMin);
                            command.Parameters.AddWithValue("@UyeAlimMax", urunKarti.UyeAlimMax);
                            command.Parameters.AddWithValue("@MarkaID", urunKarti.MarkaID);
                            command.Parameters.AddWithValue("@TedarikciID", urunKarti.TedarikciID);
                            command.Parameters.AddWithValue("@TedarikciKodu", (urunKarti.TedarikciKodu ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@TedarikciKodu2", (urunKarti.TedarikciKodu2 ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@YayinTarihi", (urunKarti.YayinTarihi.Equals(default(DateTime)) ? (object)DBNull.Value : urunKarti.YayinTarihi));
                            command.Parameters.AddWithValue("@OnYazi", (urunKarti.OnYazi ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@Aciklama", (urunKarti.Aciklama ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@DuzenleyenKullanici", urunKarti.DuzenleyenKullanici);
                            command.Parameters.AddWithValue("@EkleyenKullanici", urunKarti.EkleyenKullanici);
                            // ... Diğer alanlarınız için de benzer şekilde parametreler ekleyin ...

                            command.Parameters.AddWithValue("@KargoTipi", urunKarti.KargoTipi);
                            command.Parameters.AddWithValue("@TahminiTeslimSuresi", urunKarti.TahminiTeslimSuresi);
                            command.Parameters.AddWithValue("@TahminiTeslimSuresiAyniGun", urunKarti.TahminiTeslimSuresiAyniGun);
                            command.Parameters.AddWithValue("@TahminiTeslimSuresiGoster", urunKarti.TahminiTeslimSuresiGoster);
                            command.Parameters.AddWithValue("@TakimKampanyaId", urunKarti.TakimKampanyaId);
                            command.Parameters.AddWithValue("@TakimUrun", urunKarti.TakimUrun);
                            command.Parameters.AddWithValue("@TeknikDetayGrupID", urunKarti.TeknikDetayGrupID);
                            command.Parameters.AddWithValue("@ToplamStokAdedi", urunKarti.ToplamStokAdedi);
                            command.Parameters.AddWithValue("@UrunSayfaAdresi", (urunKarti.UrunSayfaAdresi ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@YonlendirmeAdresi", (urunKarti.YonlendirmeAdresi ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@SeoNoFollow", urunKarti.SeoNoFollow);
                            command.Parameters.AddWithValue("@SeoNoIndex", urunKarti.SeoNoIndex);
                            command.Parameters.AddWithValue("@PuanDeger", urunKarti.PuanDeger);
                            command.Parameters.AddWithValue("@OzelAlan1", (urunKarti.OzelAlan1 ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@OzelAlan2", (urunKarti.OzelAlan2 ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@OzelAlan3", (urunKarti.OzelAlan3 ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@OzelAlan4", (urunKarti.OzelAlan4 ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@OzelAlan5", (urunKarti.OzelAlan5 ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@AdwordsAciklama", (urunKarti.AdwordsAciklama ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@AdwordsKategori", (urunKarti.AdwordsKategori ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@AdwordsTip", (urunKarti.AdwordsTip ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@AnaKategori", (urunKarti.AnaKategori ?? (object)DBNull.Value));
                            command.Parameters.AddWithValue("@AsortiGrupID", urunKarti.AsortiGrupID);
                            command.Parameters.AddWithValue("@MarketPlaceAktif", urunKarti.MarketPlaceAktif);
                            command.Parameters.AddWithValue("@MarketPlaceAktif2", urunKarti.MarketPlaceAktif2);
                            command.Parameters.AddWithValue("@MarketPlaceAktif3", urunKarti.MarketPlaceAktif3);
                            command.Parameters.AddWithValue("@SatisBirimi", (urunKarti.SatisBirimi ?? (object)DBNull.Value));

                            // Her bir UrunKarti nesnesi için kaydetme işlemini gerçekleştirin
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Hata yönetimi
                    MessageBox.Show("Veritabanına kayıt sırasında bir hata oluştu: " + ex.Message);
                }
            }
        }
        //        public static void UrunKartlariniKaydet(List<UrunKarti> urunKartiListesi)
        //        {
        //            string serverName = Properties.Settings.Default.SunucuAdi;
        //            string userName = Properties.Settings.Default.KullaniciAdi;
        //            string password = Properties.Settings.Default.Sifre;
        //            string database = Properties.Settings.Default.database;
        //            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

        //            using (SqlConnection connection = new SqlConnection(connectionString))
        //            {
        //                try
        //                {
        //                    connection.Open();

        //                    foreach (UrunKarti urunKarti in urunKartiListesi)
        //                    {
        //                        // İhtiyacınıza göre alanları ekleyin veya çıkarın
        //                        string query = @"
        //INSERT INTO ZTMSGTicimaxUrunKarti (
        //    ID, Aktif, AnaKategoriID, UrunAdi, TedarikciID, TedarikciKodu, 
        //    TedarikciKodu2, ToplamStokAdedi, AnaKategori
        //) 
        //SELECT 
        //    @ID, @Aktif, @AnaKategoriID, @UrunAdi, @TedarikciID, @TedarikciKodu, 
        //    @TedarikciKodu2, @ToplamStokAdedi, @AnaKategori
        //WHERE NOT EXISTS (SELECT 1 FROM ZTMSGTicimaxUrunKarti WHERE ID = @ID)";

        //                        using (SqlCommand command = new SqlCommand(query, connection))
        //                        {
        //                            // Parametrelerinizi ekleyin
        //                            command.Parameters.AddWithValue("@ID", urunKarti.ID);
        //                            command.Parameters.AddWithValue("@Aktif", urunKarti.Aktif);
        //                            command.Parameters.AddWithValue("@AnaKategoriID", urunKarti.AnaKategoriID);

        //                            command.Parameters.AddWithValue("@UrunAdi", (urunKarti.UrunAdi ?? (object)DBNull.Value));

        //                            command.Parameters.AddWithValue("@TedarikciID", urunKarti.TedarikciID);
        //                            command.Parameters.AddWithValue("@TedarikciKodu", (urunKarti.TedarikciKodu ?? (object)DBNull.Value));
        //                            command.Parameters.AddWithValue("@TedarikciKodu2", (urunKarti.TedarikciKodu2 ?? (object)DBNull.Value));

        //                            command.Parameters.AddWithValue("@ToplamStokAdedi", urunKarti.ToplamStokAdedi);

        //                            command.Parameters.AddWithValue("@AnaKategori", (urunKarti.AnaKategori ?? (object)DBNull.Value));


        //                            // Her bir UrunKarti nesnesi için kaydetme işlemini gerçekleştirin
        //                            command.ExecuteNonQuery();
        //                        }
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    // Hata yönetimi
        //                    MessageBox.Show("Veritabanına kayıt sırasında bir hata oluştu: " + ex.Message);
        //                }
        //            }
        //        }



        public static List<Tedarikci> SelectTedarikci()
        {
            try
            {
                //List<Tedarikci> tedarikciListe = new List<Tedarikci>();

                // TedarikciID değeri 0 gönderilirse tüm tedarikçilerin listesi gelir.
                //tedarikciListe = StaticVariables.urunServisClient.SelectTedarikci(StaticVariables.uyeKodu, 0);

                //// TedarikciID değeri 0 da büyük gönderilirse id si verilen tedarikçi gelir.
                //tedarikciListe = StaticVariables.urunServisClient.SelectTedarikci(StaticVariables.uyeKodu, 5);

                //MessageBox.Show("Tedarikçiler listelendi. " + tedarikciListe.Count + " adet kayıtlı tedarikçiniz bulunmaktadır.");
                MessageBox.Show("Tedarikçiler listelendi. " + StaticVariables.tedarikciList.Count + " adet kayıtlı tedarikçiniz bulunmaktadır.");

                //  StaticFunctions.CevapListele(StaticVariables.tedarikciList.Cast<object>().ToList(), "Tedarikçiler");

                return StaticVariables.tedarikciList;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static int SaveTedarikci()
        {
            try
            {
                Tedarikci tedarikci = new Tedarikci
                {
                    Aktif = true,
                    ID = 0,//id 0 gönderilir ise yeni tedarikçi ekler 0 dan büyük gönderilirse gönderilen id li tedarikçi güncellenir.
                    Mail = "Tedarikçi Mail",
                    Not = "",
                    Tanim = "Tedarikçi adi"
                };
                int eklenenTedarikciId = StaticVariables.urunServisClient.SaveTedarikci(StaticVariables.uyeKodu, tedarikci);

                if (eklenenTedarikciId > 0)
                    MessageBox.Show("Tedarikçi eklendi id: " + eklenenTedarikciId);
                else
                    MessageBox.Show("Tedarikçi eklenemedi.");

                return eklenenTedarikciId;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return 0;
            }
        }
        public static List<Marka> SelectMarka()
        {
            try
            {
                //List<Marka> markaListe = new List<Marka>();

                // eğer markaID değeri 0 gönderilir ise cevap olarak tüm markaların listesi gelir.
                //markaListe = StaticVariables.urunServisClient.SelectMarka(StaticVariables.uyeKodu, 0);

                //// eğer markaID değeri 0 dan büyük gönderilir ise id si girilen marka gelir. 
                //markaListe = StaticVariables.urunServisClient.SelectMarka(StaticVariables.uyeKodu, 3);

                //MessageBox.Show("Markalar listelendi. " + markaListe.Count + " adet kayıtlı markanız bulunmaktadır.");
                MessageBox.Show("Markalar listelendi. " + StaticVariables.markaList.Count + " adet kayıtlı markanız bulunmaktadır.");

                //    StaticFunctions.CevapListele(StaticVariables.markaList.Cast<object>().ToList(), "Markalar");

                return StaticVariables.markaList;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static int SaveMarka()
        {
            try
            {
                Marka marka = new Marka
                {
                    Aktif = true,
                    ID = 0, //id 0 gönderilir ise yeni marka ekler 0 dan büyük gönderilirse gönderilen id li marka güncellenir.
                    SeoAnahtarKelime = "Anahtar kelime",
                    SeoSayfaAciklama = "Sayfa Aciklama ",
                    SeoSayfaBaslik = "Sayfa baslik",
                    Tanim = "Marka Adi"
                };
                int eklenenMarkaId = StaticVariables.urunServisClient.SaveMarka(StaticVariables.uyeKodu, marka);

                if (eklenenMarkaId > 0)
                    MessageBox.Show("Marka eklendi id: " + eklenenMarkaId);

                return eklenenMarkaId;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return 0;
            }
        }
        public static UpdateUrlResponse UpdateUrl()
        {
            try
            {
                UpdateUrlRequest updateUrlRequest = new UpdateUrlRequest()
                {
                    Tip = UrlType.Kategori, // hangi tipte url i güncellenecekse onu giriyoruz.
                    ID = 1,
                    Dil = "en", // dil değeri boş gönderilir ise türkçe olarak kaydolur.
                    Url = "/Giyim" //  url değeri
                };

                UpdateUrlResponse updateUrlResponse = StaticVariables.urunServisClient.UpdateUrl(StaticVariables.uyeKodu, updateUrlRequest);

                if (updateUrlResponse.IsError)
                    MessageBox.Show(updateUrlResponse.ErrorMessage);
                else
                    MessageBox.Show("Url güncellendi");

                return updateUrlResponse;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static void SaveResim()
        {
            try
            {
                UrunKarti urunKarti = new UrunKarti()
                {
                    TedarikciKodu = "tedarikçi kodu", // resim eklenecek ürünün tedarikçi kodu 
                    ID = 1, // resim eklenecek ürün kartının id değeri
                    TedarikciID = 1 // veritabanında kayıtlı tedarikçi id değeri. 
                };

                List<string> resimler = new List<string>(); // eklenecek olan resimlerin listesi 
                resimler.Add("resim1 url");
                resimler.Add("resim2 url");

                urunKarti.Resimler = resimler;
                List<UrunKarti> urunKartiListesi = new List<UrunKarti>();
                urunKartiListesi.Add(urunKarti);

                StaticVariables.urunServisClient.SaveResim(StaticVariables.uyeKodu, urunKartiListesi, StaticVariables.alanAdi, "");

                MessageBox.Show("Resim eklendi");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        public static WebServisResponse DeleteTedarikci()
        {
            try
            {
                UrunServis.WebServisResponse webServisResponse = StaticVariables.urunServisClient.DeleteTedarikci(StaticVariables.uyeKodu, 1);
                // webServisResponse da işlemin ne şekilde sonuçlandığına dair bilgi döndürülüyor.

                if (webServisResponse.IsError)
                    MessageBox.Show(webServisResponse.ErrorMessage);
                else
                    MessageBox.Show("Tedarikçi silindi");

                return webServisResponse;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static WebServisResponse DeleteMarka()
        {
            try
            {
                UrunServis.WebServisResponse webServisResponse = StaticVariables.urunServisClient.DeleteMarka(StaticVariables.uyeKodu, 1);
                // Serviscevap ta işlemin ne şekilde sonuçlandığına dair bilgi döndürülüyor.

                if (webServisResponse.IsError)
                    MessageBox.Show(webServisResponse.ErrorMessage);
                else
                    MessageBox.Show("Kategori silindi");

                return webServisResponse;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static WebServisResponse DeleteKategori()
        {
            try
            {
                UrunServis.WebServisResponse webServisResponse = StaticVariables.urunServisClient.DeleteKategori(StaticVariables.uyeKodu, 1);

                if (webServisResponse.IsError)
                    MessageBox.Show(webServisResponse.ErrorMessage);
                else
                    MessageBox.Show("kategori silindi");

                return webServisResponse;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static SaveMagazaStokResponse SaveMagazaStok()
        {
            try
            {
                List<WebMagazaStok> webMagazaStokList = new List<WebMagazaStok>();
                WebMagazaStok webMagazaStok = new WebMagazaStok
                {
                    EksiStokAdedi = 5, // mağazanın ayırmak istediği stok adedi 
                    MagazaKodu = "tici",
                    StokAdedi = 10, // mağazaya eklenecek stok adedi 
                    TedarikciKodu = "EXCEL|1", // ürüne ait tedarik
                    UrunID = 1, // kayıtlı ürün id değeri 
                    UrunKartiID = 1  // kayıtlı ürünün ürün  kartı id değeri 
                };
                webMagazaStokList.Add(webMagazaStok);
                SaveMagazaStokRequest saveMagazaStokRequest = new SaveMagazaStokRequest();
                saveMagazaStokRequest.MagazaStokList = webMagazaStokList;



                SaveMagazaStokResponse saveMagazaStokResponse = StaticVariables.urunServisClient.SaveMagazaStok(StaticVariables.uyeKodu, saveMagazaStokRequest);

                if (saveMagazaStokResponse.IsError)
                    MessageBox.Show(saveMagazaStokResponse.ErrorMessage);
                else
                    MessageBox.Show("Mağaza stok eklendi.");

                return saveMagazaStokResponse;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static List<SiparisUrunDurumlari> GetProductStatus()
        {
            try
            {
                // Sipariş durumları listesini getirir. Parametre göndermeye gerek yoktur. 
                List<UrunServis.SiparisUrunDurumlari> siparisUrunDurumlariListe = StaticVariables.urunServisClient.GetProductStatus(StaticVariables.uyeKodu);

                MessageBox.Show("Sipariş ürün durumları listelendi. " + siparisUrunDurumlariListe.Count + "adet sipariş ürün durumunuz bulunmaktadır.");

                //StaticFunctions.CevapListele(siparisUrunDurumlariListe.Cast<object>().ToList(), "Sipariş Ürün Durumları");

                return siparisUrunDurumlariListe;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }



        public static List<Kategori> GetUrunWithRetry(string WSYetki, int sayi, string dil, int maxAttempts = 3, int delayBetweenAttempts = 1000)
        {
            int attempts = 0;
            List<Kategori> kategoriListe = null;

            while ((kategoriListe == null || kategoriListe.Count == 0))
            {
                try
                {
                    attempts++;
                    kategoriListe = StaticVariables.urunServisClient.SelectKategori(WSYetki, sayi, dil);
                    if (kategoriListe != null && kategoriListe.Count > 0) break; // Eğer sipariş listesi alındıysa döngüden çık
                }
                catch (Exception ex)
                {
                    // Loglama veya hata yönetimi
                    Console.WriteLine($"Deneme {attempts}: {ex.Message}");
                }

                // Belirlenen süre kadar bekleyin
                if (kategoriListe == null || kategoriListe.Count == 0)
                {
                    Thread.Sleep(delayBetweenAttempts);
                }
            }

            return kategoriListe;
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


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanına kayıt sırasında bir hata oluştu: " + ex.Message);
                }
            }
        }
        public static List<Kategori> SelectKategori()
        {
            try
            {
                string sitead = Properties.Settings.Default.txtSiteAdi;
                string WSYetki = Properties.Settings.Default.txtWsYetki;
                StaticVariables.urunServisClient = new UrunServis.UrunServisClient();

                StaticVariables.urunServisClient.Endpoint.Address = new System.ServiceModel.EndpointAddress($"https://{sitead}/Servis/UrunServis.svc");


                List<Kategori> kategoriListe = UrunServiceMethods.GetUrunWithRetry(WSYetki, 0, "");
                if (kategoriListe != null && kategoriListe.Count > 0)
                {
                    KategorileriKaydet(kategoriListe);
                }
                else
                {


                    MessageBox.Show("Kategori Çekilemedi Tekrar deneyin.");
                    // Sipariş listesi alınamadıysa uygun bir hata mesajı göster

                }
                // List<WebSiparisUrun> uyeAdresListe = SiparisServiceMethods.SelectSiparisDetay();
                // MessageBox.Show("Son 10 günün siparişleri listelendi");

                //StaticFunctions.CevapListele(siparisListe.Cast<object>().ToList(), "Siparişler");

                return kategoriListe;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        public static void SaveKategoriParent()
        {
            try
            {
                StaticVariables.urunServisClient.SaveKategoriParent(StaticVariables.uyeKodu, 2, 1);
                MessageBox.Show("Kategori parent eklendi.");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public static List<Kategori> GetKategoriFromSP()
        {
            List<Kategori> kategoriListesi = new List<Kategori>();



            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("MSG_GetMSGTicimaxSeoKategori", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) // while döngüsüne dikkat edin
                            {

                                Kategori kategori = new Kategori
                                {
                                    ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                    Tanim = reader["Tanim"] != DBNull.Value ? reader["Tanim"].ToString() : string.Empty,
                                    // Örnek olarak PID ve Aktif doldurulmuştur, geri kalan alanları benzer şekilde doldurabilirsiniz.
                                    PID = reader["PID"] != DBNull.Value ? Convert.ToInt32(reader["PID"]) : 0,
                                    Aktif = reader["Aktif"] != DBNull.Value ? Convert.ToBoolean(reader["Aktif"]) : false,
                                    // Diğer alanlarınızı benzer bir kontrol ile doldurun
                                    Kod = reader["Kod"] != DBNull.Value ? reader["Kod"].ToString() : string.Empty,
                                    SeoAnahtarKelime = reader["SeoAnahtarKelime"] != DBNull.Value ? reader["SeoAnahtarKelime"].ToString() : string.Empty,
                                    SeoSayfaAciklama = reader["SeoSayfaAciklama"] != DBNull.Value ? reader["SeoSayfaAciklama"].ToString() : string.Empty,
                                    SeoSayfaBaslik = reader["SeoSayfaBaslik"] != DBNull.Value ? reader["SeoSayfaBaslik"].ToString() : string.Empty,
                                    Icerik = reader["Icerik"] != DBNull.Value ? reader["Icerik"].ToString() : string.Empty,
                                    Sira = reader["Sira"] != DBNull.Value ? Convert.ToInt32(reader["Sira"]) : 0,
                                    Url = reader["Url"] != DBNull.Value ? reader["Url"].ToString() : string.Empty,
                                };
                                kategoriListesi.Add(kategori);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Burada SQL bağlantısı açma veya komut çalıştırma sırasında bir hata oluştu
                Console.WriteLine("SQL işlemi sırasında bir hata oluştu: " + ex.Message);
            }
            return kategoriListesi;
        }


        public static int SaveKategori()
        {
            try
            {
                //List<Kategori> kategoriListesi = GetKategoriFromSP();
                string sitead = Properties.Settings.Default.txtSiteAdi;
                string WSYetki = Properties.Settings.Default.txtWsYetki;
                StaticVariables.urunServisClient = new UrunServis.UrunServisClient();

                StaticVariables.urunServisClient.Endpoint.Address = new System.ServiceModel.EndpointAddress($"https://{sitead}/Servis/UrunServis.svc");

                try
                {
                    List<Kategori> kategoriListesi = GetKategoriFromSP();
                    foreach (var kategori in kategoriListesi)
                    {
                        // Servis aracılığıyla her bir kategoriyi kaydedin
                        int eklenenKategoriId = StaticVariables.urunServisClient.SaveKategori(WSYetki, kategori);


                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Hata: {exception.Message}");
                }
                return 0;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return 0;
            }
        }
        public static void SaveIlgiliUrun()
        {
            List<IlgiliUrun> ilgiliUrunListe = new List<IlgiliUrun>();

            // UrunKartiID =205 olan ürüne 206 , 206 olan ürüne de 205 i ilgili ürün olarak ekler. İstersek tek taraflı da ekleyebiliriz. 
            IlgiliUrun ilgiliUrun = new IlgiliUrun
            {
                UrunKartiID = 205,
                IlgiliUrunKartiID = 206
            };
            IlgiliUrun ilgiliUrun2 = new IlgiliUrun
            {
                UrunKartiID = 206,
                IlgiliUrunKartiID = 205
            };

            ilgiliUrunListe.Add(ilgiliUrun);
            ilgiliUrunListe.Add(ilgiliUrun2);

            StaticVariables.urunServisClient.SaveIlgiliUrun(StaticVariables.uyeKodu, ilgiliUrunListe);
        }
        public static List<IlgiliUrun> SelectIlgiliUrun()
        {
            try
            {
                // ikisi de 0 gönderilir ise tüm ilgili ürünler listelenir. Urun kartı id ve ilgili ürün kartı id lere göre de filtrelenebilir.
                List<IlgiliUrun> ilgiliUrunListe = StaticVariables.urunServisClient.SelectIlgiliUrun(StaticVariables.uyeKodu, 0, 0);

                //StaticFunctions.CevapListele(ilgiliUrunListe.Cast<object>().ToList(), "İlgili Ürün Listesi");

                return ilgiliUrunListe;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
        // buradan aşağısı dökümanda ve mevcut versiyonda yok 
        public static void SaveUrunKategori()
        {
            List<UrunKategori> urunkategoriListe = new List<UrunKategori>();
            UrunKategori urunKategori = new UrunKategori
            {
                KategoriID = 53,
                UrunKartiID = 205,
                Sira = 1
            };
            urunkategoriListe.Add(urunKategori);
            StaticVariables.urunServisClient.SaveUrunKategori(StaticVariables.uyeKodu, urunkategoriListe);
        }
        public static void DeleteUrunKategori()
        {
            List<UrunKategori> urunKategoriListe = new List<UrunKategori>();
            UrunKategori urunKategori = new UrunKategori
            {
                KategoriID = 205,
                UrunKartiID = 53,
                Sira = 1
            };
            urunKategoriListe.Add(urunKategori);
            StaticVariables.urunServisClient.DeleteUrunKategori(StaticVariables.uyeKodu, urunKategoriListe);
        }
        public static void SaveUrunEtiket()
        {
            List<UrunEtiket> liste = new List<UrunEtiket>();
            UrunEtiket etiket = new UrunEtiket
            {
                EtiketID = 2,
                UrunKartiID = 205,
                Sira = 5
            };
            liste.Add(etiket);
            StaticVariables.urunServisClient.SaveUrunEtiket(StaticVariables.uyeKodu, liste);
        }
        public static void DeleteUrunEtiket()
        {
            try
            {
                List<UrunEtiket> liste = new List<UrunEtiket>();
                UrunEtiket etiket = new UrunEtiket
                {
                    // iki alan da  zorunlu 
                    EtiketID = 1,
                    UrunKartiID = 1,
                };

                liste.Add(etiket);
                StaticVariables.urunServisClient.DeleteUrunEtiket(StaticVariables.uyeKodu, liste);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public static List<UrunEtiket> SelectUrunEtiket()
        {
            // etiket id dolu urun karti id 0 gönderilir ise gönderilen etiket id yi içeren  tüm kayıtlar gelir aynısı ürün kartı id için de geçerlidir.  
            List<UrunEtiket> urunEtiketListe = StaticVariables.urunServisClient.SelectUrunEtiket(StaticVariables.uyeKodu, 0, 206);
            return urunEtiketListe;
        }
        public static void DeleteIlgiliUrun()
        {
            // girilen idli ürün kartını içeren tüm ilgili ürünler silinir.
            StaticVariables.urunServisClient.DeleteIlgiliUrun(StaticVariables.uyeKodu, 205);
        }


    }
}
