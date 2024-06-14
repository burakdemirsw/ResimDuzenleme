using System.Collections.Generic;

namespace ResimDuzenleme
{
    public class TrendyolContentModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ProductAttribute> Attributes { get; set; }
        public string Barcode { get; set; }
        public string Brand { get; set; }
        public int BrandId { get; set; }
        public int pimCategoryId { get; set; }
        public string CategoryName { get; set; }
        public long CreateDateTime { get; set; }
        public string Gender { get; set; }
        public bool HasActiveCampaign { get; set; }
        public List<ProductImage> Images { get; set; }
        public long LastPriceChangeDate { get; set; }
        public long LastStockChangeDate { get; set; }
        public decimal ListPrice { get; set; }
        public bool Locked { get; set; }
        public bool OnSale { get; set; }
        public int PimCategoryId { get; set; }
        public string PlatformListingId { get; set; }
        public string ProductCode { get; set; }
        public int ProductContentId { get; set; }
        public string ProductMainId { get; set; }
        public int Quantity { get; set; }
        public int ReturningAddressId { get; set; }
        public decimal SalePrice { get; set; }
        public int ShipmentAddressId { get; set; }
        public string StockCode { get; set; }
        public string StockId { get; set; }
        public string StockUnitType { get; set; }
        public int SupplierId { get; set; }
        public int VatRate { get; set; }
        public int DeliveryDuration { get; set; }
        public int Version { get; set; }
        public bool Rejected { get; set; }
        public List<string> RejectReasonDetails { get; set; }
        public bool Blacklisted { get; set; }
        public DeliveryOptions DeliveryOptions { get; set; }
    }

}
