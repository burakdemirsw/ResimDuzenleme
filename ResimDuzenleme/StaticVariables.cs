using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResimDuzenleme.UrunServis;


namespace ResimDuzenleme
{

    //public partial class StaticVariables
    //{

    //    public static SiparisServis.SiparisServisClient siparisServisClient;


    //    public static string uyeKodu = Properties.Settings.Default.txtWsYetki;
    //    public static string alanAdi =  Properties.Settings.Default.txtSiteAdi;


    //}


    public static class StaticVariables
    {

        //public static SiparisServis.SiparisServisClient siparisServisClient;
        public static SiparisServis.SiparisServisClient siparisServisClient;
        public static UrunServis.UrunServisClient urunServisClient;
        //public static UyeServis.UyeServisClient uyeServisClient = new UyeServisClient();
  
        public static CustomServis.CustomServisClient customServisClient;
        public static UyeServis.UyeServisClient uyeServisClient;
        public static string uyeKodu = "";
        public static string alanAdi = "";
        public static List<Kategori> kategoriList = new List<Kategori>();
        public static List<Marka> markaList = new List<Marka>();
        public static List<Tedarikci> tedarikciList = new List<Tedarikci>();
        public static List<Etiket> etiketList = new List<Etiket>();
        public enum Tip { Kategori, Marka, Tedarikci, Etiket }
        //public static string uyeKodu = "";
        //public static string alanAdi = "";



    }
}
