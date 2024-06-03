using Newtonsoft.Json;

namespace ResimDuzenleme
{
    public class VM_HttpConnectionRequest
    {
        [JsonProperty("SessionID")]
        public string SessionId { get; set; }
    }
}
