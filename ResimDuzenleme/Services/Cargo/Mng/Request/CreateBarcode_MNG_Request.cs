using GoogleAPI.Domain.Models.Cargo.Mng.Order;
using System.Collections.Generic;

namespace ResimDuzenleme.Models.Cargo.Mng.Request
{
    public class CreateBarcode_MNG_Request
    {
        public string ReferenceId { get; set; }
        public string BillOfLandingId { get; set; }
        public int IsCOD { get; set; }
        public int CodAmount { get; set; }
        public int PackagingType { get; set; }
        public List<OrderPieceList_MNG> OrderPieceList { get; set; }
    }

}
