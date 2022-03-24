using Refit;

namespace Inchcape.Akeneo.Connector.Models
{
    public class FilterParams
    {
        [AliasAs("locales")] public string Locales { get; set; }

        [AliasAs("channel")] public string Channel { get; set; }
        [AliasAs("search")] public string Search { get; set; }

        public FilterParams()
        {
        }

        public FilterParams(string attribute, string @operator, object value)
        {
            Search = new SearchFilter(attribute, @operator, value).ToString();
        }
    }
}
