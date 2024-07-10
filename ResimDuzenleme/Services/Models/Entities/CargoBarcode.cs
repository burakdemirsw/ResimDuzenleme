using System;

namespace ResimDuzenleme.Services.Models.Entities
{
    public class CargoBarcode : BaseEntity
    {
        public int CargoFirmId { get; set; }

        public string OrderRequest { get; set; }
        public string OrderResponse { get; set; }
        public string BarcodeResponse { get; set; }
        public string OrderNo { get; set; }
        public string ReferenceId { get; set; }
        public string BarcodeZplCode { get; set; }
        public string ShipmentId { get; set; }
        public string Customer { get; set; }
        public string BarcodeRequest { get; set; }
        public int Desi { get; set; }
        public int Kg { get; set; }
        public int PackagingType { get; set; }
        public int BarcodeSequence { get; set; }
        public string Marketplace { get; set; }
        public string SalesUrl { get; set; }

        public string FirstItem { get; set; }
        public string OrderStatus { get; set; }
        public string Country { get; set; }
        public DateTime OrderDate { get; set; }


    }
    public class CargoBarcode_VM
    {
        public int CargoFirmId { get; set; }

        public string OrderNo { get; set; }
        public string ReferenceId { get; set; }
        public string BarcodeZplCode { get; set; }
        public string ShipmentId { get; set; }
        public string Customer { get; set; }

        public string BarcodeRequest { get; set; }
        public int Desi { get; set; }
        public int Kg { get; set; }
        public int PackagingType { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsPrinted { get; set; }


    }
    public class ZTMSG_CreateCargoBarcode
    {
        public string Order { get; set; }
        public string Recepient { get; set; }
        public string BarcodeRequest { get; set; }
        public string OrderPieceList { get; set; }
        public string BarcodeBase64 { get; set; }
        public int CargoFirmId { get; set; }
        public string Marketplace { get; set; }
        public string SalesUrl { get; set; }
        public string FirstItem { get; set; }
        public string OrderStatus { get; set; }
        public string Country { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
