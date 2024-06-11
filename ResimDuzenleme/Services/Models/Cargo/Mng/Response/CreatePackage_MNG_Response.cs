using Newtonsoft.Json;

namespace ResimDuzenleme.Services.Models.MNG.Response
{
    public class CreatePackage_MNG_Response
    {
        [JsonProperty("orderInvoiceId")]
        public string OrderInvoiceId { get; set; }
        [JsonProperty("orderInvoiceDetailId")]

        public string OrderInvoiceDetailId { get; set; }
        [JsonProperty("shipperBranchCode")]

        public string ShipperBranchCode { get; set; }
    }



}
