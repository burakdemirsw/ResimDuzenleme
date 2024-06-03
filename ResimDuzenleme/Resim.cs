using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResimDuzenleme
{
    public class Resim
    {
        public int UrunKartiID { get; set; }
        public int VaryasyonID { get; set; }
        public string ResimAdresi { get; set; }
        public string ResimDurumu { get; set; }
        public Marka2 Marka { get; set; }
    }
}
