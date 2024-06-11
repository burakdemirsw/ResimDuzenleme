using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResimDuzenleme.Services.Cargo.Reports.ReportModels
{
    public class CargoBarcode_ZPL
    {
        public string CargoCompany { get; set; }

        public string SupplierName { get; set; }
        public string ReceiverName { get; set; }
        public string Address { get; set; }
        public string Desi { get; set; }
        public string Kg { get; set; }
        public string ShipmentType { get; set; }
        public string Amount { get; set; }
        public string PaymentType { get; set; }
        public string CargoBarcode { get; set; }
        public string OrderNo { get; set; }
        public string CreatedDate { get; set; }
        public string Description { get; set; }

    }
}
