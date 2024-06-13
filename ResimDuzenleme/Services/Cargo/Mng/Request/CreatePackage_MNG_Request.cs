using GoogleAPI.Domain.Models.Cargo.Mng.Order;
using System.Collections.Generic;


namespace GoogleAPI.Domain.Models.Cargo.Mng.Request
{
    public class CreatePackage_MNG_Request
    {
        public Order_MNG Order { get; set; }
        public List<OrderPieceList_MNG> OrderPieceList { get; set; }
        //public Shipper_MNG Shipper { get; set; }
        public Recipient_MNG Recipient { get; set; }
    }

}
