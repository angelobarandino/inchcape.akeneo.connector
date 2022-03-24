using System.Collections.Generic;
using Inchcape.Akeneo.Connector.Utils.Converters;
using Newtonsoft.Json;

namespace Inchcape.Akeneo.Connector.Responses
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class AkeneoProductSearchResponse
    {
        [JsonProperty("current_page")] 
        public int CurrentPage { get; set; }
        
        [JsonProperty("_embedded.items")]
        public List<PimProductResponse> Items { get; set; }
    }
}