using System.Collections.Generic;
using Inchcape.Akeneo.Connector.Utils.Converters;
using Newtonsoft.Json;

namespace Inchcape.Akeneo.Connector.Responses
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class AssetFamiliesResponse
    {
        [JsonProperty("_embedded.items")]
        public List<AssetFamilyItem> Items { get; set; }
    }
}