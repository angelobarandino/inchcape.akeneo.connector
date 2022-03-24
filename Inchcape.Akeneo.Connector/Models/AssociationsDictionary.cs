using System;
using System.Collections.Generic;

namespace Inchcape.Akeneo.Connector.Models
{
    public class AssociationsDictionary : Dictionary<string, AssociationItem>
    {
        public string[] GetProductIds(string property)
        {
            return !ContainsKey(property) ? Array.Empty<string>() : this[property].Products;
        }
    }
}