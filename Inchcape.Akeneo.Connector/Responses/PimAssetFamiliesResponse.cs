using System.Collections.Generic;
using Inchcape.Akeneo.Connector.Utils.Converters;
using Newtonsoft.Json;

namespace Inchcape.Akeneo.Connector.Responses
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class PimAssetFamiliesResponse
    {
        [JsonProperty("_embedded.items")]
        public List<PimAssetFamilyItem> Items { get; set; }
    }
}