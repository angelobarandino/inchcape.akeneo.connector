using System.Collections.Generic;
using System.Text.Json;
using Inchcape.Akeneo.Connector.Utils.Converters;
using Newtonsoft.Json;

namespace Inchcape.Akeneo.Connector.Responses
{
    [JsonConverter(typeof(JsonPathConverter))]
    public class ReferenceEntityResponse
    {
        [JsonProperty("_embedded.items")]
        public List<ReferenceEntityItem> Items { get; set; }
    }
}
