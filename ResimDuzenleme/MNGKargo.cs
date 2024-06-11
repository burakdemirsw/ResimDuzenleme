using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ResimDuzenleme.MngKargo;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.IO;
using Newtonsoft.Json;

using ResimDuzenleme.Services.Models.MNG.Request;
using ResimDuzenleme.Services.Models.MNG.Order;
using ResimDuzenleme.Services.Models.MNG.Cargo;


namespace ResimDuzenleme
{
    public partial class MNGKargo : Form
    {
        public MNGKargo()
        {
            InitializeComponent();
        }

        public class MngKargoBilgileriModel
        {
     
            public string KullaniciAdi { get; set; }
            public string Sifre { get; set; }
        }
        public class MngKargoSiparisBilgileri
        {
            public string pChIrsaliyeNo { get; set; }
            public double pPrKiymet { get; set; }
            public string pChBarkod { get; set; }
            public string pChIcerik { get; set; }
            public string pFlAlSms { get; set; }
            public string pFlGnSms { get; set; }
            public string pKargoParcaList { get; set; }
            public string pAliciMusteriMngNo { get; set; }
            public string pAliciMusteriBayiNo { get; set; }
            public string pAliciMusteriAdi { get; set; }
            public string pChSiparisNo { get; set; }
            public string pLuOdemeSekli { get; set; }
            public string pFlAdresFarkli { get; set; }
            public string pChIl { get; set; }
            public string pChIlce { get; set; }
            public string pChAdres { get; set; }
            public string pChSemt { get; set; }
            public string pChMahalle { get; set; }
            public string pChMeydanBulvar { get; set; }
            public string pChCadde { get; set; }
            public string pChSokak { get; set; }
            public string pChTelEv { get; set; }
            public string pChTelCep { get; set; }
            public string pChTelIs { get; set; }
            public string pChFax { get; set; }
            public string pChEmail { get; set; }
            public string pChVergiDairesi { get; set; }
            public string pChVergiNumarasi { get; set; }
            public string pFlKapidaOdeme { get; set; }
            public string pKullaniciAdi { get; set; }
            public string pSifre { get; set; }
        }

        //public void MngKargoBilgileriGuncelle(string KullaniciAdi, string Sifre)
        //{
        //    try
        //    {
        //        if (TicimaxCon.State == ConnectionState.Closed)
        //        {
        //            TicimaxCon.Open();
        //        }
        //        SqlCommand cmd = new SqlCommand("update MngKargoBilgileri set ApiKullaniciAdi=@KullaniciAdi,ApiSifre=@Sifre where id=1", TicimaxCon);
        //        cmd.Parameters.AddWithValue("@KullaniciAdi", KullaniciAdi);
        //        cmd.Parameters.AddWithValue("@Sifre", Sifre);
        //        cmd.ExecuteNonQuery();
        //        TicimaxCon.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        HataSinifi hata = new HataSinifi();
        //        hata.HataKaydet(ex.Message, "MngKargoBilgileriGuncelle");
        //    }
        //}

        public MngKargoBilgileriModel GetMngBilgileri()
        {
            MngKargoBilgileriModel mng = new MngKargoBilgileriModel();

            // Veritabanı bağlantı string'inizi buraya ekleyin
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            string query = "SELECT TOP 1 CustomerCode, PassWord FROM ZTMSGMNGKargoApi"; // Sadece ilk kaydı alacak şekilde güncellendi

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Sadece bir satır oku
                            {
                                mng.KullaniciAdi = reader["CustomerCode"].ToString();
                                mng.Sifre = reader["PassWord"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return mng;
        }
        public MngKargoSiparisBilgileri GetKargoBilgileri(string OrderNumber)
        {
            MngKargoSiparisBilgileri MngKargoBilgileri = new MngKargoSiparisBilgileri();
            DataTable dataTable = new DataTable();

            // Veritabanı bağlantı bilgilerini Properties.Settings'ten al
            string serverName = Properties.Settings.Default.SunucuAdi;
            string userName = Properties.Settings.Default.KullaniciAdi;
            string password = Properties.Settings.Default.Sifre;
            string database = Properties.Settings.Default.database;
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("MSGKargoKontrol", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@tsnumber", OrderNumber);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                }

                // DataTable'den gelen verileri MngKargoBilgileri nesnesine aktar
                if (dataTable.Rows.Count > 0)
                {
                    DataRow item = dataTable.Rows[0]; // Sadece ilk satırı alıyoruz, birden fazla sonuç beklemiyoruz.
                                                      // Veri atamalarını burada yap
                    MngKargoBilgileri = MapDataRowToMngKargoSiparisBilgileri(item);
                }
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                Console.WriteLine(ex.Message);
            }

            return MngKargoBilgileri;
        }

        private MngKargoSiparisBilgileri MapDataRowToMngKargoSiparisBilgileri(DataRow item)
        {
            // DataRow'dan MngKargoSiparisBilgileri'ne dönüşüm yapılıyor
            MngKargoSiparisBilgileri MngKargoBilgileri = new MngKargoSiparisBilgileri
            {
                // Özellik atamaları
                // Örnek:
                pChIrsaliyeNo = item["pChIrsaliyeNo"].ToString(),
                pPrKiymet = item["pPrKiymet"] != DBNull.Value ? Convert.ToDouble(item["pPrKiymet"].ToString()) : 0,
                pChBarkod = item["pChBarkod"].ToString(),
                pChIcerik = item["pChIcerik"].ToString(),
                pFlAlSms = item["pFlAlSms"].ToString(),
                pFlGnSms = item["pFlGnSms"].ToString(),
                pKargoParcaList = item["pKargoParcaList"].ToString(),
                pAliciMusteriMngNo = item["pAliciMusteriMngNo"].ToString(),
                pAliciMusteriBayiNo = item["pAliciMusteriBayiNo"].ToString(),
                pAliciMusteriAdi = item["pAliciMusteriAdi"].ToString(),
                pChSiparisNo = item["pChSiparisNo"].ToString(),
                pLuOdemeSekli = item["pLuOdemeSekli"].ToString(),
                pFlAdresFarkli = item["pFlAdresFarkli"].ToString(),
                pChIl = item["pChIl"].ToString(),
                pChIlce = item["pChIlce"].ToString(),
                pChAdres = item["pChAdres"].ToString(),
                pChSemt = item["pChSemt"].ToString(),
                pChMahalle = item["pChMahalle"].ToString(),
                pChMeydanBulvar = item["pChMeydanBulvar"].ToString(),
                pChCadde = item["pChCadde"].ToString(),
                pChSokak = item["pChSokak"].ToString(),
                pChTelEv = item["pChTelEv"].ToString(),
                pChTelCep = item["pChTelCep"].ToString(),
                pChTelIs = item["pChTelIs"].ToString(),
                pChFax = item["pChFax"].ToString(),
                pChEmail = item["pChEmail"].ToString(),
                pChVergiDairesi = item["pChVergiDairesi"].ToString(),
                pChVergiNumarasi = item["pChVergiNumarasi"].ToString(),
                pFlKapidaOdeme = item["pFlKapidaOdeme"].ToString(),
                pKullaniciAdi = item["pKullaniciAdi"].ToString(),
                pSifre = item["pSifre"].ToString(),
                // Diğer alanlar için de benzer atamalar yapılır
            };

            return MngKargoBilgileri;
        }

        //public string MngKargoGonderiOlustur(MngKargoSiparisBilgileri SiparisBilgileri)
        //{
        //    try
        //    {
        //        // Kullanıcı adı ve şifre bilgilerini al
        //        MngKargoBilgileriModel mng = GetMngBilgileri();

        //        // MNG Kargo SOAP servisine bağlan
        //        MusteriKargoSiparisSoapClient mngkargo = new MusteriKargoSiparisSoapClient("MusteriKargoSiparisSoap12");

        //        // SiparisGirisiDetayliV2 servis metodunu çağır
        //        string Cevap = mngkargo.SiparisGirisiDetayliV2(
        //            SiparisBilgileri.pChIrsaliyeNo,
        //            SiparisBilgileri.pPrKiymet.ToString(),
        //            SiparisBilgileri.pChBarkod,
        //            SiparisBilgileri.pChIcerik,
        //            Convert.ToInt32(SiparisBilgileri.pFlAlSms),
        //            Convert.ToInt32(SiparisBilgileri.pFlGnSms),
        //            SiparisBilgileri.pKargoParcaList,
        //            SiparisBilgileri.pAliciMusteriMngNo,
        //            SiparisBilgileri.pAliciMusteriBayiNo,
        //            SiparisBilgileri.pAliciMusteriAdi,
        //            SiparisBilgileri.pChSiparisNo,
        //            SiparisBilgileri.pLuOdemeSekli,
        //            SiparisBilgileri.pFlAdresFarkli,
        //            SiparisBilgileri.pChIl,
        //            SiparisBilgileri.pChIlce,
        //            SiparisBilgileri.pChAdres,
        //            SiparisBilgileri.pChSemt,
        //            SiparisBilgileri.pChMahalle,
        //            SiparisBilgileri.pChMeydanBulvar,
        //            SiparisBilgileri.pChCadde,
        //            SiparisBilgileri.pChSokak,
        //            SiparisBilgileri.pChTelEv,
        //            SiparisBilgileri.pChTelCep,
        //            SiparisBilgileri.pChTelIs,
        //            SiparisBilgileri.pChFax,
        //            SiparisBilgileri.pChEmail,
        //            SiparisBilgileri.pChVergiDairesi,
        //            SiparisBilgileri.pChVergiNumarasi,
        //            Convert.ToInt32(SiparisBilgileri.pFlKapidaOdeme),
        //            mng.KullaniciAdi,
        //            mng.Sifre);

        //        // Eğer işlem başarılı ise, servisten gelen cevabı döndür
        //        return Cevap;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Hata oluşursa, hatayı string olarak döndür
        //        return "Hata: " + ex.Message;
        //    }
        //}


        public string MngKargoGonderiOlustur(MngKargoSiparisBilgileri SiparisBilgileri)
        {
            try
            {

              


                ////string KullaniciAdi = "302617285";
                ////string Sifre = "DOCMPETU";
                //MngKargoBilgileriModel mng = GetMngBilgileri();
                //MusteriKargoSiparisSoapClient mngkargo = new MusteriKargoSiparisSoapClient();
                //string Cevap = mngkargo.SiparisGirisiDetayliV2(SiparisBilgileri.pChIrsaliyeNo, SiparisBilgileri.pPrKiymet.ToString(), SiparisBilgileri.pChBarkod, SiparisBilgileri.pChIcerik, Convert.ToInt32(SiparisBilgileri.pFlAlSms.ToString()), Convert.ToInt32(SiparisBilgileri.pFlGnSms.ToString
                //        ()), SiparisBilgileri.pKargoParcaList, SiparisBilgileri.pAliciMusteriMngNo, SiparisBilgileri.pAliciMusteriBayiNo, SiparisBilgileri.pAliciMusteriAdi, SiparisBilgileri.pChSiparisNo, SiparisBilgileri.pLuOdemeSekli, SiparisBilgileri.pFlAdresFarkli, SiparisBilgileri.pChIl, SiparisBilgileri.pChIlce, SiparisBilgileri.pChAdres, SiparisBilgileri.pChSemt, SiparisBilgileri.pChMahalle, SiparisBilgileri.pChMeydanBulvar, SiparisBilgileri.pChCadde, SiparisBilgileri.pChSokak, SiparisBilgileri.pChTelEv, SiparisBilgileri.pChTelCep, SiparisBilgileri.pChTelIs, SiparisBilgileri.pChFax, SiparisBilgileri.pChEmail, SiparisBilgileri.pChVergiDairesi, SiparisBilgileri.pChVergiNumarasi, Convert.ToInt32(SiparisBilgileri.pFlKapidaOdeme), mng.KullaniciAdi, mng.Sifre);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        //public void SiparisKargoBilgiDegistir(string OrderNumber)
        //{
        //    try
        //    {
        //        if (con.State == ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }
        //        SqlCommand cmd = new SqlCommand("Usp_KargoTakip", con);
        //        cmd.Parameters.AddWithValue("@Ordernumber", OrderNumber);
        //        cmd.Parameters.AddWithValue("@Kargo", true);
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //        con.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //    }
        //}
        private void MNGKargo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // textBox1'den sipariş numarasını al
            string orderNumber = textBox1.Text;

            if (!string.IsNullOrEmpty(orderNumber))
            {
                // Sipariş numarasını kullanarak kargo bilgilerini getir
                MngKargoSiparisBilgileri kargoBilgileri = GetKargoBilgileri(orderNumber);
                string cevap = MngKargoGonderiOlustur(kargoBilgileri);
                // Alınan kargo bilgilerini işle (Örneğin, kullanıcıya göster)
                // Burada basitçe bilgilerin bir kısmını MessageBox ile gösteriyorum.
                // Gerçek uygulamada, elde edilen bilgileri arayüzde uygun bir şekilde göstermelisiniz.
                string message = $"Irsaliye No: {kargoBilgileri.pChIrsaliyeNo}\n" +
                                 $"Barkod: {kargoBilgileri.pChBarkod}\n" +
                                 $"Alici: {kargoBilgileri.pAliciMusteriAdi}";
                MessageBox.Show(message, "Kargo Bilgileri", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Eğer textBox1 boşsa, kullanıcıyı uyar
                MessageBox.Show("Lütfen bir sipariş numarası giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
         

        }

  
    }
}
