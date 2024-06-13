using System;
using System.Collections.Generic;

namespace ResimDuzenleme
{
    public class ZTMSGTicUyeAdres
    {
        public int ModelType { get; set; }
        public string CurrAccCode { get; set; }
        public string CurrAccDescription { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsIndividualAcc { get; set; }
        public bool IsSubjectToEInvoice { get; set; }
        public string IdentityNum { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOfficeCode { get; set; }
        public string CurrencyCode { get; set; }
        public string OfficeCode { get; set; }
        public string WholeSalePriceGroupCode { get; set; }
        public string RetailSalePriceGroupCode { get; set; }
        public int CustomerTypeCode { get; set; }
        public List<PostalAddress> PostalAddresses { get; set; }
        public List<Attribute> Attributes { get; set; }
        public List<Communication> Communications { get; set; }
    }

    public class ZTMSGTicUyeAdresR
    {
        public int ModelType { get; set; }
        public string CurrAccCode { get; set; }
        public string CurrAccDescription { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsIndividualAcc { get; set; }
        public bool IsSubjectToEInvoice { get; set; }
        public string IdentityNum { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOfficeCode { get; set; }
        public string CurrencyCode { get; set; }
        public string OfficeCode { get; set; }
        public string WholeSalePriceGroupCode { get; set; }
        public string RetailSalePriceGroupCode { get; set; }

        public List<PostalAddress> PostalAddresses { get; set; }
        public List<Communication> Communications { get; set; }
    }


    public class ZtNebimFaturaR
    {
        public int ModelType { get; set; }
        public string CustomerCode { get; set; }
        public string OfficeCode { get; set; }
        public string StoreCode { get; set; }
        public string StoreWarehouseCode { get; set; }
        public string DeliveryCompanyCode { get; set; }
        public int PosTerminalID { get; set; }
        public int ShipmentMethodCode { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsSalesViaInternet { get; set; }
        public string DocumentNumber { get; set; }
        public string Description { get; set; }
        public string InternalDescription { get; set; }
        public List<InvoiceLines> Lines { get; set; }
        public OrdersViaInternetInfo OrdersViaInternetInfo { get; set; }
        public List<Payments> Payments { get; set; }
    }



    public class ZtNebimFaturaROnline
    {
        public int ModelType { get; set; }
        public string CustomerCode { get; set; }
        public string OfficeCode { get; set; }
        public string StoreCode { get; set; }
        public string WarehouseCode { get; set; }
        public string DeliveryCompanyCode { get; set; }

        public string BillingPostalAddressID { get; set; }
        public string ShippingPostalAddressID { get; set; }
        public int TaxExemptionCode { get; set; }
        public int PosTerminalID { get; set; }
        public int ShipmentMethodCode { get; set; }
        public DateTime Invoicedate { get; set; }
        public bool SendInvoiceByEMail { get; set; }
        public bool IsOrderBase { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsSalesViaInternet { get; set; }
        public string EMailAddress { get; set; }
        public string Description { get; set; }
        public string InternalDescription { get; set; }
        public List<InvoiceLiness> Lines { get; set; }
        public SalesViaInternetInfo SalesViaInternetInfo { get; set; }

    }


    public class ZtNebimFaturaROnlineReturn
    {
        public int ModelType { get; set; }
        public bool Isreturn { get; set; }
        public string CustomerCode { get; set; }
        public string OfficeCode { get; set; }
        public string StoreCode { get; set; }
        public string WarehouseCode { get; set; }
        public string DeliveryCompanyCode { get; set; }
        public string Series { get; set; }
        public string SeriesNumber { get; set; }
        public string BillingPostalAddressID { get; set; }
        public string ShippingPostalAddressID { get; set; }
        public int TaxExemptionCode { get; set; }
        public int PosTerminalID { get; set; }
        public int ShipmentMethodCode { get; set; }
        public DateTime Invoicedate { get; set; }


        public bool IsCompleted { get; set; }


        public string Description { get; set; }
        public string InternalDescription { get; set; }
        public List<InvoiceLinesReturn> Lines { get; set; }
        public List<Payments> Payments { get; set; }


    }



    public class ZtNebimFaturaAlis
    {
        public int ModelType { get; set; }
        public string InvoiceNumber { get; set; }
        public string VendorCode { get; set; }
        public string EInvoiceNumber { get; set; }
        public string OfficeCode { get; set; }
        public string StoreCode { get; set; }
        public string WarehouseCode { get; set; }
        public string DeliveryCompanyCode { get; set; }

        public string BillingPostalAddressID { get; set; }
        public string ShippingPostalAddressID { get; set; }
        public int TaxExemptionCode { get; set; }
        public int PosTerminalID { get; set; }
        public int ShipmentMethodCode { get; set; }
        public DateTime Invoicedate { get; set; }

        public bool IsOrderBase { get; set; }


        public string Description { get; set; }
        public string InternalDescription { get; set; }
        public List<InvoiceLinesAlis> Lines { get; set; }
        public bool IsCompleted { get; set; }



    }

    public class InvoiceLinesAlis
    {

        public string OrderlineID { get; set; }

        public int VatRate { get; set; }
        public decimal PriceVI { get; set; }
        public decimal AmountVI { get; set; }
        public int Qty1 { get; set; }

    }


    public class ZtNebimFaturaROnlineCount
    {
        public int ModelType { get; set; }
        public string CustomerCode { get; set; }
        public string OfficeCode { get; set; }
        public string StoreCode { get; set; }
        public string WarehouseCode { get; set; }
        public string DeliveryCompanyCode { get; set; }

        public string BillingPostalAddressID { get; set; }
        public string ShippingPostalAddressID { get; set; }
        public int TaxExemptionCode { get; set; }
        public int PosTerminalID { get; set; }
        public int ShipmentMethodCode { get; set; }
        public DateTime Invoicedate { get; set; }
        public bool SendInvoiceByEMail { get; set; }
        public bool IsOrderBase { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsSalesViaInternet { get; set; }
        public string EMailAddress { get; set; }
        public string Description { get; set; }
        public string InternalDescription { get; set; }
        public List<InvoiceLiness> Lines { get; set; }
        public SalesViaInternetInfo SalesViaInternetInfo { get; set; }

    }




    public class ztNebimFaturaGoster
    {
        public string FaturaNo { get; set; }
        public string Cevap { get; set; }


    }
    public class ZtNebimFaturaRShipment
    {
        public int ModelType { get; set; }
        public string CustomerCode { get; set; }
        public string OfficeCode { get; set; }
        public string StoreCode { get; set; }
        public string WarehouseCode { get; set; }
        public string DeliveryCompanyCode { get; set; }

        public string BillingPostalAddressID { get; set; }
        public string ShippingPostalAddressID { get; set; }
        public int TaxExemptionCode { get; set; }
        public int PosTerminalID { get; set; }
        public int ShipmentMethodCode { get; set; }
        public DateTime Invoicedate { get; set; }
        public bool SendInvoiceByEMail { get; set; }
        public bool IsShipmentBase { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsSalesViaInternet { get; set; }
        public string EMailAddress { get; set; }
        public string Description { get; set; }
        public string InternalDescription { get; set; }
        public List<InvoiceLinesss> Lines { get; set; }
        public SalesViaInternetInfo SalesViaInternetInfo { get; set; }
        public List<Payments> Payments { get; set; }
        public PostalAddress PostalAddress { get; set; }


    }



    public class FaturaBilgisi2
    {
        public string DataBaseNebim { get; set; }
        public string IpAdres { get; set; }
        public string Firma { get; set; }
        public List<ZTMSGUrunListMisigo> UrunListesi { get; set; }

    }


    public class FaturaBilgisi
    {
        public string DataBaseNebim { get; set; }
        public string IpAdres { get; set; }
        public string Firma { get; set; }
    }
    public class InvoiceLines
    {

        public string UsedBarcode { get; set; }
        public int VatRate { get; set; }
        public decimal PriceVI { get; set; }
        public decimal AmountVI { get; set; }
        public int Qty1 { get; set; }

    }

    public class InvoiceLiness
    {

        public string OrderlineID { get; set; }
        public string UsedBarcode { get; set; }
        public int VatRate { get; set; }
        public decimal PriceVI { get; set; }
        public decimal AmountVI { get; set; }
        public decimal Qty1 { get; set; }

    }

    public class InvoiceLinesReturn
    {

        public string lineID { get; set; }
        public string UsedBarcode { get; set; }
        public int VatRate { get; set; }
        public decimal PriceVI { get; set; }
        public decimal AmountVI { get; set; }
        public int Qty1 { get; set; }
        public string ReturnReasonCode { get; set; }
    }


    public class InvoiceLinesss
    {

        public string ShipmentLineID { get; set; }
        public string ItemCode { get; set; }
        public string ColorCode { get; set; }
        public string ItemDim1Code { get; set; }
        public int VatRate { get; set; }
        public decimal PriceVI { get; set; }
        public decimal AmountVI { get; set; }
        public int Qty1 { get; set; }

    }


    public class OrdersViaInternetInfo
    {

        public string SalesURL { get; set; }
        public int PaymentTypeCode { get; set; }
        public string PaymentTypeDescription { get; set; }
        public string PaymentAgent { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime SendDate { get; set; }

    }


    public class SalesViaInternetInfo
    {

        public string SalesURL { get; set; }
        public int PaymentTypeCode { get; set; }
        public string PaymentTypeDescription { get; set; }
        public string PaymentAgent { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime SendDate { get; set; }

    }


    public class Payments
    {

        public int PaymentType { get; set; }
        public string Code { get; set; }
        public string CreditCardTypeCode { get; set; }
        public int InstallmentCount { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Amount { get; set; }


    }



    public class PostalAddress
    {
        public int AddressID { get; set; }
        public string CountryCode { get; set; }
        public string StateCode { get; set; }
        public string CityCode { get; set; }
        public string DistrictCode { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNum { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOfficeCode { get; set; }
        public string ZipCode { get; set; }


    }

    public class Attribute
    {
        public int AttributeTypeCode { get; set; }
        public string AttributeCode { get; set; }
    }

    public class Communication
    {
        public int CommunicationTypeCode { get; set; }
        public string CommAddress { get; set; }
    }
}
