using System.Collections.Generic;

namespace ResimDuzenleme
{

    public class Item
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
        public List<ProductLots> ProductLots { get; set; }
        public List<Descriptions> Descriptions { get; set; }
        public List<ItemNote> ItemNotes { get; set; }
    }


    public class Item3
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
    }


    public class Variant
    {
        public string ColorCode { get; set; }
        public string ItemDim1Code { get; set; }
    }

    public class BasePrice
    {
        public int BasePriceCode { get; set; }
        public string CountryCode { get; set; }
        public string CurrencyCode { get; set; }
        public double Price { get; set; }
        public string PriceDate { get; set; }
    }

    public class Barcodes
    {
        public string Barcode { get; set; }
        public string BarcodeTypeCode { get; set; }
        public string ColorCode { get; set; }
        public string ItemDim1Code { get; set; }
        public int Qty { get; set; }
        public string UnitOfMeasureCode { get; set; }
    }

    public class Descriptions
    {
        public string DataLanguageCode { get; set; }
        public string Description { get; set; }
    }

    public class ItemNote
    {
        public string LangCode { get; set; }
        public string Notes { get; set; }
        public string PlainText { get; set; }
    }

    public class ProductLots
    {
        public string DeleteWithProductLotBarcode { get; set; }
        public string IsDefault { get; set; }
        public string LotCode { get; set; }
    }
}
