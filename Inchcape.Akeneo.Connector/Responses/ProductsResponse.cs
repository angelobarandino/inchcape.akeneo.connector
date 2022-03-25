using System.Collections.Generic;
using Inchcape.Akeneo.Connector.Utils.Converters;
using Newtonsoft.Json;

namespace Inchcape.Akeneo.Connector.Responses
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class ProductsResponse
    {
        [JsonProperty("current_page")] 
        public int CurrentPage { get; set; }

        [JsonProperty("items_count")] 
        public int ItemsCount { get; set; }

        [JsonProperty("_embedded.items")] 
        public List<ProductResponse> Items { get; set; }
    }
}