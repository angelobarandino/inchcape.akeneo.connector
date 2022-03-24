using Inchcape.Akeneo.Connector.Interfaces;
using Inchcape.Akeneo.Connector.Models;

namespace Inchcape.Akeneo.Connector.Responses
{
    public abstract class PimValueDictionaryBase : IPimValueDictionary
    {
        public ValuesDictionary Values { get; set; }
    }
}
