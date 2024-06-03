using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResimDuzenleme
{

    public class Urun
    {
        public int UrunKartiID { get; set; }
        public string UrunAdi { get; set; }
        public string OnYazi { get; set; }
        public string Aciklama { get; set; }
        public int MarkaID { get; set; }
        public int KategoriID { get; set; }
        public string SatisBirimi { get; set; }
        public string UrunUrl { get; set; }
        public string OzelAlan1 { get; set; }
        public string OzelAlan2 { get; set; }
        public string OzelAlan3 { get; set; }
        public string OzelAlan4 { get; set; }
        public string OzelAlan5 { get; set; }
        public List<Secenek> UrunSecenek { get; set; }
    }

    public class Secenek
    {
        public int VaryasyonID { get; set; }
        public string StokKodu { get; set; }
        public string Barkod { get; set; }
        public int StokAdedi { get; set; }
        public double AlisFiyati { get; set; }
        public double SatisFiyati { get; set; }
        public double IndirimliFiyat { get; set; }
        public bool KDVDahil { get; set; }
        public int KdvOrani { get; set; }
        public string ParaBirimi { get; set; }
        public int Desi { get; set; }
        public int UrunKartiID { get; set; }

        public List<Ozellik> EkSecenekOzellik { get; set; }
    }

    public class Ozellik
    {
        public int VaryasyonID { get; set; }
        public string Tanim { get; set; }
        public string Deger { get; set; }
    }
}
