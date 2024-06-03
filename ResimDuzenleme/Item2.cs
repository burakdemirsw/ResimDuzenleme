using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResimDuzenleme
{
   public class Item2
    {
        public string barcode { get; set; }
        public string title { get; set; }
        public string productMainId { get; set; }
        public int brandId { get; set; }
        public int categoryId { get; set; }
        public string stockCode { get; set; }
        public int dimensionalWeight { get; set; }
        public string description { get; set; }
        public int deliveryDuration { get; set; }
        public int vatRate { get; set; }
        //  public DeliveryOption deliveryOption { get; set; }
        public List<image> images { get; set; }
        public List<attribute> attributes { get; set; }
        public int cargoCompanyId { get; set; }
        public int shipmentAddressId { get; set; }
        public int returningAddressId { get; set; }
    }
}
