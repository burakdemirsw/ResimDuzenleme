using System.Collections.Generic;

namespace ResimDuzenleme
{
    public class Stok
    {

        public string ModelType { get; set; }
        public string OfficeCode { get; set; }
        public string StoreCode { get; set; }
        public string WarehouseCode { get; set; }
        public int CompanyCode { get; set; }
        public int InnerProcessType { get; set; }
        public List<Lines> Lines { get; set; }

    }
    public class Lines
    {
        public int ItemTypeCode { get; set; }
        public string UsedBarcode { get; set; }
        public string BatchCode { get; set; }
        public int Qty1 { get; set; }
        public int Qty2 { get; set; }
    }




    public class Stok2
    {

        public string ModelType { get; set; }
        public string OfficeCode { get; set; }
        public string StoreCode { get; set; }
        public string WarehouseCode { get; set; }
        public int CompanyCode { get; set; }
        public int InnerProcessType { get; set; }
        public List<Lines2> Lines { get; set; }

    }
    public class Lines2
    {
        public int ItemTypeCode { get; set; }
        public string Itemcode { get; set; }
        public string ColorCode { get; set; }
        public string Itemdim1Code { get; set; }
        public int Qty1 { get; set; }
        public int Qty2 { get; set; }
    }

}
