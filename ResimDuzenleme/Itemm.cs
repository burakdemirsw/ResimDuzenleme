using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResimDuzenleme
{

    public class Itemm
    {
        public string ModelType { get; set; }
        public string ItemTypeCode { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public int ItemDimTypeCode { get; set; }
        public string ItemTaxGrCode { get; set; }
        public int ProductHierarchyID { get; set; }
        public bool UsePOS { get; set; }
        public bool UseStore { get; set; }
        public bool UseInternet { get; set; }
        public string UnitOfMeasureCode1 { get; set; }
        public List<Variant> Variants { get; set; }
        public List<BasePrice> BasePrices { get; set; }
        public bool UseBatch { get; set; }
        public bool UseManufacturing { get; set; }
        public bool UseRoll { get; set; }
        public bool UseSerialNumber { get; set; }
        public List<Barcodes> Barcodes { get; set; }
        public List<Descriptions> Descriptions { get; set; }
        public List<ItemNote> ItemNotes { get; set; }



        public void HandleNullFields()
        {
            if (Variants == null)
            {
                Variants = new List<Variant>();
            }
            if (BasePrices == null)
            {
                BasePrices = new List<BasePrice>();
            }
            if (Barcodes == null)
            {
                Barcodes = new List<Barcodes>();
            }
            if (Descriptions == null)
            {
                Descriptions = new List<Descriptions>();
            }
            if (ItemNotes == null)
            {
                ItemNotes = new List<ItemNote>();
            }
        }
    }

   
}
