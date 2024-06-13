using System;
using System.Collections.Generic;

namespace ResimDuzenleme
{
    class ZtNebimFaturaRYD
    {



        public int ModelType { get; set; }
        public string CustomerCode { get; set; }
        public string OfficeCode { get; set; }
        public string StoreCode { get; set; }
        public string WarehouseCode { get; set; }
        public string DocCurrencyCode { get; set; }
        public string DeliveryCompanyCode { get; set; }
        public string BillingPostalAddressID { get; set; }
        public string ShippingPostalAddressID { get; set; }
        public int PosTerminalID { get; set; }
        public int ShipmentMethodCode { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsSalesViaInternet { get; set; }
        public string DocumentNumber { get; set; }
        public string Description { get; set; }
        public string InternalDescription { get; set; }
        public List<InvoiceLinesYD> Lines { get; set; }
        public OrdersViaInternetInfo OrdersViaInternetInfo { get; set; }


    }

    public class InvoiceLinesYD
    {

        public string UsedBarcode { get; set; }
        public int VatRate { get; set; }
        public string DocCurrencyCode { get; set; }
        public decimal PriceVI { get; set; }
        public decimal AmountVI { get; set; }
        public int Qty1 { get; set; }

    }

}
