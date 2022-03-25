using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json;

namespace Inchcape.Akeneo.Connector.Models
{
    public class SearchFilter
    {
        private readonly Dictionary<string, List<object>> _searchQuery = new Dictionary<string, List<object>>();


        public SearchFilter Set(string attribute, string @operator, object value, string locale = null, string scope = null)
        {
            if (!_searchQuery.ContainsKey(attribute))
            {
                var obj = new Dictionary<string, object> { { "operator", @operator } };
                
                if (value != null) obj.Add("value", value);
                if (scope != null) obj.Add("scope", scope);
                if (locale != null) obj.Add("locale", locale);
                
                _searchQuery.Add(attribute, new List<object> { obj });
            }

            return this;
        }
        
        public override string ToString() => JsonConvert.SerializeObject(_searchQuery);
    }
}