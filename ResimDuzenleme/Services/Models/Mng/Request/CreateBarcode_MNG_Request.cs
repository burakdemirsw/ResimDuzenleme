
using Newtonsoft.Json;
using ResimDuzenleme.Services.Models.MNG.Order;
using System.Collections.Generic;

namespace ResimDuzenleme.Services.Models.MNG.Request
{
    public class CreateBarcode_MNG_Request
    {
        [JsonProperty("referenceId")]
        public string ReferenceId { get; set; }
        [JsonProperty("billOfLandingId")]
        public string BillOfLandingId { get; set; }
        [JsonProperty("isCOD")]
        public int IsCOD { get; set; }
        [JsonProperty("codAmount")]
        public int CodAmount { get; set; }
        [JsonProperty("packagingType")]
        public int PackagingType { get; set; }
        [JsonProperty("orderPieceList")]
        //public CreatePackage_MNG_RR Response { get; set; }
        public List<OrderPieceList_MNG> OrderPieceList { get; set; }

    }

}
