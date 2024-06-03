using Newtonsoft.Json;

namespace ResimDuzenleme.Services.Models.MNG.Response
{
    public class DeletePackage_MNG_Request
    {
        [JsonProperty("referenceId")]

        public string ReferenceId { get; set; }
        [JsonProperty("shipmentId")]

        public string ShipmentId { get; set; }

    }



}
