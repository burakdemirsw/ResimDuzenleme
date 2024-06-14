using ResimDuzenleme.UrunServis;
using System.Collections.Generic;


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
        public static List<string> errors = new List<string>();

        public enum Tip { Kategori, Marka, Tedarikci, Etiket }
        public static bool DebugMode { get; set; } = false; 
        //public static string uyeKodu = "";
        //public static string alanAdi = "";



    }
    
}
