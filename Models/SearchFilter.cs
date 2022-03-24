using System.Collections.Generic;
using System.Text.Json;

namespace Inchcape.Akeneo.Connector.Models
{
    public class SearchFilter
    {
        private readonly string attribute;
        private readonly string @operator;
        private readonly object value;

        public SearchFilter(string attribute, string @operator, object value)
        {
            this.attribute = attribute;
            this.@operator = @operator;
            this.value = value;
        }
        
        public override string ToString()
        {
            var searchQuery = JsonSerializer.Serialize(new Dictionary<string, object>
            {
                { 
                    attribute, new object[]
                    {
                        new
                        {
                            @operator,
                            value
                        }
                    }
                }
            });

            return searchQuery;
        }

        public static string Set(string attribute, string @operator, object value)
        {
            return new SearchFilter(
                attribute,
                @operator,
                value
            ).ToString();
        }
    }
}