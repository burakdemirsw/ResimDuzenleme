using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ResimDuzenleme
{
    public class VM_HttpConnectionRequest
    {
        [JsonProperty("SessionID")]
        public string SessionId { get; set; }
    }
}
