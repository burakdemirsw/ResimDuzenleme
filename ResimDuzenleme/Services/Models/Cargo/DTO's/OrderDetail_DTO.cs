using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResimDuzenleme.Services.Models.DTO_s
{
    public class OrderDetail_DTO
    {
        public string OrderNumber { get; set; }
        public string CurrAccCode { get; set; }
        public string DeliveryCompanyDescription { get; set; }
        public string SalesURL { get; set; }
        public string Desi { get; set; }
        public string Desi2 { get; set; }
        public string Description { get; set; }
        public string InternalDescription { get; set; }
        public decimal Amount { get; set; }
    }
}
