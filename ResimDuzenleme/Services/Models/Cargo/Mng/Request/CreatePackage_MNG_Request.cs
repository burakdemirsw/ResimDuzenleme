

using System.Collections.Generic;
using ResimDuzenleme.Services.Models.MNG.Cargo;
using ResimDuzenleme.Services.Models.MNG.Order;

namespace ResimDuzenleme.Services.Models.MNG.Request
{
    public class CreatePackage_MNG_Request
    {
        public Order_MNG Order { get; set; }
        public List<OrderPieceList_MNG> OrderPieceList { get; set; }
        //public Shipper_MNG Shipper { get; set; }
        public Recipient_MNG Recipient { get; set; }
    }

    public class CreatePackage_MNG_RM
    {
        public CreatePackage_MNG_Request OrderRequest { get; set; }
        public CreateBarcode_MNG_Request BarcodeRequest { get; set; }
        public string BarcodeBase64 { get; set; }
        public int CargoFirmId { get; set; }

    }

}
