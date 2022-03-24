using Inchcape.Akeneo.Connector.Interfaces;

namespace Inchcape.Akeneo.Connector.Responses
{
    public class PimReferenceEntityItem : PimValueDictionaryBase, IPimResponseObject
    {
        public string Code { get; set; }
        public string Identifier { get; set; }
        public string Family { get; set; }
        public string Parent { get; set; }
        public bool Enabled { get; set; }
    }
}
