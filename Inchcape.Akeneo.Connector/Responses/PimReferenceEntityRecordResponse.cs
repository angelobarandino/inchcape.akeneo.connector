using System.Text.Json;
using Inchcape.Akeneo.Connector.Interfaces;
using Newtonsoft.Json;

namespace Inchcape.Akeneo.Connector.Responses
{
    public class PimReferenceEntityRecordResponse : PimValueDictionaryBase, IPimCodeIdentifier
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        public string Identifier { get; set; }
    }
}
