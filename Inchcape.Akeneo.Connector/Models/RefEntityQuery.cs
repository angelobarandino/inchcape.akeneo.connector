using Refit;

namespace Inchcape.Akeneo.Connector.Models
{
    public class RefEntityQueryParams
    {
        [AliasAs("locales")] public string Locales { get; set; }
        [AliasAs("channel")] public string Channel { get; set; }
        [AliasAs("search")] public string Search { get; set; }
        [AliasAs("search_after ")] public string SearchAfter  { get; set; }
    }
}
