using Inchcape.Akeneo.Connector.Interfaces;
using Inchcape.Akeneo.Connector.Models;

namespace Inchcape.Akeneo.Connector.Responses
{
    public abstract class ValueDictionaryBase : IPimValueDictionary
    {
        public ValuesDictionary Values { get; set; }
    }
}
