using Inchcape.Akeneo.Connector.Interfaces;
using Inchcape.Akeneo.Connector.Models;

namespace Inchcape.Akeneo.Connector.Responses
{
    public class PimProductResponse : PimValueDictionaryBase, IPimResponseObject.IWithAssociations
    {
        public string Code { get; set; }
        public string Identifier { get; set; }
        public string Family { get; set; }
        public string Parent { get; set; }
        public bool Enabled { get; set; }
        public AssociationsDictionary Associations { get; set; }
    }
}
