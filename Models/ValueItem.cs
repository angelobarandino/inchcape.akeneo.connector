using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Inchcape.Akeneo.Connector.Models
{
    public class ValueItem
    {
        public string Locale { get; set; }
        public string Scope { get; set; }
        public JToken Data { get; set; }
        
        [JsonProperty("_links")]
        public JObject Links { get; set; }
    }
}
