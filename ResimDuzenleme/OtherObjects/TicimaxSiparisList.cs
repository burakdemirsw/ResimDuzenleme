using System;

namespace ResimDuzenleme
{
    public class TicimaxSiparisList
    {
        public string AdiSoyadi { get; set; }
        public int SiparisID { get; set; }
        public string MarketPlaceKampanyaKodu { get; set; }
        public string SiparisNo { get; set; }
        public DateTime SiparisTarihi { get; set; }

    }



    public class TicimaxSiparisListDetay
    {
        public int SiparisID { get; set; }
        public int SiparisDetayID { get; set; }
        public string Barkod { get; set; }
        public int Adet { get; set; }
        public string MagazaKodu { get; set; }
    }
}
