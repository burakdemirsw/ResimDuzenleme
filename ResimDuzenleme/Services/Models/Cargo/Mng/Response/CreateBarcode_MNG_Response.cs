using Newtonsoft.Json;
using System.Collections.Generic;

namespace ResimDuzenleme.Services.Models.MNG.Response
{
    

    public class CreateBarcode_MNG_Response
    {
        [JsonProperty("referenceId")]
        public string ReferenceId { get; set; }

        [JsonProperty("invoiceId")]
        public string InvoiceId { get; set; }

        [JsonProperty("shipmentId")]
        public string ShipmentId { get; set; }

        [JsonProperty("barcodes")]
        public List<Barcode_MNG> Barcodes { get; set; }

        [JsonProperty("referenceBarcodeOnError")]
        public string ReferenceBarcodeOnError { get; set; }

        public List<string> BarcodePaths { get; set; }
    }




}
