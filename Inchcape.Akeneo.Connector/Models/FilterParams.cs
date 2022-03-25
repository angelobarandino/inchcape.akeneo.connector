using Refit;

namespace Inchcape.Akeneo.Connector.Models
{
    public class FilterParams
    {
        [AliasAs("locales")] public string Locales { get; set; }
        [AliasAs("channel")] public string Channel { get; set; }
        [AliasAs("search")] public string Search { get; set; }

    }
}
