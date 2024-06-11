using Newtonsoft.Json;

namespace ResimDuzenleme.Services.Models.MNG.Order
{
    public class OrderPieceList_MNG
    {
        [JsonProperty("barcode")]
        public string Barcode { get; set; }
        [JsonProperty("desi")]
        public int Desi { get; set; }
        [JsonProperty("kg")]
        public int Kg { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
    }

}
